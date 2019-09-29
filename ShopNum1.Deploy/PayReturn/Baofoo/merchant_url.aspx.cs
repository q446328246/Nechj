using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn.Baofoo
{
    public partial class merchant_url : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = base.Request.Params["MerchantID"];
            string text2 = base.Request.Params["TransID"];
            string text3 = base.Request.Params["Result"];
            string text4 = base.Request.Params["resultDesc"];
            string text5 = base.Request.Params["factMoney"];
            string text6 = base.Request.Params["additionalInfo"];
            string text7 = base.Request.Params["SuccTime"];
            string text8 = base.Request.Params["Md5Sign"].ToLower();
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Baofoo.aspx");
            if (paymentKey == null || paymentKey.Rows.Count <= 0)
            {
                this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
            }
            string text9 = paymentKey.Rows[0]["SecretKey"].ToString();
            string strToBeEncrypt = string.Concat(new string[]
		{
			text,
			text2,
			text3,
			text4,
			text5,
			text6,
			text7,
			text9
		});
            if (text8.ToLower() == ShopNum1.Payment.Baofoo.Md5Encrypt(strToBeEncrypt).ToLower())
            {
                this.lbMoney.Text = ((double)int.Parse(text5) * 0.01).ToString() + " 元";
                this.lbDate.Text = text7;
                this.lbFlag.Text = ShopNum1.Payment.Baofoo.GetErrorInfo(text3, text4);
                this.lbOrderID.Text = text2;
                base.Response.Redirect("/main/Member/m_index.aspx");
            }
            else
            {
                base.Response.Write("校验失败");
            }
        }

    }
}