using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ProductBookingDetail : BaseShopWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "S_ProductBookingDetail.ascx";
        private string string_1 = string.Empty;

        public S_ProductBookingDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            var btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += method_0;
            string_1 = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("Guid");
        }

        public static string IsAudit(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void method_0(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ProductBookingList.aspx");
        }

        protected void method_1()
        {
            RepeaterData.DataSource =
                ((Shop_ProductBooking_Action) LogicFactory.CreateShop_ProductBooking_Action()).GetProductBooking(
                    string_1);
            RepeaterData.DataBind();
        }
    }
}