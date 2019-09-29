using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeSupplyDemandDetail : BaseWebControl
    {
        private Repeater RepeaterData1;
        private Repeater RepeaterData2;
        private Repeater RepeaterData3;
        private string skinFilename = "DeSupplyDemandDetail.ascx";

        public DeSupplyDemandDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string code { get; set; }

        public string ShowCount { get; set; }

        protected void BindData1()
        {
            DataTable table =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .GetTitleByCodeTrade(0, code, ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData1.DataSource = table.DefaultView;
                RepeaterData1.DataBind();
            }
        }

        protected void BindData2()
        {
            DataTable table =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .GetTitleByCodeTrade(1, code, ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData2.DataSource = table.DefaultView;
                RepeaterData2.DataBind();
            }
        }

        protected void BindData3()
        {
            DataTable titleByCodeRecommend =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .GetTitleByCodeRecommend(code, ShowCount);
            if ((titleByCodeRecommend != null) && (titleByCodeRecommend.Rows.Count > 0))
            {
                RepeaterData3.DataSource = titleByCodeRecommend.DefaultView;
                RepeaterData3.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData1 = (Repeater) skin.FindControl("RepeaterData1");
            RepeaterData2 = (Repeater) skin.FindControl("RepeaterData2");
            RepeaterData3 = (Repeater) skin.FindControl("RepeaterData3");
            try
            {
                int.Parse(ShowCount);
            }
            catch
            {
                ShowCount = "0";
            }
            BindData1();
            BindData2();
            BindData3();
        }
    }
}