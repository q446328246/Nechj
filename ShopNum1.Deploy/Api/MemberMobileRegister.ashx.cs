using System;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// MemberMobileRegister 的摘要说明
    /// </summary>
    public class MemberMobileRegister : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["type"] != null)
            {
                string strtype = context.Request.QueryString["type"];
                string strTel = null, strEmail = null, strkey = null;
                switch (strtype)
                {
                    case "1":
                        strTel = context.Request.QueryString["mobile"];
                        context.Response.Write(ExistMobileForFind(strTel));
                        break;
                    case "2":
                        strTel = context.Request.QueryString["mobile"];
                        context.Response.Write(SendCodeForCheck(strTel));
                        break;
                    case "3":
                        strkey = context.Request.QueryString["key"];
                        strTel = context.Request.QueryString["mobile"];
                        context.Response.Write(MemberMobileExec(strkey, strTel));
                        break;
                    case "4":
                        strEmail = context.Request.QueryString["email"];
                        context.Response.Write(BindEmail(strEmail));
                        break;
                    case "5":
                        strEmail = context.Request.QueryString["email"];
                        strkey = context.Request.QueryString["key"];
                        context.Response.Write(CheckEmalCode(strkey, strEmail, "0"));
                        break;
                    case "6":
                        context.Response.Write(SendCodeForCheck());
                        break;
                    case "7":
                        context.Response.Write(ExistMobileByMemloginId());
                        break;
                    case "8":
                        strkey = context.Request.QueryString["key"];
                        context.Response.Write(MemberMobileExec(strkey));
                        break;
                    case "9":
                        context.Response.Write(SendCodeForCheck());
                        break;
                    case "10":
                        context.Response.Write(ExistMobileByMemloginId());
                        break;
                    case "11":
                        strkey = context.Request.QueryString["key"];
                        context.Response.Write(MemberMobileExec(strkey));
                        break;
                    case "12":
                        strEmail = context.Request.QueryString["email"];
                        context.Response.Write(CheckEmail(strEmail));
                        break;
                    default:
                        context.Response.Write("error");
                        break;
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        #region   邮箱绑定方法

        public string CheckEmail(string email)
        {
            var Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

            int checkEmailCount = Member_Action.CheckmemEmail(email);
            if (checkEmailCount > 0)
            {
                checkEmailCount = Member_Action.CheckEmail(email, GetMemLoginId());
                if (checkEmailCount > 0)
                {
                    //是这个会员邮箱 没有进行绑定
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                //没有进行过绑定，可以进行绑定
                return "1";
            }
        }

        public string CheckEmalCode(string key, string email, string type)
        {
            string strEmailCode = ShopNum1.Common.Common.GetNameById("[key]", "shopNum1_MemberActivate",
                                                     " and [key]='" + key + "' and email='" + email +
                                                     "' and type='0' and extiretime>getdate()");

            if (strEmailCode != "")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

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

        //从XML文档中读相应的参数
        //发邮件部分----从XML文档中读相应的参数,同时查询邮件发送记录参数
        public string BindEmail(string email)
        {
            var shopNum1_MemberActivate_Action = new ShopNum1_MemberActivate_Action();
            shopNum1_MemberActivate_Action.DeleteKey(GetMemLoginId(), email, "email");

            string strresult = "0";
            IShopNum1_Member_Action memberAction = LogicFactory.CreateShopNum1_Member_Action();
            //发送邮件
            //调用模板邮件
            GetEmailSetting();
            var netMail = new NetMail();
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
            var shopNum1_MemberActivate = new ShopNum1_MemberActivate();
            shopNum1_MemberActivate.Guid = Guid.NewGuid();
            shopNum1_MemberActivate.MemberID = GetMemLoginId();
            shopNum1_MemberActivate.Pwd = "";
            shopNum1_MemberActivate.Key =
                ShopNum1.Common.Encryption.GetMd5SecondHash(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") +
                                            new Random().Next().ToString()).Substring(0, 8);
            shopNum1_MemberActivate.type = 0;
            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
            shopNum1_MemberActivate.Email = email;
            shopNum1_MemberActivate.isinvalid = 0;
            shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
            // 收件人姓名

            var emailAction = new ShopNum1_Email_Action();
            netMail.AddRecipient(email);
            //邮件内容,从模块中读出来
            string strcontent = "尊敬的" + GetMemLoginId() + "用户，您的邮箱验证码为" + shopNum1_MemberActivate.Key;
            netMail.Subject = "邮箱验证";
            netMail.Body = HttpContext.Current.Server.HtmlDecode(strcontent);
            // 发件人地址(与邮件回复地址相同)
            netMail.From = strRestoreEmail;
            if (netMail.Send() != true)
            {
                ////发送失败,发送状态为0
                ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 0, netMail.Body);
                emailGroupSend.EmailTitle = "账户安全设置";
                //邮件发送历史的添加
                int check = emailAction.AddEmailGroupSend(emailGroupSend);
            }
            else
            {
                //发送成功,发送状态为2
                ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 2, netMail.Body);
                emailGroupSend.EmailTitle = "账户安全设置";
                //邮件发送历史的添加
                int check = emailAction.AddEmailGroupSend(emailGroupSend);
                //成功跳转页面  
                strresult = "1";
            }
            return strresult;
        }

        /// <summary>
        ///   建立ShopNum1_EmailGroupSend对象
        /// </summary>
        /// <param name="memLoginID">用户名</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
        {
            var emailGroupSend = new ShopNum1_EmailGroupSend();

            emailGroupSend.Guid = Guid.NewGuid();
            emailGroupSend.EmailTitle = strTitle;
            emailGroupSend.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            emailGroupSend.EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b");
            emailGroupSend.SendObjectEmail = sconts;
            emailGroupSend.SendObject = memLoginID + "-" + email;
            emailGroupSend.State = state;
            return emailGroupSend;
        }

        #region 邮件设置

        private readonly string strTitle = string.Empty;
        private string strEmailAccount = string.Empty;
        private string strEmailCode = string.Empty;
        private string strEmailPassword = string.Empty;
        private string strEmailServer = string.Empty;
        private string strRestoreEmail = string.Empty;
        private string strSMTP = string.Empty;
        private string strServerPort = string.Empty;

        #endregion

        #endregion

        #region 手机绑定方法

        private int ExistMobileCode(string key, string mobile)
        {
            if (MemberMobileExec(key, mobile) != "")
            {
                ShopNum1.Common.Common.UpdateInfo("ismobileactivation=1", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //检查验证码是否存在
        public string MemberMobileExec(string key)
        {
            try
            {
                string strMobile = ShopNum1.Common.Common.GetNameById("Mobile", "select Mobile from ShopNum1_Member ",
                                                      " and memloginId='" + GetMemLoginId() + "' and mobile!=''");
                var shopNum1_MemberActivate_Action =
                    (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                if (shopNum1_MemberActivate_Action.CheckMobileCode(key, strMobile, "1") != "0")
                {
                    return "1";
                }
                else
                    return "0";
            }
            catch
            {
                return "0";
            }
        }

        public string MemberMobileExec(string key, string mobile)
        {
            var shopNum1_MemberActivate_Action =
                (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            string check = shopNum1_MemberActivate_Action.CheckMobileCode(key, mobile, "1");
            return check;
        }

        //判断号码是否存在，如果存在并且状态的话，返回false 
        public string ExistMobileForFind(string mobile)
        {
            var Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            //是否存在
            int checkMobile = Member_Action.CheckBindMobile(mobile, "");
            if (checkMobile > 0)
            {
                //存在后，看这个号码是否绑定过
                checkMobile = Member_Action.CheckBindMobile(mobile, GetMemLoginId());
                {
                    if (checkMobile > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            else
            {
                return "1";
            }
        }

        private string ExistMobileByMemloginId()
        {
            string strMobile = ShopNum1.Common.Common.GetNameById("Mobile", "select Mobile from ShopNum1_Member ",
                                                  " and memloginId='" + GetMemLoginId() + "' and mobile!=''");
            if (strMobile != "")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        ///   获得登录名的方法
        /// </summary>
        /// <returns></returns>
        private string GetMemLoginId()
        {
            string name = "";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
        }

        private string SendCodeForCheck()
        {
            try
            {
                string strMobile = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member ",
                                                      " and memloginId='" + GetMemLoginId() + "' and mobile!=''");
                var shopNum1_MemberActivate_Action =
                    (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                var shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                if (strMobile != "")
                {
                    shopNum1_MemberActivate.Guid = Guid.NewGuid();
                    shopNum1_MemberActivate.Key = new Random().Next(111111, 999999).ToString();
                    shopNum1_MemberActivate.MemberID = GetMemLoginId();
                    shopNum1_MemberActivate.Email = "";
                    shopNum1_MemberActivate.Phone = strMobile;
                    shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                    shopNum1_MemberActivate.type = Convert.ToByte(2);
                    shopNum1_MemberActivate.isinvalid = Convert.ToByte(0);
                    shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
                }
                string strresult = "false";

                #region 模板读取

                string strMsg = "亲，本次操作的验证码为:" + shopNum1_MemberActivate.Key + "。切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【唐江宝宝】";

                #endregion

                string outstr = "";
                var sms = new SMS();
                sms.Send(strMobile.Trim(), strMsg, out outstr);
                strresult = outstr;
                if (outstr.IndexOf("发送成功") != -1)
                {
                    InsertData(GetMemLoginId() + "-" + strMobile.Trim(), strMobile, strMsg, 2);
                }
                else
                {
                    InsertData(GetMemLoginId() + "-" + strMobile.Trim(), strMobile, strMsg, 0);
                }
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///   发送手机验证码
        /// </summary>
        /// <param name="strtel"></param>
        /// <returns></returns>
        public string SendCodeForCheck(string strtel)
        {
            try
            {
                var shopNum1_MemberActivate_Action =
                    (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();

                shopNum1_MemberActivate_Action.DeleteKey(strtel, strtel, "phone");

                var shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                shopNum1_MemberActivate.Guid = Guid.NewGuid();
                shopNum1_MemberActivate.Key = new Random().Next(111111, 999999).ToString();
                shopNum1_MemberActivate.MemberID = strtel;
                shopNum1_MemberActivate.Email = "";
                shopNum1_MemberActivate.Phone = strtel;
                shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                shopNum1_MemberActivate.type = Convert.ToByte(1);
                shopNum1_MemberActivate.isinvalid = Convert.ToByte(0);
                shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
                string strresult = "false";

                #region 模板读取

                string strMsg = "亲，本次操作的验证码为:" + shopNum1_MemberActivate.Key + "。切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【唐江宝宝】";

                #endregion

                string outstr = "";
                var sms = new SMS();
                sms.Send(strtel.Trim(), strMsg, out outstr);
                strresult = outstr;
                if (outstr.IndexOf("发送成功") != -1)
                {
                    InsertData(GetMemLoginId() + "-" + strtel.Trim(), strtel, strMsg, 2);
                }
                else
                {
                    InsertData(GetMemLoginId() + "-" + strtel.Trim(), strtel, strMsg, 0);
                }
                return "1";
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        ///   保存短信记录
        /// </summary>
        public void InsertData(string sendObject, string strMoible, string sendObjectMMS, int resultState)
        {
            var mms = new ShopNum1_MMSGroupSend();
            mms.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            mms.Guid = Guid.NewGuid();
            mms.IsTime = 0;
            mms.MMSGuid = new Guid("464595bb-4e2a-4240-9b5e-03871e8b1409");
            mms.MMSTitle = "手机验证";
            mms.SendObject = sendObject;
            mms.SendObjectMMS = sendObjectMMS;
            mms.State = resultState;
            mms.TimeSendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var MMSGroupSend_Action = new ShopNum1_MMSGroupSend_Action();
            MMSGroupSend_Action.Add(mms);
        }

        #endregion
    }
}