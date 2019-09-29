using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class HelpCategory : BaseWebControl
    {
        private Repeater RepeaterHelpList;
        private string skinFilename = "HelpCategory.ascx";

        public HelpCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterHelpList = (Repeater) skin.FindControl("RepeaterHelpList");
            RepeaterHelpList.ItemDataBound += RepeaterHelpList_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table = ((ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action()).Search("0",
                ShowCount);
            RepeaterHelpList.DataSource = table.DefaultView;
            RepeaterHelpList.DataBind();
        }

        protected void RepeaterHelpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var action = (ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action();
            var field = (HiddenField) e.Item.FindControl("HiddenFieldGuid");
            DataTable table = action.Search(field.Value, ShowCount, 0);
            var repeater = (Repeater) e.Item.FindControl("RepeaterHelp");
            repeater.DataSource = table.DefaultView;
            repeater.DataBind();
        }
    }
}