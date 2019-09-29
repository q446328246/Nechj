using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;
using ShopNum1.Standard;

namespace ShopNum1.Deploy.Main.Themes.Skin_Default.skins
{
    public partial class MemberMobileRegister : BaseUserControl
    {
        public static bool EnableRegister = true;

        protected void Page_Load(object sender, EventArgs e)
        {
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

        #region 手机注册
        protected void buttoninfo_Click(object sender, EventArgs e)
        {
            string str = ShopSettings.GetValue("RegIsEmail");
            string str2 = ShopSettings.GetValue("RegIsActivationEmail");

            ShopSettings.GetValue("RegistOrderIsMMS");
            string str3 = ShopSettings.GetValue("Name");

            var member = new ShopNum1_Member();

            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string key = M_code.Value;
            string mobilenumber = TextBoxMemLoginID.Text;
            var shopNum1_MemberActivate_Action =
                    (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            string iskey = shopNum1_MemberActivate_Action.CheckMobileCode(key, mobilenumber, "1");
            if (iskey == "0")
            {
                MessageBox.Show("验证码输入错误！");
            }
            else
            {
                string mobilepwd = new Random().Next(111111, 999999).ToString();

                Exception exception;

                if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text.Trim()))
                {
                    if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                    {
                        
                        TextBoxMemLoginID.Text = string.Empty;
                        MessageBox.Show("手机号码已经被注册过了,请换一个手机号码!");
                        return;
                    }
                    member.MemLoginID = TextBoxMemLoginID.Text;
                }


                member.Mobile = TextBoxMemLoginID.Text.Trim();



                member.Email = "";


                if (!(!str2.Equals("1")))
                {
                    member.IsForbid = 1;
                }
                else
                {
                    member.IsForbid = 0;
                }


                member.MemberType = 1;

                member.RealName = ""; //用户姓名
                member.IdentityCard = "";//用户身份证号
                member.MemLoginNO = action.GetMemberNumberRegister();
                member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(mobilepwd);
                member.PayPwd = ShopNum1.Common.Encryption.GetMd5SecondHash(mobilepwd);
                member.Guid = Guid.NewGuid();
                member.AdvancePayment = 0;
                member.AddressValue = "";
                member.AddressCode = "";
                member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.LoginDate = null;
                member.IsMobileActivation = 0;
                member.IsEmailActivation = "0";
                member.IsMobileRegister = 1;

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
                    ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).GetDefaultMemberRank();

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

                //注册赠积分
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

                member.Score1 = 0;
                member.Score2 = 0;
                member.Score3 = 0;
                member.Score4 = 0;
                member.Score5 = 0;
                member.Score6 = 0;

                //会员注册成功
                if (action.AddMobileResigter(member) == 1)
                {
                    var sms = new SMS();
                    string retmsg = "";
                    sms.Send(TextBoxMemLoginID.Text.Trim(), "尊敬的" + TextBoxMemLoginID.Text.Trim() + ":您的登录密码和交易密码为" + mobilepwd + "【唐江宝宝】", out retmsg);
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
                            ((Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
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
                            if (Func.uc_user_register(member.MemLoginID, mobilepwd, str20) > 0)
                            {
                                string script =
                                    Func.uc_user_synlogin(
                                        Func.uc_user_login(member.MemLoginID, mobilepwd).Uid);
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
                            if (session.Register(member.MemLoginID, mobilepwd, str9, false) > 0)
                            {
                                int uid = 0;
                                uid = session.GetUserID(member.MemLoginID);
                                session.Login(uid, mobilepwd, false, 100,
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
                            str12, "IntergrationMemberRegist.aspx?MemLoginID=", member.MemLoginID,"&MemLoginNO=",member.MemLoginNO, "&Email=",
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
                        if (member.Email == "")
                        {
                            cookie = new HttpCookie("MemberLoginCookie");
                            cookie.Values.Add("MemLoginID", member.MemLoginID);
                            cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                            cookie.Values.Add("Name", member.RealName);
                            cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                            cookie.Values.Add("MemberType", member.MemberType.ToString());
                            cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());
                            if (member.MemberType.ToString() == "2")
                            {
                                var action3 =
                                    (Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
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
                            
                        }

                        try
                        {
                            RegIsActivationEmail email;
                            str4 = Guid.NewGuid().ToString();
                            email = new RegIsActivationEmail
                            {
                                Email = member.Mobile,
                                Name = TextBoxMemLoginID.Text.Trim(),
                                link =
                                    GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str4 +
                                    "&type=0&email=" + member.Mobile + "&userID=" +
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
                                    .Replace("{$PassWord}", mobilepwd)
                                    .Replace("{$ShopName}", email.ShopName)
                                    .Replace("{$CheckUrl}", email.link)
                                    .Replace("{$SendTime}", email.SysSendTime);
                            str8 = email.ChangeRegister(Page.Server.HtmlDecode(str5));
                            SendMailForRegister(TextBoxMemLoginID.Text.Trim(), member.Mobile, str4, "", str6,
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
                            Email = member.Mobile,
                            Name = TextBoxMemLoginID.Text.Trim(),
                            Password = mobilepwd,
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
                        new SendEmail().Emails(member.Mobile, TextBoxMemLoginID.Text.Trim(), str6, str7, str8);
                    }

                    AddScroll();

                    if (str2 == "0")
                    {
                        cookie = new HttpCookie("MemberLoginCookie");
                        cookie.Values.Add("MemLoginID", member.MemLoginID);
                        cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                        cookie.Values.Add("Name", member.RealName);
                        cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                        cookie.Values.Add("MemberType", member.MemberType.ToString());
                        cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());

                        if (member.MemberType.ToString() == "2")
                        {
                            shopRankByMemLoginID =
                                ((Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
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
                            "?email=" + member.Mobile + "&id=" +
                            member.Mobile + "'", true);
                    }
                }
                else
                {
                    MessageBox.Show("注册失败!请重新注册");
                }
            }
        }
        #endregion
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
                ((ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
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
                ((ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
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
            var action = (ShopNum1_MemberEmailExec_Action)LogicFactory.CreateShopNum1_MemberEmailExec_Action();
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
