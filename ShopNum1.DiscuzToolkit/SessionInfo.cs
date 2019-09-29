using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    [XmlRoot("auth_getSession_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
    public class SessionInfo
    {
        [XmlElement("expires")] public long Expires;
        [XmlIgnore] public string Secret;
        [XmlElement("session_key")] public string SessionKey;
        [XmlElement("uid")] public long UId;
        [XmlElement("user_name")] public string UserName;

        public SessionInfo()
        {
        }

        public SessionInfo(string session_key, long long_0, string secret, string rest_url)
        {
            SessionKey = session_key;
            UId = long_0;
            Secret = secret;
            Expires = 0L;
        }
    }
}