using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System.Data;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberApproval1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                DateBind();
            }
          
        }
        protected void DateBind()
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            string Referral = decodedCookieShopMemberLogin.Values["MemLoginID"];
            var orderinfoaction1 = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderset1 = orderinfoaction1.GetAllApprovalReferral(Referral);
            GridView1.DataSource = orderset1;

            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete1")
            {
                string MemloginID = e.CommandArgument.ToString();
                HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                string Referral = decodedCookieShopMemberLogin.Values["MemLoginID"];
                var orderinfoaction1 = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
                int orderset1 = orderinfoaction1.DeleteShopNum1_Referral(Referral, MemloginID);
                DateBind();
            }
        }
    }
}