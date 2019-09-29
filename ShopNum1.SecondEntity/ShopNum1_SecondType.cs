using System;

namespace ShopNum1.Second
{
    [Serializable]
    public class ShopNum1_SecondType
    {
        private DateTime dateTime_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

        public string AppID
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string AppSecret
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string content
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public DateTime createTime
        {
            get { return dateTime_0; }
            set { dateTime_0 = value; }
        }

        public int ID
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public string ImgSrc
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public int isAvabile
        {
            get { return int_1; }
            set { int_1 = value; }
        }

        public int OrderID
        {
            get { return int_2; }
            set { int_2 = value; }
        }

        public string redirectURL
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string TypeName
        {
            get { return string_0; }
            set { string_0 = value; }
        }
    }
}