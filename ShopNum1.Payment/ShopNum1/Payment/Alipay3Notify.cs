using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class Alipay3Notify
    {
        private readonly string a1 = "";
        private readonly string b1 = "";
        private readonly string c1 = "";
        private readonly string d1 = "";
        private readonly string e1 = "";
        private readonly string f1 = "";
        private readonly string g1 = "";
        private readonly string h1 = "";
        private readonly Dictionary<string, string> i1 = new Dictionary<string, string>();
        private readonly string j1 = "";

        public Alipay3Notify(SortedDictionary<string, string> inputPara, string notify_id, string partner, string key,
                             string input_charset, string sign_type, string transport)
        {
            b1 = transport;
            if (b1 == "https")
            {
                a1 = "https://www.alipay.com/cooperate/gateway.do?";
            }
            else
            {
                a1 = "http://notify.alipay.com/trade/notify_query.do?";
            }
            c1 = partner.Trim();
            d1 = key.Trim();
            e1 = input_charset;
            f1 = sign_type.ToUpper();
            i1 = Para_filter(inputPara);
            j1 = Create_linkstring(i1);
            g1 = Build_mysign(i1, d1, f1, e1);
            h1 = a(notify_id);
        }

        public string Mysign
        {
            get { return g1; }
        }

        public string ResponseTxt
        {
            get { return h1; }
        }

        public string PreSignStr
        {
            get { return j1; }
        }

        private string a(string A_0)
        {
            string a_;
            if (b1 == "https")
            {
                a_ = string.Concat(new[]
                    {
                        a1,
                        "service=notify_verify&partner=",
                        c1,
                        "&notify_id=",
                        A_0
                    });
            }
            else
            {
                a_ = string.Concat(new[]
                    {
                        a1,
                        "partner=",
                        c1,
                        "&notify_id=",
                        A_0
                    });
            }
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

        public static Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var current in dicArrayPre)
            {
                if (current.Key.ToLower() != "sign" && current.Key.ToLower() != "sign_type" && current.Value != "")
                {
                    dictionary.Add(current.Key.ToLower(), current.Value);
                }
            }
            return dictionary;
        }

        public static string Create_linkstring(Dictionary<string, string> dicArray)
        {
            var stringBuilder = new StringBuilder();
            foreach (var current in dicArray)
            {
                stringBuilder.Append(current.Key + "=" + current.Value + "&");
            }
            return stringBuilder.ToString();
        }

        public static string Build_mysign(Dictionary<string, string> dicArray, string key, string sign_type,
                                          string _input_charset)
        {
            string text = Create_linkstring(dicArray);
            int length = text.Length;
            if (text != "")
            {
                text = text.Substring(0, length - 1);
            }
            text += key;
            return Sign(text, sign_type, _input_charset);
        }

        public static string Sign(string prestr, string sign_type, string _input_charset)
        {
            var stringBuilder = new StringBuilder(32);
            if (sign_type.ToUpper() == "MD5")
            {
                MD5 mD = new MD5CryptoServiceProvider();
                byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return stringBuilder.ToString();
        }
    }
}