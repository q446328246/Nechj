//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ShopEnsure")]
    public class ShopNum1_ShopEnsure
    {
        private decimal decimal_0;
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        //[Column(Storage = "_EnsureMoney", DbType = "Decimal(18,2) NOT NULL")]
        public decimal EnsureMoney
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    decimal_0 = value;
                }
            }
        }

        //[Column(Storage = "_Href", DbType = "NVarChar(150)")]
        public string Href
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

        //[Column(Storage = "_ImagePath", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string ImagePath
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

        //[Column(Storage = "_MemberLoginID", DbType = "NVarChar(50)")]
        public string MemberLoginID
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