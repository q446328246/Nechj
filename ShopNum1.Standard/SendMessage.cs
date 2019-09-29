using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Security;
namespace ShopNum1.Standard
{
    public class SendMessage
    {
        public static string send(string string_0, string urlAddr, Dictionary<string, string> dictionary_0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string text = string.Empty;
            foreach (KeyValuePair<string, string> current in dictionary_0)
            {
                stringBuilder.Append(current.Key);
                stringBuilder.Append("=");
                stringBuilder.Append(current.Value);
                stringBuilder.Append("&");
            }
            string text2 = stringBuilder.ToString();
            if (text2.Length > 0)
            {
                text2 = text2.TrimEnd(new char[]
				{
					'&'
				});
            }
            string result;
            try
            {
                string string_ = urlAddr + text2;
                result = SendMessage.getPage(urlAddr, text2);
                return result;
            }
            catch (Exception ex)
            {
                text = ex.Message;
            }
            result = text;
            return result;
        }
        public static string getPage(string string_0, string paramList)
        {
            string result = string.Empty;

            Encoding encoding = Encoding.UTF8;

            byte[] data = encoding.GetBytes(paramList);


            HttpWebRequest webRequest = WebRequest.Create(string_0) as HttpWebRequest;

            webRequest.Method = "POST";
            
            webRequest.KeepAlive = false;
            //webRequest.AllowAutoRedirect = true;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR  3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET ";


            webRequest.ContentLength = data.Length;
            webRequest.Timeout = 15000;

            try
            {
                Stream reqStream = webRequest.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                WebResponse response = webRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
                result = streamReader.ReadToEnd();
                response.Close();
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
        public static string smethod_0(string string_0)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(string_0, "MD5").ToLower();
        }
    }
}
