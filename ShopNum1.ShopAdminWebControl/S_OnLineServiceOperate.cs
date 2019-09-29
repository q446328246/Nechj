using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_OnLineServiceOperate : BaseShopWebControl
    {
        private Button btn_Back;
        private Button btn_Save;
        private HtmlInputCheckBox check_IsShow;
        private HtmlInputHidden hid_TypeName;
        private HtmlInputHidden hid_TypeValue;
        private string skinFilename = "S_OnLineServiceOperate.ascx";
        private HtmlInputText txt_OnlineServiceID;
        private HtmlInputText txt_OnlineServiceName;
        private HtmlInputText txt_OrderID;

        public S_OnLineServiceOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Guid != "0")
            {
                BindData();
            }
            else
            {
                method_2();
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_OnLineServiceList.aspx?Type=1");
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_OnlineServiceName = (HtmlInputText) skin.FindControl("txt_OnlineServiceName");
            txt_OnlineServiceID = (HtmlInputText) skin.FindControl("txt_OnlineServiceID");
            txt_OrderID = (HtmlInputText) skin.FindControl("txt_OrderID");
            check_IsShow = (HtmlInputCheckBox) skin.FindControl("check_IsShow");
            hid_TypeName = (HtmlInputHidden) skin.FindControl("hid_TypeName");
            hid_TypeValue = (HtmlInputHidden) skin.FindControl("hid_TypeValue");
            btn_Save = (Button) skin.FindControl("btn_Save");
            btn_Save.Click += btn_Save_Click;
            btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += btn_Back_Click;
            Guid = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("Guid");
            if (Guid != "0")
            {
                method_1();
            }
            else
            {
                txt_OrderID.Value = (method_3() + 1).ToString();
            }
        }

        protected void BindData()
        {
            var onlineService = new ShopNum1_Shop_OnlineService
            {
                Guid = new Guid(Guid),
                Type = hid_TypeValue.Value,
                TypeName = hid_TypeName.Value,
                Name = txt_OnlineServiceName.Value,
                ServiceAccount = txt_OnlineServiceID.Value,
                OrderID = Convert.ToInt32(txt_OrderID.Value)
            };
            if (check_IsShow.Checked)
            {
                onlineService.IsShow = 1;
            }
            else
            {
                onlineService.IsShow = 0;
            }
            var action = (Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action();
            if (action.UpdateOnLineService(onlineService) > 0)
            {
                Page.Response.Redirect("S_OnLineServiceList.aspx?Type=1");
            }
        }

        protected void method_1()
        {
            DataTable onLineService =
                ((Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action()).GetOnLineService(Guid);
            hid_TypeValue.Value = onLineService.Rows[0]["Type"].ToString();
            hid_TypeName.Value = onLineService.Rows[0]["TypeName"].ToString();
            txt_OnlineServiceName.Value = onLineService.Rows[0]["Name"].ToString();
            txt_OnlineServiceID.Value = onLineService.Rows[0]["ServiceAccount"].ToString();
            txt_OrderID.Value = onLineService.Rows[0]["OrderID"].ToString();
            if (onLineService.Rows[0]["IsShow"].ToString() == "1")
            {
                check_IsShow.Checked = true;
            }
            else
            {
                check_IsShow.Checked = false;
            }
        }

        protected void method_2()
        {
            var onlineService = new ShopNum1_Shop_OnlineService
            {
                Guid = System.Guid.NewGuid(),
                Type = hid_TypeValue.Value,
                TypeName = hid_TypeName.Value,
                Name = txt_OnlineServiceName.Value,
                ServiceAccount = txt_OnlineServiceID.Value,
                OrderID = Convert.ToInt32(txt_OrderID.Value)
            };
            if (check_IsShow.Checked)
            {
                onlineService.IsShow = 1;
            }
            else
            {
                onlineService.IsShow = 0;
            }
            onlineService.MemLoginID = base.MemLoginID;
            var action = (Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action();
            if (action.AddOnLineService(onlineService) > 0)
            {
                Page.Response.Redirect("S_OnLineServiceList.aspx?type=1");
            }
        }

        private int method_3()
        {
            return Common.Common.ReturnMaxID("OrderID", "MemLoginID", base.MemLoginID, "ShopNum1_Shop_OnlineService");
        }
    }
}