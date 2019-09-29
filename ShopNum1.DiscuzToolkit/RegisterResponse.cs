using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("auth_register_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class RegisterResponse
    {
        [XmlText] public int Uid;
    }
}