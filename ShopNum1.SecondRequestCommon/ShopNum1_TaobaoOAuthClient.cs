namespace ShopNum1.Second
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;

    public class ShopNum1_TaobaoOAuthClient
    {
        private readonly string a1 = "https://oauth.taobao.com/authorize";
        private readonly string b1 = " https://oauth.taobao.com/token";

        private ShopNum1_TaobaoOAuthMessage a(string A_0)
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
                throw serializer.Deserialize<ShopNum1_TaobaoOAuthException>(input);
            }
            input = input.Replace(@"\", @"\\");
            return serializer.Deserialize<ShopNum1_TaobaoOAuthMessage>(input);
        }

        public ShopNum1_TaobaoOAuthMessage GetAccessTokenByAuthorizationCode(string API_Key, string Secret_Key, string code, string redirect_uri)
        {
            string str = string.Format("grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri={3}", new object[] { code, API_Key, Secret_Key, redirect_uri });
            return this.a(str);
        }

        public ShopNum1_TaobaoOAuthMessage GetAccessTokenByClientCredentials(string API_Key, string Secret_Key, string scope)
        {
            string str = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope={2}", API_Key, Secret_Key, scope);
            return this.a(str);
        }

        public ShopNum1_TaobaoOAuthMessage GetAccessTokenByPasswordCredentials(string API_Key, string Secret_Key, string username, string password, string scope)
        {
            string str = string.Format("grant_type=password&client_id={0}&client_secret={1}&scope={2}&username={3}&password={4}", new object[] { API_Key, Secret_Key, scope, username, password });
            return this.a(str);
        }

        public ShopNum1_TaobaoOAuthMessage GetAccessTokenByRefreshToken(string API_Key, string Secret_Key, string refresh_token, string scope)
        {
            string str = string.Format("grant_type=refresh_token&client_id={0}&client_secret={1}&scope={2}&refresh_token={3}", new object[] { API_Key, Secret_Key, scope, refresh_token });
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

