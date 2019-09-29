namespace ShopNum1.Email
{
    public class UpdateOrderStute
    {
        public string Name { get; set; }

        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string UpdateTime { get; set; }

        public string ChangeUpdateOrderStute(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$OrderNumber}", OrderNumber)
                    .Replace("{$OrderStatus}", OrderStatus)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$UpdateTime}", UpdateTime)
                    .Replace("$SendTime}", SysSendTime);
        }
    }
}