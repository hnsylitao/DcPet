using DcPet.Common;
using DcPet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Areas.Api.Controllers
{
    public class CommonController : Controller
    {
        [HttpGet]
        public ActionResult Area()
        {
            using (WorkUnit wu = new WorkUnit())
            {
                TResult T = new TResult();
                T.data = wu.db.dc_area.OrderBy(p => p.id).Select(p => new
                {
                    p.no,
                    p.name
                }).ToArray();
                return T.ToResult();
            }
        }

        [HttpGet]
        public ActionResult PetType()
        {
            using (WorkUnit wu = new WorkUnit())
            {
                TResult T = new TResult();
                T.data = wu.db.dc_pettype.OrderBy(p => p.id).Select(p => new
                {
                    p.id,
                    p.pettype
                }).ToArray();
                return T.ToResult();
            }
        }

    }
}