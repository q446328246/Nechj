using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_IPInfo")]
    public class ShopNum1_IPInfo
    {
        private Guid guid_0;
        private int int_0;
        private string string_0;
        private string string_1;

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

        //[Column(Storage = "_IPGroupGuid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IPGroupGuid
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

        //[Column(Storage = "_IPName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IPName
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

        //[Column(Storage = "_IsForbid", DbType = "Int NOT NULL")]
        public int IsForbid
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