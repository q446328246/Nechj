using System;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbTopCommon;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbRemoveShopBind : Page
    {
        /// <summary>
        ///     会员名
        /// </summary>
        private string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //验证会员中心的cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //退出
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //退出
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //会员登录ID
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];
            }
        }

        protected void ButtonRemoveAdmin_Click(object sender, EventArgs e)
        {
            TopClient.AgentLogout();
            //清空appsecret
            DelAppSecret();

            var tbSystemOperate = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            tbSystemOperate.Remove(MemLoginID);
            MessageBox.Show("删除绑定成功!");
        }

        /// <summary>
        ///     删除appsecret
        /// </summary>
        private void DelAppSecret()
        {
            var tbTopKeyOperate = (ShopNum1_TbTopKey_Action) LogicTbFactory.CreateShopNum1_TbTopKey_Action();
            tbTopKeyOperate.Delete(MemLoginID);
        }
    }
}