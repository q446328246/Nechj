using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_ProductComment")]
    public class ShopNum1_Shop_ProductComment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private decimal? decimal_0;
        private Guid guid_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int? int_3;
        private int int_4;
        private int? int_5;
        private int? int_6;
        private int? int_7;
        private int? int_8;
        private int int_9;

        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;


        public int shop_category_id
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("shop_category_id");
                }
            }
        }

        //[Column(Storage = "_Attitude", DbType = "Int")]
        public int? Attitude
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("Attitude");
                }
            }
        }

        //[Column(Storage = "_BuyerAttitude", DbType = "Int")]
        public int? BuyerAttitude
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("BuyerAttitude");
                }
            }
        }

        //[Column(Storage = "_Character", DbType = "Int")]
        public int? Character
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("Character");
                }
            }
        }

        //[Column(Storage = "_Comment", DbType = "NVarChar(500)")]
        public string Comment
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Comment");
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
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("CommentTime");
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
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("CommentType");
                }
            }
        }

        //[Column(Storage = "_ContinueComment", DbType = "NVarChar(250)")]
        public string ContinueComment
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("ContinueComment");
                }
            }
        }

        //[Column(Storage = "_ContinueReply", DbType = "NVarChar(250)")]
        public string ContinueReply
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("ContinueReply");
                }
            }
        }

        //[Column(Storage = "_ContinueReplyTime", DbType = "DateTime")]
        public DateTime? ContinueReplyTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("ContinueReplyTime");
                }
            }
        }

        //[Column(Storage = "_ContinueState", DbType = "Int")]
        public int? ContinueState
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("ContinueState");
                }
            }
        }

        //[Column(Storage = "_ContinueTime", DbType = "DateTime")]
        public DateTime? ContinueTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("ContinueTime");
                }
            }
        }

        //[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
        public Guid Guid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    SendPropertyChanging();
                    guid_0 = value;
                    SendPropertyChanged("Guid");
                }
            }
        }

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("IsAudit");
                }
            }
        }

        //[Column(Storage = "_IsDelete", DbType = "Int NOT NULL")]
        public int IsDelete
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsDelete");
                }
            }
        }

        //[Column(Storage = "_IsNick", DbType = "Int")]
        public int? IsNick
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IsNick");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_OrderGuid", DbType = "NVarChar(50)")]
        public string OrderGuid
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("OrderGuid");
                }
            }
        }

        //[Column(Storage = "_ProductGuid", DbType = "NVarChar(2000) NOT NULL", CanBeNull = false)]
        public string ProductGuid
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("ProductGuid");
                }
            }
        }

        //[Column(Storage = "_ProductName", DbType = "NVarChar(2000)")]
        public string ProductName
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("ProductName");
                }
            }
        }

        //[Column(Storage = "_ProductPrice", DbType = "Decimal(18,2)")]
        public decimal? ProductPrice
        {
            get { return decimal_0; }
            set
            {
                decimal? nullable = decimal_0;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("ProductPrice");
                }
            }
        }

        //[Column(Storage = "_Reply", DbType = "NVarChar(500)")]
        public string Reply
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Reply");
                }
            }
        }

        //[Column(Storage = "_ReplyTime", DbType = "DateTime")]
        public DateTime? ReplyTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("ReplyTime");
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ShopID
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        //[Column(Storage = "_ShopLoginId", DbType = "NVarChar(50)")]
        public string ShopLoginId
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("ShopLoginId");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "NVarChar(50)")]
        public string ShopName
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        //[Column(Storage = "_SpecValue", DbType = "NVarChar(100)")]
        public string SpecValue
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("SpecValue");
                }
            }
        }

        //[Column(Storage = "_Speed", DbType = "Int NOT NULL")]
        public int Speed
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("Speed");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, propertyChangingEventArgs_0);
            }
        }
    }
}