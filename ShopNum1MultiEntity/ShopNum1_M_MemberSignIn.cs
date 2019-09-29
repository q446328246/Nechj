using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_M_MemberSignIn : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        private decimal bonus;

        public decimal Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }
        private string memLoginID;
        public string MemLoginID
        {
            get { return memLoginID; }
            set { memLoginID = value; }
        }
        private string memo;
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        private string signInCreate;
        public string SignInCreate
        {
            get { return signInCreate; }
            set { signInCreate = value; }
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
        public static List<ShopNum1_M_MemberSignIn> FromDataRow1(DataTable table)
        {
            List<ShopNum1_M_MemberSignIn> Member = new List<ShopNum1_M_MemberSignIn>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_M_MemberSignIn M_Member = new ShopNum1_M_MemberSignIn();

                M_Member.Bonus = Convert.ToDecimal(row["Bonus"]);
                M_Member.MemLoginID = row["MemLoginID"].ToString();
                M_Member.Memo = row["memo"].ToString();
                M_Member.SignInCreate = row["SignInCreate"].ToString();
                 
                Member.Add(M_Member);
            }
            return Member;


        }
    }
}
