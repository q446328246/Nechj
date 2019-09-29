using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class EarningsDetails : INotifyPropertyChanging, INotifyPropertyChanged
    { 
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        public virtual string CreateTime { get; set; }

        public virtual decimal EveryDayAllEarnings { get; set; }

        public virtual decimal hashrateEarnings { get; set; }
        public virtual decimal linkEarnings { get; set; }
        public virtual decimal signinEarnings { get; set; }
        public virtual decimal presenterEarnings { get; set; }

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
        public static List<EarningsDetails> FromDataRow1(DataTable table )
        {
            List<EarningsDetails> Member = new List<EarningsDetails>();
            foreach (DataRow row in table.Rows)
            {
                EarningsDetails M_Member = new EarningsDetails();
 
                M_Member.CreateTime = row["CreateTime"].ToString();

                //hashrateEarnings 算力收益1 linkEarnings链接收益2 signinEarnings签到收益3 presenterEarnings赠送收益4  EveryDayAllEarnings 总额
                M_Member.hashrateEarnings = Convert.ToDecimal(row["hashrateEarnings"].ToString());
                M_Member.linkEarnings = Convert.ToDecimal(row["linkEarnings"].ToString());
                M_Member.signinEarnings = Convert.ToDecimal(row["signinEarnings"].ToString());
                M_Member.presenterEarnings = Convert.ToDecimal(row["presenterEarnings"].ToString());

                M_Member.EveryDayAllEarnings = Convert.ToDecimal(row["EveryDayAllEarnings"]);
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
