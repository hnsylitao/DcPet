using DcPet.Common;
using DcPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcPet.Areas.Api.Models
{
    public class UserViewModel
    {
        public UserViewModel() {
            petsex = PetSex.Female;
        }
        public string phone { get; set; }
        public string name { get; set; }

        public string petname { get; set; }
        public int pettype { get; set; }
        public PetSex petsex { get; set; }
        public DateTime petdate { get; set; }
        public string petarea { get; set; }
        public string petaddress { get; set; }
        public string petdemand { get; set; }
        public string[] petimages { get; set; }

        public string checkmodel() {
            string result = string.Empty;

            if (!phone.IsPhoneNumber())
            {
                return "手机号码格式不正确";
            }
            if (string.IsNullOrEmpty(name))
            {
                return "名字不能为空";
            }
            if (string.IsNullOrEmpty(petname))
            {
                return "宠物名不能为空";
            }
            if (string.IsNullOrEmpty(petarea))
            {
                return "区域不能为空";
            }
            foreach (var item in petimages)
            {
                if (!item.IsUrl())
                {
                    return "图象链接有误";
                }
                var url = new Uri(item);
                if (!url.IsBaseOf(new Uri(QiniuHelp.cdnurl))) {
                    return "图象链接有误";
                }
            }

            return result;
        }
    }
}
