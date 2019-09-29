using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class poplogin : BaseWebControl
    {
        private Button ButtonLogin;
        private Button ButtonTwo;
        private HiddenField HiddenFieldLoginType;
        private Label LabelLoginInfo;
        private TextBox TextBoxCode;
        private TextBox TextBoxCode1;
        private TextBox TextBoxEmail;
        private TextBox TextBoxMemLoginID1;
        private TextBox TextBoxPwd;
        private TextBox TextBoxPwd1;
        private TextBox TextBoxRePwd;
        private HtmlGenericControl VerifyCode;
        private string skinFilename = "poplogin.ascx";
        private string string_1 = string.Empty;
        private TextBox textBox_0;

        public poplogin()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void AddScroll()
        {
            string s = ShopSettings.GetValue("RegPresentScore");
            string str2 = ShopSettings.GetValue("RegPresentRankScore");
            if (int.Parse(s) > 0)
            {
                var scoreModeLog = new ShopNum1_ScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = 0,
                    OperateScore = int.Parse(s),
                    LastOperateScore = int.Parse(s),
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = "注册赠送消费红包",
                    MemLoginID = textBox_0.Text,
                    CreateUser = textBox_0.Text,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_ScoreModifyLog_Action) LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
                    scoreModeLog);
            }
            if (int.Parse(str2) > 0)
            {
                var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = 0,
                    OperateScore = int.Parse(str2),
                    LastOperateScore = int.Parse(str2),
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = "注册赠送等级红包",
                    MemLoginID = textBox_0.Text,
                    CreateUser = textBox_0.Text,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
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
                if (TextBoxCode.Text.ToLower() != Page.Session["code"].ToString().ToLower())
                {
                    LabelLoginInfo.Text = "验证码不正确！";
                    return;
                }
            }
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            DataTable memberPassWord = null;
            memberPassWord = action.GetMemberPassWord(textBox_0.Text.Trim(),
                Encryption.GetMd5Hash(TextBoxPwd.Text.Trim()));
            if ((memberPassWord != null) && (memberPassWord.Rows.Count > 0))
            {
                if (memberPassWord.Rows[0]["IsForbid"].ToString() == "1")
                {
                    LabelLoginInfo.Text = "对不起，您的账户已被禁用！";
                }
                else
                {
                    var cookie = new HttpCookie("MemberLoginCookie");
                    cookie.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
                    cookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
                    cookie.Values.Add("IsMailActivation", memberPassWord.Rows[0]["IsMailActivation"].ToString());
                    cookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
                    cookie.Values.Add("MemRankGuid", memberPassWord.Rows[0]["MemberRankGuid"].ToString());
                    if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
                    {
                        DataTable shopRankByMemLoginID =
                            ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                                .GetShopRankByMemLoginID(memberPassWord.Rows[0]["MemLoginID"].ToString());
                        if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                        {
                            cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                        }
                    }
                    cookie.Values.Add("UID", "-1");
                    HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                    cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie2);
                    action.UpdateLoginTime(textBox_0.Text.Trim(), Page.Request.UserHostAddress);
                    if (Page.Request.QueryString["goback"] != null)
                    {
                        string_1 = Page.Request.QueryString["goback"];
                    }
                    else
                    {
                        string_1 = GetPageName.RetDomainUrl("index");
                    }
                    if (Page.Request.QueryString["vj"] != null)
                    {
                        Page.Response.Write("<script>parent.location.href='" + Page.Request.QueryString["backurl"] + "&category=" + CookieCustomerCategory +
                                            "';</script>");
                    }
                }
            }
            else
            {
                LabelLoginInfo.Text = "用户名或密码有误！";
            }
        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("商城不支持本方式注册，请正常注册！");
            return;
            string str = ShopSettings.GetValue("RegIsEmail");
            string str2 = ShopSettings.GetValue("RegIsActivationEmail");
            ShopSettings.GetValue("RegistOrderIsMMS");
            string str3 = ShopSettings.GetValue("Name");
            var member = new ShopNum1_Member();
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if ((ShopSettings.GetValue("RegVerifyCode") == "1") &&
                ((Page.Session["code"] == null) ||
                 (TextBoxCode1.Text.ToLower() != Page.Session["code"].ToString().ToLower())))
            {
                MessageBox.Show("验证码输入错误！");
            }
            else
            {
                if (TextBoxMemLoginID1.Text.Trim() != "")
                {
                    if (action.CheckmemLoginID(TextBoxMemLoginID1.Text.Trim()) > 0)
                    {
                        MessageBox.Show("用户名已经被注册过了,请换一个用户名!");
                        return;
                    }
                    member.MemLoginID = TextBoxMemLoginID1.Text;
                }
                if (TextBoxEmail.Text.Trim() != "")
                {
                    if (action.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0)
                    {
                        MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
                        return;
                    }
                    member.MemLoginID = TextBoxMemLoginID1.Text.Trim();
                }
                member.MemberType = 1;
                member.Name = "";
                member.Pwd = Encryption.GetMd5Hash(TextBoxRePwd.Text);
                member.IsForbid = 0;
                member.Email = TextBoxEmail.Text;
                member.Guid = Guid.NewGuid();
                member.AdvancePayment = 0;
                member.AddressValue = "";
                member.AddressCode = "";
                member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.LoginDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.IsMobileActivation = 0;
                member.IsEmailActivation = "0";
                if ((Page.Request.QueryString["memberid"] != null) &&
                    !string.IsNullOrEmpty(Page.Request.QueryString["memberid"]))
                {
                    if (
                        !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_Member",
                            "   AND  MemLoginID='" +
                            Page.Request.QueryString["memberid"] + "'")))
                    {
                        member.PromotionMemLoginID = Page.Request.QueryString["memberid"];
                    }
                    else
                    {
                        member.PromotionMemLoginID = "";
                    }
                }
                else
                {
                    member.PromotionMemLoginID = "";
                }
                if (str2 == "0")
                {
                    member.IsMailActivation = 1;
                }
                else
                {
                    member.IsMailActivation = 0;
                }
                string s = ShopSettings.GetValue("RegPresentRankScore");
                if ((s == "") || (s == null))
                {
                    member.MemberRank = 0;
                }
                else
                {
                    member.MemberRank = int.Parse(s);
                }
                string str4 = ShopSettings.GetValue("RegPresentScore");
                if ((str4 == "") || (str4 == null))
                {
                    member.Score = 0;
                }
                else
                {
                    member.Score = int.Parse(str4);
                }
                member.LastLoginIP = null;
                member.LoginTime = 1;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                if (action.Add(member) == 1)
                {
                    DataTable editInfo;
                    string str6;
                    string str7;
                    string str8;
                    string str9;
                    Exception exception;
                    string str21;
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        try
                        {
                            string oldUser = string.Empty;
                            HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                            oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                            ((Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                                (oldUser, textBox_0.Text.Trim());
                            cookie3.Values.Clear();
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
                        }
                    }
                    if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
                    {
                        try
                        {
                            if (Func.uc_user_register(member.MemLoginID, TextBoxPwd.Text.Trim(), member.Email) > 0)
                            {
                                string script =
                                    Func.uc_user_synlogin(
                                        Func.uc_user_login(member.MemLoginID, TextBoxPwd.Text.Trim()).Uid);
                                HttpContext.Current.Response.AddHeader("P3P",
                                    "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msgok", script, false);
                            }
                        }
                        catch
                        {
                        }
                    }
                    string str11 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                    if (str11.Trim() == "1")
                    {
                        DiscuzSession session = DiscuzSessionHelper.GetSession();
                        try
                        {
                            if (
                                session.Register(member.MemLoginID, TextBoxRePwd.Text.Trim(), TextBoxEmail.Text.Trim(),
                                    false) >
                                0)
                            {
                                int userID = 0;
                                userID = session.GetUserID(member.MemLoginID);
                                session.Login(userID, TextBoxPwd.Text.Trim(), false, 100,
                                    ConfigurationManager.AppSettings["CookieDomain"]);
                            }
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                        }
                    }
                    if (ConfigurationManager.AppSettings["IsIntergrationTg"] == "1")
                    {
                        var section =
                            (AppSettingsSection)
                                WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath)
                                    .GetSection("appSettings");
                        string str12 = section.Settings["TgPostUrl"].Value;
                        string str19 = section.Settings["TgSourceKey"].Value;
                        if (method_0(string.Concat(new object[]
                        {
                            str12, "IntergrationMemberRegist.aspx?MemLoginID=", member.MemLoginID, "&Email=",
                            member.Email, "&Pwd=", member.Pwd, "&PayPwd=", member.PayPwd, "&Sex=", member.Sex,
                            "&Birthday=", member.Birthday, "&Photo=", member.Photo, "&RealName=",
                            member.RealName, "&Area=", member.Address, "&Vocation=", member.Vocation, "&Address=",
                            member.Address, "&Postalcode=", member.Postalcode, "&Fax=", member.Fax, "&QQ=",
                            member.QQ, "&WebSite=", member.WebSite, "&Question=",
                            member.Question, "&Answer=", member.Answer, "&RegDate=", member.RegeDate,
                            "&LastLoginDate=", member.LastLoginDate, "&LastLoginIP=", member.LastLoginIP,
                            "&LoginTime=", DateTime.Now.ToString(), "&AdvancePayment=", member.AdvancePayment,
                            "&Score=", member.Score, "&RankScore=0&LockAdvancePayment=",
                            member.LockAdvancePayment, "&LockSocre=", member.LockSocre, "&MemberRankGuid=",
                            Guid.Empty, "&TradeCount=0&CreateUser=admin&CreateTime=", DateTime.Now.ToString(),
                            "&ModifyUser=admin&ModifyTime=", DateTime.Now.ToString(), "&TgSourceKey=", str19
                        })) != string.Empty)
                        {
                            string str13 =
                                string.Concat(new object[]
                                {
                                    str12, "IntergrationMemberLogin.aspx?MemLoginID=", member.MemLoginID,
                                    "&MemberRankGuid=", Guid.NewGuid(), "&Pwd=", member.Pwd, "&TgSourceKey=",
                                    section.Settings["TgSourceKey"].Value
                                });
                            string format = "<script src='{0}'></script>";
                            format = string.Format(format, str13);
                            Page.Response.Write(format);
                        }
                    }
                    if (str2 == "1")
                    {
                        if ((TextBoxEmail.Text == "") && (textBox_0.Text != ""))
                        {
                            Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                "  and MemLoginID='" + textBox_0.Text + "'");
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                "window.location.href='" +
                                GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                                "?type=2&MemLoginID=" + textBox_0.Text.Trim() +
                                "'", true);
                        }
                        try
                        {
                            str21 = Guid.NewGuid().ToString();
                            var email2 = new RegIsActivationEmail();
                            email2.Email = TextBoxEmail.Text.Trim();
                            email2.Name = textBox_0.Text.Trim();
                            email2.link = GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str21 +
                                          "&type=0&email=" + email2.Email + "&userID=" + textBox_0.Text.Trim();
                            email2.ShopName = str3;
                            email2.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            str6 = string.Empty;
                            str7 = string.Empty;
                            str9 = "7790bcf5-f88a-46bd-8ead-959118481c02";
                            str8 = string.Empty;
                            var action4 = new ShopNum1_Email_Action();
                            editInfo = action4.GetEditInfo("'" + str9 + "'", 0);
                            if (editInfo.Rows.Count > 0)
                            {
                                str6 = editInfo.Rows[0]["Remark"].ToString();
                                str7 = editInfo.Rows[0]["Title"].ToString();
                            }
                            str6 =
                                str6.Replace("{$Name}", email2.Name)
                                    .Replace("{$PassWord}", TextBoxPwd.Text)
                                    .Replace("{$ShopName}", email2.ShopName)
                                    .Replace("{$CheckUrl}", email2.link)
                                    .Replace("{$SendTime}", email2.SysSendTime);
                            str8 = email2.ChangeRegister(Page.Server.HtmlDecode(str6));
                            SendMailForRegister(textBox_0.Text.Trim(), TextBoxEmail.Text.Trim(), str21, "", str7, str9,
                                str8);
                        }
                        catch (Exception exception3)
                        {
                            exception = exception3;
                            Context.Response.Write(exception.Message);
                        }
                    }
                    if ((str == "1") && (str2 == "0"))
                    {
                        var register = new Register();
                        register.Email = TextBoxEmail.Text.Trim();
                        register.Name = textBox_0.Text.Trim();
                        register.Password = TextBoxPwd.Text.Trim();
                        register.ShopName = str3;
                        register.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        str6 = string.Empty;
                        str7 = string.Empty;
                        str9 = "4a12724c-5154-4928-b867-d5bd180e80e6";
                        str8 = string.Empty;
                        editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + str9 + "'", 0);
                        str21 = Guid.NewGuid().ToString();
                        if (editInfo.Rows.Count > 0)
                        {
                            str6 = editInfo.Rows[0]["Remark"].ToString();
                            str7 = editInfo.Rows[0]["Title"].ToString();
                        }
                        str8 = register.ChangeRegister(Page.Server.HtmlDecode(str6));
                        new SendEmail().Emails(TextBoxEmail.Text.Trim(), textBox_0.Text.Trim(), str7, str9, str8);
                    }
                    AddScroll();
                    if (str2 == "0")
                    {
                        var cookie = new HttpCookie("MemberLoginCookie");
                        cookie.Values.Add("MemLoginID", member.MemLoginID);
                        cookie.Values.Add("Name", member.Name);
                        cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                        cookie.Values.Add("MemberType", member.MemberType.ToString());
                        if (member.MemberType.ToString() == "2")
                        {
                            DataTable shopRankByMemLoginID =
                                ((Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
                                    .GetShopRankByMemLoginID(member.MemLoginID);
                            if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                            {
                                cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                            }
                        }
                        cookie.Values.Add("UID", "-1");
                        HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                        cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                        Page.Response.AppendCookie(cookie2);
                        Page.Response.Write("<script>parent.location.href='" + Page.Request.QueryString["backurl"] +
                                            "';</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                            "window.location.href='" +
                            GetPageName.RetDomainUrl("E-mailVerification") +
                            "?email=" + TextBoxEmail.Text.Trim() + "&id=" +
                            TextBoxEmail.Text.Trim() + "'", true);
                    }
                }
                else
                {
                    MessageBox.Show("注册失败!请重新注册");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            textBox_0 = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxPwd = (TextBox) skin.FindControl("TextBoxPwd");
            TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
            LabelLoginInfo = (Label) skin.FindControl("LabelLoginInfo");
            ButtonLogin = (Button) skin.FindControl("ButtonLogin");
            ButtonLogin.Click += ButtonLogin_Click;
            VerifyCode = (HtmlGenericControl) skin.FindControl("VerifyCode");
            HiddenFieldLoginType = (HiddenField) skin.FindControl("HiddenFieldLoginType");
            TextBoxMemLoginID1 = (TextBox) skin.FindControl("TextBoxMemLoginID1");
            TextBoxEmail = (TextBox) skin.FindControl("TextBoxEmail");
            TextBoxPwd1 = (TextBox) skin.FindControl("TextBoxPwd1");
            TextBoxRePwd = (TextBox) skin.FindControl("TextBoxRePwd");
            TextBoxCode1 = (TextBox) skin.FindControl("TextBoxCode1");
            ButtonTwo = (Button) skin.FindControl("ButtonTwo");
            ButtonTwo.Click += ButtonTwo_Click;
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                if (ShopSettings.GetValue("MemLoginVerifyCode") == "1")
                {
                    VerifyCode.Visible = true;
                }
                else
                {
                    VerifyCode.Visible = false;
                }
            }
            else
            {
                if (Page.Request.QueryString["goback"] != null)
                {
                    string_1 = Page.Request.QueryString["goback"];
                }
                else
                {
                    string_1 = GetPageName.RetDomainUrl("index");
                }
                if (Page.Request.QueryString["vj"] != null)
                {
                    Page.Response.Write("<script>parent.location.href='" + Page.Request.QueryString["backurl"] +
                                        "';</script>");
                }
            }
        }

        private string method_0(string string_2)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_2);
            try
            {
                request.Timeout = 0xbb8;
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle,
            string emailTemplentGuid, string emailBody)
        {
            var action = (ShopNum1_MemberEmailExec_Action) LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            var memberEmailExec = new ShopNum1_MemberEmailExec
            {
                ExtireTime = DateTime.Now.AddHours(24.0),
                Email = Email,
                Emailkey = Emailkey,
                Guid = Guid.NewGuid(),
                Isinvalid = 0,
                MemberID = MemLoginID,
                Phone = Phone,
                Type = 0
            };
            if (action.MemberEmailInsert(memberEmailExec) > 0)
            {
                new SendEmail().Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
            }
        }
    }
}