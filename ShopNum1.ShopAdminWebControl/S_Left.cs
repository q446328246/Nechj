using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Left : BaseMemberWebControl
    {
        private Panel PanelScroe;
        private HtmlAnchor ScoreOrder;
        private HtmlAnchor ScoreProduct;
        private Panel panShowWeixin;
        private string skinFilename = "S_Left.ascx";

        public S_Left()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelScroe = (Panel) skin.FindControl("PanelScroe");
            panShowWeixin = (Panel) skin.FindControl("panShowWeixin");
            ScoreOrder = (HtmlAnchor) skin.FindControl("ScoreOrder");
            ScoreProduct = (HtmlAnchor) skin.FindControl("ScoreProduct");
            try
            {
                string str =
                    Common.Common.GetNameById(
                        "isnull(cast(IsIntegralShop as varchar(10)),0)+'|'+isnull(cast(IsWeixin as varchar(10)),0)",
                        "ShopNum1_ShopInfo", "  AND  MemLoginID='" + base.MemLoginID + "'");
                string str2 = Common.Common.GetNameById("wEndTime", "ShopNum1_ShopInfo",
                    "  AND  MemLoginID='" + base.MemLoginID + "'");
                if (str != "")
                {
                    PanelScroe.Visible = false;
                    ScoreOrder.Visible = false;
                    ScoreProduct.Visible = false;
                    panShowWeixin.Visible = false;
                    if (str.Split(new[] {'|'})[0] == "1")
                    {
                        ScoreOrder.Visible = true;
                        ScoreProduct.Visible = true;
                        PanelScroe.Visible = true;
                    }
                    if ((str2 != "") &&
                        ((str.Split(new[] {'|'})[1] == "1") && (Convert.ToDateTime(str2) > DateTime.Now.ToLocalTime())))
                    {
                        panShowWeixin.Visible = true;
                    }
                }
            }
            catch
            {
                PanelScroe.Visible = false;
                ScoreOrder.Visible = false;
                ScoreProduct.Visible = false;
               // panShowWeixin.Visible = false;
            }
        }
    }
}