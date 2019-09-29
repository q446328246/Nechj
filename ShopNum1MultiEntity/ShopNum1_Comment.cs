using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Comment")]
    public class ShopNum1_Comment
    {
        private DateTime dateTime_0;
        private Guid guid_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        //[Column(Storage = "_Bad", DbType = "Int NOT NULL")]
        public int Bad
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

        //[Column(Storage = "_Comment", DbType = "NVarChar(250)")]
        public string Comment
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

        //[Column(Storage = "_CommentTime", DbType = "DateTime NOT NULL")]
        public DateTime CommentTime
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

        //[Column(Storage = "_CommentType", DbType = "Int NOT NULL")]
        public int CommentType
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

        //[Column(Storage = "_Good", DbType = "Int NOT NULL")]
        public int Good
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

        //[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL")]
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

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
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

        //[Column(Storage = "_MemberOne", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemberOne
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

        //[Column(Storage = "_MemberTwo", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemberTwo
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

        //[Column(Storage = "_Middle", DbType = "Int NOT NULL")]
        public int Middle
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

        //[Column(Storage = "_OrderId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OrderId
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
    }
}