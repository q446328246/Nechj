using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_OtherOrderInfo")]
    public class ShopNum1_Shop_OtherOrderInfo
    {
        private DateTime dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private decimal decimal_0;
        private decimal decimal_1;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;
        private int int_1;
        private int int_2;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;

        //[Column(Storage = "_BuyNumber", DbType = "Int NOT NULL")]
        public int BuyNumber
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

        //[Column(Storage = "_CreateTime", DbType = "DateTime NOT NULL")]
        public DateTime CreateTime
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

        //[Column(Storage = "_Description", DbType = "NVarChar(MAX)")]
        public string Description
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

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
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

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
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

        //[Column(Storage = "_Name", DbType = "NChar(100) NOT NULL", CanBeNull = false)]
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

        //[Column(Storage = "_OrderStatus", DbType = "Int NOT NULL")]
        public int OrderStatus
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

        //[Column(Storage = "_PaymentName", DbType = "NChar(100) NOT NULL", CanBeNull = false)]
        public string PaymentName
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

        //[Column(Storage = "_PaymentStatus", DbType = "Int NOT NULL")]
        public int PaymentStatus
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

        //[Column(Storage = "_PaymentTime", DbType = "DateTime")]
        public DateTime? PaymentTime
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

        //[Column(Storage = "_PaymentType", DbType = "UniqueIdentifier NOT NULL")]
        public Guid PaymentType
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    guid_1 = value;
                }
            }
        }

        //[Column(Storage = "_RelevanceID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string RelevanceID
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

        //[Column(Storage = "_TotalPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal TotalPrice
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    decimal_1 = value;
                }
            }
        }

        //[Column(Storage = "_TradeID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string TradeID
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

        //[Column(Storage = "_Type", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Type
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

        //[Column(Storage = "_UnitPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal UnitPrice
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
    }
}