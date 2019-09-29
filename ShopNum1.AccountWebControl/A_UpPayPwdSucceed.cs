using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_UpPayPwdSucceed : BaseMemberWebControl
    {
        private Label Lab_MemLoginID;
        private string skinFilename = "A_UpPayPwdSucceed.ascx";

        public A_UpPayPwdSucceed()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            Lab_MemLoginID.Text = base.MemLoginID;
        }
    }
}