using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MemberEmailExec")]
    public class ShopNum1_MemberEmailExec : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte? byte_0;
        private byte byte_1;
        private DateTime? dateTime_0;
        private Guid? guid_0;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Email");
                }
            }
        }

        //[Column(Storage = "_Emailkey", DbType = "NVarChar(200) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Emailkey
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Emailkey");
                }
            }
        }

        //[Column(Storage = "_ExtireTime", DbType = "DateTime")]
        public DateTime? ExtireTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("ExtireTime");
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
                    SendPropertyChanging();
                    guid_0 = value;
                    SendPropertyChanged("Guid");
                }
            }
        }

        //[Column(Storage = "_Isinvalid", DbType = "TinyInt")]
        public byte? Isinvalid
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("Isinvalid");
                }
            }
        }

        //[Column(Storage = "_MemberID", DbType = "NVarChar(50)")]
        public string MemberID
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("MemberID");
                }
            }
        }

        //[Column(Storage = "_Phone", DbType = "NVarChar(100)")]
        public string Phone
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Phone");
                }
            }
        }

        //[Column(Storage = "_Type", DbType = "TinyInt NOT NULL")]
        public byte Type
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    SendPropertyChanging();
                    byte_1 = value;
                    SendPropertyChanged("Type");
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