using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.WebControl
{
    public class CategoryInfoDetail : BaseWebControl
    {
        private Repeater RepeaterCommentList;
        private string skinFilename = "CategoryInfoDetail.ascx";

        public CategoryInfoDetail()
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
                ((Shop_CategoryInfo_Action) LogicFactory.CreateShop_CategoryInfo_Action()).CategoryInfoDetail(StrGuid);
            RepeaterCommentList.DataSource = table;
            RepeaterCommentList.DataBind();
        }
    }
}