using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_Earnings : INotifyPropertyChanging, INotifyPropertyChanged
    { 
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        private string SingleAllEarnings;

        public string singleAllEarnings
        {
            get { return SingleAllEarnings; }
            set { SingleAllEarnings = value; }
        }
        private string NewestSingleEarnings;

        public string newestSingleEarnings
        {
            get { return NewestSingleEarnings; }
            set { NewestSingleEarnings = value; }
        }
        private string CreateTime;

        public string createTime
        {
            get { return CreateTime; }
            set { CreateTime = value; }
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

        public static ShopNum1_Earnings FromDataRow1(List<string> aist)
        {
            ShopNum1_Earnings M_Member = new ShopNum1_Earnings();
            for (int i = 0; i < aist.Count; i++)
			{
                M_Member.singleAllEarnings = aist[0];
                M_Member.newestSingleEarnings = aist[1];
                M_Member.createTime = aist[2];

            }
            

            return M_Member;
        }

    }
}
