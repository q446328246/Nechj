namespace ShopNum1.Second
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Xml;

    public class ShopNum1_BaiduCommonClient
    {
        private readonly string a1 = "https://openapi.baidu.com/rest/2.0/passport/users/getLoggedInUser";

        private ShopNum1_BaiduUserResponse a(string A_0)
        {
            string xml = null;
            ShopNum1_BaiduUserResponse response = new ShopNum1_BaiduUserResponse();
            try
            {
                xml = new s().a(this.a1, A_0);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    xml = new StreamReader(exception.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                    return null;
                }
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlNodeList list = document.SelectNodes("passport_users_getLoggedInUser_response");
            if (list.Count == 0)
            {
                return null;
            }
            response.uid=(list[0].ChildNodes[0].InnerText);
            response.uname = list[0].ChildNodes[1].InnerText;
            response.portrait = list[0].ChildNodes[2].InnerText;
            return response;
        }

        private ShopNum1_BaiduUserResponse b(string A_0)
        {
            string strXml = null;
            ShopNum1_BaiduUserResponse ojb = new ShopNum1_BaiduUserResponse();
            try
            {
                strXml = new s().a(this.a1, A_0);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    strXml = new StreamReader(exception.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                    return null;
                }
            }
            XmlOperate operate = new XmlOperate();
            ErrorRsp rsp = new ErrorRsp();
            operate.XmlToObject2<ShopNum1_BaiduUserResponse>(strXml, "passport_users_getLoggedInUser", "", ojb, rsp);
            return ojb;
        }

        private ShopNum1_BaiduUserResponse c(string A_0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ShopNum1_BaiduUserResponse response = new ShopNum1_BaiduUserResponse();
            string input = null;
            try
            {
                input = new s().a(this.a1, A_0);
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
                throw serializer.Deserialize<ShopNum1_BaiduOAuthException>(input);
            }
            return serializer.Deserialize<ShopNum1_BaiduUserResponse>(input);
        }

        public ShopNum1_BaiduUserResponse GetBaiduUser(string acctoken, string format)
        {
            string str = string.Format("access_token={0}&format={1}", acctoken, format);
            ShopNum1_BaiduUserResponse response = new ShopNum1_BaiduUserResponse();
            if (format == "json")
            {
                return this.c(str);
            }
            return this.c(str);
        }
    }
}

