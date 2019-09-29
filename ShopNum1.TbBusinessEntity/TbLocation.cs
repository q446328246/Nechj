namespace ShopNum1.TbBusinessEntity
{
    public class TbLocation
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;

        public string address
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string city
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string country
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string district
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public string state
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string zip
        {
            get { return string_0; }
            set { string_0 = value; }
        }
    }
}