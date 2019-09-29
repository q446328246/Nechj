using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;

namespace ShopNum1MultiEntity


{
    public class NEC_ChongZhiJiLu : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);



        public virtual string MemLoginID { get; set; }
        public virtual string Texthash { get; set; }
        public virtual string Toaddr { get; set; }
        public virtual string Fromaddr { get; set; }
        public virtual string Addtime { get; set; }
        public virtual string Counts { get; set; }
        public virtual string Status { get; set; }

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
        public static List<NEC_ChongZhiJiLu> FromData(DataTable table)
        {
            List<NEC_ChongZhiJiLu> Member = new List<NEC_ChongZhiJiLu>();
            foreach (DataRow row in table.Rows)
            {
                NEC_ChongZhiJiLu M_Member = new NEC_ChongZhiJiLu();

                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.Texthash = row["Texthash"].ToString();
                M_Member.Toaddr = row["Toaddr"].ToString();
                M_Member.Fromaddr = row["Fromaddr"].ToString();
                M_Member.Addtime = row["Time"].ToString();
                M_Member.Counts = row["Counts"].ToString();
                M_Member.Status = row["Status"].ToString();

                Member.Add(M_Member);
            }
            return Member;
        }
    }
}