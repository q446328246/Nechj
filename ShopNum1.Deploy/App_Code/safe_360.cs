using System;
using System.Text.RegularExpressions;
using System.Web;

namespace ShopNum1.Deploy.App_Code
{
    public class safe_360
    {
        private const string string_0 = @"<[^>]+?style=[\w]+?:expression\(|\b(alert|confirm|prompt)\b|^\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*img\b|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)";

        public static bool CheckData(string inputData)
        {
            return Regex.IsMatch(inputData, @"<[^>]+?style=[\w]+?:expression\(|\b(alert|confirm|prompt)\b|^\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*img\b|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)");
        }

        public static bool CookieData()
        {
            bool flag = false;
            for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
            {
                if (flag = CheckData(HttpContext.Current.Request.Cookies[i].Value.ToLower()))
                {
                    return flag;
                }
            }
            return flag;
        }

        public static bool GetData()
        {
            bool flag = false;
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                if (flag = CheckData(HttpContext.Current.Request.QueryString[i].ToString()))
                {
                    return flag;
                }
            }
            return flag;
        }

        public static bool PostData()
        {
            bool flag = false;
            for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
            {
                if (flag = CheckData(HttpContext.Current.Request.Form[i].ToString()))
                {
                    return flag;
                }
            }
            return flag;
        }

        public static bool referer()
        {
            return CheckData(HttpContext.Current.Request.UrlReferrer.ToString());
        }
    }
}