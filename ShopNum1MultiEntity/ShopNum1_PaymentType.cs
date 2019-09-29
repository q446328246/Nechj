using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_PaymentType")]
    public class ShopNum1_PaymentType : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte? byte_0;
        private Guid guid_0;
        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        //[Column(Storage = "_BakcImg", DbType = "NVarChar(250)")]
        public string BakcImg
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("BakcImg");
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

        //[Column(Storage = "_IsShopUse", DbType = "TinyInt")]
        public byte? IsShopUse
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("IsShopUse");
                }
            }
        }

        //[Column(Storage = "_Memo", DbType = "NVarChar(4000)")]
        public string Memo
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Memo");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
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
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("OrderID");
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