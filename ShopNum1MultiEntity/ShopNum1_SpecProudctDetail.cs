using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_SpecProudctDetails")]
    public class ShopNum1_SpecProudctDetail
    {
        private Guid? guid_0;
        private int? int_0;
        private int? int_1;
        private int? int_2;
        private string string_0;
        private string string_1;

        //[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier")]
        public Guid? ProductGuid
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

        //[Column(Storage = "_ProductImage", DbType = "VarChar(100)")]
        public string ProductImage
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

        //[Column(Storage = "_SpecId", DbType = "Int")]
        public int? SpecId
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

        //[Column(Storage = "_SpecValueId", DbType = "Int")]
        public int? SpecValueId
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

        //[Column(Storage = "_SpecValueName", DbType = "VarChar(50)")]
        public string SpecValueName
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

        //[Column(Storage = "_TypeId", DbType = "Int")]
        public int? TypeId
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
    }
}