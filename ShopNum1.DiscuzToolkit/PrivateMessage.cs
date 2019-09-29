using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class PrivateMessage
    {
        [XmlElement("from_id"), JsonProperty("from_id")] public string FormID;
        [JsonProperty("from"), XmlElement("from")] public string FromUser;
        [JsonProperty("message"), XmlElement("message")] public string Message;
        [XmlElement("message_id"), JsonProperty("message_id")] public int MsgID;
        [XmlElement("post_date_time"), JsonProperty("post_date_time")] public string PostDateTime;
        [JsonProperty("subject"), XmlElement("subject", IsNullable = false)] public string Subject;
    }
}