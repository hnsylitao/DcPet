using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Areas.Api.Controllers
{
    public class PetController : Controller
    {
        // GET: Api/Pet
        public ActionResult Index()
        {
            return View();
        }
    }
}