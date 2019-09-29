using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace ShopNum1.TbTopCommon
{
    public static class TopClient
    {
        public static bool isAdminSessionTrue = false;
        public static bool isAgentSessionTrue = false;

        public static string AdminSession
        {
            get
            {
                try
                {
                    if ((HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"] != null))
                    {
                        return HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"];
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static string AdminUserNick
        {
            get
            {
                try
                {
                    if ((HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"] != null))
                    {
                        return
                            HttpUtility.UrlDecode(
                                HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["visitor_nick"]);
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static string AgentSession
        {
            get
            {
                try
                {
                    if ((HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"] != null))
                    {
                        return HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"];
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static string AgentUserNick
        {
            get
            {
                try
                {
                    if ((HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"] != null))
                    {
                        return
                            HttpUtility.UrlDecode(
                                HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"]);
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static bool IsAdminLogin
        {
            get
            {
                return ((HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"] != null));
            }
        }

        public static bool IsAgentLogin
        {
            get
            {
                return ((HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"] != null));
            }
        }

        public static bool IsLogin
        {
            get
            {
                return ((HttpContext.Current.Request.Cookies[TopConfig.CookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"] != null));
            }
        }

        public static string Session
        {
            get
            {
                try
                {
                    if ((HttpContext.Current.Request.Cookies[TopConfig.CookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"] != null))
                    {
                        return HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"];
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static string UserNick
        {
            get
            {
                try
                {
                    if ((HttpContext.Current.Request.Cookies[TopConfig.CookiesName] != null) &&
                        (HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"] != null))
                    {
                        return
                            HttpUtility.UrlDecode(
                                HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["visitor_nick"]);
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static int AdminLogout()
        {
            var cookie = new HttpCookie(TopConfig.AdminCookiesName, "")
            {
                Expires = DateTime.Now.AddDays(-1.0)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            return 1;
        }

        public static int AgentLogout()
        {
            var cookie = new HttpCookie(TopConfig.AgentCookiesName, "")
            {
                Expires = DateTime.Now.AddDays(-1.0)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            return 1;
        }

        public static bool isSessionTimeOut(Page page, string user)
        {
            if (user == "admin")
            {
                if (IsAdminLogin)
                {
                    var parameters = new Dictionary<string, string>();
                    parameters.Add("fields", "oid");
                    parameters.Add("rate_type", "get");
                    parameters.Add("role", "seller");
                    parameters.Add("page_no", "1");
                    parameters.Add("page_size", "1");
                    string xml = TopAPI.Post("taobao.traderates.get", AdminSession, parameters);
                    var document = new XmlDocument();
                    document.LoadXml(xml);
                    var rsp = new ErrorRsp();
                    var parser = new Parser();
                    if (parser.IsXmlError2(document, rsp))
                    {
                        isAdminSessionTrue = false;
                        return false;
                    }
                    isAdminSessionTrue = true;
                    return true;
                }
                isAdminSessionTrue = false;
                return false;
            }
            if (IsAgentLogin)
            {
                isAgentSessionTrue = true;
                return true;
            }
            isAgentSessionTrue = false;
            return false;
        }

        public static int Logout()
        {
            HttpContext.Current.Response.Cookies.Remove(TopConfig.CookiesName);
            HttpContext.Current.Response.Cookies.Remove(TopConfig.AdminCookiesName);
            HttpContext.Current.Response.Cookies.Remove(TopConfig.AgentCookiesName);
            return 1;
        }

        public static void SetAdminCookies(string nick, string sessionkey)
        {
            HttpContext.Current.Response.Cookies[TopConfig.AdminCookiesName]["visitor_nick"] =
                HttpUtility.UrlEncode(nick);
            HttpContext.Current.Response.Cookies[TopConfig.AdminCookiesName]["top_session"] = sessionkey;
        }

        public static void SetAgentCookies(string nick, string sessionkey)
        {
            HttpContext.Current.Response.Cookies[TopConfig.AgentCookiesName]["visitor_nick"] =
                HttpUtility.UrlEncode(nick);
            HttpContext.Current.Response.Cookies[TopConfig.AgentCookiesName]["top_session"] = sessionkey;
        }

        public static void SetCookies(string nick, string sessionkey)
        {
            HttpContext.Current.Response.Cookies[TopConfig.CookiesName]["visitor_nick"] = HttpUtility.UrlEncode(nick);
            HttpContext.Current.Response.Cookies[TopConfig.CookiesName]["top_session"] = sessionkey;
        }
    }
}