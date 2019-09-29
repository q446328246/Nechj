using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("users_getID_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class GetIDResponse
    {
        [XmlText] public int UId;
    }
}