using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System;

namespace ShopNum1.KuaiDi
{
    public class ShopNum1_KuaiDiRequest
    {
        private string string_0 = "http://api.kuaidi100.com/api?id={0}&com={1}&nu={2}&show={3}&muti={4}&order={5}";
        private string string_1 = "";
        private string string_2 = "2";
        private string string_3 = "desc";
        private string string_4 = "1";

        public string apikey
        {
            get
            {
                if (string_1 == "")
                {
                    string_1 = ConfigurationManager.AppSettings["KuaiDiApiKey"];
                }
                return string_1;
            }
            set { string_1 = value; }
        }

        public string muti
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string order
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string showtype
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string GetKuaidiInfo(string kuaicom, string kuainum, string vlicode)
        {
              Stream responseStream;
              string result="";
              try
              {
                  responseStream =
                    WebRequest.Create(string.Format(string_0, new object[] { apikey, kuaicom, kuainum, showtype, muti, order }))
                              .GetResponse()
                              .GetResponseStream();
                  Encoding encoding = Encoding.UTF8;
                  var reader = new StreamReader(responseStream, encoding);
                  result= reader.ReadToEnd();
              }
              catch (System.Exception ex)
              {
 
              }
                return result;
        }

        public string GetKuaidiInfo(string kuaicom, string kuainum, string vlicode, string kuaidishow, string kuaidimuti,
                                    string kuaidiorder)
        {
            if (kuaidishow == "")
            {
                kuaidishow = showtype;
            }
            if (kuaidimuti == "")
            {
                kuaidimuti = muti;
            }
            if (kuaidiorder == "")
            {
                kuaidiorder = order;
            }
            Stream responseStream =
                WebRequest.Create(string.Format(string_0,
                                                new object[]
                                                    {apikey, kuaicom, kuainum, kuaidishow, kuaidimuti, kuaidiorder}))
                          .GetResponse()
                          .GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            var reader = new StreamReader(responseStream, encoding);
            return reader.ReadToEnd();
        }

        //电商ID
        private string EBusinessID = "1271332";
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private string AppKey = "2d11f2d4-189a-4f99-8c60-8ac6cb168c2b";
        //请求url
        private string ReqURL = "http://api.kdniao.com/Ebusiness/EbusinessOrderHandle.aspx";




        /// <summary>
        /// Json方式 查询订单物流轨迹
        /// </summary>
        /// <returns></returns>
        public string getOrderTracesByJson(string name, string num)
        {
            string requestData = "{'LogisticCode':'" + num + "','ShipperCode':'" + name + "'}";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "1002");
            string dataSign = encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = sendPost(ReqURL, param);

            //根据公司业务处理返回的信息......

            return result;
        }

        /// <summary>
        /// Post方式提交数据，返回网页的源代码
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="param">请求的参数集合</param>
        /// <returns>远程资源的响应结果</returns>
        private string sendPost(string url, Dictionary<string, string> param)
        {
            string result = "";
            StringBuilder postData = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                foreach (var p in param)
                {
                    if (postData.Length > 0)
                    {
                        postData.Append("&");
                    }
                    postData.Append(p.Key);
                    postData.Append("=");
                    postData.Append(p.Value);
                }
            }
            byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(postData.ToString());
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = url;
                request.Accept = "*/*";
                request.Timeout = 30 * 1000;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.Method = "POST";
                request.ContentLength = byteData.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(byteData, 0, byteData.Length);
                stream.Flush();
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream backStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(backStream, Encoding.GetEncoding("UTF-8"));
                result = sr.ReadToEnd();
                sr.Close();
                backStream.Close();
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        ///<summary>
        ///电商Sign签名
        ///</summary>
        ///<param name="content">内容</param>
        ///<param name="keyValue">Appkey</param>
        ///<param name="charset">URL编码 </param>
        ///<returns>DataSign签名</returns>
        private string encrypt(String content, String keyValue, String charset)
        {
            if (keyValue != null)
            {
                return base64(MD5(content + keyValue, charset), charset);
            }
            return base64(MD5(content, charset), charset);
        }

        ///<summary>
        /// 字符串MD5加密
        ///</summary>
        ///<param name="str">要加密的字符串</param>
        ///<param name="charset">编码方式</param>
        ///<returns>密文</returns>
        private string MD5(string str, string charset)
        {
            byte[] buffer = System.Text.Encoding.GetEncoding(charset).GetBytes(str);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider check;
                check = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] somme = check.ComputeHash(buffer);
                string ret = "";
                foreach (byte a in somme)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("X");
                    else
                        ret += a.ToString("X");
                }
                return ret.ToLower();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="str">内容</param>
        /// <param name="charset">编码方式</param>
        /// <returns></returns>
        private string base64(String str, String charset)
        {
            return Convert.ToBase64String(System.Text.Encoding.GetEncoding(charset).GetBytes(str));
        }


        public string GetKuaidiInfoMY(string kuaicom, string kuainum)
        {

            string result = "";

            JObject obj = (JObject)JsonConvert.DeserializeObject(getOrderTracesByJson(kuaicom, kuainum));
            JArray jsonObj = JArray.Parse(obj["Traces"].ToString());
            string message = @"<table border='0'>
                    <tr><td width='80'>时间</td><td width='100'>地址</td></tr>";
            string tpl = "<tr><td>{0}</td><td>{1}</td></tr>";
            foreach (JObject jObject in jsonObj)
            {
                message += String.Format(tpl, jObject["AcceptTime"], jObject["AcceptStation"]);
            }
            message += "</table>";
            result = message;
            return result;
        }
    }
}