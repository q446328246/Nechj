namespace ShopNum1.Second
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;

    public class ShopNum1_XinlanCommonClient
    {
        private readonly string a1 = "https://api.weibo.com/2/users/show.json";

        private ShopNum1_XinlanUserResponse a(string A_0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ShopNum1_XinlanUserResponse response = new ShopNum1_XinlanUserResponse();
            string input = null;
            try
            {
                input = new s().a(A_0);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    input = new StreamReader(exception.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                }
            }
            return serializer.Deserialize<ShopNum1_XinlanUserResponse>(input);
        }

        public ShopNum1_XinlanUserResponse GetXinlanUser(string uid, string access_token)
        {
            string a = this.a1;
            if (uid != "")
            {
                a = a + "?" + string.Format("uid={0}&access_token={1}", uid, access_token);
            }
            return this.a(a);
        }
    }
}

