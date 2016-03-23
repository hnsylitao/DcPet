using DcPet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcPet.Models
{
    public class DcUser
    {
        public dc_user user { get; set; }
        public dc_userdata data { get; set; }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="wu"></param>
        /// <returns></returns>
        public static IQueryable<DcUser> GetEntitys(WorkUnit wu)
        {
            var result= (from u in wu.db.dc_user
             join d in wu.db.dc_userdata on u.token equals d.token into ds
             from da in ds.DefaultIfEmpty()
             select new DcUser()
             {
                 user = u,
                 data = da
             });
            return result;
        } 

    }
}
