using System;
using System.Collections;
using System.Web;
using System.Xml;

namespace ShopNum1.Cache
{
    public class CacheByXml
    {
        private static readonly object object_0 = new object();
        public static XmlElement objectXmlMap = rootXml.CreateElement("Cache");
        public static XmlDocument rootXml = new XmlDocument();
        protected static volatile System.Web.Caching.Cache webCache = HttpRuntime.Cache;

        static CacheByXml()
        {
            rootXml.AppendChild(objectXmlMap);
        }

        public static void Add(string xpath, object object_1)
        {
            XmlElement element;
            XmlAttribute attribute;
            string str = smethod_1(xpath);
            int length = str.LastIndexOf("/");
            string str2 = str.Substring(0, length);
            string name = str.Substring(length + 1);
            XmlNode node = objectXmlMap.SelectSingleNode(str2);
            string key = "";
            XmlNode oldChild = objectXmlMap.SelectSingleNode(smethod_1(xpath));
            if (oldChild != null)
            {
                key = oldChild.Attributes["objectId"].Value;
            }
            if (key == "")
            {
                node = smethod_0(str2);
                key = Guid.NewGuid().ToString();
                element = objectXmlMap.OwnerDocument.CreateElement(name);
                attribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                attribute.Value = key;
                element.Attributes.Append(attribute);
                node.AppendChild(element);
            }
            else
            {
                element = objectXmlMap.OwnerDocument.CreateElement(name);
                attribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                attribute.Value = key;
                element.Attributes.Append(attribute);
                node.ReplaceChild(element, oldChild);
            }
            webCache.Insert(key, object_1);
        }

        public static object Get(string xpath)
        {
            object obj2 = null;
            XmlNode node = objectXmlMap.SelectSingleNode(smethod_1(xpath));
            if (node != null)
            {
                string key = node.Attributes["objectId"].Value;
                obj2 = webCache.Get(key);
            }
            return obj2;
        }

        public static object[] GetList(string xpath)
        {
            XmlNodeList list =
                objectXmlMap.SelectSingleNode(smethod_1(xpath)).SelectNodes(smethod_1(xpath) + "/*[@objectId]");
            var list2 = new ArrayList();
            string key = null;
            foreach (XmlNode node2 in list)
            {
                key = node2.Attributes["objectId"].Value;
                list2.Add(webCache.Get(key));
            }
            return (object[]) list2.ToArray(typeof (object));
        }

        public static void Remove(string xpath)
        {
            lock (object_0)
            {
                string str;
                XmlNode oldChild = objectXmlMap.SelectSingleNode(smethod_1(xpath));
                if (oldChild.HasChildNodes)
                {
                    XmlNodeList list = oldChild.SelectNodes("*[@objectId]");
                    str = "";
                    foreach (XmlNode node2 in list)
                    {
                        str = node2.Attributes["objectId"].Value;
                        node2.ParentNode.RemoveChild(node2);
                        webCache.Remove(str);
                    }
                }
                else
                {
                    str = oldChild.Attributes["objectId"].Value;
                    oldChild.ParentNode.RemoveChild(oldChild);
                    webCache.Remove(str);
                }
            }
        }

        private static XmlNode smethod_0(string string_0)
        {
            lock (object_0)
            {
                string[] strArray = string_0.Split(new[] {'/'});
                string xpath = "";
                XmlNode objectXmlMap = CacheByXml.objectXmlMap;
                for (int i = 1; i < strArray.Length; i++)
                {
                    if (CacheByXml.objectXmlMap.SelectSingleNode(xpath + "/" + strArray[i]) == null)
                    {
                        XmlElement newChild = CacheByXml.objectXmlMap.OwnerDocument.CreateElement(strArray[i]);
                        objectXmlMap.AppendChild(newChild);
                    }
                    xpath = xpath + "/" + strArray[i];
                    objectXmlMap = CacheByXml.objectXmlMap.SelectSingleNode(xpath);
                }
                return objectXmlMap;
            }
        }

        private static string smethod_1(string string_0)
        {
            string[] strArray = string_0.Split(new[] {'/'});
            string_0 = "/Cache";
            foreach (string str in strArray)
            {
                if (str != "")
                {
                    string_0 = string_0 + "/" + str;
                }
            }
            return string_0;
        }
    }
}