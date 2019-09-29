 
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_NECSevenDetailWeek : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);



        public virtual string Createtime { get; set; }


        public virtual string Bonus { get; set; }


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
        public static List<ShopNum1_NECSevenDetailWeek> FromDataRow1(DataTable table)
        {
            List<ShopNum1_NECSevenDetailWeek> Member = new List<ShopNum1_NECSevenDetailWeek>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_NECSevenDetailWeek M_Member = new ShopNum1_NECSevenDetailWeek();
                M_Member.Createtime = row["Createtime"].ToString();
                M_Member.Bonus = row["Bonus"].ToString();
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}

