using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeShopIsNew : BaseWebControl
    {
        private Repeater RepeaterData;
        private HtmlGenericControl htmlGenericControl_0;
        private string skinFilename = "DeShopIsNew.ascx";

        public DeShopIsNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            string pagesize = ShopSettings.GetValue("DefaultCategoryShopCount");
            DataTable table = action.SearchNewsShopList(pagesize);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            htmlGenericControl_0 = (HtmlGenericControl) e.Item.FindControl("spanMemLoginID");
            var repeater = e.Item.FindControl("RepeaterImg") as Repeater;
            DataTable ensureImagePathBymemberLoginID =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .GetEnsureImagePathBymemberLoginID(htmlGenericControl_0.InnerText.Trim());
            if ((ensureImagePathBymemberLoginID != null) && (ensureImagePathBymemberLoginID.Rows.Count > 0))
            {
                repeater.DataSource = ensureImagePathBymemberLoginID.DefaultView;
                repeater.DataBind();
            }
            var repeater2 = e.Item.FindControl("RepeaterProduct") as Repeater;
            string productCount = ShopSettings.GetValue("ShopMainProductCount");
            DataTable table2 =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SearchProductByMemLoginID(htmlGenericControl_0.InnerText.Trim(), productCount);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                repeater2.DataSource = table2.DefaultView;
                repeater2.DataBind();
            }
        }
    }
}