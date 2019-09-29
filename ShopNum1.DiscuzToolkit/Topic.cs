using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class Topic
    {
        [JsonProperty("fid"), XmlElement("fid", IsNullable = false)] public int Fid;
        [XmlElement("icon_id", IsNullable = true), JsonProperty("icon_id")] public int Iconid;
        [JsonProperty("message"), XmlElement("message", IsNullable = false)] public string Message;
        [XmlElement("tags", IsNullable = true), JsonProperty("tags")] public string Tags;
        [JsonProperty("title"), XmlElement("title", IsNullable = false)] public string Title;
        [XmlElement("uid", IsNullable = false), JsonProperty("uid")] public int UId;
    }
}