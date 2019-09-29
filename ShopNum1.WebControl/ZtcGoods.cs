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
    public class ZtcGoods : BaseWebControl
    {
        private Literal LiteralTitle;
        private Repeater RepeaterData;
        private string skinFilename = "ZtcGoods.ascx";

        public ZtcGoods()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string endNum { get; set; }

        public string ShowCount { get; set; }

        public string startNum { get; set; }

        public string Title { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LiteralTitle = (Literal) skin.FindControl("LiteralTitle");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            LiteralTitle.Text = Title;
            BindData();
        }

        protected void BindData()
        {
            decimal num = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney"));
            DataTable table = ((ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action()).Search(
                startNum, endNum, 1, num);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
            }
        }
    }
}