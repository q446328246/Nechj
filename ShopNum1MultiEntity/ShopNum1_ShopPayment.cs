﻿using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ShopPayment")]
    public class ShopNum1_ShopPayment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private decimal decimal_0;
        private Guid guid_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_Charge", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Charge
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("Charge");
                }
            }
        }

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("Email");
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

        //[Column(Storage = "_IsCOD", DbType = "Int NOT NULL")]
        public int IsCOD
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("IsCOD");
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsPercent", DbType = "Int NOT NULL")]
        public int IsPercent
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("IsPercent");
                }
            }
        }

        //[Column(Storage = "_memloginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string memloginID
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("memloginID");
                }
            }
        }

        //[Column(Storage = "_Memo", DbType = "NVarChar(4000)")]
        public string Memo
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("Memo");
                }
            }
        }

        //[Column(Storage = "_MerchantCode", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string MerchantCode
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("MerchantCode");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(100)")]
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
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("OrderID");
                }
            }
        }

        //[Column(Storage = "_Partner", DbType = "NVarChar(100)")]
        public string Partner
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("Partner");
                }
            }
        }

        //[Column(Storage = "_PaymentType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string PaymentType
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("PaymentType");
                }
            }
        }

        //[Column(Storage = "_Pwd", DbType = "NVarChar(250)")]
        public string Pwd
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Pwd");
                }
            }
        }

        //[Column(Storage = "_SecondKey", DbType = "NVarChar(250)")]
        public string SecondKey
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("SecondKey");
                }
            }
        }

        //[Column(Storage = "_SecretKey", DbType = "NVarChar(250)")]
        public string SecretKey
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("SecretKey");
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