using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class Post
    {
        [XmlElement("ad_index"), JsonProperty("ad_index")] public int AdIndex;
        [JsonProperty("invisible"), XmlElement("invisible")] public int Invisible;
        [XmlElement("layer"), JsonProperty("layer")] public int Layer;
        [XmlElement("message"), JsonProperty("message")] public string Message;
        [XmlElement("pid"), JsonProperty("pid")] public int Pid;
        [XmlElement("post_date_time"), JsonProperty("post_date_time")] public string PostDateTime;
        [JsonProperty("poster_avator"), XmlElement("poster_avator")] public string PosterAvator;
        [XmlElement("poster_avator_height"), JsonProperty("poster_avator_height")] public int PosterAvatorHeight;
        [XmlElement("poster_avator_width"), JsonProperty("poster_avator_width")] public int PosterAvatorWidth;
        [JsonProperty("poster_email"), XmlElement("poster_email")] public string PosterEmail;
        [XmlElement("poster_id"), JsonProperty("poster_id")] public int PosterId;
        [JsonProperty("poster_location"), XmlElement("poster_location")] public string PosterLocation;
        [JsonProperty("poster_name"), XmlElement("poster_name")] public string PosterName;
        [XmlElement("poster_show_email"), JsonProperty("poster_show_email")] public int PosterShowEmail;
        [XmlElement("poster_signature"), JsonProperty("poster_signature")] public string PosterSignature;
        [XmlElement("rate"), JsonProperty("rate")] public int Rate;
        [JsonProperty("rate_times"), XmlElement("rate_times")] public int RateTimes;
        [XmlElement("title"), JsonProperty("title")] public string Title;
        [JsonProperty("use_signature"), XmlElement("use_signature")] public int UseSignature;
    }
}