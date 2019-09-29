using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_deleteReplies_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicDeleteRepliesResponse
    {
        [XmlText] public string Result;
    }
}