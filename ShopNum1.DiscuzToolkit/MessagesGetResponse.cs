using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("messages_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class MessagesGetResponse
    {
        [JsonProperty("pms"), XmlElement("pm")] public PrivateMessage[] PM;
        [JsonProperty("count"), XmlElement("count")] public int count;
    }
}