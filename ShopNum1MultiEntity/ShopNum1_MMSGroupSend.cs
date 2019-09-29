using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MMSGroupSend")]
    public class ShopNum1_MMSGroupSend
    {
        private DateTime dateTime_0;
        private DateTime? dateTime_1;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;
        private int int_1;
        private string string_0;
        private string string_1;
        private string string_2;

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

        //[Column(Storage = "_IsTime", DbType = "Int NOT NULL")]
        public int IsTime
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

        //[Column(Storage = "_MMSGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid MMSGuid
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

        //[Column(Storage = "_MMSTitle", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MMSTitle
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

        //[Column(Storage = "_SendObject", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string SendObject
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

        //[Column(Storage = "_SendObjectMMS", DbType = "NVarChar(4000) NOT NULL", CanBeNull = false)]
        public string SendObjectMMS
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

        //[Column(Storage = "_State", DbType = "Int NOT NULL")]
        public int State
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

        //[Column(Storage = "_TimeSendTime", DbType = "DateTime")]
        public DateTime? TimeSendTime
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