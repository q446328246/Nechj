using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_CreditSumModifyLog")]
    public class ShopNum1_CreditSumModifyLog : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private DateTime? dateTime_1;
        private decimal decimal_0;
        private decimal decimal_1;
        private decimal decimal_2;
        private Guid guid_0;
        private int int_0;
        private int? int_1;

        private string string_0;
        private string string_1;
        private string string_2;

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("CreateTime");
                }
            }
        }

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        //[Column(Storage = "_CurrentCreditSum", DbType = "Decimal(18,2) NOT NULL")]
        public decimal CurrentCreditSum
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("CurrentCreditSum");
                }
            }
        }

        //[Column(Storage = "_Date", DbType = "DateTime NOT NULL")]
        public DateTime Date
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("Date");
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

        //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
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

        //[Column(Storage = "_LastOperateSum", DbType = "Decimal(18,2) NOT NULL")]
        public decimal LastOperateSum
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    SendPropertyChanging();
                    decimal_2 = value;
                    SendPropertyChanged("LastOperateSum");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_Memo", DbType = "NVarChar(250)")]
        public string Memo
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Memo");
                }
            }
        }

        //[Column(Storage = "_OperateSum", DbType = "Decimal(18,2) NOT NULL")]
        public decimal OperateSum
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    SendPropertyChanging();
                    decimal_1 = value;
                    SendPropertyChanged("OperateSum");
                }
            }
        }

        //[Column(Storage = "_OperateType", DbType = "Int NOT NULL")]
        public int OperateType
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("OperateType");
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