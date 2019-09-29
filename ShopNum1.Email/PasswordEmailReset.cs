namespace ShopNum1.Email
{
    public class PasswordEmailReset
    {
        public string ChangePwdUrl { get; set; }

        public string ExtireTime { get; set; }

        public string Hour { get; set; }

        public string MemloginID { get; set; }

        public string PassWord { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string ChangePasswordEmailReset(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$ChangePwdUrl}", ChangePwdUrl)
                    .Replace("{$Hour}", Hour)
                    .Replace("{$ExtireTime}", ExtireTime)
                    .Replace("{$Name}", MemloginID)
                    .Replace("{$PassWord}", PassWord)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$SendTime}", SysSendTime);
        }
    }
}