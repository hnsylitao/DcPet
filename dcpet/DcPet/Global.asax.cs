using DcPet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DcPet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            var statusCode = Context.Response.StatusCode;
            var routingData = Context.Request.RequestContext.RouteData;
            var area = DataHelper.ConvertTo(routingData.DataTokens["area"], string.Empty);
            if (area.ToLower() == "api")
            {
                if (statusCode == 404)
                {
                    Response.Clear();
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentType = "application/json;"; ;
                    Response.Write(new TResult(TResultStatus.NoApi).ToJson());
                }
                if (statusCode == 500)
                {
                    Response.Clear();
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentType = "application/json;"; ;
                    Response.Write(new TResult("服务器内部错误").ToJson());
                }
            }
        }
    }
}
