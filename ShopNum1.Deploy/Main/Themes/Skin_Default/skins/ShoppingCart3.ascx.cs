using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Payment;

namespace ShopNum1.Deploy.Main.Themes.Skin_Default.skins
{
    public partial class ShoppingCart3 : BaseMemberControl
    {
        public string BuyType { get; set; }
        public string Deposit { get; set; }
        public string OrganizGuid { get; set; }
        public string IsPayDeposit { get; set; }
        public int CategoryId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                MemLoginID = httpCookie.Values["MemLoginID"];
                if (Page.Request.QueryString["PaymentName"] != null)
                {
                    LabelPaymentName.Text = Page.Request.QueryString["PaymentName"];
                }
                if (Page.Request.QueryString["ShouldPayPrice"] != null)
                {
                    LabelPayPrice.Text = Page.Request.QueryString["ShouldPayPrice"];
                }
                if (Page.Request.QueryString["tradeid"] != null)
                {
                    HiddenFieldTradeID.Value = Page.Request.QueryString["tradeid"];
                }
                GetOtherInfo();
            }
            else
            {
                GetUrl.RedirectLogin();
            }
        }

        protected void GetOtherInfo()
        {
            IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataSet dataSet = shopNum1_OrderInfo_Action.OrderInfoGetSimpleByTradeID(HiddenFieldTradeID.Value, MemLoginID);
            if (dataSet != null && dataSet.Tables.Count == 2)
            {
                
                DataTable dataTable = dataSet.Tables[1];

                if (dataTable.Rows[0]["shop_category_id"].ToString() == "2")
                {
                    LabelPayPrice.Text = (Convert.ToDecimal(dataSet.Tables[0].Rows[0]["ShouldPayPrice"]) / Convert.ToDecimal(QLX_NEC_BILI.GetNECbili())).ToString();
                }
                else
                {
                    //LabelPayPrice.Text = (Convert.ToDecimal(dataSet.Tables[0].Rows[0]["ShouldPayPrice"]) / Convert.ToDecimal(QLX_NEC_BILI.GetNECbili())).ToString();
                    LabelPayPrice.Text = dataSet.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                }

                LabelPaymentName.Text = dataTable.Rows[0]["PaymentName"].ToString();
                if (LabelPaymentName.Text == "货到付款" || LabelPaymentName.Text.IndexOf("线下") != -1)
                {
                    ButtonPay.Visible = false;
                }
                HiddenFieldPaymentGuid.Value = dataTable.Rows[0]["PaymentGuid"].ToString().ToUpper();
                if (HiddenFieldPaymentGuid.Value == "ACB3A3BD-3229-436D-90DD-001B9C29AF9A" ||
                    HiddenFieldPaymentGuid.Value == "9ECA37CE-91C3-4D0C-8EFC-48D37A586D57" ||
                    HiddenFieldPaymentGuid.Value == "D2038EF7-7466-412F-AB4C-773EADB7FFFA" ||
                    HiddenFieldPaymentGuid.Value == "ACB3A3BD-3229-436D-90DD-001B9C29AF9A")
                {
                    ButtonPay.Visible = false;
                }
                HiddenFieldProductNames.Value = "";
                if (dataTable.Rows.Count > 0)
                {
                    CategoryId = Convert.ToInt32(dataTable.Rows[0]["shop_category_id"]);
                }
                RepeaterOrder.DataSource = dataTable.DefaultView;
                RepeaterOrder.DataBind();
                int num = 0;
                foreach (RepeaterItem repeaterItem in RepeaterOrder.Items)
                {
                    var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldOrderGuid");
                    var repeater = (Repeater)repeaterItem.FindControl("RepeaterOrderProduct");
                    DataTable dataTable2 = shopNum1_OrderInfo_Action.SearchOrderSimpleProduct(hiddenField.Value,
                        dataTable.Rows[num]["ShopID"].ToString());
                    repeater.DataSource = dataTable2.DefaultView;
                    repeater.DataBind();
                    foreach (DataRow dataRow in dataTable2.Rows)
                    {
                        if (HiddenFieldProductNames.Value.Length >= 48)
                        {
                            HiddenFieldProductNames.Value = HiddenFieldProductNames.Value.Substring(0, 44) + "...";
                            break;
                        }
                        HiddenFieldProductNames.Value = HiddenFieldProductNames.Value + ";" + dataRow["ProductName"];
                    }
                    num++;
                }
                LiteralPayMemLoginID.Text = dataTable.Rows[0]["PayMentMemLoginID"].ToString();
            }
        }
        protected void GetPayMentUrl() 
        {
            string shouldPayPrice = LabelPayPrice.Text;
            if (BuyType == "0")
            {
                shouldPayPrice = LabelPayPrice.Text;
            }
            else
            {
                if (BuyType == "2")
                {
                    shouldPayPrice = LabelPayPrice.Text;
                }
                else
                {
                    if (BuyType == "3")
                    {
                        shouldPayPrice = LabelPayPrice.Text;
                    }
                    else
                    {
                        if (BuyType == "1")
                        {
                            if (Deposit == "0.00")
                            {
                                shouldPayPrice = LabelPayPrice.Text;
                            }
                            else
                            {
                                shouldPayPrice = Deposit;
                            }
                        }
                    }
                }
            }
            string ZF = "";
            if (HiddenFieldPaymentGuid.Value.ToUpper() == "1075526A-7C28-44D0-B5F8-FD1B6746F662".ToUpper())
            {
                HiddenFieldPaymentGuid.Value = "D7A29771-7640-4999-85DE-B3B493DA5970";
                ZF = "&Dinpay=1";
            }
            if (HiddenFieldPaymentGuid.Value.ToUpper() == "EB24C8E6-2959-452F-9332-CAEEEDD510BA".ToUpper())
            {
                HiddenFieldPaymentGuid.Value = "D7A29771-7640-4999-85DE-B3B493DA5970";
                ZF = "&Dinpay=2";
            }
            string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
            var payUrlOperate = new PayUrlOperate();
            string payUrl = payUrlOperate.GetPayUrl(HiddenFieldPaymentGuid.Value, shouldPayPrice,
                ShopSettings.siteDomain, HiddenFieldProductNames.Value, HiddenFieldTradeID.Value, "product", "1",
                LiteralPayMemLoginID.Text, MemLoginID, timetemp);
            payUrl = payUrl + ZF;
            if (payUrl.Length > 1000)
            {
                Encoding contentEncoding;
                if (payUrl.Split(new[]
                {
                    '|'
                })[0].IndexOf("UTF") != -1)
                {
                    contentEncoding = Encoding.UTF8;
                }
                else
                {
                    contentEncoding = Encoding.Default;
                }
                Page.Response.ContentEncoding = contentEncoding;
                Page.Response.Write(payUrl.Split(new[]
                {
                    '|'
                })[1]);
            }
            else
            {
                Page.Response.Redirect(payUrl);
            }
        }

        protected void ButtonPay_Click(object sender, EventArgs e)
        {
            GetPayMentUrl();

            
        }
    }
}