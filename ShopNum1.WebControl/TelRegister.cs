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
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class TelRegister : BaseWebControl
    {
        public static bool EnableRegister = true;
        private Button ButtonConfirm;
        private CheckBox CheckBoxIfAgree;
        private Label LabelMemLoginID;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxPwd;
        private TextBox TextBoxRePwd;
        private HtmlGenericControl divAgainregester;
        private HtmlGenericControl divregester;
        private string skinFilename = "TelRegister.ascx";

        public TelRegister()
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

        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopSettings.GetValue("RegIsEmail");
            string str = ShopSettings.GetValue("RegIsActivationEmail");
            string str2 = ShopSettings.GetValue("RegistOrderIsMMS");
            string newValue = ShopSettings.GetValue("Name");
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
            {
                MessageBox.Show("用户名已经被注册过了,请换一个用户名!");
            }
            else
            {
                var member = new ShopNum1_Member
                {
                    MemLoginID = TextBoxMemLoginID.Text,
                    MemberType = 1,
                    Name = "",
                    Pwd = Encryption.GetMd5Hash(TextBoxPwd.Text),
                    IsForbid = 0,
                    Email = "",
                    Guid = Guid.NewGuid(),
                    Mobile = TextBoxMemLoginID.Text,
                    AdvancePayment = 0,
                    AddressValue = "",
                    AddressCode = "",
                    RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    LoginDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsMailActivation = 1,
                    IsMobileActivation = 1
                };
                if (str == "0")
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
                string str5 = ShopSettings.GetValue("RegPresentScore");
                if ((str5 == "") || (str5 == null))
                {
                    member.Score = 0;
                }
                else
                {
                    member.Score = int.Parse(str5);
                }
                member.LastLoginIP = null;
                member.LoginTime = 0;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                member.PayPwd = Encryption.GetMd5SecondHash(TextBoxPwd.Text);
                member.IsMailActivation = 0;
                member.IsMobileActivation = 0;
                member.PromotionMemLoginID = "";
                if (action.Add(member) == 1)
                {
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
                    string str14 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                    if (str14.Trim() == "1")
                    {
                        DiscuzSession session = DiscuzSessionHelper.GetSession();
                        try
                        {
                            if (session.Register(member.MemLoginID, TextBoxPwd.Text.Trim(), "", false) > 0)
                            {
                                int uid = 0;
                                uid = session.GetUserID(member.MemLoginID);
                                session.Login(uid, TextBoxPwd.Text.Trim(), false, 100,
                                    ConfigurationManager.AppSettings["CookieDomain"]);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (ConfigurationManager.AppSettings["IsIntergrationTg"] == "1")
                    {
                        var section =
                            (AppSettingsSection)
                                WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath)
                                    .GetSection("appSettings");
                        string str9 = section.Settings["TgPostUrl"].Value;
                        string str10 = section.Settings["TgSourceKey"].Value;
                        if (method_0(string.Concat(new object[]
                        {
                            str9, "IntergrationMemberRegist.aspx?MemLoginID=", member.MemLoginID, "&Email=",
                            member.Email, "&Pwd=", member.Pwd, "&PayPwd=", member.PayPwd, "&Sex=", member.Sex,
                            "&Birthday=", member.Birthday, "&CreditMoney=", member.CreditMoney, "&Photo=",
                            member.Photo, "&RealName=", member.RealName, "&Area=", member.Area, "&Vocation=",
                            member.Vocation, "&Address=", member.Address, "&Postalcode=", member.Postalcode,
                            "&Mobile=", member.Mobile, "&Fax=", member.Fax, "&QQ=",
                            member.QQ, "&Msn=", member.Msn, "&WebSite=", member.WebSite, "&Question=",
                            member.Question, "&Answer=", member.Answer, "&RegDate=", member.RegeDate,
                            "&LastLoginDate=", member.LastLoginDate, "&LastLoginIP=", member.LastLoginIP,
                            "&LoginTime=",
                            DateTime.Now.ToString(), "&AdvancePayment=", member.AdvancePayment, "&Score=",
                            member.Score, "&RankScore=0&LockAdvancePayment=", member.LockAdvancePayment,
                            "&LockSocre=", member.LockSocre, "&CostMoney=", member.CostMoney, "&MemberRankGuid=",
                            Guid.Empty, "&TradeCount=0&CreateUser=admin&CreateTime=", DateTime.Now.ToString(),
                            "&ModifyUser=admin&ModifyTime=",
                            DateTime.Now.ToString(), "&TgSourceKey=", str10
                        })) != string.Empty)
                        {
                            string str12 =
                                string.Concat(new object[]
                                {
                                    str9, "IntergrationMemberLogin.aspx?MemLoginID=", member.MemLoginID,
                                    "&MemberRankGuid=", Guid.NewGuid(), "&Pwd=", member.Pwd, "&TgSourceKey=",
                                    section.Settings["TgSourceKey"].Value
                                });
                            string format = "<script src='{0}'></script>";
                            format = string.Format(format, str12);
                            Page.Response.Write(format);
                        }
                    }
                    if (str2 == "1")
                    {
                        ShopNum1_MMSGroupSend send;
                        var register = new Register
                        {
                            Email = "",
                            Name = TextBoxMemLoginID.Text.Trim(),
                            Password = TextBoxPwd.Text.Trim(),
                            ShopName = newValue,
                            SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        string str6 = string.Empty;
                        string mMsTitle = string.Empty;
                        string mmsGuid = "4A12724C-5154-4928-B867-D5BD180E80E6";
                        IShopNum1_MMS_Action action2 = LogicFactory.CreateShopNum1_MMS_Action();
                        DataTable editInfo = action2.GetEditInfo(mmsGuid, 0);
                        Guid.NewGuid().ToString();
                        if (editInfo.Rows.Count > 0)
                        {
                            str6 = editInfo.Rows[0]["Remark"].ToString();
                            mMsTitle = editInfo.Rows[0]["Title"].ToString();
                        }
                        str6 = register.ChangeRegister(Page.Server.HtmlDecode(str6));
                        var sms = new SMS();
                        str6 =
                            str6.Replace("{$Name}", TextBoxMemLoginID.Text)
                                .Replace("{$ShopName}", newValue)
                                .Replace("{$Password} ", member.Pwd)
                                .Replace("{$Email}", "")
                                .Replace("{$SendTime}", DateTime.Now.ToString());
                        string retmsg = "";
                        sms.Send(member.MemLoginID, str6 + "【唐江宝宝】", out retmsg);
                        if (retmsg.IndexOf("发送成功") != -1)
                        {
                            send = AddMMS(member.MemLoginID, member.MemLoginID, mMsTitle, 2, mmsGuid);
                            action2.AddMMSGroupSend(send);
                        }
                        else
                        {
                            send = AddMMS(TextBoxMemLoginID.Text.Trim(), member.MemLoginID, mMsTitle, 0,
                                "4a12724c-5154-4928-b867-d5bd180e80e6");
                            action2.AddMMSGroupSend(send);
                        }
                    }
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                        "window.location.href='" +
                        GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                        "?type=2&MemLoginID=" + TextBoxMemLoginID.Text.Trim() +
                        "'",
                        true);
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
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                try
                {
                    Page.Form.DefaultButton = "TelRegister$ctl00$ButtonConfirm";
                }
                catch
                {
                }
                divAgainregester.Visible = false;
                divregester.Visible = true;
                TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
                TextBoxPwd = (TextBox) skin.FindControl("TextBoxPwd");
                TextBoxRePwd = (TextBox) skin.FindControl("TextBoxRePwd");
                CheckBoxIfAgree = (CheckBox) skin.FindControl("CheckBoxIfAgree");
                ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
                ButtonConfirm.Click += ButtonConfirm_Click;
            }
            else
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                LabelMemLoginID.Text = cookie2.Values["MemLoginID"];
                divAgainregester.Visible = true;
                divregester.Visible = false;
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