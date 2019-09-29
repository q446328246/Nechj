using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_delete_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicDeleteResponse
    {
        [XmlText] public int Result;
    }
}