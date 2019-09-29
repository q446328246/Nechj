using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CategoryInfoIsNew : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "CategoryInfoIsNew.ascx";

        public CategoryInfoIsNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((Shop_CategoryInfo_Action) LogicFactory.CreateShop_CategoryInfo_Action()).Search(MemLoginID, "1");
            RepeaterShow.DataSource = table;
            RepeaterShow.DataBind();
        }
    }
}