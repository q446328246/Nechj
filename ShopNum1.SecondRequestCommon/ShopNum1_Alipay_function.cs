namespace ShopNum1.Second
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml;

    public class ShopNum1_Alipay_function
    {
        public string Build_mysign(Dictionary<string, string> dicArray, string key, string sign_type, string _input_charset)
        {
            string prestr = this.Create_linkstring(dicArray);
            int length = prestr.Length;
            prestr = prestr.Substring(0, length - 1) + key;
            return this.Sign(prestr, sign_type, _input_charset);
        }

        public string Create_linkstring(Dictionary<string, string> dicArray)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in dicArray)
            {
                builder.Append(pair.Key + "=" + pair.Value + "&");
            }
            return builder.ToString();
        }

        public void log_result(string sPath, string sWord)
        {
            StreamWriter writer = new StreamWriter(sPath, false, Encoding.Default);
            writer.Write(sWord);
            writer.Close();
        }

        public Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in dicArrayPre)
            {
                if (((pair.Key.ToLower() != "sign") && (pair.Key.ToLower() != "sign_type")) && (pair.Value != ""))
                {
                    string key = pair.Key.ToLower();
                    dictionary.Add(key, pair.Value);
                }
            }
            return dictionary;
        }

        public string Query_timestamp(string partner)
        {
            string url = "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + partner;
            XmlTextReader reader = new XmlTextReader(url);
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            return document.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
        }

        public string Sign(string prestr, string sign_type, string _input_charset)
        {
            StringBuilder builder = new StringBuilder(0x20);
            if (sign_type.ToUpper() == "MD5")
            {
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
                for (int i = 0; i < buffer.Length; i++)
                {
                    builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return builder.ToString();
        }
    }
}

