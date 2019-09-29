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
        }

        public static string LinkUrl(string string_2)
        {
            if (string_2.Contains("http://"))
            {
                return string_2;
            }
            return GetPageName.RetDomainUrl(string_2 ?? "");
        }

        protected void BindData()
        {
            DataTable buttomNavigation =
                ((ShopNum1_UserDefinedColumn_Action) LogicFactory.CreateShopNum1_UserDefinedColumn_Action())
                    .GetButtomNavigation(ShowCount);
            RepeaterData.DataSource = buttomNavigation.DefaultView;
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