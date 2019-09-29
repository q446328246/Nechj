using System;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    // //[Table(Name = "dbo.ShopNum1_Video")]
    public class ShopNum1_Video
    {
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private Guid guid_0;
        private int? int_0;
        private int? int_1;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int? int_6;
        private int? int_7;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;

        ////[Column(Storage = "_BroadcastCount", DbType = "Int")]
        public int? BroadcastCount
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

        // //[Column(Storage = "_CategoryID", DbType = "Int")]
        public int? CategoryID
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

        // //[Column(Storage = "_CommentCount", DbType = "Int")]
        public int? CommentCount
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    int_5 = value;
                }
            }
        }

        // //[Column(Storage = "_Content", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Content
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

        // //[Column(Storage = "_CreateTime", DbType = "DateTime")]
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

        // //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
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

        ////[Column(Storage = "_Description", DbType = "VarChar(150)")]
        public string Description
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

        //  //[Column(Storage = "_DownCount", DbType = "Int")]
        public int? DownCount
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

        // //[Column(Storage = "_FavoritesCount", DbType = "Int")]
        public int? FavoritesCount
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

        ////[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL")]
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

        ////[Column(Storage = "_ImgAdd", DbType = "NVarChar(200)")]
        public string ImgAdd
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

        ////[Column(Storage = "_IsRecommend", DbType = "Int")]
        public int? IsRecommend
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    int_7 = value;
                }
            }
        }

        ////[Column(Storage = "_KeyWords", DbType = "NVarChar(50)")]
        public string KeyWords
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

        // //[Column(Storage = "_KeyWordsSeo", DbType = "VarChar(200)")]
        public string KeyWordsSeo
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

        // //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
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

        // //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
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

        ////[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    int_6 = value;
                }
            }
        }

        ////[Column(Storage = "_Title", DbType = "NVarChar(50)")]
        public string Title
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

        ////[Column(Storage = "_UpCount", DbType = "Int")]
        public int? UpCount
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

        // //[Column(Storage = "_VideoAdd", DbType = "NVarChar(500)")]
        public string VideoAdd
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