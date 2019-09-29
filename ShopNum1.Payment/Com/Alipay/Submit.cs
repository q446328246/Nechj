using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Com.Alipay
{
    public class Submit
    {
        private static string a1;
        public static string _key;
        private static string b1;
        private static string c1;

        static Submit()
        {
            a1 = "https://mapi.alipay.com/gateway.do?";
            _key = "";
            b1 = "";
            c1 = "";
            b1 = Config.Input_charset.Trim().ToLower();
            c1 = Config.Sign_type.Trim().ToUpper();
        }

        public static string key { get; set; }

        private static string a(Dictionary<string, string> A_0)
        {
            string prestr = Core.CreateLinkString(A_0);
            string text = c1;
            string result;
            if (text != null && text == "MD5")
            {
                result = AlipayMD5.Sign(prestr, _key, b1);
            }
            else
            {
                result = "";
            }
            return result;
        }

        private static Dictionary<string, string> a(SortedDictionary<string, string> A_0)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary = Core.FilterPara(A_0);
            string value = a(dictionary);
            dictionary.Add("sign", value);
            dictionary.Add("sign_type", c1);
            return dictionary;
        }

        private static string a(SortedDictionary<string, string> A_0, Encoding A_1)
        {
            var dicArray = new Dictionary<string, string>();
            dicArray = a(A_0);
            return Core.CreateLinkStringUrlencode(dicArray, A_1);
        }

        public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string strMethod,
                                          string strButtonValue)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary = a(sParaTemp);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Concat(new[]
                {
                    "<form id='alipaysubmit' name='alipaysubmit' action='",
                    a1,
                    "_input_charset=",
                    b1,
                    "' method='",
                    strMethod.ToLower().Trim(),
                    "'>"
                }));
            foreach (var current in dictionary)
            {
                stringBuilder.Append(string.Concat(new[]
                    {
                        "<input type='hidden' name='",
                        current.Key,
                        "' value='",
                        current.Value,
                        "'/>"
                    }));
            }
            stringBuilder.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");
            stringBuilder.Append("<script>document.forms['alipaysubmit'].submit();</script>");
            return stringBuilder.ToString();
        }

        public static string BuildRequest(SortedDictionary<string, string> sParaTemp)
        {
            Encoding encoding = Encoding.GetEncoding(b1);
            string s = a(sParaTemp, encoding);
            byte[] bytes = encoding.GetBytes(s);
            string requestUriString = a1 + "_input_charset=" + b1;
            string result = "";
            try
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(requestUriString);
                httpWebRequest.Method = "post";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = bytes.Length;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                var streamReader = new StreamReader(responseStream, encoding);
                var stringBuilder = new StringBuilder();
                string value;
                while ((value = streamReader.ReadLine()) != null)
                {
                    stringBuilder.Append(value);
                }
                responseStream.Close();
                result = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                result = "报错：" + ex.Message;
            }
            return result;
        }

        public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string strMethod, string fileName,
                                          byte[] data, string contentType, int lengthFile)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary = a(sParaTemp);
            string requestUriString = a1 + "_input_charset=" + b1;
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(requestUriString);
            httpWebRequest.Method = strMethod;
            string str = DateTime.Now.Ticks.ToString("x");
            string text = "--" + str;
            httpWebRequest.ContentType = "\r\nmultipart/form-data; boundary=" + str;
            httpWebRequest.KeepAlive = true;
            var stringBuilder = new StringBuilder();
            foreach (var current in dictionary)
            {
                stringBuilder.Append(string.Concat(new[]
                    {
                        text,
                        "\r\nContent-Disposition: form-data; name=\"",
                        current.Key,
                        "\"\r\n\r\n",
                        current.Value,
                        "\r\n"
                    }));
            }
            stringBuilder.Append(text + "\r\nContent-Disposition: form-data; name=\"withhold_file\"; filename=\"");
            stringBuilder.Append(fileName);
            stringBuilder.Append("\"\r\nContent-Type: " + contentType + "\r\n\r\n");
            string s = stringBuilder.ToString();
            Encoding encoding = Encoding.GetEncoding(b1);
            byte[] bytes = encoding.GetBytes(s);
            byte[] bytes2 = Encoding.ASCII.GetBytes("\r\n" + text + "--\r\n");
            long contentLength = (bytes.Length + lengthFile + bytes2.Length);
            httpWebRequest.ContentLength = contentLength;
            Stream requestStream = httpWebRequest.GetRequestStream();
            Stream responseStream;
            string result;
            try
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Write(data, 0, lengthFile);
                requestStream.Write(bytes2, 0, bytes2.Length);
                var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                responseStream = httpWebResponse.GetResponseStream();
            }
            catch (WebException ex)
            {
                result = ex.ToString();
                return result;
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                }
            }
            var streamReader = new StreamReader(responseStream, encoding);
            var stringBuilder2 = new StringBuilder();
            string value;
            while ((value = streamReader.ReadLine()) != null)
            {
                stringBuilder2.Append(value);
            }
            responseStream.Close();
            result = stringBuilder2.ToString();
            return result;
        }

        public static string Query_timestamp()
        {
            string url = string.Concat(new[]
                {
                    a1,
                    "service=query_timestamp&partner=",
                    Config.Partner,
                    "&_input_charset=",
                    Config.Input_charset
                });
            var reader = new XmlTextReader(url);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(reader);
            return xmlDocument.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
        }
    }
}