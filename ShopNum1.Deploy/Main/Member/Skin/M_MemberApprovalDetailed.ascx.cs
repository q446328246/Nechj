using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using System.Data;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberApprovalDetailed : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateBind();
            }  
        }
        private void DateBind()
        {
            
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            string Referral = decodedCookieShopMemberLogin.Values["MemLoginID"];
            var orderinfoaction1 = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
            string MemloginID = Page.Request.QueryString["type"];
            DataTable orderset1 = orderinfoaction1.GetAllApprovalReferralAndMemloginID(Referral, MemloginID);
            TextBoxBankName.Text = orderset1.Rows[0]["BankName"].ToString();
            TextBoxAgent.Text = orderset1.Rows[0]["Agent"].ToString();
            TextBoxaccount_no.Text = orderset1.Rows[0]["BankID"].ToString();
            TextBoxbank_address.Text = orderset1.Rows[0]["BankBranch"].ToString();
            TextBoxaccount_name.Text = orderset1.Rows[0]["AccountName"].ToString();
            TextBoxReferee.Text = orderset1.Rows[0]["MemloginID"].ToString();
           
        }  
    }
}