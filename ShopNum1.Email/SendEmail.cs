using System;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Email
{
    public class SendEmail
    {
        private string a = string.Empty;
        private string b = string.Empty;
        private string c = string.Empty;
        private string d = string.Empty;
        private string e = string.Empty;
        private string f = string.Empty;
        private string g = string.Empty;
        private string h = string.Empty;

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string scont,
            string emailTemplentGuid)
        {
            return new ShopNum1_EmailGroupSend
            {
                Guid = Guid.NewGuid(),
                EmailTitle = h,
                CreateTime = DateTime.Now,
                EmailGuid = new Guid(emailTemplentGuid),
                SendObjectEmail = scont,
                SendObject = memLoginID + "-" + email,
                State = state
            };
        }

        public int Emails(string email, string MemLoginID, string emailTitle, string emailTemplentGuid, string emailBody)
        {
            ShopNum1_EmailGroupSend send;
            email = email.Trim();
            if ((email == "") || (email == null))
            {
                return 0;
            }
            GetEmailSetting();
            var mail = new NetMail
            {
                MailDomain = b,
                Mailserverport = Convert.ToInt32(d.Trim()),
                Username = c,
                Password = e,
                Html = true
            };
            mail.AddRecipient(email);
            mail.Body = HttpContext.Current.Server.HtmlDecode(emailBody);
            mail.From = f;
            mail.Subject = h = emailTitle;
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (!mail.Send())
            {
                send = Add(MemLoginID, email, 0, emailBody, emailTemplentGuid);
                action.AddEmailGroupSend(send);
                return 0;
            }
            send = Add(MemLoginID, email, 2, emailBody, emailTemplentGuid);
            action.AddEmailGroupSend(send);
            return 1;
        }

        protected void GetEmailSetting()
        {
            a = ShopSettings.GetValue("EmailServer");
            b = ShopSettings.GetValue("SMTP");
            d = ShopSettings.GetValue("ServerPort");
            c = ShopSettings.GetValue("EmailAccount");
            e = Encryption.Decrypt(ShopSettings.GetValue("EmailPassword"));
            f = ShopSettings.GetValue("RestoreEmail");
            g = ShopSettings.GetValue("EmailCode");
        }
    }
}