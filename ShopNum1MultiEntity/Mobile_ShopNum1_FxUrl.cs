using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class Mobile_ShopNum1_FxUrl : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public virtual string FxUrl__share_title { get; set; }
        public virtual string FxUrl__share_url { get; set; }
        public virtual string FxUrl__share_icon { get; set; }
        public virtual string FxUrl__share_description { get; set; }



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
