using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopCommentStatReport : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "ShopCommentStatReport.ascx";
        private string string_1;

        public ShopCommentStatReport()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public static string ShopID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(ShopID);
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            string_1 = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string memloginid = action.GetMemberLoginidByShopid(ShopID);
            DataTable shopInfo = action.GetShopInfo(memloginid);
            RepeaterShow.DataSource = shopInfo.DefaultView;
            RepeaterShow.DataBind();
            foreach (RepeaterItem item in RepeaterShow.Items)
            {
                var field1 = (HiddenField) item.FindControl("ha");
                var field2 = (HiddenField) item.FindControl("hc");
                var field3 = (HiddenField) item.FindControl("hs");
            }
        }
    }
}