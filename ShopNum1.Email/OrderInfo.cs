namespace ShopNum1.Email
{
    public class OrderInfo
    {
        public string Name { get; set; }

        public string OrderNumber { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string ChangeOrderInfo(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$OrderNumber}", OrderNumber)
                    .Replace("{$SendTime}", SysSendTime);
        }
    }
}