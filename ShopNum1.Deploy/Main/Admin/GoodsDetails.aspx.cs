using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class GoodsDetails : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string text1 = base.Request.QueryString["guid"];
        }
    }
}