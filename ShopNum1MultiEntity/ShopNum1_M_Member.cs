using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class ShopNum1_M_Member : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        //private string rankName;

        //public string RankName
        //{
        //    get { return rankName; }
        //    set { rankName = value; }
        //}

        //private string papwd;

        //public string PayPwd
        //{
        //    get { return papwd; }
        //    set { papwd = value; }
        //}

        //private Guid guid;

        //public Guid Guid
        //{
        //    get { return guid; }
        //    set { guid = value; }
        //}
        private string memLoginID;

        public string MemLoginID
        {
            get { return memLoginID; }
            set { memLoginID = value; }
        }
        private string identityCard;

        public string IdentityCard
        {
            get { return identityCard; }
            set { identityCard = value; }
        }
        private string realName;

        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }
        private decimal advancePayment;

        public decimal AdvancePayment
        {
            get { return advancePayment; }
            set { advancePayment = value; }
        }
        private string mobile;

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
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
        private string superior;
        public string Superior
        {
            get { return superior; }
            set { superior = value; }
        }


        private string token;
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string membership_Level;
        public string Membership_Level
        {
            get { return membership_Level; }
            set { membership_Level = value; }
        }
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        private string zaiBi;
        public string ZaiBi
        {
            get { return zaiBi; }
            set { zaiBi = value; }
        }
        private string shopBili;
        public string ShopBili
        {
            get { return shopBili; }
            set { shopBili = value; }
        }
        private string recoMember;
        public string RecoMember
        {
            get { return recoMember; }
            set { recoMember = value; }
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


        public static ShopNum1_M_Member FromDataRow(DataRow row)
        {
            ShopNum1_M_Member M_Member = new ShopNum1_M_Member();
            M_Member.Score_dv = Convert.ToDecimal(row["Score_dv"]);
            M_Member.Score_hv = Convert.ToDecimal(row["Score_hv"]);
            M_Member.MemLoginID = row["MemLoginID"].ToString();
            M_Member.Mobile = row["Mobile"].ToString();
            M_Member.RealName = row["RealName"].ToString();
            M_Member.Name = row["Name"].ToString();
            M_Member.IdentityCard = row["IdentityCard"].ToString();
            M_Member.AdvancePayment = Convert.ToDecimal(row["AdvancePayment"]);
            M_Member.Superior = row["Superior"].ToString();
            M_Member.Token = row["LoginToken"].ToString();
            M_Member.Membership_Level = row["membership_Level"].ToString();
            M_Member.ZaiBi = row["ZaiBi"].ToString();
            M_Member.RecoMember = row["RecoMember"].ToString();
            M_Member.ShopBili = Convert.ToString(Convert.ToDecimal(row["ShopBili"]) * 100);
            if (row["Photo"].ToString() == null || row["Photo"].ToString() == "")
            {
                M_Member.Photo = "";
            }
            else
            {
                M_Member.Photo = row["Photo"].ToString();
            }
            return M_Member;
        }

        public static ShopNum1_M_Member FromDataRowGetMoney(DataRow row)
        {
            ShopNum1_M_Member M_MemberGetMoney = new ShopNum1_M_Member();
            //M_MemberGetMoney.Score_bv = Convert.ToDecimal(row["Score_bv"]);
            //M_MemberGetMoney.Score_cv = Convert.ToDecimal(row["Score_cv"]);
            M_MemberGetMoney.Score_dv = Convert.ToDecimal(row["Score_dv"]);
            M_MemberGetMoney.Score_hv = Convert.ToDecimal(row["Score_hv"]);
            M_MemberGetMoney.AdvancePayment = Convert.ToDecimal(row["AdvancePayment"]);
            //M_MemberGetMoney.Score_pv_a = Convert.ToDecimal(row["Score_pv_a"]);
            //M_MemberGetMoney.Score_pv_b = Convert.ToDecimal(row["Score_pv_b"]);
            //M_MemberGetMoney.Score_pv_cv = Convert.ToDecimal(row["Score_pv_cv"]);
            //M_MemberGetMoney.Score_record_pv_a = Convert.ToDecimal(row["Score_record _pv_a"]);
            //M_MemberGetMoney.Score_rv = Convert.ToDecimal(row["Score_rv"]);
            //M_MemberGetMoney.Score_sv = Convert.ToDecimal(row["Score_sv"]);
            
            //M_MemberGetMoney.MemberRankGuid = new Guid(row["MemberRankGuid"].ToString());
            return M_MemberGetMoney;
        }
        //}
    }
}
