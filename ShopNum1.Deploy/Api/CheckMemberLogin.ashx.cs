using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// CheckMemberLogin 的摘要说明
    /// </summary>
    public class CheckMemberLogin : IHttpHandler, IRequiresSessionState
    {

        string strAction = "";
        string agenturl_0 = "";


        #region 邮件设置
        string strEmailServer = string.Empty;
        string strSMTP = string.Empty;
        string strEmailAccount = string.Empty;
        string strServerPort = string.Empty;
        string strEmailPassword = string.Empty;
        string strRestoreEmail = string.Empty;
        string strEmailCode = string.Empty;
        //记录发送邮件的Title
        string strTitle = string.Empty;
        #endregion


        public void ProcessRequest(HttpContext context)
        {
            strAction = context.Request["type"];
            agenturl_0 = context.Request["agenturl"] == null ? "" : context.Request["agenturl"].ToString();
            if (strAction == null)
            {
                return;
            }
            switch (strAction.ToLower())
            {
                // params={"type":"memregist","agentID":"","memid":memid,"pwd":pwd,"email":email,"RealName":RealName};
                //case "memregist":
                //    string regagentID = context.Request["agentID"] == null ? "" : context.Request["agentID"].ToString();
                //    string regmemid = context.Request["memid"] == null ? "" : context.Request["memid"].ToString();
                //    string regpwd = context.Request["pwd"] == null ? "" : context.Request["pwd"].ToString();
                //    string regemail = context.Request["email"] == null ? "" : context.Request["email"].ToString();
                //    string regRealName = context.Request["RealName"] == null ? "" : context.Request["RealName"].ToString();
                //    string regMobile = context.Request["Mobile"] == null ? "" : context.Request["Mobile"].ToString();
                //    context.Response.Write(Memregist(regagentID, regmemid, regpwd, regemail, regRealName));
                //    break;
                case "getverifycode":
                    string verifycodetype = context.Request["code"] == null ? "" : context.Request["code"].ToString();
                    context.Response.Write(CheckCode(verifycodetype));
                    break;
                //找回密码页面 验证码
                case "findpwdverifycode":
                    string findpwdverifycode = context.Request["findpwdcode"] == null ? "" : context.Request["findpwdcode"].ToString();
                    context.Response.Write(CheckFindPwdCode(findpwdverifycode));
                    break;

                //用户ID是否存在
                case "userisexist":
                    string strUserID = context.Request["UserID"];
                    strUserID = HttpUtility.UrlDecode(context.Request["UserID"].ToString().Trim(), System.Text.Encoding.GetEncoding("gb2312"));//中文编码

                    context.Response.Write(ExistMemLoginID(strUserID));
                    break;
                //Email是否已被注册
                case "emailisexist":
                    string strEmail = context.Request["Email"];
                    context.Response.Write(ExistEmail(strEmail));
                    break;
                //检查身份证号是否存在
                case "identifycardisexist":
                    string identifyCard = context.Request["identifyCard"];
                    context.Response.Write(ExistIdentifyCard(identifyCard));
                    break;
                //检查身份证号是否存在
                case "identifycardisexist2":
                    string identifyCard3 = context.Request["identifyCard"];
                    context.Response.Write(ExistIdentifyCard2(identifyCard3));
                    break;

                //Model是否已被注册
                case "mobileisexist":
                    string strMobile = context.Request["Mobile"];
                    context.Response.Write(ExistMobile(strMobile));
                    break;
                //Email是否已被注册 找回密码
                case "emailisexistfind":
                    string strEmailFind = context.Request["Email"];
                    context.Response.Write(ExistEmailForFind(strEmailFind));
                    break;

                //Email是否已被注册 找回密码
                case "emailisexistfindv":
                    string strEmailFindV2 = context.Request["Email"];
                    string strUserId2 = context.Request["User"];
                    context.Response.Write(ExistEmailForFindv(strEmailFindV2, strUserId2));
                    break;
                //Model是否已被注册 找回密码
                case "mobileisexistfind":
                    string strMobileFind = context.Request["Mobile"];
                    context.Response.Write(ExistMobileForFind(strMobileFind));
                    break;

                //Model是否已被注册 找回密码
                case "mobileisexistfindv":
                    string strMobileFindV2 = context.Request["Mobile"];
                    string strUserId = context.Request["User"];
                    context.Response.Write(ExistMobileForFindv(strMobileFindV2, strUserId));
                    break;


                //发送邮件 找回密码
                case "sendemail":
                    string strSendEmailFind = context.Request["Email"];
                    context.Response.Write(FindPwdByEmail(strSendEmailFind));
                    break;
                //发送邮件 找回密码
                case "sendemailv":
                    string strSendEmailFindv = context.Request["Email"];
                    string strMemberIdv = context.Request["User"];
                    context.Response.Write(FindPwdByEmail(strSendEmailFindv, strMemberIdv));
                    break;
                //发送短信 找回密码
                case "sendemobile":
                    string strSendMobileFind = context.Request["Mobile"];
                    string strMemberId = context.Request["memberid"];
                    context.Response.Write(FindPwdByTel(strSendMobileFind, strMemberId));
                    break;
                case "sendemobilev":
                    string strSendMobileFindv = context.Request["Mobile"];
                    string strMemberIdv2 = context.Request["User"];
                    context.Response.Write(FindPwdByTel(strSendMobileFindv, strMemberIdv2));
                    break;
                //短信验证码 找回密码
                case "membermobileexec":
                    string strMobileCode = context.Request["MobileCode"];
                    string strttelx = context.Request["tel"];
                    context.Response.Write(MemberMobileExec(strMobileCode, strttelx, ""));
                    break;
                //手机注册发送验证码
                case "insertcode":
                    string strmobile = context.Request["Mobile"];
                    context.Response.Write(SendCodeForCheck(strmobile)); break;
                //验证码是否存在
                case "checkexistcode":
                    strmobile = context.Request["key"];
                    string strttel = context.Request["tel"];
                    context.Response.Write(MemberMobileExec(strmobile, strttel, "1")); break;
                default:
                    break;
            }
        }
        //private string Memregist(string agentID, string memid, string pwd, string email, string RealName)
        //{
        //    string strRegIsEmail = ShopSettings.GetValue("RegIsEmail");
        //    string strRegIsActivationEmail = ShopSettings.GetValue("RegIsActivationEmail");
        //    string strRegIsMMS = ShopSettings.GetValue("RegIsMMS");
        //    string strShopName = ShopSettings.GetValue("Name");
        //    ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //    ShopNum1_Member member = new ShopNum1_Member();
        //    member.MemLoginID = memid;
        //    member.MemberType = 1;
        //    member.Name = "";
        //    member.Pwd = Encryption.GetMd5Hash(pwd);
        //    member.IsForbid = 0;
        //    member.Email = email;
        //    member.Guid = Guid.NewGuid();
        //    member.Tel = "";
        //    member.AdvancePayment = 0;
        //    member.AddressValue = "";
        //    member.AddressCode = "";
        //    member.RegeDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    member.LoginDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    if (strRegIsActivationEmail == "0")
        //    {
        //        member.IsMailActivation = 1;//2012-09-04添加 已经激活
        //    }
        //    else
        //    {
        //        member.IsMailActivation = 0;//2012-09-04添加 没有激活
        //    }
        //    string RankScore = ShopSettings.GetValue("RegPresentRankScore");
        //    if (RankScore == "" || RankScore == null)
        //    {
        //        member.MemberRank = 0;
        //    }
        //    else
        //    {
        //        member.MemberRank = int.Parse(RankScore);
        //    }
        //    string Score = ShopSettings.GetValue("RegPresentScore");
        //    if (Score == "" || Score == null)
        //    {
        //        member.Score = 0;
        //    }
        //    else
        //    {
        //        member.Score = int.Parse(Score);
        //    }
        //    member.LastLoginIP = null;
        //    member.LoginTime = 0;
        //    member.AdvancePayment = 0;
        //    member.LockAdvancePayment = 0;
        //    member.LockSocre = 0;
        //    member.CostMoney = 0;
        //    member.PayPwd = Encryption.GetMd5SecondHash(pwd);
        //    member.PromotionMemLoginID = "";
        //    member.IsMailActivation = 0;
        //    member.IsMobileActivation = 0;
        //    if (memberAction.Add(member) == 1)
        //    {
        //        //集成UCenter
        //        string IsInterationUCDiscuz = ConfigurationManager.AppSettings["IsIntergrationUCenter"].ToString();
        //        if (IsInterationUCDiscuz == "1")
        //        {
        //            try
        //            {
        //                int ir = Func.uc_user_register(member.MemLoginID, pwd, member.Email);
        //                //用户成功注册以后 才登陆
        //                if (ir > 0)
        //                {

        //                    RTN_UserLogin rtnUserLogin = Func.uc_user_login(member.MemLoginID, pwd);
        //                    string tologin = Func.uc_user_synlogin(rtnUserLogin.Uid);
        //                    HttpContext.Current.Response.AddHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
        //                    //HttpContext.Current.ClientScript.RegisterClientScriptBlock(HttpContext.Current.GetType(), "msgok", tologin, false);
        //                }
        //            }
        //            catch
        //            {
        //            }
        //        }
        //        //如果操作执行Discuz！NT3.5
        //        string strIsInterationDiscuz = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
        //        if (strIsInterationDiscuz.Trim().ToString() == "1")
        //        {
        //            DiscuzSession ds = DiscuzSessionHelper.GetSession();
        //            try
        //            {
        //                if (ds.Register(member.MemLoginID, pwd, email, false) > 0)
        //                {
        //                    int userId = 0;
        //                    userId = ds.GetUserID(member.MemLoginID);
        //                    ds.Login(userId, pwd, false, 100, ConfigurationManager.AppSettings["CookieDomain"]);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //        //本地登陆 并发送邮件和短信
        //        //先确定是否需要发关邮件0--不发送邮件1-发送
        //        if (strRegIsActivationEmail == "1")
        //        {
        //            //发送激活邮件
        //            string key = Guid.NewGuid().ToString();
        //            RegIsActivationEmail IsActivationEmail = new RegIsActivationEmail();
        //            ////E - mail
        //            IsActivationEmail.Email = email;
        //            ////用 户 名
        //            IsActivationEmail.Name = memid;
        //            ////用户密码
        //            IsActivationEmail.link = GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + key + "&type=0&userID=" + memid;
        //            ////商城名称
        //            IsActivationEmail.ShopName = strShopName;
        //            //系统回复时间
        //            IsActivationEmail.SysSendTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            //邮件内容,从模块中读出来
        //            string strcontent = string.Empty;
        //            string strTitle = string.Empty;
        //            string emailTemplentGuid = "27815f7e-8f56-4f6d-afcb-edb099f16f60";
        //            string emailBody = string.Empty;
        //            ShopNum1_Email_Action emailAction = new ShopNum1_Email_Action();
        //            DataTable dataTabelemailAction = emailAction.GetEditInfo("'" + emailTemplentGuid + "'", 0);

        //            if (dataTabelemailAction.Rows.Count > 0)
        //            {
        //                strcontent = dataTabelemailAction.Rows[0]["Remark"].ToString();
        //                strTitle = dataTabelemailAction.Rows[0]["Title"].ToString();
        //            }
        //            emailBody = IsActivationEmail.ChangeRegister(HttpContext.Current.Server.HtmlDecode(strcontent));
        //            SendMailForRegister(memid, email, key, "", strTitle, emailTemplentGuid, emailBody);
        //        }
        //        if (strRegIsEmail == "1")
        //        {
        //            //发送欢迎邮件
        //            Register register = new Register();
        //            ////E - mail
        //            register.Email = email;
        //            ////用 户 名
        //            register.Name = memid;
        //            ////用户密码
        //            register.Password = pwd;
        //            ////商城名称
        //            register.ShopName = strShopName;
        //            //系统回复时间
        //            register.SysSendTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            //邮件内容,从模块中读出来
        //            string strcontent = string.Empty;
        //            string strTitle = string.Empty;
        //            string emailTemplentGuid = "4bd008be-cb3d-4350-9396-008987fd0df4";
        //            string emailBody = string.Empty;
        //            ShopNum1_Email_Action emailAction = new ShopNum1_Email_Action();
        //            DataTable dataTabelemailAction = emailAction.GetEditInfo("'" + emailTemplentGuid + "'", 0);
        //            string key = Guid.NewGuid().ToString();
        //            if (dataTabelemailAction.Rows.Count > 0)
        //            {
        //                strcontent = dataTabelemailAction.Rows[0]["Remark"].ToString();
        //                strTitle = dataTabelemailAction.Rows[0]["Title"].ToString();
        //            }
        //            emailBody = register.ChangeRegister(HttpContext.Current.Server.HtmlDecode(strcontent));
        //            //执行发送邮件的功能
        //            SendEmail sendEmail = new SendEmail();
        //            sendEmail.Emails(email, memid, strTitle, emailTemplentGuid, emailBody);
        //        }
        //        //将登录名写入Cookie
        //        HttpCookie logincookie = new HttpCookie("MemberLoginCookie");
        //        //将登录ID写到cookie
        //        logincookie.Values.Add("MemLoginID", memid.Trim());
        //        //将会员等级Guid写到Cookie
        //        //加密Cookie
        //        HttpCookie encodeCookie = HttpSecureCookie.Encode(logincookie);
        //        encodeCookie.Domain = System.Configuration.ConfigurationManager.AppSettings["CookieDomain"].ToString();
        //        //HttpContext.Current.Response.AppendCookie(encodeCookie);
        //        HttpContext.Current.Response.AppendCookie(encodeCookie);
        //        return "true";
        //    }
        //    else
        //    {
        //        return "false";
        //    }
        //}
        //发送邮箱进行验证
        //private MailMessage mailMessage;  
        //private SmtpClient smtpClient;  
        //private string password;//发件人密码
        public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle, string emailTemplentGuid, string emailBody)
        {
            ShopNum1_MemberEmailExec_Action MemberEmailExec_Action = (ShopNum1_MemberEmailExec_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            ShopNum1_MemberEmailExec MemberEmailExec = new ShopNum1_MemberEmailExec();
            //当前时间的24小时后面
            MemberEmailExec.ExtireTime = DateTime.Now.AddHours(24);
            MemberEmailExec.Email = Email;
            MemberEmailExec.Emailkey = Emailkey;
            MemberEmailExec.Guid = Guid.NewGuid();
            MemberEmailExec.Isinvalid = 0;
            MemberEmailExec.MemberID = MemLoginID;
            MemberEmailExec.Phone = Phone;
            MemberEmailExec.Type = 0;
            int k = MemberEmailExec_Action.MemberEmailInsert(MemberEmailExec);
            if (k > 0)
            {
                //执行发送邮件的功能
                SendEmail sendEmail = new SendEmail();
                sendEmail.Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
            }
        }
        //用户名，昵称，邮箱,手机 是否存在
        public string ExistMemLoginID(string memloginid)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

            if (memberAction.CheckmemLoginID(memloginid) > 0)
            {

                return "true";
            }
            return "false";
        }

        public string ExistEmail(string email)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (memberAction.CheckmemEmail(email) > 0)
            {
                return "true";
            }
            return "false";
        }

        /// <summary>
        /// 检查身份证号是否存在
        /// </summary>
        /// <param name="identifyCard"></param>
        /// <returns></returns>
        public string ExistIdentifyCard(string identifyCard)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (memberAction.CheckIdentityCard(identifyCard) > 0)
            {
                return "true";
            }
            return "false";
        }

        /// <summary>
        /// 检查身份证号是否存在
        /// </summary>
        /// <param name="identifyCard"></param>
        /// <returns></returns>
        public string ExistIdentifyCard2(string identifyCard)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (memberAction.CheckIdentityCard2(identifyCard) > 0)
            {
                return "true";
            }
            return "false";
        }

        //CheckMobile
        public string ExistMobile(string mobile)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (memberAction.CheckMobile(mobile) > 0)
            {
                return "true";
            }
            return "false";
        }
        private string serverReturn;
        //注册 验证码
        private string CheckCode(string verifycodetype)
        {
            if (verifycodetype.ToLower() == HttpContext.Current.Session["code"].ToString().ToLower())
            {
                return "true";
            }

            return "false";
        }
        // 找回密码页面 验证码
        private string CheckFindPwdCode(string verifycodetype)
        {
            if (verifycodetype.ToLower() == HttpContext.Current.Session["code"].ToString().ToLower())
            {
                return "true";
            }

            return "false";
        }
        //CheckMobile
        public string ExistMobileForFind(string mobile)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable datatable = memberAction.CheckMemMobileByMobile(mobile);
            if (datatable.Rows.Count > 0)
            {
                return "true," + datatable.Rows[0]["MemLoginID"].ToString() + "," + datatable.Rows[0]["Mobile"].ToString();

            }
            return "false";
        }

        //CheckMobile
        public string ExistMobileForFindv(string mobile,string userId)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable datatable = memberAction.CheckMemMobileByMobile_two(mobile, userId);
            if (datatable.Rows.Count > 0)
            {
                return "true," + datatable.Rows[0]["MemLoginID"].ToString() + "," + datatable.Rows[0]["Mobile"].ToString();

            }
            return "false";
        }
        public string ExistEmailForFindv(string email, string userId)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable datatable = memberAction.CheckMemEmailByEmail_two(email,userId);
            if (datatable.Rows.Count > 0)
            {
                return "true," + datatable.Rows[0]["MemLoginID"].ToString() + "," + datatable.Rows[0]["email"].ToString();
            }
            return "false";
        }

        public string ExistEmailForFind(string email)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable datatable = memberAction.CheckMemEmailByEmail(email);
            if (datatable.Rows.Count > 0)
            {
                return "true," + datatable.Rows[0]["MemLoginID"].ToString() + "," + datatable.Rows[0]["email"].ToString();
            }
            return "false";
        }
        #region 邮箱 找回密码
        //邮箱 找回密码
        public string FindPwdByEmail(string email)
        {
            string strresult = "false";
            //取商城名称
            string strShopName = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("Name"));
            //string email = HttpContext.Current.Request.Form["TextBoxEmail"];
            string pwdtemp = HttpContext.Current.Request.Form["TextBoxPwd"];
            ShopNum1.Interface.IShopNum1_Member_Action memberAction = LogicFactory.CreateShopNum1_Member_Action();
            //密码找回信息 
            ShopNum1.Interface.IShopNum1_MemberPwd_Action imembPwd = LogicFactory.CreateShopNum1_MemberPwd_Action();
            DataTable dataTablememberAction = memberAction.CheckMemEmailByEmail(email);
            if (dataTablememberAction == null || dataTablememberAction.Rows.Count == 0)
            {
                strresult = "false";
            }
            if (dataTablememberAction.Rows.Count > 0)
            {
                //发送邮件
                //调用模板邮件
                GetEmailSetting();
                NetMail netMail = new NetMail();
                // 邮箱域
                netMail.MailDomain = strSMTP;
                // 邮件服务器端口号
                netMail.Mailserverport = Convert.ToInt32(strServerPort.Trim());
                // SMTP认证时使用的用户名
                netMail.Username = strEmailAccount;
                // SMTP认证时使用的密码
                netMail.Password = ShopNum1.Common.Encryption.Decrypt(strEmailPassword);
                //  是否Html邮件
                netMail.Html = true;
                string strMemLoginID = string.Empty;
                string strPwd = string.Empty;
                //从Cookie中取MemLoginID
                strMemLoginID = dataTablememberAction.Rows[0]["MemLoginID"].ToString();
                //  string OldPwd = dataTablememberAction.Rows[0]["Pwd"].ToString();
                strPwd = pwdtemp;
                ShopNum1_MemberPwd MemberPwd = new ShopNum1_MemberPwd();
                MemberPwd.MemberID = strMemLoginID;
                MemberPwd.Pwd = "";
                MemberPwd.pwdkey = ShopNum1.Common.Encryption.GetMd5SecondHash(System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + new Random().Next().ToString()).Substring(0, 8);
                MemberPwd.type = 0;
                MemberPwd.extireTime = Convert.ToDateTime(System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss"));
                MemberPwd.Email = email;
                int check10 = imembPwd.MemberPwdInsert(MemberPwd);
                //MessageBox.Show(check10.ToString());
                // 收件人姓名
                netMail.AddRecipient(email);
                //取邮件内容
                PasswordEmailReset passwordReset = new PasswordEmailReset();
                string urlpage = ShopSettings.IsOverrideUrl ? "FindBackPassword" + ShopSettings.overrideUrlName : "FindBackPassword";
                passwordReset.ChangePwdUrl = "http://" + ConfigurationManager.AppSettings["DoMain"].ToString() + "/" + urlpage + "?type=0&key=" + MemberPwd.pwdkey;
                passwordReset.ShopName = ShopSettings.GetValue("Name");
                passwordReset.SysSendTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                passwordReset.ExtireTime = MemberPwd.extireTime.ToString();
                passwordReset.MemloginID = strMemLoginID;
                passwordReset.Hour = "24";
                //邮件内容,从模块中读出来
                string strcontent = string.Empty;
                ShopNum1_Email_Action emailAction = new ShopNum1_Email_Action();
                strTitle = "发送邮件找回密码";
                strcontent = @"尊敬的{$Name}：你可以通过下面链接找回自己的密码。<br />
<a href=''{$ResetUrl}'' target=''_blank''>{$ResetUrl}</a>,你如果链接无法点击请复制到浏览器地址栏。<br />
<p>
	感谢您对的{$ShopName}关注。
</p>
<p>
	祝您购物愉快！
</p>
<p>
	请勿回复{$ShopName}   {$SendTime}
</p>
<p>
	<br />
</p>";
                strcontent = strcontent.Replace("{$Name}", passwordReset.MemloginID);
                strcontent = strcontent.Replace("{$ResetUrl}", passwordReset.ChangePwdUrl);
                strcontent = strcontent.Replace("{$ShopName}", passwordReset.ShopName);
                strcontent = strcontent.Replace("{$SendTime}", System.DateTime.Now.ToString());
                netMail.Subject = passwordReset.ShopName + "找回密码";
                netMail.Body = passwordReset.ChangePasswordEmailReset(HttpContext.Current.Server.HtmlDecode(strcontent));
                // 发件人地址(与邮件回复地址相同)
                netMail.From = strRestoreEmail;
                if (netMail.Send() != true)
                {
                    ////发送失败,发送状态为0
                    ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 0, netMail.Body);
                    //邮件发送历史的添加
                    int check = emailAction.AddEmailGroupSend(emailGroupSend);
                    if (check > 0)
                    {
                        strresult = "false";
                    }
                }
                else
                {
                    //发送成功,发送状态为2
                    ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 2, netMail.Body);
                    //邮件发送历史的添加
                    int check = emailAction.AddEmailGroupSend(emailGroupSend);
                    //成功跳转页面  
                    strresult = "true";
                }



            }
            return strresult;
        }
        public string FindPwdByEmail(string email, string User)
        {
            string strresult = "false";
            //取商城名称
            string strShopName = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("Name"));
            //string email = HttpContext.Current.Request.Form["TextBoxEmail"];
            string pwdtemp = HttpContext.Current.Request.Form["TextBoxPwd"];
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            //密码找回信息 
            ShopNum1.Interface.IShopNum1_MemberPwd_Action imembPwd = LogicFactory.CreateShopNum1_MemberPwd_Action();
            DataTable dataTablememberAction = memberAction.CheckMemEmailByEmail_two(email, User);
            if (dataTablememberAction == null || dataTablememberAction.Rows.Count == 0)
            {
                strresult = "false";
            }
            if (dataTablememberAction.Rows.Count > 0)
            {
                //发送邮件
                //调用模板邮件
                GetEmailSetting();
                NetMail netMail = new NetMail();
                // 邮箱域
                netMail.MailDomain = strSMTP;
                // 邮件服务器端口号
                netMail.Mailserverport = Convert.ToInt32(strServerPort.Trim());
                // SMTP认证时使用的用户名
                netMail.Username = strEmailAccount;
                // SMTP认证时使用的密码
                netMail.Password = ShopNum1.Common.Encryption.Decrypt(strEmailPassword);
                //  是否Html邮件
                netMail.Html = true;
                string strMemLoginID = string.Empty;
                string strPwd = string.Empty;
                //从Cookie中取MemLoginID
                strMemLoginID = dataTablememberAction.Rows[0]["MemLoginID"].ToString();
                //  string OldPwd = dataTablememberAction.Rows[0]["Pwd"].ToString();
                strPwd = pwdtemp;
                ShopNum1_MemberPwd MemberPwd = new ShopNum1_MemberPwd();
                MemberPwd.MemberID = strMemLoginID;
                MemberPwd.Pwd = "";
                MemberPwd.pwdkey = ShopNum1.Common.Encryption.GetMd5SecondHash(System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + new Random().Next().ToString()).Substring(0, 8);
                MemberPwd.type = 0;
                MemberPwd.extireTime = Convert.ToDateTime(System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss"));
                MemberPwd.Email = email;
                int check10 = imembPwd.MemberPwdInsert(MemberPwd);
                //MessageBox.Show(check10.ToString());
                // 收件人姓名
                netMail.AddRecipient(email);
                //取邮件内容
                PasswordEmailReset passwordReset = new PasswordEmailReset();
                string urlpage = ShopSettings.IsOverrideUrl ? "FindBackPassword" + ShopSettings.overrideUrlName : "FindBackPassword";
                passwordReset.ChangePwdUrl = "http://" + ConfigurationManager.AppSettings["DoMain"].ToString() + "/" + urlpage + "?type=0&key=" + MemberPwd.pwdkey;
                passwordReset.ShopName = ShopSettings.GetValue("Name");
                passwordReset.SysSendTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                passwordReset.ExtireTime = MemberPwd.extireTime.ToString();
                passwordReset.MemloginID = strMemLoginID;
                passwordReset.Hour = "24";
                //邮件内容,从模块中读出来
                string strcontent = string.Empty;
                ShopNum1_Email_Action emailAction = new ShopNum1_Email_Action();
                strTitle = "发送邮件找回密码";
                strcontent = @"尊敬的{$Name}：你可以通过下面链接找回自己的密码。<br />
<a href=''{$ResetUrl}'' target=''_blank''>{$ResetUrl}</a>,你如果链接无法点击请复制到浏览器地址栏。<br />
<p>
	感谢您对的{$ShopName}关注。
</p>
<p>
	祝您购物愉快！
</p>
<p>
	请勿回复{$ShopName}   {$SendTime}
</p>
<p>
	<br />
</p>";
                strcontent = strcontent.Replace("{$Name}", passwordReset.MemloginID);
                strcontent = strcontent.Replace("{$ResetUrl}", passwordReset.ChangePwdUrl);
                strcontent = strcontent.Replace("{$ShopName}", passwordReset.ShopName);
                strcontent = strcontent.Replace("{$SendTime}", System.DateTime.Now.ToString());
                netMail.Subject = passwordReset.ShopName + "找回密码";
                netMail.Body = passwordReset.ChangePasswordEmailReset(HttpContext.Current.Server.HtmlDecode(strcontent));
                // 发件人地址(与邮件回复地址相同)
                netMail.From = strRestoreEmail;
                if (netMail.Send() != true)
                {
                    ////发送失败,发送状态为0
                    ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 0, netMail.Body);
                    //邮件发送历史的添加
                    int check = emailAction.AddEmailGroupSend(emailGroupSend);
                    if (check > 0)
                    {
                        strresult = "false";
                    }
                }
                else
                {
                    //发送成功,发送状态为2
                    ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 2, netMail.Body);
                    //邮件发送历史的添加
                    int check = emailAction.AddEmailGroupSend(emailGroupSend);
                    //成功跳转页面  
                    strresult = "true";
                }



            }
            return strresult;
        }


        //从XML文档中读相应的参数
        //发邮件部分----从XML文档中读相应的参数,同时查询邮件发送记录参数
        protected void GetEmailSetting()
        {
            strEmailServer = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailServer"));
            strSMTP = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("SMTP"));
            strServerPort = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("ServerPort"));
            strEmailAccount = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailAccount"));
            strEmailPassword = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailPassword"));
            strRestoreEmail = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("RestoreEmail"));
            strEmailCode = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailCode"));
        }


        /// <summary>
        /// 建立ShopNum1_EmailGroupSend对象
        /// </summary>
        /// <param name="memLoginID">用户名</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
        {
            ShopNum1_EmailGroupSend emailGroupSend = new ShopNum1_EmailGroupSend();

            emailGroupSend.Guid = Guid.NewGuid();
            emailGroupSend.EmailTitle = strTitle;
            emailGroupSend.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            emailGroupSend.EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b");
            emailGroupSend.SendObjectEmail = sconts;
            emailGroupSend.SendObject = memLoginID + "-" + email;
            emailGroupSend.State = state;
            //emailGroupSend.IsTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));   //是否定时
            //emailGroupSend.TimeSendTime= 0; 　　　　　　　　　//定时时间

            return emailGroupSend;
        }

        #endregion


        #region  手机找回密码
        public string FindPwdByTel(string tel, string memberid)
        {
            //发送验证码删除之前发送记录 by 0831 seven
            ShopNum1_Member_Action Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            Member_Action.DeleteMemberActivate(tel);


            ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
            //ShopNum1_MemberEmailExec_Action memberEmailExec_Action = new ShopNum1_MemberEmailExec_Action();
            //ShopNum1_MemberEmailExec MemberEmailExec = new ShopNum1_MemberEmailExec();
            shopNum1_MemberActivate.Guid = Guid.NewGuid();
            shopNum1_MemberActivate.Key = new Random().Next(111111, 999999).ToString();
            shopNum1_MemberActivate.MemberID = memberid;
            shopNum1_MemberActivate.Email = "";
            shopNum1_MemberActivate.Phone = tel;
            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
            shopNum1_MemberActivate.type = Convert.ToByte(1);
            shopNum1_MemberActivate.isinvalid = Convert.ToByte(0);
            shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
            //memberEmailExec_Action.MemberEmailInsert(MemberEmailExec);//插入验证码
            string strresult = "false";
            DataTable result = IsExistMobile(tel.Trim(), memberid);
            if (result.Rows.Count <= 0)
            {
                strresult = "false";
            }
            else
            {
                string name = result.Rows[0]["MemLoginID"].ToString();
                #region 模板读取
                string strMsg = "亲爱的" + name + ",您申请找回密码的验证码为：" + shopNum1_MemberActivate.Key + "。【唐江宝宝】";
                #endregion
                string outstr = "";
                SMS sms = new SMS();
                sms.Send(tel.Trim(), strMsg, out outstr);
                strresult = outstr;
                if (outstr.IndexOf("发送成功") != -1)
                {
                    //保存短信记录
                    InsertData(name + "-" + tel.Trim(), strMsg, 2);
                }
                else
                {
                    //保存短信记录
                    InsertData(name + "-" + tel.Trim(), strMsg, 0);
                }
            }
            return strresult;
        }
        public string SendCodeForCheck(string strtel)
        {
            ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
            shopNum1_MemberActivate.Guid = Guid.NewGuid();
            shopNum1_MemberActivate.Key = new Random().Next(111111, 999999).ToString();
            shopNum1_MemberActivate.MemberID = strtel;
            shopNum1_MemberActivate.Email = "";
            shopNum1_MemberActivate.Phone = strtel;
            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(3);
            shopNum1_MemberActivate.type = Convert.ToByte(1);
            shopNum1_MemberActivate.isinvalid = Convert.ToByte(0);
            shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
            string strresult = "false";
            DataTable result = IsExistMobile(strtel.Trim());
            if (result.Rows.Count <= 0)
            {
                strresult = "false";
            }
            else
            {
                string name = result.Rows[0]["MemLoginID"].ToString();
                #region 模板读取
                string strMsg = "亲爱的" + name + ",您申请注册的手机验证码为：" + shopNum1_MemberActivate.Key + "。【唐江宝宝】";
                #endregion
                string outstr = "";
                SMS sms = new SMS();
                sms.Send(strtel.Trim(), strMsg, out outstr);
                strresult = outstr;
                if (outstr.IndexOf("发送成功") != -1)
                {
                    InsertData(name + "-" + strtel.Trim(), strMsg, 2);
                }
                else
                {
                    InsertData(name + "-" + strtel.Trim(), strMsg, 0);
                }
            }
            return strresult;
        }
        /// <summary>
        /// 旧方法
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public DataTable ExistMobiles(string Mobile)
        {
            ShopNum1_Member_Action memberAction = new ShopNum1_Member_Action();
            DataTable dataTable = memberAction.CheckMemMobileByMobile(Mobile);
            if (dataTable != null)
            {
                return dataTable;
            }
            else
            {

                return null;
            }
        }
        /// <summary>
        ///  Jely 20130502新增方法
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public DataTable IsExistMobile(string Mobile)
        {
            ShopNum1_Member_Action memberAction = new ShopNum1_Member_Action();
            DataTable dataTable = memberAction.CheckMemMobileByMobile(Mobile);
            if (dataTable != null)
            {
                return dataTable;
            }
            else
            {

                return null;
            }
        }

        public DataTable IsExistMobile(string Mobile,string User)
        {
            ShopNum1_Member_Action memberAction = new ShopNum1_Member_Action();
            DataTable dataTable = memberAction.CheckMemMobileByMobile_two(Mobile,User);
            if (dataTable != null)
            {
                return dataTable;
            }
            else
            {

                return null;
            }
        }

        /// <summary>
        /// 新建密码
        /// </summary>
        public string SetNewPwd(string MemLoginID)
        {
            string newPwd = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 7; i++)
            {
                int d = r.Next(0, 9);
                newPwd += d.ToString();
            }
            ShopNum1_Member_Action Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            Member_Action.UpdatePwd(MemLoginID, ShopNum1.Common.Encryption.GetMd5Hash(newPwd));
            return newPwd;
        }

        /// <summary>
        /// 保存短信记录
        /// </summary>
        public void InsertData(string sendObject, string sendObjectMMS, int resultState)
        {
            ShopNum1_MMSGroupSend mms = new ShopNum1_MMSGroupSend();
            mms.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            mms.Guid = Guid.NewGuid();
            mms.IsTime = 0;
            mms.MMSGuid = new Guid("464595bb-4e2a-4240-9b5e-03871e8b1409");
            mms.MMSTitle = "重设(找回)密码";
            mms.SendObject = sendObject;
            mms.SendObjectMMS = sendObjectMMS;
            mms.State = resultState;
            mms.TimeSendTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ShopNum1_MMSGroupSend_Action MMSGroupSend_Action = new ShopNum1_MMSGroupSend_Action();
            MMSGroupSend_Action.AddTwo(mms);
        }


        public string MemberMobileExec(string key, string mobile, string type)
        {
            //ShopNum1_MemberEmailExec_Action MemberEmailExec_Action = new ShopNum1_MemberEmailExec_Action();
            //return MemberEmailExec_Action.MemberMobileExec(Emailkey, "1").ToString();
            ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();

            return shopNum1_MemberActivate_Action.CheckMobileCode(key, mobile, type).ToString();
        }



        #endregion




        //IHttpHandler Members

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }




        //ICallbackEventHandler Members

        public string GetCallbackResult()
        {

            string[] parts = serverReturn.Split('|');
            return (string)GetType().GetMethod(parts[0]).Invoke(this, new object[] { parts[1] });


        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            serverReturn = eventArgument;
        }
    }
}