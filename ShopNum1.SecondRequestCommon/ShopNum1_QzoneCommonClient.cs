namespace ShopNum1.Second
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class ShopNum1_QzoneCommonClient
    {
        public string access_token;
        public string AppId;
        public string AppSecret;
        protected static string error_rspXML = "<error_response>\r\n<args list=\"true\"><arg><key>post</key><value>{2}</value></arg></args>\r\n<code>{0}</code>\r\n<msg>{1}</msg>\r\n<sub_code></sub_code>\r\n<sub_msg></sub_msg>\r\n</error_response>";
        public string openid;
        public string redirectURI;
        public static string RestUrl = "https://graph.qq.com/";
        public string scrore;

        protected static string CustomErrorXML(string code, Exception exp)
        {
            return string.Format(error_rspXML, code, exp.Message.Replace("\"", "'").Replace("'", "'").Replace("&", "＆"), exp.StackTrace.Replace("\"", "'").Replace("'", "'").Replace("<", "＜").Replace(">", "＞").Replace("&", "＆"));
        }

        public static void GetAuthorizationCode(string appid, string returnurl)
        {
            string url = string.Format("http://openapi.qzone.qq.com/oauth/show?client_id={0}&response_type=token&scope=get_user_info&redirect_uri={1}&which=ConfirmPage&display=", appid, returnurl);
            HttpContext.Current.Response.Redirect(url);
        }

        public static string GetAuthorizationUrl(string appid, string returnurl)
        {
            return string.Format("http://openapi.qzone.qq.com/oauth/show?client_id={0}&response_type=token&scope=get_user_info&redirect_uri={1}&which=ConfirmPage&display=", appid, returnurl);
        }

        public string GetQzoneOpenID()
        {
            return JsonOperate.GetValueFromJson(this.QzoneGet("openID", "", "").Replace("callback(", "").Replace(");", ""), "openid");
        }

        public string GetQzoneUrl(string type, string method, string format)
        {
            if (type == "openID")
            {
                return string.Format("https://graph.qq.com/oauth2.0/me?access_token={0}", this.access_token);
            }
            return string.Format("https://graph.qq.com/{0}/{1}?access_token={2}&oauth_consumer_key={3}&openid={4}&format={5}", new object[] { type, method, this.access_token, this.AppId, this.openid, format });
        }

        public string QzoneGet(string type, string method, string format)
        {
            try
            {
                string input = string.Empty;
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.GetQzoneUrl(type, method, format));
                request.Method = "GET";
                request.KeepAlive = true;
                request.UserAgent = "SpaceTimeApp2.0";
                request.Timeout = 0x493e0;
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                Encoding encoding = Encoding.GetEncoding("utf-8");
                Stream responseStream = null;
                StreamReader reader = null;
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, encoding);
                input = reader.ReadToEnd();
                if (reader != null)
                {
                    reader.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                return Regex.Replace(input, @"[\x00-\x08\x0b-\x0c\x0e-\x1f]", "");
            }
            catch (Exception exception)
            {
                return CustomErrorXML("8001", exception);
            }
        }
    }
}

