using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ButtomNavigation : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ButtomNavigation.ascx";

        public ButtomNavigation()
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
            if (RepeaterData.Items.Count >= 1)
            {
                RepeaterData.Items[RepeaterData.Items.Count - 1].FindControl("LabelSpilt").Visible = false;
            }
        }

        protected void BindData()
        {
            DataTable buttomNavigation =
                ((Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action()).GetButtomNavigation
                    (ShowCount);
            if ((buttomNavigation != null) && (buttomNavigation.Rows.Count > 0))
            {
                RepeaterData.DataSource = buttomNavigation.DefaultView;
                RepeaterData.DataBind();
            }
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