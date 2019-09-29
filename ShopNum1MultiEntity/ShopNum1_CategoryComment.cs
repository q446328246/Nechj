using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_CategoryComment")]
    public class ShopNum1_CategoryComment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        //[Column(Storage = "_AssociatedMemberID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AssociatedMemberID
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("AssociatedMemberID");
                }
            }
        }

        //[Column(Storage = "_CategoryInfoGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid CategoryInfoGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("CategoryInfoGuid");
                }
            }
        }

        //[Column(Storage = "_Content", DbType = "NText NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string Content
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Content");
                }
            }
        }

        //[Column(Storage = "_CreateIP", DbType = "Char(20) NOT NULL", CanBeNull = false)]
        public string CreateIP
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("CreateIP");
                }
            }
        }

        //[Column(Storage = "_CreateMember", DbType = "NVarChar(25) NOT NULL", CanBeNull = false)]
        public string CreateMember
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("CreateMember");
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
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("CreateTime");
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
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("IsAudit");
                }
            }
        }

        //[Column(Storage = "_Title", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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