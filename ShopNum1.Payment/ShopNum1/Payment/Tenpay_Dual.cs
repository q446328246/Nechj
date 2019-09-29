using System.Collections;
using System.Text;
using System.Web;

namespace ShopNum1.Payment
{
    public class Tenpay_Dual
    {
        private string a;
        private string b;
        private string c;
        protected HttpContext httpContext;
        protected Hashtable parameters;

        public Tenpay_Dual(HttpContext httpContext)
        {
            parameters = new Hashtable();
            this.httpContext = httpContext;
            setGateUrl("https://www.tenpay.com/cgi-bin/v1.0/service_gate.cgi");
        }

        public virtual void init()
        {
        }

        public string getGateUrl()
        {
            return a;
        }

        public void setGateUrl(string gateUrl)
        {
            a = gateUrl;
        }

        public string getKey()
        {
            return b;
        }

        public void setKey(string key)
        {
            b = key;
        }

        public virtual string getRequestURL()
        {
            createSign();
            var stringBuilder = new StringBuilder();
            var arrayList = new ArrayList(parameters.Keys);
            arrayList.Sort();
            foreach (string text in arrayList)
            {
                var text2 = (string) parameters[text];
                if (text2 != null && "key".CompareTo(text) != 0)
                {
                    stringBuilder.Append(text + "=" + TenpayUtil.UrlEncode(text2, getCharset()) + "&");
                }
            }
            if (stringBuilder.Length > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            return getGateUrl() + "?" + stringBuilder;
        }

        protected virtual void createSign()
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
            setParameter("sign", text3);
            setDebugInfo(stringBuilder + " => sign:" + text3);
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

        public void doSend()
        {
            httpContext.Response.Redirect(getRequestURL());
        }

        public string getDebugInfo()
        {
            return c;
        }

        public void setDebugInfo(string debugInfo)
        {
            c = debugInfo;
        }

        public Hashtable getAllParameters()
        {
            return parameters;
        }

        protected virtual string getCharset()
        {
            return httpContext.Request.ContentEncoding.BodyName;
        }
    }
}