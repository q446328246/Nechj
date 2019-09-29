using System;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_UpPayPwdSucceed : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lab_MemLoginID.Text = base.MemLoginID;
        }
    }
}