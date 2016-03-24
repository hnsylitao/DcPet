using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcPet.Common
{
    public class DataHelper
    {
        public static T ConvertTo<T>(object data, T defalut) {
            if (data == null)
            {
                return defalut;
            }
            else {
                return GetValue<T>(data);
            }
        }

        private static T GetValue<T>(object p)
        {
            // Type t = typeof(T1);
            try
            {
                //MethodInfo mi = t.GetMethod("Parse", new Type[] { typeof(string) });
                //return (T1)mi.Invoke(p, new object[] { p.ToString() });
                return (T)Convert.ChangeType(p, typeof(T));
            }
            catch
            {
                throw new Exception("error convert");
            }
        }
    }
}
