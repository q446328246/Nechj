using System;
using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_UserMessage")]
    public class ShopNum1_UserMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private DateTime dateTime_1;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;

        private string string_0;
        private string string_1;
        private string string_2;

        ////[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
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

        // //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsRead", DbType = "Int NOT NULL")]
        public int IsRead
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("IsRead");
                }
            }
        }

        //[Column(Storage = "_MessageInfoGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid MessageInfoGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("MessageInfoGuid");
                }
            }
        }

        //[Column(Storage = "_ReceiveID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ReceiveID
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ReceiveID");
                }
            }
        }

        //[Column(Storage = "_ReceiveIsDeleted", DbType = "Int NOT NULL")]
        public int ReceiveIsDeleted
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("ReceiveIsDeleted");
                }
            }
        }

        //[Column(Storage = "_ReplyContent", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string ReplyContent
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ReplyContent");
                }
            }
        }

        //[Column(Storage = "_ReplyTime", DbType = "DateTime")]
        public DateTime? ReplyTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("ReplyTime");
                }
            }
        }

        //[Column(Storage = "_SendID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string SendID
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("SendID");
                }
            }
        }

        //[Column(Storage = "_SendIsDeleted", DbType = "Int NOT NULL")]
        public int SendIsDeleted
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("SendIsDeleted");
                }
            }
        }

        //[Column(Storage = "_SendTime", DbType = "DateTime NOT NULL")]
        public DateTime SendTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("SendTime");
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