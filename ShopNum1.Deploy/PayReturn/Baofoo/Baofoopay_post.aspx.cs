using System;
using System.Configuration;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn.Baofoo
{
    public partial class Baofoopay_post : System.Web.UI.Page
    {
        protected string strMerchantID;
        protected string strPayID;
        protected string strTradeDate;
        protected string strTransID;
        protected string strOrderMoney;
        protected string strProductName;
        protected string strAmount;
        protected string strProductLogo;
        protected string strUsername;
        protected string strEmail;
        protected string strMobile;
        protected string strAdditionalInfo;
        protected string strMerchant_url;
        protected string strReturn_url;
        protected string strMd5Sign;
        protected string strNoticeType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Request.QueryString["OrderNumber"] != null)
            {
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Baofoo.aspx");
                if (paymentKey == null || paymentKey.Rows.Count <= 0)
                {
                    this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                }
                this.strMerchantID = paymentKey.Rows[0]["MerchantCode"].ToString();
                this.strPayID = "1000";
                this.strTradeDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                this.strTransID = this.Page.Request.QueryString["OrderNumber"];
                ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                if (this.Page.Request.QueryString["OrderNumber"].IndexOf('C') == -1)
                {
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(this.Page.Request.QueryString["OrderNumber"]);
                    if (dataTable == null || dataTable.Rows.Count <= 0)
                    {
                        this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                        return;
                    }
                    this.strOrderMoney = (Convert.ToDouble(dataTable.Rows[0]["ShouldPayPrice"].ToString()) * 100.0).ToString();
                    this.strProductName = "";
                    this.strAmount = "1";
                    this.strProductLogo = "";
                    this.strUsername = dataTable.Rows[0]["Name"].ToString();
                    this.strEmail = dataTable.Rows[0]["Email"].ToString();
                    this.strMobile = dataTable.Rows[0]["Mobile"].ToString();
                    this.strAdditionalInfo = "";
                    this.strMerchant_url = "http://" + ConfigurationManager.AppSettings["Domain"] + "/PayReturn/Baofoo/merchant_url.aspx";
                    this.strReturn_url = "http://" + ConfigurationManager.AppSettings["Domain"] + "/PayReturn/Baofoo/return_url.aspx";
                    this.strNoticeType = "1";
                    string string_ = paymentKey.Rows[0]["SecretKey"].ToString();
                    this.strMd5Sign = this.method_0(this.strMerchantID, this.strPayID, this.strTradeDate, this.strTransID, this.strOrderMoney, this.strMerchant_url, this.strReturn_url, this.strNoticeType, string_);
                }
                else
                {
                    this.strOrderMoney = (Convert.ToDouble(ShopNum1.Common.Common.ReqStr("price").ToString()) * 100.0).ToString();
                    this.strProductName = "";
                    this.strAmount = "1";
                    this.strProductLogo = "";
                    this.strUsername = "";
                    this.strEmail = "";
                    this.strMobile = "";
                    this.strAdditionalInfo = "";
                    this.strMerchant_url = "http://" + ConfigurationManager.AppSettings["Domain"] + "/PayReturn/Baofoo/merchant_url.aspx";
                    this.strReturn_url = "http://" + ConfigurationManager.AppSettings["Domain"] + "/PayReturn/Baofoo/return_url.aspx";
                    this.strNoticeType = "1";
                    string string_ = paymentKey.Rows[0]["SecretKey"].ToString();
                    this.strMd5Sign = this.method_0(this.strMerchantID, this.strPayID, this.strTradeDate, this.strTransID, this.strOrderMoney, this.strMerchant_url, this.strReturn_url, this.strNoticeType, string_);
                }
            }
            else
            {
                this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
            }
        }
        private string method_0(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8)
        {
            string strToBeEncrypt = string.Concat(new string[]
		{
			string_0,
			string_1,
			string_2,
			string_3,
			string_4,
			string_5,
			string_6,
			string_7,
			string_8
		});
            return ShopNum1.Payment.Baofoo.Md5Encrypt(strToBeEncrypt);
        }

    }
}