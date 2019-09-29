using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("notification_send_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class SendNotificationResponse
    {
        [XmlText] public string Result;
    }
}