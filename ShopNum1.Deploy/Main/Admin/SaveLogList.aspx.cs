using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using ShopNum1.Deploy.KCELogic;
using ShopNum1.Deploy.KCESservice;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SaveLogList : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                //string fh = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=sync_status");
                //gzts.InnerHtml = fh;
                //string str = (base.Request.QueryString["operateStatus"] == null) ? "-1" : base.Request.QueryString["operateStatus"];

                //if (str == "1")
                //{
                //    DropdownListSOperateStatus.SelectedValue = "0";
                //}
                //else
                //{
                //    DropdownListSOperateStatus.SelectedValue = "-1";
                //}

                BindGrid();
            }
        }

        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataBind();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            if (action.deleteNEC_Tx(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "批量删除成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Search_SaveLog.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        public string WHJGet(string url)
        {
            //创建请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //GET请求
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//执行get请求
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            //返回内容JSON
            string retString = myStreamReader.ReadToEnd();
            return retString;
        }


        protected void ButtonExamineBylink_Click(object sender, EventArgs e)
        {
            //string UserMemo = "";
            LinkButton btn = (LinkButton)sender;
            string orderid = btn.CommandArgument;
        


            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = member_Action.GetSaveLog(orderid);
            if (table.Rows[0]["status"].ToString() == "0")
            {
                string kgf = "1";
                string saveurl = table.Rows[0]["saveurl"].ToString();
                string savesum = table.Rows[0]["savesum"].ToString();
                decimal zETH = Convert.ToDecimal(savesum) - Convert.ToDecimal(kgf);
                bool fh = false;

                #region 审核成功
                bool IsWHJDebug = false;
                try
                {
                    IsWHJDebug = ConfigurationManager.AppSettings["IsWHJDebug"] == "1" ? true : false;
                }
                catch (Exception)
                {

                }
                string api = IsWHJDebug ? "http://api.zqex.vip" : "http://api.gmsq.vip";
                string currency_id = IsWHJDebug ? "" : "32";
                string secret = "LVAcff-gyZN-5CzD5h_aSijNOBaRAlet2q_TwLufjRpa2H4bp1u-QnOI3ef5bxav";
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                api += "?appid=1";
                api += "&symbol=zqex.redemption.update_money";
                api += "&money="+ zETH;
                api += "&address=" + saveurl;
                api += "&identity=necjsjh";

                

                api += "&currency_id=" + currency_id;
               

                parameters.Add("appid", "1");
                parameters.Add("symbol", "zqex.redemption.update_money");
                parameters.Add("money", zETH.ToString());
                parameters.Add("address", saveurl);
                parameters.Add("identity", "necjsjh");
                
                parameters.Add("currency_id", currency_id);
                string sign = GetSignature(parameters, secret);
                api += "&sign=" + sign;





                string ssss = WHJGet(api);

                WHJRoot wr = StringHelper.Deserialize<WHJRoot>(ssss);
                if (wr.code == 0)
                {
                    fh = true;
                }


                #endregion



               
    
                if (fh)
                {
                    member_Action.SetSaveLog(orderid,"1");
                }
                else
                {
                    MessageBox.Show("操作失败!");
                }
            }
            else
            {
                MessageBox.Show("已操作过此提现订单!");
            }


            this.Num1GridViewShow.DataBind();
        }
        public string GetSignature(IDictionary<string, string> parameters, string secret)
        {
            // 先将参数以其参数名的字典序升序进行排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> iterator = sortedParams.GetEnumerator();

            // 遍历排序后的字典，将所有参数按"key=value"格式拼接在一起
            StringBuilder basestring = new StringBuilder();
            while (iterator.MoveNext())
            {
                string key = iterator.Current.Key;
                string value = iterator.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    basestring.Append(key).Append("=").Append(value);
                    basestring.Append("&");
                }
            }
            string ddaa = basestring.Remove(basestring.Length - 1, 1).ToString();
            secret = secret ?? "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(ddaa);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashmessage.Length; i++)
                {
                    /*string hex = hashmessage[i].ToString("x");
                    if (hex.Length == 1)
                    {
                        builder.Append("0");
                    }
                    builder.Append(hex);*/
                    builder.Append(hashmessage[i].ToString("x2"));
                }
                return builder.ToString();
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

        protected void selectJYstatus_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string txhash = btn.CommandArgument;

            //Response.Redirect("https://etherscan.io/tx/" + txhash + "");
            string url = "https://etherscan.io/tx/" + txhash;
            //Response.Write("<script>window.showModelessDialog('" + tz + "')</script>");
            Response.Write("<script language='javascript'>window.open('" + url + "');</script>");

        }
        protected void ButtonRefuseBylink_Click(object sender, EventArgs e)
        {
            //string UserMemo = "";
            LinkButton btn = (LinkButton)sender;
            string orderid = btn.CommandArgument;
         
   
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = member_Action.GetSaveLog(orderid);
            if (table.Rows[0]["status"].ToString() == "0")
            {
                #region 拒绝返还
                member_Action.SetSaveLog(orderid, "2");
                
                string memloginid = table.Rows[0]["memloginid"].ToString();
                string savepv_a = table.Rows[0]["savepv_a"].ToString();
                string savedv = table.Rows[0]["savedv"].ToString();
                string savesum = table.Rows[0]["savesum"].ToString();

                member_Action.INsertAdvancePaymentModifyLog_Gz_ADDZB(memloginid, Convert.ToDecimal(savepv_a), "救赎币未通过");
                member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_DDDDV(memloginid, Convert.ToDecimal(savedv), "救赎币未通过");
                member_Action.JianSavedayuse(memloginid, Convert.ToDecimal(savesum), 1);//0减1加

                #endregion
            }
            else
            {
                MessageBox.Show("已操作过此提现订单!");
            }


            this.Num1GridViewShow.DataBind();
        }


        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            //base.Response.Redirect("AdvancePaymentApplyLog_Operate.aspx?guid='" + CheckGuid.Value + "'");
        }

        protected void ButtonReportAll_Click(object sender, EventArgs e)
        {
            if (Num1GridViewShow.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出提现审核数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "AdvancePaymentApplyLog_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "17");
                cookie.Values.Add("Guids", "-1");
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string NECChangeOperateStatus(string operateStatus)
        {
            if (operateStatus == "0")
            {
                return " 未确认";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "0");
            }
            if (operateStatus == "1")
            {
                return " 已完成";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "1");
            }
            return "已拒绝";
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return "提现";
            }
            if (operateType == "1")
            {
                return "充值";
            }
            return "";
        }

        private HttpCookie method_5()
        {
            //string text = TextBoxOrderNumber.Text;
            string str2 = TextBoxSMemLoginID.Text;
            string selectedValue = DropdownListSOperateStatus.SelectedValue;
            string str4 = TextBoxSDate1.Text;
            string str5 = TextBoxSDate2.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            //cookie.Values.Add("OrderNumber", text);
            cookie.Values.Add("MemLoginID", str2);
            cookie.Values.Add("State", selectedValue);
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            return cookie;
        }
    }
}