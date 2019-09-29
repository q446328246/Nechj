namespace ShopNum1.TbBusinessEntity
{
    public class TbItemCat
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;

        public bool is_parent { get; set; }

        public string name
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string parent_cid
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public int sort_order { get; set; }

        public string status
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string cid
        {
            get { return string_0; }
            set { string_0 = value; }
        }
    }
}