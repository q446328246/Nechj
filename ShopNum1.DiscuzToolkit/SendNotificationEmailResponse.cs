using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("notification_sendemail_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class SendNotificationEmailResponse
    {
        [XmlText] public string Recipients;
    }
}