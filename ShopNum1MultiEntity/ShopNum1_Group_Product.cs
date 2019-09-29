using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1__Group_Product")]
    public class ShopNum1_Group_Product : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private decimal? decimal_0;
        private int int_0;
        private int? int_1;
        private int? int_10;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int? int_6;
        private int? int_7;
        private int? int_8;
        private int? int_9;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;

        //[Column(Storage = "_Aid", DbType = "Int")]
        public int? Aid
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("Aid");
                }
            }
        }

        //[Column(Storage = "_Aname", DbType = "VarChar(100)")]
        public string Aname
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Aname");
                }
            }
        }

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

        //[Column(Storage = "_GropuArea", DbType = "Int")]
        public int? GropuArea
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("GropuArea");
                }
            }
        }

        //[Column(Storage = "_GroupCount", DbType = "Int")]
        public int? GroupCount
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("GroupCount");
                }
            }
        }

        //[Column(Storage = "_GroupImg", DbType = "VarChar(80)")]
        public string GroupImg
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("GroupImg");
                }
            }
        }

        //[Column(Storage = "_GroupPrice", DbType = "Decimal(18,2)")]
        public decimal? GroupPrice
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
                    SendPropertyChanged("GroupPrice");
                }
            }
        }

        //[Column(Storage = "_GroupSmallImg", DbType = "VarChar(80)")]
        public string GroupSmallImg
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("GroupSmallImg");
                }
            }
        }

        //[Column(Storage = "_GroupStock", DbType = "Int")]
        public int? GroupStock
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("GroupStock");
                }
            }
        }

        //[Column(Storage = "_GroupType", DbType = "Int")]
        public int? GroupType
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("GroupType");
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

        //[Column(Storage = "_Introduce", DbType = "VarChar(6000)")]
        public string Introduce
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Introduce");
                }
            }
        }

        //[Column(Storage = "_IsRecommond", DbType = "Int")]
        public int? IsRecommond
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("IsRecommond");
                }
            }
        }

        //[Column(Storage = "_LimitNum", DbType = "Int")]
        public int? LimitNum
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("LimitNum");
                }
            }
        }

        //[Column(Storage = "_MemLoginId", DbType = "VarChar(50)")]
        public string MemLoginId
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("MemLoginId");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "VarChar(100)")]
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

        //[Column(Storage = "_ProductGuId", DbType = "VarChar(100)")]
        public string ProductGuId
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ProductGuId");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "VarChar(100)")]
        public string ShopName
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        //[Column(Storage = "_State", DbType = "Int")]
        public int? State
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    SendPropertyChanging();
                    int_10 = value;
                    SendPropertyChanged("State");
                }
            }
        }

        //[Column(Storage = "_VirtualNum", DbType = "Int")]
        public int? VirtualNum
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("VirtualNum");
                }
            }
        }

        //[Column(Storage = "_VisitCount", DbType = "Int")]
        public int? VisitCount
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("VisitCount");
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