using DePet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DcPet.Areas.File.Controllers
{
    public class FileController : Controller
    {
        // GET: File/File
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var staticfiltpath = FileHelp.UploadFile(file);
            if (string.IsNullOrEmpty(staticfiltpath))
            {
                return Content(new { erro = "文件错误" }.ToJson());
            }
            else {
                var qiniu = new QiniuHelp();
                var serverpath = qiniu.upfile(staticfiltpath);
                return Content(new { file = serverpath }.ToJson());
            }
        }
    }
}