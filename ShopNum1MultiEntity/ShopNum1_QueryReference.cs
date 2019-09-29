using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;

namespace ShopNum1MultiEntity
{

    public class QueryReference : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        public virtual string PersonCate { get; set; }
        public virtual string  MemLoginID { get; set; }
        public virtual string IdentityCard { get; set; }
        public virtual string RealName { get; set; }
        public virtual string  Mobile { get; set; }
        public virtual string Superior { get; set; }
        public virtual string Name { get; set; }
        
        public virtual string RegeDate { get; set; }
        public virtual string YesterdayAllBonus { get; set; }
        public virtual string Photo { get; set; }
        public virtual string Membership_Level { get; set; }
 


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
        public static List<QueryReference> FromDataRow1(DataTable table)
        {
            List<QueryReference> Member = new List<QueryReference>();
            foreach (DataRow row in table.Rows)
            {
                QueryReference M_Member = new QueryReference();
                 
                
                M_Member.YesterdayAllBonus = String.Format("{0:N2}", row["YesterdayAllBonus"].ToString());
                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.PersonCate = row["PersonCate"].ToString();
                M_Member.RealName = row["RealName"].ToString();
                M_Member.Mobile = row["Mobile"].ToString();
                M_Member.RegeDate = row["RegeDate"].ToString();
                if (row["Photo"].ToString() == null || row["Photo"].ToString() == "")
                {
                    M_Member.Photo = "";
                }
                else
                {
                    M_Member.Photo = ShopSettings.siteDomain + Convert.ToString(row["Photo"]);
                }
                
    
                M_Member.Membership_Level = row["Membership_Level"].ToString();
                M_Member.Name = row["Name"].ToString();
                M_Member.IdentityCard = row["IdentityCard"].ToString();
                M_Member.Superior = row["Superior"].ToString();
                Member.Add(M_Member);
            }
            return Member;
        }

    }
}
