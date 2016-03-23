using DcPet.Common;
using DcPet.Data;
using DcPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DcPet
{
    public class FilterApp : FilterAttribute, IActionFilter
    {


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region 验证uuid
            using (WorkUnit wu = new WorkUnit())
            {
                DcUser juser = null;
                var uuid = filterContext.HttpContext.Request.QueryString["uuid"];
                var device = filterContext.HttpContext.Request.QueryString["device"];
                var platform = filterContext.HttpContext.Request.QueryString["platform"];
                if (uuid != null)
                {
                    juser = DcUser.GetEntitys(wu).Where(p => p.user.uuid == uuid).FirstOrDefault();
                    if (juser == null)
                    {
                        var dcuser = new dc_user()
                        {
                            device = device,
                            disable = false,
                            firstip = WEBHelp.UserIp,
                            lastip = null,
                            firsttime = DateTime.Now,
                            platform = platform,
                            token = Guid.NewGuid(),
                            uuid = uuid,
                        };
                        wu.db.dc_user.Add(dcuser);
                        dc_userdata dcdata = null;
                        juser = new DcUser()
                        {
                            user = dcuser,
                            data = dcdata
                        };
                    }
                    else {
                        if (juser.user.disable==true)
                        {
                            filterContext.Result = new TResult("用户已被禁用").ToResult();
                        }
                        juser.user.lasttime = DateTime.Now;
                        juser.user.lastip = WEBHelp.UserIp;
                    }
                    filterContext.Controller.ViewData["_juser"] = juser;
                    wu.Save();
                }
                else {
                    filterContext.Result = new TResult("no uuid parameter").ToResult(); 
                }
            }
            #endregion
        }
    }
}
