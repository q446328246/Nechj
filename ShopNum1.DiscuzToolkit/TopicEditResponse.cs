using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("topics_edit_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TopicEditResponse
    {
        [XmlText] public int Result;
    }
}