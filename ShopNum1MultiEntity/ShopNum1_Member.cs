using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_Member")]
    public class ShopNum1_Member : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte byte_0;
        private byte? byte_1;
        private byte? byte_2;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private DateTime? dateTime_4;
        private DateTime? dateTime_5;
        private DateTime? dateTime_6;
        private DateTime? dateTime_7;
        private DateTime? dateTime_8;
        private DateTime? dateTime_9;
        private decimal? decimal_0;
        private decimal? decimal_1;
        private decimal? decimal_2;
        private decimal? decimal_3;
        private Guid guid_0;
        private Guid guid_1;
        private decimal int_0;
        private int? int_1;
        private int? int_10;
        private int? int_2;
        private int? int_3;
        private int? int_4;
        private int int_5;
        private int? int_6;
        private int? int_7;
        private int? int_8;
        private int? int_11;
        private int? int_9;

        private decimal score1;
        private decimal score2;
        private decimal score3;
        private decimal score4;
        private decimal score5;
        private decimal score6;

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
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;
        private string string_31;

        private string distributoId;
        private string sponsorId;
        private string sponsorName;
        private string placementId;
        private string placementName;
        private string shopNames;
        private int retailersStates;
        private int deeps;
        private int int_7MJ;
        private int id;
        private string recoCode;
        private string recoMember;
        private string eTHAddress;
        private string nECAddress;


        public string NECAddress
        {
            get { return nECAddress; }
            set
            {
                if (nECAddress != value)
                {
                    SendPropertyChanging();
                    nECAddress = value;
                    SendPropertyChanged("NECAddress");
                }
            }
        }


        public string ETHAddress
        {
            get { return eTHAddress; }
            set
            {
                if (eTHAddress != value)
                {
                    SendPropertyChanging();
                    eTHAddress = value;
                    SendPropertyChanged("ETHAddress");
                }
            }
        }
        public string RecoMember
        {
            get { return recoMember; }
            set
            {
                if (recoMember != value)
                {
                    SendPropertyChanging();
                    recoMember = value;
                    SendPropertyChanged("RecoMember");
                }
            }
        }


        public string RecoCode
        {
            get { return recoCode; }
            set
            {
                if (recoCode != value)
                {
                    SendPropertyChanging();
                    recoCode = value;
                    SendPropertyChanged("RecoCode");
                }
            }
        }

        public int ID
        {
            get { return id; }
            set
            {

                if (id != value)
                {
                    SendPropertyChanging();
                    id = value;
                    SendPropertyChanged("ID");
                }

            }
        }


        public int mobiletype
        {
            get { return int_7MJ; }
            set
            {
                if (int_7MJ != value)
                {
                    SendPropertyChanging();
                    int_7MJ = value;
                    SendPropertyChanged("mobiletype");
                }
            }
        }

        public int Deep
        {
            get { return deeps; }
            set
            {

                if (deeps != value)
                {
                    SendPropertyChanging();
                    deeps = value;
                    SendPropertyChanged("Deep");
                }

            }
        }
        public int RetailersStates
        {
            get { return retailersStates; }
            set
            {

                if (retailersStates != value)
                {
                    SendPropertyChanging();
                    retailersStates = value;
                    SendPropertyChanged("RetailersStates");
                }

            }
        }

        private string NBSuperior;
        private decimal SPScore_hv;

        public string ShopNames
        {
            get { return shopNames; }
            set
            {
                if (shopNames != value)
                {
                    SendPropertyChanging();
                    shopNames = value;
                    SendPropertyChanged("ShopNames");
                }
            }
        }

        public decimal Score_hv
        {
            get { return SPScore_hv; }
            set
            {
                if (SPScore_hv != value)
                {
                    SendPropertyChanging();
                    SPScore_hv = value;
                    SendPropertyChanged("Score_hv");
                }
            }
        }

        public string Superior
        {
            get { return NBSuperior; }
            set
            {
                if (NBSuperior != value)
                {
                    SendPropertyChanging();
                    NBSuperior = value;
                    SendPropertyChanged("Superior");
                }
            }
        }


        public string MemLoginNO
        {
            get { return string_31; }
            set
            {
                if (string_31 != value)
                {
                    SendPropertyChanging();
                    string_31 = value;
                    SendPropertyChanged("MemLoginNO");
                }
            }
        }



        //[Column(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
        {
            get { return string_18; }
            set
            {
                if (string_18 != value)
                {
                    SendPropertyChanging();
                    string_18 = value;
                    SendPropertyChanged("Address");
                }
            }
        }

        //[Column(Storage = "_AddressCode", DbType = "VarChar(9)")]
        public string AddressCode
        {
            get { return string_27; }
            set
            {
                if (string_27 != value)
                {
                    SendPropertyChanging();
                    string_27 = value;
                    SendPropertyChanged("AddressCode");
                }
            }
        }

        //[Column(Storage = "_AddressValue", DbType = "NVarChar(50)")]
        public string AddressValue
        {
            get { return string_28; }
            set
            {
                if (string_28 != value)
                {
                    SendPropertyChanging();
                    string_28 = value;
                    SendPropertyChanged("AddressValue");
                }
            }
        }

        //[Column(Storage = "_AdvancePayment", DbType = "Decimal(18,2)")]
        public decimal? AdvancePayment
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
                    SendPropertyChanged("AdvancePayment");
                }
            }
        }

        //[Column(Storage = "_AlipayNumber", DbType = "NVarChar(100)")]
        public string AlipayNumber
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("AlipayNumber");
                }
            }
        }

        //[Column(Storage = "_Answer", DbType = "NVarChar(50)")]
        public string Answer
        {
            get { return string_22; }
            set
            {
                if (string_22 != value)
                {
                    SendPropertyChanging();
                    string_22 = value;
                    SendPropertyChanged("Answer");
                }
            }
        }

        //[Column(Storage = "_Area", DbType = "NVarChar(50)")]
        public string Area
        {
            get { return string_20; }
            set
            {
                if (string_20 != value)
                {
                    SendPropertyChanging();
                    string_20 = value;
                    SendPropertyChanged("Area");
                }
            }
        }

        //[Column(Storage = "_AuditFailedReason", DbType = "NVarChar(500)")]
        public string AuditFailedReason
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("AuditFailedReason");
                }
            }
        }

        //[Column(Storage = "_Birthday", DbType = "DateTime")]
        public DateTime? Birthday
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("Birthday");
                }
            }
        }

        //[Column(Storage = "_CostMoney", DbType = "Decimal(18,2)")]
        public decimal? CostMoney
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
                    SendPropertyChanged("CostMoney");
                }
            }
        }

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
        {
            get { return dateTime_6; }
            set
            {
                if (dateTime_6 != value)
                {
                    SendPropertyChanging();
                    dateTime_6 = value;
                    SendPropertyChanged("CreateTime");
                }
            }
        }

        //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        //[Column(Storage = "_CreditMoney", DbType = "Decimal(18,2)")]
        public decimal? CreditMoney
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
                    SendPropertyChanged("CreditMoney");
                }
            }
        }

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Email");
                }
            }
        }

        //[Column(Storage = "_Fax", DbType = "NVarChar(20)")]
        public string Fax
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    SendPropertyChanging();
                    string_16 = value;
                    SendPropertyChanged("Fax");
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

        //[Column(Storage = "_IdentificationIsAudit", DbType = "Int")]
        public int? IdentificationIsAudit
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    SendPropertyChanging();
                    int_3 = value;
                    SendPropertyChanged("IdentificationIsAudit");
                }
            }
        }

        //[Column(Storage = "_IdentificationTime", DbType = "DateTime")]
        public DateTime? IdentificationTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("IdentificationTime");
                }
            }
        }

        //[Column(Storage = "_IdentityCard", DbType = "NVarChar(50)")]
        public string IdentityCard
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("IdentityCard");
                }
            }
        }

        //[Column(Storage = "_IdentityCardBackImg", DbType = "NVarChar(250)")]
        public string IdentityCardBackImg
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("IdentityCardBackImg");
                }
            }
        }

        //[Column(Storage = "_IdentityCardImg", DbType = "NVarChar(250)")]
        public string IdentityCardImg
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("IdentityCardImg");
                }
            }
        }

        //[Column(Storage = "_IsDeleted", DbType = "TinyInt NOT NULL")]
        public byte IsDeleted
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        //[Column(Storage = "_IsEmailActivation", CanBeNull = false)]
        public string IsEmailActivation
        {
            get { return string_30; }
            set
            {
                if (string_30 != value)
                {
                    SendPropertyChanging();
                    string_30 = value;
                    SendPropertyChanged("IsEmailActivation");
                }
            }
        }

        //[Column(Storage = "_IsForbid", DbType = "Int")]
        public int? IsForbid
        {
            get { return int_9; }
            set
            {
                if (int_9 != value)
                {
                    SendPropertyChanging();
                    int_9 = value;
                    SendPropertyChanged("IsForbid");
                }
            }
        }
        public int? IsMobileRegister
        {
            get { return int_11; }
            set
            {
                if (int_11 != value)
                {
                    SendPropertyChanging();
                    int_11 = value;
                    SendPropertyChanged("IsMobileRegister");
                }
            }
        }

        //[Column(Storage = "_IsMailActivation", DbType = "Int")]
        public int? IsMailActivation
        {
            get { return int_4; }
            set
            {
                if (int_4 != value)
                {
                    SendPropertyChanging();
                    int_4 = value;
                    SendPropertyChanged("IsMailActivation");
                }
            }
        }

        //[Column(Storage = "_IsMobileActivation", DbType = "Int NOT NULL")]
        public int IsMobileActivation
        {
            get { return int_5; }
            set
            {
                if (int_5 != value)
                {
                    SendPropertyChanging();
                    int_5 = value;
                    SendPropertyChanged("IsMobileActivation");
                }
            }
        }

        //[Column(Storage = "_LastLoginDate", DbType = "DateTime")]
        public DateTime? LastLoginDate
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("LastLoginDate");
                }
            }
        }

        //[Column(Storage = "_LastLoginIP", DbType = "NVarChar(25)")]
        public string LastLoginIP
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("LastLoginIP");
                }
            }
        }

        //[Column(Storage = "_LockAdvancePayment", DbType = "Decimal(18,2)")]
        public decimal? LockAdvancePayment
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
                    SendPropertyChanged("LockAdvancePayment");
                }
            }
        }

        //[Column(Storage = "_LockSocre", DbType = "Int")]
        public int? LockSocre
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("LockSocre");
                }
            }
        }

        //[Column(Storage = "_LoginDate", DbType = "DateTime")]
        public DateTime? LoginDate
        {
            get { return dateTime_5; }
            set
            {
                if (dateTime_5 != value)
                {
                    SendPropertyChanging();
                    dateTime_5 = value;
                    SendPropertyChanged("LoginDate");
                }
            }
        }

        //[Column(Storage = "_LoginTime", DbType = "Int")]
        public int? LoginTime
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("LoginTime");
                }
            }
        }

        //[Column(Storage = "_MActiveTime", DbType = "DateTime")]
        public DateTime? MActiveTime
        {
            get { return dateTime_9; }
            set
            {
                if (dateTime_9 != value)
                {
                    SendPropertyChanging();
                    dateTime_9 = value;
                    SendPropertyChanged("MActiveTime");
                }
            }
        }

        //[Column(Storage = "_MemberRank", DbType = "Int")]
        public int? MemberRank
        {
            get { return int_10; }
            set
            {
                if (int_10 != value)
                {
                    SendPropertyChanging();
                    int_10 = value;
                    SendPropertyChanged("MemberRank");
                }
            }
        }

        //[Column(Storage = "_MemberRankGuid")]
        public Guid MemberRankGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("MemberRankGuid");
                }
            }
        }

        //[Column(Storage = "_MemberType", DbType = "Int")]
        public int? MemberType
        {
            get { return int_8; }
            set
            {
                if (int_8 != value)
                {
                    SendPropertyChanging();
                    int_8 = value;
                    SendPropertyChanged("MemberType");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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
            get { return string_24; }
            set
            {
                if (string_24 != value)
                {
                    SendPropertyChanging();
                    string_24 = value;
                    SendPropertyChanged("Mobile");
                }
            }
        }

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return dateTime_7; }
            set
            {
                if (dateTime_7 != value)
                {
                    SendPropertyChanging();
                    dateTime_7 = value;
                    SendPropertyChanged("ModifyTime");
                }
            }
        }

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_29; }
            set
            {
                if (string_29 != value)
                {
                    SendPropertyChanging();
                    string_29 = value;
                    SendPropertyChanged("ModifyUser");
                }
            }
        }

        //[Column(Storage = "_Msn", DbType = "NVarChar(50)")]
        public string Msn
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("Msn");
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(20)")]
        public string Name
        {
            get { return string_25; }
            set
            {
                if (string_25 != value)
                {
                    SendPropertyChanging();
                    string_25 = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        //[Column(Storage = "_PayPwd", DbType = "NVarChar(250)")]
        public string PayPwd
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("PayPwd");
                }
            }
        }

        //[Column(Storage = "_Photo", DbType = "NVarChar(250)")]
        public string Photo
        {
            get { return string_21; }
            set
            {
                if (string_21 != value)
                {
                    SendPropertyChanging();
                    string_21 = value;
                    SendPropertyChanged("Photo");
                }
            }
        }

        //[Column(Storage = "_Postalcode", DbType = "NVarChar(20)")]
        public string Postalcode
        {
            get { return string_17; }
            set
            {
                if (string_17 != value)
                {
                    SendPropertyChanging();
                    string_17 = value;
                    SendPropertyChanged("Postalcode");
                }
            }
        }

        //[Column(Storage = "_PromotionMemLoginID", DbType = "NVarChar(50)")]
        public string PromotionMemLoginID
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("PromotionMemLoginID");
                }
            }
        }

        //[Column(Storage = "_Pwd", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string Pwd
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Pwd");
                }
            }
        }

        //[Column(Storage = "_QQ", DbType = "NVarChar(15)")]
        public string QQ
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    SendPropertyChanging();
                    string_15 = value;
                    SendPropertyChanged("QQ");
                }
            }
        }

        //[Column(Storage = "_Question", DbType = "NVarChar(50)")]
        public string Question
        {
            get { return string_23; }
            set
            {
                if (string_23 != value)
                {
                    SendPropertyChanging();
                    string_23 = value;
                    SendPropertyChanged("Question");
                }
            }
        }

        //[Column(Storage = "_RankScore", DbType = "Int")]
        public int? RankScore
        {
            get { return int_7; }
            set
            {
                if (int_7 != value)
                {
                    SendPropertyChanging();
                    int_7 = value;
                    SendPropertyChanged("RankScore");
                }
            }
        }



        //[Column(Storage = "_RealName", DbType = "NVarChar(50)")]
        public string RealName
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("RealName");
                }
            }
        }

        //[Column(Storage = "_RegDate", DbType = "DateTime")]
        public DateTime? RegDate
        {
            get { return dateTime_4; }
            set
            {
                if (dateTime_4 != value)
                {
                    SendPropertyChanging();
                    dateTime_4 = value;
                    SendPropertyChanged("RegDate");
                }
            }
        }

        //[Column(Storage = "_RegeDate", DbType = "DateTime")]
        public DateTime? RegeDate
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("RegeDate");
                }
            }
        }

        //[Column(Storage = "_Score", DbType = "Int NOT NULL")]
        public Decimal Score
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("Score");
                }
            }
        }

        public Decimal Score1
        {
            get { return score1; }
            set
            {
                if (score1 != value)
                {
                    SendPropertyChanging();
                    score1 = value;
                    SendPropertyChanged("Score1");
                }
            }
        }

        public Decimal Score2
        {
            get { return score2; }
            set
            {
                if (score2 != value)
                {
                    SendPropertyChanging();
                    score2 = value;
                    SendPropertyChanged("Score2");
                }
            }
        }

        public Decimal Score3
        {
            get { return score3; }
            set
            {
                if (score3 != value)
                {
                    SendPropertyChanging();
                    score3 = value;
                    SendPropertyChanged("Score3");
                }
            }
        }

        public Decimal Score4
        {
            get { return score4; }
            set
            {
                if (score4 != value)
                {
                    SendPropertyChanging();
                    score4 = value;
                    SendPropertyChanged("Score4");
                }
            }
        }

        public Decimal Score5
        {
            get { return score5; }
            set
            {
                if (score5 != value)
                {
                    SendPropertyChanging();
                    score5 = value;
                    SendPropertyChanged("Score5");
                }
            }
        }

        public Decimal Score6
        {
            get { return score6; }
            set
            {
                if (score6 != value)
                {
                    SendPropertyChanging();
                    score6 = value;
                    SendPropertyChanged("Score6");
                }
            }
        }

        //[Column(Storage = "_Sex", DbType = "TinyInt")]
        public byte? Sex
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    SendPropertyChanging();
                    byte_1 = value;
                    SendPropertyChanged("Sex");
                }
            }
        }

        //[Column(Storage = "_Status", DbType = "TinyInt")]
        public byte? Status
        {
            get { return byte_2; }
            set
            {
                if (byte_2 != value)
                {
                    SendPropertyChanging();
                    byte_2 = value;
                    SendPropertyChanged("Status");
                }
            }
        }

        //[Column(Storage = "_TActiveTime", DbType = "DateTime")]
        public DateTime? TActiveTime
        {
            get { return dateTime_8; }
            set
            {
                if (dateTime_8 != value)
                {
                    SendPropertyChanging();
                    dateTime_8 = value;
                    SendPropertyChanged("TActiveTime");
                }
            }
        }

        //[Column(Storage = "_Tel", DbType = "NVarChar(25)")]
        public string Tel
        {
            get { return string_26; }
            set
            {
                if (string_26 != value)
                {
                    SendPropertyChanging();
                    string_26 = value;
                    SendPropertyChanged("Tel");
                }
            }
        }

        //[Column(Storage = "_TradeCount", DbType = "Int")]
        public int? TradeCount
        {
            get { return int_6; }
            set
            {
                if (int_6 != value)
                {
                    SendPropertyChanging();
                    int_6 = value;
                    SendPropertyChanged("TradeCount");
                }
            }
        }

        //[Column(Storage = "_Vocation", DbType = "NVarChar(100)")]
        public string Vocation
        {
            get { return string_19; }
            set
            {
                if (string_19 != value)
                {
                    SendPropertyChanging();
                    string_19 = value;
                    SendPropertyChanged("Vocation");
                }
            }
        }

        //[Column(Storage = "_WebSite", DbType = "NVarChar(250)")]
        public string WebSite
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("WebSite");
                }
            }
        }

        public string DistributorId
        {
            get { return distributoId; }
            set
            {
                if (distributoId != value)
                {
                    SendPropertyChanging();
                    distributoId = value;
                    SendPropertyChanged("DistributorId");
                }
            }
        }

        public string SponsorId
        {
            get { return sponsorId; }
            set
            {
                if (sponsorId != value)
                {
                    SendPropertyChanging();
                    sponsorId = value;
                    SendPropertyChanged("SponsorId");
                }
            }
        }

        public string SponsorName
        {
            get { return sponsorName; }
            set
            {
                if (sponsorName != value)
                {
                    SendPropertyChanging();
                    sponsorName = value;
                    SendPropertyChanged("SponsorName");
                }
            }
        }

        public string PlacementId
        {
            get { return placementId; }
            set
            {
                if (placementId != value)
                {
                    SendPropertyChanging();
                    placementId = value;
                    SendPropertyChanged("PlacementId");
                }
            }
        }

        public string PlacementName
        {
            get { return placementName; }
            set
            {
                if (placementName != value)
                {
                    SendPropertyChanging();
                    placementName = value;
                    SendPropertyChanged("PlacementName");
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