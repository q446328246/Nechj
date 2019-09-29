using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_CheckMobile : BaseMemberWebControl
    {
        private Label Lab_MemLoginID;
        private HtmlInputText M_code;
        private Label nextmobile;
        private string skinFilename = "A_CheckMobile.ascx";

        public A_CheckMobile()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            M_code = (HtmlInputText) skin.FindControl("M_code");
            nextmobile = (Label) skin.FindControl("nextmobile");
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            nextmobile.Text = action.GetAdvancePayment(base.MemLoginID).Rows[0]["Mobile"].ToString();
        }
    }
}