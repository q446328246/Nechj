using System;
using System.ComponentModel;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MemberReport")]
    public class ShopNum1_MemberReport : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private int int_0;
        private int? int_1;
        private int int_2;

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

        //[Column(Storage = "_ComplaintContent", DbType = "NVarChar(MAX)")]
        public string ComplaintContent
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("ComplaintContent");
                }
            }
        }

        //[Column(Storage = "_ComplaintImage", DbType = "NVarChar(200)")]
        public string ComplaintImage
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("ComplaintImage");
                }
            }
        }

        //[Column(Storage = "_ComplaintTime", DbType = "DateTime")]
        public DateTime? ComplaintTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("ComplaintTime");
                }
            }
        }

        //[Column(Storage = "_CustomerMessage", DbType = "NVarChar(MAX)")]
        public string CustomerMessage
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("CustomerMessage");
                }
            }
        }

        //[Column(Storage = "_Evidence", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false)]
        public string Evidence
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Evidence");
                }
            }
        }

        //[Column(Storage = "_EvidenceImage", DbType = "NVarChar(250)")]
        public string EvidenceImage
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("EvidenceImage");
                }
            }
        }

        //[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //IsDbGenerated = true)]
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

        //[Column(Storage = "_IsComplaint", DbType = "Int NOT NULL")]
        public int IsComplaint
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("IsComplaint");
                }
            }
        }

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //[Column(Storage = "_OperateUser", DbType = "NVarChar(50)")]
        public string OperateUser
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("OperateUser");
                }
            }
        }

        //[Column(Storage = "_ProcessingResults", DbType = "NVarChar(1000)")]
        public string ProcessingResults
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("ProcessingResults");
                }
            }
        }

        //[Column(Storage = "_ProcessingStatus", DbType = "Int")]
        public int? ProcessingStatus
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("ProcessingStatus");
                }
            }
        }

        //[Column(Storage = "_ProcessingTime", DbType = "DateTime")]
        public DateTime? ProcessingTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("ProcessingTime");
                }
            }
        }

        //[Column(Storage = "_ProductUrl", DbType = "NVarChar(250)")]
        public string ProductUrl
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("ProductUrl");
                }
            }
        }

        //[Column(Storage = "_ReportShop", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ReportShop
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("ReportShop");
                }
            }
        }

        //[Column(Storage = "_ReportTime", DbType = "DateTime")]
        public DateTime? ReportTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("ReportTime");
                }
            }
        }

        //[Column(Storage = "_ReportType", DbType = "NVarChar(50)")]
        public string ReportType
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("ReportType");
                }
            }
        }

        //[Column(Storage = "_ShopProductID", DbType = "NVarChar(250)")]
        public string ShopProductID
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ShopProductID");
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