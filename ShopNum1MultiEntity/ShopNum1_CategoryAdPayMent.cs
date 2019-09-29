using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_CategoryAdPayMent")]
    public class ShopNum1_CategoryAdPayMent
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private DateTime dateTime_2;
        private DateTime? dateTime_3;
        private decimal decimal_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_AdvertisementContent", DbType = "NVarChar(250)")]
        public string AdvertisementContent
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

        //[Column(Storage = "_AdvertisementID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AdvertisementID
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

        //[Column(Storage = "_AdvertisementLike", DbType = "NVarChar(100)")]
        public string AdvertisementLike
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

        //[Column(Storage = "_AdvertisementPic", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string AdvertisementPic
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

        //[Column(Storage = "_BuyTime", DbType = "DateTime NOT NULL")]
        public DateTime BuyTime
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

        //[Column(Storage = "_CategoryAdID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CategoryAdID
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

        //[Column(Storage = "_CategoryCode", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string CategoryCode
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

        //[Column(Storage = "_CategoryName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CategoryName
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

        //[Column(Storage = "_CategoryType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CategoryType
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

        //[Column(Storage = "_EndTime", DbType = "DateTime NOT NULL")]
        public DateTime EndTime
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

        //[Column(Storage = "_FailCause", DbType = "NVarChar(250)")]
        public string FailCause
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

        //[Column(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", //IsDbGenerated = true)]
        public int ID
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

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
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

        //[Column(Storage = "_IsEffective", DbType = "Int NOT NULL")]
        public int IsEffective
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

        //[Column(Storage = "_IsPayMent", DbType = "Int NOT NULL")]
        public int IsPayMent
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

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
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

        //[Column(Storage = "_PayMentName", DbType = "NVarChar(50)")]
        public string PayMentName
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

        //[Column(Storage = "_PayMentTime", DbType = "DateTime")]
        public DateTime? PayMentTime
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

        //[Column(Storage = "_PayMentType", DbType = "NVarChar(50)")]
        public string PayMentType
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

        //[Column(Storage = "_ShowPayMentPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal ShowPayMentPrice
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    decimal_0 = value;
                }
            }
        }

        //[Column(Storage = "_StartTime", DbType = "DateTime NOT NULL")]
        public DateTime StartTime
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

        //[Column(Storage = "_TradeID", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string TradeID
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
    }
}