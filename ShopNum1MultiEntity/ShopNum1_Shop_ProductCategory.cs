//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_ProductCategory")]
    public class ShopNum1_Shop_ProductCategory
    {
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

        //[Column(Storage = "_CategoryLevel", DbType = "Int NOT NULL")]
        public int CategoryLevel
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    int_3 = value;
                }
            }
        }

        //[Column(Storage = "_Code", DbType = "VarChar(9) NOT NULL", CanBeNull = false)]
        public string Code
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

        //[Column(Storage = "_Description", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string Description
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

        //[Column(Storage = "_Family", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string Family
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

        //[Column(Storage = "_FatherID", DbType = "Int NOT NULL")]
        public int FatherID
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    int_4 = value;
                }
            }
        }

        //[Column(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", //IsDbGenerated = true)]
        public int ID
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

        //[Column(Storage = "_IsShow", DbType = "Int NOT NULL")]
        public int IsShow
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

        //[Column(Storage = "_Keywords", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string Keywords
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

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
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

        //[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
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
    }
}