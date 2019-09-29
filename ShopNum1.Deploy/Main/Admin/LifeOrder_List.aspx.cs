using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class LifeOrder_List : PageBase, IRequiresSessionState
    {
        protected const string Order_Operate = "Order_Operate.aspx";
        protected const string OrderList_Report = "OrderList_Report.aspx";
        public int PageSize = 10;
        private string string_4 = string.Empty;
        public DataTable dt_OrderList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (this.Page.Request.QueryString["oderstatus"] != null)
            {
                this.DropDownListOderStatus.SelectedValue = this.Page.Request.QueryString["oderstatus"].ToString();
            }
            if (this.Page.Request.QueryString["paymentstate"] != null)
            {
                this.DropDownListPaymentState.SelectedValue = this.Page.Request.QueryString["paymentstate"].ToString();
            }
            if (this.Page.Request.QueryString["shipmentstate"] != null)
            {
                this.DropDownListShipmentState.SelectedValue = this.Page.Request.QueryString["shipmentstate"].ToString();
            }
            if (this.Page.Request.QueryString["type"] != null)
            {
                this.DropDownListType.SelectedValue = this.Page.Request.QueryString["type"].ToString();
            }
            string text = (this.Page.Request.QueryString["style"] == null) ? "1" : this.Page.Request.QueryString["style"].ToString();
            string text2 = text;
            switch (text2)
            {
                case "1":
                    this.method_6(this.LinkButtonAll);
                    break;
                case "2":
                    this.method_6(this.LinkButtonNopayment);
                    break;
                case "3":
                    this.method_6(this.LinkButtonPayment);
                    break;
                case "4":
                    this.method_6(this.LinkButtonSend);
                    break;
                case "5":
                    this.method_6(this.LinkButtonComplete);
                    break;
                case "6":
                    this.method_6(this.LinkButtonRefund);
                    break;
                case "7":
                    this.method_6(this.LinkButtonReturnGoods);
                    break;
                case "8":
                    this.method_6(this.LinkButtonCancel);
                    break;
            }
            if (ShopNum1.Common.Common.ReqStr("pagesize") != "")
            {
                this.PageSize = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pagesize"));
            }
            this.BindDropDownListOderStatus();
            this.BindGrid(this.method_5());
        }
        private string method_5()
        {
            string text = ShopNum1.Common.Common.ReqStr("trdeid");
            string text2 = ShopNum1.Common.Common.ReqStr("orid");
            string text3 = ShopNum1.Common.Common.ReqStr("mid");
            string text4 = ShopNum1.Common.Common.ReqStr("ct");
            string text5 = ShopNum1.Common.Common.ReqStr("et");
            string text6 = ShopNum1.Common.Common.ReqStr("sp1");
            string text7 = ShopNum1.Common.Common.ReqStr("sp2");
            string text8 = ShopNum1.Common.Common.ReqStr("shopid");
            string text9 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("sn"));
            string text10 = ShopNum1.Common.Common.ReqStr("status");
            this.TextBoxCreateTime1.Text = text4;
            this.TextBoxCreateTime2.Text = text5;
            string text11 = string.Empty;
            text11 += " and feetype=2 ";
            if (Operator.FormatToEmpty(text) != string.Empty)
            {
                text11 = text11 + " AND tradeid LIKE '%" + text + "%'";
            }
            if (Operator.FormatToEmpty(text2) != string.Empty)
            {
                text11 = text11 + " AND OrderNumber LIKE '%" + text2 + "%'";
            }
            if (Operator.FormatToEmpty(text3) != string.Empty)
            {
                text11 = text11 + " AND MemLoginID LIKE '%" + Operator.FilterString(text3) + "%'";
            }
            if (Operator.FormatToEmpty(text4) != string.Empty)
            {
                text11 = text11 + " AND CreateTime>='" + text4 + "' ";
            }
            if (Operator.FormatToEmpty(text5) != string.Empty)
            {
                text11 = text11 + " AND CreateTime<='" + text5 + "' ";
            }
            if (Operator.FormatToEmpty(text6) != string.Empty)
            {
                text11 = text11 + " AND ShouldPayPrice>='" + text6 + "' ";
            }
            if (Operator.FormatToEmpty(text7) != string.Empty)
            {
                text11 = text11 + " AND ShouldPayPrice<='" + text7 + "' ";
            }
            if (Operator.FormatToEmpty(text8) != string.Empty)
            {
                text11 = text11 + " AND ShopID  Like '%" + text8 + "%' ";
            }
            if (Operator.FormatToEmpty(text9) != string.Empty)
            {
                text11 = text11 + " AND ShopName  Like '%" + text9 + "%' ";
            }
            if (Operator.FormatToEmpty(text10) != string.Empty)
            {
                text11 = text11 + " and oderstatus= " + text10;
            }
            return text11;
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.DropDownListType.SelectedValue = "0";
            this.BindGrid(this.method_5());
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_Operate.aspx?guid=" + this.CheckGuid.Value.Replace("'", ""));
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            int num = shopNum1_OrderInfo_Action.Delete(this.CheckGuid.Value);
            if (num > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record = "管理员删除生活服务订单";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "LifeOrder_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
                this.BindGrid(this.method_5());
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }
        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            LinkButton linkButton = (LinkButton)sender;
            string commandArgument = linkButton.CommandArgument;
            int num = shopNum1_OrderInfo_Action.Delete("'" + commandArgument + "'");
            if (num > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record = "管理员删除生活服务订单";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "LifeOrder_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
                this.BindGrid(this.method_5());
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }
        protected void BindGrid(string strcondition)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string text = base.Request.RawUrl;
            if (text.IndexOf("?") != -1)
            {
                text = text.Split(new char[]
			{
				'?'
			})[0];
            }
            this.string_4 = ShopNum1.Common.Common.ReqStr("PageID");
            if (this.string_4 == "")
            {
                this.string_4 = "1";
            }
            DataTable dataTable = shopNum1_OrderInfo_Action.SelectList(this.PageSize.ToString(), this.string_4, strcondition, "0", "CreateTime", "desc");
            PageList1 pageList = new PageList1();
            pageList.PageSize = this.PageSize;
            pageList.PageID = Convert.ToInt32(this.string_4.ToString());
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            else
            {
                pageList.RecordCount = 0;
            }
            pageList.PageCount = pageList.RecordCount / pageList.PageSize;
            if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
            {
                pageList.PageCount++;
            }
            if (pageList.PageID > pageList.PageCount)
            {
                pageList.PageID = pageList.PageCount;
            }
            if (pageList.PageSize > pageList.RecordCount || pageList.PageCount == 1)
            {
                this.showPage.Visible = false;
            }
            else
            {
                this.showPage.Visible = true;
            }
            PageListBll pageListBll = new PageListBll(text, true);
            this.pageDiv.InnerHtml = pageListBll.GetPageListNewManage(pageList);
            this.dt_OrderList = shopNum1_OrderInfo_Action.SelectList(this.PageSize.ToString(), this.string_4, strcondition, "1", "CreateTime", "desc");
            if (this.dt_OrderList.Rows.Count == 0)
            {
                this.dt_OrderList = null;
            }
        }
        protected void BindDropDownListOderStatus()
        {
            ListItem listItem = new ListItem();
            listItem.Text = "-全部-";
            listItem.Value = "-1";
            this.DropDownListOderStatus.Items.Add(listItem);
            ListItem listItem2 = new ListItem();
            listItem2.Text = "等待买家付款";
            listItem2.Value = "0";
            this.DropDownListOderStatus.Items.Add(listItem2);
            ListItem listItem3 = new ListItem();
            listItem3.Text = "等待买家消费";
            listItem3.Value = "1";
            this.DropDownListOderStatus.Items.Add(listItem3);
            ListItem listItem4 = new ListItem();
            listItem4.Text = "等待卖家确认";
            listItem4.Value = "2";
            this.DropDownListOderStatus.Items.Add(listItem4);
            ListItem listItem5 = new ListItem();
            listItem5.Text = "交易成功";
            listItem5.Value = "3";
            this.DropDownListOderStatus.Items.Add(listItem5);
            ListItem listItem6 = new ListItem();
            listItem6.Text = "系统关闭订单";
            listItem6.Value = "4";
            this.DropDownListOderStatus.Items.Add(listItem6);
            ListItem listItem7 = new ListItem();
            listItem7.Text = "卖家关闭订单";
            listItem7.Value = "5";
            this.DropDownListOderStatus.Items.Add(listItem7);
            ListItem listItem8 = new ListItem();
            listItem8.Text = "买家关闭订单";
            listItem8.Value = "6";
            this.DropDownListOderStatus.Items.Add(listItem8);
        }
        public string ChangeOderStatus(string oderStatus)
        {
            string result;
            switch (oderStatus)
            {
                case "0":
                    result = "等待买家付款";
                    return result;
                case "1":
                    result = "等待买家消费";
                    return result;
                case "2":
                    result = "等待卖家确认";
                    return result;
                case "3":
                    result = "交易成功";
                    return result;
                case "4":
                    result = "系统关闭订单";
                    return result;
                case "5":
                    result = "卖家关闭订单";
                    return result;
                case "6":
                    result = "买家关闭订单";
                    return result;
            }
            result = "非法状态";
            return result;
        }
        protected void ButtonReportx_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record = "导出生活服务订单数据";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "LifeOrder_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
                HttpCookie httpCookie = this.method_7();
                httpCookie.Values.Add("PageCheck", "1");
                httpCookie.Values.Add("Guids", "-1");
                httpCookie.Values.Add("Condition", this.method_5());
                HttpCookie cookie1 = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie1);
                base.Response.Redirect("OrderList_Report.aspx?Type=xls");
            }
        }
        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();

                shopNum1_OperateLog.Record = "导出生活服务订单数据";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "LifeOrder_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);

                HttpCookie httpCookie = this.method_7();
                httpCookie.Values.Add("PageCheck", "1");
                httpCookie.Values.Add("Guids", this.CheckGuid.Value);
                httpCookie.Values.Add("Condition", this.method_5());
                HttpCookie cookie1 = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie1);
                base.Response.Redirect("OrderList_Report.aspx?Type=xls");
                this.CheckGuid.Value = "0";
            }
        }
        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            string text = ShopNum1.Common.Common.ReqStr("trdeid");
            string text2 = ShopNum1.Common.Common.ReqStr("orid");
            string text3 = ShopNum1.Common.Common.ReqStr("mid");
            string text4 = ShopNum1.Common.Common.ReqStr("ct");
            string text5 = ShopNum1.Common.Common.ReqStr("et");
            string text6 = ShopNum1.Common.Common.ReqStr("sp1");
            string text7 = ShopNum1.Common.Common.ReqStr("sp2");
            string text8 = ShopNum1.Common.Common.ReqStr("shopid");
            string text9 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("sn"));
            ShopNum1.Common.Common.ReqStr("status");
            base.Response.Redirect(string.Concat(new object[]
		{
			"LifeOrder_List.aspx?style=1&tradeid=",
			text,
			"&orid=",
			text2,
			"&mid=",
			text3,
			"&ct=",
			text4,
			"&et=",
			text5,
			"&sp1=",
			text6,
			"&sp2=",
			text7,
			"&shopid=",
			text8,
			"&sn=",
			text9,
			"&pagesize=",
			this.PageSize
		}));
        }
        protected void LinkButtonPayment_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=3&status=1");
        }
        protected void LinkButtonNopayment_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=2&status=0");
        }
        protected void LinkButtonSend_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=4&status=2");
        }
        protected void LinkButtonComplete_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=5&status=3");
        }
        protected void LinkButtonRefund_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=6&status=6");
        }
        protected void LinkButtonReturnGoods_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=7&status=5");
        }
        protected void LinkButtonCanel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LifeOrder_List.aspx?style=8&status=4");
        }
        protected void ClearControl()
        {
            this.DropDownListOderStatus.SelectedValue = "-1";
            this.DropDownListPaymentState.SelectedValue = "-1";
            this.DropDownListShipmentState.SelectedValue = "-1";
        }
        private void method_6(LinkButton linkButton_0)
        {
            this.LinkButtonAll.CssClass = "";
            this.LinkButtonNopayment.CssClass = "";
            this.LinkButtonPayment.CssClass = "";
            this.LinkButtonSend.CssClass = "";
            this.LinkButtonComplete.CssClass = "";
            this.LinkButtonRefund.CssClass = "";
            this.LinkButtonReturnGoods.CssClass = "";
            this.LinkButtonCancel.CssClass = "";
            linkButton_0.CssClass = "cur";
        }
        private HttpCookie method_7()
        {
            ShopNum1.Common.Common.ReqStr("trdeid");
            string value = ShopNum1.Common.Common.ReqStr("orid");
            string value2 = ShopNum1.Common.Common.ReqStr("mid");
            string value3 = ShopNum1.Common.Common.ReqStr("ct");
            string value4 = ShopNum1.Common.Common.ReqStr("et");
            string value5 = ShopNum1.Common.Common.ReqStr("sp1");
            string value6 = ShopNum1.Common.Common.ReqStr("sp2");
            string value7 = ShopNum1.Common.Common.ReqStr("shopid");
            string value8 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("sn"));
            string value9 = ShopNum1.Common.Common.ReqStr("status");
            return new HttpCookie("OrderListReportCookie")
            {
                Values = 
			{
				
				{
					"OrderNumber",
					value
				},
				
				{
					"MemLoginID",
					value2
				},
				
				{
					"Address",
					""
				},
				
				{
					"Postalcode",
					""
				},
				
				{
					"Mobile",
					""
				},
				
				{
					"Email",
					""
				},
				
				{
					"Tel",
					""
				},
				
				{
					"Name",
					""
				},
				
				{
					"ShouldPayPrice1",
					value5
				},
				
				{
					"ShouldPayPrice2",
					value6
				},
				
				{
					"CreateTime1",
					value3
				},
				
				{
					"CreateTime2",
					value4
				},
				
				{
					"ShopID",
					value7
				},
				
				{
					"ShopName",
					value8
				},
				
				{
					"OrderType",
					"-2"
				},
				
				{
					"orderStatus",
					value9
				}
			}
            };
        }
        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                HttpCookie httpCookie = this.method_7();
                if (this.RadioButtonListOutPage.SelectedValue == "0")
                {
                    httpCookie.Values.Add("PageCheck", "1");
                    httpCookie.Values.Add("Guids", this.CheckGuid.Value);
                    httpCookie.Values.Add("Condition", this.method_5());
                }
                else
                {
                    httpCookie.Values.Add("PageCheck", "0");
                    httpCookie.Values.Add("Guids", "0");
                    httpCookie.Values.Add("Condition", this.method_5());
                }
                HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie);
                base.Response.Redirect("OrderList_Report.aspx?Type=html");
            }
        }
        public string ChangeOrderType(object IsPanicBuy, object isSpellBuy)
        {
            string result;
            if (IsPanicBuy.ToString() == "1")
            {
                result = "抢购订单";
            }
            else
            {
                if (isSpellBuy.ToString() == "1")
                {
                    result = "团购订单";
                }
                else
                {
                    if (IsPanicBuy.ToString() == "0" && isSpellBuy.ToString() == "0")
                    {
                        result = "普通订单";
                    }
                    else
                    {
                        result = "非法订单";
                    }
                }
            }
            return result;
        }
    }
}