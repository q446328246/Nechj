using System;
using System.ComponentModel;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_Order_Refuse : INotifyPropertyChanging, INotifyPropertyChanged
	{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_14;
        private string string_15;
        private string string_16;

        public string AdminID
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    SendPropertyChanging();
                    string_16 = value;
                    SendPropertyChanged("AdminID");
                }
            }
        }

        public string Status
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    SendPropertyChanging();
                    string_15 = value;
                    SendPropertyChanged("Status");
                }
            }
        }
        public string EndTime
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("EndTime");
                }
            }
        }
        public string Remark
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("Remark");
                }
            }
        }
        public string MemberloginID
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("MemberloginID");
                }
            }
        }

        public string OrderID
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("OrderID");
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
