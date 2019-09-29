using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SellOrder : BaseWebControl
    {
        private DataList DataListSellOrder;
        private string skinFilename = "SellOrder.ascx";

        public SellOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            DataListSellOrder = (DataList) skin.FindControl("DataListSellOrder");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            string str =
                new ShopSettings().GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                    "SellOrderCount");
            DataTable table =
                ((ShopNum1_Report_Action) LogicFactory.CreateShopNum1_Report_Action()).SearchSellOrder(string.Empty,
                    string.Empty,
                    Convert.ToInt32(
                        str));
            DataListSellOrder.DataSource = table;
            DataListSellOrder.DataBind();
        }
    }
}