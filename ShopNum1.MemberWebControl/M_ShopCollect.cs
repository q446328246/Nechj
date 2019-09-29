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

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_ShopCollect : BaseMemberWebControl
    {
        private Repeater RepeaterShow;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_ShopCollect.ascx";

        public M_ShopCollect()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public static string GetShopNameByShopId(string ShopID)
        {
            string str = Common.Common.GetNameById("ShopName", "ShopNum1_ShopInfo", "   AND  ShopID='" + ShopID + "'");
            if (!string.IsNullOrEmpty(str))
            {
                return str;
            }
            return ShopID;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            BindData();
        }

        private void BindData()
        {
            var action = (Shop_Collect_Action) LogicFactory.CreateShop_Collect_Action();
            var commonModel = new CommonPageModel
            {
                Condition = "   AND  MemLoginID='" + base.MemLoginID + "'  ",
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_MyCollect.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = null;
            table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}