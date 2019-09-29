using System.Net;
using System.Net.Mail;
using System.Text;
using ShopNum1.Common;

namespace ShopNum1.Email
{
    public class NetMail
    {
        public string Body { get; set; }

        public string From { get; set; }

        public string FromName { get; set; }

        public bool Html { get; set; }

        public string MailDomain { get; set; }

        public int Mailserverport { get; set; }

        public string Password { get; set; }

        public string RecipientName { get; set; }

        public string Subject { get; set; }

        public string Username { get; set; }

        public bool AddRecipient(string receiveName)
        {
            RecipientName = receiveName;
            return true;
        }

        public bool Send()
        {
            try
            {
                var client = new SmtpClient
                {
                    Host = MailDomain,
                    Port = Mailserverport,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Username, Password)
                };
                var message = new MailMessage();
                Encoding displayNameEncoding = Encoding.GetEncoding("utf-8");
                message.From = new MailAddress(From, ShopSettings.GetValue("Name"), displayNameEncoding);
                string recipientName = RecipientName;
                message.To.Add(recipientName);
                message.Subject = Subject;
                message.Body = Body;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                if (Mailserverport != 0x19)
                {
                    client.EnableSsl = true;
                }
                try
                {
                    client.Send(message);
                }
                catch (SmtpException exception)
                {
                    string text1 = exception.Message;
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}