using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class HelpList : BaseWebControl
    {
        private DataList DataListHelpList;

        private Repeater RepeaterRemark;
        private string skinFilename = "HelpList.ascx";

        public HelpList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string DefaultHelp { get; set; }

        public int ShowCount { get; set; }

        protected void DataListHelpList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var action = (ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action();
            var field = (HiddenField) e.Item.FindControl("HiddenFieldGuid");
            DataTable table = action.Search(field.Value, 0);
            if ((e.Item.ItemIndex == 0) && (table.Rows.Count > 0))
            {
                DefaultHelp = table.Rows[0]["Guid"].ToString();
            }
            var repeater = (Repeater) e.Item.FindControl("RepeaterHelp");
            repeater.DataSource = table.DefaultView;
            repeater.DataBind();
        }

        protected override void InitializeSkin(Control skin)
        {
            DataListHelpList = (DataList) skin.FindControl("DataListHelpList");
            RepeaterRemark = (Repeater) skin.FindControl("RepeaterRemark");
            DataListHelpList.ItemDataBound += DataListHelpList_ItemDataBound;
            if (!Page.IsPostBack)
            {
                BindData();
                string str = Common.Common.ReqStr("guid");
                if (str != "0")
                {
                    method_1(str);
                }
                else
                {
                    method_1(DefaultHelp);
                }
            }
        }

        protected void BindData()
        {
            DataTable table = ((ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action()).Search("0",
                ShowCount);
            DataListHelpList.DataSource = table.DefaultView;
            DataListHelpList.DataBind();
        }

        protected void method_1(string string_2)
        {
            DataTable table = ((ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action()).SearchRemark(string_2,
                0);
            RepeaterRemark.DataSource = table.DefaultView;
            RepeaterRemark.DataBind();
        }
    }
}