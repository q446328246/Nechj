using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class Notification
    {
        [JsonProperty("most_recent"), XmlElement("most_recent", IsNullable = false)] public int MostRecent;
        [XmlElement("unread", IsNullable = false), JsonProperty("unread")] public int Unread;
    }
}