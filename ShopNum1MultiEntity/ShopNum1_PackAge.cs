using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_PackAge")]
    public class ShopNum1_PackAge : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private decimal? decimal_0;
        private decimal? decimal_1;
        private decimal? decimal_2;
        private int int_0;
        private int? int_1;
        private int? int_2;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
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

        // [Column(Name = "[Desc]", Storage = "_Desc", DbType = "VarChar(3000)")]
        public string Desc
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Desc");
                }
            }
        }

        //[Column(Storage = "_Fee", DbType = "Int")]
        public int? Fee
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("Fee");
                }
            }
        }

        //[Column(Storage = "_FeePrice", DbType = "Decimal(18,2)")]
        public decimal? FeePrice
        {
            get { return decimal_2; }
            set
            {
                decimal? nullable = decimal_2;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_2 = value;
                    SendPropertyChanged("FeePrice");
                }
            }
        }

        //[Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //IsDbGenerated = true)]
        public int Id
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("Id");
                }
            }
        }

        //[Column(Storage = "_MemloginId", DbType = "VarChar(50)")]
        public string MemloginId
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("MemloginId");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "VarChar(50)")]
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

        //[Column(Storage = "_Pic", DbType = "VarChar(200)")]
        public string Pic
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Pic");
                }
            }
        }

        //[Column(Storage = "_Price", DbType = "Decimal(18,2)")]
        public decimal? Price
        {
            get { return decimal_0; }
            set
            {
                decimal? nullable = decimal_0;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("Price");
                }
            }
        }

        //[Column(Storage = "_SalePrice", DbType = "Decimal(18,2)")]
        public decimal? SalePrice
        {
            get { return decimal_1; }
            set
            {
                decimal? nullable = decimal_1;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_1 = value;
                    SendPropertyChanged("SalePrice");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "VarChar(50)")]
        public string ShopName
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        //[Column(Storage = "_State", DbType = "Int")]
        public int? State
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("State");
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