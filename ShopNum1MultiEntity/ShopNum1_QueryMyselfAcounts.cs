using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class QueryMyselfAc : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        private decimal score_dv;

        public decimal Score_dv
        {
            get { return score_dv; }
            set { score_dv = value; }
        }
        private decimal score_hv;

        public decimal Score_hv
        {
            get { return score_hv; }
            set { score_hv = value; }
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
        public static QueryMyselfAc FromDataRow1(DataRow row)
        {
            QueryMyselfAc M_Member = new QueryMyselfAc();
            M_Member.Score_dv = Convert.ToDecimal(row["Score_dv"]);
            M_Member.Score_hv = Convert.ToDecimal(row["Score_hv"]);
            return M_Member;
        }


    }
}
