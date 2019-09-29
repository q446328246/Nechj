using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("error_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class Error
    {
        [XmlElement("request_args", IsNullable = false)] public ArgResponse Args;
        [XmlElement("error_code")] public int ErrorCode;
        [XmlElement("error_msg")] public string ErrorMsg;
    }
}