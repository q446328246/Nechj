using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_GroupProduct : BaseShopWebControl
    {
        public static DataTable dt_GroupProduct = null;
        private readonly Shop_GroupProduct_Action shop_GroupProduct_Action_0 = new Shop_GroupProduct_Action();
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_GroupProduct.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;

        public S_GroupProduct()
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
            string_1 = Common.Common.ReqStr("pn");
            string_2 = Common.Common.ReqStr("no");
            string_3 = Common.Common.ReqStr("sname");
            string_4 = Common.Common.ReqStr("stype");
            if (!Page.IsPostBack)
            {
                BindData();
                method_2();
            }
        }

        protected void BindData()
        {
            if ((Common.Common.ReqStr("sign") == "del") && (Common.Common.ReqStr("del") != ""))
            {
                shop_GroupProduct_Action_0.DeleteGroupProduct(Common.Common.ReqStr("del"), base.MemLoginID);
            }
        }

        private string method_1()
        {
            var builder = new StringBuilder();
            builder.Append(" AND MemloginId='" + base.MemLoginID + "'");
            return builder.ToString();
        }

        protected void method_2()
        {
            if (PageSize.ToString() == "")
            {
                PageSize = 10;
            }
            string currentpage = Common.Common.ReqStr("PageID");
            if (currentpage == "")
            {
                currentpage = "1";
            }
            DataTable table = shop_GroupProduct_Action_0.SelectActivity(PageSize.ToString(), currentpage, method_1(),
                "0");
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = Convert.ToInt32(currentpage)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("shop/ShopAdmin/S_GroupProduct.aspx", true).GetPageListNew(pl);
            dt_GroupProduct = shop_GroupProduct_Action_0.SelectActivity(PageSize.ToString(), currentpage, method_1(),
                "1");
            if (dt_GroupProduct.Rows.Count == 0)
            {
                dt_GroupProduct = null;
            }
        }
    }
}