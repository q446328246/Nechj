using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ComplaintsReply")]
    public class ShopNum1_ComplaintsReply : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private Guid guid_0;
        private Guid guid_1;

        private string string_0;

        //[Column(Storage = "_ComplaintsManagementGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid ComplaintsManagementGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("ComplaintsManagementGuid");
                }
            }
        }

        //[Column(Storage = "_guid", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
        public Guid guid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    SendPropertyChanging();
                    guid_0 = value;
                    SendPropertyChanged("guid");
                }
            }
        }

        //[Column(Storage = "_RepalyTime", DbType = "DateTime NOT NULL")]
        public DateTime RepalyTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("RepalyTime");
                }
            }
        }

        //[Column(Storage = "_ReplayContent", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string ReplayContent
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("ReplayContent");
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