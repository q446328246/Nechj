using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class Login : BaseWebControl
    {
        private static Func<string, bool> func_0;
        private Button ButtonCancelLogin;
        private Button ButtonLogin;
        private HiddenField HiddenFieldLoginType;
        private Label LabelLoginInfo;
        private Label LabelMemLoginID;
        private DropDownList LoginValidity;
        private Repeater RepeaterSecondLogin;
        private TextBox TextBoxCode;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxPwd;
        private HtmlTableRow VerifyCode;
        private HtmlGenericControl divAgainLogin;
        private HtmlGenericControl divlogin;
        private string string_0 = "Login.ascx";

        public Login()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_0;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            divlogin = (HtmlGenericControl) skin.FindControl("divlogin");
            divAgainLogin = (HtmlGenericControl) skin.FindControl("divAgainLogin");
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Expires = 0;
                Page.Response.Buffer = true;
                Page.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
                Page.Response.AddHeader("pragma", "no-cache");
                Page.Response.CacheControl = "no-cache";
                //this.divlogin.Visible = true;
                //this.divAgainLogin.Visible = false;
                TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
                TextBoxPwd = (TextBox) skin.FindControl("TextBoxPwd");
                TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
                LabelLoginInfo = (Label) skin.FindControl("LabelLoginInfo");
                ButtonLogin = (Button) skin.FindControl("ButtonLogin");
                ButtonCancelLogin = (Button) skin.FindControl("ButtonCancelLogin");
                ButtonLogin.Click += ButtonLogin_Click;
                VerifyCode = (HtmlTableRow) skin.FindControl("VerifyCode");
                LoginValidity = (DropDownList) skin.FindControl("LoginValidity");
                HiddenFieldLoginType = (HiddenField) skin.FindControl("HiddenFieldLoginType");
                RepeaterSecondLogin = (Repeater) skin.FindControl("RepeaterSecondLogin");
                if (RepeaterSecondLogin != null)
                {
                    var shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
                    DataTable secondByCount = shopNum1_SecondTypeBussiness.GetSecondByCount("10", "1");
                    if (secondByCount != null && secondByCount.Rows.Count > 0)
                    {
                        RepeaterSecondLogin.DataSource = secondByCount;
                        RepeaterSecondLogin.DataBind();
                    }
                }
                if (Page.IsPostBack && Page.Request.Form["secondEVENTTARGET"] != null &&
                    Page.Request.Form["secondEVENTTARGET"] != "")
                {
                    if (Page.Request.Form["secondEVENTTARGET"] == "cartClick")
                    {
                        Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
                        return;
                    }
                    RaisePostBackEvent();
                }
                //if (ShopSettings.GetValue("MemLoginVerifyCode") == "1")
                //{
                //    this.VerifyCode.Visible = true;
                //}
                //else
                //{
                //    this.VerifyCode.Visible = false;
                //}
            }
            else
            {
                if (Page.IsPostBack && Page.Request.Form["secondEVENTTARGET"] != null &&
                    Page.Request.Form["secondEVENTTARGET"] != "")
                {
                    if (Page.Request.Form["secondEVENTTARGET"] == "cartClick")
                    {
                        GetUrl.RedirectLoginGoBack();
                        return;
                    }
                    RaisePostBackEvent();
                }
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                LabelMemLoginID.Text = httpCookie.Values["MemLoginID"];
                //this.divlogin.Visible = false;
                //this.divAgainLogin.Visible = true;
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (ShopSettings.GetValue("MemLoginVerifyCode") == "1")
            {
                if (Page.Session["code"] == null)
                {
                    LabelLoginInfo.Text = "验证码有误！";
                    return;
                }
                if (TextBoxCode.Text.ToUpper() != Page.Session["code"].ToString())
                {
                    LabelLoginInfo.Text = "验证码不正确！";
                    return;
                }
            }
            var shopNum1_Member_Action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            DataTable memberPassWord = shopNum1_Member_Action.GetMemberPassWord(TextBoxMemLoginID.Text.Trim(),
                Encryption.GetMd5Hash(TextBoxPwd.Text.Trim()));
            if (memberPassWord != null && memberPassWord.Rows.Count > 0)
            {
                string str = string.Empty;
                if (memberPassWord.Rows[0]["IsForbid"].ToString() == "1")
                {
                    MessageBox.Show("对不起，您的账户已被禁用！");
                }
                else
                {
                    var httpCookie = new HttpCookie("MemberLoginCookie");
                    httpCookie.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
                    httpCookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
                    httpCookie.Values.Add("IsMailActivation", memberPassWord.Rows[0]["IsMailActivation"].ToString());
                    httpCookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
                    httpCookie.Values.Add("MemRankGuid", memberPassWord.Rows[0]["MemberRankGuid"].ToString());
                    if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
                    {
                        var shopNum1_ShopInfoList_Action =
                            (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
                        DataTable shopRankByMemLoginID =
                            shopNum1_ShopInfoList_Action.GetShopRankByMemLoginID(
                                memberPassWord.Rows[0]["MemLoginID"].ToString());
                        if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
                        {
                            httpCookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                        }
                    }
                    HttpCookie httpCookie2 = HttpSecureCookie.Encode(httpCookie);
                    httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    httpCookie.Values.Add("UID", "-1");
                    LoginValidity.SelectedValue = "0";
                    string selectedValue = LoginValidity.SelectedValue;
                    if (selectedValue != null)
                    {
                        if (!(selectedValue == "1d"))
                        {
                            if (!(selectedValue == "1h"))
                            {
                                if (!(selectedValue == "1y"))
                                {
                                    if (!(selectedValue == "1m"))
                                    {
                                        if (selectedValue == "1w")
                                        {
                                            httpCookie2.Expires =
                                                Convert.ToDateTime(
                                                    DateTime.Now.AddDays(7.0).ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                    }
                                    else
                                    {
                                        httpCookie2.Expires =
                                            Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                }
                                else
                                {
                                    httpCookie2.Expires =
                                        Convert.ToDateTime(DateTime.Now.AddYears(1).ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                            }
                            else
                            {
                                httpCookie2.Expires =
                                    Convert.ToDateTime(DateTime.Now.AddHours(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        }
                        else
                        {
                            httpCookie2.Expires =
                                Convert.ToDateTime(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                    string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"];
                    if (a == "1")
                    {
                        var rTN_UserLogin = new RTN_UserLogin();
                        try
                        {
                            rTN_UserLogin = Func.uc_user_login(TextBoxMemLoginID.Text.Trim(),
                                TextBoxPwd.Text.Trim().ToLower());
                        }
                        catch
                        {
                        }
                        int num = shopNum1_Member_Action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim());
                        if (rTN_UserLogin.Uid < 0)
                        {
                            LabelLoginInfo.Text = "用户名或密码有误！";
                        }
                        else
                        {
                            if (rTN_UserLogin.Uid > 0 && num > 0)
                            {
                                shopNum1_Member_Action.UpdatePwd(rTN_UserLogin.UserName,
                                    Encryption.GetMd5Hash(rTN_UserLogin.PassWord));
                            }
                            rTN_UserLogin.Uid.ToString();
                            try
                            {
                                string script = Func.uc_user_synlogin(rTN_UserLogin.Uid);
                                HttpContext.Current.Response.AddHeader("P3P",
                                    "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ucenter", script, false);
                            }
                            catch
                            {
                            }
                        }
                    }
                    string a2 = ConfigurationManager.AppSettings["IsIntergrationTg"];
                    if (a2 == "1")
                    {
                        Configuration configuration =
                            WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath);
                        var appSettingsSection = (AppSettingsSection) configuration.GetSection("appSettings");
                        string value = appSettingsSection.Settings["TgPostUrl"].Value;
                        string value2 = appSettingsSection.Settings["TgSourceKey"].Value;
                        string arg = string.Concat(new object[]
                        {
                            value,
                            "IntergrationMemberLogin.aspx?MemLoginID=",
                            TextBoxMemLoginID.Text.Trim(),
                            "&MemberRankGuid=",
                            Guid.NewGuid(),
                            "&Pwd=",
                            TextBoxPwd.Text.Trim().ToLower(),
                            "&TgSourceKey=",
                            value2
                        });
                        string text = "<script src='{0}'></script>";
                        text = string.Format(text, arg);
                        Page.Response.Write(text);
                    }
                    string text2 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                    if (text2.Trim() == "1" && Page.Request.Cookies["dnt"] == null)
                    {
                        DiscuzSession session = DiscuzSessionHelper.GetSession();
                        try
                        {
                            int userID = session.GetUserID(TextBoxMemLoginID.Text.Trim());
                            session.Login(userID, TextBoxPwd.Text.Trim().ToLower(), false, 100,
                                ConfigurationManager.AppSettings["CookieDomain"]);
                        }
                        catch
                        {
                        }
                    }
                    Page.Response.AppendCookie(httpCookie2);
                    shopNum1_Member_Action.UpdateLoginTime(TextBoxMemLoginID.Text.Trim(), Page.Request.UserHostAddress);
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        try
                        {
                            string oldUser = string.Empty;
                            HttpCookie httpCookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                            HttpCookie httpCookie4 = HttpSecureCookie.Decode(httpCookie3);
                            oldUser = httpCookie4.Values["MemLoginID"];
                            var shop_Product_Action =
                                (Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action();
                            shop_Product_Action.ChangeCarByCook(oldUser, TextBoxMemLoginID.Text.Trim());
                            httpCookie3.Values.Clear();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (Common.Common.ReqStr("goback") != "")
                    {
                        str = Common.Common.ReqStr("goback").Replace("%2f", "/");
                    }
                    else
                    {
                        str = "/main/member/m_index.aspx";
                    }
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirecturl",
                        "window.location.href='" + str + "'", true);
                }
            }
            else
            {
                string str = string.Empty;
                if (Page.Request.QueryString["goback"] != null)
                {
                    str = Page.Request.QueryString["goback"];
                }
                else
                {
                    str = "/main/member/m_index.aspx";
                }
                string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"];
                if (a == "1")
                {
                    var rTN_UserLogin = new RTN_UserLogin();
                    try
                    {
                        rTN_UserLogin = Func.uc_user_login(TextBoxMemLoginID.Text.Trim(),
                            TextBoxPwd.Text.Trim().ToLower());
                    }
                    catch
                    {
                    }
                    if (rTN_UserLogin.Uid < 0)
                    {
                        LabelLoginInfo.Text = "用户名或密码有误！";
                    }
                    else
                    {
                        int num = shopNum1_Member_Action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim());
                        if (num <= 0)
                        {
                            var shopNum1_Member = new ShopNum1_Member();
                            shopNum1_Member.MemLoginID = rTN_UserLogin.UserName;
                            shopNum1_Member.MemberType = 1;
                            shopNum1_Member.Name = "";
                            shopNum1_Member.Pwd = Encryption.GetMd5Hash(TextBoxPwd.Text.Trim().ToLower());
                            shopNum1_Member.IsForbid = 0;
                            shopNum1_Member.Email = rTN_UserLogin.Email;
                            shopNum1_Member.Guid = Guid.NewGuid();
                            shopNum1_Member.Tel = "";
                            shopNum1_Member.AdvancePayment = 0m;
                            shopNum1_Member.AddressValue = "";
                            shopNum1_Member.AddressCode = "";
                            shopNum1_Member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_Member.LoginDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            string value3 = ShopSettings.GetValue("RegPresentRankScore");
                            if (value3 == "" || value3 == null)
                            {
                                shopNum1_Member.MemberRank = 0;
                            }
                            else
                            {
                                shopNum1_Member.MemberRank = int.Parse(value3);
                            }
                            string value4 = ShopSettings.GetValue("RegPresentScore");
                            if (value4 == "" || value4 == null)
                            {
                                shopNum1_Member.Score = 0;
                            }
                            else
                            {
                                shopNum1_Member.Score = int.Parse(value4);
                            }
                            shopNum1_Member.LastLoginIP = null;
                            shopNum1_Member.LoginTime = 0;
                            shopNum1_Member.AdvancePayment = 0m;
                            shopNum1_Member.LockAdvancePayment = 0m;
                            shopNum1_Member.LockSocre = 0;
                            shopNum1_Member.CostMoney = 0m;
                            shopNum1_Member.IsMailActivation = 1;
                            shopNum1_Member.PayPwd = Encryption.GetMd5SecondHash(TextBoxPwd.Text.Trim().ToLower());
                            var shopNum1_MemberRank_Action =
                                (ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action();
                            DataTable defaultMemberRank = shopNum1_MemberRank_Action.GetDefaultMemberRank();
                            Guid memberRankGuid = Guid.NewGuid();
                            try
                            {
                                if (defaultMemberRank != null && defaultMemberRank.Rows.Count > 0)
                                {
                                    memberRankGuid = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
                                }
                                else
                                {
                                    memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                                }
                            }
                            catch (Exception)
                            {
                                memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                            }
                            shopNum1_Member.MemberRankGuid = memberRankGuid;
                            shopNum1_Member_Action.Add(shopNum1_Member);
                        }
                        else
                        {
                            if (rTN_UserLogin.Uid > 0 && num > 0)
                            {
                                shopNum1_Member_Action.UpdatePwd(rTN_UserLogin.UserName,
                                    Encryption.GetMd5Hash(rTN_UserLogin.PassWord));
                            }
                        }
                        rTN_UserLogin.Uid.ToString();
                        try
                        {
                            string script = Func.uc_user_synlogin(rTN_UserLogin.Uid);
                            HttpContext.Current.Response.AddHeader("P3P",
                                "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ucenter", script, false);
                            HttpCookie httpCookie2 = HttpSecureCookie.Encode(new HttpCookie("MemberLoginCookie")
                            {
                                Values =
                                {
                                    {
                                        "MemLoginID",
                                        rTN_UserLogin.UserName
                                    },

                                    {
                                        "Name",
                                        ""
                                    },

                                    {
                                        "IsMailActivation",
                                        "1"
                                    },

                                    {
                                        "MemberType",
                                        "1"
                                    }
                                }
                            });
                            httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(httpCookie2);
                            shopNum1_Member_Action.UpdateLoginTime(rTN_UserLogin.UserName, Page.Request.UserHostAddress);
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirecturl",
                                "window.location.href='" + str + "'", true);
                        }
                        catch
                        {
                        }
                    }
                }
                LabelLoginInfo.Text = "用户名或密码有误！";
            }
        }

        public void RaisePostBackEvent()
        {
            string arg = Page.Request.Form["secondEVENTTARGET"];
            if (func_0 == null)
            {
                func_0 = smethod_0;
            }
            Func<string, bool> func = func_0;
            func(arg);
        }

        private static bool smethod_0(string string_1)
        {
            var shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
            if (string_1 != null)
            {
                if (!(string_1 == "1"))
                {
                    if (!(string_1 == "2"))
                    {
                        if (!(string_1 == "3"))
                        {
                            if (!(string_1 == "4"))
                            {
                                if (string_1 == "5")
                                {
                                    DataTable model = shopNum1_SecondTypeBussiness.GetModel(5);
                                    new ShopNum1_TaobaoOAuthClient().GetAuthorizationUrl(
                                        model.Rows[0]["AppID"].ToString(),
                                        "http://" + ConfigurationManager.AppSettings["Domain"] +
                                        "/Main/Second/Taobao/TaobaoReturn.aspx");
                                }
                            }
                            else
                            {
                                var alipay_config = new ShopNum1_Alipay_config();
                                new ShopNum1_AlipayOAuthClient(alipay_config).GetAuthorizationUrl();
                            }
                        }
                        else
                        {
                            DataTable model = shopNum1_SecondTypeBussiness.GetModel(3);
                            if (model != null && model.Rows.Count != 0)
                            {
                                new ShopNum1_XinlanOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                                    "http://" + ConfigurationManager.AppSettings["Domain"] +
                                    "/Main/Second/Xinlan/XinlanReturn.aspx");
                            }
                        }
                    }
                    else
                    {
                        DataTable model = shopNum1_SecondTypeBussiness.GetModel(2);
                        if (model != null && model.Rows.Count != 0)
                        {
                            new ShopNum1_BaiduOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                                "http://" + ConfigurationManager.AppSettings["Domain"] +
                                "/Main/Second/Baidu/BaiduReturn.aspx");
                        }
                    }
                }
                else
                {
                    DataTable model = shopNum1_SecondTypeBussiness.GetModel(1);
                    if (model != null && model.Rows.Count != 0)
                    {
                        ShopNum1_QzoneCommonClient.GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(),
                            "http://" + ConfigurationManager.AppSettings["Domain"] +
                            "/Main/Second/Qzone/QzoneReturn.aspx");
                    }
                }
            }
            return true;
        }
    }
}