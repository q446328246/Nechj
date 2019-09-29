using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Bourse.Skin
{
    public partial class B_Left : BaseMemberControl
    {
        private string upgrade;

        public string Upgrade
        {
            get { return upgrade; }
            set { upgrade = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            String GetIsShopActivate = memberrankguid_Action.GetIsShopActivate(base.MemLoginID);
            if (GetIsShopActivate=="1")
            {
                upgrade = "B_CSChongZhi.aspx";
            }
            else
            {
                upgrade = "B_MemberRegProtocol.aspx?B=B_CSChongZhi";
            }
        }
    }
}