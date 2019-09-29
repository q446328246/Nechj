namespace ShopNum1.Email
{
    public class ModifyProtectAnswer
    {
        public string Answer { get; set; }

        public string Name { get; set; }

        public string Question { get; set; }

        public string SendTime { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string Url { get; set; }

        public string ChangeModifyProtectAnswer(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$SendTime}", SendTime)
                    .Replace("{$Question}", Question)
                    .Replace("{$Answer}", Answer)
                    .Replace("{$Url}", Url)
                    .Replace("{$SendTime}", SysSendTime);
        }
    }
}