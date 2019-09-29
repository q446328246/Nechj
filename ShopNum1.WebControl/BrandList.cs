using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class BrandList : BaseWebControl
    {
        private Repeater RepeaterBrandCategory;
        private string skinFilename = "BrandList.ascx";

        public BrandList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string BrandCount { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterBrandCategory = (Repeater) skin.FindControl("RepeaterBrandCategory");
            RepeaterBrandCategory.ItemDataBound += RepeaterBrandCategory_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable brandCategory =
                ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).GetBrandCategory(ShowCount);
            RepeaterBrandCategory.DataSource = brandCategory;
            RepeaterBrandCategory.DataBind();
        }

        protected void RepeaterBrandCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterBrandImg");
                var literal = (Literal) e.Item.FindControl("LiteralCode");
                if ((literal.Text == "") || (literal.Text == string.Empty))
                {
                    repeater.DataSource = null;
                    repeater.DataBind();
                }
                else
                {
                    DataTable brandImgByCode =
                        ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).GetBrandImgByCode(
                            ShowCount, literal.Text);
                    repeater.DataSource = brandImgByCode;
                    repeater.DataBind();
                }
            }
        }
    }
}