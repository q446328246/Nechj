using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_CategoryAdvertisement")]
    public class ShopNum1_CategoryAdvertisement
    {
        private DateTime? dateTime_0;
        private decimal decimal_0;
        private int int_0;
        private int? int_1;
        private int? int_2;
        private int int_3;
        private int? int_4;
        private int int_5;
        private int int_6;
        private int int_7;
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

        //[Column(Storage = "_AdDefaultLike", DbType = "NVarChar(250)")]
        public string AdDefaultLike
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

        //[Column(Storage = "_AdIntroduce", DbType = "NVarChar(250)")]
        public string AdIntroduce
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

        //[Column(Storage = "_Adlocation", DbType = "NVarChar(250)")]
        public string Adlocation
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

        //[Column(Storage = "_AdvertisementDPic", DbType = "NVarChar(250)")]
        public string AdvertisementDPic
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

        //[Column(Storage = "_Advertisementflow", DbType = "Int")]
        public int? Advertisementflow
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

        //[Column(Storage = "_AdvertisementLike", DbType = "NVarChar(250)")]
        public string AdvertisementLike
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

        //[Column(Storage = "_AdvertisementName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AdvertisementName
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

        //[Column(Storage = "_AdvertisementNPic", DbType = "NVarChar(250)")]
        public string AdvertisementNPic
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

        //[Column(Storage = "_AdvertisementPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal AdvertisementPrice
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

        //[Column(Storage = "_CategoryAdID", DbType = "Int NOT NULL")]
        public int CategoryAdID
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

        //[Column(Storage = "_CategoryCode", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string CategoryCode
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

        //[Column(Storage = "_CategoryName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CategoryName
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

        //[Column(Storage = "_CategoryType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CategoryType
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

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
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

        //[Column(Storage = "_Height", DbType = "Int")]
        public int? Height
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

        //[Column(Storage = "_IsBuy", DbType = "Int NOT NULL")]
        public int IsBuy
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

        //[Column(Storage = "_IsEnabled", DbType = "Int NOT NULL")]
        public int IsEnabled
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

        //[Column(Storage = "_IsShow", DbType = "Int NOT NULL")]
        public int IsShow
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

        //[Column(Storage = "_Width", DbType = "Int")]
        public int? Width
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
    }
}