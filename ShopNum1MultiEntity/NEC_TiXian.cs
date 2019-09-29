using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;

namespace ShopNum1MultiEntity
{

    public class NEC_TiXian : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
        new PropertyChangingEventArgs(string.Empty);



        public virtual string MemLoginID { get; set; }
        public virtual string MoneyNumber { get; set; }
        public virtual string Status { get; set; }
        public virtual string TxTime { get; set; }
        public virtual string ETHAddress { get; set; }

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
        public static List<NEC_TiXian> FromDataRow1(DataTable table)
        {
            List<NEC_TiXian> Member = new List<NEC_TiXian>();
            foreach (DataRow row in table.Rows)
            {
                NEC_TiXian M_Member = new NEC_TiXian();
 
                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.MoneyNumber = row["MoneyNumber"].ToString();
                M_Member.Status = row["Status"].ToString();
                M_Member.TxTime = row["TxTime"].ToString();
                M_Member.ETHAddress = row["ETHAddress"].ToString();
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
