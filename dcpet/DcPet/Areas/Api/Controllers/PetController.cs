using DcPet.Areas.Api.IControllers;
using DcPet.Common;
using DcPet.Data;
using DcPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Areas.Api.Controllers
{
    public class PetController : BaseApiController
    {
        
        /// <summary>
        /// 获取宠物
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [FilterApp]
        public ActionResult Index(int? index=1,int? size=5)
        {
            using (WorkUnit wu=new WorkUnit())
            {
                TResultForPage T = TResultForPage.Empty;
                var juser = this.GetUser();
                var jpet = DcPets.GetEntitys(wu).Where(p => p.pet.token == juser.user.token).FirstOrDefault();
                var query = DcPets.GetEntitys(wu);
                if (jpet == null)
                {
                    query = query.OrderByDescending(p => p.pet.firsttime);
                }
                else {
                    query = query.Select(p => new
                    {
                        depet = p,
                        destype = (p.pet.pettype == jpet.pet.pettype ? 0 : 1),
                        desarea = (p.pet.area == jpet.pet.area ? 0 : 1),
                        desdate = ((p.pet.date.Year == jpet.pet.date.Year) && (p.pet.date.Month == jpet.pet.date.Month)) ? 0 : 1
                    })
                    .OrderBy(p => p.destype)
                    .ThenBy(p=>p.desarea)
                    .ThenBy(p=>p.desdate)
                    .ThenByDescending(p => p.depet.pet.firsttime)
                    .Where(p => p.depet.pet.sex != jpet.pet.sex)
                    .Select(p => p.depet);
                }
                var count = query.Count();
                var data = query.ApartPage(index.Value, size.Value).ToArray().Select(p=>new {
                    petid= p.pet.id,
                    petname= p.pet.name,
                    petarea=p.area.name,
                    petaddress=p.pet.address,
                    petdate=p.pet.date,
                    petdemand=p.pet.demand,
                    petsex=p.pet.sex,
                    pettype=p.type.pettype,
                    petimages=p.petimages.Select(x=>x.image).ToArray(),
                    user = new {
                        name=p.userdata.name,
                        phone=p.userdata.phonenumber
                    }
                });
                T = new TResultForPage(index.Value, size.Value, count, data);
                return T.ToResult();
            }
        }
    }
}