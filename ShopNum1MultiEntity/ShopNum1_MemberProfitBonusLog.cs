using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MemberProfitBonusLog")]
    public class ShopNum1_MemberProfitBonusLog
    {
        private DateTime? dateTime_0;
        private decimal? decimal_0;
        private Guid guid_0;
        private Guid guid_1;
        private Guid? guid_2;
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        //[Column(Storage = "_GroupPrice", DbType = "Decimal(18,2)")]
        public decimal? GroupPrice
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

        //[Column(Storage = "_InstructorGuid", DbType = "UniqueIdentifier")]
        public Guid? InstructorGuid
        {
            get { return guid_2; }
            set
            {
                if (guid_2 != value)
                {
                    guid_2 = value;
                }
            }
        }

        //[Column(Storage = "_InstructorName", DbType = "NVarChar(50)")]
        public string InstructorName
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

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
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

        //[Column(Storage = "_MemberLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemberLoginID
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

        //[Column(Storage = "_OrderNumber", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OrderNumber
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

        //[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid ProductGuid
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

        //[Column(Storage = "_ProductName", DbType = "NVarChar(50)")]
        public string ProductName
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

        //[Column(Storage = "_RecordTime", DbType = "SmallDateTime")]
        public DateTime? RecordTime
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
    }
}