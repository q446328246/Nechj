using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("users_changePassword_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class ChangePasswordResponse
    {
        [XmlText] public int Result;
    }
}