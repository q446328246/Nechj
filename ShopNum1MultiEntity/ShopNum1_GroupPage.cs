using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_GroupPage")]
    public class ShopNum1_GroupPage
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private Guid guid_0;
        private int int_0;
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

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CreateUser
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

        //[Column(Storage = "_GroupGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid GroupGuid
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

        //[Column(Storage = "_ModifyTime", DbType = "DateTime NOT NULL")]
        public DateTime ModifyTime
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

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ModifyUser
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

        //[Column(Storage = "_PageGuid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string PageGuid
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