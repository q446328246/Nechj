namespace ShopNum1.Email
{
    public class PasswordReset
    {
        public string Name { get; set; }

        public string PassWord { get; set; }

        public string SendTime { get; set; }

        public string ShopName { get; set; }

        public string SysSendTime { get; set; }

        public string ChangePasswordReset(string content)
        {
            string str = string.Empty;
            str = content;
            return
                str.Replace("{$Name}", Name)
                    .Replace("{$SendTime}", SendTime)
                    .Replace("{$PassWord}", PassWord)
                    .Replace("{$ShopName}", ShopName)
                    .Replace("{$SendTime}", SysSendTime);
        }
    }
}