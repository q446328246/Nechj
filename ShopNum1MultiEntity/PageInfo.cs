////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.PageInfo")]
    public class PageInfo
    {
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        // //[Column(Storage = "_divid", CanBeNull = false)]
        public string divid
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    string_4 = value;
                }
            }
        }

        ////[Column(Storage = "_FileName", DbType = "NVarChar(50)")]
        public string FileName
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    string_2 = value;
                }
            }
        }

        // //[Column(Storage = "_Guid", DbType = "NVarChar(50)")]
        public string Guid
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    string_0 = value;
                }
            }
        }

        // //[Column(Storage = "_PageName", DbType = "NVarChar(50)")]
        public string PageName
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    string_1 = value;
                }
            }
        }

        //  //[Column(Storage = "_PageNote", DbType = "NVarChar(250)")]
        public string PageNote
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    string_3 = value;
                }
            }
        }
    }
}