using System;
using System.ComponentModel;
using System.Collections.Generic;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Shop_Product")]
    public class ShopNum1_Shop_Product : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private DateTime? dateTime_4;
        private DateTime? dateTime_5;
        private decimal decimal_0;
        private decimal? decimal_1;
        private decimal decimal_2;
        private decimal decimal_3;
        private decimal decimal_4;
        private decimal decimal_5;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;
        private int int_1;
        private int? int_10;
        private int int_11;
        private int? int_12;
        private int int_13;
        private int int_14;
        private int int_15;
        private int int_16;
        private int int_17;
        private int int_18;
        private int int_19;
        private int int_2;
        private int int_20;
        private int? int_21;
        private int? int_22;
        private int? int_23;
        private int? int_24;
        private int? int_25;
        private int? int_26;
        private int? int_27;
        private int? int_28;
        private int? int_29;
        private int int_3;
        private int? int_30;
        private int int_31;
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private int? int_8;
        private int? int_9;
        private long long_0;

        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_14;
        private string string_15;
        private string string_16;
        private string string_17;
        private string string_18;
        private string string_19;
        private string string_2;
        private string string_20;
        private string string_21;
        private string string_22;
        private string string_23;
        private string string_24;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;
        private int MyID_id;
        private string Score_Color;
        private string Score_ize;
        private decimal textWeight_one;
        private List<ShopNum1_Shop_Product_Price> prices = new List<ShopNum1_Shop_Product_Price>();
        private int unitCount_one;
        private int Score_MaxNumber_one;

        private decimal MyPrice_one;


        public decimal MyPrice
        {
            get { return MyPrice_one; }
            set
            {
                if (MyPrice_one != value)
                {
                    SendPropertyChanging();
                    MyPrice_one = value;
                    SendPropertyChanged("MyPrice");
                }
            }
        }

        public int unitCount
        {
            get { return unitCount_one; }
            set
            {
                if (unitCount_one != value)
                {
                    SendPropertyChanging();
                    unitCount_one = value;
                    SendPropertyChanged("unitCount");
                }
            }
        }
        public decimal textWeight
        {
            get { return textWeight_one; }
            set
            {
                if (textWeight_one != value)
                {
                    SendPropertyChanging();
                    textWeight_one = value;
                    SendPropertyChanged("textWeight");
                }
            }
        }

        public int MaxNumber_one
        {
            get { return Score_MaxNumber_one; }
            set
            {
                if (Score_MaxNumber_one != value)
                {
                    SendPropertyChanging();
                    Score_MaxNumber_one = value;
                    SendPropertyChanged("MaxNumber_one");
                }
            }
        }

        public List<ShopNum1_Shop_Product_Price> Prices
        {
            get { return prices; }
            set { prices = value; }
        }

        public string Size
        {
            get { return Score_ize; }
            set
            {
                if (Score_ize != value)
                {
                    SendPropertyChanging();
                    Score_ize = value;
                    SendPropertyChanged("Size");
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


        public int MyID
        {
            get { return MyID_id; }
            set
            {
                if (MyID_id != value)
                {
                    SendPropertyChanging();
                    MyID_id = value;
                    SendPropertyChanged("MyID");
                }
            }
        }


        //给值
        

        //[Column(Storage = "_AddressCode", DbType = "NVarChar(250)")]
        public string AddressCode
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    SendPropertyChanging();
                    string_16 = value;
                    SendPropertyChanged("AddressCode");
                }
            }
        }

        //[Column(Storage = "_AddressValue", DbType = "NVarChar(250)")]
        public string AddressValue
        {
            get { return string_17; }
            set
            {
                if (string_17 != value)
                {
                    SendPropertyChanging();
                    string_17 = value;
                    SendPropertyChanged("AddressValue");
                }
            }
        }

        //[Column(Storage = "_BrandGuid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid BrandGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("BrandGuid");
                }
            }
        }

        //[Column(Storage = "_BrandName", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string BrandName
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("BrandName");
                }
            }
        }

        //[Column(Storage = "_BuyCount", DbType = "Int NOT NULL")]
        public int BuyCount
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("BuyCount");
                }
            }
        }

        //[Column(Storage = "_ClickCount", DbType = "Int NOT NULL")]
        public int ClickCount
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("ClickCount");
                }
            }
        }

        //[Column(Storage = "_CollectCount", DbType = "Int NOT NULL")]
        public int CollectCount
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("CollectCount");
                }
            }
        }

        //[Column(Storage = "_CommentCount", DbType = "Int NOT NULL")]
        public int CommentCount
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("CommentCount");
                }
            }
        }

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
            get { return string_24; }
            set
            {
                if (string_24 != value)
                {
                    SendPropertyChanging();
                    string_24 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        //[Column(Storage = "_Ctype", DbType = "Int")]
        public int? Ctype
        {
            get { return int_25; }
            set
            {
                if (int_25 != value)
                {
                    SendPropertyChanging();
                    int_25 = value;
                    SendPropertyChanged("Ctype");
                }
            }
        }

        //[Column(Storage = "_DeSaleTime", DbType = "DateTime")]
        public DateTime? DeSaleTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("DeSaleTime");
                }
            }
        }

        //[Column(Storage = "_Description", DbType = "NVarChar(250)")]
        public string Description
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("Description");
                }
            }
        }

        //[Column(Storage = "_Detail", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Detail
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Detail");
                }
            }
        }

        //[Column(Storage = "_Ems_fee", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Ems_fee
        {
            get { return decimal_4; }
            set
            {
                if (decimal_4 != value)
                {
                    SendPropertyChanging();
                    decimal_4 = value;
                    SendPropertyChanged("Ems_fee");
                }
            }
        }

        //[Column(Storage = "_EndTime", DbType = "DateTime")]
        public DateTime? EndTime
        {
            get { return dateTime_5; }
            set
            {
                if (dateTime_5 != value)
                {
                    SendPropertyChanging();
                    dateTime_5 = value;
                    SendPropertyChanged("EndTime");
                }
            }
        }

        //[Column(Storage = "_Express_fee", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Express_fee
        {
            get { return decimal_3; }
            set
            {
                if (decimal_3 != value)
                {
                    SendPropertyChanging();
                    decimal_3 = value;
                    SendPropertyChanged("Express_fee");
                }
            }
        }

        //[Column(Storage = "_FeeTemplateID", DbType = "Int")]
        public int? FeeTemplateID
        {
            get { return int_21; }
            set
            {
                if (int_21 != value)
                {
                    SendPropertyChanging();
                    int_21 = value;
                    SendPropertyChanged("FeeTemplateID");
                }
            }
        }

        //[Column(Storage = "_FeeTemplateName", DbType = "NVarChar(50)")]
        public string FeeTemplateName
        {
            get { return string_20; }
            set
            {
                if (string_20 != value)
                {
                    SendPropertyChanging();
                    string_20 = value;
                    SendPropertyChanged("FeeTemplateName");
                }
            }
        }

        //[Column(Storage = "_FeeType", DbType = "Int NOT NULL")]
        public int FeeType
        {
            get { return int_13; }
            set
            {
                if (int_13 != value)
                {
                    SendPropertyChanging();
                    int_13 = value;
                    SendPropertyChanged("FeeType");
                }
            }
        }

        //[Column(Storage = "_GoodsType", DbType = "Int")]
        public int? GoodsType
        {
            get { return int_22; }
            set
            {
                if (int_22 != value)
                {
                    SendPropertyChanging();
                    int_22 = value;
                    SendPropertyChanged("GoodsType");
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

        //[Column(Storage = "_Id", AutoSync = AutoSync.Always, DbType = "BigInt NOT NULL IDENTITY", //IsDbGenerated = true)]
        public long Id
        {
            get { return long_0; }
            set
            {
                if (long_0 != value)
                {
                    SendPropertyChanging();
                    long_0 = value;
                    SendPropertyChanged("Id");
                }
            }
        }

        //[Column(Storage = "_Instruction", DbType = "NVarChar(4000)")]
        public string Instruction
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Instruction");
                }
            }
        }

        //[Column(Storage = "_IsAudit", DbType = "Int NOT NULL")]
        public int IsAudit
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("IsAudit");
                }
            }
        }

        //[Column(Storage = "_IsBest", DbType = "Int")]
        public int? IsBest
        {
            get { return int_12; }
            set
            {
                if (int_12 != value)
                {
                    SendPropertyChanging();
                    int_12 = value;
                    SendPropertyChanged("IsBest");
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
        {
            get { return int_26; }
            set
            {
                if (int_26 != value)
                {
                    SendPropertyChanging();
                    int_26 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsHot", DbType = "Int")]
        public int? IsHot
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("IsHot");
                }
            }
        }

        //[Column(Storage = "_IsNew", DbType = "Int")]
        public int? IsNew
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("IsNew");
                }
            }
        }

        //[Column(Storage = "_IsPromotion", DbType = "Int")]
        public int? IsPromotion
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    SendPropertyChanging();
                    int_10 = value;
                    SendPropertyChanged("IsPromotion");
                }
            }
        }

        //[Column(Storage = "_IsReal", DbType = "Int NOT NULL")]
        public int IsReal
        {
            get { return int_14; }
            set
            {
                if (int_14 != value)
                {
                    SendPropertyChanging();
                    int_14 = value;
                    SendPropertyChanged("IsReal");
                }
            }
        }

        //[Column(Storage = "_IsRecommend", DbType = "Int NOT NULL")]
        public int IsRecommend
        {
            get { return int_11; }
            set
            {
                if (int_11 != value)
                {
                    SendPropertyChanging();
                    int_11 = value;
                    SendPropertyChanged("IsRecommend");
                }
            }
        }

        //[Column(Storage = "_IsSaled", DbType = "Int")]
        public int? IsSaled
        {
            get { return int_27; }
            set
            {
                if (int_27 != value)
                {
                    SendPropertyChanging();
                    int_27 = value;
                    SendPropertyChanged("IsSaled");
                }
            }
        }

        //[Column(Storage = "_IsSell", DbType = "Int NOT NULL")]
        public int IsSell
        {
            get { return int_15; }
            set
            {
                if (int_15 != value)
                {
                    SendPropertyChanging();
                    int_15 = value;
                    SendPropertyChanged("IsSell");
                }
            }
        }

        //[Column(Storage = "_IsShopGood", DbType = "Int NOT NULL")]
        public int IsShopGood
        {
            get { return int_20; }
            set
            {
                if (int_20 != value)
                {
                    SendPropertyChanging();
                    int_20 = value;
                    SendPropertyChanged("IsShopGood");
                }
            }
        }

        //[Column(Storage = "_IsShopHot", DbType = "Int NOT NULL")]
        public int IsShopHot
        {
            get { return int_17; }
            set
            {
                if (int_17 != value)
                {
                    SendPropertyChanging();
                    int_17 = value;
                    SendPropertyChanged("IsShopHot");
                }
            }
        }

        //[Column(Storage = "_IsShopNew", DbType = "Int NOT NULL")]
        public int IsShopNew
        {
            get { return int_16; }
            set
            {
                if (int_16 != value)
                {
                    SendPropertyChanging();
                    int_16 = value;
                    SendPropertyChanged("IsShopNew");
                }
            }
        }

        //[Column(Storage = "_IsShopPromotion", DbType = "Int NOT NULL")]
        public int IsShopPromotion
        {
            get { return int_18; }
            set
            {
                if (int_18 != value)
                {
                    SendPropertyChanging();
                    int_18 = value;
                    SendPropertyChanged("IsShopPromotion");
                }
            }
        }

        //[Column(Storage = "_IsShopRecommend", DbType = "Int NOT NULL")]
        public int IsShopRecommend
        {
            get { return int_19; }
            set
            {
                if (int_19 != value)
                {
                    SendPropertyChanging();
                    int_19 = value;
                    SendPropertyChanged("IsShopRecommend");
                }
            }
        }

        //[Column(Storage = "_Keywords", DbType = "NVarChar(150)")]
        public string Keywords
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    SendPropertyChanging();
                    string_15 = value;
                    SendPropertyChanged("Keywords");
                }
            }
        }

        //[Column(Storage = "_MarketPrice", DbType = "Decimal(18,2)")]
        public decimal? MarketPrice
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
                    SendPropertyChanged("MarketPrice");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
        {
            get { return string_18; }
            set
            {
                if (string_18 != value)
                {
                    SendPropertyChanging();
                    string_18 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_MinusFee", DbType = "Decimal(18,2) NOT NULL")]
        public decimal MinusFee
        {
            get { return decimal_5; }
            set
            {
                if (decimal_5 != value)
                {
                    SendPropertyChanging();
                    decimal_5 = value;
                    SendPropertyChanged("MinusFee");
                }
            }
        }

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("ModifyTime");
                }
            }
        }

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_23; }
            set
            {
                if (string_23 != value)
                {
                    SendPropertyChanging();
                    string_23 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        //[Column(Storage = "_MonthSale", DbType = "Int NOT NULL")]
        public int MonthSale
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("MonthSale");
                }
            }
        }

        //[Column(Storage = "_MultiImages", DbType = "NVarChar(800)")]
        public string MultiImages
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("MultiImages");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
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

        //[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
        {
            get { return int_28; }
            set
            {
                if (int_28 != value)
                {
                    SendPropertyChanging();
                    int_28 = value;
                    SendPropertyChanged("OrderID");
                }
            }
        }

        //[Column(Storage = "_OriginalImage", DbType = "NVarChar(150) NOT NULL", CanBeNull = false)]
        public string OriginalImage
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("OriginalImage");
                }
            }
        }

        //[Column(Storage = "_Post_fee", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Post_fee
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    SendPropertyChanging();
                    decimal_2 = value;
                    SendPropertyChanged("Post_fee");
                }
            }
        }

        //[Column(Storage = "_ProductCategoryCode", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string ProductCategoryCode
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("ProductCategoryCode");
                }
            }
        }

        //[Column(Storage = "_ProductCategoryName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ProductCategoryName
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("ProductCategoryName");
                }
            }
        }

        //[Column(Storage = "_ProductNum", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string ProductNum
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ProductNum");
                }
            }
        }

        //[Column(Storage = "_ProductSeriesCode", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string ProductSeriesCode
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("ProductSeriesCode");
                }
            }
        }

        //[Column(Storage = "_ProductSeriesName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ProductSeriesName
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("ProductSeriesName");
                }
            }
        }

        //[Column(Storage = "_ProductState", DbType = "Int")]
        public int? ProductState
        {
            get { return int_23; }
            set
            {
                if (int_23 != value)
                {
                    SendPropertyChanging();
                    int_23 = value;
                    SendPropertyChanged("ProductState");
                }
            }
        }

        //[Column(Storage = "_PulishType", DbType = "Int")]
        public int? PulishType
        {
            get { return int_30; }
            set
            {
                if (int_30 != value)
                {
                    SendPropertyChanging();
                    int_30 = value;
                    SendPropertyChanged("PulishType");
                }
            }
        }

        //[Column(Storage = "_RepertoryAlertCount")]
        public int RepertoryAlertCount
        {
            get { return int_31; }
            set
            {
                if (int_31 != value)
                {
                    SendPropertyChanging();
                    int_31 = value;
                    SendPropertyChanged("RepertoryAlertCount");
                }
            }
        }

        //[Column(Storage = "_RepertoryCount", DbType = "Int NOT NULL")]
        public int RepertoryCount
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("RepertoryCount");
                }
            }
        }

        //[Column(Storage = "_SaleNumber", DbType = "Int NOT NULL")]
        public int SaleNumber
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("SaleNumber");
                }
            }
        }

        //[Column(Storage = "_SaleTime", DbType = "DateTime")]
        public DateTime? SaleTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("SaleTime");
                }
            }
        }

        //[Column(Storage = "_Score", DbType = "Int")]
        public int? Score
        {
            get { return int_24; }
            set
            {
                if (int_24 != value)
                {
                    SendPropertyChanging();
                    int_24 = value;
                    SendPropertyChanged("Score");
                }
            }
        }

        //[Column(Storage = "_SetStock", DbType = "Int")]
        public int? SetStock
        {
            get { return int_29; }
            set
            {
                if (int_29 != value)
                {
                    SendPropertyChanging();
                    int_29 = value;
                    SendPropertyChanged("SetStock");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "NVarChar(50)")]
        public string ShopName
        {
            get { return string_19; }
            set
            {
                if (string_19 != value)
                {
                    SendPropertyChanging();
                    string_19 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        //[Column(Storage = "_ShopPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal ShopPrice
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("ShopPrice");
                }
            }
        }

        //[Column(Storage = "_SmallImage", DbType = "NVarChar(150)")]
        public string SmallImage
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("SmallImage");
                }
            }
        }

        //[Column(Storage = "_StartTime", DbType = "DateTime")]
        public DateTime? StartTime
        {
            get { return dateTime_4; }
            set
            {
                if (dateTime_4 != value)
                {
                    SendPropertyChanging();
                    dateTime_4 = value;
                    SendPropertyChanged("StartTime");
                }
            }
        }

        //[Column(Storage = "_ThumbImage", DbType = "NVarChar(150) NOT NULL", CanBeNull = false)]
        public string ThumbImage
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("ThumbImage");
                }
            }
        }

        //[Column(Storage = "_UnitName", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string UnitName
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("UnitName");
                }
            }
        }

        //[Column(Storage = "_Wap_desc", DbType = "VarChar(300)")]
        public string Wap_desc
        {
            get { return string_21; }
            set
            {
                if (string_21 != value)
                {
                    SendPropertyChanging();
                    string_21 = value;
                    SendPropertyChanged("Wap_desc");
                }
            }
        }

        //[Column(Storage = "_Wap_detail_url", DbType = "VarChar(100)")]
        public string Wap_detail_url
        {
            get { return string_22; }
            set
            {
                if (string_22 != value)
                {
                    SendPropertyChanging();
                    string_22 = value;
                    SendPropertyChanged("Wap_detail_url");
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