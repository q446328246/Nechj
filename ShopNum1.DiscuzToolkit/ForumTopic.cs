using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class ForumTopic
    {
        [JsonProperty("author"), XmlElement("author")] public string Author = string.Empty;
        [JsonProperty("author_id"), XmlElement("author_id")] public int AuthorId;
        [XmlElement("last_post_time"), JsonProperty("last_post_time")] public string LastPostTime = string.Empty;
        [XmlElement("last_poster_id"), JsonProperty("last_poster_id")] public int LastPosterId;
        [XmlElement("reply_count"), JsonProperty("reply_count")] public int ReplyCount;
        [XmlElement("title"), JsonProperty("title")] public string Title = string.Empty;
        [XmlElement("tid"), JsonProperty("tid")] public int TopicId;
        [XmlElement("view_count"), JsonProperty("view_count")] public int ViewCount;
    }
}