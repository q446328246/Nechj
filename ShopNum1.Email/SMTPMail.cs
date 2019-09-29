using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ShopNum1.Email
{
    public class SMTPMail
    {
        private string a;
        private string b;
        private string c;
        private string d;
        private string e;
        private string f;

        public string Body
        {
            get { return f; }
            set { f = value; }
        }

        public string SmtpPwd
        {
            get { return c; }
            set { c = value; }
        }

        public string SmtpServer
        {
            get { return a; }
            set { a = value; }
        }

        public string SmtpUser
        {
            get { return b; }
            set { b = value; }
        }

        public string Title
        {
            get { return e; }
            set { e = value; }
        }

        public string UserEmail
        {
            get { return d; }
            set { d = value; }
        }

        public bool SendEmail()
        {
            bool flag;
            try
            {
                using (var message = new MailMessage(b, d))
                {
                    message.Subject = e;
                    message.Body = f;
                    message.SubjectEncoding = Encoding.UTF8;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.Normal;
                    new SmtpClient(a)
                    {
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(b, c)
                    }.Send(message);
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}