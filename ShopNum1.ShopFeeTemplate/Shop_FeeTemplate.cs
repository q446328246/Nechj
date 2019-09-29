using System;

namespace ShopNum1.ShopFeeTemplate
{
    [Serializable]
    public class Shop_FeeTemplate
    {
        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        public string altertime
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(string_9).ToString("yyyy-MM-dd hh:mm:ss");
                }
                catch
                {
                    return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
            set { string_9 = value; }
        }

        public string createtime
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(string_8).ToString("yyyy-MM-dd hh:mm:ss");
                }
                catch
                {
                    return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
            set { string_8 = value; }
        }

        public string feetype
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string groupid
        {
            get { return string_10; }
            set { string_10 = value; }
        }

        public string groupregioncodes
        {
            get { return string_12; }
            set { string_12 = value; }
        }

        public string groupregionnames
        {
            get { return string_11; }
            set { string_11 = value; }
        }

        public string oneadd
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public string orderid
        {
            get { return string_13; }
            set { string_13 = value; }
        }

        public string regioncode
        {
            get { return string_6; }
            set { string_6 = value; }
        }

        public string regionname
        {
            get { return string_7; }
            set { string_7 = value; }
        }

        public string fee
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string String_1
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string templateid
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string templatename
        {
            get { return string_2; }
            set { string_2 = value; }
        }
    }
}