using System;

namespace ShopNum1.TbBusinessEntity
{
    public class TbSku
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        public string created
        {
            get
            {
                try
                {
                    return (string_7 = Convert.ToDateTime(string_7).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch
                {
                    return ((string_7 == string.Empty) ? "1990-1-1 00:00:00" : "1991-1-1 00:00:01");
                }
            }
            set { string_7 = value; }
        }

        public string modified
        {
            get
            {
                try
                {
                    return (string_8 = Convert.ToDateTime(string_8).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch
                {
                    return ((string_8 == string.Empty) ? "1990-1-1 00:00:00" : "1991-1-1 00:00:01");
                }
            }
            set { string_8 = value; }
        }

        public string num_iid
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string outer_id
        {
            get { return string_6; }
            set { string_6 = value; }
        }

        public string price
        {
            get
            {
                try
                {
                    return Convert.ToDouble(string_5).ToString("#.00");
                }
                catch
                {
                    return ((string_5 != string.Empty) ? "0.00" : "");
                }
            }
            set { string_5 = value; }
        }

        public string properties
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string propertiesText
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public int quantity { get; set; }

        public string sku_id
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string status
        {
            get { return string_9; }
            set { string_9 = value; }
        }

        public string String_0
        {
            get { return string_1; }
            set { string_1 = value; }
        }
    }
}