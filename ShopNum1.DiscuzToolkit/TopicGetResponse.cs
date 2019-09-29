using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicGetResponse
    {
        [XmlElement("attachment"), JsonProperty("attachments")] public AttachmentInfo[] Attachments;
        [XmlElement("author"), JsonProperty("author")] public string Author = string.Empty;
        [JsonProperty("author_id"), XmlElement("author_id")] public int AuthorId;
        [JsonProperty("fid"), XmlElement("fid", IsNullable = false)] public int Fid;
        [JsonProperty("icon_id"), XmlElement("icon_id", IsNullable = false)] public int Iconid;
        [JsonProperty("last_post_time"), XmlElement("last_post_time")] public string LastPostTime = string.Empty;
        [XmlElement("last_poster_id"), JsonProperty("last_poster_id")] public int LastPosterId;
        [JsonIgnore, XmlAttribute("list")] public bool List;
        [JsonProperty("posts"), XmlElement("post")] public Post[] Posts;
        [JsonProperty("reply_count"), XmlElement("reply_count")] public int ReplyCount;
        [JsonProperty("tags"), XmlElement("tags", IsNullable = true)] public string Tags;
        [XmlElement("title", IsNullable = false), JsonProperty("title")] public string Title;
        [JsonProperty("topic_id"), XmlElement("topic_id")] public int TopicId;
        [JsonProperty("url"), XmlElement("url")] public string Url;
        [JsonProperty("view_count"), XmlElement("view_count")] public int ViewCount;
    }
}