namespace ShopNum1.Email
{
    public class MemberRecommend
    {
        public string Name { get; set; }

        public string ShopName { get; set; }

        public string ChangeMemberRecommed(string content)
        {
            string str = string.Empty;
            str = content;
            return str.Replace("{$Name}", Name).Replace("{$ShopName}", ShopName);
        }
    }
}