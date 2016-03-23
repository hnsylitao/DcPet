using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePet.Common
{
    public static class Json
    {
        /// <summary>
        /// JSON 序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToJson(this object data) {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return JsonConvert.SerializeObject(data, Formatting.Indented, timeFormat);
        }
    }
}
