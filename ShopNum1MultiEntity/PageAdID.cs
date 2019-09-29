////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    // //[Table(Name = "dbo.PageAdID")]
    public class PageAdID
    {
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;

        ////[Column(Storage = "_Content", DbType = "varchar(2000)", CanBeNull = false)]
        public string Content
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    string_7 = value;
                }
            }
        }

        // //[Column(Storage = "_DivID", DbType = "NVarChar(150)")]
        public string DivID
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

        //   //[Column(Storage = "_FileName", DbType = "NVarChar(50)")]
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

        //  //[Column(Storage = "_Height", DbType = "NVarChar(50)")]
        public string Height
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    string_5 = value;
                }
            }
        }

        ////[Column(Storage = "_ImgSrc", DbType = "varchar(200)", CanBeNull = false)]
        public string ImgSrc
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    string_6 = value;
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

        ////[Column(Storage = "_Width", DbType = "NVarChar(50)")]
        public string Width
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
    }
}