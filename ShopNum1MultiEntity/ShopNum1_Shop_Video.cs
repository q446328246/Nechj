using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_Video")]
    public class ShopNum1_Shop_Video : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private Guid guid_0;
        private int? int_0;
        private int? int_1;
        private int? int_2;
        private int? int_3;

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

        //[Column(Storage = "_BroadcastCount", DbType = "Int")]
        public int? BroadcastCount
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("BroadcastCount");
                }
            }
        }

        //[Column(Storage = "_CategoryGuid", DbType = "NVarChar(50)")]
        public string CategoryGuid
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("CategoryGuid");
                }
            }
        }

        //[Column(Storage = "_Content", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Content
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Content");
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
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("CreateTime");
                }
            }
        }

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        //[Column(Storage = "_Description", DbType = "NVarChar(100)")]
        public string Description
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("Description");
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

        //[Column(Storage = "_ImgAdd", DbType = "NVarChar(200)")]
        public string ImgAdd
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ImgAdd");
                }
            }
        }

        //[Column(Storage = "_IsAudit", DbType = "Int")]
        public int? IsAudit
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsAudit");
                }
            }
        }

        //[Column(Storage = "_IsRecommend", DbType = "Int")]
        public int? IsRecommend
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("IsRecommend");
                }
            }
        }

        //[Column(Storage = "_KeyWords", DbType = "NVarChar(50)")]
        public string KeyWords
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("KeyWords");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("ModifyTime");
                }
            }
        }

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        //[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("OrderID");
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50)")]
        public string ShopID
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        //[Column(Storage = "_Title", DbType = "NVarChar(50)")]
        public string Title
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Title");
                }
            }
        }

        //[Column(Storage = "_VideoAdd", DbType = "NVarChar(500)")]
        public string VideoAdd
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("VideoAdd");
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