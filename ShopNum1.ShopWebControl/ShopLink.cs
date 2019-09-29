using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopLink : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "ShopLink.ascx";

        public ShopLink()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string ShowCount { get; set; }

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
            if (int.Parse(ShowCount) > 0)
            {
                DataTable table = ((Shop_ShopLink_Action) LogicFactory.CreateShop_ShopLink_Action()).Show(MemLoginID,
                    ShowCount);
                RepeaterShow.DataSource = table;
                RepeaterShow.DataBind();
            }
        }
    }
}