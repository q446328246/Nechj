using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

public class Mobile : System.Web.UI.Page
{

    /********************************************************************************************************/
    //全文模板短信数据发送
    /********************************************************************************************************/
    #region 数据发送
    public string send(string mobiled, string Content, string templatet)
    {

        string sendurl = "http://api.sms.cn/sms/";
        string mobile = mobiled;
        string strContent = "{" + "\"code\"" + ":\"" + Content + "\"}";

        StringBuilder sbTemp = new StringBuilder();
        string uid = "qianlixing";
        string pwd = "9224938909";
        string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd + uid, "MD5"); //密码进行MD5加密
        //POST 传值
        string template = templatet;


        //if (1 == 1)
        if (templatet == "513065")
        {
            sbTemp.Append("?ac=send&uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobile + "&content=" + strContent + "&template=" + template);
            byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());
            String postReturn = doPostRequest(sendurl, bTemp);
            JObject studentsJson = JObject.Parse(postReturn);
            string fhh = studentsJson["stat"].ToString();
            return fhh;  //测试返回结果

        }
        else
        {
            //string cc = "?ac=sendint&uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobile + "&content=" + strContent + "&template=6015499";
            //sbTemp.Append("?ac=sendint&uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobile + "&content=" + strContent + "&template=6015499");
            //byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());

            //String postReturn = doPostRequest(sendurl, bTemp);
            //JObject studentsJson = JObject.Parse(postReturn);
            //string fhh = studentsJson["stat"].ToString();
            //return fhh;  //测试返回结果

            String postReturnf = doGetRequest("http://api.sms.cn/sms/?ac=sendint&uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobiled + "&content=" + strContent + "&template=" + templatet);
            JObject studentsJsonf = JObject.Parse(postReturnf);
            string fhh = studentsJsonf["stat"].ToString();
            return fhh;  //测试返回结果
        }





    }
    //POST方式发送得结果
    private static String doPostRequest(string url, byte[] bData)
    {
        System.Net.HttpWebRequest hwRequest;
        System.Net.HttpWebResponse hwResponse;

        string strResult = string.Empty;
        try
        {
            hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            hwRequest.Timeout = 5000;
            hwRequest.Method = "POST";
            hwRequest.ContentType = "application/x-www-form-urlencoded";
            hwRequest.ContentLength = bData.Length;

            System.IO.Stream smWrite = hwRequest.GetRequestStream();
            smWrite.Write(bData, 0, bData.Length);
            smWrite.Close();
        }
        catch (System.Exception err)
        {
            WriteErrLog(err.ToString());
            return strResult;
        }

        //get response
        try
        {
            hwResponse = (HttpWebResponse)hwRequest.GetResponse();
            StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
            strResult = srReader.ReadToEnd();
            srReader.Close();
            hwResponse.Close();
        }
        catch (System.Exception err)
        {
            WriteErrLog(err.ToString());
        }
        return strResult;
    }
    private static void WriteErrLog(string strErr)
    {
        Console.WriteLine(strErr);
        System.Diagnostics.Trace.WriteLine(strErr);
    }
    #endregion



    //GET方式发送得结果
    private static String doGetRequest(string url)
    {
        HttpWebRequest hwRequest;
        HttpWebResponse hwResponse;

        string strResult = string.Empty;
        try
        {
            hwRequest = (System.Net.HttpWebRequest)WebRequest.Create(url);
            hwRequest.Timeout = 5000;
            hwRequest.Method = "GET";
            hwRequest.ContentType = "application/x-www-form-urlencoded";
        }
        catch (System.Exception err)
        {
            WriteErrLog(err.ToString());
            return strResult;
        }

        //get response
        try
        {
            hwResponse = (HttpWebResponse)hwRequest.GetResponse();
            StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
            strResult = srReader.ReadToEnd();
            srReader.Close();
            hwResponse.Close();
        }
        catch (System.Exception err)
        {
            WriteErrLog(err.ToString());
        }

        return strResult;
    }
}