using System.Web;

namespace ShopNum1.Common
{
    public class Globals
    {
        public static string ApplicationPath
        {
            get
            {
                string applicationPath = HttpContext.Current.Request.ApplicationPath;
                if (applicationPath == "/")
                {
                    return "/";
                }
                return applicationPath;
            }
        }

        public static string ImagePath
        {
            get
            {
                string applicationPath = HttpContext.Current.Request.ApplicationPath;
                if (applicationPath == "/")
                {
                    return "/ImgUpload/";
                }
                return (applicationPath + "/ImgUpload/");
            }
        }

        public static string IPAddress
        {
            get
            {
                string userHostAddress = string.Empty;
                HttpRequest request = HttpContext.Current.Request;
                if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                {
                    return request.ServerVariables["REMOTE_ADDR"];
                }
                userHostAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                switch (userHostAddress)
                {
                    case null:
                    case "":
                        userHostAddress = request.UserHostAddress;
                        break;
                }
                return userHostAddress;
            }
        }

        public static string MoneySymbol
        {
            get
            {
                new ShopSettings();
                if (ApplicationPath == "/")
                {
                    HttpContext.Current.Server.MapPath("/Settings/ShopSetting.xml");
                }
                else
                {
                    HttpContext.Current.Server.MapPath(ApplicationPath + "/Settings/ShopSetting.xml");
                }
                return ShopSettings.GetValue("MoneySymbol");
            }
        }

        public static string SkinName
        {
            get
            {
                var themes = new Themes();
                string fieldXmlPath = string.Empty;
                if (ApplicationPath == "/")
                {
                    fieldXmlPath = HttpContext.Current.Server.MapPath("/Settings/SiteConfig.xml");
                }
                else
                {
                    fieldXmlPath = HttpContext.Current.Server.MapPath(ApplicationPath + "/Settings/SiteConfig.xml");
                }
                return themes.GetValue(fieldXmlPath, "Themes");
            }
        }

        public static string SkinPath
        {
            get
            {
                var themes = new Themes();
                string fieldXmlPath = string.Empty;
                if (ApplicationPath == "/")
                {
                    fieldXmlPath = HttpContext.Current.Server.MapPath("/Settings/SiteConfig.xml");
                }
                else
                {
                    fieldXmlPath = HttpContext.Current.Server.MapPath(ApplicationPath + "/Settings/SiteConfig.xml");
                }
                string str2 = themes.GetValue(fieldXmlPath, "Themes");
                string str3 = "/Main/Themes/" + str2;
                if (!(ApplicationPath == "/"))
                {
                    str3 = ApplicationPath + str3;
                }
                return str3;
            }
        }
    }
}