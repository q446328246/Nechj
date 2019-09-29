using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_FeedBack : BaseMemberControl
    {
        private DataTable dt;


        protected void Page_Load(object sender, EventArgs e)
        {
            var action1 = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            string strCondition = " and memloginid='" + base.MemLoginID + "'";
            if (Common.Common.ReqStr("type") == "1")
            {
                strCondition = strCondition + " and reply!=''";
            }
            int num = 10;
            var action = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            int num2 = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num2 = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(action.SelectShopComment(num.ToString(), num2.ToString(), strCondition, "0").Rows[0][0]);
            var bll = new PageListBll("main/member/M_FeedBack.aspx", true);
            var pl = new PageList1
            {
                PageSize = num,
                PageID = num2,
                RecordCount = num3
            };
            divPage.InnerHtml = bll.GetPageListNew(pl);
            dt = action.SelectShopComment(num.ToString(), num2.ToString(), strCondition, "1");
            repBingComment.DataSource = dt.DefaultView;
            repBingComment.DataBind();
        }
    }
}