﻿using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ThemeList : BaseShopWebControl
    {
        public static DataTable dt_GroupProduct = null;

        private readonly ShopNum1_Activity_Action shopNum1_Activity_Action_0 =
            ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action());

        private readonly Shop_GroupProduct_Action shop_GroupProduct_Action_0 = new Shop_GroupProduct_Action();

        private HtmlGenericControl pageDiv;

        private string skinFilename = "S_ThemeList.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;

        public S_ThemeList()
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
            DataTable table = shopNum1_Activity_Action_0.SelectShopThemeActivty(PageSize.ToString(), currentpage,
                " group by A.Guid,A.ThemeTitle,A.ThemeDescription,A.ThemeStatus,A.CreateTime,A.StartDate,A.EndDate",
                "0");
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = Convert.ToInt32(currentpage)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = table.Rows.Count;
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("shop/ShopAdmin/S_ThemeList.aspx", true).GetPageListNew(pl);
            dt_GroupProduct = shopNum1_Activity_Action_0.SelectShopThemeActivty(PageSize.ToString(), currentpage,
                " group by A.Guid,A.ThemeTitle,A.ThemeDescription,A.ThemeStatus,A.CreateTime,A.StartDate,A.EndDate",
                "1");
            if (dt_GroupProduct.Rows.Count == 0)
            {
                dt_GroupProduct = null;
            }
        }
    }
}