using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using ShopNum1.Payment;

namespace tenpay
{
    public class TenpayDual_ResponseHandler
    {
        private string a;
        private string b;
        protected HttpContext httpContext;
        protected Hashtable parameters;

        public TenpayDual_ResponseHandler(HttpContext httpContext)
        {
            parameters = new Hashtable();
            this.httpContext = httpContext;
            NameValueCollection nameValueCollection;
            if (this.httpContext.Request.HttpMethod == "POST")
            {
                nameValueCollection = this.httpContext.Request.Form;
            }
            else
            {
                nameValueCollection = this.httpContext.Request.QueryString;
            }
            foreach (string text in nameValueCollection)
            {
                string parameterValue = nameValueCollection[text];
                setParameter(text, parameterValue);
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

        public void doShow(string show_url)
        {
            string s =
                "<html><head>\r\n<meta name=\"TENCENT_ONLINE_PAYMENT\" content=\"China TENCENT\">\r\n<script language=\"javascript\">\r\nwindow.location.href='" +
                show_url + "';\r\n</script>\r\n</head><body></body></html>";
            httpContext.Response.Write(s);
            httpContext.Response.End();
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
            return httpContext.Request.ContentEncoding.BodyName;
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