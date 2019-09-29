using System;
using System.Collections.Specialized;

namespace ShopNum1.DiscuzCommon
{
    public static class DisRequestActions
    {
        public const string Dis_ACTION_DELETEUSER = "deleteuser";
        public const string Dis_ACTION_GETCREDITSETTINGS = "getcreditsettings";
        public const string Dis_ACTION_GETTAG = "gettag";
        public const string Dis_ACTION_RENAMEUSER = "renameuser";
        public const string Dis_ACTION_SYNLOGIN = "login";
        public const string Dis_ACTION_SYNLOGOUT = "logout";
        public const string Dis_ACTION_TEST = "test";
        private static readonly StringCollection stringCollection_0;

        static DisRequestActions()
        {
            if (stringCollection_0 == null)
            {
                stringCollection_0 = new StringCollection();
                stringCollection_0.Add("test");
                stringCollection_0.Add("deleteuser");
                stringCollection_0.Add("renameuser");
                stringCollection_0.Add("gettag");
                stringCollection_0.Add("login");
                stringCollection_0.Add("logout");
                stringCollection_0.Add("getcreditsettings");
            }
        }

        public static bool IsValidAction(string action)
        {
            return stringCollection_0.Contains(action.ToLower());
        }

        public static int StringToInt(string string_0)
        {
            return StringToInt(string_0, 0);
        }

        public static int StringToInt(string string_0, int defaultValue)
        {
            if (!string.IsNullOrEmpty(string_0))
            {
                int result = 0;
                if (int.TryParse(string_0, out result))
                {
                    return result;
                }
            }
            return defaultValue;
        }

        public static int UnixTimestamp()
        {
            DateTime time = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x7b2, 1, 1));
            string str = DateTime.Parse(DateTime.Now.ToString()).Subtract(time).Ticks.ToString();
            return Convert.ToInt32(str.Substring(0, str.Length - 7));
        }
    }
}