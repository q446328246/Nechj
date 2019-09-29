﻿using System;
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
    public partial class AdvancePaymentApplyLog_ListETH_Cz : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
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


        //protected void ButtonDelete_Click(object sender, EventArgs e)
        //{
        //    var action =
        //        (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
        //    if (action.Delete(CheckGuid.Value) > 0)
        //    {
        //        var operateLog = new ShopNum1_OperateLog
        //        {
        //            Record = "删除成功",
        //            OperatorID = base.ShopNum1LoginID,
        //            IP = Globals.IPAddress,
        //            PageName = "AdvancePaymentApplyLog_List.aspx",
        //            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        //        };
        //        base.OperateLog(operateLog);
        //        BindGrid();
        //        MessageShow.ShowMessage("DelYes");
        //        MessageShow.Visible = true;
        //    }
        //    else
        //    {
        //        MessageShow.ShowMessage("DelNo");
        //        MessageShow.Visible = true;
        //    }
        //}


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
            string url="https://etherscan.io/tx/" + txhash;
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
            DataTable table = action.ETHSearchTx(orderid.Replace("'", ""));
            if (table.Rows[0]["Status"].ToString() == "0")
            {
                action.NECChangeOperateStatus(2, orderid.Replace("'", ""));
                string memloginid = table.Rows[0]["MemloginID"].ToString();
                string ETH = table.Rows[0]["ETH"].ToString();
                member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_hv(memloginid, Convert.ToDecimal(ETH), "提现审核未通过");
                member_Action.PreTransfer_GZ(orderid.Replace("'", ""), ETH.ToString(), "提现审核未通过", memloginid, memloginid, "18");


                //string LabelMemLoginIDValue = table.Rows[0]["MemLoginID"].ToString(); ;
                //string LabelOperateMoneyValue = table.Rows[0]["OperateMoney"].ToString();
                //string LabelMemLoginRealNameValue = table.Rows[0]["RealName"].ToString();
                //string LabelCurrentAdvancePaymentValue = table.Rows[0]["CurrentAdvancePayment"].ToString();
                //string LabelDateValue = table.Rows[0]["Date"].ToString();
                //string HiddenFieldOperateTypeValue = table.Rows[0]["OperateType"].ToString();

                //decimal num = 0M;
                //string str = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  AND  MemLoginID='" + LabelMemLoginIDValue + "'");
                //if (!string.IsNullOrEmpty(str))
                //{
                //    num = Convert.ToDecimal(str);
                //}
                //var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                //{
                //    Guid = Guid.NewGuid(),
                //    OperateType = 5,
                //    CurrentAdvancePayment = num,
                //    OperateMoney = Convert.ToDecimal(LabelOperateMoneyValue),
                //    LastOperateMoney = num + Convert.ToDecimal(LabelOperateMoneyValue),
                //    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                //    Memo = "系统拒绝会员提现申请，返回金币（BV）￥" + LabelOperateMoneyValue.Trim(),
                //    MemLoginID = LabelMemLoginIDValue,
                //    CreateUser = base.ShopNum1LoginID,
                //    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                //    IsDeleted = 0
                //};
                //((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(advancePaymentModifyLog);
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
                        PageName = "AdvancePaymentApplyLog_ListETH_Cz.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "19");
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

        public string NECCZChangeOperateStatus(string operateStatus)
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
            
            string str2 = TextBoxSMemLoginID.Text;
            string selectedValue1 = DropdownList1.SelectedValue;
            string selectedValue = DropdownListSOperateStatus.SelectedValue;
            string str4 = TextBoxSDate1.Text;
            string str5 = TextBoxSDate2.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            
            cookie.Values.Add("Bizhong", selectedValue1);
            cookie.Values.Add("MemLoginID", str2);
            cookie.Values.Add("State", selectedValue);
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            return cookie;
        }
    }
}