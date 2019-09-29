using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_ProductSpell")]
    public class ShopNum1_Shop_ProductSpell
    {
        private DateTime dateTime_0;
        private Guid guid_0;
        private int int_0;
        private string string_0;
        private string string_1;

        //[Column(Storage = "_BuyCount", DbType = "Int NOT NULL")]
        public int BuyCount
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

        //[Column(Storage = "_BuyDate", DbType = "DateTime NOT NULL")]
        public DateTime BuyDate
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

        //[Column(Storage = "_MemberLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemberLoginID
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

        //[Column(Storage = "_ProductGuid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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
    }
}