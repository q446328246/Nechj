using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_ProductCategory_List : PageBase, IRequiresSessionState
    {
        public DataTable dataTable = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.dataTable = ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action()).SearchtProductCategory(0, 0);
            }
        }
    }
}