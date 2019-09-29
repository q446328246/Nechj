using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ServiceLog")]
    public class ShopNum1_ServiceLog
    {
        private DateTime dateTime_0;
        private Guid guid_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

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

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CreateUser
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

        //[Column(Storage = "_Remark", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string Remark
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

        //[Column(Storage = "_ServiceName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ServiceName
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

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ShopID
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
    }
}