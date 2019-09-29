using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Xml;

namespace ShopNum1.Second
{
    public class ShopNum1_QzoneCommonResponse
    {
        public string GetQQUserName(string string_0, string ftype)
        {
            if (ftype == "xml")
            {
                var document = new XmlDocument();
                document.LoadXml(string_0);
                try
                {
                    if (document.SelectNodes("data").Count != 0)
                    {
                        return document.SelectSingleNode("data/nickname").InnerText;
                    }
                }
                catch
                {
                }
                return "";
            }
            var serializer = new JavaScriptSerializer();
            var dictionary = (Dictionary<string, object>) serializer.DeserializeObject(string_0);
            try
            {
                object obj2;
                dictionary.TryGetValue("nickname", out obj2);
                return obj2.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}