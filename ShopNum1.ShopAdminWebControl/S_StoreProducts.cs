using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_StoreProducts : BaseShopWebControl
    {
        public static DataTable dt_ShowStoreProduct;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_StoreProduct.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;

        public S_StoreProducts()
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
            string_5 = Common.Common.ReqStr("shopct");
            if (!Page.IsPostBack)
            {
                BindData();
                method_2();
            }
        }

        protected void BindData()
        {
            var action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            if ((Common.Common.ReqStr("sign") == "del") && (Common.Common.ReqStr("del") != ""))
            {
                action.DeleteShopProduct(Common.Common.ReqStr("del"), base.MemLoginID);
            }
        }

        private string method_1()
        {
            var builder = new StringBuilder();
            builder.Append(" and memloginid='" + base.MemLoginID + "' and issell=0 and isdeleted=0 and issaled=1 ");
            if (string_5 != "")
            {
                builder.Append(" and productseriescode like '%" + HttpUtility.HtmlDecode(string_5).Replace("%2f", "/") +
                               "%' ");
            }
            if (string_1 != "")
            {
                builder.Append(" and name like '%" + HttpUtility.HtmlDecode(string_1).Replace("%2f", "/") + "%' ");
            }
            if (string_2 != "")
            {
                builder.Append(" and productnum like '%" + HttpUtility.HtmlDecode(string_2).Replace("%2f", "/") + "%' ");
            }
            return builder.ToString();
        }

        protected void method_2()
        {
            var action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            if (PageSize.ToString() == "")
            {
                PageSize = 10;
            }
            string strCurrentPage = Common.Common.ReqStr("PageID");
            if (strCurrentPage == "")
            {
                strCurrentPage = "1";
            }
            DataTable table = action.GetProductList(PageSize.ToString(), strCurrentPage, method_1(), "0");
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = Convert.ToInt32(strCurrentPage)
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
                new PageListBll("shop/ShopAdmin/S_StoreProduct.aspx", true).GetPageListNew(pl);
            dt_ShowStoreProduct = action.GetProductList(PageSize.ToString(), strCurrentPage, method_1(), "1");
            if (dt_ShowStoreProduct.Rows.Count == 0)
            {
                dt_ShowStoreProduct = null;
            }
        }
    }
}