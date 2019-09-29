using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;

namespace ShopNum1.Common
{
    public static class HexConvert
    {
        public static string Decode(string strDecode)
        {
            string str = "";
            for (int i = 0; i < (strDecode.Length/4); i++)
            {
                str = str + ((char) ((ushort) short.Parse(strDecode.Substring(i*4, 4), NumberStyles.HexNumber)));
            }
            return str;
        }

        public static string Encode(string strEncode)
        {
            string str = "";
            foreach (short num2 in strEncode.ToCharArray())
            {
                str = str + num2.ToString("X4");
            }
            return str;
        }

        public static SortedDictionary<string, string> GetRequestHtmlGet()
        {
            var dictionary = new SortedDictionary<string, string>();
            NameValueCollection queryString = HttpContext.Current.Request.QueryString;
            string[] allKeys = queryString.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                if ((queryString[i] != null) && (allKeys[i] != null))
                {
                    dictionary.Add(allKeys[i], queryString[i]);
                }
            }
            return dictionary;
        }

        public static SortedDictionary<string, string> GetRequestHtmlPost()
        {
            var dictionary = new SortedDictionary<string, string>();
            NameValueCollection form = HttpContext.Current.Request.Form;
            string[] allKeys = form.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                if ((form[i] != null) && (allKeys[i] != null))
                {
                    dictionary.Add(allKeys[i], form[i]);
                }
            }
            return dictionary;
        }
    }
}