using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_FeedBack : BaseMemberWebControl
    {
        private HtmlGenericControl divPage;
        private DataTable dt;
        private Repeater repBingComment;
        private string skinFilename = "M_FeedBack.ascx";

        public M_FeedBack()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            divPage = (HtmlGenericControl) skin.FindControl("divPage");
            repBingComment = (Repeater) skin.FindControl("repBingComment");
            var action1 = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
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