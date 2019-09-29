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
    public class OnLineFootService : BaseWebControl
    {
        private Label Lab_ServerPhone;
        private Panel PanelPhone;
        private Panel PanelQQ;
        private Panel PanelShowServer;
        private Panel PanelWW;
        private Repeater RepeaterKFT;
        private Repeater RepeaterMSN;
        private Repeater RepeaterPhone;
        private Repeater RepeaterQQ;
        private Repeater RepeaterWW;
        private string skinFilename = "OnLineFootService.ascx";

        public OnLineFootService()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterQQ = (Repeater) skin.FindControl("RepeaterQQ");
            RepeaterMSN = (Repeater) skin.FindControl("RepeaterMSN");
            RepeaterWW = (Repeater) skin.FindControl("RepeaterWW");
            RepeaterKFT = (Repeater) skin.FindControl("RepeaterKFT");
            RepeaterPhone = (Repeater) skin.FindControl("RepeaterPhone");
            PanelShowServer = (Panel) skin.FindControl("PanelShowServer");
            PanelQQ = (Panel) skin.FindControl("PanelQQ");
            PanelWW = (Panel) skin.FindControl("PanelWW");
            PanelPhone = (Panel) skin.FindControl("PanelPhone");
            Lab_ServerPhone = (Label) skin.FindControl("Lab_ServerPhone");
            if (!Page.IsPostBack)
            {
            }
            method_1();
            BindData();
            method_2();
        }

        protected void BindData()
        {
            string str = ShopSettings.GetValue("ShowCustomer");
            string str2 = ShopSettings.GetValue("IsOpenPhone");
            string str3 = ShopSettings.GetValue("ServerPhone");
            switch (str)
            {
                case "1":
                    PanelShowServer.Visible = true;
                    break;

                case "0":
                    PanelShowServer.Visible = false;
                    break;
            }
            if (str2 == "1")
            {
                PanelPhone.Visible = true;
                Lab_ServerPhone.Text = str3;
            }
            else if (str2 == "0")
            {
                PanelPhone.Visible = false;
            }
        }

        protected void method_1()
        {
            DataTable table =
                ((ShopNum1_OnLineService_Action) LogicFactory.CreateShopNum1_OnLineService_Action()).SearchTypeInfo(
                    "QQ", 1, ShowCount);
            if (table.Rows.Count > 0)
            {
                RepeaterQQ.DataSource = table;
                RepeaterQQ.DataBind();
            }
            else
            {
                PanelQQ.Visible = false;
            }
        }

        protected void method_2()
        {
            DataTable table =
                ((ShopNum1_OnLineService_Action) LogicFactory.CreateShopNum1_OnLineService_Action()).SearchTypeInfo(
                    "WW", 1, ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterWW.DataSource = table;
                RepeaterWW.DataBind();
            }
            else
            {
                PanelWW.Visible = false;
            }
        }
    }
}