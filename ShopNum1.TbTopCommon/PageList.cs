namespace ShopNum1.TbTopCommon
{
    public class PageList
    {
        private int int_0 = 20;
        private int int_1 = 1;
        private int int_2 = 1;
        private int int_3 = 1;

        public int PageCount
        {
            get { return int_2; }
            set { int_2 = value; }
        }

        public int PageID
        {
            get { return int_1; }
            set { int_1 = value; }
        }

        public int PageSize
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public int RecordCount
        {
            get { return int_3; }
            set { int_3 = value; }
        }
    }
}