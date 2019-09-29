using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;

namespace ShopNum1MultiEntity
{
    public class NEC_BiBi : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
        new PropertyChangingEventArgs(string.Empty);



        public virtual string Name { get; set; }
        public virtual string ZuiXinJia { get; set; }
        public virtual string ZFJ { get; set; }

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
        public static List<NEC_BiBi> FromData(DataTable table)
        {
            List<NEC_BiBi> Member = new List<NEC_BiBi>();
            foreach (DataRow row in table.Rows)
            {
                NEC_BiBi M_Member = new NEC_BiBi();

                M_Member.Name = row["Name"].ToString();
                M_Member.ZuiXinJia = row["ZuiXinJia"].ToString();
                M_Member.ZFJ = row["ZFJ"].ToString();
                
                Member.Add(M_Member);
            }
            return Member;
        }
    }
}
