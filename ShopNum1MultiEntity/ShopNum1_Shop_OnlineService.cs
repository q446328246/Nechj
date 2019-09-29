using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_OnlineService")]
    public class ShopNum1_Shop_OnlineService
    {
        private Guid guid_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

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
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    int_0 = value;
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
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

        //[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
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

        //[Column(Storage = "_OrderID", DbType = "Int NOT NULL")]
        public int OrderID
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

        //[Column(Storage = "_ServiceAccount", DbType = "NVarChar(25) NOT NULL", CanBeNull = false)]
        public string ServiceAccount
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

        //[Column(Storage = "_Type", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Type
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

        //[Column(Storage = "_TypeName", CanBeNull = false)]
        public string TypeName
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    string_4 = value;
                }
            }
        }
    }
}