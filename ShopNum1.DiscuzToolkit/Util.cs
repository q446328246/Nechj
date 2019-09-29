using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    public class Util
    {
        private const string string_0 = "\r\n";
        private static readonly Dictionary<int, XmlSerializer> dictionary_0 = new Dictionary<int, XmlSerializer>();
        private readonly string string_1;
        private string string_2;

        public Util(string api_key, string secret, string string_4)
        {
            string_1 = api_key;
            string_2 = secret;
            Url = string_4;
        }

        internal string ApiKey
        {
            get { return string_1; }
        }

        private static XmlSerializer ErrorSerializer
        {
            get { return GetSerializer(typeof (Error)); }
        }

        internal string SharedSecret
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        internal string Url { get; set; }

        public bool UseJson { get; set; }

        public static bool GetBoolFromString(string input)
        {
            try
            {
                return bool.Parse(input);
            }
            catch
            {
                return false;
            }
        }

        public static int GetIntFromString(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        public T GetResponse<T>(string method_name, params DiscuzParam[] parameters)
        {
            T local2;
            DiscuzParam[] paramArray = Sign(method_name, parameters);
            var builder = new StringBuilder();
            for (int i = 0; i < paramArray.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append("&");
                }
                builder.Append(paramArray[i].ToEncodedString());
            }
            byte[] buffer = GetResponseBytes(Url, method_name, builder.ToString());
            XmlSerializer serializer = GetSerializer(typeof (T));
            try
            {
                local2 = (T) serializer.Deserialize(new MemoryStream(buffer));
            }
            catch
            {
                var error = (Error) ErrorSerializer.Deserialize(new MemoryStream(buffer));
                File.AppendAllText(HttpContext.Current.Request.PhysicalApplicationPath + @"\log\logDiscuz.txt",
                    string.Format("{0}:{1}，错误代码:{2}\r\n", DateTime.Now, error.ErrorMsg,
                        error.ErrorCode));
                throw new DiscuzException(error.ErrorCode, error.ErrorMsg);
            }
            return local2;
        }

        public static byte[] GetResponseBytes(string apiUrl, string method_name, string postData)
        {
            byte[] bytes;
            var request = (HttpWebRequest) WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Timeout = 0x4e20;
            HttpWebResponse response = null;
            try
            {
                var writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postData);
                if (writer != null)
                {
                    writer.Close();
                }
                response = (HttpWebResponse) request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    bytes = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return bytes;
        }

        public static XmlSerializer GetSerializer(Type type_0)
        {
            int hashCode = type_0.GetHashCode();
            if (!dictionary_0.ContainsKey(hashCode))
            {
                dictionary_0.Add(hashCode, new XmlSerializer(type_0));
            }
            return dictionary_0[hashCode];
        }

        private string method_0(string string_4, params DiscuzParam[] discuzParam_0)
        {
            DiscuzParam[] paramArray = Sign(string_4, discuzParam_0);
            var builder = new StringBuilder(Url);
            for (int i = 0; i < paramArray.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append("&");
                }
                builder.Append(paramArray[i]);
            }
            return builder.ToString();
        }

        public static string RemoveJsonNull(string json)
        {
            json = Regex.Replace(json, ",\"\\w*\":null", string.Empty);
            json = Regex.Replace(json, "\"\\w*\":null,", string.Empty);
            json = Regex.Replace(json, "\"\\w*\":null", string.Empty);
            json = Regex.Replace(json, ",\"\\w*\":0", string.Empty);
            json = Regex.Replace(json, "\"\\w*\":0,", string.Empty);
            return json;
        }

        public DiscuzParam[] Sign(string method_name, DiscuzParam[] parameters)
        {
            var list = new List<DiscuzParam>(parameters)
            {
                DiscuzParam.Create("method", method_name),
                DiscuzParam.Create("api_key", string_1),
                DiscuzParam.Create("call_id", DateTime.Now.Ticks)
            };
            list.Sort();
            var builder = new StringBuilder();
            foreach (DiscuzParam param in list)
            {
                if (!string.IsNullOrEmpty(param.Value))
                {
                    builder.Append(param);
                }
            }
            builder.Append(string_2);
            byte[] buffer2 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
            var builder2 = new StringBuilder();
            foreach (byte num2 in buffer2)
            {
                builder2.Append(num2.ToString("x2"));
            }
            list.Add(DiscuzParam.Create("sig", builder2.ToString()));
            return list.ToArray();
        }
    }
}