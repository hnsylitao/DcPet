using DcPet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Areas.File.Controllers
{
    public class FileController : Controller
    {
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var staticfiltpath = FileHelp.UploadFile(file);
            if (string.IsNullOrEmpty(staticfiltpath))
            {
                return new TResult("文件错误").ToResult();
            }
            else {
                TResult T = new TResult();
                var qiniu = new QiniuHelp();
                var serverpath = qiniu.upfile(staticfiltpath);
                T.data = serverpath;
                return T.ToResult();
            }
        }
    }
}