using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("auth_createToken_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class TokenInfo
    {
        [XmlElement("session_key")] public string Token;
    }
}