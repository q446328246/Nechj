using System;
using System.ComponentModel;

namespace ShopNum1MultiEntity
{
    public class PostPrice : INotifyPropertyChanging, INotifyPropertyChanged
	{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private decimal decimal_1;
        private decimal decimal_2;
        private decimal decimal_3;

        public decimal FirstHeavyPrice
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    SendPropertyChanging();
                    decimal_1 = value;
                    SendPropertyChanged("FirstHeavyPrice");
                }
            }
        }



        public decimal AfterHeavyPrice
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    SendPropertyChanging();
                    decimal_2 = value;
                    SendPropertyChanged("AfterHeavyPrice");
                }
            }
        }


        public decimal FirstHeavy
        {
            get { return decimal_3; }
            set
            {
                if (decimal_3 != value)
                {
                    SendPropertyChanging();
                    decimal_3 = value;
                    SendPropertyChanged("FirstHeavy");
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
