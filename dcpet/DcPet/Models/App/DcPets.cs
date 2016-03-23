using DcPet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcPet.Models
{
    public class DcPets
    {
        public dc_pet pet { get; set; }
        public IEnumerable<dc_pet_image> petimages { get; set; }
        public dc_pettype type { get; set; }
        public dc_area area { get; set; }
        public static IQueryable<DcPets> GetEntitys(WorkUnit wu) {
            var result = (from pet in wu.db.dc_pet 
                          join petimage in wu.db.dc_pet_image on pet.id equals petimage.petid into petimages
                          join type in wu.db.dc_pettype on pet.pettype equals type.id
                          join area in wu.db.dc_area on pet.area equals area.no
                          select new DcPets() {
                              pet=pet,
                              area=area,
                              petimages=petimages,
                              type=type
                          });
            return result;
        }
    }

    public enum PetSex {
        /// <summary>
        /// 公
        /// </summary>
        Male=0,
        /// <summary>
        /// 母
        /// </summary>
        Female=1,
    }
}
