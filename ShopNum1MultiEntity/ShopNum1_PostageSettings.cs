using System;
using System.ComponentModel;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_PostageSettings : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private string string_0;
        private decimal score1;
        private decimal score2;
        private decimal score3;


        public Decimal FirstHeavyPrice
        {
            get { return score1; }
            set
            {
                if (score1 != value)
                {
                    SendPropertyChanging();
                    score1 = value;
                    SendPropertyChanged("FirstHeavyPrice");
                }
            }
        }
        public Decimal AfterHeavyPrice
        {
            get { return score2; }
            set
            {
                if (score2 != value)
                {
                    SendPropertyChanging();
                    score2 = value;
                    SendPropertyChanged("AfterHeavyPrice");
                }
            }
        }
        public Decimal FirstHeavy
        {
            get { return score3; }
            set
            {
                if (score3 != value)
                {
                    SendPropertyChanging();
                    score3 = value;
                    SendPropertyChanged("FirstHeavy");
                }
            }
        }

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
