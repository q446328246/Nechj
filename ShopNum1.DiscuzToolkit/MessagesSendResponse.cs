using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("messages_send_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class MessagesSendResponse
    {
        [XmlText] public string Result;
    }
}