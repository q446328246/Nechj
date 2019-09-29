using System.Collections;
using System.Text;
using System.Xml;
using ShopNum1.Payment;

namespace tenpay
{
    public class TenpayDual_ClientResponseHandler
    {
        private string a;
        private string b;
        private string c = "gb2312";
        protected string content;
        protected Hashtable parameters;

        public TenpayDual_ClientResponseHandler()
        {
            parameters = new Hashtable();
        }

        public string getContent()
        {
            return content;
        }

        public virtual void setContent(string content)
        {
            this.content = content;
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);
            XmlNode xmlNode = xmlDocument.SelectSingleNode("root");
            XmlNodeList childNodes = xmlNode.ChildNodes;
            foreach (XmlNode xmlNode2 in childNodes)
            {
                setParameter(xmlNode2.Name, xmlNode2.InnerXml);
            }
        }

        public string getKey()
        {
            return a;
        }

        public void setKey(string key)
        {
            a = key;
        }

        public string getParameter(string parameter)
        {
            var text = (string) parameters[parameter];
            return (text == null) ? "" : text;
        }

        public void setParameter(string parameter, string parameterValue)
        {
            if (parameter != null && parameter != "")
            {
                if (parameters.Contains(parameter))
                {
                    parameters.Remove(parameter);
                }
                parameters.Add(parameter, parameterValue);
            }
        }

        public virtual bool isTenpaySign()
        {
            var stringBuilder = new StringBuilder();
            var arrayList = new ArrayList(parameters.Keys);
            arrayList.Sort();
            foreach (string text in arrayList)
            {
                var text2 = (string) parameters[text];
                if (text2 != null && "".CompareTo(text2) != 0 && "sign".CompareTo(text) != 0 &&
                    "key".CompareTo(text) != 0)
                {
                    stringBuilder.Append(text + "=" + text2 + "&");
                }
            }
            stringBuilder.Append("key=" + getKey());
            string text3 = MD5Util.GetMD5(stringBuilder.ToString(), getCharset()).ToLower();
            setDebugInfo(stringBuilder + " => sign:" + text3);
            return getParameter("sign").ToLower().Equals(text3);
        }

        public string getDebugInfo()
        {
            return b;
        }

        protected void setDebugInfo(string debugInfo)
        {
            b = debugInfo;
        }

        protected virtual string getCharset()
        {
            return c;
        }

        public void setCharset(string charset)
        {
            c = charset;
        }

        public virtual bool _isTenpaySign(ArrayList akeys)
        {
            var stringBuilder = new StringBuilder();
            foreach (string text in akeys)
            {
                var text2 = (string) parameters[text];
                if (text2 != null && "".CompareTo(text2) != 0 && "sign".CompareTo(text) != 0 &&
                    "key".CompareTo(text) != 0)
                {
                    stringBuilder.Append(text + "=" + text2 + "&");
                }
            }
            stringBuilder.Append("key=" + getKey());
            string text3 = MD5Util.GetMD5(stringBuilder.ToString(), getCharset()).ToLower();
            setDebugInfo(stringBuilder + " => sign:" + text3);
            return getParameter("sign").ToLower().Equals(text3);
        }
    }
}