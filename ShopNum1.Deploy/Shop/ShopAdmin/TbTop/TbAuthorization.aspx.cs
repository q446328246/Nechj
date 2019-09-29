using System;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbLinq;
using ShopNum1.TbTopCommon;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbAuthorization : Page
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

            if (TopClient.isSessionTimeOut(Page, "agent"))
            {
                string shopname =
                    HttpUtility.UrlDecode(
                        HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"]);
                var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
                if (tbSystem.GetTbSysem(MemLoginID, shopname) != null)
                {
                    Response.Redirect("TbAuthorizationSuccess.aspx");
                    return;
                }
                else
                {
                    if (TopClient.AdminLogout() == 1)
                    {
                        return;
                    }
                }
            }
            form1.Target = "_blank";
        }

        protected void btnAuthorization_Click(object sender, EventArgs e)
        {
            var tbTopKeyAction = (ShopNum1_TbTopKey_Action) LogicTbFactory.CreateShopNum1_TbTopKey_Action();
            ShopNum1_TbTopKey tbTop = tbTopKeyAction.SearchTopKey(MemLoginID);
            if (tbTop != null)
            {
                TopConfig.AppKey = tbTop.AppKey;
                TopConfig.AppSecret = tbTop.AppSecret;
                TopConfig.AgentAppkey = tbTop.AppKey;
                TopConfig.AgentSecret = tbTop.AppSecret;
            }
            TopAPI.RestUrl = TopConfig.ServerURL;
            Response.Redirect(TopConfig.ShopContainerURL); //识别环境类型，返回不同调用容器地址
        }

        //检测店铺淘宝权限
        public bool CheckShopUseTaobao()
        {
            return true;
            //string strIsUsedTaoBao = ShopSettings.GetValue("IsUsedTaoBao");

            //if (strIsUsedTaoBao == "0")
            //{
            //    return false;  //不能使用
            //}
            //else if (strIsUsedTaoBao == "1")
            //{
            //    return 1;  //不能添加商品
            //}
            //else
            //{

            //    ShopNum1_AgentPower_Action agentPower_Action = (ShopNum1_AgentPower_Action)LogicFactory.CreateShopNum1_AgentPower_Action();
            //    DataTable dataTableAgent = agentPower_Action.GetEditInfo(AgentLoginID);
            //    if (dataTableAgent.Rows.Count > 0)
            //    {
            //        if (dataTableAgent.Rows[0]["IsUsedTaoBao"].ToString() == "0")
            //        {
            //            return 0;//商品以添满
            //        }
            //        else
            //        {
            //            return 1;//可以添加
            //        }
            //    }
            //    else
            //    {
            //        return 0;//可以添加

            //    }
            //}
        }
    }
}