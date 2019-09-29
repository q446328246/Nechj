using System;
using System.Web.SessionState;
using System.Web.UI;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class MerchantFailure : Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblReturnCode.Text = ((base.Request["ReturnCode"] == null) ? "" : base.Request["ReturnCode"]);
            lblErrorMessage.Text = ((base.Request["ErrorMessage"] == null) ? "" : base.Request["ErrorMessage"]);
        }
    }
}