using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Limit_ActivityOpreate : BaseShopWebControl
    {
        private readonly ShopNum1_Activity_Action shopNum1_Activity_Action_0 =
            ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action());

        private readonly ShopNum1_Product_Activity shopNum1_Product_Activity_0 = new ShopNum1_Product_Activity();
        private Button btnSub;
        private Shop_LimtPackages_Action shop_LimtPackages_Action_0 = new Shop_LimtPackages_Action();

        private string skinFilename = "S_Limit_ActivityOpreate.ascx";
        private HtmlInputText txtDisCount;
        private HtmlInputText txtEndTime;
        private HtmlInputText txtName;
        private HtmlInputText txtStartTime;

        public S_Limit_ActivityOpreate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            shopNum1_Product_Activity_0.Name = txtName.Value;
            shopNum1_Product_Activity_0.StartTime = Convert.ToDateTime(txtStartTime.Value);
            shopNum1_Product_Activity_0.EndTime = Convert.ToDateTime(txtEndTime.Value);
            shopNum1_Product_Activity_0.Type = 2;
            shopNum1_Product_Activity_0.Discount = Convert.ToDecimal(txtDisCount.Value);
            shopNum1_Product_Activity_0.LimitProduct = Convert.ToInt32(ShopSettings.GetValue("Limit_GoodsCount"));
            shopNum1_Product_Activity_0.MemloginId = base.MemLoginID;
            shopNum1_Product_Activity_0.ShopName = Common.Common.GetNameById("shopname", "shopnum1_shopinfo",
                " and memloginid='" + base.MemLoginID + "'");
            shopNum1_Activity_Action_0.AddActivity(shopNum1_Product_Activity_0);
            Page.Response.Redirect("S_Limit_ActivityList.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            txtName = (HtmlInputText) skin.FindControl("txtName");
            txtStartTime = (HtmlInputText) skin.FindControl("txtStartTime");
            txtEndTime = (HtmlInputText) skin.FindControl("txtEndTime");
            txtDisCount = (HtmlInputText) skin.FindControl("txtDisCount");
            btnSub = (Button) skin.FindControl("btnSub");
            btnSub.Click += btnSub_Click;
            if (!Page.IsPostBack)
            {
            }
        }
    }
}