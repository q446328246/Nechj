using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeProductOrder : BaseWebControl
    {
        private Literal LiteralTitle;
        private Repeater RepeaterData;
        private string skinFilename = "DeProductOrder.ascx";

        public DeProductOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string OrderType { get; set; }

        public string ShowCount { get; set; }

        public string Title { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            LiteralTitle = (Literal) skin.FindControl("LiteralTitle");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SearchProductOrder(ShowCount, OrderType);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
            LiteralTitle.Text = Title;
        }
    }
}