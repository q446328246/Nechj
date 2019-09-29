﻿using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_BadWords")]
    public class ShopNum1_BadWords : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string CreateUser
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        //[Column(Storage = "_find", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string find
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("find");
                }
            }
        }

        //[Column(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //IsDbGenerated = true)]
        public int id
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("id");
                }
            }
        }

        //[Column(Storage = "_replacement", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string replacement
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("replacement");
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