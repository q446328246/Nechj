using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    public class SupplyDetail : BaseWebControl
    {
        private Repeater RepeaterCommentList;
        private string skinFilename = "SupplyDetail.ascx";

        public SupplyDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string StrGuid { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            StrGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            RepeaterCommentList = (Repeater) skin.FindControl("RepeaterCommentList");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((Shop_SupplyDemand_Action) LogicFactory.CreateShop_SupplyDemand_Action()).SupplyDemandDetail(StrGuid);
            RepeaterCommentList.DataSource = table;
            RepeaterCommentList.DataBind();
        }
    }
}