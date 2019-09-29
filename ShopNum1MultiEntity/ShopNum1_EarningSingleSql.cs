using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
namespace ShopNum1MultiEntity
{
 
    public class ShopNum1_EarningSingleSql : INotifyPropertyChanging, INotifyPropertyChanged
    { 
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


 

        private string hashrateAll;
        public string HashrateAll
        {
            get { return hashrateAll; }
            set { hashrateAll = value; }
        }

        private string linkAll;
        public string LinkAll
        {
            get { return linkAll; }
            set { linkAll = value; }
        }

        private string signinAll;
        public string SigninAll
        {
            get { return signinAll; }
            set { signinAll = value; }
        }

        private string presenterAll;
        public string PresenterAll
        {
            get { return presenterAll; }
            set { presenterAll = value; }
        }


        private string hashrateNew;
        public string HashrateNew
        {
            get { return hashrateNew; }
            set { hashrateNew = value; }
        }

        private string linkNew;
        public string LinkNew
        {
            get { return linkNew; }
            set { linkNew = value; }
        }

        private string signinNew;
        public string SigninNew
        {
            get { return signinNew; }
            set { signinNew = value; }
        }

        private string presenterNew;
        public string PresenterNew
        {
            get { return presenterNew; }
            set { presenterNew = value; }
        }

        private string createtime;
        public string Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }


        private string PresenterAllBonus;
        public string presenterAllBonus
        {
            get { return PresenterAllBonus; }
            set { PresenterAllBonus = value; }
        }

        private string newAllBonus;
        public string NewAllBonus
        {
            get { return newAllBonus; }
            set { newAllBonus = value; }
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

        public static ShopNum1_EarningSingleSql FromDataRow1(List<string> aist)
        {
            ShopNum1_EarningSingleSql M_Member = new ShopNum1_EarningSingleSql();
            for (int i = 0; i < aist.Count; i++)
			{
                M_Member.HashrateAll = aist[0];
                M_Member.LinkAll = aist[1];
                M_Member.SigninAll = aist[2];
                M_Member.PresenterAll = aist[3];

                M_Member.HashrateNew = aist[4];
                M_Member.LinkNew = aist[5];
                M_Member.SigninNew = aist[6];
                M_Member.PresenterNew = aist[7];
                M_Member.Createtime = aist[8];
                M_Member.presenterAllBonus = aist[9];
                M_Member.NewAllBonus = aist[10];
            }
            

            return M_Member;
        }

    }
}
