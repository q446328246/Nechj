using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopURLManage : BaseShopWebControl
    {
        private Repeater RepeaterShow;
        private HtmlGenericControl pageDiv;
        private HtmlTable showTable;
        private string skinFilename = "S_ShopURLManage.ascx";
        private HtmlAnchor wyss;

        public S_ShopURLManage()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public static string GetLongUrl(string string_3)
        {
            return (string_3 + ShopSettings.siteDomain.Substring(3));
        }

        public static string GetState(string value)
        {
            if (value == "0")
            {
                return "未审核";
            }
            if (value == "1")
            {
                return "审核通过";
            }
            if (value == "2")
            {
                return "审核未通过";
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            wyss = (HtmlAnchor) skin.FindControl("wyss");
            showTable = (HtmlTable) skin.FindControl("showTable");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_URLManage_Action) LogicFactory.CreateShop_URLManage_Action();
            string str = string.Empty;
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND  MemLoginID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
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
                new PageListBll("Shop/ShopAdmin/S_ShopURLManage.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                wyss.Visible = false;
                showTable.Visible = false;
            }
        }
    }
}