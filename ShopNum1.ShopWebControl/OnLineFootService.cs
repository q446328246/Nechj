using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class OnLineFootService : BaseWebControl
    {
        private readonly Shop_OnLineService_Action shop_OnLineService_Action_0 =
            ((Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action());

        private Label Lab_Phone;
        private Panel PanelPhone;
        private Panel PanelQQ;
        private Panel PanelShowServer;
        private Panel PanelWW;
        private Repeater RepeaterKFT;
        private Repeater RepeaterPH;
        private Repeater RepeaterQQ;
        private Repeater RepeaterWW;

        private string skinFilename = "OnLineFootService.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;

        public OnLineFootService()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string_1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            DataTable memSimpleByShopID =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                    ShopSettings.GetValue("PersonShopUrl") + string_1);
            if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
            {
                MemLoginID = memSimpleByShopID.Rows[0]["MemLoginID"].ToString();
                string str = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                shop_OnLineService_Action_0.StrPath = "~/Shop/Shop/" + str.Replace("-", "/") + "/" +
                                                      ShopSettings.GetValue("PersonShopUrl") + string_1 +
                                                      "/xml/OnLineServer.xml";
                RepeaterQQ = (Repeater) skin.FindControl("RepeaterQQ");
                RepeaterWW = (Repeater) skin.FindControl("RepeaterWW");
                RepeaterKFT = (Repeater) skin.FindControl("RepeaterKFT");
                RepeaterPH = (Repeater) skin.FindControl("RepeaterPH");
                PanelQQ = (Panel) skin.FindControl("PanelQQ");
                PanelWW = (Panel) skin.FindControl("PanelWW");
                PanelPhone = (Panel) skin.FindControl("PanelPhone");
                Lab_Phone = (Label) skin.FindControl("Lab_Phone");
                PanelShowServer = (Panel) skin.FindControl("PanelShowServer");
                if (!Page.IsPostBack)
                {
                    BindData();
                }
                method_1();
                BindData();
                if (RepeaterWW != null)
                {
                    method_2();
                }
            }
        }

        protected void BindData()
        {
            string_1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            if (string_1 != "0")
            {
                DataTable memSimpleByShopID =
                    ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                        ShopSettings.GetValue("PersonShopUrl") + string_1);
                if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                {
                    string str = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    string path = "~/Shop/Shop/" + str.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                                  string_1 + "/Site_Settings.xml";
                    var set = new DataSet();
                    set.ReadXml(Page.Server.MapPath(path));
                    DataRow row = set.Tables["Setting"].Rows[0];
                    if (row["ShowCustomer"].ToString() == "1")
                    {
                        PanelShowServer.Visible = true;
                    }
                    else if (row["ShowCustomer"].ToString() == "0")
                    {
                        PanelShowServer.Visible = false;
                    }
                    if (row["IsOpenServicePhone"].ToString() != "1")
                    {
                        PanelPhone.Visible = false;
                    }
                    else
                    {
                        PanelPhone.Visible = true;
                        Lab_Phone.Text = row["ServicePhone"].ToString();
                    }
                }
            }
        }

        protected void method_1()
        {
            DataTable table = shop_OnLineService_Action_0.GetOnLineServiceList1(MemLoginID, "QQ", ShowCount.ToString());
            if (table.Rows.Count > 0)
            {
                RepeaterQQ.DataSource = table;
                RepeaterQQ.DataBind();
            }
            else
            {
                PanelQQ.Visible = false;
                RepeaterQQ.Visible = false;
            }
        }

        protected void method_2()
        {
            DataTable table = shop_OnLineService_Action_0.GetOnLineServiceList1(MemLoginID, "WW", ShowCount.ToString());
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterWW.DataSource = table;
                RepeaterWW.DataBind();
            }
            else
            {
                PanelWW.Visible = false;
                RepeaterWW.Visible = false;
            }
        }
    }
}