using System.Configuration;
using System.Web;

namespace ShopNum1.TbTopCommon
{
    public static class TopConfig
    {
        private static bool bool_0;
        private static string string_0 = string.Empty;
        private static string string_1 = "test";
        private static string string_10 = "ShopNum1TbApp{0}";
        private static string string_11 = "ShopNum1AgentTbApp{0}";
        private static string string_12 = "ShopNum1AdminTbApp{0}";
        private static string string_2 = "test";
        private static string string_3 = "test";
        private static string string_4 = "test";
        private static string string_5 = "test";
        private static string string_6 = "test";

        private static string string_7 = (SendBox
            ? "http://gw.api.tbsandbox.com/router/rest"
            : "http://gw.api.taobao.com/router/rest");

        private static string string_8 = (SendBox
            ? "http://container.api.tbsandbox.com/container?appkey={0}"
            : "http://container.open.taobao.com/container?appkey={0}");

        private static string string_9 = (SendBox
            ? "http://container.api.tbsandbox.com/container?authcode={0}"
            : "http://container.open.taobao.com/container?authcode={0}");

        public static string AdminAppkey
        {
            get
            {
                if ((string_3 == "test") && (ConfigurationManager.AppSettings["AdminAppKey"] != null))
                {
                    string_3 = ConfigurationManager.AppSettings["AdminAppKey"];
                    return string_3;
                }
                return string_3;
            }
            set { string_3 = value; }
        }

        public static string AdminContainerURL
        {
            get { return string.Format(string_8, AdminAppkey); }
            set { string_8 = value; }
        }

        public static string AdminCookiesName
        {
            get
            {
                if (ConfigurationManager.AppSettings["AdminCookiesName"] != null)
                {
                    return string.Format(ConfigurationManager.AppSettings["AdminCookiesName"], AdminAppkey);
                }
                return string.Format(string_12, AdminAppkey);
            }
            set { string_12 = value; }
        }

        public static string AdminSecret
        {
            get
            {
                if ((string_4 == "test") && (ConfigurationManager.AppSettings["AdminAppSecret"] != null))
                {
                    string_4 = ConfigurationManager.AppSettings["AdminAppSecret"];
                    return string_4;
                }
                return string_4;
            }
            set { string_4 = value; }
        }

        public static string AgentAppkey
        {
            get
            {
                if (string_5 == "test")
                {
                    if (ConfigurationManager.AppSettings["AgentAppKey"] != null)
                    {
                        string_5 = ConfigurationManager.AppSettings["AgentAppKey"];
                        return string_5;
                    }
                    if (string_5 != null)
                    {
                        return string_5;
                    }
                }
                return string_5;
            }
            set { string_5 = value; }
        }

        public static string AgentContainerURL
        {
            get { return string.Format(string_8, AgentAppkey); }
            set { string_8 = value; }
        }

        public static string AgentCookiesName
        {
            get
            {
                if (ConfigurationManager.AppSettings["AgentCookiesName"] != null)
                {
                    return string.Format(ConfigurationManager.AppSettings["AgentCookiesName"], AgentAppkey);
                }
                return string.Format(string_11, AgentAppkey);
            }
            set { string_11 = value; }
        }

        public static string AgentSecret
        {
            get
            {
                if ((string_6 == "test") && (ConfigurationManager.AppSettings["AgentAppSecret"] != null))
                {
                    string_6 = ConfigurationManager.AppSettings["AgentAppSecret"];
                    return string_6;
                }
                return string_6;
            }
            set { string_6 = value; }
        }

        public static string AppKey
        {
            get
            {
                if (HttpContext.Current.Session["Appkey"] != null)
                {
                    string_1 = HttpContext.Current.Session["Appkey"].ToString();
                }
                return string_1;
            }
            set
            {
                HttpContext.Current.Session["Appkey"] = value;
                HttpContext.Current.Session.Timeout = 20;
            }
        }

        public static string AppSecret
        {
            get
            {
                if (HttpContext.Current.Session["AppSecret"] != null)
                {
                    string_2 = HttpContext.Current.Session["AppSecret"].ToString();
                }
                return string_2;
            }
            set
            {
                HttpContext.Current.Session["AppSecret"] = value;
                HttpContext.Current.Session.Timeout = 20;
            }
        }

        public static string ContainerAuthCodeURL
        {
            get { return string_9; }
            set { string_9 = value; }
        }

        public static string CookiesName
        {
            get
            {
                if (ConfigurationManager.AppSettings["CookieName"] != null)
                {
                    return string.Format(ConfigurationManager.AppSettings["CookieName"], AgentAppkey + AdminAppkey);
                }
                return string.Format(string_10, AgentAppkey + AdminAppkey);
            }
            set { string_10 = value; }
        }

        public static string Domain
        {
            get
            {
                if (ConfigurationManager.AppSettings["Domain"] != null)
                {
                    string_0 = ConfigurationManager.AppSettings["Domain"];
                    return string_0;
                }
                return string_0;
            }
            set { string_0 = value; }
        }

        public static bool SendBox
        {
            get
            {
                if (ConfigurationManager.AppSettings["SandBox"] != null)
                {
                    if (ConfigurationManager.AppSettings["SandBox"] == "1")
                    {
                        bool_0 = true;
                    }
                    else
                    {
                        bool_0 = false;
                    }
                }
                return bool_0;
            }
            set { bool_0 = value; }
        }

        public static string ServerURL
        {
            get { return string_7; }
            set { string_7 = value; }
        }

        public static string ShopContainerURL
        {
            get { return string.Format(string_8, AppKey); }
            set { string_8 = value; }
        }
    }
}