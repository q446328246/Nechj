using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopType_List : PageBase, IRequiresSessionState
    {
        public DataTable dataTable = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                dataTable =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action())
                        .SearchtProductCategory(0, 0);
            }
        }
    }
}