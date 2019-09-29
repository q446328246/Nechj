using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;


namespace ShopNum1MultiEntity
{
    public class Mobile_ShopNum1_SelectOrderStatusNum : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);

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

        public virtual string OrderStatus0 { get; set; }
        public virtual string OrderStatus1 { get; set; }
        public virtual string OrderStatus2 { get; set; }


    }
}
