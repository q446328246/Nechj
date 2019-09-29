using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// BackPwd 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BackPwd : System.Web.Services.WebService
    {

        [WebMethod]
        public string VerificationCode(string mobile)
        {
            if (IsHandset(mobile))
            {
                string code = new Random().Next(111111, 999999).ToString();
                string content = "亲，本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【唐江巴巴】";
                bool ret = SendFast(mobile, content);
                if (ret)
                {
                    return code;
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                return "手机号码格式不正确";
            }
        }

        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^1[3|4|5|7|8][0-9]\d{8}$");
        }

        public static string SendVerificationMsg(string url, string param)
        {
            string result = string.Empty;

            Encoding encoding = Encoding.UTF8;

            byte[] data = encoding.GetBytes(param);


            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;

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

        public bool SendFast(string mobile, string content)
        {
            bool flag = false;
            string url = "http://106.3.37.99:7799/sms.aspx";
            string con = HttpUtility.UrlEncode(content, Encoding.UTF8);
            string data = "action=send&userid=117&account=tj88&password=tj123321&mobile="+mobile+ "&content="+ con;
            string text2 = SendVerificationMsg(url, data);
            bool result;
            if (text2 == "")
            {
                result = false;
            }
            else
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(text2);
                XmlNode node = xml.ChildNodes[1].ChildNodes[0];



                if (node.InnerText.ToLower() == "success")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                result = flag;
            }
            return result;
        }

        [WebMethod]
        public string updatepwd(string memberid,string newpwd)
        {
            string result = string.Empty;
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            try
            {
                int count = action.UpdatePwd(memberid.Trim(), ShopNum1.Common.Encryption.GetMd5Hash(newpwd.Trim()));
                if (count == 1)
                {
                    result = "密码修改成功";
                }
                else
                {
                    result = "密码修改失败"; 
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
    }
}
