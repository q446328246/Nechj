using System;

namespace ShopNum1.Second
{
    [Serializable]
    public class ShopNum1_SecondUser
    {
        private DateTime dateTime_0;
        private int int_0;
        private int int_1;
        private string string_0;
        private string string_1;
        private string string_2;

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

        public int isAvailable
        {
            get { return int_1; }
            set { int_1 = value; }
        }

        public string MemlogID
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string SecondID
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string Secondtype
        {
            get { return string_2; }
            set { string_2 = value; }
        }
    }
}