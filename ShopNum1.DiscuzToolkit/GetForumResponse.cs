using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("forums_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class GetForumResponse
    {
        [JsonProperty("current_topics"), XmlElement("current_topics")] public int CurTopics;
        [JsonProperty("description"), XmlElement("description")] public string Description;
        [JsonProperty("fid"), XmlElement("fid")] public int Fid;
        [XmlElement("icon"), JsonProperty("icon")] public string Icon;
        [XmlElement("last_post"), JsonProperty("last_post")] public string LastPost;
        [XmlElement("last_poster"), JsonProperty("last_poster")] public string LastPoster;
        [XmlElement("last_poster_id"), JsonProperty("last_poster_id")] public int LastPosterId;
        [JsonProperty("last_tid"), XmlElement("last_tid")] public int LastTid;
        [XmlElement("last_title"), JsonProperty("last_title")] public string LastTitle;
        [JsonProperty("moderators"), XmlElement("moderators")] public string Moderators;
        [XmlElement("name"), JsonProperty("name")] public string Name;
        [JsonProperty("parent_id"), XmlElement("parent_id")] public int ParentId;
        [XmlElement("parent_id_list"), JsonProperty("parent_id_list")] public string ParentIdList;
        [JsonProperty("path_list"), XmlElement("path_list")] public string PathList;
        [XmlElement("posts"), JsonProperty("posts")] public int Posts;
        [XmlElement("rules"), JsonProperty("rules")] public string Rules;
        [XmlElement("status"), JsonProperty("status")] public int Status;
        [XmlElement("sub_forum_count"), JsonProperty("sub_forum_count")] public int SubForumCount;
        [XmlElement("today_posts"), JsonProperty("today_posts")] public int TodayPosts;
        [XmlElement("topics"), JsonProperty("topics")] public int Topics;
        [JsonProperty("url"), XmlElement("url")] public string Url;
    }
}