using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DePet.Common
{
    public static class FileHelp
    {
        /// <summary>
        /// 文件转MD5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string filepath)
        {
            try
            {
                FileStream file = new FileStream(filepath, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                string strText = Encoding.Default.GetString(retVal);

                return Encrypt.MD5Encrypt(strText);
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" +ex.Message);
            }
        }

        public static string UploadFile(HttpPostedFileBase file) {
            if (file!=null)
            {
                string directory = HttpContext.Current.Server.MapPath("~/uploadfiles/");
                new DirectoryInfo(directory).Create();//自行判断一下是否存在。
                var filename = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), file.FileName.Substring(file.FileName.LastIndexOf('.')));
                var staticfilepath = string.Format("{0}{1}", directory, filename);
                file.SaveAs(staticfilepath);
                return staticfilepath;
            }
            return null;
        }

        public static void DeleteFile(string filepath) {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }  
        }
    }
}
