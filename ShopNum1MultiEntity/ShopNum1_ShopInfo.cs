using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ShopInfo")]
    public class ShopNum1_ShopInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte byte_0;
        private byte? byte_1;
        private byte? byte_2;
        private byte? byte_3;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private DateTime? dateTime_4;
        private DateTime? dateTime_5;
        private decimal decimal_0;
        private Guid guid_0;
        private Guid guid_1;
        private int int_0;
        private int int_1;
        private int int_10;
        private int? int_11;
        private int? int_12;
        private int? int_13;
        private int int_2;
        private int? int_3;
        private int? int_4;
        private int? int_5;
        private int? int_6;
        private int? int_7;
        private int int_8;
        private int int_9;

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
        private string string_34;
        private string string_35;
        private string string_36;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        private string TaxRegistration_one;
        private string Organization_one;
        private string TextBoxReferral_one;

        public string TextBoxReferral
        {
            get { return TextBoxReferral_one; }
            set
            {
                if (TextBoxReferral_one != value)
                {
                    SendPropertyChanging();
                    TextBoxReferral_one = value;
                    SendPropertyChanged("TextBoxReferral");
                }
            }
        }

        public string Organization
        {
            get { return Organization_one; }
            set
            {
                if (Organization_one != value)
                {
                    SendPropertyChanging();
                    Organization_one = value;
                    SendPropertyChanged("Organization");
                }
            }
        }

        public string TaxRegistration
        {
            get { return TaxRegistration_one; }
            set
            {
                if (TaxRegistration_one != value)
                {
                    SendPropertyChanging();
                    TaxRegistration_one = value;
                    SendPropertyChanged("TaxRegistration");
                }
            }
        }

        //[Column(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("Address");
                }
            }
        }

        //[Column(Storage = "_AddressCode", DbType = "NVarChar(50)")]
        public string AddressCode
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("AddressCode");
                }
            }
        }

        //[Column(Storage = "_AddressValue", DbType = "NVarChar(50)")]
        public string AddressValue
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("AddressValue");
                }
            }
        }

        //[Column(Storage = "_ApplyTime", DbType = "DateTime")]
        public DateTime? ApplyTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("ApplyTime");
                }
            }
        }

        //[Column(Storage = "_AuditFailedReason", DbType = "NVarChar(500)")]
        public string AuditFailedReason
        {
            get { return string_35; }
            set
            {
                if (string_35 != value)
                {
                    SendPropertyChanging();
                    string_35 = value;
                    SendPropertyChanged("AuditFailedReason");
                }
            }
        }

        //[Column(Storage = "_AuditTime", DbType = "DateTime")]
        public DateTime? AuditTime
        {
            get { return dateTime_5; }
            set
            {
                if (dateTime_5 != value)
                {
                    SendPropertyChanging();
                    dateTime_5 = value;
                    SendPropertyChanged("AuditTime");
                }
            }
        }

        //[Column(Storage = "_Banner", DbType = "NVarChar(250)")]
        public string Banner
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("Banner");
                }
            }
        }

        //[Column(Storage = "_BusinessLicense", DbType = "NVarChar(500) NOT NULL", CanBeNull = false)]
        public string BusinessLicense
        {
            get { return string_29; }
            set
            {
                if (string_29 != value)
                {
                    SendPropertyChanging();
                    string_29 = value;
                    SendPropertyChanged("BusinessLicense");
                }
            }
        }

        //[Column(Storage = "_BusinessScope", DbType = "NVarChar(200)")]
        public string BusinessScope
        {
            get { return string_28; }
            set
            {
                if (string_28 != value)
                {
                    SendPropertyChanging();
                    string_28 = value;
                    SendPropertyChanged("BusinessScope");
                }
            }
        }

        //[Column(Storage = "_BusinessTerm", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string BusinessTerm
        {
            get { return string_27; }
            set
            {
                if (string_27 != value)
                {
                    SendPropertyChanging();
                    string_27 = value;
                    SendPropertyChanged("BusinessTerm");
                }
            }
        }

        //[Column(Storage = "_CardImage", DbType = "NVarChar(50)")]
        public string CardImage
        {
            get { return string_20; }
            set
            {
                if (string_20 != value)
                {
                    SendPropertyChanging();
                    string_20 = value;
                    SendPropertyChanged("CardImage");
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

        //[Column(Storage = "_CompanAuditFailedReason", DbType = "NVarChar(800)")]
        public string CompanAuditFailedReason
        {
            get { return string_32; }
            set
            {
                if (string_32 != value)
                {
                    SendPropertyChanging();
                    string_32 = value;
                    SendPropertyChanged("CompanAuditFailedReason");
                }
            }
        }

        //[Column(Storage = "_CompanAuditTime", DbType = "DateTime")]
        public DateTime? CompanAuditTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("CompanAuditTime");
                }
            }
        }

        //[Column(Storage = "_CompanIsAudit", DbType = "Int NOT NULL")]
        public int CompanIsAudit
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("CompanIsAudit");
                }
            }
        }

        //[Column(Storage = "_CompanName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string CompanName
        {
            get { return string_25; }
            set
            {
                if (string_25 != value)
                {
                    SendPropertyChanging();
                    string_25 = value;
                    SendPropertyChanged("CompanName");
                }
            }
        }

        //[Column(Storage = "_CompanyIntroduce", DbType = "NVarChar(MAX)")]
        public string CompanyIntroduce
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("CompanyIntroduce");
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

        //[Column(Storage = "_EnsureID", DbType = "NVarChar(50)")]
        public string EnsureID
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    SendPropertyChanging();
                    string_15 = value;
                    SendPropertyChanged("EnsureID");
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

        //[Column(Storage = "_IdentityAuditTime", DbType = "DateTime")]
        public DateTime? IdentityAuditTime
        {
            get { return dateTime_4; }
            set
            {
                if (dateTime_4 != value)
                {
                    SendPropertyChanging();
                    dateTime_4 = value;
                    SendPropertyChanged("IdentityAuditTime");
                }
            }
        }

        //[Column(Storage = "_IdentityCard", DbType = "NVarChar(50)")]
        public string IdentityCard
        {
            get { return string_19; }
            set
            {
                if (string_19 != value)
                {
                    SendPropertyChanging();
                    string_19 = value;
                    SendPropertyChanged("IdentityCard");
                }
            }
        }

        //[Column(Storage = "_IdentityIsAudit", DbType = "Int NOT NULL")]
        public int IdentityIsAudit
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    SendPropertyChanging();
                    int_10 = value;
                    SendPropertyChanged("IdentityIsAudit");
                }
            }
        }

        //[Column(Storage = "_IsAudit", DbType = "TinyInt NOT NULL")]
        public byte IsAudit
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("IsAudit");
                }
            }
        }

        //[Column(Storage = "_IsClose", DbType = "Int")]
        public int? IsClose
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("IsClose");
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsExpires", DbType = "Int")]
        public int? IsExpires
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("IsExpires");
                }
            }
        }

        //[Column(Storage = "_IsHot", DbType = "TinyInt")]
        public byte? IsHot
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    SendPropertyChanging();
                    byte_1 = value;
                    SendPropertyChanged("IsHot");
                }
            }
        }

        //[Column(Storage = "_IsIntegralShop", DbType = "Int")]
        public int? IsIntegralShop
        {
            get { return int_11; }
            set
            {
                if (int_11 != value)
                {
                    SendPropertyChanging();
                    int_11 = value;
                    SendPropertyChanged("IsIntegralShop");
                }
            }
        }

        //[Column(Storage = "_IsPayMentShop", DbType = "Int NOT NULL")]
        public int IsPayMentShop
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("IsPayMentShop");
                }
            }
        }

        //[Column(Storage = "_IsRecommend", DbType = "TinyInt")]
        public byte? IsRecommend
        {
            get { return byte_3; }
            set
            {
                if (byte_3 != value)
                {
                    SendPropertyChanging();
                    byte_3 = value;
                    SendPropertyChanged("IsRecommend");
                }
            }
        }

        //[Column(Storage = "_IsVisits", DbType = "TinyInt")]
        public byte? IsVisits
        {
            get { return byte_2; }
            set
            {
                if (byte_2 != value)
                {
                    SendPropertyChanging();
                    byte_2 = value;
                    SendPropertyChanged("IsVisits");
                }
            }
        }

        //[Column(Storage = "_Latitude", DbType = "NVarChar(50)")]
        public string Latitude
        {
            get { return string_34; }
            set
            {
                if (string_34 != value)
                {
                    SendPropertyChanging();
                    string_34 = value;
                    SendPropertyChanged("Latitude");
                }
            }
        }

        //[Column(Storage = "_LegalPerson", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string LegalPerson
        {
            get { return string_26; }
            set
            {
                if (string_26 != value)
                {
                    SendPropertyChanging();
                    string_26 = value;
                    SendPropertyChanged("LegalPerson");
                }
            }
        }

        //[Column(Storage = "_Longitude", DbType = "NVarChar(50)")]
        public string Longitude
        {
            get { return string_33; }
            set
            {
                if (string_33 != value)
                {
                    SendPropertyChanging();
                    string_33 = value;
                    SendPropertyChanged("Longitude");
                }
            }
        }

        //[Column(Storage = "_MainGoods", DbType = "NVarChar(MAX)")]
        public string MainGoods
        {
            get { return string_22; }
            set
            {
                if (string_22 != value)
                {
                    SendPropertyChanging();
                    string_22 = value;
                    SendPropertyChanged("MainGoods");
                }
            }
        }

        //[Column(Storage = "_ManageBySite", DbType = "Int")]
        public int? ManageBySite
        {
            get { return int_13; }
            set
            {
                if (int_13 != value)
                {
                    SendPropertyChanging();
                    int_13 = value;
                    SendPropertyChanged("ManageBySite");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_Memo", DbType = "NVarChar(1000)")]
        public string Memo
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    SendPropertyChanging();
                    string_16 = value;
                    SendPropertyChanged("Memo");
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
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(50)")]
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

        //[Column(Storage = "_OpenTime", DbType = "DateTime")]
        public DateTime? OpenTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("OpenTime");
                }
            }
        }

        //[Column(Storage = "_OperateUser", DbType = "NVarChar(50)")]
        public string OperateUser
        {
            get { return string_36; }
            set
            {
                if (string_36 != value)
                {
                    SendPropertyChanging();
                    string_36 = value;
                    SendPropertyChanged("OperateUser");
                }
            }
        }

        //[Column(Storage = "_OrderID", DbType = "Int")]
        public int? OrderID
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("OrderID");
                }
            }
        }

        //[Column(Storage = "_Phone", DbType = "NVarChar(25)")]
        public string Phone
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("Phone");
                }
            }
        }

        //[Column(Storage = "_PostalCode", DbType = "NVarChar(50)")]
        public string PostalCode
        {
            get { return string_21; }
            set
            {
                if (string_21 != value)
                {
                    SendPropertyChanging();
                    string_21 = value;
                    SendPropertyChanged("PostalCode");
                }
            }
        }

        //[Column(Storage = "_RegisteredCapital", DbType = "Decimal(18,2) NOT NULL")]
        public decimal RegisteredCapital
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("RegisteredCapital");
                }
            }
        }

        //[Column(Storage = "_RegistrationNum", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string RegistrationNum
        {
            get { return string_24; }
            set
            {
                if (string_24 != value)
                {
                    SendPropertyChanging();
                    string_24 = value;
                    SendPropertyChanged("RegistrationNum");
                }
            }
        }

        //[Column(Storage = "_SalesRange", DbType = "NVarChar(150) NOT NULL", CanBeNull = false)]
        public string SalesRange
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("SalesRange");
                }
            }
        }

        //[Column(Storage = "_ShopBrandGuid", DbType = "NChar(50)")]
        public string ShopBrandGuid
        {
            get { return string_31; }
            set
            {
                if (string_31 != value)
                {
                    SendPropertyChanging();
                    string_31 = value;
                    SendPropertyChanged("ShopBrandGuid");
                }
            }
        }

        //[Column(Storage = "_ShopBrandName", DbType = "NChar(100)")]
        public string ShopBrandName
        {
            get { return string_30; }
            set
            {
                if (string_30 != value)
                {
                    SendPropertyChanging();
                    string_30 = value;
                    SendPropertyChanged("ShopBrandName");
                }
            }
        }

        //[Column(Storage = "_ShopCategory", DbType = "VarChar(50)")]
        public string ShopCategory
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("ShopCategory");
                }
            }
        }

        //[Column(Storage = "_ShopCategoryID", DbType = "NVarChar(50)")]
        public string ShopCategoryID
        {
            get { return string_17; }
            set
            {
                if (string_17 != value)
                {
                    SendPropertyChanging();
                    string_17 = value;
                    SendPropertyChanged("ShopCategoryID");
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "Int NOT NULL")]
        public int ShopID
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        //[Column(Storage = "_ShopIntroduce", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string ShopIntroduce
        {
            get { return string_23; }
            set
            {
                if (string_23 != value)
                {
                    SendPropertyChanging();
                    string_23 = value;
                    SendPropertyChanged("ShopIntroduce");
                }
            }
        }

        //[Column(Storage = "_ShopName", DbType = "NVarChar(50)")]
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

        //[Column(Storage = "_ShopRank", DbType = "UniqueIdentifier NOT NULL")]
        public Guid ShopRank
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("ShopRank");
                }
            }
        }

        //[Column(Storage = "_ShopReputation", DbType = "Int")]
        public int? ShopReputation
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("ShopReputation");
                }
            }
        }

        //[Column(Storage = "_ShopType", DbType = "Int")]
        public int? ShopType
        {
            get { return int_12; }
            set
            {
                if (int_12 != value)
                {
                    SendPropertyChanging();
                    int_12 = value;
                    SendPropertyChanged("ShopType");
                }
            }
        }

        //[Column(Storage = "_ShopUrl", DbType = "VarChar(50)")]
        public string ShopUrl
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ShopUrl");
                }
            }
        }

        //[Column(Storage = "_Tel", DbType = "NVarChar(25)")]
        public string Tel
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Tel");
                }
            }
        }

        //[Column(Storage = "_TemplateType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string TemplateType
        {
            get { return string_18; }
            set
            {
                if (string_18 != value)
                {
                    SendPropertyChanging();
                    string_18 = value;
                    SendPropertyChanged("TemplateType");
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