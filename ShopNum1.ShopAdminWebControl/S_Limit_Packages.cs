using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Limit_Packages : BaseShopWebControl
    {
        public static DataTable dt_LimitPackages = null;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_Limit_Packages.ascx";

        public S_Limit_Packages()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            var action = new Shop_LimtPackages_Action();
            string condition = " and Memloginid='" + base.MemLoginID + "'";
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(action.SelectLimtPackage(PageSize.ToString(), num.ToString(), condition, "0").Rows[0][0]);
            var bll = new PageListBll("shop/ShopAdmin/S_Limit_Packages.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = num,
                RecordCount = num3
            };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt_LimitPackages = action.SelectLimtPackage(PageSize.ToString(), num.ToString(), condition, "1");
        }
    }
}