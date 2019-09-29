using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_IPManage")]
    public class ShopNum1_IPManage
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private Guid guid_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

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

        //[Column(Storage = "_IPBegin", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IPBegin
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

        //[Column(Storage = "_IPEnd", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IPEnd
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

        //[Column(Storage = "_IPGroupName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IPGroupName
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

        //[Column(Storage = "_Remark", DbType = "NVarChar(250)")]
        public string Remark
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

        //[Column(Storage = "_TimeBegin", DbType = "DateTime NOT NULL")]
        public DateTime TimeBegin
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

        //[Column(Storage = "_TimeEnd", DbType = "DateTime NOT NULL")]
        public DateTime TimeEnd
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
    }
}