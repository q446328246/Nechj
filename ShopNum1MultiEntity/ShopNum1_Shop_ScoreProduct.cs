using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_ScoreProduct")]
    public class ShopNum1_Shop_ScoreProduct
    {
        private byte? byte_0;
        private byte? byte_1;
        private byte? byte_2;
        private byte? byte_3;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private decimal? decimal_0;
        private decimal? decimal_1;
        private Guid? guid_0;
        private int? int_0;
        private int? int_1;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int? int_6;
        private int? int_7;
        private int? int_8;
        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_14;
        private string string_15;
        private string string_16;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_Brief", DbType = "NVarChar(500)")]
        public string Brief
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

        //[Column(Storage = "_ClickCount", DbType = "Int")]
        public int? ClickCount
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

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
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

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    string_15 = value;
                }
            }
        }

        //[Column(Storage = "_Detail", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Detail
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

        //[Column(Storage = "_Guid", DbType = "UniqueIdentifier")]
        public Guid? Guid
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

        //[Column(Storage = "_HaveSale", DbType = "Int")]
        public int? HaveSale
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

        //[Column(Storage = "_IsAudit", DbType = "TinyInt")]
        public byte? IsAudit
        {
            get { return byte_2; }
            set
            {
                if (byte_2 != value)
                {
                    byte_2 = value;
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
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

        //[Column(Storage = "_IsHot", DbType = "TinyInt")]
        public byte? IsHot
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    byte_1 = value;
                }
            }
        }

        //[Column(Storage = "_IsNew", DbType = "TinyInt")]
        public byte? IsNew
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    byte_0 = value;
                }
            }
        }

        //[Column(Storage = "_IsRecommend", DbType = "TinyInt")]
        public byte? IsRecommend
        {
            get { return byte_3; }
            set
            {
                if (byte_3 != value)
                {
                    byte_3 = value;
                }
            }
        }

        //[Column(Storage = "_IsSaled", DbType = "Int")]
        public int? IsSaled
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

        //[Column(Storage = "_MarketPrice", DbType = "Decimal(18,2)")]
        public decimal? MarketPrice
        {
            get { return decimal_1; }
            set
            {
                decimal? nullable = decimal_1;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    decimal_1 = value;
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "VarChar(100)")]
        public string MemLoginID
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    string_12 = value;
                }
            }
        }

        //[Column(Storage = "_Meto_Description", DbType = "NVarChar(150)")]
        public string Meto_Description
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    string_10 = value;
                }
            }
        }

        //[Column(Storage = "_Meto_Keywords", DbType = "NVarChar(200)")]
        public string Meto_Keywords
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    string_11 = value;
                }
            }
        }

        //[Column(Storage = "_Meto_Title", DbType = "NVarChar(150)")]
        public string Meto_Title
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

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
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

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    string_16 = value;
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(100)")]
        public string Name
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

        //[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
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

        //[Column(Storage = "_OriginalImge", DbType = "NVarChar(250)")]
        public string OriginalImge
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

        //[Column(Storage = "_ProductCategoryCode", DbType = "NVarChar(10)")]
        public string ProductCategoryCode
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    string_14 = value;
                }
            }
        }

        //[Column(Storage = "_ProductCategoryID", DbType = "Int")]
        public int? ProductCategoryID
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

        //[Column(Storage = "_ProductCategoryName", DbType = "NVarChar(500)")]
        public string ProductCategoryName
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

        //[Column(Storage = "_RepertoryCount", DbType = "Int")]
        public int? RepertoryCount
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

        //[Column(Storage = "_RepertoryNumber", DbType = "NVarChar(50)")]
        public string RepertoryNumber
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

        //[Column(Storage = "_RepertoryWarnCount", DbType = "Int")]
        public int? RepertoryWarnCount
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

        //[Column(Storage = "_SaleTime", DbType = "DateTime")]
        public DateTime? SaleTime
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

        //[Column(Storage = "_Score", DbType = "Int")]
        public int? Score
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

        //[Column(Storage = "_ShopID", DbType = "VarChar(100)")]
        public string ShopID
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    string_13 = value;
                }
            }
        }

        //[Column(Storage = "_SmallImage", DbType = "NVarChar(250)")]
        public string SmallImage
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

        //[Column(Storage = "_ThumbImage", DbType = "NVarChar(250)")]
        public string ThumbImage
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

        //[Column(Storage = "_UnitName", DbType = "NVarChar(20)")]
        public string UnitName
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

        //[Column(Storage = "_Weight", DbType = "Decimal(18,2)")]
        public decimal? Weight
        {
            get { return decimal_0; }
            set
            {
                decimal? nullable = decimal_0;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    decimal_0 = value;
                }
            }
        }
    }
}