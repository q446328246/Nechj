using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    public class Friend : SessionWrapper
    {
        [XmlElement("uid")] public long UId;

        public Friend()
        {
        }

        public Friend(long UId, DiscuzSession session)
        {
            this.UId = UId;
            base.discuzSession_0 = session;
        }

        public User GetUserInfo()
        {
            return base.discuzSession_0.GetUserInfo(new[] {UId}, User.FIELDS)[0];
        }
    }
}