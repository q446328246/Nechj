using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_Coupon")]
    public class ShopNum1_Shop_Coupon
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private DateTime dateTime_2;
        private DateTime? dateTime_3;
        private Guid guid_0;
        private int int_0;
        private int? int_1;
        private int int_10;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private int int_8;
        private int int_9;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_AdressCode", DbType = "NVarChar(50)")]
        public string AdressCode
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

        //[Column(Storage = "_AdressName", DbType = "NVarChar(100)")]
        public string AdressName
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

        //[Column(Storage = "_BrowserCount", DbType = "Int")]
        public int? BrowserCount
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    int_3 = value;
                }
            }
        }

        //[Column(Storage = "_Content", DbType = "NVarChar(MAX)")]
        public string Content
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

        //[Column(Storage = "_CouponName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string CouponName
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

        //[Column(Storage = "_CreateTime", DbType = "DateTime NOT NULL")]
        public DateTime CreateTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    dateTime_2 = value;
                }
            }
        }

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CreateUser
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

        //[Column(Storage = "_DownloadCount", DbType = "Int")]
        public int? DownloadCount
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    int_1 = value;
                }
            }
        }

        //[Column(Storage = "_EndTime", DbType = "DateTime NOT NULL")]
        public DateTime EndTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    dateTime_1 = value;
                }
            }
        }

        //[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid Guid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    guid_0 = value;
                }
            }
        }

        //[Column(Storage = "_ImgPath", DbType = "NVarChar(500)")]
        public string ImgPath
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

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    int_5 = value;
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    int_6 = value;
                }
            }
        }

        //[Column(Storage = "_IsEffective", DbType = "Int")]
        public int? IsEffective
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    int_4 = value;
                }
            }
        }

        //[Column(Storage = "_IsHot", DbType = "Int NOT NULL")]
        public int IsHot
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    int_8 = value;
                }
            }
        }

        //[Column(Storage = "_IsNew", DbType = "Int NOT NULL")]
        public int IsNew
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    int_9 = value;
                }
            }
        }

        //[Column(Storage = "_IsRecommend", DbType = "Int NOT NULL")]
        public int IsRecommend
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    int_10 = value;
                }
            }
        }

        //[Column(Storage = "_IsShow", DbType = "Int NOT NULL")]
        public int IsShow
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    int_7 = value;
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
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

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    dateTime_3 = value;
                }
            }
        }

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    string_8 = value;
                }
            }
        }

        //[Column(Storage = "_SaleTitle", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string SaleTitle
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    string_9 = value;
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "NVarChar(50)")]
        public string ShopName
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

        //[Column(Storage = "_StartTime", DbType = "DateTime NOT NULL")]
        public DateTime StartTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    dateTime_0 = value;
                }
            }
        }

        //[Column(Storage = "_Type", DbType = "Int NOT NULL")]
        public int Type
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    int_0 = value;
                }
            }
        }

        //[Column(Storage = "_UseCount", DbType = "Int")]
        public int? UseCount
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    int_2 = value;
                }
            }
        }
    }
}