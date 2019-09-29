using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ShopRank")]
    public class ShopNum1_ShopRank : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private decimal? decimal_0;
        private Guid guid_0;
        private int? int_0;
        private int? int_1;
        private int? int_10;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int? int_6;
        private int int_7;
        private int int_8;
        private int int_9;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

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
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("CreateUser");
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

        //[Column(Storage = "_IsDefault", DbType = "Int NOT NULL")]
        public int IsDefault
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("IsDefault");
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsOverrideDomain", DbType = "Int")]
        public int? IsOverrideDomain
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsOverrideDomain");
                }
            }
        }

        //[Column(Storage = "_IsSetSEO", DbType = "Int NOT NULL")]
        public int IsSetSEO
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("IsSetSEO");
                }
            }
        }

        //[Column(Storage = "_MaxArticleCout", DbType = "Int")]
        public int? MaxArticleCout
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("MaxArticleCout");
                }
            }
        }

        //[Column(Storage = "_MaxFileCount", DbType = "Int")]
        public int? MaxFileCount
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("MaxFileCount");
                }
            }
        }

        //[Column(Storage = "_MaxPanicBuyCount", DbType = "Int")]
        public int? MaxPanicBuyCount
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("MaxPanicBuyCount");
                }
            }
        }

        //[Column(Storage = "_MaxProductCount", DbType = "Int")]
        public int? MaxProductCount
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("MaxProductCount");
                }
            }
        }

        //[Column(Storage = "_MaxSpellBuyCount", DbType = "Int")]
        public int? MaxSpellBuyCount
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("MaxSpellBuyCount");
                }
            }
        }

        //[Column(Storage = "_MaxVedioCount", DbType = "Int")]
        public int? MaxVedioCount
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("MaxVedioCount");
                }
            }
        }

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("ModifyTime");
                }
            }
        }

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        //[Column(Storage = "_Pic", DbType = "NVarChar(100)")]
        public string Pic
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Pic");
                }
            }
        }

        //[Column(Storage = "_price", DbType = "Decimal(18,2)")]
        public decimal? price
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
                    SendPropertyChanged("price");
                }
            }
        }

        //[Column(Storage = "_RankValue", DbType = "Int")]
        public int? RankValue
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    SendPropertyChanging();
                    int_10 = value;
                    SendPropertyChanged("RankValue");
                }
            }
        }

        //[Column(Storage = "_shopTemplate", DbType = "NVarChar(MAX)")]
        public string shopTemplate
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("shopTemplate");
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

        //[Column(Storage = "_validityDate", DbType = "NVarChar(50)")]
        public string validityDate
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("validityDate");
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