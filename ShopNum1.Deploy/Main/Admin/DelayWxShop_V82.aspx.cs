using System;
using System.Data;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class DelayWxShop_V82 : PageBase, IRequiresSessionState
    {
        public DataTable dt_WxShop = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt_WxShop = Common.Common.GetTableById("shopname,memloginid", "shopnum1_shopinfo",
                                                       " And WendTime<'" + DateTime.Now.ToLocalTime() + "'");
            }
        }
    }
}