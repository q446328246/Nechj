using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("users_setExtCredits_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class SetExtCreditsResponse
    {
        [XmlText] public int Successfull;
    }
}