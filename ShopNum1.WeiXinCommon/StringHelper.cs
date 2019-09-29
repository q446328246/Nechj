using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ShopNum1.WeiXinCommon
{
    public class StringHelper
    {
        public static string RemoveLast(string str)
        {
            return (str = !string.IsNullOrEmpty(str) ? str.Remove(str.Length - 1, 1) : str);
        }

        public static string ReturnJson(object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static List<T> ReturnListFromJson<T>(string strJson) where T : class
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<T>>(strJson);
        }

        public static T ReturnModelFromJson<T>(string strJson) where T : class
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(strJson);
        }
    }
}