using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("notification_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class GetNotiificationResponse
    {
        [XmlElement("message", IsNullable = true), JsonProperty("message")] public Notification Message;
        [XmlElement("notification", IsNullable = true), JsonProperty("notification")] public Notification Notification;
    }
}