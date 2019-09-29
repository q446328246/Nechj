using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_GroupPageWebControl")]
    public class ShopNum1_GroupPageWebControl
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private Guid guid_0;
        private Guid guid_1;
        private Guid guid_2;
        private Guid guid_3;
        private int int_0;
        private int int_1;
        private int int_2;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        //[Column(Storage = "_ControlID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ControlID
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

        //[Column(Storage = "_ControlType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ControlType
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
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    string_2 = value;
                }
            }
        }

        //[Column(Storage = "_GroupGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid GroupGuid
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

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
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

        //[Column(Storage = "_IsShow", DbType = "Int NOT NULL")]
        public int IsShow
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

        //[Column(Storage = "_IsUse", DbType = "Int NOT NULL")]
        public int IsUse
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
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    string_3 = value;
                }
            }
        }

        //[Column(Storage = "_PageGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid PageGuid
        {
            get { return guid_3; }
            set
            {
                if (guid_3 != value)
                {
                    guid_3 = value;
                }
            }
        }

        //[Column(Storage = "_PageWebControlGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid PageWebControlGuid
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
    }
}