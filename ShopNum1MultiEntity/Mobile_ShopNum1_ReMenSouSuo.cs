using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class Mobile_ShopNum1_ReMenSouSuo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public virtual string MobileService_ReMenSouSuo__Id { get; set; }
        public virtual string MobileService_ReMenSouSuo__SelectName { get; set; }
        public virtual string MobileService_ReMenSouSuo__Shop_Category_ID { get; set; }




        #region 封装
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

        #endregion
    }
}
