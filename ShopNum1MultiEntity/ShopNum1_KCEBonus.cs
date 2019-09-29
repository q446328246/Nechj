using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class KCEBonus : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        public virtual string  MemLoginID { get; set; }
        public virtual string  Bonus1 { get; set; }
        public virtual string  Bonus2 { get; set; }
        public virtual string Membership_Level { get; set; }

        public virtual string BonusAll { get; set; }
        public virtual string CreateTime { get; set; }
        public virtual string standardfactor { get; set; }
        public virtual string isdelete { get; set; }
        

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
        public static List<KCEBonus> FromDataRow1(DataTable table)
        {
            List<KCEBonus> Member = new List<KCEBonus>();
            foreach (DataRow row in table.Rows)
            {
                KCEBonus M_Member = new KCEBonus();
                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.Bonus1 = row["Bonus1"].ToString();
                M_Member.Bonus2 = row["Bonus2"].ToString();
                M_Member.Membership_Level = row["Membership_Level"].ToString();
                M_Member.BonusAll = row["BonusAll"].ToString();
                M_Member.CreateTime = row["CreateTime"].ToString();
                M_Member.standardfactor = row["standardfactor"].ToString();
                M_Member.isdelete = row["isdelete"].ToString();
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
