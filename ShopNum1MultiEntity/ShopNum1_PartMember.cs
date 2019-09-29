using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_PartMember
    {
        //private string realName;

        //public string RealName
        //{
        //    get { return realName; }
        //    set { realName = value; }
        //}

        private string mobile;

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private decimal score_pv_b;

        public decimal Score_pv_b
        {
            get { return score_pv_b; }
            set { score_pv_b = value; }
        }

        private string superior;

        public string Superior 
        { 
            get { return superior; }
            set { superior = value; } 
        }

        public static ShopNum1_PartMember PartMember(DataRow row, string superiorMobile) 
        {
            ShopNum1_PartMember partMember = new ShopNum1_PartMember();
            //partMember.RealName = row["RealName"].ToString();
            partMember.Mobile = row["Mobile"].ToString();
            partMember.Score_pv_b = Convert.ToDecimal(row["Score_pv_b"].ToString()) * 100;
            partMember.Superior = superiorMobile;
            return partMember;
        }
    }
}
