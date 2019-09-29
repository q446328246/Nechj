using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_create_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicCreateResponse
    {
        [XmlElement("need_audit"), JsonProperty("need_audit")] public bool NeedAudit;
        [JsonProperty("topic_id"), XmlElement("topic_id")] public int Topicid;
        [JsonProperty("url"), XmlElement("url")] public string Url;
    }
}