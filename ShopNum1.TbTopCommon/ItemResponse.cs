using System;

namespace ShopNum1.TbTopCommon
{
    public class ItemResponse
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;

        public string created
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(string_2).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { string_2 = value; }
        }

        public string modified
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(string_3).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { string_3 = value; }
        }

        public string num_iid
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string String_0
        {
            get { return string_0; }
            set { string_0 = value; }
        }
    }
}