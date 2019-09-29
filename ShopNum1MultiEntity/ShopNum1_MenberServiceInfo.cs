using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MenberServiceInfo")]
    public class ShopNum1_MenberServiceInfo
    {
        private DateTime? dateTime_0;
        private Guid? guid_0;
        private int? int_0;
        private int? int_1;
        private string string_0;
        private string string_1;

        //[Column(Storage = "_EndTime", DbType = "DateTime")]
        public DateTime? EndTime
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

        //[Column(Storage = "_OtherProductCount", DbType = "Int")]
        public int? OtherProductCount
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

        //[Column(Storage = "_ServiceGuid", DbType = "NVarChar(50)")]
        public string ServiceGuid
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

        //[Column(Storage = "_ServiceProductCount", DbType = "Int")]
        public int? ServiceProductCount
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

        //[Column(Storage = "_ShopName", DbType = "NVarChar(50)")]
        public string ShopName
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