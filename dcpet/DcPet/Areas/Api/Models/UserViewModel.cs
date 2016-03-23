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
    }
}
