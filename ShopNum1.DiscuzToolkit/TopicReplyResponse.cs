using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_reply_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicReplyResponse
    {
        [XmlElement("need_audit"), JsonProperty("need_audit")] public bool NeedAudit;
        [JsonProperty("post_id"), XmlElement("post_id")] public int PostId;
        [JsonProperty("url"), XmlElement("url")] public string Url;
    }
}