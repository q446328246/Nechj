using System;
using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.BoutiqueEnroll")]
    public class BoutiqueEnroll : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private DateTime? dateTime_0;
        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        ////[Column(Storage = "_Address", DbType = "NVarChar(500)")]
        public string Address
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Address");
                }
            }
        }

        // //[Column(Storage = "_CheckedName", DbType = "NVarChar(500)")]
        public string CheckedName
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("CheckedName");
                }
            }
        }

        ////[Column(Storage = "_EnrollTime", DbType = "DateTime")]
        public DateTime? EnrollTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("EnrollTime");
                }
            }
        }

        ////[Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //    //IsDbGenerated = true)]
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

        // //[Column(Storage = "_Name", DbType = "NVarChar(50)")]
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

        ////[Column(Storage = "_Remarks", DbType = "NVarChar(500)")]
        public string Remarks
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Remarks");
                }
            }
        }

        // //[Column(Storage = "_Tel", DbType = "NVarChar(50)")]
        public string Tel
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Tel");
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