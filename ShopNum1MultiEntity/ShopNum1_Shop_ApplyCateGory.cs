using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_ApplyCateGory")]
    public class ShopNum1_Shop_ApplyCateGory
    {
        private DateTime dateTime_0;
        private DateTime? dateTime_1;
        private Guid guid_0;
        private Guid guid_1;
        private Guid? guid_2;
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;

        //[Column(Storage = "_ApplyTime", DbType = "DateTime NOT NULL")]
        public DateTime ApplyTime
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

        //[Column(Storage = "_BrandName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string BrandName
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

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
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

        //[Column(Storage = "_NewBrandGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid NewBrandGuid
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

        //[Column(Storage = "_NewShopCateGoryCode", DbType = "VarChar(20) NOT NULL", CanBeNull = false)]
        public string NewShopCateGoryCode
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

        //[Column(Storage = "_OldBrandGuid", DbType = "UniqueIdentifier")]
        public Guid? OldBrandGuid
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

        //[Column(Storage = "_OldBrandName", DbType = "NVarChar(100)")]
        public string OldBrandName
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    string_6 = value;
                }
            }
        }

        //[Column(Storage = "_OldShopCategoryCode", DbType = "VarChar(20)")]
        public string OldShopCategoryCode
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    string_7 = value;
                }
            }
        }

        //[Column(Storage = "_OldShopCategoryName", DbType = "NVarChar(100)")]
        public string OldShopCategoryName
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    string_5 = value;
                }
            }
        }

        //[Column(Storage = "_Remarks", DbType = "NVarChar(250)")]
        public string Remarks
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

        //[Column(Storage = "_ShopCategoryName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string ShopCategoryName
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

        //[Column(Storage = "_ShopID", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string ShopID
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

        //[Column(Storage = "_VerifyTime", DbType = "DateTime")]
        public DateTime? VerifyTime
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