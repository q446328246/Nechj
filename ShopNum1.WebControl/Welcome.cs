using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class Welcome : BaseWebControl
    {
        private static Func<string, bool> func_0;
        private Label LabelMemLoginID;
        private Literal LiteralCartCount;
        private Label MemLoginID;
        private HtmlGenericControl login;
        private HtmlGenericControl loginOut;
        private HtmlGenericControl loginOutTwo;
        private HtmlGenericControl loginTwo;
        private Repeater repeater_0;
        private HtmlGenericControl shopcart1;
        private HtmlGenericControl shopcart2;
        private string skinFilename = "Weblcome.ascx";

        public Welcome()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            try
            {
                login = (HtmlGenericControl) skin.FindControl("login");
                loginOut = (HtmlGenericControl) skin.FindControl("loginOut");
                MemLoginID = (Label) skin.FindControl("MemLoginID");
                loginTwo = (HtmlGenericControl) skin.FindControl("loginTwo");
                loginOutTwo = (HtmlGenericControl) skin.FindControl("loginOutTwo");
                LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
                shopcart1 = (HtmlGenericControl) skin.FindControl("shopcart1");
                shopcart2 = (HtmlGenericControl) skin.FindControl("shopcart2");
                LiteralCartCount = (Literal) skin.FindControl("LiteralCartCount");
                if (Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    login.Visible = false;
                    loginOut.Visible = true;
                    loginTwo.Visible = false;
                    loginOutTwo.Visible = true;
                    shopcart1.Visible = false;
                    shopcart2.Visible = true;
                    MemLoginID.Text = cookie2.Values["MemLoginID"];
                    BindData(MemLoginID.Text.Trim());
                    if ((Page.IsPostBack &&
                         ((Page.Request.Form["secondEVENTTARGET"] != null) &&
                          (Page.Request.Form["secondEVENTTARGET"] != ""))) &&
                        (Page.Request.Form["secondEVENTTARGET"] == "cartClick"))
                    {
                        Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
                    }
                }
                else
                {
                    string str = string.Empty;
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                        str = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                        BindData(str);
                        shopcart1.Visible = false;
                        shopcart2.Visible = true;
                    }
                    else
                    {
                        shopcart1.Visible = true;
                        shopcart2.Visible = false;
                    }
                    repeater_0 = (Repeater) skin.FindControl("RepeaterSecondLogin");
                    login.Visible = true;
                    loginOut.Visible = false;
                    loginTwo.Visible = true;
                    loginOutTwo.Visible = false;
                    if (repeater_0 != null)
                    {
                        DataTable secondByCount = new ShopNum1_SecondTypeBussiness().GetSecondByCount("10", "1");
                        if ((secondByCount != null) && (secondByCount.Rows.Count > 0))
                        {
                            repeater_0.DataSource = secondByCount;
                            repeater_0.DataBind();
                        }
                    }
                    if (Page.IsPostBack &&
                        ((Page.Request.Form["secondEVENTTARGET"] != null) &&
                         (Page.Request.Form["secondEVENTTARGET"] != "")))
                    {
                        if (Page.Request.Form["secondEVENTTARGET"] == "cartClick")
                        {
                            GetUrl.RedirectLoginGoBack();
                        }
                        else
                        {
                            RaisePostBackEvent();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Logout(string domain)
        {
            if (HttpContext.Current.Request.Cookies["dnt"] != null)
            {
                var cookie = new HttpCookie("dnt")
                {
                    Expires = Convert.ToDateTime(DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss")),
                    Domain = domain,
                    Secure = false
                };
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        protected void BindData(string string_1)
        {
            if (LiteralCartCount != null)
            {
                IShopNum1_Cart_Action action = LogicFactory.CreateShopNum1_Cart_Action();
                LiteralCartCount.Text = action.GetMemCartCount(string_1).ToString();
            }
        }

        public void RaisePostBackEvent()
        {
            string arg = Page.Request.Form["secondEVENTTARGET"];
            if (func_0 == null)
            {
                func_0 = sBindData;
            }
            func_0(arg);
        }


        private static bool sBindData(string string_1)
        {
            DataTable model = null;
            var bussiness = new ShopNum1_SecondTypeBussiness();
            string str = string_1;
            switch (str)
            {
                case null:
                    break;

                case "1":
                    model = bussiness.GetModel(1);
                    if ((model != null) && (model.Rows.Count != 0))
                    {
                        ShopNum1_QzoneCommonClient.GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                            "http://" +
                            ConfigurationManager.AppSettings["Domain"] +
                            "/Main/Second/Qzone/QzoneReturn.aspx");
                    }
                    break;

                case "2":
                    model = bussiness.GetModel(2);
                    if ((model != null) && (model.Rows.Count != 0))
                    {
                        new ShopNum1_BaiduOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                            "http://" +
                            ConfigurationManager.AppSettings["Domain"] +
                            "/Main/Second/Baidu/BaiduReturn.aspx");
                    }
                    break;

                case "3":
                    model = bussiness.GetModel(3);
                    if ((model != null) && (model.Rows.Count != 0))
                    {
                        new ShopNum1_XinlanOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                            "http://" +
                            ConfigurationManager.AppSettings["Domain"] +
                            "/Main/Second/Xinlan/XinlanReturn.aspx");
                    }
                    break;

                default:
                    if (!(str == "4"))
                    {
                        if (str == "5")
                        {
                            model = bussiness.GetModel(5);
                            new ShopNum1_TaobaoOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                                "http://" +
                                ConfigurationManager.AppSettings[
                                    "Domain"] +
                                "/Main/Second/Taobao/TaobaoReturn.aspx");
                        }
                    }
                    else
                    {
                        var _config = new ShopNum1_Alipay_config();
                        new ShopNum1_AlipayOAuthClient(_config).GetAuthorizationUrl();
                    }
                    break;
            }
            return true;
        }
    }
}