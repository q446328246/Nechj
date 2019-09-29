using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopOpenStep1 : BaseMemberWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "S_ShopOpenStep1.ascx";

        public S_ShopOpenStep1()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void GetData()
        {
            DataTable table = ((Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action()).Search(0);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemDataBound += RepeaterShow_ItemDataBound;
            GetData();
        }

        protected void RepeaterShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var label = (Label) e.Item.FindControl("LabelShopTemplateCount");
                string text = label.Text;
                string str2 = "0";
                if (!string.IsNullOrEmpty(text))
                {
                    str2 = text.Split(new[] {','}).Length.ToString();
                }
                label.Text = str2;
            }
        }
    }
}