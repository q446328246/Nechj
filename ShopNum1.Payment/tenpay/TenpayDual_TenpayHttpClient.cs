using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace tenpay
{
    public class TenpayDual_TenpayHttpClient
    {
        private string a;
        private string b;
        private string c;
        private string d;
        private string e;
        private string f;
        private string g;
        private int h;
        private int i;
        private string j;

        public TenpayDual_TenpayHttpClient()
        {
            g = "";
            e = "";
            f = "";
            a = "";
            b = "";
            c = "POST";
            d = "";
            h = 60;
            i = 0;
            j = "gb2312";
        }

        public void setReqContent(string reqContent)
        {
            a = reqContent;
        }

        public string getResContent()
        {
            return b;
        }

        public void setMethod(string method)
        {
            c = method;
        }

        public string getErrInfo()
        {
            return d;
        }

        public void setCertInfo(string certFile, string certPasswd)
        {
            e = certFile;
            f = certPasswd;
        }

        public void setCaInfo(string caFile)
        {
            g = caFile;
        }

        public void setTimeOut(int timeOut)
        {
            h = timeOut;
        }

        public int getResponseCode()
        {
            return i;
        }

        public void setCharset(string charset)
        {
            j = charset;
        }

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain,
                                          SslPolicyErrors errors)
        {
            return true;
        }

        public bool call()
        {
            HttpWebResponse httpWebResponse = null;
            bool result;
            try
            {
                string text = null;
                HttpWebRequest httpWebRequest;
                if (c.ToUpper() == "POST")
                {
                    string[] array = Regex.Split(a, "\\?");
                    httpWebRequest = (HttpWebRequest) WebRequest.Create(array[0]);
                    if (array.Length >= 2)
                    {
                        text = array[1];
                    }
                }
                else
                {
                    httpWebRequest = (HttpWebRequest) WebRequest.Create(a);
                }
                ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                if (e != "")
                {
                    httpWebRequest.ClientCertificates.Add(new X509Certificate2(e, f));
                }
                httpWebRequest.Timeout = h*1000;
                Encoding encoding = Encoding.GetEncoding(j);
                if (text != null)
                {
                    byte[] bytes = encoding.GetBytes(text);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.ContentLength = bytes.Length;
                    Stream requestStream = httpWebRequest.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding);
                b = streamReader.ReadToEnd();
                streamReader.Close();
                httpWebResponse.Close();
            }
            catch (Exception ex)
            {
                d += ex.Message;
                if (httpWebResponse != null)
                {
                    i = Convert.ToInt32(httpWebResponse.StatusCode);
                }
                result = false;
                return result;
            }
            i = Convert.ToInt32(httpWebResponse.StatusCode);
            result = true;
            return result;
        }
    }
}