using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ScoreOrderProduct")]
    public class ShopNum1_ScoreOrderProduct
    {
        private Guid? guid_0;
        private Guid? guid_1;
        private int? int_0;
        private int? int_1;
        private string string_0;
        private string string_1;
        private string string_2;

        //[Column(Storage = "_BuyNumber", DbType = "Int")]
        public int? BuyNumber
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

        //[Column(Storage = "_Guid", DbType = "UniqueIdentifier")]
        public Guid? Guid
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

        //[Column(Storage = "_Name", DbType = "NVarChar(100)")]
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

        //[Column(Storage = "_OrderNumber", DbType = "VarChar(100)")]
        public string OrderNumber
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

        //[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier")]
        public Guid? ProductGuid
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

        //[Column(Storage = "_RepertoryNumber", DbType = "VarChar(100)")]
        public string RepertoryNumber
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

        //[Column(Storage = "_Score", DbType = "Int")]
        public int? Score
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