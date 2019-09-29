using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_getList_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicGetListResponse
    {
        [XmlElement("count")] public int Count;
        [JsonIgnore, XmlAttribute("list")] public bool List;
        [XmlElement("topic")] public ForumTopic[] Topics;
    }
}