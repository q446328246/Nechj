using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_M_Member1 : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        private decimal score_dv;

        public decimal Score_dv
        {
            get { return score_dv; }
            set { score_dv = value; }
        }
        private decimal score_hv;

        public decimal Score_hv
        {
            get { return score_hv; }
            set { score_hv = value; }
        }
        private decimal advancePayment;

         public decimal AdvancePayment
        {
            get { return advancePayment; }
            set { advancePayment = value; }
        }
         private string  memLoginID;
         public string MemLoginID
         {
             get { return memLoginID; }
             set { memLoginID = value; }
         }
         private string name;
         public string Name
         {
             get { return name; }
             set { name = value; }
         }
         private string photo;
         public string Photo
         {
             get { return photo; }
             set { photo = value; }
         }
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
        public static ShopNum1_M_Member1 FromDataRow1(DataRow row)
        {
            ShopNum1_M_Member1 M_Member = new ShopNum1_M_Member1();
            M_Member.Score_dv = Convert.ToDecimal(row["Score_dv"]);
            M_Member.Score_hv = Convert.ToDecimal(row["Score_hv"]);
            M_Member.AdvancePayment = Convert.ToDecimal(row["AdvancePayment"]);
            M_Member.MemLoginID = row["MemLoginID"].ToString();
            M_Member.Name = row["Name"].ToString();
            M_Member.Photo = ShopSettings.siteDomain + Convert.ToString(row["Photo"]);
            return M_Member;
        }


    }
}
