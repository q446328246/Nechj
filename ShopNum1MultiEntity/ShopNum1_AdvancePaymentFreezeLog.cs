using System;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    // //[Table(Name = "dbo.ShopNum1_AdvancePaymentFreezeLog")]
    public class ShopNum1_AdvancePaymentFreezeLog
    {
        private DateTime dateTime_0;
        private decimal decimal_0;
        private decimal decimal_1;
        private decimal decimal_2;
        private Guid guid_0;
        private int int_0;
        private int? int_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        ////[Column(Storage = "_CreateTime", DbType = "NVarChar(50)")]
        public string CreateTime
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

        // //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
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

        ////[Column(Storage = "_CurrentAdvancePayment", DbType = "Decimal(18,2) NOT NULL")]
        public decimal CurrentAdvancePayment
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

        ////[Column(Storage = "_Date", DbType = "DateTime NOT NULL")]
        public DateTime Date
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

        // //[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL")]
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

        // //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
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

        // //[Column(Storage = "_LastOperateMoney", DbType = "Decimal(18,2) NOT NULL")]
        public decimal LastOperateMoney
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    decimal_2 = value;
                }
            }
        }

        // //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
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

        // //[Column(Storage = "_Memo", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Memo
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

        // //[Column(Storage = "_OperateMoney", DbType = "Decimal(18,2) NOT NULL")]
        public decimal OperateMoney
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

        // //[Column(Storage = "_OperateType", DbType = "Int NOT NULL")]
        public int OperateType
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
    }
}