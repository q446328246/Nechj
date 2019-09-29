﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_EarningsDetailsNews2 : INotifyPropertyChanging, INotifyPropertyChanged
    { 
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        public virtual string CreateTime { get; set; }

        public virtual string MemLoginID { get; set; }

        public virtual string Bonus2 { get; set; }
        public virtual string Bonus3 { get; set; }
        public virtual string fenxiang { get; set; }
        public virtual string lianjie { get; set; }


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
        public static List<ShopNum1_EarningsDetailsNews2> FromDataRow1(DataTable table)
        {
            List<ShopNum1_EarningsDetailsNews2> Member = new List<ShopNum1_EarningsDetailsNews2>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_EarningsDetailsNews2 M_Member = new ShopNum1_EarningsDetailsNews2();
 
                M_Member.CreateTime = row["CreateTime"].ToString();

                //hashrateEarnings 算力收益1 linkEarnings链接收益2 signinEarnings签到收益3 presenterEarnings赠送收益4  EveryDayAllEarnings 总额
                M_Member.MemLoginID =  row["MemLoginID"].ToString();
                M_Member.Bonus2 = row["Bonus2"].ToString();
                M_Member.Bonus3 =  row["Bonus3"].ToString();
                M_Member.fenxiang = row["fenxiang"].ToString();
                M_Member.lianjie =row["lianjie"].ToString();

                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
