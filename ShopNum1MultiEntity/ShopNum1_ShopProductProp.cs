using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ShopProductProp")]
    public class ShopNum1_ShopProductProp : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private bool bool_0;
        private byte byte_0;
        private int int_0;
        private int int_1;

        private string string_0;
        private string string_1;

        //[Column(Storage = "_Content", DbType = "NVarChar(4000)")]
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

        //[Column(Storage = "_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        //[Column(Storage = "_IsImport", DbType = "Bit NOT NULL")]
        public bool IsImport
        {
            get { return bool_0; }
            set
            {
                if (bool_0 != value)
                {
                    SendPropertyChanging();
                    bool_0 = value;
                    SendPropertyChanged("IsImport");
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

        //[Column(Storage = "_PropName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string PropName
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("PropName");
                }
            }
        }

        //[Column(Storage = "_ShowType", DbType = "TinyInt NOT NULL")]
        public byte ShowType
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("ShowType");
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