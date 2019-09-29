//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Spec")]
    public class ShopNum1_Spec
    {
        private int? int_0;
        private int? int_1;
        private int? int_2;
        private string string_0;
        private string string_1;
        private string string_2;

        //[Column(Storage = "_ID", DbType = "Int")]
        public int? ID
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

        //[Column(Storage = "_Memo", DbType = "VarChar(50)")]
        public string Memo
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

        //[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
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

        //[Column(Storage = "_ShowType", DbType = "Int")]
        public int? ShowType
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

        //[Column(Storage = "_SpecName", DbType = "VarChar(50)")]
        public string SpecName
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

        //[Column(Storage = "_tbProp", DbType = "VarChar(50)")]
        public string tbProp
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