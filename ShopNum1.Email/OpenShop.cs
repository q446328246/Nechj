namespace ShopNum1.Email
{
    public class OpenShop
    {
        public string Name { get; set; }

        public string ShopID { get; set; }

        public string ShopName { get; set; }

        public string ShopStatus { get; set; }

        public string SysSendTime { get; set; }

        public string ChangeOpenShop(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$ShopID}", ShopID)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$ShopStatus}", ShopStatus)
                    .Replace("{$SendTime}", SysSendTime);
        }
    }
}