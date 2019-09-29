using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class IntegralPhb : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "IntegralPhb.ascx";

        public IntegralPhb()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        public void GetData()
        {
            if (string.IsNullOrEmpty(ShowCount))
            {
                ShowCount = "4";
            }
            DataTable table =
                ((ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action())
                    .GetDataTopWeb(1, 0, 1, Convert.ToInt32(ShowCount));
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }
    }
}