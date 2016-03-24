using System;
using System.Linq;
using System.Text;
using Qiniu.Conf;
using Qiniu.IO;
using Qiniu.RS;

namespace DcPet.Common
{
    public class QiniuHelp
    {

        /// <summary>
        /// ak
        /// </summary>
        private static string ACCESS_KEY = "aG3Ou2YzCPu0D_g1SPVKW911NfB3Q9RbCBq3TTso";
        /// <summary>
        /// sk
        /// </summary>
        private static string SECRET_KEY = "e6FWFz2O2ndZ02IHl9Sh1xAl85t-CUSe26zam218";
        /// <summary>
        /// 上传的空间
        /// </summary>
        private static string bucket = "petsdcimages";
        /// <summary>
        /// CDN url
        /// </summary>
        public static string cdnurl = "http://7xs3ku.com1.z0.glb.clouddn.com/";

        /// <summary>
        /// io
        /// </summary>
        private IOClient target;
        /// <summary>
        /// extra
        /// </summary>
        private PutExtra extra;
        /// <summary>
        /// put
        /// </summary>
        private PutPolicy put;

        /// <summary>
        /// 初始化
        /// </summary>
        public QiniuHelp() {
            Config.ACCESS_KEY = ACCESS_KEY;
            Config.SECRET_KEY = SECRET_KEY;
            target = new IOClient();
            extra = new PutExtra();
            //普通上传,只需要设置上传的空间名就可以了,第二个参数可以设定token过期时间
            put = new PutPolicy(bucket, 3600);
        }

        /// <summary>
        /// 获取uptoken
        /// </summary>
        /// <returns></returns>
        public string uptoken() {
           return put.Token();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public string upfile(string filepath) {
            //string key = FileHelp.GetMD5HashFromFile(filepath);
            string key = filepath.Substring(filepath.LastIndexOf("\\")+1);
            //调用Token()方法生成上传的Token
            string upToken = uptoken();

            //调用PutFile()方法上传
            PutRet ret = target.PutFile(upToken, key, filepath, extra);
            FileHelp.DeleteFile(filepath);
            //打印出相应的信息
            //Console.WriteLine(ret.Response.ToString());
            //Console.WriteLine(ret.key);
            return string.Format("{0}{1}",cdnurl, ret.key);
        }
    }
}
