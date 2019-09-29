using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ShopNum1.TbTopCommon
{
    public class TopAPI
    {
        protected static string error_rspXML =
            "<error_response>\r\n<args list=\"true\"><arg><key>post</key><value>{2}</value></arg></args>\r\n<code>{0}</code>\r\n<msg>{1}</msg>\r\n<sub_code></sub_code>\r\n<sub_msg></sub_msg>\r\n</error_response>";

        public static string RestUrl = "http://gw.api.taobao.com/router/rest";

        protected static string CreateSign(IDictionary<string, string> parameters, string secret)
        {
            parameters.Remove("sign");
            IDictionary<string, string> dictionary = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> enumerator = dictionary.GetEnumerator();
            var builder = new StringBuilder(secret);
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                string key = current.Key;
                current = enumerator.Current;
                string str4 = current.Value;
                if (!(string.IsNullOrEmpty(key) || string.IsNullOrEmpty(str4)))
                {
                    builder.Append(key).Append(str4);
                }
            }
            builder.Append(secret);
            byte[] buffer = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
            var builder2 = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                string str2 = buffer[i].ToString("X");
                if (str2.Length == 1)
                {
                    builder2.Append("0");
                }
                builder2.Append(str2);
            }
            return builder2.ToString();
        }

        protected static string CustomErrorXML(string code, Exception exception_0)
        {
            return string.Format(error_rspXML, code,
                exception_0.Message.Replace("\"", "'").Replace("'", "'").Replace("&", "＆"),
                exception_0.StackTrace.Replace("\"", "'")
                    .Replace("'", "'")
                    .Replace("<", "＜")
                    .Replace(">", "＞")
                    .Replace("&", "＆"));
        }

        public static string GetItemcatsPost(string appkey, string appSecret, string method,
            IDictionary<string, string> param)
        {
            try
            {
                string restUrl = RestUrl;
                param.Add("app_key", appkey);
                param.Add("method", method);
                param.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                param.Add("format", "xml");
                param.Add("v", "2.0");
                param.Add("sign_method", "md5");
                param.Add("sign", CreateSign(param, appSecret));
                string input = string.Empty;
                var request = (HttpWebRequest) WebRequest.Create(restUrl);
                request.Method = "POST";
                request.KeepAlive = true;
                request.UserAgent = "SpaceTimeApp2.0";
                request.Timeout = 0x7530;
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                byte[] bytes = Encoding.UTF8.GetBytes(PostData(param));
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                var response = (HttpWebResponse) request.GetResponse();
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                Stream stream = null;
                StreamReader reader = null;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                input = reader.ReadToEnd();
                if (reader != null)
                {
                    reader.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                return Regex.Replace(input, @"[\x00-\x08\x0b-\x0c\x0e-\x1f]", "");
            }
            catch (Exception exception)
            {
                return CustomErrorXML("8001", exception);
            }
        }

        public static string Post(string method, IDictionary<string, string> parameters)
        {
            return Post(RestUrl, method, "", parameters);
        }

        public static string Post(string method, string session, IDictionary<string, string> parameters)
        {
            return Post(RestUrl, method, session, parameters);
        }

        public static string Post(string string_0, string method, string session, IDictionary<string, string> param)
        {
            string appKey = TopConfig.AppKey;
            string appSecret = TopConfig.AppSecret;
            return Post(string_0, appKey, appSecret, method, session, param);
        }

        public static string Post(string method, string session, IDictionary<string, string> textParams,
            IDictionary<string, FileItem> fileParams)
        {
            string appKey = TopConfig.AppKey;
            string appSecret = TopConfig.AppSecret;
            return Post(RestUrl, appKey, appSecret, method, session, textParams, fileParams);
        }

        public static string Post(string string_0, string appkey, string appSecret, string method, string session,
            IDictionary<string, string> param)
        {
            try
            {
                param.Add("app_key", appkey);
                param.Add("method", method);
                if (appkey != "test")
                {
                    param.Add("session", session);
                }
                param.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                param.Add("format", "xml");
                param.Add("v", "2.0");
                param.Add("sign_method", "md5");
                param.Add("sign", CreateSign(param, appSecret));
                string input = string.Empty;
                var request = (HttpWebRequest) WebRequest.Create(string_0);
                request.Method = "POST";
                request.KeepAlive = true;
                request.UserAgent = "SpaceTimeApp2.0";
                request.Timeout = 0x493e0;
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                byte[] bytes = Encoding.UTF8.GetBytes(PostData(param));
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                var response = (HttpWebResponse) request.GetResponse();
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                Stream stream = null;
                StreamReader reader = null;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                input = reader.ReadToEnd();
                if (reader != null)
                {
                    reader.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                return Regex.Replace(input, @"[\x00-\x08\x0b-\x0c\x0e-\x1f]", "");
            }
            catch (Exception exception)
            {
                return CustomErrorXML("8001", exception);
            }
        }

        public static string Post(string string_0, string appkey, string appSecret, string method, string session,
            IDictionary<string, string> textParams, IDictionary<string, FileItem> fileParams)
        {
            try
            {
                byte[] buffer;
                if ((fileParams == null) || (fileParams.Count == 0))
                {
                    return Post(string_0, appkey, appSecret, method, session, textParams);
                }
                textParams.Add("app_key", appkey);
                textParams.Add("method", method);
                textParams.Add("session", session);
                textParams.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                textParams.Add("format", "xml");
                textParams.Add("v", "2.0");
                textParams.Add("sign_method", "md5");
                textParams.Add("sign", CreateSign(textParams, appSecret));
                string input = string.Empty;
                ServicePointManager.DefaultConnectionLimit = 20;
                string str5 = DateTime.Now.Ticks.ToString("X");
                var request = (HttpWebRequest) WebRequest.Create(string_0);
                request.Method = "POST";
                request.KeepAlive = true;
                request.UserAgent = "SpaceTimeApp2.0";
                request.Timeout = 0x927c0;
                request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + str5;
                Stream requestStream = request.GetRequestStream();
                byte[] bytes = Encoding.UTF8.GetBytes("\r\n--" + str5 + "\r\n");
                byte[] buffer4 = Encoding.UTF8.GetBytes("\r\n--" + str5 + "--\r\n");
                string format = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
                IEnumerator<KeyValuePair<string, string>> enumerator2 = textParams.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    KeyValuePair<string, string> current = enumerator2.Current;
                    current = enumerator2.Current;
                    string s = string.Format(format, current.Key, current.Value);
                    buffer = Encoding.UTF8.GetBytes(s);
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Write(buffer, 0, buffer.Length);
                }
                string str2 = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
                IEnumerator<KeyValuePair<string, FileItem>> enumerator = fileParams.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    KeyValuePair<string, FileItem> pair = enumerator.Current;
                    string key = pair.Key;
                    pair = enumerator.Current;
                    FileItem item = pair.Value;
                    string str3 = string.Format(str2, key, item.GetFileName(), item.GetMimeType());
                    buffer = Encoding.UTF8.GetBytes(str3);
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Write(buffer, 0, buffer.Length);
                    byte[] content = item.GetContent();
                    requestStream.Write(content, 0, content.Length);
                }
                requestStream.Write(buffer4, 0, buffer4.Length);
                requestStream.Close();
                var response = (HttpWebResponse) request.GetResponse();
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                Stream stream = null;
                StreamReader reader = null;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                input = reader.ReadToEnd();
                if (reader != null)
                {
                    reader.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                return Regex.Replace(input, @"[\x00-\x08\x0b-\x0c\x0e-\x1f]", "");
            }
            catch (Exception exception)
            {
                return CustomErrorXML("8004", exception);
            }
        }

        protected static string PostData(IDictionary<string, string> parameters)
        {
            var builder = new StringBuilder();
            bool flag = false;
            IEnumerator<KeyValuePair<string, string>> enumerator = parameters.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                string key = current.Key;
                current = enumerator.Current;
                string str3 = current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(str3))
                {
                    if (flag)
                    {
                        builder.Append("&");
                    }
                    builder.Append(key);
                    builder.Append("=");
                    builder.Append(Uri.EscapeDataString(str3));
                    flag = true;
                }
            }
            builder.ToString();
            return builder.ToString();
        }
    }
}