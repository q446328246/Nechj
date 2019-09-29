using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("users_getInfo_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class UserInfoResponse
    {
        [XmlAttribute("list")] public bool List;
        [XmlElement("user")] public User[] user_array;

        [XmlIgnore]
        public User[] Users
        {
            get { return (user_array ?? new User[0]); }
        }
    }
}