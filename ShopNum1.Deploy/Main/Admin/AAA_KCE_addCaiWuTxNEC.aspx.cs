using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Net;
using ShopNum1.BusinessLogic;
using System.IO;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AAA_KCE_addCaiWuTxNEC : PageBase, IRequiresSessionState
    {
        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
            string p = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=get_main_account_nec_balance");
            Label1.Text = p;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string memloginid = TextBox4.Text.Trim();
                //decimal bili = Convert.ToDecimal(TextBox5.Text.Trim());
                string Tx = TextBox3.Text.Trim();

                string p = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=with_draw_nec&amount=" + Tx);
                if (p != "")
                {
                    string url = "https://etherscan.io/tx/" + p;
                    //Response.Write("<script>window.showModelessDialog('" + tz + "')</script>");
                    Response.Write("<script language='javascript'>window.open('" + url + "');</script>");
                }
                else
                {
                    Response.Write("<script>alert('提现失败！');</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('系统错误！');</script>");
            }

        }


        public string Post(string url)
        {
            string strURL = url;

            //创建一个HTTP请求 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式 
            request.Method = "POST";
            //内容类型
            request.ContentType = "json";

            //设置参数，并进行URL编码 
            //虽然我们需要传递给服务器端的实际参数是JsonParas(格式：[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}])，
            //但是需要将该字符串参数构造成键值对的形式（注："paramaters=[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}]"），
            //其中键paramaters为WebService接口函数的参数名，值为经过序列化的Json数据字符串
            //最后将字符串参数进行Url编码
            string paraUrlCoded = System.Web.HttpUtility.UrlEncode("paramaters");
            paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode("");

            byte[] payload;
            //将Json字符串转化为字节 
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength  
            request.ContentLength = payload.Length;
            //发送请求，获得请求流 

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();

            //服务器端返回的是一个XML格式的字符串，XML的Content才是我们所需要的Json数据

            StreamReader Reader = new StreamReader(s);

            strValue = Reader.ReadToEnd();//取出Content中的Json数据
            Reader.Close();
            s.Close();

            return strValue;//返回Json数据
        }
    }
}