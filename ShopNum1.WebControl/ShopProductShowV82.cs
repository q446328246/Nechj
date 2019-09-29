using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopProductShowV82 : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ProductPanicBuyV82.ascx";
        private string string_1 = "0";

        public ShopProductShowV82()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CategoryID
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SelectProductShowLine(ShowCount, CategoryID);
            if (table.Rows.Count > 0)
            {
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
            }
        }
    }
}