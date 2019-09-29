using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace ShopNum1.TbLinq
{
    [Table(Name = "dbo.ShopNum1_TbTopKey")]
    public class ShopNum1_TbTopKey : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);

        private string _AppKey;
        private string _AppSecret;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private Guid _Guid;
        private int _IsForbid;
        private string _MemloginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _URL;

        [Column(Storage = "_AppKey", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string AppKey
        {
            get { return _AppKey; }
            set
            {
                if (_AppKey != value)
                {
                    SendPropertyChanging();
                    _AppKey = value;
                    SendPropertyChanged("AppKey");
                }
            }
        }

        [Column(Storage = "_AppSecret", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string AppSecret
        {
            get { return _AppSecret; }
            set
            {
                if (_AppSecret != value)
                {
                    SendPropertyChanging();
                    _AppSecret = value;
                    SendPropertyChanged("AppSecret");
                }
            }
        }

        [Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
        {
            get { return _CreateTime; }
            set
            {
                if (_CreateTime != value)
                {
                    SendPropertyChanging();
                    _CreateTime = value;
                    SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return _CreateUser; }
            set
            {
                if (_CreateUser != value)
                {
                    SendPropertyChanging();
                    _CreateUser = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        [Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
        public Guid Guid
        {
            get { return _Guid; }
            set
            {
                if (_Guid != value)
                {
                    SendPropertyChanging();
                    _Guid = value;
                    SendPropertyChanged("Guid");
                }
            }
        }

        [Column(Storage = "_IsForbid", DbType = "Int NOT NULL")]
        public int IsForbid
        {
            get { return _IsForbid; }
            set
            {
                if (_IsForbid != value)
                {
                    SendPropertyChanging();
                    _IsForbid = value;
                    SendPropertyChanged("IsForbid");
                }
            }
        }

        [Column(Storage = "_MemloginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemloginID
        {
            get { return _MemloginID; }
            set
            {
                if (_MemloginID != value)
                {
                    SendPropertyChanging();
                    _MemloginID = value;
                    SendPropertyChanged("MemloginID");
                }
            }
        }

        [Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return _ModifyTime; }
            set
            {
                if (_ModifyTime != value)
                {
                    SendPropertyChanging();
                    _ModifyTime = value;
                    SendPropertyChanged("ModifyTime");
                }
            }
        }

        [Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return _ModifyUser; }
            set
            {
                if (_ModifyUser != value)
                {
                    SendPropertyChanging();
                    _ModifyUser = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        [Column(Storage = "_URL", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string URL
        {
            get { return _URL; }
            set
            {
                if (_URL != value)
                {
                    SendPropertyChanging();
                    _URL = value;
                    SendPropertyChanged("URL");
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
                PropertyChanging(this, emptyChangingEventArgs);
            }
        }
    }
}