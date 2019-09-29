using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_NECSevenDetail : INotifyPropertyChanging, INotifyPropertyChanged
    { 
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);
                        

        private string frist;
        public string Frist
        {
            get { return frist; }
            set { frist = value; }
        }

        private string second;
        public string Second
        {
            get { return second; }
            set { second = value; }
        }

        private string three;
        public string Three
        {
            get { return three; }
            set { three = value; }
        }

        private string Four;
        public string four
        {
            get { return Four; }
            set { Four = value; }
        }

        private string five;
        public string Five
        {
            get { return five; }
            set { five = value; }
        } 
   
        private string six;
        public string Six
        {
            get { return six; }
            set { six = value; }
        }  
                           
        private string seven;
        public string Seven
        {
            get { return seven; }
            set { seven = value; }
        } 
    
    
        private string fristMoney;
        public string FristMoney
        {
            get { return fristMoney; }
            set { fristMoney = value; }
        } 

        private string secondMoney;
        public string SecondMoney
        {
            get { return secondMoney; }
            set { secondMoney = value; }
        } 

        private string threeMoney;
        public string ThreeMoney
        {
            get { return threeMoney; }
            set { threeMoney = value; }
        } 

        private string FourMoney;
        public string fourMoney
        {
            get { return FourMoney; }
            set { FourMoney = value; }
        } 
        private string fiveMoney;
        public string FiveMoney
        {
            get { return fiveMoney; }
            set { fiveMoney = value; }
        } 
        private string sixMoney;
        public string SixMoney
        {
            get { return sixMoney; }
            set { sixMoney = value; }
        }                 
        
       private string sevenMoney;
        public string SevenMoney
        {
            get { return sevenMoney; }
            set { sevenMoney = value; }
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

        public static ShopNum1_NECSevenDetail FromDataRow1(List<string> aist)
        {
            ShopNum1_NECSevenDetail M_Member = new ShopNum1_NECSevenDetail();
            for (int i = 0; i < aist.Count; i++)
            {

                M_Member.Frist = aist[0];
                M_Member.Second = aist[1];
                M_Member.Three = aist[2];
                M_Member.four = aist[3];
                M_Member.Five = aist[4];
                M_Member.Six = aist[5];
                M_Member.Seven = aist[6];


                M_Member.fristMoney = aist[7];
                M_Member.SecondMoney = aist[8];
                M_Member.ThreeMoney = aist[9];
                M_Member.fourMoney = aist[10];
                M_Member.FiveMoney = aist[11];
                M_Member.SixMoney = aist[12];
                M_Member.SevenMoney = aist[13];
            }
 
            return M_Member;
        }

    }
}
