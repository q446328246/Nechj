using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("users_setInfo_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class SetInfoResponse
    {
        [XmlText] public int Successfull;
    }
}