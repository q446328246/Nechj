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

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AAA_KCE_AdvancePaymentApplyLog_ListNEC : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                string fh = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=sync_status");
                gzts.InnerHtml = fh;
                string str = (base.Request.QueryString["operateStatus"] == null) ? "-1" : base.Request.QueryString["operateStatus"];

                if (str == "1")
                {
                    DropdownListSOperateStatus.SelectedValue = "0";
                }
                else
                {
                    DropdownListSOperateStatus.SelectedValue = "-1";
                }

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
                    PageName = "AAA_KCE_AdvancePaymentApplyLog_ListNEC.aspx",
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
     

        protected void ButtonExamineBylink_Click(object sender, EventArgs e)
        {
            //string UserMemo = "";
            LinkButton btn = (LinkButton)sender;
            string orderid = btn.CommandArgument;

            ShopNum1_AdvancePaymentApplyLog_Action action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = action.NNECSearchTx(orderid.Replace("'", ""));
            if (table.Rows[0]["Status"].ToString() == "0")
            {
                string kgf = member_Action.SelectKGFPrice();
                string ETHAddress = table.Rows[0]["NECAddress"].ToString();
                string ETH = table.Rows[0]["NEC"].ToString();
                decimal zETH = Convert.ToDecimal(ETH) - Convert.ToDecimal(kgf);

                string post = "http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=transfer_nec&from=" + ShopNum1.Common.MD5JiaMi.ShopETHAddress + "&to=" + ETHAddress + "&amount=" + zETH.ToString();
                string fh = Post(post);

                if (fh != "")
                {
                    action.nnnnNECChangeOperateStatus(1, orderid.Replace("'", ""), fh);
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
            #region
            ShopNum1_AdvancePaymentApplyLog_Action action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = action.NNECSearchTx(orderid.Replace("'", ""));
            if (table.Rows[0]["Status"].ToString() == "0")
            {
                action.nnnnNECChangeOperateStatus(2, orderid.Replace("'", ""));
                string memloginid = table.Rows[0]["MemloginID"].ToString();
                string ETH = table.Rows[0]["NEC"].ToString();
                member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_DDDDV(memloginid, Convert.ToDecimal(ETH), "提现审核未通过");
                member_Action.PreTransfer_GZ(orderid.Replace("'", ""), ETH.ToString(), "提现审核未通过", memloginid, memloginid, "21");

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
            string text = TextBoxOrderNumber.Text;
            string str2 = TextBoxSMemLoginID.Text;
            string selectedValue = DropdownListSOperateStatus.SelectedValue;
            string str4 = TextBoxSDate1.Text;
            string str5 = TextBoxSDate2.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("OrderNumber", text);
            cookie.Values.Add("MemLoginID", str2);
            cookie.Values.Add("State", selectedValue);
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            return cookie;
        }
    }
}