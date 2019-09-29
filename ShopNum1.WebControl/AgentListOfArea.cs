using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AgentListOfArea : BaseWebControl
    {
        private Label LabelLevel1AreaName;
        private Repeater RepeaterData;
        protected char charSapce = '　';

        private string skinFilename = "AgentListOfArea.ascx";
        protected string strSapce = "　　";

        public AgentListOfArea()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AreaCode { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            AreaCode = (Page.Request.QueryString["AreaCode"] == null) ? "" : Page.Request.QueryString["AreaCode"];
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            LabelLevel1AreaName = (Label) skin.FindControl("LabelLevel1AreaName");
            BindData();
        }

        protected void BindData()
        {
            if (!string.IsNullOrEmpty(AreaCode) && !(AreaCode == "-1"))
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                DataTable table = null;
                try
                {
                    table = action.SearchAgentByAreacodeProp(AreaCode, ShowCount);
                }
                catch
                {
                    table = action.SearchAgentByAreacode(AreaCode, ShowCount);
                }
                if ((table != null) && (table.Rows.Count > 0))
                {
                    RepeaterData.DataSource = table;
                    RepeaterData.DataBind();
                }
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) &&
                 (LabelLevel1AreaName.Text == "")) && (DataBinder.Eval(e.Item.DataItem, "MemLoginID").ToString() == ""))
            {
                LabelLevel1AreaName.Text = DataBinder.Eval(e.Item.DataItem, "name").ToString();
            }
        }
    }
}