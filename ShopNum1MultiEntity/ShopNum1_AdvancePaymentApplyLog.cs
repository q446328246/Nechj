using System;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_AdvancePaymentApplyLog")]
    public class ShopNum1_AdvancePaymentApplyLog
    {
        private DateTime dateTime_0;
        private decimal decimal_0;
        private decimal decimal_1;
        private Guid guid_0;
        private Guid? guid_1;
        private int int_0;
        private int int_1;
        private int? int_2;
        private int? int_3;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string txtBankCard;
        private string txtGetBamkCard;
        private string txtUserName;


        public string BankCard
        {
            get { return txtBankCard; }
            set
            {
                if (txtBankCard != value)
                {
                    txtBankCard = value;
                }
            }
        }

        public string GetBamkCard
        {
            get { return txtGetBamkCard; }
            set
            {
                if (txtGetBamkCard != value)
                {
                    txtGetBamkCard = value;
                }
            }
        }

        public string UserName
        {
            get { return txtUserName; }
            set
            {
                if (txtUserName != value)
                {
                    txtUserName = value;
                }
            }
        }




        //  //[Column(Storage = "_Account", DbType = "NVarChar(50)")]
        public string Account
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    string_7 = value;
                }
            }
        }

        // //[Column(Storage = "_Bank", DbType = "NVarChar(50)")]
        public string Bank
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    string_5 = value;
                }
            }
        }

        // //[Column(Storage = "_CurrentAdvancePayment", DbType = "Decimal(18,2) NOT NULL")]
        public decimal CurrentAdvancePayment
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    decimal_0 = value;
                }
            }
        }

        // //[Column(Storage = "_Date", DbType = "DateTime NOT NULL")]
        public DateTime Date
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    dateTime_0 = value;
                }
            }
        }

        // //[Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL")]
        public Guid Guid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    guid_0 = value;
                }
            }
        }

        // //[Column(Storage = "_ID", DbType = "Int")]
        public int? ID
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    int_2 = value;
                }
            }
        }

        // //[Column(Storage = "_IsDeleted", DbType = "Int NOT NULL")]
        public int IsDeleted
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    int_1 = value;
                }
            }
        }

        //  //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    string_3 = value;
                }
            }
        }

        //  //[Column(Storage = "_Memo", DbType = "NVarChar(4000)")]
        public string Memo
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    string_1 = value;
                }
            }
        }

        //  //[Column(Storage = "_OperateMoney", DbType = "Decimal(18,2) NOT NULL")]
        public decimal OperateMoney
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    decimal_1 = value;
                }
            }
        }

        // //[Column(Storage = "_OperateStatus", DbType = "Int NOT NULL")]
        public int OperateStatus
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    int_0 = value;
                }
            }
        }

        // //[Column(Storage = "_OperateType", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string OperateType
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    string_0 = value;
                }
            }
        }

        //  //[Column(Storage = "_OrderNumber", CanBeNull = false)]
        public string OrderNumber
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    string_8 = value;
                }
            }
        }

        // //[Column(Storage = "_OrderStatus", DbType = "Int")]
        public int? OrderStatus
        {
            get { return int_3; }
            set
            {
                if (int_3 != value)
                {
                    int_3 = value;
                }
            }
        }

        ////[Column(Storage = "_PaymentGuid", DbType = "UniqueIdentifier")]
        public Guid? PaymentGuid
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    guid_1 = value;
                }
            }
        }

        //  //[Column(Storage = "_PaymentName", DbType = "NVarChar(50)")]
        public string PaymentName
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    string_4 = value;
                }
            }
        }

        //   //[Column(Storage = "_TrueName", DbType = "NVarChar(50)")]
        public string TrueName
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    string_6 = value;
                }
            }
        }

        //   //[Column(Storage = "_UserMemo", DbType = "NVarChar(4000)")]
        public string UserMemo
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    string_2 = value;
                }
            }
        }
    }
}