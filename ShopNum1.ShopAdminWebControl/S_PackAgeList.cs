using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_PackAgeList : BaseShopWebControl
    {
        public static DataTable dt_PackAgeList = null;
        private HtmlGenericControl pageDiv;
        private Repeater repPackAge;
        private string skinFilename = "S_PackAgeList.ascx";

        public S_PackAgeList()
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
            repPackAge = (Repeater) skin.FindControl("repPackAge");
            if (!Page.IsPostBack)
            {
                BindData();
                method_1();
            }
        }

        protected void BindData()
        {
            if ((Common.Common.ReqStr("del") != "") && (Common.Common.ReqStr("sign") != ""))
            {
                ((Shop_PackAge_Action) LogicFactory.CreateShop_PackAge_Action()).DeletePackAge(
                    Common.Common.ReqStr("del"), base.MemLoginID);
            }
        }

        protected void method_1()
        {
            var action = (Shop_PackAge_Action) LogicFactory.CreateShop_PackAge_Action();
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(
                    action.SelectPackAgeProduct(PageSize.ToString(), num.ToString(),
                        " and memloginid='" + base.MemLoginID + "'", "0", "desc", "createtime",
                        "*", "ShopNum1_PackAge t").Rows[0][0]);
            var bll = new PageListBll("shop/ShopAdmin/S_PackAgeList.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = num,
                RecordCount = num3
            };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt_PackAgeList = action.SelectPackAgeProduct(PageSize.ToString(), num.ToString(),
                " and memloginid='" + base.MemLoginID + "'", "1", "desc",
                "createtime",
                "id,memloginid,name,price,saleprice,pic,(case state when '0' then '未开启' else '已开启' end)statetxt,(select count(*) from ShopNum1_PackAgeRalate where PackAgeId=t.id)pcount",
                "ShopNum1_PackAge t");
            repPackAge.DataSource = dt_PackAgeList.DefaultView;
            repPackAge.DataBind();
        }
    }
}