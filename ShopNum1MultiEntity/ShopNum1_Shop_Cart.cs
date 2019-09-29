using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_Cart")]
    public class ShopNum1_Shop_Cart : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime dateTime_0;
        private decimal decimal_0;
        private decimal decimal_1;
        private decimal decimal_2;
        private decimal? decimal_3;
        private decimal? decimal_4;
        private decimal? decimal_5;
        private Guid guid_0;
        private Guid guid_1;
        private Guid? guid_2;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int? int_6;
        private int int_7;

        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;
        private int Score_shop_category_id;
        private decimal Score_Score_pv_a;
        private decimal Score_Score_pv_b;
        private decimal Score_Score_hv;
        private decimal Score_Score_dv;

        private string Score_Color;
        private string Score_Size;
        private decimal Score_GoodsWeight;

        private decimal Score_Score_pv_cv;

        public decimal GoodsWeight
        {
            get { return Score_GoodsWeight; }
            set
            {
                if (Score_GoodsWeight != value)
                {
                    SendPropertyChanging();
                    Score_GoodsWeight = value;
                    SendPropertyChanged("GoodsWeight");
                }
            }
        }

        public decimal Score_pv_cv
        {
            get { return Score_Score_pv_cv; }
            set
            {
                if (Score_Score_pv_cv != value)
                {
                    SendPropertyChanging();
                    Score_Score_pv_cv = value;
                    SendPropertyChanged("Score_pv_cv");
                }
            }
        }

        public string Color
        {
            get { return Score_Color; }
            set
            {
                if (Score_Color != value)
                {
                    SendPropertyChanging();
                    Score_Color = value;
                    SendPropertyChanged("Color");
                }
            }
        }

        public string Size
        {
            get { return Score_Size; }
            set
            {
                if (Score_Size != value)
                {
                    SendPropertyChanging();
                    Score_Size = value;
                    SendPropertyChanged("Size");
                }
            }
        }


        public decimal Score_dv
        {
            get { return Score_Score_dv; }
            set
            {
                if (Score_Score_dv != value)
                {
                    SendPropertyChanging();
                    Score_Score_dv = value;
                    SendPropertyChanged("Score_dv");
                }
            }
        }

        public decimal Score_hv
        {
            get { return Score_Score_hv; }
            set
            {
                if (Score_Score_hv != value)
                {
                    SendPropertyChanging();
                    Score_Score_hv = value;
                    SendPropertyChanged("Score_hv");
                }
            }
        }


        public decimal Score_pv_a
        {
            get { return Score_Score_pv_a; }
            set
            {
                if (Score_Score_pv_a != value)
                {
                    SendPropertyChanging();
                    Score_Score_pv_a = value;
                    SendPropertyChanged("Score_pv_a");
                }
            }
        }

        public decimal Score_pv_b
        {
            get { return Score_Score_pv_b; }
            set
            {
                if (Score_Score_pv_b != value)
                {
                    SendPropertyChanging();
                    Score_Score_pv_b = value;
                    SendPropertyChanged("Score_pv_b");
                }
            }
        }



        public int shop_category_id
        {
            get { return Score_shop_category_id; }
            set
            {
                if (Score_shop_category_id != value)
                {
                    SendPropertyChanging();
                    Score_shop_category_id = value;
                    SendPropertyChanged("shop_category_id");
                }
            }
        }




        //[Column(Storage = "_Attributes", DbType = "NVarChar(250)")]
        public string Attributes
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Attributes");
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

        public int AgentId
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("AgentId");
                }
            }
        }

        //[Column(Storage = "_BuyPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal BuyPrice
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    SendPropertyChanging();
                    decimal_2 = value;
                    SendPropertyChanged("BuyPrice");
                }
            }
        }

        //[Column(Storage = "_CartType", DbType = "Int NOT NULL")]
        public int CartType
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("CartType");
                }
            }
        }

        //[Column(Storage = "_CreateTime", DbType = "DateTime NOT NULL")]
        public DateTime CreateTime
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
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("DetailedSpecifications");
                }
            }
        }

        //[Column(Storage = "_Ems_fee", DbType = "Decimal(18,2)")]
        public decimal? Ems_fee
        {
            get { return decimal_5; }
            set
            {
                decimal? nullable = decimal_5;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_5 = value;
                    SendPropertyChanged("Ems_fee");
                }
            }
        }

        //[Column(Storage = "_Express_fee", DbType = "Decimal(18,2)")]
        public decimal? Express_fee
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
                    SendPropertyChanged("Express_fee");
                }
            }
        }

        //[Column(Storage = "_ExtensionAttriutes", DbType = "NVarChar(250)")]
        public string ExtensionAttriutes
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("ExtensionAttriutes");
                }
            }
        }

        //[Column(Storage = "_FeeType", DbType = "Int")]
        public int? FeeType
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("FeeType");
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
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IsJoinActivity");
                }
            }
        }

        //[Column(Storage = "_IsPresent", DbType = "Int NOT NULL")]
        public int IsPresent
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("IsPresent");
                }
            }
        }

        //[Column(Storage = "_IsReal", DbType = "Int NOT NULL")]
        public int IsReal
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsReal");
                }
            }
        }

        //[Column(Storage = "_IsShipment", DbType = "Int NOT NULL")]
        public int IsShipment
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
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
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
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

        //[Column(Storage = "_OriginalImge", DbType = "NVarChar(250)")]
        public string OriginalImge
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("OriginalImge");
                }
            }
        }

        //[Column(Storage = "_ParentGuid", DbType = "UniqueIdentifier")]
        public Guid? ParentGuid
        {
            get { return guid_2; }
            set
            {
                if (guid_2 != value)
                {
                    SendPropertyChanging();
                    guid_2 = value;
                    SendPropertyChanged("ParentGuid");
                }
            }
        }

        //[Column(Storage = "_Post_fee", DbType = "Decimal(18,2)")]
        public decimal? Post_fee
        {
            get { return decimal_3; }
            set
            {
                decimal? nullable = decimal_3;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_3 = value;
                    SendPropertyChanged("Post_fee");
                }
            }
        }

        //[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid ProductGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("ProductGuid");
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

        //[Column(Storage = "_SellName", DbType = "NVarChar(50)")]
        public string SellName
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("SellName");
                }
            }
        }

        //[Column(Storage = "_setStock", CanBeNull = false)]
        public string setStock
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("setStock");
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ShopID
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        //[Column(Storage = "_ShopPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal ShopPrice
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    SendPropertyChanging();
                    decimal_1 = value;
                    SendPropertyChanged("ShopPrice");
                }
            }
        }

        //[Column(Storage = "_SpecificationName", DbType = "NVarChar(500)")]
        public string SpecificationName
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("SpecificationName");
                }
            }
        }

        //[Column(Storage = "_SpecificationValue", DbType = "NVarChar(500)")]
        public string SpecificationValue
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
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