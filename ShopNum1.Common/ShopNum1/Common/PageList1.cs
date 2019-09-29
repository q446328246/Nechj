namespace ShopNum1.Common
{
    public class PageList1
    {
        private int pageCount = 1;
        private int pageID = 1;
        private int pageSize = 20;
        private int recordCount = 1;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }

        public int PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }
    }
}