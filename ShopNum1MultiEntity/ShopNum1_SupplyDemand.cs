using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_SupplyDemand")]
    public class ShopNum1_SupplyDemand : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte byte_0;
        private DateTime dateTime_0;
        private int int_0;
        private int int_1;
        private int? int_2;
        private int int_3;

        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_14;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_AddressCode", DbType = "NVarChar(9) NOT NULL", CanBeNull = false)]
        public string AddressCode
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("AddressCode");
                }
            }
        }

        //[Column(Storage = "_AddressValue", DbType = "NVarChar(50)")]
        public string AddressValue
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("AddressValue");
                }
            }
        }

        //[Column(Storage = "_CategoryCode", DbType = "NVarChar(50)")]
        public string CategoryCode
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("CategoryCode");
                }
            }
        }

        //[Column(Storage = "_CategoryName", DbType = "NVarChar(50)")]
        public string CategoryName
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("CategoryName");
                }
            }
        }

        //[Column(Storage = "_ContactName", DbType = "NVarChar(50)")]
        public string ContactName
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("ContactName");
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

        //[Column(Storage = "_Description", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Description
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Description");
                }
            }
        }

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("Email");
                }
            }
        }

        //[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //IsDbGenerated = true)]
        public int ID
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("ID");
                }
            }
        }

        //[Column(Storage = "_Image", DbType = "NVarChar(250)")]
        public string Image
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Image");
                }
            }
        }

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IsAudit");
                }
            }
        }

        //[Column(Storage = "_IsRecommend", DbType = "TinyInt NOT NULL")]
        public byte IsRecommend
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("IsRecommend");
                }
            }
        }

        //[Column(Storage = "_Keywords", DbType = "NVarChar(200)")]
        public string Keywords
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Keywords");
                }
            }
        }

        //[Column(Storage = "_MemberID", DbType = "NVarChar(50)")]
        public string MemberID
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("MemberID");
                }
            }
        }

        //[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
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

        //[Column(Storage = "_OtherContactWay", DbType = "NVarChar(200)")]
        public string OtherContactWay
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("OtherContactWay");
                }
            }
        }

        //[Column(Storage = "_ReleaseTime", DbType = "DateTime NOT NULL")]
        public DateTime ReleaseTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("ReleaseTime");
                }
            }
        }

        //[Column(Storage = "_Tel", DbType = "NVarChar(25)")]
        public string Tel
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("Tel");
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

        //[Column(Storage = "_TradeType", DbType = "Int NOT NULL")]
        public int TradeType
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("TradeType");
                }
            }
        }

        //[Column(Storage = "_ValidTime", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ValidTime
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("ValidTime");
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