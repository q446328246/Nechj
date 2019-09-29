using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductPanicBuyV82 : BaseWebControl
    {
        private Repeater RepeaterData;
        private HtmlInputHidden hidendtime;
        private string skinFilename = "ProductPanicBuyV82.ascx";

        public ProductPanicBuyV82()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            hidendtime = (HtmlInputHidden) skin.FindControl("hidendtime");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SelectProductPanicBuy(ShowCount);
            if (table.Rows.Count > 0)
            {
                var builder = new StringBuilder();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    builder.Append(
                        Convert.ToDateTime(table.Rows[i]["endtime"].ToString())
                            .ToLocalTime()
                            .ToString()
                            .Replace("-", "/") + "|");
                }
                builder.Remove(builder.Length - 1, 1);
                hidendtime.Value = builder.ToString();
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
            }
        }
    }
}