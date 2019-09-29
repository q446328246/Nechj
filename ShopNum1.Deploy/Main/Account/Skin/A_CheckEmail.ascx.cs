using System;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_CheckEmail : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            nextEmail.Text = action.GetAdvancePayment(base.MemLoginID).Rows[0]["Email"].ToString();
        }
    }
}
                                            
