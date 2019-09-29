using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("forums_create_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class CreateForumResponse
    {
        [XmlElement("fid"), JsonProperty("fid")] public int Fid;
        [JsonProperty("url"), XmlElement("url")] public string Url;
    }
}