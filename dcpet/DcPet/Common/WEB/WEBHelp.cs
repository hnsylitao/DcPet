using DcPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Common
{
    public static class WEBHelp
    {
        /// <summary>
        /// 客户端ip(访问用户)
        /// </summary>
        public static string UserIp
        {
            get
            {
                string realRemoteIP = "";
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    realRemoteIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0];
                }
                if (string.IsNullOrEmpty(realRemoteIP))
                {
                    realRemoteIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.IsNullOrEmpty(realRemoteIP))
                {
                    realRemoteIP = HttpContext.Current.Request.UserHostAddress;
                }
                return realRemoteIP;
            }
        }

        public static DcUser GetUser(this Controller ctl) {
            var result= (DcUser)ctl.ViewData["_juser"];
            return result;
        }

    }
}
