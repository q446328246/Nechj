using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_OrderProduct")]
    public class ShopNum1_OrderProduct : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private decimal decimal_0;
        private decimal decimal_1;
        private decimal decimal_2;
        private decimal decimal_3;
        private decimal? decimal_4;
        private Guid guid_0;
        private int int_0;
        private int? int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private int? int_5;
        private int? int_6;
        private int int_7;

        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        private string Scpre_Size;
        private string Scpre_Color;

        private decimal Score_score_pv_cv;

        public decimal score_pv_cv
        {
            get { return Score_score_pv_cv; }
            set
            {
                if (Score_score_pv_cv != value)
                {
                    SendPropertyChanging();
                    Score_score_pv_cv = value;
                    SendPropertyChanged("score_pv_cv");
                }
            }
        }

        public string Color
        {
            get { return Scpre_Color; }
            set
            {
                if (Scpre_Color != value)
                {
                    SendPropertyChanging();
                    Scpre_Color = value;
                    SendPropertyChanged("Color");
                }
            }
        }

        public string Size
        {
            get { return Scpre_Size; }
            set
            {
                if (Scpre_Size != value)
                {
                    SendPropertyChanging();
                    Scpre_Size = value;
                    SendPropertyChanged("Size");
                }
            }
        }


        public int shop_category_id
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("shop_category_id");
                }
            }
        }

        //[Column(Storage = "_Attributes", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string Attributes
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("Attributes");
                }
            }
        }

        //[Column(Storage = "_BuyerGetProfit", DbType = "Decimal(18,2)")]
        public decimal? BuyerGetProfit
        {
            get { return decimal_4; }
            set
            {
                decimal? nullable = decimal_4;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_4 = value;
                    SendPropertyChanged("BuyerGetProfit");
                }
            }
        }

        //[Column(Storage = "_BuyNumber", DbType = "Int NOT NULL")]
        public int BuyNumber
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("BuyNumber");
                }
            }
        }

        //[Column(Storage = "_BuyPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal BuyPrice
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    SendPropertyChanging();
                    decimal_1 = value;
                    SendPropertyChanged("BuyPrice");
                }
            }
        }

        //[Column(Storage = "_ConsumptionScore", DbType = "Int")]
        public int? ConsumptionScore
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("ConsumptionScore");
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

        //[Column(Storage = "_DetailedSpecifications", DbType = "NVarChar(4000)")]
        public string DetailedSpecifications
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("DetailedSpecifications");
                }
            }
        }

        //[Column(Storage = "_ExtensionAttriutes", DbType = "NVarChar(250)")]
        public string ExtensionAttriutes
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("ExtensionAttriutes");
                }
            }
        }

        //[Column(Storage = "_GroupPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal GroupPrice
        {
            get { return decimal_3; }
            set
            {
                if (decimal_3 != value)
                {
                    SendPropertyChanging();
                    decimal_3 = value;
                    SendPropertyChanged("GroupPrice");
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

        //[Column(Storage = "_IsJoinActivity", DbType = "Int NOT NULL")]
        public int IsJoinActivity
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsJoinActivity");
                }
            }
        }

        //[Column(Storage = "_IsReal", DbType = "Int NOT NULL")]
        public int IsReal
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("IsReal");
                }
            }
        }

        //[Column(Storage = "_IsShipment", DbType = "Int NOT NULL")]
        public int IsShipment
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IsShipment");
                }
            }
        }

        //[Column(Storage = "_MarketPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal MarketPrice
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("MarketPrice");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        //[Column(Storage = "_OrderInfoGuid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OrderInfoGuid
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("OrderInfoGuid");
                }
            }
        }

        //[Column(Storage = "_OrderType", DbType = "Int")]
        public int? OrderType
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("OrderType");
                }
            }
        }

        //[Column(Storage = "_ProductGuid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ProductGuid
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ProductGuid");
                }
            }
        }

        //[Column(Storage = "_ProductImg", DbType = "NVarChar(80)")]
        public string ProductImg
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("ProductImg");
                }
            }
        }

        //[Column(Storage = "_ProductName", DbType = "VarChar(100)")]
        public string ProductName
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("ProductName");
                }
            }
        }

        //[Column(Storage = "_RankScore", DbType = "Int")]
        public int? RankScore
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("RankScore");
                }
            }
        }

        //[Column(Storage = "_RepertoryNumber", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string RepertoryNumber
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("RepertoryNumber");
                }
            }
        }

        //[Column(Storage = "_setStock", CanBeNull = false)]
        public string setStock
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("setStock");
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ShopID
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        //[Column(Storage = "_ShopPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal ShopPrice
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    SendPropertyChanging();
                    decimal_2 = value;
                    SendPropertyChanged("ShopPrice");
                }
            }
        }

        //[Column(Storage = "_SpecificationName", DbType = "NVarChar(500)")]
        public string SpecificationName
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("SpecificationName");
                }
            }
        }

        //[Column(Storage = "_SpecificationValue", DbType = "NVarChar(500)")]
        public string SpecificationValue
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("SpecificationValue");
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