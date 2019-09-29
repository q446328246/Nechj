using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class IndexForum
    {
        [JsonProperty("current_topics"), XmlElement("current_topics")] public int CurTopics;
        [JsonProperty("description"), XmlElement("description")] public string Description;
        [XmlElement("fid"), JsonProperty("fid")] public int Fid;
        [XmlElement("has_new"), JsonProperty("has_new")] public string HasNew;
        [XmlElement("icon"), JsonProperty("icon")] public string Icon;
        [XmlElement("last_post"), JsonProperty("last_post")] public string LastPost;
        [XmlElement("last_poster"), JsonProperty("last_poster")] public string LastPoster;
        [JsonProperty("last_poster_id"), XmlElement("last_poster_id")] public int LastPosterId;
        [JsonProperty("last_tid"), XmlElement("last_tid")] public int LastTid;
        [XmlElement("last_title"), JsonProperty("last_title")] public string LastTitle;
        [JsonProperty("moderators"), XmlElement("moderators")] public string Moderators;
        [JsonProperty("name"), XmlElement("name")] public string Name;
        [JsonProperty("parent_id"), XmlElement("parent_id")] public int ParentId;
        [XmlElement("parent_id_list"), JsonProperty("parent_id_list")] public string ParentIdList;
        [XmlElement("path_list"), JsonProperty("path_list")] public string PathList;
        [XmlElement("posts"), JsonProperty("posts")] public int Posts;
        [XmlElement("rules"), JsonProperty("rules")] public string Rules;
        [JsonProperty("status"), XmlElement("status")] public int Status;
        [XmlElement("sub_forum_count"), JsonProperty("sub_forum_count")] public int SubForumCount;
        [JsonProperty("today_posts"), XmlElement("today_posts")] public int TodayPosts;
        [JsonProperty("topics"), XmlElement("topics")] public int Topics;
        [JsonProperty("url"), XmlElement("url")] public string Url;
    }
}