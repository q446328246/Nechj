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
    public class ShopEspecialSeach : BaseWebControl
    {
        private Repeater RepeaterData;
        private HtmlGenericControl htmlGenericControl_0;
        private Localize localizeTitle;
        private string skinFilename = "ShopEspecialSeach.ascx";

        public ShopEspecialSeach()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShopType { get; set; }

        public string ShowCount { get; set; }

        public string Title { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            localizeTitle = (Localize) skin.FindControl("localizeTitle");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .SearchEspecialShopList(ShowCount, ShopType);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
            if (Operator.FormatToEmpty(Title) != string.Empty)
            {
                localizeTitle.Text = Title;
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            htmlGenericControl_0 = (HtmlGenericControl) e.Item.FindControl("spanshopid");
            var repeater = e.Item.FindControl("RepeaterImg") as Repeater;
            DataTable ensureImagePathBymemberLoginID =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .GetEnsureImagePathBymemberLoginID(htmlGenericControl_0.InnerText.Trim());
            if ((ensureImagePathBymemberLoginID != null) && (ensureImagePathBymemberLoginID.Rows.Count > 0))
            {
                repeater.DataSource = ensureImagePathBymemberLoginID.DefaultView;
                repeater.DataBind();
            }
        }
    }
}