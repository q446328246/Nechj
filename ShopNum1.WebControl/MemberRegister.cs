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

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MemberRegister : BaseWebControl
    {
        public static bool EnableRegister = true;
        private Button ButtonConfirm;
        private CheckBox CheckBoxIfAgree;
        private Label LabelMemLoginID;
        private TextBox TextBoxCode;
        private TextBox TextBoxEmail;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxMobile;
        private TextBox TextBoxPwd;
        private TextBox TextBoxRePwd;
        private HtmlTableRow VerifyCode;
        private HtmlGenericControl divAgainregester;
        private HtmlGenericControl divregester;
        private string skinFilename = "MemberRegister.ascx";

        public MemberRegister()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state,
            string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = mobile,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
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
                    MemLoginID = TextBoxMemLoginID.Text,
                    CreateUser = TextBoxMemLoginID.Text,
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
                    MemLoginID = TextBoxMemLoginID.Text,
                    CreateUser = TextBoxMemLoginID.Text,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
            }
        }

        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string str = ShopSettings.GetValue("RegIsEmail");
            string str2 = ShopSettings.GetValue("RegIsActivationEmail");
            ShopSettings.GetValue("RegistOrderIsMMS");
            string str3 = ShopSettings.GetValue("Name");
            var member = new ShopNum1_Member();
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if ((ShopSettings.GetValue("RegVerifyCode") == "1") &&
                ((Page.Session["code"] == null) ||
                 (TextBoxCode.Text.ToUpper() != Page.Session["code"].ToString().ToUpper())))
            {
                MessageBox.Show("验证码输入错误！");
            }
            else
            {
                Exception exception;
                if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text.Trim()))
                {
                    TextBoxEmail.Text = string.Empty;
                    TextBoxMobile.Text = string.Empty;
                    if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                    {
                        MessageBox.Show("用户名已经被注册过了,请换一个用户名!");
                        return;
                    }
                    member.MemLoginID = TextBoxMemLoginID.Text;
                }
                if (!string.IsNullOrEmpty(TextBoxMobile.Text.Trim()))
                {
                    TextBoxMemLoginID.Text = string.Empty;
                    TextBoxEmail.Text = string.Empty;
                    if (action.CheckMemMobileByMobile(TextBoxMobile.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
                        return;
                    }
                    member.MemLoginID = TextBoxMobile.Text.Trim();
                }
                if (!string.IsNullOrEmpty(TextBoxEmail.Text.Trim()))
                {
                    TextBoxMemLoginID.Text = string.Empty;
                    TextBoxMobile.Text = string.Empty;
                    if (action.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0)
                    {
                        MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
                        return;
                    }
                    member.MemLoginID = TextBoxEmail.Text.Trim();
                }
                if (!(string.IsNullOrEmpty(TextBoxEmail.Text.Trim()) || !str2.Equals("1")))
                {
                    member.IsForbid = 1;
                }
                else
                {
                    member.IsForbid = 0;
                }
                member.MemberType = 1;
                member.Name = "";
                member.Pwd = Encryption.GetMd5Hash(TextBoxPwd.Text);
                member.Email = TextBoxEmail.Text;
                member.Guid = Guid.NewGuid();
                member.Mobile = TextBoxMobile.Text;
                member.AdvancePayment = 0;
                member.AddressValue = "";
                member.AddressCode = "";
                member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.LoginDate = null;
                member.IsMobileActivation = 0;
                member.IsEmailActivation = "0";
                if ((Page.Request.QueryString["memberid"] != null) &&
                    !string.IsNullOrEmpty(Page.Request.QueryString["memberid"]))
                {
                    if (
                        !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_Member",
                            "   AND  MemLoginID='" +
                            HttpUtility.HtmlDecode(
                                Page.Request.QueryString["memberid"]) + "'")))
                    {
                        member.PromotionMemLoginID = HttpUtility.HtmlDecode(Page.Request.QueryString["memberid"]);
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
                DataTable defaultMemberRank =
                    ((ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action()).GetDefaultMemberRank();
                Guid guid2 = Guid.NewGuid();
                try
                {
                    if ((defaultMemberRank != null) && (defaultMemberRank.Rows.Count > 0))
                    {
                        guid2 = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
                    }
                    else
                    {
                        guid2 = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                    }
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    guid2 = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                }
                member.MemberRankGuid = guid2;
                string str10 = ShopSettings.GetValue("RegPresentScore");
                if ((str10 == "") || (str10 == null))
                {
                    member.Score = 0;
                }
                else
                {
                    member.Score = int.Parse(str10);
                }
                member.LastLoginIP = null;
                member.LoginTime = 1;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                if (action.Add(member) == 1)
                {
                    HttpCookie cookie;
                    HttpCookie cookie2;
                    string str4;
                    string str5;
                    string str6;
                    string str7;
                    string str8;
                    DataTable editInfo;
                    DataTable shopRankByMemLoginID;
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        try
                        {
                            string oldUser = string.Empty;
                            HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                            oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                            ((Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                                (oldUser,
                                    TextBoxMemLoginID
                                        .Text
                                        .Trim());
                            cookie3.Values.Clear();
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                        }
                    }
                    if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
                    {
                        try
                        {
                            string str20 = member.Email;
                            if (member.Email == "")
                            {
                                str20 = member.MemLoginID + "@163.com";
                            }
                            else
                            {
                                str20 = member.Email;
                            }
                            if (Func.uc_user_register(member.MemLoginID, TextBoxPwd.Text.Trim(), str20) > 0)
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
                    string str19 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                    if (str19.Trim() == "1")
                    {
                        DiscuzSession session = DiscuzSessionHelper.GetSession();
                        try
                        {
                            string str9 = member.Email;
                            if (member.Email == "")
                            {
                                str9 = member.MemLoginID + "@163.com";
                            }
                            else
                            {
                                str9 = member.Email;
                            }
                            if (session.Register(member.MemLoginID, TextBoxPwd.Text.Trim(), str9, false) > 0)
                            {
                                int uid = 0;
                                uid = session.GetUserID(member.MemLoginID);
                                session.Login(uid, TextBoxPwd.Text.Trim(), false, 100,
                                    ConfigurationManager.AppSettings["DiscuzCookieDomain"]);
                            }
                        }
                        catch (Exception exception3)
                        {
                            exception = exception3;
                        }
                    }
                    if (ConfigurationManager.AppSettings["IsIntergrationTg"] == "1")
                    {
                        var section =
                            (AppSettingsSection)
                                WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath)
                                    .GetSection("appSettings");
                        string str12 = section.Settings["TgPostUrl"].Value;
                        string str16 = section.Settings["TgSourceKey"].Value;
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
                            Guid.Empty, "&TradeCount=0&CreateUser=  &CreateTime=", DateTime.Now.ToString(),
                            "&ModifyUser= &ModifyTime=", DateTime.Now.ToString(), "&TgSourceKey=", str16
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
                        if (TextBoxEmail.Text == "")
                        {
                            cookie = new HttpCookie("MemberLoginCookie");
                            cookie.Values.Add("MemLoginID", member.MemLoginID);
                            cookie.Values.Add("Name", member.Name);
                            cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                            cookie.Values.Add("MemberType", member.MemberType.ToString());
                            if (member.MemberType.ToString() == "2")
                            {
                                var action3 =
                                    (Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                                shopRankByMemLoginID = action3.GetShopRankByMemLoginID(member.MemLoginID);
                                if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                                {
                                    cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                                }
                            }
                            cookie.Values.Add("UID", "-1");
                            cookie2 = HttpSecureCookie.Encode(cookie);
                            cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(cookie2);
                            if (TextBoxMemLoginID.Text != "")
                            {
                                Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                    "  and MemLoginID='" + TextBoxMemLoginID.Text + "'");
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                    "window.location.href='" +
                                    GetPageName.RetDomainUrl(
                                        "MemberRegisterSuccess") +
                                    "?type=2&MemLoginID=" +
                                    TextBoxMemLoginID.Text.Trim() + "'", true);
                            }
                            else if (TextBoxMobile.Text != "")
                            {
                                Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                    " and Mobile='" + TextBoxMobile.Text + "'");
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                    "window.location.href='" +
                                    GetPageName.RetDomainUrl(
                                        "MemberRegisterSuccess") +
                                    "?type=2&MemLoginID=" +
                                    TextBoxMobile.Text.Trim() + "'", true);
                            }
                        }
                        try
                        {
                            RegIsActivationEmail email;
                            str4 = Guid.NewGuid().ToString();
                            email = new RegIsActivationEmail
                            {
                                Email = TextBoxEmail.Text.Trim(),
                                Name = TextBoxMemLoginID.Text.Trim(),
                                link =
                                    GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str4 +
                                    "&type=0&email=" + TextBoxEmail.Text.Trim() + "&userID=" +
                                    TextBoxMemLoginID.Text.Trim(),
                                ShopName = str3,
                                SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            };
                            str5 = string.Empty;
                            str6 = string.Empty;
                            str7 = "7790bcf5-f88a-46bd-8ead-959118481c02";
                            str8 = string.Empty;
                            var action2 = new ShopNum1_Email_Action();
                            editInfo = action2.GetEditInfo("'" + str7 + "'", 0);
                            if (editInfo.Rows.Count > 0)
                            {
                                str5 = editInfo.Rows[0]["Remark"].ToString();
                                str6 = editInfo.Rows[0]["Title"].ToString();
                            }
                            str5 =
                                str5.Replace("{$Name}", email.Name)
                                    .Replace("{$PassWord}", TextBoxPwd.Text)
                                    .Replace("{$ShopName}", email.ShopName)
                                    .Replace("{$CheckUrl}", email.link)
                                    .Replace("{$SendTime}", email.SysSendTime);
                            str8 = email.ChangeRegister(Page.Server.HtmlDecode(str5));
                            SendMailForRegister(TextBoxMemLoginID.Text.Trim(), TextBoxEmail.Text.Trim(), str4, "", str6,
                                str7, str8);
                        }
                        catch (Exception exception4)
                        {
                            exception = exception4;
                            Context.Response.Write(exception.Message);
                        }
                    }
                    if ((str == "1") && (str2 == "0"))
                    {
                        var register = new Register
                        {
                            Email = TextBoxEmail.Text.Trim(),
                            Name = TextBoxMemLoginID.Text.Trim(),
                            Password = TextBoxPwd.Text.Trim(),
                            ShopName = str3,
                            SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        str5 = string.Empty;
                        str6 = string.Empty;
                        str7 = "4a12724c-5154-4928-b867-d5bd180e80e6";
                        str8 = string.Empty;
                        editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + str7 + "'", 0);
                        str4 = Guid.NewGuid().ToString();
                        if (editInfo.Rows.Count > 0)
                        {
                            str5 = editInfo.Rows[0]["Remark"].ToString();
                            str6 = editInfo.Rows[0]["Title"].ToString();
                        }
                        str8 = register.ChangeRegister(Page.Server.HtmlDecode(str5));
                        new SendEmail().Emails(TextBoxEmail.Text.Trim(), TextBoxMemLoginID.Text.Trim(), str6, str7, str8);
                    }
                    AddScroll();
                    if (str2 == "0")
                    {
                        cookie = new HttpCookie("MemberLoginCookie");
                        cookie.Values.Add("MemLoginID", member.MemLoginID);
                        cookie.Values.Add("Name", member.Name);
                        cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                        cookie.Values.Add("MemberType", member.MemberType.ToString());
                        if (member.MemberType.ToString() == "2")
                        {
                            shopRankByMemLoginID =
                                ((Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
                                    .GetShopRankByMemLoginID(member.MemLoginID);
                            if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                            {
                                cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                            }
                        }
                        cookie.Values.Add("UID", "-1");
                        cookie2 = HttpSecureCookie.Encode(cookie);
                        cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                        Page.Response.AppendCookie(cookie2);
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                            "window.location.href='" +
                            GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                            "?type=2&MemLoginID=" +
                            TextBoxMemLoginID.Text.Trim() + "'",
                            true);
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
            divAgainregester = (HtmlGenericControl) skin.FindControl("divAgainregester");
            divregester = (HtmlGenericControl) skin.FindControl("divregester");
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxPwd = (TextBox) skin.FindControl("TextBoxPwd");
            TextBoxRePwd = (TextBox) skin.FindControl("TextBoxRePwd");
            TextBoxEmail = (TextBox) skin.FindControl("TextBoxEmail");
            TextBoxMobile = (TextBox) skin.FindControl("TextBoxMobile");
            CheckBoxIfAgree = (CheckBox) skin.FindControl("CheckBoxIfAgree");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
            VerifyCode = (HtmlTableRow) skin.FindControl("VerifyCode");
            ButtonConfirm.Click += ButtonConfirm_Click;
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                divAgainregester.Visible = false;
                divregester.Visible = true;
                Page.Response.Expires = 0;
                Page.Response.Buffer = true;
                Page.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
                Page.Response.AddHeader("pragma", "no-cache");
                Page.Response.CacheControl = "no-cache";
            }
            else
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                LabelMemLoginID.Text = cookie2.Values["MemLoginID"];
                divAgainregester.Visible = true;
                divregester.Visible = false;
            }
            if (ShopSettings.GetValue("MemLoginVerifyCode") == "1")
            {
                VerifyCode.Visible = true;
            }
            else
            {
                VerifyCode.Visible = false;
            }
        }

        private string method_0(string string_1)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_1);
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