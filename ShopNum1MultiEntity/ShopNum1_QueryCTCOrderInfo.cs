using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class QueryCTCO : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        public virtual string Guid { get; set; }
        public virtual string MemLoginID { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string OderStatus { get; set; }
        public virtual string ShipmentStatus { get; set; } 

        public virtual string ShouldPayPrice { get; set; }
        public virtual string CreateTime { get; set; }
        public virtual string ConfirmTime { get; set; }
        public virtual string PayTime { get; set; }
        public virtual string Score_pv_b { get; set; } 


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

        public static List<QueryCTCO> FromDataRow1(DataTable table)
        {
            List<QueryCTCO> Member = new List<QueryCTCO>();
            foreach (DataRow row in table.Rows)
            {
                QueryCTCO M_Member = new QueryCTCO();
                M_Member.Guid = row["Guid"].ToString();
                M_Member.MemLoginID = (row["MemLoginID"]).ToString();
                M_Member.OrderNumber = (row["OrderNumber"]).ToString();
                M_Member.OderStatus = row["OderStatus"].ToString();
                M_Member.ShipmentStatus = row["ShipmentStatus"].ToString();
                M_Member.ShouldPayPrice = (row["ShouldPayPrice"]).ToString();
                M_Member.CreateTime = row["CreateTime"].ToString();
                M_Member.ConfirmTime = row["ConfirmTime"].ToString();
                M_Member.PayTime = row["PayTime"].ToString();
                M_Member.Score_pv_b = row["Score_pv_b"].ToString();
                Member.Add(M_Member);
            }

            return Member;

        }
    }
}
