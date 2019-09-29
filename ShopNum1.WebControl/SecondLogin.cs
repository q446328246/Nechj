using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SecondLogin : BaseWebControl
    {
        private Repeater RepeaterSecondLogin;

        protected override void InitializeSkin(Control skin)
        {
            RepeaterSecondLogin = (Repeater) skin.FindControl("RepeaterSecondLogin");
            if (RepeaterSecondLogin != null)
            {
                DataTable secondByCount = new ShopNum1_SecondTypeBussiness().GetSecondByCount("10", "1");
                if ((secondByCount != null) && (secondByCount.Rows.Count > 0))
                {
                    RepeaterSecondLogin.DataSource = secondByCount;
                    RepeaterSecondLogin.DataBind();
                }
            }
        }
    }
}