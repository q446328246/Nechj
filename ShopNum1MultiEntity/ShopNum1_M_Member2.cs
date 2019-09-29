using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_M_Member2 : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);



        public virtual string OperateMoney { get; set; }
        public virtual string Date { get; set; }
        public virtual string Memo { get; set; } 
        public virtual string MemLoginID { get; set; } 
        public virtual string RMemberID { get; set; } 

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
        public static List<ShopNum1_M_Member2> FromDataRow1(DataTable table)
        {



            List<ShopNum1_M_Member2> Member = new List<ShopNum1_M_Member2>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_M_Member2 M_Member = new ShopNum1_M_Member2();
                M_Member.OperateMoney =row["OperateMoney"].ToString();
                M_Member.Date = (row["Date"]).ToString();
                M_Member.Memo = (row["Memo"]).ToString();
                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.RMemberID = row["RMemberID"].ToString();
                Member.Add(M_Member);
            }
            
            return Member;
        }


    }
}
