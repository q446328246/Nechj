﻿using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_OnlineService")]
    public class ShopNum1_OnlineService : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private Guid guid_0;
        private int int_0;
        private int int_1;
        private int int_2;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

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

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CreateUser
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("CreateUser");
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

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsShow", DbType = "Int NOT NULL")]
        public int IsShow
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("IsShow");
                }
            }
        }

        //[Column(Storage = "_Location", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string Location
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Location");
                }
            }
        }

        //[Column(Storage = "_ModifyTime", DbType = "DateTime NOT NULL")]
        public DateTime ModifyTime
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

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ModifyUser
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        //[Column(Storage = "_OrderID", DbType = "Int NOT NULL")]
        public int OrderID
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("OrderID");
                }
            }
        }

        //[Column(Storage = "_ServiceAccount", DbType = "NVarChar(25) NOT NULL", CanBeNull = false)]
        public string ServiceAccount
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ServiceAccount");
                }
            }
        }

        //[Column(Storage = "_Type", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Type
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
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