//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ScoreFreezeLog")]
    public class ShopNum1_ScoreFreezeLog
    {
        private string string_0;
        private string string_1;
        private string string_10;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_CreateTime", DbType = "NChar(10)")]
        public string CreateTime
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    string_9 = value;
                }
            }
        }

        //[Column(Storage = "_CreateUser", DbType = "NChar(10)")]
        public string CreateUser
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    string_8 = value;
                }
            }
        }

        //[Column(Storage = "_CurrentScore", DbType = "NChar(10)")]
        public string CurrentScore
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

        //[Column(Storage = "_Date", DbType = "NChar(10)")]
        public string Date
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

        //[Column(Storage = "_Guid", DbType = "NChar(10)")]
        public string Guid
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

        //[Column(Storage = "_IsDeleted", DbType = "NChar(10)")]
        public string IsDeleted
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    string_10 = value;
                }
            }
        }

        //[Column(Storage = "_LastOperateScore", DbType = "NChar(10)")]
        public string LastOperateScore
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

        //[Column(Storage = "_MemLoginID", DbType = "NChar(10)")]
        public string MemLoginID
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

        //[Column(Storage = "_Memo", DbType = "NChar(10)")]
        public string Memo
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

        //[Column(Storage = "_OperateScore", DbType = "NChar(10)")]
        public string OperateScore
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

        //[Column(Storage = "_OperateType", DbType = "NChar(10)")]
        public string OperateType
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
    }
}