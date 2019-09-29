using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class VideoCategoryList : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "VideoCategoryList.ascx";

        public VideoCategoryList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable videoCategoryList =
                ((Shop_VideoCategory_Action) LogicFactory.CreateShop_VideoCategory_Action()).GetVideoCategoryList(
                    MemLoginID, "1");
            RepeaterData.DataSource = videoCategoryList;
            RepeaterData.DataBind();
        }
    }
}