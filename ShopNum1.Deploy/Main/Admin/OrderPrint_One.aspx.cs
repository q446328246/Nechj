using System;
using System.Data;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderPrint_One : PageBase, IRequiresSessionState
    {
        public DataTable dt = null;

        private void BindData()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}