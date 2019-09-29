using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Limit_BuyPackage : BaseShopWebControl
    {
        private Button btnSub;
        private string skinFilename = "S_Limit_BuyPackage.ascx";
        private HtmlInputText txtNum;

        public S_Limit_BuyPackage()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            string str = ShopSettings.GetValue("Limit_Money");
            string str2 = ShopSettings.GetValue("Limit_ActivityCount");
            string str3 = ShopSettings.GetValue("Limit_GoodsCount");
            int months = Convert.ToInt32(txtNum.Value);
            var package = new ShopNum1_Limt_Package
            {
                Name = "限制折扣套餐",
                StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                EndTime = DateTime.Now.AddMonths(months),
                BuyNum = months,
                PayMoney = Convert.ToDecimal((months*Convert.ToDecimal(str))),
                LeaveNum = Convert.ToInt32(str2),
                LimtActivityNum = Convert.ToInt32(str2),
                LimitProductNum = Convert.ToInt32(str3),
                MemloginId = base.MemLoginID,
                ShopName =
                    Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and name='" + base.MemLoginID + "'")
            };
            new Shop_LimtPackages_Action().AddLimtPackage(package);
            Page.Response.Redirect("S_Limit_Packages.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            btnSub = (Button) skin.FindControl("btnSub");
            btnSub.Click += btnSub_Click;
            txtNum = (HtmlInputText) skin.FindControl("txtNum");
        }
    }
}