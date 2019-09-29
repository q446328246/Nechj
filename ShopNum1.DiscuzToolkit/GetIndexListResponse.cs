using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("forums_getIndexList_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class GetIndexListResponse
    {
        [XmlElement("forum"), JsonProperty("forums")] public IndexForum[] Forum;
    }
}