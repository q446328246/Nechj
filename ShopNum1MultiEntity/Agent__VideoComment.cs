using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.Agent__VideoComment")]
    public class Agent__VideoComment
    {
        private DateTime? dateTime_0;
        private Guid? guid_0;
        private string string_0;
        private string string_1;
        private string string_2;

        //[Column(Storage = "_Content", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Content
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

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
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

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
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

        //[Column(Storage = "_VideoGuid", DbType = "NVarChar(50)")]
        public string VideoGuid
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