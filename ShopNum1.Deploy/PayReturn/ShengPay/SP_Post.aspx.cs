using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn.ShengPay
{
    public partial class SP_Post : Page, IRequiresSessionState
    {
        protected string ShenPayName;
        protected string Version;
        protected string Charset;
        protected string MsgSender;
        protected string SendTime;
        protected string OrderNo;
        protected string OrderAmount;
        protected string OrderTime;
        protected string PayType;
        protected string payChannel;
        protected string InstCode;
        protected string PageUrl;
        protected string NotifyUrl;
        protected string ProductName;
        protected string BuyerContact;
        protected string BuyerIp;
        protected string Ext1;
        protected string SignType;
        protected string SignMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Request.QueryString["OrderNumber"] != null && this.Page.Request.QueryString["amount"] != null && this.Page.Request.QueryString["sign"] != null && !this.Page.IsPostBack)
            {
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("ShengPay.aspx");
                if (paymentKey == null || paymentKey.Rows.Count <= 0)
                {
                    this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                }
                this.MsgSender = paymentKey.Rows[0]["MerchantCode"].ToString();
                string text = paymentKey.Rows[0]["SecretKey"].ToString();
                this.ShenPayName = "B2CPayment";
                this.Version = "V4.1.1.1.1";
                this.Charset = "UTF-8";
                this.SendTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                this.OrderNo = this.Page.Request.QueryString["OrderNumber"].ToString();
                this.OrderAmount = this.Page.Request.QueryString["amount"].ToString();
                this.OrderTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                this.PayType = "PT001";
                this.payChannel = "19";
                this.InstCode = "CMB";
                this.PageUrl = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["SPReceive"];
                this.NotifyUrl = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["SPSend"];
                this.ProductName = "B2CPayment";
                this.BuyerContact = "13545281376";
                this.BuyerIp = "10.135.12.21";
                this.Ext1 = "Recharge";
                this.SignType = "MD5";
                string s = string.Concat(new string[]
			{
				this.ShenPayName,
				this.Version,
				this.Charset,
				this.MsgSender,
				this.SendTime,
				this.OrderNo,
				this.OrderAmount,
				this.OrderTime,
				this.PayType,
				this.InstCode,
				this.PageUrl,
				this.NotifyUrl,
				this.ProductName,
				this.BuyerContact,
				this.BuyerIp,
				this.Ext1,
				this.SignType,
				text
			});
                MD5 mD = new MD5CryptoServiceProvider();
                byte[] signed = mD.ComputeHash(Encoding.GetEncoding("gbk").GetBytes(s));
                string text2 = byte2mac(signed);
                this.SignMsg = text2.ToUpper();
            }
        }
        public static string byte2mac(byte[] signed)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < signed.Length; i++)
            {
                byte b = signed[i];
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

    }
}