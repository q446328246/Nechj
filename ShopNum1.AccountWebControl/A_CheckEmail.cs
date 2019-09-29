using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_CheckEmail : BaseMemberWebControl
    {
        private Label Lab_MemLoginID;
        private Label nextEmail;
        private string skinFilename = "A_CheckEmail.ascx";

        public A_CheckEmail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            nextEmail = (Label) skin.FindControl("nextEmail");
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            nextEmail.Text = action.GetAdvancePayment(base.MemLoginID).Rows[0]["Email"].ToString();
        }
    }
}