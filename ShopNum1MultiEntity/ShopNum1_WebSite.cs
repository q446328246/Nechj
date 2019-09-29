using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_WebSite")]
    public class ShopNum1_WebSite : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private bool bool_0;
        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;

        // //[Column(Storage = "_addressCode", DbType = "NVarChar(50)")]
        public string addressCode
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("addressCode");
                }
            }
        }

        // //[Column(Storage = "_addressName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string addressName
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("addressName");
                }
            }
        }

        // //[Column(Storage = "_domain", DbType = "VarChar(250) NOT NULL", CanBeNull = false)]
        public string domain
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("domain");
                }
            }
        }

        // //[Column(Storage = "_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        // //[Column(Storage = "_isAvailable", DbType = "Bit NOT NULL")]
        public bool isAvailable
        {
            get { return bool_0; }
            set
            {
                if (bool_0 != value)
                {
                    SendPropertyChanging();
                    bool_0 = value;
                    SendPropertyChanged("isAvailable");
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