using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class BrandAllList : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "BrandAllList.ascx";

        public BrandAllList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCountOne { get; set; }

        public string ShowCountTwo { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(0, 0,
                    ShowCountOne);
            if (table.Rows.Count > 0)
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
            var repeater = (Repeater) e.Item.FindControl("RepeaterBrand");
            var label = (Label) e.Item.FindControl("LabelBrandCount");
            DataTable productBrandBycount =
                ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).GetProductBrandBycount(
                    field.Value, ShowCountTwo);
            label.Text = (productBrandBycount == null) ? "0" : productBrandBycount.Rows.Count.ToString();
            if (productBrandBycount != null)
            {
                repeater.DataSource = productBrandBycount.DefaultView;
                repeater.DataBind();
            }
        }
    }
}