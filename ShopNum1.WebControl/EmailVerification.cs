using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class EmailVerification : BaseWebControl, ICallbackEventHandler
    {
        private Label LabelEmail;
        private LinkButton LinkButtonEmail;
        private LinkButton LinkButtonSend;
        private string skinFilename = "E-mailVerification.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;

        public EmailVerification()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string GetCallbackResult()
        {
            throw new NotImplementedException();
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            throw new NotImplementedException();
        }

        public void GetUrl(string email)
        {
            int num = Convert.ToInt32(email.LastIndexOf(".")) - Convert.ToInt32(email.LastIndexOf("@"));
            string str = email.Substring(email.LastIndexOf("@") + 1, num - 1);
            DataTable xmlDataTable = GetXmlDataTable();
            if ((xmlDataTable != null) && (xmlDataTable.Rows.Count > 0))
            {
                for (int i = 0; i < xmlDataTable.Rows.Count; i++)
                {
                    if (xmlDataTable.Rows[i]["sign"].ToString() == str)
                    {
                        if (xmlDataTable.Rows[i]["url"].ToString().Contains("http://") ||
                            xmlDataTable.Rows[i]["url"].ToString().Contains("https://"))
                        {
                            LinkButtonEmail.PostBackUrl = xmlDataTable.Rows[i]["url"].ToString();
                        }
                        else
                        {
                            LinkButtonEmail.PostBackUrl = "http://" + xmlDataTable.Rows[i]["url"];
                        }
                    }
                }
            }
        }

        public DataTable GetXmlDataTable()
        {
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath("~/Settings/email.xml"));
            if ((set == null) || (set.Tables.Count == 0))
            {
                return null;
            }
            return set.Tables[0];
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelEmail = (Label) skin.FindControl("LabelEmail");
            LinkButtonEmail = (LinkButton) skin.FindControl("LinkButtonEmail");
            LinkButtonSend = (LinkButton) skin.FindControl("LinkButtonSend");
            LinkButtonSend.Click += LinkButtonSend_Click;
            if ((Page.Request.QueryString["email"] != null) && (Page.Request.QueryString["id"] != null))
            {
                string_1 = Page.Request.QueryString["email"];
                string_2 = Page.Request.QueryString["id"];
                LabelEmail.Text = string_1;
                GetUrl(string_1);
            }
        }

        protected void LinkButtonSend_Click(object sender, EventArgs e)
        {
            ShopSettings.GetValue("RegIsEmail");
            string str = ShopSettings.GetValue("RegIsActivationEmail");
            ShopSettings.GetValue("RegIsMMS");
            string str2 = ShopSettings.GetValue("Name");
            if (str == "1")
            {
                RegIsActivationEmail email;
                string emailkey = Guid.NewGuid().ToString();
                email = new RegIsActivationEmail
                {
                    Email = string_1,
                    Name = string_2,
                    link =
                        GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + emailkey + "&type=0&email=" +
                        string_1 + "&userID=" + string_2,
                    ShopName = str2,
                    SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                string s = string.Empty;
                string strTitle = string.Empty;
                string emailTemplentGuid = "7790bcf5-f88a-46bd-8ead-959118481c02";
                string emailBody = string.Empty;
                new ShopNum1_Email_Action();
                s =
                    "<p>尊敬的{$Name}：你已经在本站注册，这是您的用户名和邮箱地址，用户名：{$Name}，邮箱：{$Email}，请牢记。</p><p>\t接下来您只需通过点击以下链接进行验证。</p><p><a href={$CheckUrl} target=_blank>{$CheckUrl}</a>(如果无法点击，请复制到地址栏进行验证。)</p><p>\t感谢您对的{$ShopName}关注。</p><p>\t祝您购物愉快！&nbsp;</p><p>\t请勿回复{$ShopName}   {$SendTime}</p>";
                s =
                    s.Replace("{$Name}", email.Name)
                        .Replace("{$Email}", email.Email)
                        .Replace("{$CheckUrl}", email.link)
                        .Replace("{$ShopName}", "ShopNum1多用户商城")
                        .Replace("{$SendTime}", email.SysSendTime);
                strTitle = "ShopNum1多用户商城-注册时邮件提醒";
                emailBody = email.ChangeRegister(Page.Server.HtmlDecode(s));
                SendMailForRegister(string_2, string_1, emailkey, "", strTitle, emailTemplentGuid, emailBody);
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
                MessageBox.Show("发送成功，请前往登录邮箱");
            }
        }
    }
}