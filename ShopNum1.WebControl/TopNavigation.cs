using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class TopNavigation : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "TopNavigation.ascx";

        public TopNavigation()
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
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable topNavigation =
                ((ShopNum1_UserDefinedColumn_Action) LogicFactory.CreateShopNum1_UserDefinedColumn_Action())
                    .GetTopNavigation(ShowCount);
            RepeaterData.DataSource = topNavigation.DefaultView;
            RepeaterData.DataBind();
        }

        public static string ShowIsOpen(string ifOpen)
        {
            if (ifOpen == "0")
            {
                ifOpen = "_self";
                return ifOpen;
            }
            if (ifOpen == "1")
            {
                ifOpen = "_blank";
            }
            return ifOpen;
        }
    }
}