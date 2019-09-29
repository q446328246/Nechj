using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member
{
    public partial class M_TJmemberTGYWY : PageBase
    {
        public string TEXT;
        public string URL;
        public void BindtITLE()
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];

            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string MemID = string.Empty;


            DataTable membertable = action.GetMemInfo(MemberLoginID);
            MemID = membertable.Rows[0]["MemLoginNO"].ToString();

            TEXT = "注册:http://" + ShopSettings.siteDomain + "/Main/MemberRegister.aspx?recommendid=" + MemID + "";
            URL = "http://" + ShopSettings.siteDomain + "/Main/MemberRegister.aspx?recommendid=" + MemID + "";

         
            Image1.ImageUrl = string.Format("VQRcodeall.aspx?Recommend={0}", MemID);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindtITLE();
        }
    }
}