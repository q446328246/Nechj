using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class KCENotice : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);



        public virtual string  Guid { get; set; }


        public virtual string Title { get; set; }
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
        public static List<KCENotice> FromDataRow1(DataTable table)
        {
            List<KCENotice> Member = new List<KCENotice>();
            foreach (DataRow row in table.Rows)
            {
                KCENotice M_Member = new KCENotice();
                M_Member.Guid = row["Guid"].ToString();
                M_Member.Title = row["Title"].ToString();
                M_Member.CreateTime = row["CreateTime"].ToString();
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
