using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ShopNum1.Second
{
    public class JsonOperate
    {
        public static string GetValueFromJson(string strjson, string name)
        {
            var serializer = new JavaScriptSerializer();
            var dictionary = (Dictionary<string, object>) serializer.DeserializeObject(strjson);
            try
            {
                object obj2;
                dictionary.TryGetValue(name, out obj2);
                return obj2.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}