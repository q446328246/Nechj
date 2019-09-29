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
        ///     ��Ա��
        /// </summary>
        private string MemLoginID { get; set; }

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
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];
            }


            if (Request.QueryString["top_appkey"] != null)
            {
                //���ڻص���ַ��http://open.taobao.com/dev/index.php/%E8%8E%B7%E5%8F%96SessionKey
                //�����û���֤��http://open.taobao.com/dev/index.php/%E7%94%A8%E6%88%B7%E9%AA%8C%E8%AF%81

                //��֤�ص���ַ�����Ƿ�Ϸ�������Ϸ��������û�������CookieAdmin
                if (Sys.VerifyTopResponse(Request.QueryString["top_parameters"], Request.QueryString["top_session"],
                                          Request.QueryString["top_sign"], TopConfig.AppKey, TopConfig.AppSecret))
                {
                    //��֤�ɹ�

                    //��top_parametersΪ������ǰ�ص���ַ��¼��nick
                    string nick = new Parser().GetParameters(Request.QueryString["top_parameters"], "visitor_nick");
                    ///������Ա����̺ͱ����Ƿ��
                    var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
                    string shopname = string.Empty;
                    if (!tbSystem.CheckTbUserBind(nick, MemLoginID, out shopname))
                    {
                        Response.Write(
                            String.Format(
                                "<script type='text/javascript'>alert(\"���󶨵ĵ���Ϊ '{0}' ���ø��˻����µ�¼�Ա�!\");</script>",
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
                    //��֤ʧ��
                    Response.Write("��Ч��֤��");
                    //Response.Write("<script type='text/javascript'>window.location.href=\"../login.aspx\" </script>");
                }
            }
            else
            {
                Response.Write("��Ч�������󣬵�¼��֤ʧ��");
                Response.Write("<script type='text/javascript'>window.location.href=\"../login.aspx\" </script>");
            }
        }
    }
}