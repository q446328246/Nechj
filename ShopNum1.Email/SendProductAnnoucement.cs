namespace ShopNum1.Email
{
    public class SendProductAnnoucement
    {
        public string Memo { get; set; }

        public string Name { get; set; }

        public string OrderNumber { get; set; }

        public string SendTime { get; set; }

        public string ShopDoMain { get; set; }

        public string ShopName { get; set; }

        public string ChangeSendProductAnnoucement(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$OrderNumber}", OrderNumber)
                    .Replace("{$DoMain}", ShopDoMain)
                    .Replace("{$SendTime}", SendTime)
                    .Replace("{$Memo}", Memo)
                    .Replace("{$ShopName}", ShopName);
        }
    }
}