using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class KCEBonus3 : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        public virtual string  MemLoginID { get; set; }
        public virtual string Allnum { get; set; }
        public virtual string CreateTime { get; set; }


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
        public static List<KCEBonus3> FromDataRow1(DataTable table)
        {
            List<KCEBonus3> Member = new List<KCEBonus3>();
            foreach (DataRow row in table.Rows)
            {
                KCEBonus3 M_Member = new KCEBonus3();
                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.Allnum = row["Allnum"].ToString();
                M_Member.CreateTime = row["CreateTime"].ToString();
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
