namespace ShopNum1.Second
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;

    public class ShopNum1_XinlanOAuthClient
    {
        private readonly string a1 = "https://api.weibo.com/oauth2/authorize";
        private readonly string b1 = "https://api.weibo.com/oauth2/access_token";

        private ShopNum1_XinLanOAuthMessage a(string A_0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = null;
            try
            {
                input = new s().a(this.b1, A_0);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    input = new StreamReader(exception.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                }
            }
            if (input.Contains("error"))
            {
                throw serializer.Deserialize<ShopNum1_XinlanOAuthException>(input);
            }
            input = input.Replace(@"\", @"\\");
            return serializer.Deserialize<ShopNum1_XinLanOAuthMessage>(input);
        }

        public ShopNum1_XinLanOAuthMessage GetAccessTokenByAppkeySecret(string API_Key, string Secret, string redirect_url, string code)
        {
            string str = string.Format("client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&code={3}", new object[] { API_Key, Secret, redirect_url, code });
            return this.a(str);
        }

        public void GetAuthorizationCode(string API_Key, string redirect_uri)
        {
            string url = string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", this.a1, API_Key, redirect_uri);
            HttpContext.Current.Response.Redirect(url);
        }

        public string GetAuthorizationUrl(string API_Key, string redirect_uri)
        {
            return string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", this.a1, API_Key, redirect_uri);
        }
    }
}

