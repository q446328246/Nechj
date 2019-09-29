using System;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbTopCommon;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class Login : Page
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


            if (Request.QueryString["top_appkey"] != null)
            {
                //关于回调地址：http://open.taobao.com/dev/index.php/%E8%8E%B7%E5%8F%96SessionKey
                //关于用户验证：http://open.taobao.com/dev/index.php/%E7%94%A8%E6%88%B7%E9%AA%8C%E8%AF%81

                //验证回调地址参数是否合法，如果合法并保存用户数据至CookieAdmin
                if (Sys.VerifyTopResponse(Request.QueryString["top_parameters"], Request.QueryString["top_session"],
                                          Request.QueryString["top_sign"], TopConfig.AppKey, TopConfig.AppSecret))
                {
                    //验证成功

                    //从top_parameters为解析当前回调地址登录的nick
                    string nick = new Parser().GetParameters(Request.QueryString["top_parameters"], "visitor_nick");
                    ///检查是淘宝商铺和本地是否绑定
                    var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
                    string shopname = string.Empty;
                    if (!tbSystem.CheckTbUserBind(nick, MemLoginID, out shopname))
                    {
                        Response.Write(
                            String.Format(
                                "<script type='text/javascript'>alert(\"您绑定的店铺为 '{0}' 请用该账户重新登录淘宝!\");</script>",
                                shopname));
                        Response.Write(
                            "<script type='text/javascript'>window.location.href=\"../s_Index.aspx?tosurl=TbTop/TbAuthorization.aspx\" </script>");
                        return;
                    }
                    if (shopname == "000")
                    {
                        tbSystem.InsertTbSystem(MemLoginID, nick);
                    }

                    TopClient.SetAgentCookies(nick, Request.QueryString["top_session"]);
                    TopAPI.RestUrl = TopConfig.ServerURL;

                    TopClient.isAgentSessionTrue = true;
                    // Response.Redirect("TbAuthorizationSuccess.aspx");
                    Response.Redirect("../s_Index.aspx?tosurl=TbTop/TbAuthorizationSuccess.aspx");
                }
                else
                {
                    //验证失败
                    Response.Write("无效验证！");
                    //Response.Write("<script type='text/javascript'>window.location.href=\"../login.aspx\" </script>");
                }
            }
            else
            {
                Response.Write("无效参数对象，登录验证失败");
                Response.Write("<script type='text/javascript'>window.location.href=\"../login.aspx\" </script>");
            }
        }
    }
}