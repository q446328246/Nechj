using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MemberPwd")]
    public class ShopNum1_MemberPwd : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte byte_0;
        private byte byte_1;
        private DateTime dateTime_0;
        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Email");
                }
            }
        }

        //[Column(Storage = "_extireTime", DbType = "DateTime NOT NULL")]
        public DateTime extireTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("extireTime");
                }
            }
        }

        //[Column(Storage = "_Guid", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", //IsDbGenerated = true)]
        public int Guid
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("Guid");
                }
            }
        }

        //[Column(Storage = "_isinvalid", DbType = "TinyInt NOT NULL")]
        public byte isinvalid
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("isinvalid");
                }
            }
        }

        //[Column(Storage = "_MemberID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        //[Column(Storage = "_pwdkey", DbType = "VarChar(200) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string pwdkey
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("pwdkey");
                }
            }
        }

        //[Column(Storage = "_pwd", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Pwd
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("pwd");
                }
            }
        }

        //[Column(Storage = "_type", DbType = "TinyInt NOT NULL")]
        public byte type
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    SendPropertyChanging();
                    byte_1 = value;
                    SendPropertyChanged("type");
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