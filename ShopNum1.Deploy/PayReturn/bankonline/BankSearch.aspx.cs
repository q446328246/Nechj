using System;
using System.Data;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn.bankonline
{
    public partial class BankSearch : Page, IRequiresSessionState
    {
        protected string v_oid;
        protected string v_mid;
        protected string billNo_md5;
        protected string v_url;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.v_mid = "";
            this.v_url = "http://www.t.com";
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Send.aspx");
            string str = paymentKey.Rows[0]["SecretKey"].ToString();
            this.v_mid = paymentKey.Rows[0]["merchantcode"].ToString();
            this.v_oid = base.Request["v_oid"];
            string password = this.v_oid + str;
            this.billNo_md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5").ToUpper();
        }

    }
}