using System;
using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_Address")]
    public class ShopNum1_Address : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private Guid guid_0;
        private int int_0;
        private int int_1;

        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        // //[Column(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Address");
                }
            }
        }

        // //[Column(Storage = "_AddressCode", DbType = "NVarChar(50)")]
        public string AddressCode
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("AddressCode");
                }
            }
        }

        //   //[Column(Storage = "_AddressValue", CanBeNull = false)]
        public string AddressValue
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("AddressValue");
                }
            }
        }

        // //[Column(Storage = "_Area", DbType = "NVarChar(250)")]
        public string Area
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("Area");
                }
            }
        }

        //  //[Column(Storage = "_CreateTime", DbType = "DateTime NOT NULL")]
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

        // //[Column(Storage = "_CreateUser", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CreateUser
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        // //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Email");
                }
            }
        }

        // //[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
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

        //  //[Column(Storage = "_IsDefault", DbType = "Int NOT NULL")]
        public int IsDefault
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("IsDefault");
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

        // //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        // //[Column(Storage = "_Mobile", DbType = "NVarChar(20)")]
        public string Mobile
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Mobile");
                }
            }
        }

        // //[Column(Storage = "_ModifyTime", DbType = "DateTime NOT NULL")]
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

        //   //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        // //[Column(Storage = "_Name", DbType = "NVarChar(50)")]
        public string Name
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        //  //[Column(Storage = "_Postalcode", DbType = "NVarChar(20)")]
        public string Postalcode
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Postalcode");
                }
            }
        }

        //  //[Column(Storage = "_Tel", DbType = "NVarChar(20)")]
        public string Tel
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Tel");
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