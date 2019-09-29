namespace ShopNum1.Email
{
    public class RegisterOutofStock
    {
        public string latestTime { get; set; }

        public string MemberName { get; set; }

        public string Number { get; set; }

        public string Product { get; set; }

        public string ReplyMemo { get; set; }

        public string ReplyTime { get; set; }

        public string ReplyUser { get; set; }

        public string SendTime { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string ChangeRegisterOutofStock(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$MemberName}", MemberName)
                    .Replace("{$SendTime}", SendTime)
                    .Replace("{$ReplyUser}", ReplyUser)
                    .Replace("{$ReplyTime}", ReplyTime)
                    .Replace("{$ReplyMemo}", ReplyMemo)
                    .Replace("{$Product}", Product)
                    .Replace("{$Number}", Number)
                    .Replace("{$latestTime}", latestTime)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$SendTime}", SysSendTime);
        }
    }
}