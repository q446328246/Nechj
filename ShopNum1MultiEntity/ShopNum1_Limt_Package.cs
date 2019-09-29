using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1__Limt_Package")]
    public class ShopNum1_Limt_Package : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private decimal? decimal_0;
        private int int_0;
        private int? int_1;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int? int_6;

        private string string_0;
        private string string_1;
        private string string_2;

        //[Column(Storage = "_BuyNum", DbType = "Int")]
        public int? BuyNum
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("BuyNum");
                }
            }
        }

        //[Column(Storage = "_EndTime", DbType = "DateTime")]
        public DateTime? EndTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("EndTime");
                }
            }
        }

        //[Column(Storage = "_Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        //[Column(Storage = "_LeaveNum", DbType = "Int")]
        public int? LeaveNum
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("LeaveNum");
                }
            }
        }

        //[Column(Storage = "_LimitProductNum", DbType = "Int")]
        public int? LimitProductNum
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("LimitProductNum");
                }
            }
        }

        //[Column(Storage = "_LimtActivityNum", DbType = "Int")]
        public int? LimtActivityNum
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("LimtActivityNum");
                }
            }
        }

        //[Column(Storage = "_MemloginId", DbType = "VarChar(50)")]
        public string MemloginId
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("MemloginId");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "VarChar(100)")]
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

        //[Column(Storage = "_PayMoney", DbType = "Decimal(18,2)")]
        public decimal? PayMoney
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
                    SendPropertyChanged("PayMoney");
                }
            }
        }

        //[Column(Storage = "_PublishedNum", DbType = "Int")]
        public int? PublishedNum
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("PublishedNum");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "VarChar(100)")]
        public string ShopName
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        //[Column(Storage = "_StartTime", DbType = "DateTime")]
        public DateTime? StartTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("StartTime");
                }
            }
        }

        //[Column(Storage = "_State", DbType = "Int")]
        public int? State
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
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