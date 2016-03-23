using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DcPet.Common
{
    /// <summary>
    /// Json
    /// </summary>
    public class TResult
    {
        public TResultStatus status { get; set; }

        public string error { get; set; }

        public object data { get; set; }

        public TResult() {
            this.status = TResultStatus.Success;
            this.error = null;
            this.data = null;
        }

        public TResult(TResultStatus status)
        {
            this.status = status;
            this.error = null;
            this.data = null;
        }

        public TResult(string error)
        {
            this.status = TResultStatus.Error;
            this.error = error;
            this.data = null;
        }

        public TResult(object data) {
            this.status = TResultStatus.Success;
            this.error = null;
            this.data = data;
        }

        public ActionResult ToResult()
        {
            var josnStr = this.ToJson();
            var jsonpCallback = System.Web.HttpContext.Current.Request.Params["callback"];
            if (!string.IsNullOrWhiteSpace(jsonpCallback))
            {
                josnStr = string.Format("{0}({1})", jsonpCallback, josnStr);
            }

            var result = new ContentResult();
            result.Content = josnStr;
            result.ContentEncoding = Encoding.UTF8;
            result.ContentType = "application/json;";
            return result;
        }

    }
    /// <summary>
    /// 分页 Json
    /// </summary>
    public class TResultForPage :TResult {
        public static TResultForPage Empty;
        static TResultForPage() {
            Empty=new TResultForPage();
        }

        /// <summary>
        /// 当前显示页
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 当前显示条目
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 总共条目
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int pagecount {
            get {
                if (size<=0)
                {
                    return 0;
                }
                return (count % size == 0) ?
                  (count / size) :
                  (count / size) + 1;
            }
        }
        /// <summary>
        /// 是否最后一页
        /// </summary>
        public bool islast
        {
            get
            {
                if (count == 0)
                {
                    return true;
                }
                return (count % size == 0) ?
                    index >= (count / size) :
                   index >= (count / size) + 1;
            }
        }


        public TResultForPage() : base() { }
        public TResultForPage(int index, int size, int maxCount):this() {
            this.index = index;
            this.size = size;
            this.count = maxCount;
        }
        public TResultForPage(int index, int size, int maxCount, object model):this(index,size,maxCount)
        {
            this.data = model;
        }
    }
    /// <summary>
    /// 状态码
    /// </summary>
    public enum TResultStatus:int {
        /// <summary>
        /// 成功
        /// </summary>
        Success=200,
        /// <summary>
        /// 错误
        /// </summary>
        Error=400,
        /// <summary>
        /// 未登录
        /// </summary>
        Fail=401,
    }
}
