using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_ProductBooking")]
    public class ShopNum1_Shop_ProductBooking
    {
        private DateTime dateTime_0;
        private Guid guid_0;
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_10;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_Address", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string Address
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

        //[Column(Storage = "_Email", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string Email
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

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
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

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
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

        //[Column(Storage = "_Mobile", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string Mobile
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

        //[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
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

        //[Column(Storage = "_Postalcode", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string Postalcode
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

        //[Column(Storage = "_ProductGuid", DbType = "NVarChar(50)")]
        public string ProductGuid
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

        //[Column(Storage = "_ProductName", DbType = "NVarChar(50)")]
        public string ProductName
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

        //[Column(Storage = "_Rank", DbType = "NVarChar(500)")]
        public string Rank
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

        //[Column(Storage = "_SendDate", DbType = "DateTime NOT NULL")]
        public DateTime SendDate
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

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ShopID
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

        //[Column(Storage = "_Tel", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string Tel
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
    }
}