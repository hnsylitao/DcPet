using DcPet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Areas.Api.IControllers
{
    public class BaseApiController : Controller
    {

        protected override void OnException(ExceptionContext filterContext) {
            filterContext.Result = new ContentResult() {
                Content=filterContext.Exception.Message
            };
        }

        protected ActionResult TJson() {
            return new TResult().ToResult();
        }

        protected ActionResult TJson(string error)
        {
            return new TResult(error).ToResult();
        }

        protected ActionResult TJson(object data)
        {
            return new TResult(data).ToResult();
        }

        protected ActionResult TJson(int maxCount, object data)
        {
            int index = HttpContext.Request["index"] == null ? 1 : int.Parse(HttpContext.Request["index"]);
            int size = HttpContext.Request["size"] == null ? 5 : int.Parse(HttpContext.Request["size"]);
            return new TResultForPage(index, size, maxCount, data).ToResult();
        }

        protected ActionResult TJson(int index, int size, int maxCount, object data)
        {
            return new TResultForPage(index,size,maxCount, data).ToResult();
        }
    }
}