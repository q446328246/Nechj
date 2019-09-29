using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("auth_encodePassword_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class EncodePasswordResponse
    {
        [XmlText] public string Password;
    }
}