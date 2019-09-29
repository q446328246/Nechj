using System;
using System.Text;
using System.Web;

namespace ShopNum1.Payment
{
    public class TenpayUtil
    {
        public static string UrlEncode(string instr, string charset)
        {
            string result;
            if (instr == null || instr.Trim() == "")
            {
                result = "";
            }
            else
            {
                string text;
                try
                {
                    text = HttpUtility.UrlEncode(instr, Encoding.GetEncoding(charset));
                }
                catch (Exception)
                {
                    text = HttpUtility.UrlEncode(instr, Encoding.GetEncoding("GB2312"));
                }
                result = text;
            }
            return result;
        }

        public static string UrlDecode(string instr, string charset)
        {
            string result;
            if (instr == null || instr.Trim() == "")
            {
                result = "";
            }
            else
            {
                string text;
                try
                {
                    text = HttpUtility.UrlDecode(instr, Encoding.GetEncoding(charset));
                }
                catch (Exception)
                {
                    text = HttpUtility.UrlDecode(instr, Encoding.GetEncoding("GB2312"));
                }
                result = text;
            }
            return result;
        }

        public static uint UnixStamp()
        {
            return
                Convert.ToUInt32(
                    (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        public static string BuildRandomStr(int length)
        {
            var random = new Random();
            string text = random.Next().ToString();
            if (text.Length > length)
            {
                text = text.Substring(0, length);
            }
            else
            {
                if (text.Length < length)
                {
                    for (int i = length - text.Length; i > 0; i--)
                    {
                        text.Insert(0, "0");
                    }
                }
            }
            return text;
        }
    }
}