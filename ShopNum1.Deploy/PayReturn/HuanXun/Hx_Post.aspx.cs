using System;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class Hx_Post : Page, IRequiresSessionState
    {
        protected string Mer_code;
        protected string Billno;
        protected string Amount;
        protected string BillDate;
        protected string Currency_Type;
        protected string Gateway_Type;
        protected string Lang;
        protected string Merchanturl;
        protected string FailUrl;
        protected string ErrorUrl;
        protected string Attach;
        protected string DispAmount;
        protected string OrderEncodeType;
        protected string RetEncodeType;
        protected string Rettype;
        protected string ServerUrl;
        protected string SignMD5;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Request.QueryString["OrderNumber"] != null && this.Page.Request.QueryString["amount"] != null && this.Page.Request.QueryString["sign"] != null && !this.Page.IsPostBack)
            {
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("huanxun.aspx");
                if (paymentKey == null || paymentKey.Rows.Count <= 0)
                {
                    this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                }
                this.Mer_code = paymentKey.Rows[0]["MerchantCode"].ToString();
                string text = paymentKey.Rows[0]["SecretKey"].ToString();
                this.Billno = this.Page.Request.QueryString["OrderNumber"].ToString();
                this.Amount = Math.Round(decimal.Parse(this.Page.Request.QueryString["amount"]), 2).ToString();
                if (this.Amount.IndexOf(".") == -1)
                {
                    this.Amount += ".00";
                }
                this.BillDate = DateTime.Now.ToString("yyyyMMdd");
                this.Currency_Type = "RMB";
                this.Gateway_Type = "01";
                this.Lang = "GB";
                this.Merchanturl = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["HXReceive"];
                this.FailUrl = "";
                this.ErrorUrl = "";
                this.Attach = "";
                this.DispAmount = Convert.ToString(Math.Round(decimal.Parse(this.Amount), 2));
                this.OrderEncodeType = "5";
                this.RetEncodeType = "17";
                this.Rettype = "1";
                this.ServerUrl = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["HXSend"];
                this.SignMD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(string.Concat(new string[]
			{
				"billno",
				this.Billno,
				"currencytype",
				this.Currency_Type,
				"amount",
				this.Amount,
				"date",
				this.BillDate,
				"orderencodetype",
				this.OrderEncodeType,
				text
			}), "MD5").ToLower();
            }
        }

    }
}