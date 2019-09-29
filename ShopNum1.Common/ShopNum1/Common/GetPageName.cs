using System.Configuration;
using System.Web;

namespace ShopNum1.Common
{
    public class GetPageName
    {
        public static string AgentGetPage(string value)
        {
            int num = HttpContext.Current.Request.Path.LastIndexOf('/');
            int num2 = HttpContext.Current.Request.Path.LastIndexOf('.');
            string str = HttpContext.Current.Request.Path.Substring(num + 1, (num2 - num) - 1);
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + str + GetOverrideUrlName() + value);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + str + ".aspx" + value +
                    "&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentProductMultiImage(object guid, object originalImge)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/ProductMultiImage" + GetOverrideUrlName() +
                        "?guid=" + guid + "&OriginalImge=" + originalImge);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/ProductMultiImage.aspx?guid=" + guid +
                    "&OriginalImge=" + originalImge + "&AgentLoginID=" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentProductSearch(string search, object name)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/ProductSearch" + GetOverrideUrlName() +
                        "?Search=" + search + "&Name=" + name);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/ProductSearch.aspx?Search=" + search +
                    "&Name=" + name + "&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentRetUrl(string pagename)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName());
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename + ".aspx?AgentLoginID=" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentRetUrl(string pagename, object value)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + "/" + value +
                        GetOverrideUrlName());
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename + ".aspx?guid=" + value +
                    "&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentRetUrl(string pagename, object value, string args)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + "/" + value +
                        GetOverrideUrlName());
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename + ".aspx?" + args + "=" +
                    value + "&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentRetUrl(string pagename, string value, string args)
        {
            string str2;
            string str = string.Empty;
            if (ShopSettings.IsOverrideUrl)
            {
                str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName();
                if (args != null)
                {
                    str2 = str;
                    str = str2 + "?" + args + "=" + value;
                }
                return str;
            }
            str = "http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                  HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename + ".aspx";
            if (args != null)
            {
                str2 = str;
                str = str2 + "?" + args + "=" + value + "&AgentLoginID=" +
                      HttpContext.Current.Request.QueryString["AgentLoginID"];
            }
            return str;
        }
        public static string AgentRetUrlcenter(string pagename, string value, string args,int category)
        {
            string str2;
            string str = string.Empty;
            if (ShopSettings.IsOverrideUrl)
            {
                str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName();
                if (args != null)
                {
                    str2 = str;
                    str = str2 + "?category=" + category + "&" + args + "=" + value;
                }
                return str;
            }
            str = "http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                  HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename + ".aspx";
            if (args != null)
            {
                str2 = str;
                str = str2 + "?category="+category.ToString()+"&" + args + "=" + value + "&AgentLoginID=" +
                      HttpContext.Current.Request.QueryString["AgentLoginID"];
            }
            return str;
        }

        public static string AgentRetUrlMore(string pagename, string value)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName() + "?" +
                        value);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename + ".aspx?" + value +
                    "&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string AgentUserDefinedColumn(string pagename)
        {
            if (pagename.IndexOf("http://") != -1)
            {
                return pagename;
            }
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename.Split(new[] {'+'})[0] +
                        GetOverrideUrlName());
            }
            string str2 = string.Empty;
            if (pagename.Split(new[] {'+'})[1].IndexOf("?") != -1)
            {
                str2 = "&&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"];
            }
            else
            {
                str2 = "?AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"];
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/Agent/Agent/" +
                    HttpContext.Current.Request.QueryString["AgentLoginID"] + "/" + pagename.Split(new[] {'+'})[1] +
                    str2);
        }

        public static string GetDoMain()
        {
            if ((ConfigurationManager.AppSettings["DoMain"] != HttpContext.Current.Request.Url.Host) &&
                (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf("http://www") != -1))
            {
                return HttpContext.Current.Request.Url.Host;
            }
            return HttpContext.Current.Request.Url.Host.Replace("www",
                                                                HttpContext.Current.Request.QueryString["AgentLoginID"]);
        }

        public static string GetMainPage(string PageName)
        {
            string siteDomain = ShopSettings.siteDomain;
            if (!ShopSettings.siteDomain.Contains("http://"))
            {
                siteDomain = "http://" + siteDomain;
            }
            return (siteDomain + "/" + PageName);
        }

        public static string GetOverrideUrlName()
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ShopSettings.overrideUrlName;
            }
            return ".aspx";
        }

        public static string GetPage(string value)
        {
            int num = HttpContext.Current.Request.Path.LastIndexOf('/');
            int num2 = HttpContext.Current.Request.Path.LastIndexOf('.');
            string str = HttpContext.Current.Request.Path.Substring(num + 1, (num2 - num) - 1);
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + str + GetOverrideUrlName() + value);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + str + ".aspx" + value);
        }

        public static string OrganizBuyDetail(object guid, object productguid)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/OrganizBuyDetail/" + guid +
                        GetOverrideUrlName() + "?productguid=" + productguid);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/OrganizBuyDetail.aspx?guid=" + guid +
                    "&productguid=" + productguid);
        }

        public static string pop_GetMainPage(string PageName)
        {
            string siteDomain = ShopSettings.siteDomain;
            if (!ShopSettings.siteDomain.Contains("http%3A%2F%2F"))
            {
                siteDomain = "http%3A%2F%2F" + siteDomain;
            }
            return (siteDomain + "%2F" + PageName);
        }

        public static string pop_RetDomainUrl(string pagename)
        {
            return ("http%3A%2F%2F" + ShopSettings.siteDomain + "%2F" + pagename + GetOverrideUrlName());
        }

        public static string ProductMultiImage(object guid, object originalImge)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/ProductMultiImage" + GetOverrideUrlName() +
                        "?guid=" + guid + "&OriginalImge=" + originalImge);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/ProductMultiImage.aspx?guid=" + guid +
                    "&OriginalImge=" + originalImge);
        }

        public static string ProductSearch(string search, object name)
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ("http://" + HttpContext.Current.Request.Url.Host + "/ProductList" + GetOverrideUrlName() +
                        "?Search=" + search + "&code=" + name);
            }
            return ("http://" + HttpContext.Current.Request.Url.Host + "/ProductList.aspx?Search=" + search + "&code=" +
                    name);
        }

        public static string RetDomainUrl(string pagename)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + GetOverrideUrlName());
        }

        public static string RetDomainUrl(string pagename, object value)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + GetOverrideUrlName());
        }

        public static string RetDomainUrl(string pagename, object value, string args)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + GetOverrideUrlName() + "?" + args + "=" +
                    value);
        }

        public static string RetDomainUrlMore(string pagename, string value)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + GetOverrideUrlName() + "?" + value);
        }

        public static string RetUrl(string pagename)
        {
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName());
        }
        public static string RetUrlcenter(string pagename, string category)
        {
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName() + "?category=" + category);
        }

        public static string RetUrlcenter(string pagename, object value,string category)
        {
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + "/" + value +
                    GetOverrideUrlName() + "?category=" + category);
        }

        public static string RetUrl(string pagename, object value)
        {
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + "/" + value +
                    GetOverrideUrlName());
        }

        public static string RetUrl(string pagename, object value, string args)
        {
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName() + "?" +
                    args + "=" + value);
        }

        public static string RetUrl(string pagename, string value, string args,int category)
        {
            string str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName();
            if (args != null)
            {
                string str2 = str;
                str = str2 + "?category="+category.ToString()+"&" + args + "=" + value;
            }
            return str;
        }

        public static string RetUrlMore(string pagename, string value)
        {
            return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + GetOverrideUrlName() + "?" +
                    value);
        }

        public static string UserDefinedColumn(string pagename)
        {
            if (pagename.IndexOf("http://") == -1)
            {
                if (ShopSettings.IsOverrideUrl)
                {
                    return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename.Split(new[] {'+'})[0] +
                            GetOverrideUrlName());
                }
                return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename.Split(new[] {'+'})[1]);
            }
            return pagename;
        }
    }
}