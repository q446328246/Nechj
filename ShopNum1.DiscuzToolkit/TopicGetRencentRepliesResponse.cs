using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_getRecentReplies_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicGetRencentRepliesResponse
    {
        [XmlElement("count")] public int Count;
        [XmlAttribute("list"), JsonIgnore] public bool List;
        [XmlElement("post")] public Post[] post_array;

        [JsonIgnore]
        public Post[] Posts
        {
            get { return (post_array ?? new Post[0]); }
        }
    }
}