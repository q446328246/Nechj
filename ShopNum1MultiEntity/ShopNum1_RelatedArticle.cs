using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_RelatedArticle")]
    public class ShopNum1_RelatedArticle
    {
        private DateTime dateTime_0;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;
        private string string_0;

        //[Column(Storage = "_ArticleGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid ArticleGuid
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
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    string_0 = value;
                }
            }
        }

        //[Column(Storage = "_IsBoth", DbType = "Int NOT NULL")]
        public int IsBoth
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

        //[Column(Storage = "_SubArticleGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid SubArticleGuid
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