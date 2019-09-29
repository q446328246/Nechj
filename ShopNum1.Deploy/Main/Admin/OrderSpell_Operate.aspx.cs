using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderSpell_Operate : PageBase, IRequiresSessionState
    {
        protected const string Order_List = "Order_List.aspx";
        protected const string Order_Operate_10 = "Order_Operate_10.aspx";
        protected const string Order_Operate_2 = "Order_Operate_2.aspx";
        protected const string Order_Operate_4 = "Order_Operate_4.aspx";
        protected const string Order_Operate_5 = "Order_Operate_5.aspx";
        protected const string Order_Operate_6 = "Order_Operate_6.aspx";
        protected const string Order_Operate_8 = "Order_Operate_8.aspx";
        protected const string Order_Operate_9 = "Order_Operate_9.aspx";
        protected const string OrderInfo_Report = "OrderInfo_Report.aspx";
        private readonly string string_11 = string.Empty;
        private string string_10 = string.Empty;

        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;
        public string OrganizGuid { get; set; }

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state)
        {
            return new ShopNum1_EmailGroupSend
                {
                    Guid = Guid.NewGuid(),
                    EmailTitle = string_11,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    EmailGuid = new Guid("7C367402-4219-46B7-BC48-72CF48F6A836"),
                    SendObjectEmail = email,
                    SendObject = memLoginID + "-" + email,
                    State = state
                };
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrderInfo_Report.aspx?OrderNumber=" + LabelOrderNumberValue.Text);
        }

        public string ChangeOderStatus(string oderStatus)
        {
            if (oderStatus == "0")
            {
                return "等待买家付款";
            }
            if (oderStatus == "1")
            {
                return "等待卖家发货";
            }
            if (oderStatus == "2")
            {
                return "等待买家确认收货";
            }
            if (oderStatus == "3")
            {
                return "交易成功";
            }
            if (oderStatus == "4")
            {
                return "系统关闭订单";
            }
            if (oderStatus == "5")
            {
                return "卖家关闭订单";
            }
            if (oderStatus == "6")
            {
                return "买家关闭订单";
            }
            return "非法状态";
        }

        public string ChangePaymentStatus(string paymentStatus)
        {
            if (paymentStatus == "0")
            {
                return "未付款";
            }
            if (paymentStatus == "1")
            {
                return "已付款";
            }
            if (paymentStatus == "2")
            {
                return "退款成功";
            }
            if (paymentStatus == "3")
            {
                return "卖家拒绝退款";
            }
            return "非法状态";
        }

        public string ChangeShipmentStatus(string shipmentStatus)
        {
            if (shipmentStatus == "0")
            {
                return "未发货";
            }
            if (shipmentStatus == "1")
            {
                return "已发货";
            }
            if (shipmentStatus == "2")
            {
                return "已收货";
            }
            if (shipmentStatus == "3")
            {
                return "退货";
            }
            return "非法状态";
        }

        protected int CheckMember()
        {
            int num = 0;
            try
            {
                var guid = new Guid(LabelMemLoginIDValue.Text);
            }
            catch
            {
                num = 1;
            }
            return num;
        }

        protected void GetAllProductWeight()
        {
            DataTable orderProductGuidAndByNumber =
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action())
                    .GetOrderProductGuidAndByNumber(LabelOrderNumberValue.Text);
            var action2 = (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
            HiddenFieldAllWeight.Value = "0.00";
            for (int i = 0; i < orderProductGuidAndByNumber.Rows.Count; i++)
            {
                string guid = orderProductGuidAndByNumber.Rows[i]["ProductGuid"].ToString();
                string str2 = orderProductGuidAndByNumber.Rows[i]["BuyNumber"].ToString();
                string weight = action2.GetWeight(guid);
                HiddenFieldAllWeight.Value =
                    Convert.ToString((Convert.ToDecimal(HiddenFieldAllWeight.Value) +
                                      (Convert.ToDecimal(str2)*Convert.ToDecimal(weight))));
            }
        }

        protected void GetEmailSetting()
        {
            var settings = new ShopSettings();
            string_4 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailServer"));
            string_5 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
            string_7 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "ServerPort"));
            string_6 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailAccount"));
            string_8 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailPassword"));
            string_9 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "RestoreEmail"));
            string_10 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailCode"));
        }

        protected void GetOrderInfo()
        {
            DataTable table =
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).Search(
                    hiddenFieldGuid.Value);
            LabelOrderNumberValue.Text = table.Rows[0]["OrderNumber"].ToString();
            string str = string.Empty;
            str = ChangeOderStatus(table.Rows[0]["OderStatus"].ToString());
            LabelOderStatusValue.Text = str;
            LabelCreateTimeValue.Text = table.Rows[0]["CreateTime"].ToString();
            LabelPaymentNameValue.Text = table.Rows[0]["PaymentName"].ToString();
            LabelPayTimeValue.Text = table.Rows[0]["PayTime"].ToString();
            if (table.Rows[0]["DispatchType"].ToString() == "1")
            {
                LabelDispatchModeNameValue.Text = "平邮";
            }
            else if (table.Rows[0]["DispatchType"].ToString() == "2")
            {
                LabelDispatchModeNameValue.Text = "快递";
            }
            else
            {
                LabelDispatchModeNameValue.Text = "Ems";
            }
            LabelDispatchTimeValue.Text = table.Rows[0]["DispatchTime"].ToString();
            LabelShipmentNumberValue.Text = table.Rows[0]["ShipmentNumber"].ToString();
            LabelFromUrlValue.Text = table.Rows[0]["FromUrl"].ToString();
            LabelInvoiceTypeValue.Text = table.Rows[0]["InvoiceType"].ToString();
            LabelInvoiceTitleValue.Text = table.Rows[0]["InvoiceTitle"].ToString();
            LabelInvoiceContentValue.Text = table.Rows[0]["InvoiceContent"].ToString();
            LabelClientToSellerMsgValue.Text = table.Rows[0]["ClientToSellerMsg"].ToString();
            LabelOutOfStockOperateValue.Text = table.Rows[0]["OutOfStockOperate"].ToString();
            LabelSellerToClientMsgValue.Text = table.Rows[0]["SellerToClientMsg"].ToString();
            LabelNameValue.Text = table.Rows[0]["Name"].ToString();
            LabelEmailValue.Text = table.Rows[0]["Email"].ToString();
            LabelAddressValue.Text = table.Rows[0]["Address"].ToString();
            LabelPostalcodeValue.Text = table.Rows[0]["Postalcode"].ToString();
            LabelTelValue.Text = table.Rows[0]["Tel"].ToString();
            LabelMobileValue.Text = table.Rows[0]["Mobile"].ToString();
            LabelProductPriceValue.Text = table.Rows[0]["ProductPrice"].ToString();
            LabelDiscountValue.Text = table.Rows[0]["Discount"].ToString();
            LabelInvoiceTaxValue.Text = table.Rows[0]["InvoiceTax"].ToString();
            LabelDispatchPriceValue.Text = table.Rows[0]["DispatchPrice"].ToString();
            if (table.Rows[0]["IsPercent"].ToString() == "0")
            {
                LabelPaymentPriceValue.Text = table.Rows[0]["PaymentPrice"].ToString();
            }
            else
            {
                LabelPaymentPriceValue.Text =
                    (((((Convert.ToDecimal(LabelProductPriceValue.Text) + Convert.ToDecimal(LabelDiscountValue.Text)) +
                        Convert.ToDecimal(LabelInvoiceTaxValue.Text)) + Convert.ToDecimal(LabelDispatchPriceValue.Text))*
                      Convert.ToDecimal(table.Rows[0]["PaymentPrice"].ToString()))/100M).ToString();
            }
            LabelShopIDValue.Text = table.Rows[0]["ShopID"].ToString();
            LabelShopNameValue.Text = table.Rows[0]["ShopName"].ToString();
            LabelMemLoginIDValueShow.Text = table.Rows[0]["MemLoginID"].ToString();
            LabelMemLoginIDValue.Text = table.Rows[0]["MemLoginID"].ToString();
            string orderPrice = "0";
            orderPrice = LabelProductPriceValue.Text + "-" + LabelDiscountValue.Text + "+" + LabelInvoiceTaxValue.Text +
                         "+" + LabelDispatchPriceValue.Text + "+" + LabelPaymentPriceValue.Text;
            LabelOrderPriceValue.Text =
                ((ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action()).ComputeOderPrice(orderPrice);
            LabelAlreadPayPriceValue.Text = table.Rows[0]["AlreadPayPrice"].ToString();
            LabelSurplusPriceValue.Text = table.Rows[0]["SurplusPrice"].ToString();
            LabelScorePriceValue.Text = table.Rows[0]["ScorePrice"].ToString();
            LabelShouldPayPriceValue.Text = table.Rows[0]["ShouldPayPrice"].ToString();
            LabelUseScoreValue.Text = table.Rows[0]["UseScore"].ToString();
            HiddenFieldDeposit.Value = table.Rows[0]["Deposit"].ToString();
            HiddenFieldBuyType.Value = table.Rows[0]["BuyType"].ToString();
            HiddenFieldActivityGuid.Value = table.Rows[0]["ActivityGuid"].ToString();
            if (!(HiddenFieldBuyType.Value == "0") && !(HiddenFieldBuyType.Value == "1"))
            {
            }
        }

        protected void GetOrderProduct()
        {
            DataTable table =
                ((ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action()).Search(
                    hiddenFieldGuid.Value);
            Num1GridViewShowOrderProduct.DataSource = table.DefaultView;
            Num1GridViewShowOrderProduct.DataBind();
        }

        protected void GetOrderProductRepeter()
        {
            DataTable table =
                ((ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action()).Search(
                    hiddenFieldGuid.Value);
            RepeaterData.DataSource = table.DefaultView;
            RepeaterData.DataBind();
        }

        private string method_5(string string_13)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_13);
            try
            {
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        protected void Num1GridViewShowOrderProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[8].Text =
                    (Convert.ToDecimal(e.Row.Cells[6].Text)*Convert.ToInt32(e.Row.Cells[7].Text)).ToString();
            }
            if ((e.Row.RowType == DataControlRowType.DataRow) || (e.Row.RowType == DataControlRowType.Header))
            {
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                            ? "0"
                                            : base.Request.QueryString["guid"];
                GetOrderInfo();
                GetOrderProduct();
                GetOrderProductRepeter();
            }
        }
    }
}