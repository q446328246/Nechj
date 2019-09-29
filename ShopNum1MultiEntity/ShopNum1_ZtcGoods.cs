using System;
using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    // //[Table(Name = "dbo.ShopNum1_ZtcGoods")]
    public class ShopNum1_ZtcGoods : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte? byte_0;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private decimal? decimal_0;
        private decimal? decimal_1;
        private decimal? decimal_2;
        private Guid? guid_0;
        private int int_0;
        private int? int_1;
        private int? int_2;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

        // //[Column(Storage = "_CreateTime", DbType = "DateTime")]
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

        // //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
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

        //   //[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //       //IsDbGenerated = true)]
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

        //   //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //   //[Column(Storage = "_MemberID", DbType = "NVarChar(50)")]
        public string MemberID
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("MemberID");
                }
            }
        }

        //   //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
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

        //  //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
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

        // //[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier")]
        public Guid? ProductGuid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    SendPropertyChanging();
                    guid_0 = value;
                    SendPropertyChanged("ProductGuid");
                }
            }
        }

        //   //[Column(Storage = "_ProductPrice", DbType = "Decimal(18,2)")]
        public decimal? ProductPrice
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
                    SendPropertyChanged("ProductPrice");
                }
            }
        }

        // //[Column(Storage = "_SellCount", DbType = "Int")]
        public int? SellCount
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("SellCount");
                }
            }
        }

        // //[Column(Storage = "_SellPrice", DbType = "Decimal(18,2)")]
        public decimal? SellPrice
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
                    SendPropertyChanged("SellPrice");
                }
            }
        }

        // //[Column(Storage = "_ShopName", DbType = "NVarChar(100)")]
        public string ShopName
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        // //[Column(Storage = "_StartTime", DbType = "DateTime")]
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

        //  //[Column(Storage = "_State", DbType = "TinyInt")]
        public byte? State
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("State");
                }
            }
        }

        // //[Column(Storage = "_Ztc_Money", DbType = "Decimal(18,2)")]
        public decimal? Ztc_Money
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
                    SendPropertyChanged("Ztc_Money");
                }
            }
        }

        // //[Column(Storage = "_ZtcImg", DbType = "NVarChar(250)")]
        public string ZtcImg
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ZtcImg");
                }
            }
        }

        // //[Column(Storage = "_ZtcName", DbType = "NVarChar(100)")]
        public string ZtcName
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("ZtcName");
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