using System;
using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_ZtcApply")]
    public class ShopNum1_ZtcApply : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte? byte_0;
        private byte? byte_1;
        private byte? byte_2;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private decimal? decimal_0;
        private Guid? guid_0;
        private int int_0;
        private int? int_1;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;

        ////[Column(Storage = "_ApplyTime", DbType = "DateTime")]
        public DateTime? ApplyTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("ApplyTime");
                }
            }
        }

        // //[Column(Storage = "_AuditState", DbType = "TinyInt")]
        public byte? AuditState
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    SendPropertyChanging();
                    byte_1 = value;
                    SendPropertyChanged("AuditState");
                }
            }
        }

        // //[Column(Storage = "_AuditTime", DbType = "DateTime")]
        public DateTime? AuditTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("AuditTime");
                }
            }
        }

        //  //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("CreateTime");
                }
            }
        }

        // //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("CreateUser");
                }
            }
        }

        //  //[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //     //IsDbGenerated = true)]
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

        // //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("IsDeleted");
                }
            }
        }

        // //[Column(Storage = "_MemberID", DbType = "NVarChar(50)")]
        public string MemberID
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("MemberID");
                }
            }
        }

        // //[Column(Storage = "_OperateRemark", DbType = "NVarChar(400)")]
        public string OperateRemark
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("OperateRemark");
                }
            }
        }

        //  //[Column(Storage = "_OperateUser", DbType = "NVarChar(50)")]
        public string OperateUser
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("OperateUser");
                }
            }
        }

        ////[Column(Storage = "_PayState", DbType = "TinyInt")]
        public byte? PayState
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("PayState");
                }
            }
        }

        ////[Column(Storage = "_ProductGuid", DbType = "UniqueIdentifier")]
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

        // //[Column(Storage = "_ProductName", DbType = "NVarChar(100)")]
        public string ProductName
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("ProductName");
                }
            }
        }

        ////[Column(Storage = "_Remark", DbType = "NVarChar(400)")]
        public string Remark
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Remark");
                }
            }
        }

        ////[Column(Storage = "_ShopID", DbType = "VarChar(50)")]
        public string ShopID
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ShopID");
                }
            }
        }

        // //[Column(Storage = "_ShopName", DbType = "NVarChar(100)")]
        public string ShopName
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
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

        // //[Column(Storage = "_Type", DbType = "TinyInt")]
        public byte? Type
        {
            get { return byte_2; }
            set
            {
                if (byte_2 != value)
                {
                    SendPropertyChanging();
                    byte_2 = value;
                    SendPropertyChanged("Type");
                }
            }
        }

        //  //[Column(Storage = "_Ztc_Money", DbType = "Decimal(18,2)")]
        public decimal? Ztc_Money
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
                    SendPropertyChanged("Ztc_Money");
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