using System.Collections;
using System.Configuration;
using System.Web;

namespace ShopNum1.Common
{
    public class GetUrl
    {
        public static string GetLoginUrl(string pagename, string memloginid)
        {
            var hashtable = (Hashtable) HttpContext.Current.Application["UserUrl"];
            string str = ConfigurationManager.AppSettings["Domain"].ToLower();
            string str2 = hashtable[memloginid] + str;
            return ("http://" + str2 + pagename + ".html");
        }

        public static string GetNewHost()
        {
            var hashtable = (Hashtable) HttpContext.Current.Application["UserUrl"];
            string str = HttpContext.Current.Request.Url.Host.ToLower();
            string str2 = ConfigurationManager.AppSettings["Domain"].ToLower();
            string str3 = "";
            if (str.IndexOf(str2.Replace("/", "")) != -1)
            {
                str3 = str.Split(new[] {'.'})[0];
            }
            else
            {
                str3 = hashtable[str].ToString();
            }
            return (hashtable[str3] + str2);
        }

        public static void RedirectLogin()
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            HttpContext.Current.Response.Redirect("http://" + ShopSettings.siteDomain + "/Login" + str);
        }

        public static void RedirectLogin(string Message)
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s =
                string.Format(
                    "<script>alert('{0}');location.href='http://" + ShopSettings.siteDomain + "/Login" + str +
                    "';</script>", Message);
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.End();
        }

        public static void RedirectLoginGoBack()
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
            if ((s.IndexOf("?goback=") == -1) && (s.IndexOf("/login") == -1))
            {
                HttpContext.Current.Response.Redirect("http://" + ShopSettings.siteDomain + "/Login" + str + "?goback=" +
                                                      HttpContext.Current.Server.UrlEncode(s));
            }
            else
            {
                HttpContext.Current.Response.Redirect(s);
            }
        }

        public static void RedirectLoginGoBack(string Message)
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
            string str3 =
                string.Format(
                    "<script>alert('{0}');location.href='http://" + ShopSettings.siteDomain + "/Login" + str +
                    "?goback=" + HttpContext.Current.Server.UrlEncode(s) + "';</script>", Message);
            HttpContext.Current.Response.Write(str3);
            HttpContext.Current.Response.End();
        }

        public static void RedirectShopLoginGoBack()
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
            HttpContext.Current.Response.Redirect("http://" + ShopSettings.siteDomain + "/Login" + str + "?goback=" +
                                                  HttpContext.Current.Server.UrlEncode(s));
        }

        public static void RedirectShopLoginGoBack(string Message)
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
            string str3 =
                string.Format(
                    "<script>alert('{0}');location.href='http://" + ShopSettings.siteDomain + "/Login" + str +
                    "?goback=" + HttpContext.Current.Server.UrlEncode(s) + "';</script>", Message);
            HttpContext.Current.Response.Write(str3);
            HttpContext.Current.Response.End();
        }

        public static void RedirectTopLogin()
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s = "<script>top.location.href='http://" + ShopSettings.siteDomain + "/Login" + str + "';</script>";
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.End();
        }

        public static void RedirectTopLogin(string Message)
        {
            string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
            string s =
                string.Format(
                    "<script>alert('{0}');top.location.href='http://" + ShopSettings.siteDomain + "/Login" + str +
                    "';</script>", Message);
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.End();
        }
    }
}