using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class AcountA_B_C : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);
          

        private decimal a;

        public decimal Static
        {
            get { return a; }
            set { a = value; }
        }
        private decimal b;

        public decimal Trends
        {
            get { return b; }
            set { b = value; }
        }
        private decimal c;

        public decimal ExchangeAmount
        {
            get { return c; }
            set { c = value; }
        }
        private decimal d;
        public decimal Allnum
        {
            get { return d; }
            set { d = value; }
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

        public static AcountA_B_C FromDataRow1(List<decimal> aist)
        {
            AcountA_B_C M_Member = new AcountA_B_C();
            for (int i = 0; i < aist.Count; i++)
			{
                M_Member.Static = aist[0];
                M_Member.Trends = aist[1];
                M_Member.ExchangeAmount = aist[2];
                M_Member.Allnum = aist[3];
            }
            

            return M_Member;
        }

    }
}
