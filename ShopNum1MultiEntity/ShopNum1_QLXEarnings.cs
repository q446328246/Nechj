using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_QLXEarnings : INotifyPropertyChanging, INotifyPropertyChanged
    { 
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        private string usableNEC;
        public string UsableNEC
        {
            get { return usableNEC; }
            set { usableNEC = value; }
        }

        private string freezeNEC;
        public string FreezeNEC
        {
            get { return freezeNEC; }
            set { freezeNEC = value; }
        }

        private string allNEC;
        public string AllNEC
        {
            get { return allNEC; }
            set { allNEC = value; }
        }

        private string allNECCNY;
        public string AllNECCNY
        {
            get { return allNECCNY; }
            set { allNECCNY = value; }
        }

        private string uSDT;
        public string USDT
        {
            get { return uSDT; }
            set { uSDT = value; }
        } 
   
        private string uSDTCNY;
        public string USDTCNY
        {
            get { return uSDTCNY; }
            set { uSDTCNY = value; }
        }  
                           
        private string allNECUSDT;
        public string AllNECUSDT
        {
            get { return allNECUSDT; }
            set { allNECUSDT = value; }
        } 
    
        private string allNECUSDTCNY;
        public string AllNECUSDTCNY
        {
            get { return allNECUSDTCNY; }
            set { allNECUSDTCNY = value; }
        }      
                       
        private string eTH;
        public string ETH
        {
            get { return eTH; }
            set { eTH = value; }
        }  
        private string allETHCny;
        public string AllETHCny
        {
            get { return allETHCny; }
            set { allETHCny = value; }
        }
        private string huiLv;
        public string HuiLv
        {
            get { return huiLv; }
            set { huiLv = value; }
        }
         

        private string usdt_ethBiLI;
        public string Usdt_ethBiLI
        {
            get { return usdt_ethBiLI; }
            set { usdt_ethBiLI = value; }
        }

        private string usableNECCNY;
        public string UsableNECCNY
        {
            get { return usableNECCNY; }
            set { usableNECCNY = value; }
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

        public static ShopNum1_QLXEarnings FromDataRow1(List<string> aist)
        {
            ShopNum1_QLXEarnings M_Member = new ShopNum1_QLXEarnings();
            for (int i = 0; i < aist.Count; i++)
			{
                M_Member.UsableNEC = aist[0];
                M_Member.FreezeNEC = aist[1];
                M_Member.AllNEC = aist[2];

                M_Member.AllNECCNY = aist[3];
                M_Member.USDT = aist[4];
                M_Member.USDTCNY = aist[5];

                M_Member.AllNECUSDT = aist[6];
                M_Member.AllNECUSDTCNY = aist[7];

                M_Member.ETH = aist[8];
                M_Member.AllETHCny = aist[9];
                M_Member.HuiLv = aist[10];

                M_Member.Usdt_ethBiLI = aist[11];

                M_Member.UsableNECCNY = aist[12];


            } 

            return M_Member;
        }

    }
}
