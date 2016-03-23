using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DcPet.Common;
using DcPet.Data;
using DcPet.Areas.Api.Models;
using DcPet.Models;

namespace DcPet.Areas.Api.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [FilterApp]
        public ActionResult data()
        {
            using (WorkUnit wu = new WorkUnit())
            {
                TResult T = new TResult();
                var juser = this.GetUser();
                var jpet = DcPets.GetEntitys(wu).Where(p => p.pet.token == juser.user.token).FirstOrDefault();
                T.data = new
                {
                    user = new
                    {
                        token = juser.user.token,
                        lastip = juser.user.lastip,
                        lasttime = juser.user.lasttime
                    },
                    userdata = (juser.data == null ? null : new
                    {
                        phone=juser.data.phonenumber,
                        name=juser.data.name,
                    }),
                    petdata=(jpet==null? null: new {
                        petname=jpet.pet.name,
                        pettype = jpet.pet.pettype,
                        petaddress = jpet.pet.address,
                        petarea = jpet.pet.area,
                        petdate = jpet.pet.date,
                        petdemand = jpet.pet.demand,
                        petsex = jpet.pet.sex,
                        petimages=jpet.petimages.OrderBy(p=>p.id).Select(p=>p.image).ToArray(),
                    }),
                };
                return T.ToResult();
            }
        }

        /// <summary>
        /// 编辑用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [FilterApp]
        public ActionResult data(UserViewModel model) {
            using (WorkUnit wu = new WorkUnit())
            {
                TResult T = new TResult();
                var juser = this.GetUser();
                if (!model.phone.IsPhoneNumber()) return new TResult("手机号不正确").ToResult();
                if (juser.data != null)
                {
                    var userdata = wu.db.dc_userdata.Where(p => p.token == juser.user.token).FirstOrDefault();
                    userdata.phonenumber = model.phone;
                    userdata.name = model.name;
                }
                else {
                    var userdata = new dc_userdata()
                    {
                        token = juser.user.token,
                        name = model.name,
                        phonenumber = model.phone,
                    };
                    wu.db.dc_userdata.Add(userdata);
                }
                var jpet = DcPets.GetEntitys(wu).Where(p => p.pet.token == juser.user.token).FirstOrDefault();

                if (jpet == null)
                {
                    var pet = new dc_pet()
                    {
                        address = model.petaddress,
                        area = model.petarea,
                        date = model.petdate,
                        demand = model.petdemand,
                        disable = false,
                        firsttime = DateTime.Now,
                        name = model.petname,
                        pettype = model.pettype,
                        sex = (int)model.petsex,
                        token = juser.user.token,
                    };
                    wu.db.dc_pet.Add(pet);
                    wu.Save();
                    foreach (var image in model.petimages)
                    {
                        wu.db.dc_pet_image.Add(new dc_pet_image()
                        {
                            image=image,
                            petid=pet.id,
                            firsttime=DateTime.Now,
                        });
                    }
                }
                else {
                    jpet.pet.address = model.petaddress;
                    jpet.pet.area = model.petarea;
                    jpet.pet.date = model.petdate;
                    jpet.pet.demand = model.petdemand;
                    jpet.pet.lasttime = DateTime.Now;
                    jpet.pet.name = model.petname;
                    jpet.pet.pettype = model.pettype;
                    jpet.pet.sex = (int)model.petsex;
                    foreach (var petimage in jpet.petimages)
                    {
                        wu.db.dc_pet_image.Remove(petimage);
                    }
                    foreach (var image in model.petimages)
                    {
                        wu.db.dc_pet_image.Add(new dc_pet_image()
                        {
                            image = image,
                            petid = jpet.pet.id,
                            firsttime = DateTime.Now,
                        });
                    }
                }
                wu.Save();
                T.data = true;
                return T.ToResult();
            }
        }
    }
}