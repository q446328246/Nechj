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
    public partial class Order_List : PageBase, IRequiresSessionState
    {
        protected const string Order_Operate = "Order_Operate.aspx";
        protected const string OrderList_Report = "OrderList_Report.aspx";
        private int int_0 = 10;
        private string string_4 = string.Empty;
        public DataTable dt_OrderList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            //if (!IsPostBack)
            //{
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
                    this.int_0 = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pagesize"));
                }
                this.BindDropDownListOderStatus();
                this.BindGrid(this.method_5());
                
            //}
            
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
            string text12 = ShopNum1.Common.Common.ReqStr("cpt");
            string text13 = ShopNum1.Common.Common.ReqStr("ept");
            string text14 = ShopNum1.Common.Common.ReqStr("superior");
            if (text10=="")
            {
                text10 = ShopNum1.Common.Common.ReqStr("dll1");
                
            }
            string text112 = ShopNum1.Common.Common.ReqStr("dll");
            this.TextBoxCreateTime1.Text = text4;
            this.TextBoxCreateTime2.Text = text5;
            this.TextBoxPayTime1.Text = text12;
            this.TextBoxPayTime2.Text = text13;
            string text11 = string.Empty;
            if (Operator.FormatToEmpty(text) != string.Empty)
            {
                text11 = text11 + " AND c.tradeid LIKE '%" + text + "%'";
            }
            if (Operator.FormatToEmpty(text2) != string.Empty)
            {
                text11 = text11 + " AND c.OrderNumber LIKE '%" + text2 + "%'";
            }
            if (Operator.FormatToEmpty(text3) != string.Empty)
            {
                text11 = text11 + " AND c.MemLoginID LIKE '%" + Operator.FilterString(text3) + "%'";
            }
            if (Operator.FormatToEmpty(text4) != string.Empty)
            {
                text11 = text11 + " AND c.CreateTime>='" + Convert.ToDateTime(text4) + "' ";
            }
            if (Operator.FormatToEmpty(text5) != string.Empty)
            {
                text11 = text11 + " AND c.CreateTime<='" + Convert.ToDateTime(text5) + "' ";
            }
            if (Operator.FormatToEmpty(text6) != string.Empty)
            {
                text11 = text11 + " AND c.ShouldPayPrice>='" + text6 + "' ";
            }
            if (Operator.FormatToEmpty(text7) != string.Empty)
            {
                text11 = text11 + " AND c.ShouldPayPrice<='" + text7 + "' ";
            }
            if (Operator.FormatToEmpty(text8) != string.Empty)
            {
                text11 = text11 + " AND c.ShopID  Like '%" + text8 + "%' ";
            }
            if (Operator.FormatToEmpty(text9) != string.Empty)
            {
                text11 = text11 + " AND c.ShopName  Like '%" + text9 + "%' ";
            }
            if (Operator.FormatToEmpty(text10) != string.Empty)
            {
                if (text10=="422")
                {
                    text11 = text11 + " and c.oderstatus in (1,2,3)";
                }
                else
                {
                    text11 = text11 + " and c.oderstatus= " + text10;
                }
               
            }
            if ((Operator.FormatToEmpty(text112)!= string.Empty&&(Operator.FormatToEmpty(text112)!="-1")))
            {
                text11 = text11 + " and c.shop_category_id= " + text112 + "";
            }
            if (Operator.FormatToEmpty(text12) != string.Empty)
            {
                text11 = text11 + " AND c.PayTime>='" + Convert.ToDateTime(text12) + "' ";
            }
            if (Operator.FormatToEmpty(text13) != string.Empty)
            {
                text11 = text11 + " AND c.PayTime<='" + Convert.ToDateTime(text13) + "' ";
            }
            if (Operator.FormatToEmpty(text14) != string.Empty)
            {
                text11 = text11 + "AND c.MemLoginID in (select MemLoginID from ShopNum1_Member where Superior='"+text14+"') ";
            }
            return text11;
        }

        private string method_8()
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
            if (text10 == "")
            {
                text10 = ShopNum1.Common.Common.ReqStr("dll1");

            }
            string text12 = ShopNum1.Common.Common.ReqStr("cpt");
            string text13 = ShopNum1.Common.Common.ReqStr("ept");
            string text112 = ShopNum1.Common.Common.ReqStr("dll");
            this.TextBoxCreateTime1.Text = text4;
            this.TextBoxCreateTime2.Text = text5;
            this.TextBoxPayTime1.Text = text12;
            this.TextBoxPayTime2.Text = text13;

            string text11 = string.Empty;
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
                text11 = text11 + " AND CreateTime>='" + Convert.ToDateTime(text4) + "' ";
            }
            if (Operator.FormatToEmpty(text5) != string.Empty)
            {
                text11 = text11 + " AND CreateTime<='" + Convert.ToDateTime(text5) + "' ";
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
                if (text10 == "422")
                {
                    text11 = text11 + " and oderstatus in (1,2,3)";
                }
                else
                {
                    text11 = text11 + " and oderstatus= " + text10;
                }

            }
            if ((Operator.FormatToEmpty(text112) != string.Empty && (Operator.FormatToEmpty(text112) != "-1")))
            {
                text11 = text11 + " and shop_category_id= " + text112 + "";
            }

            if (Operator.FormatToEmpty(text12) != string.Empty)
            {
                text11 = text11 + " AND PayTime>='" + Convert.ToDateTime(text12) + "' ";
            }
            if (Operator.FormatToEmpty(text13) != string.Empty)
            {
                text11 = text11 + " AND PayTime<='" + Convert.ToDateTime(text13) + "' ";
            }

            return text11;
        }

        private string method_9()
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
            if (text10 == "")
            {
                text10 = ShopNum1.Common.Common.ReqStr("dll1");

            }
            string text12 = ShopNum1.Common.Common.ReqStr("cpt");
            string text13 = ShopNum1.Common.Common.ReqStr("ept");
            string text112 = ShopNum1.Common.Common.ReqStr("dll");
            this.TextBoxCreateTime1.Text = text4;
            this.TextBoxCreateTime2.Text = text5;
            this.TextBoxPayTime1.Text = text12;
            this.TextBoxPayTime2.Text = text13;

            string text11 = string.Empty;
            if (Operator.FormatToEmpty(text) != string.Empty)
            {
                text11 = text11 + " AND soi.tradeid LIKE '%" + text + "%'";
            }
            if (Operator.FormatToEmpty(text2) != string.Empty)
            {
                text11 = text11 + " AND soi.OrderNumber LIKE '%" + text2 + "%'";
            }
            if (Operator.FormatToEmpty(text3) != string.Empty)
            {
                text11 = text11 + " AND soi.MemLoginID LIKE '%" + Operator.FilterString(text3) + "%'";
            }
            if (Operator.FormatToEmpty(text4) != string.Empty)
            {
                text11 = text11 + " AND soi.CreateTime>='" + Convert.ToDateTime(text4) + "' ";
            }
            if (Operator.FormatToEmpty(text5) != string.Empty)
            {
                text11 = text11 + " AND soi.CreateTime<='" + Convert.ToDateTime(text5) + "' ";
            }
            if (Operator.FormatToEmpty(text6) != string.Empty)
            {
                text11 = text11 + " AND soi.ShouldPayPrice>='" + text6 + "' ";
            }
            if (Operator.FormatToEmpty(text7) != string.Empty)
            {
                text11 = text11 + " AND soi.ShouldPayPrice<='" + text7 + "' ";
            }
            if (Operator.FormatToEmpty(text8) != string.Empty)
            {
                text11 = text11 + " AND soi.ShopID  Like '%" + text8 + "%' ";
            }
            if (Operator.FormatToEmpty(text9) != string.Empty)
            {
                text11 = text11 + " AND soi.ShopName  Like '%" + text9 + "%' ";
            }
            if (Operator.FormatToEmpty(text10) != string.Empty)
            {
                if (text10 == "422")
                {
                    text11 = text11 + " and soi.oderstatus in (1,2,3)";
                }
                else
                {
                    text11 = text11 + " and soi.oderstatus= " + text10;
                }

            }
            if ((Operator.FormatToEmpty(text112) != string.Empty && (Operator.FormatToEmpty(text112) != "-1")))
            {
                text11 = text11 + " and shop_category_id= " + text112 + "";
            }

            if (Operator.FormatToEmpty(text12) != string.Empty)
            {
                text11 = text11 + " AND PayTime>='" + Convert.ToDateTime(text12) + "' ";
            }
            if (Operator.FormatToEmpty(text13) != string.Empty)
            {
                text11 = text11 + " AND PayTime<='" + Convert.ToDateTime(text13) + "' ";
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
                
                shopNum1_OperateLog.Record="����Աɾ������";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Order_List.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                
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
                
                shopNum1_OperateLog.Record="����Աɾ������";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Order_List.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                
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
            DataTable dataTable = shopNum1_OrderInfo_Action.SelectList_order(this.int_0.ToString(), this.string_4, strcondition, "0", "CreateTime", "desc");
            PageList1 pageList = new PageList1();
            pageList.PageSize = this.int_0;
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
            this.dt_OrderList = shopNum1_OrderInfo_Action.SelectList_order(this.int_0.ToString(), this.string_4, strcondition, "1", "CreateTime", "desc");
            if (this.dt_OrderList.Rows.Count == 0)
            {
                this.dt_OrderList = null;
            }
        }
        protected void BindDropDownListOderStatus()
        {
            ListItem listItem = new ListItem();
            listItem.Text = "-ȫ��-";
            listItem.Value = "-1";
            this.DropDownListOderStatus.Items.Add(listItem);
            ListItem listItem2 = new ListItem();
            listItem2.Text = "�ȴ���Ҹ���";
            listItem2.Value = "0";
            this.DropDownListOderStatus.Items.Add(listItem2);
            ListItem listItem3 = new ListItem();
            listItem3.Text = "�ȴ����ҷ���";
            listItem3.Value = "1";
            this.DropDownListOderStatus.Items.Add(listItem3);
            ListItem listItem4 = new ListItem();
            listItem4.Text = "�ȴ����ȷ���ջ�";
            listItem4.Value = "2";
            this.DropDownListOderStatus.Items.Add(listItem4);
            ListItem listItem5 = new ListItem();
            listItem5.Text = "���׳ɹ�";
            listItem5.Value = "3";
            this.DropDownListOderStatus.Items.Add(listItem5);
            ListItem listItem6 = new ListItem();
            listItem6.Text = "ϵͳ�رն���";
            listItem6.Value = "4";
            this.DropDownListOderStatus.Items.Add(listItem6);
            ListItem listItem7 = new ListItem();
            listItem7.Text = "���ҹرն���";
            listItem7.Value = "5";
            this.DropDownListOderStatus.Items.Add(listItem7);
            ListItem listItem8 = new ListItem();
            listItem8.Text = "��ҹرն���";
            listItem8.Value = "6";
            this.DropDownListOderStatus.Items.Add(listItem8);
        }
        public string ChangeOderStatus(string oderStatus, string feeType)
        {
            string result;
            switch (oderStatus)
            {
                case "0":
                    result = "�ȴ���Ҹ���";
                    return result;
                case "1":
                    if (feeType == "2")
                    {
                        result = "�ȴ��������";
                        return result;
                    }
                    result = "�ȴ����ҷ���";
                    return result;
                case "2":
                    if (feeType == "2")
                    {
                        result = "�ȴ�����ȷ��";
                        return result;
                    }
                    result = "�ȴ����ȷ���ջ�";
                    return result;
                case "3":
                    result = "���׳ɹ�";
                    return result;
                case "4":
                    result = "ϵͳ�رն���";
                    return result;
                case "5":
                    result = "���ҹرն���";
                    return result;
                case "6":
                    result = "��ҹرն���";
                    return result;
            }
            result = "�Ƿ�״̬";
            return result;
        }
        public string GetOrderTypeImg(string strOderType)
        {
            string result;
            switch (strOderType)
            {
                case "1":
                    result = "<img src=\"images/icon_tg.png\" alt=\"�Ź��\" />";
                    return result;
                case "2":
                    result = "<img src=\"images/icon_zk.png\" alt=\"��ʱ�ۿ�\" />";
                    return result;
                case "3":
                    result = "<img src=\"images/icon_zh.png\" alt=\"����ײ�\" />";
                    return result;
                case "4":
                    result = "<img src=\"images/icon_qg.png\" alt=\"�����\" />";
                    return result;
                case "5":
                    result = "<img src=\"images/icon_qg.png\" alt=\"�����\" />";
                    return result;
                case "8":
                    result = "�ֻ��ͻ���";
                    return result;
                case "9":
                    result = "wapվ";
                    return result;
                case "10":
                    result = "΢���̳�";
                    return result;
            }
            result = "��ͨ����";
            return result;
        }
        protected void ButtonReportx_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("��ǰ�޵����ļ�¼��");
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                  
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                
                shopNum1_OperateLog.Record="������������";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Order_List.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
            
                HttpCookie httpCookie = this.method_7();
                httpCookie.Values.Add("PageCheck", "1");
                httpCookie.Values.Add("Guids", "-1");
                httpCookie.Values.Add("Condition", this.method_5());
                httpCookie.Values.Add("Reportx_State", "1");
                HttpCookie cookie1 = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie1);
                base.Response.Redirect("OrderList_Report.aspx?Type=xls");
            }
        }
        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("��ǰ�޵����ļ�¼��");
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                
                shopNum1_OperateLog.Record="������������";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Order_List.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
              
                HttpCookie httpCookie = this.method_7();
                httpCookie.Values.Add("PageCheck", "1");
                httpCookie.Values.Add("Guids", this.CheckGuid.Value);
                httpCookie.Values.Add("Condition", this.method_5());
                httpCookie.Values.Add("Reportx_State", "2");
                HttpCookie cookie1 = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie1);
                base.Response.Redirect("OrderList_Report.aspx?Type=xls");
                this.CheckGuid.Value = "0";
            }
        }

        protected void ButtonReportFinance_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("��ǰ�޵����ļ�¼��");
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();

                shopNum1_OperateLog.Record = "�������񶩵�����";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "Order_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);

                HttpCookie httpCookie = this.method_7();
                httpCookie.Values.Add("PageCheck", "1");
                httpCookie.Values.Add("Guids", "-1");
                httpCookie.Values.Add("Condition", this.method_9());
                httpCookie.Values.Add("Reportx_State", "3");
                HttpCookie cookie1 = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie1);
                base.Response.Redirect("OrderList_Report.aspx?Type=xls");
            }
        }


        protected void ButtonReportFinanceTK_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("��ǰ�޵����ļ�¼��");
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();

                shopNum1_OperateLog.Record = "�������񶩵�����";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "Order_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);

                HttpCookie httpCookie = this.method_7();
                httpCookie.Values.Add("PageCheck", "1");
                httpCookie.Values.Add("Guids", "-1");
                httpCookie.Values.Add("Condition", this.method_9());
                httpCookie.Values.Add("Reportx_State", "4");
                HttpCookie cookie1 = HttpSecureCookie.Encode(httpCookie);
                base.Response.AppendCookie(cookie1);
                base.Response.Redirect("OrderList_Report.aspx?Type=xls");
            }
        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=1");
        }
        protected void LinkButtonPayment_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=3&status=1");
        }
        protected void LinkButtonNopayment_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=2&status=0");
        }
        protected void LinkButtonSend_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=4&status=2");
        }
        protected void LinkButtonComplete_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=5&status=3");
        }
        protected void LinkButtonRefund_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=6&status=6");
        }
        protected void LinkButtonReturnGoods_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=7&status=5");
        }
        protected void LinkButtonCanel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Order_List.aspx?style=8&status=4");
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
            string value10 = ShopNum1.Common.Common.ReqStr("cpt");
            string value11 = ShopNum1.Common.Common.ReqStr("ept");
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
					"-1"
				},
				
				{
					"orderStatus",
					value9
				},
                {
					"PayTime1",
					value10
				},
				
				{
					"PayTime2",
					value11
				}
			}
            };
        }
        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            if (this.dt_OrderList.Rows.Count < 1)
            {
                MessageBox.Show("��ǰ�޵����ļ�¼��");
            }
            else
            {
                HttpCookie httpCookie = this.method_7();
                if (this.RadioButtonListOutPage.SelectedValue == "0")
                {
                    httpCookie.Values.Add("PageCheck", "1");
                    httpCookie.Values.Add("Guids", this.CheckGuid.Value);
                }
                else
                {
                    httpCookie.Values.Add("PageCheck", "0");
                    httpCookie.Values.Add("Guids", "0");
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
                result = "��������";
            }
            else
            {
                if (isSpellBuy.ToString() == "1")
                {
                    result = "�Ź�����";
                }
                else
                {
                    if (IsPanicBuy.ToString() == "0" && isSpellBuy.ToString() == "0")
                    {
                        result = "��ͨ����";
                    }
                    else
                    {
                        result = "�Ƿ�����";
                    }
                }
            }
            return result;
        }

        
    }
}