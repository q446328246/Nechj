using System;
using System.Data;
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
    public class S_Limit_ActivityList : BaseShopWebControl
    {
        public static DataTable dt_LimitActivity = null;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_Limit_ActivityList.ascx";

        public S_Limit_ActivityList()
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
                if ((Common.Common.ReqStr("lid") != "") && (Common.Common.ReqStr("sign") == "del"))
                {
                    new Shop_LimtPackages_Action().DeletePackById(base.MemLoginID, Common.Common.ReqStr("lid"));
                }
                BindData();
            }
        }

        protected void BindData()
        {
            var action = (ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action();
            string condition = " and MemloginId='" + base.MemLoginID + "' and type=2";
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(action.SelectActivity(PageSize.ToString(), num.ToString(), condition, "0").Rows[0][0]);
            var bll = new PageListBll("shop/ShopAdmin/S_Limit_ActivityList.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = num,
                RecordCount = num3
            };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt_LimitActivity = action.SelectActivity(PageSize.ToString(), num.ToString(), condition, "1");
            if (dt_LimitActivity.Rows.Count == 0)
            {
                dt_LimitActivity = null;
            }
        }
    }
}