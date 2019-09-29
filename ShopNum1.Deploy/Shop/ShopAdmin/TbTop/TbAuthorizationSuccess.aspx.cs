using System;
using System.Web;
using System.Web.UI;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbAuthorizationSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //��֤��Ա���ĵ�cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //�˳�
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //�˳�
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //��Ա��¼ID
            }
        }
    }
}