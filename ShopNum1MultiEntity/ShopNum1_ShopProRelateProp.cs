using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ShopProRelateProp")]
    public class ShopNum1_ShopProRelateProp
    {
        private Guid guid_0;
        private int? int_0;
        private int? int_1;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private string string_0;

        //[Column(Storage = "_CTypeID", DbType = "Int")]
        public int? CTypeID
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

        //[Column(Storage = "_InputValue", DbType = "VarChar(200)")]
        public string InputValue
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

        //[Column(Storage = "_PCategoryID", DbType = "Int")]
        public int? PCategoryID
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

        //[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid ProductGuid
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

        //[Column(Storage = "_PropID", DbType = "Int")]
        public int? PropID
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

        //[Column(Storage = "_PropValueID", DbType = "Int")]
        public int? PropValueID
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

        //[Column(Storage = "_ShowType", DbType = "Int")]
        public int? ShowType
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
    }
}