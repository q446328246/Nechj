using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_OrderInfo")]
    public class ShopNum1_OrderInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte? byte_0;
        private byte? byte_1;
        private byte? byte_2;
        private byte? byte_3;
        private byte? byte_4;
        private byte? byte_5;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private DateTime? dateTime_4;
        private DateTime? dateTime_5;
        private decimal? decimal_0;
        private decimal? decimal_1;
        private decimal decimal_10;
        private decimal? decimal_11;
        private decimal? decimal_12;
        private decimal decimal_13;
        private decimal? decimal_2;
        private decimal? decimal_3;
        private decimal? decimal_4;
        private decimal decimal_5;
        private decimal decimal_6;
        private decimal decimal_7;
        private decimal decimal_8;
        private decimal decimal_9;
        private decimal decimal_14;
        private Guid guid_0;
        private Guid? guid_1;
        private Guid? guid_2;
        private Guid? guid_3;
        private Guid? guid_4;
        private Guid? guid_5;
        private Guid? guid_6;
        private int int_0;
        private int int_1;
        private int int_10;
        private int int_11;
        private int int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int int_6;
        private int? int_7;
        private int? int_8;
        private int int_9;
        private int int_12;

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
        private string string_25;
        private string string_26;
        private string string_27;
        private string string_28;
        private string string_29;
        private string string_3;
        private string string_30;
        private string string_31;
        private string string_32;
        private string string_33;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;
        private decimal Score_Score_pv_b;
        private decimal Score_Score_hv;
        private decimal Score_Score_dv;
        private decimal Score_Score_pv_a;
        private string Score_AgentId;
        private string ServiceAgent_string;

        private decimal Score_Score_cv;
        private decimal Score_Score_max_hv;
        private int Score_shop_category_id;
        private decimal Score_score_reduce_pv_b;
        private decimal Score_score_reduce_hv;
        private decimal Score_score_reduce_dv;
        private decimal Score_score_reduce_pv_a;
        private decimal Score_score_pv_cv;
        private decimal Score_Offset_pv_b;



        public decimal SuanLiUnitPrice
        {
            get { return decimal_14; }
            set
            {
                if (decimal_14 != value)
                {
                    SendPropertyChanging();
                    decimal_14 = value;
                    SendPropertyChanged("SuanLiUnitPrice");
                }
            }
        }
        public int SuanLiDaySum
        {
            get { return int_12; }
            set
            {
                if (int_12 != value)
                {
                    SendPropertyChanging();
                    int_12 = value;
                    SendPropertyChanged("SuanLiDaySum");
                }
            }
        }

        public Guid? SuperiorRank
        {
            get { return guid_6; }
            set
            {
                if (guid_6 != value)
                {
                    SendPropertyChanging();
                    guid_6 = value;
                    SendPropertyChanged("SuperiorRank");
                }
            }
        }

        public decimal ProductPv_b
        {
            get { return decimal_13; }
            set
            {
                if (decimal_13 != value)
                {
                    SendPropertyChanging();
                    decimal_13 = value;
                    SendPropertyChanged("ProductPv_b");
                }
            }
        }

        public decimal Offset_pv_b
        {
            get { return Score_Offset_pv_b; }
            set
            {
                if (Score_Offset_pv_b != value)
                {
                    SendPropertyChanging();
                    Score_Offset_pv_b = value;
                    SendPropertyChanged("Offset_pv_b");
                }
            }
        }

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

        public string ServiceAgent
        {
            get { return ServiceAgent_string; }
            set
            {
                if (ServiceAgent_string != value)
                {
                    SendPropertyChanging();
                    ServiceAgent_string = value;
                    SendPropertyChanged("ServiceAgent");
                }
            }
        }

        public decimal score_reduce_dv
        {
            get { return Score_score_reduce_dv; }
            set
            {
                if (Score_score_reduce_dv != value)
                {
                    SendPropertyChanging();
                    Score_score_reduce_dv = value;
                    SendPropertyChanged("score_reduce_dv");
                }
            }
        }

        public decimal score_reduce_hv
        {
            get { return Score_score_reduce_hv; }
            set
            {
                if (Score_score_reduce_hv != value)
                {
                    SendPropertyChanging();
                    Score_score_reduce_hv = value;
                    SendPropertyChanged("score_reduce_hv");
                }
            }
        }

        public decimal score_reduce_pv_a
        {
            get { return Score_score_reduce_pv_a; }
            set
            {
                if (Score_score_reduce_pv_a != value)
                {
                    SendPropertyChanging();
                    Score_score_reduce_pv_a = value;
                    SendPropertyChanged("score_reduce_pv_a");
                }
            }
        }

        public decimal score_reduce_pv_b
        {
            get { return Score_score_reduce_pv_b; }
            set
            {
                if (Score_score_reduce_pv_b != value)
                {
                    SendPropertyChanging();
                    Score_score_reduce_pv_b = value;
                    SendPropertyChanged("score_reduce_pv_b");
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


        //给他值
        public decimal Score_cv
        {
            get { return Score_Score_cv; }
            set
            {
                if (Score_Score_cv != value)
                {
                    SendPropertyChanging();
                    Score_Score_cv = value;
                    SendPropertyChanged("Score_cv");
                }
            }
        }

        //给他值
        public decimal Score_max_hv
        {
            get { return Score_Score_max_hv; }
            set
            {
                if (Score_Score_max_hv != value)
                {
                    SendPropertyChanging();
                    Score_Score_max_hv = value;
                    SendPropertyChanged("Score_max_hv");
                }
            }
        }



        public string AgentId
        {
            get { return Score_AgentId; }
            set
            {
                if (Score_AgentId != value)
                {
                    SendPropertyChanging();
                    Score_AgentId = value;
                    SendPropertyChanged("AgentId");
                }
            }
        }


        //给他值
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



        //给他值
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


        //给他值
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


        //给他值
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




        //[Column(Storage = "_ActivityGuid", DbType = "UniqueIdentifier")]
        public Guid? ActivityGuid
        {
            get { return guid_3; }
            set
            {
                if (guid_3 != value)
                {
                    SendPropertyChanging();
                    guid_3 = value;
                    SendPropertyChanged("ActivityGuid");
                }
            }
        }

        //[Column(Storage = "_ActvieContent", DbType = "NVarChar(50)")]
        public string ActvieContent
        {
            get { return string_28; }
            set
            {
                if (string_28 != value)
                {
                    SendPropertyChanging();
                    string_28 = value;
                    SendPropertyChanged("ActvieContent");
                }
            }
        }

        //[Column(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Address");
                }
            }
        }

        //[Column(Storage = "_AlreadPayPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal AlreadPayPrice
        {
            get { return decimal_7; }
            set
            {
                if (decimal_7 != value)
                {
                    SendPropertyChanging();
                    decimal_7 = value;
                    SendPropertyChanged("AlreadPayPrice");
                }
            }
        }

        //[Column(Storage = "_BlessCardContent", DbType = "NVarChar(4000)")]
        public string BlessCardContent
        {
            get { return string_23; }
            set
            {
                if (string_23 != value)
                {
                    SendPropertyChanging();
                    string_23 = value;
                    SendPropertyChanged("BlessCardContent");
                }
            }
        }

        //[Column(Storage = "_BlessCardGuid", DbType = "UniqueIdentifier")]
        public Guid? BlessCardGuid
        {
            get { return guid_5; }
            set
            {
                if (guid_5 != value)
                {
                    SendPropertyChanging();
                    guid_5 = value;
                    SendPropertyChanged("BlessCardGuid");
                }
            }
        }

        //[Column(Storage = "_BlessCardName", DbType = "NVarChar(50)")]
        public string BlessCardName
        {
            get { return string_22; }
            set
            {
                if (string_22 != value)
                {
                    SendPropertyChanging();
                    string_22 = value;
                    SendPropertyChanged("BlessCardName");
                }
            }
        }

        //[Column(Storage = "_BlessCardPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal BlessCardPrice
        {
            get { return decimal_6; }
            set
            {
                if (decimal_6 != value)
                {
                    SendPropertyChanging();
                    decimal_6 = value;
                    SendPropertyChanged("BlessCardPrice");
                }
            }
        }

        //[Column(Storage = "_BuyIsDeleted", DbType = "TinyInt")]
        public byte? BuyIsDeleted
        {
            get { return byte_2; }
            set
            {
                if (byte_2 != value)
                {
                    SendPropertyChanging();
                    byte_2 = value;
                    SendPropertyChanged("BuyIsDeleted");
                }
            }
        }

        //[Column(Storage = "_BuyType", DbType = "NVarChar(50)")]
        public string BuyType
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    SendPropertyChanging();
                    string_16 = value;
                    SendPropertyChanged("BuyType");
                }
            }
        }

        //[Column(Storage = "_CancelReason", DbType = "NVarChar(500)")]
        public string CancelReason
        {
            get { return string_19; }
            set
            {
                if (string_19 != value)
                {
                    SendPropertyChanging();
                    string_19 = value;
                    SendPropertyChanged("CancelReason");
                }
            }
        }

        //[Column(Storage = "_ClientToSellerMsg", DbType = "NVarChar(500)")]
        public string ClientToSellerMsg
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("ClientToSellerMsg");
                }
            }
        }

        //[Column(Storage = "_ConfirmTime", DbType = "DateTime")]
        public DateTime? ConfirmTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("ConfirmTime");
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

        //[Column(Storage = "_Deposit", DbType = "Decimal(18,2)")]
        public decimal? Deposit
        {
            get { return decimal_11; }
            set
            {
                decimal? nullable = decimal_11;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_11 = value;
                    SendPropertyChanged("Deposit");
                }
            }
        }

        //[Column(Storage = "_Discount", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Discount
        {
            get { return decimal_10; }
            set
            {
                if (decimal_10 != value)
                {
                    SendPropertyChanging();
                    decimal_10 = value;
                    SendPropertyChanged("Discount");
                }
            }
        }

        //[Column(Storage = "_DispatchPrice", DbType = "Decimal(18,2)")]
        public decimal? DispatchPrice
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
                    SendPropertyChanged("DispatchPrice");
                }
            }
        }

        //[Column(Storage = "_DispatchTime", DbType = "DateTime")]
        public DateTime? DispatchTime
        {
            get { return dateTime_4; }
            set
            {
                if (dateTime_4 != value)
                {
                    SendPropertyChanging();
                    dateTime_4 = value;
                    SendPropertyChanged("DispatchTime");
                }
            }
        }

        //[Column(Storage = "_DispatchType", DbType = "Int")]
        public int? DispatchType
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("DispatchType");
                }
            }
        }

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Email");
                }
            }
        }

        //[Column(Storage = "_EndTime", DbType = "DateTime")]
        public DateTime? EndTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("EndTime");
                }
            }
        }

        //[Column(Storage = "_FeeType", DbType = "Int")]
        public int? FeeType
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("FeeType");
                }
            }
        }

        //[Column(Storage = "_FromAd", DbType = "UniqueIdentifier")]
        public Guid? FromAd
        {
            get { return guid_2; }
            set
            {
                if (guid_2 != value)
                {
                    SendPropertyChanging();
                    guid_2 = value;
                    SendPropertyChanged("FromAd");
                }
            }
        }

        //[Column(Storage = "_FromUrl", DbType = "NVarChar(250)")]
        public string FromUrl
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("FromUrl");
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

        //[Column(Storage = "_IdentifyCode", DbType = "varchar(10)", CanBeNull = false)]
        public string IdentifyCode
        {
            get { return string_33; }
            set
            {
                if (string_33 != value)
                {
                    SendPropertyChanging();
                    string_33 = value;
                    SendPropertyChanged("IdentifyCode");
                }
            }
        }

        //[Column(Storage = "_InvoiceContent", DbType = "NVarChar(50)")]
        public string InvoiceContent
        {
            get { return string_25; }
            set
            {
                if (string_25 != value)
                {
                    SendPropertyChanging();
                    string_25 = value;
                    SendPropertyChanged("InvoiceContent");
                }
            }
        }

        //[Column(Storage = "_InvoiceTax", DbType = "Decimal(18,2) NOT NULL")]
        public decimal InvoiceTax
        {
            get { return decimal_9; }
            set
            {
                if (decimal_9 != value)
                {
                    SendPropertyChanging();
                    decimal_9 = value;
                    SendPropertyChanged("InvoiceTax");
                }
            }
        }

        //[Column(Storage = "_InvoiceTitle", DbType = "NVarChar(50)")]
        public string InvoiceTitle
        {
            get { return string_24; }
            set
            {
                if (string_24 != value)
                {
                    SendPropertyChanging();
                    string_24 = value;
                    SendPropertyChanged("InvoiceTitle");
                }
            }
        }

        //[Column(Storage = "_InvoiceType", DbType = "NVarChar(50)")]
        public string InvoiceType
        {
            get { return string_26; }
            set
            {
                if (string_26 != value)
                {
                    SendPropertyChanging();
                    string_26 = value;
                    SendPropertyChanged("InvoiceType");
                }
            }
        }

        //[Column(Storage = "_IsBuyComment", DbType = "TinyInt")]
        public byte? IsBuyComment
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("IsBuyComment");
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "TinyInt")]
        public byte? IsDeleted
        {
            get { return byte_4; }
            set
            {
                if (byte_4 != value)
                {
                    SendPropertyChanging();
                    byte_4 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsLogistics", DbType = "Int")]
        public int? IsLogistics
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("IsLogistics");
                }
            }
        }

        //[Column(Storage = "_IsMemdelay", DbType = "Int NOT NULL")]
        public int IsMemdelay
        {
            get { return int_11; }
            set
            {
                if (int_11 != value)
                {
                    SendPropertyChanging();
                    int_11 = value;
                    SendPropertyChanged("IsMemdelay");
                }
            }
        }

        //[Column(Storage = "_IsMinus", DbType = "Int NOT NULL")]
        public int IsMinus
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("IsMinus");
                }
            }
        }

        //[Column(Storage = "_IsSellComment", DbType = "TinyInt")]
        public byte? IsSellComment
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    SendPropertyChanging();
                    byte_1 = value;
                    SendPropertyChanged("IsSellComment");
                }
            }
        }

        //[Column(Storage = "_JoinActiveType", DbType = "Int")]
        public int? JoinActiveType
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("JoinActiveType");
                }
            }
        }

        //[Column(Storage = "_LogisticsCompany", DbType = "NVarChar(50)")]
        public string LogisticsCompany
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("LogisticsCompany");
                }
            }
        }

        //[Column(Storage = "_LogisticsCompanyCode", DbType = "NVarChar(50)")]
        public string LogisticsCompanyCode
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("LogisticsCompanyCode");
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

        //[Column(Storage = "_Mobile", DbType = "NVarChar(20)")]
        public string Mobile
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("Mobile");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(50)")]
        public string Name
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        //[Column(Storage = "_OderStatus", DbType = "Int NOT NULL")]
        public int OderStatus
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("OderStatus");
                }
            }
        }

        //[Column(Storage = "_OrderNumber", DbType = "NVarChar(50)")]
        public string OrderNumber
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("OrderNumber");
                }
            }
        }

        //[Column(Storage = "_OrderType", DbType = "TinyInt")]
        public byte? OrderType
        {
            get { return byte_5; }
            set
            {
                if (byte_5 != value)
                {
                    SendPropertyChanging();
                    byte_5 = value;
                    SendPropertyChanged("OrderType");
                }
            }
        }

        //[Column(Storage = "_OutOfStockOperate", DbType = "NVarChar(50)")]
        public string OutOfStockOperate
        {
            get { return string_20; }
            set
            {
                if (string_20 != value)
                {
                    SendPropertyChanging();
                    string_20 = value;
                    SendPropertyChanged("OutOfStockOperate");
                }
            }
        }

        //[Column(Storage = "_PackGuid", DbType = "UniqueIdentifier")]
        public Guid? PackGuid
        {
            get { return guid_4; }
            set
            {
                if (guid_4 != value)
                {
                    SendPropertyChanging();
                    guid_4 = value;
                    SendPropertyChanged("PackGuid");
                }
            }
        }

        //[Column(Storage = "_PackName", DbType = "NVarChar(50)")]
        public string PackName
        {
            get { return string_21; }
            set
            {
                if (string_21 != value)
                {
                    SendPropertyChanging();
                    string_21 = value;
                    SendPropertyChanged("PackName");
                }
            }
        }

        //[Column(Storage = "_PackPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal PackPrice
        {
            get { return decimal_5; }
            set
            {
                if (decimal_5 != value)
                {
                    SendPropertyChanging();
                    decimal_5 = value;
                    SendPropertyChanged("PackPrice");
                }
            }
        }

        //[Column(Storage = "_PayMemo", DbType = "NVarChar(500)")]
        public string PayMemo
        {
            get { return string_17; }
            set
            {
                if (string_17 != value)
                {
                    SendPropertyChanging();
                    string_17 = value;
                    SendPropertyChanged("PayMemo");
                }
            }
        }

        //[Column(Storage = "_PaymentGuid", DbType = "UniqueIdentifier")]
        public Guid? PaymentGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("PaymentGuid");
                }
            }
        }

        //[Column(Storage = "_PayMentMemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string PayMentMemLoginID
        {
            get { return string_31; }
            set
            {
                if (string_31 != value)
                {
                    SendPropertyChanging();
                    string_31 = value;
                    SendPropertyChanged("PayMentMemLoginID");
                }
            }
        }

        //[Column(Storage = "_PaymentName", DbType = "NVarChar(50)")]
        public string PaymentName
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("PaymentName");
                }
            }
        }

        //[Column(Storage = "_PaymentPrice", DbType = "Decimal(18,2)")]
        public decimal? PaymentPrice
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
                    SendPropertyChanged("PaymentPrice");
                }
            }
        }

        //[Column(Storage = "_PaymentStatus", DbType = "Int NOT NULL")]
        public int PaymentStatus
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("PaymentStatus");
                }
            }
        }

        //[Column(Storage = "_PayTime", DbType = "DateTime")]
        public DateTime? PayTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("PayTime");
                }
            }
        }

        //[Column(Storage = "_Postalcode", DbType = "NVarChar(20)")]
        public string Postalcode
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("Postalcode");
                }
            }
        }

        //[Column(Storage = "_ProductPrice", DbType = "Decimal(18,2)")]
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

        //[Column(Storage = "_ReceiptTime", DbType = "DateTime")]
        public DateTime? ReceiptTime
        {
            get { return dateTime_5; }
            set
            {
                if (dateTime_5 != value)
                {
                    SendPropertyChanging();
                    dateTime_5 = value;
                    SendPropertyChanged("ReceiptTime");
                }
            }
        }

        //[Column(Storage = "_ReceivedDays", DbType = "Int NOT NULL")]
        public int ReceivedDays
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    SendPropertyChanging();
                    int_10 = value;
                    SendPropertyChanged("ReceivedDays");
                }
            }
        }

        //[Column(Storage = "_RecommendCommision", DbType = "Decimal(18,2)")]
        public decimal? RecommendCommision
        {
            get { return decimal_12; }
            set
            {
                decimal? nullable = decimal_12;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    decimal_12 = value;
                    SendPropertyChanged("RecommendCommision");
                }
            }
        }

        //[Column(Storage = "_refundStatus", DbType = "Int")]
        public int? refundStatus
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("refundStatus");
                }
            }
        }

        //[Column(Storage = "_RegionCode", DbType = "VarChar(50)")]
        public string RegionCode
        {
            get { return string_27; }
            set
            {
                if (string_27 != value)
                {
                    SendPropertyChanging();
                    string_27 = value;
                    SendPropertyChanged("RegionCode");
                }
            }
        }

        //[Column(Storage = "_ScorePrice", DbType = "Decimal(18,2)")]
        public decimal? ScorePrice
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
                    SendPropertyChanged("ScorePrice");
                }
            }
        }

        //[Column(Storage = "_SellerToClientMsg", DbType = "NVarChar(500)")]
        public string SellerToClientMsg
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("SellerToClientMsg");
                }
            }
        }

        //[Column(Storage = "_SellIsDeleted", DbType = "TinyInt")]
        public byte? SellIsDeleted
        {
            get { return byte_3; }
            set
            {
                if (byte_3 != value)
                {
                    SendPropertyChanging();
                    byte_3 = value;
                    SendPropertyChanged("SellIsDeleted");
                }
            }
        }

        //[Column(Storage = "_setStock", CanBeNull = false)]
        public string setStock
        {
            get { return string_32; }
            set
            {
                if (string_32 != value)
                {
                    SendPropertyChanging();
                    string_32 = value;
                    SendPropertyChanged("setStock");
                }
            }
        }

        //[Column(Storage = "_ShipmentNumber", DbType = "NVarChar(50)")]
        public string ShipmentNumber
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    SendPropertyChanging();
                    string_15 = value;
                    SendPropertyChanged("ShipmentNumber");
                }
            }
        }

        //[Column(Storage = "_ShipmentStatus", DbType = "Int NOT NULL")]
        public int ShipmentStatus
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("ShipmentStatus");
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "NVarChar(50)")]
        public string ShopID
        {
            get { return string_18; }
            set
            {
                if (string_18 != value)
                {
                    SendPropertyChanging();
                    string_18 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "NVarChar(50)")]
        public string ShopName
        {
            get { return string_30; }
            set
            {
                if (string_30 != value)
                {
                    SendPropertyChanging();
                    string_30 = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        //[Column(Storage = "_ShouldPayPrice", DbType = "Decimal(18,2)")]
        public decimal? ShouldPayPrice
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
                    SendPropertyChanged("ShouldPayPrice");
                }
            }
        }

        //[Column(Storage = "_SurplusPrice", DbType = "Decimal(18,2) NOT NULL")]
        public decimal SurplusPrice
        {
            get { return decimal_8; }
            set
            {
                if (decimal_8 != value)
                {
                    SendPropertyChanging();
                    decimal_8 = value;
                    SendPropertyChanged("SurplusPrice");
                }
            }
        }

        //[Column(Storage = "_Tel", DbType = "NVarChar(20)")]
        public string Tel
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("Tel");
                }
            }
        }

        //[Column(Storage = "_TradeID", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string TradeID
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("TradeID");
                }
            }
        }

        //[Column(Storage = "_UsedFavourTicket", DbType = "NVarChar(50)")]
        public string UsedFavourTicket
        {
            get { return string_29; }
            set
            {
                if (string_29 != value)
                {
                    SendPropertyChanging();
                    string_29 = value;
                    SendPropertyChanged("UsedFavourTicket");
                }
            }
        }

        //[Column(Storage = "_UseScore", DbType = "Int NOT NULL")]
        public int UseScore
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("UseScore");
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