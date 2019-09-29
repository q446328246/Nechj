namespace ShopNum1.Email
{
    public class RegIsActivationEmail
    {
        public string Email { get; set; }

        public string link { get; set; }

        public string Name { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string ChangeRegister(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$Email}", Email)
                    .Replace("{$SendTime}", SysSendTime)
                    .Replace("{$link}", link);
        }
    }
}