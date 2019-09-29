using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Com.Alipay
{
    public class Notify
    {
        private readonly string a1 = "";
        private readonly string b1 = "";
        private readonly string c1 = "";
        private readonly string d1 = "";
        private string e1 = "https://mapi.alipay.com/gateway.do?service=notify_verify&";

        public Notify()
        {
            a1 = Config.Partner.Trim();
            b1 = Config.Key.Trim();
            c1 = Config.Input_charset.Trim().ToLower();
            d1 = Config.Sign_type.Trim().ToUpper();
        }

        public bool Verify(SortedDictionary<string, string> inputPara, string notify_id, string sign)
        {
            bool flag = a(inputPara, sign);
            string text = "true";
            if (notify_id != null && notify_id != "")
            {
                text = a(notify_id);
            }
            return text == "true" && flag;
        }

        private string a(SortedDictionary<string, string> A_0)
        {
            var dicArray = new Dictionary<string, string>();
            dicArray = Core.FilterPara(A_0);
            return Core.CreateLinkString(dicArray);
        }

        private bool a(SortedDictionary<string, string> A_0, string A_1)
        {
            var dicArray = new Dictionary<string, string>();
            dicArray = Core.FilterPara(A_0);
            string prestr = Core.CreateLinkString(dicArray);
            bool result = false;
            if (A_1 != null && A_1 != "")
            {
                string text = d1;
                if (text != null && text == "MD5")
                {
                    result = AlipayMD5.Verify(prestr, A_1, b1, c1);
                }
            }
            return result;
        }

        private string a(string A_0)
        {
            string a_ = string.Concat(new[]
                {
                    e1,
                    "partner=",
                    a1,
                    "&notify_id=",
                    A_0
                });
            return a(a_, 120000);
        }

        private string a(string A_0, int A_1)
        {
            string result;
            try
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(A_0);
                httpWebRequest.Timeout = A_1;
                var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                var streamReader = new StreamReader(responseStream, Encoding.Default);
                var stringBuilder = new StringBuilder();
                while (-1 != streamReader.Peek())
                {
                    stringBuilder.Append(streamReader.ReadLine());
                }
                result = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                result = "错误：" + ex.Message;
            }
            return result;
        }
    }
}