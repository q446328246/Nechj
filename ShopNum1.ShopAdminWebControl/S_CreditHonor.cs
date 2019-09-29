using System;
using System.Data;
using System.Linq;
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
    public class S_CreditHonor : BaseShopWebControl
    {
        private HtmlGenericControl divPage;
        private DataTable dt;
        private HtmlInputHidden hidAttitude;
        private HtmlInputHidden hidCharacter;
        private HtmlInputHidden hidSpeed;
        private Label lblAllTotal;
        private Label lblBadTotal;
        private Label lblGoodRate;
        private Label lblGoodTotal;
        private Label lblMiddleTotal;
        private Label lblMonthBad;
        private Label lblMonthGood;
        private Label lblMonthMiddle;
        private Label lblMonthTotal;
        private Label lblSixBMonthBad;
        private Label lblSixBMonthGood;
        private Label lblSixBMonthMiddle;
        private Label lblSixBMonthTotal;
        private Label lblSixRMonthBad;
        private Label lblSixRMonthGood;
        private Label lblSixRMonthMiddle;
        private Label lblSixRMonthTotal;
        private Label lblWeekBad;
        private Label lblWeekGood;
        private Label lblWeekMiddle;
        private Label lblWeekTotal;
        private Repeater repBingComment;
        private string skinFilename = "S_CreditHonor.ascx";

        public S_CreditHonor()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            hidSpeed = (HtmlInputHidden) skin.FindControl("hidSpeed");
            hidCharacter = (HtmlInputHidden) skin.FindControl("hidCharacter");
            hidAttitude = (HtmlInputHidden) skin.FindControl("hidAttitude");
            divPage = (HtmlGenericControl) skin.FindControl("divPage");
            repBingComment = (Repeater) skin.FindControl("repBingComment");
            lblGoodRate = (Label) skin.FindControl("lblGoodRate");
            lblWeekGood = (Label) skin.FindControl("lblWeekGood");
            lblWeekMiddle = (Label) skin.FindControl("lblWeekMiddle");
            lblWeekBad = (Label) skin.FindControl("lblWeekBad");
            lblWeekTotal = (Label) skin.FindControl("lblWeekTotal");
            lblMonthGood = (Label) skin.FindControl("lblMonthGood");
            lblMonthMiddle = (Label) skin.FindControl("lblMonthMiddle");
            lblMonthBad = (Label) skin.FindControl("lblMonthBad");
            lblMonthTotal = (Label) skin.FindControl("lblMonthTotal");
            lblSixBMonthGood = (Label) skin.FindControl("lblSixBMonthGood");
            lblSixBMonthMiddle = (Label) skin.FindControl("lblSixBMonthMiddle");
            lblSixBMonthBad = (Label) skin.FindControl("lblSixBMonthBad");
            lblSixBMonthTotal = (Label) skin.FindControl("lblSixBMonthTotal");
            lblSixRMonthGood = (Label) skin.FindControl("lblSixRMonthGood");
            lblSixRMonthMiddle = (Label) skin.FindControl("lblSixRMonthMiddle");
            lblSixRMonthBad = (Label) skin.FindControl("lblSixRMonthBad");
            lblSixRMonthTotal = (Label) skin.FindControl("lblSixRMonthTotal");
            lblGoodTotal = (Label) skin.FindControl("lblGoodTotal");
            lblMiddleTotal = (Label) skin.FindControl("lblMiddleTotal");
            lblBadTotal = (Label) skin.FindControl("lblBadTotal");
            lblAllTotal = (Label) skin.FindControl("lblAllTotal");
            var action = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            if (!Page.IsPostBack)
            {
                BindData();
                string goodRate = action.GetGoodRate(base.MemLoginID, "4");
                DataTable shopCommentCount = action.GetShopCommentCount(base.MemLoginID, "1");
                if (goodRate != "")
                {
                    lblGoodRate.Text = goodRate.Split(new[] {'|'})[0];
                    hidSpeed.Value = goodRate.Split(new[] {'|'})[1];
                    hidCharacter.Value = goodRate.Split(new[] {'|'})[2];
                    hidAttitude.Value = goodRate.Split(new[] {'|'})[3];
                }
                if (shopCommentCount.Rows.Count > 0)
                {
                    lblWeekGood.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "' and CommentType='5'")
                            .Count()
                            .ToString();
                    lblWeekMiddle.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "' and CommentType='3'")
                            .Count()
                            .ToString();
                    lblWeekBad.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "' and CommentType='1'")
                            .Count()
                            .ToString();
                    lblWeekTotal.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "'").Count().ToString();
                    lblMonthGood.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "' and CommentType='5'")
                            .Count()
                            .ToString();
                    lblMonthMiddle.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "' and CommentType='3'")
                            .Count()
                            .ToString();
                    lblMonthBad.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "' and CommentType='1'")
                            .Count()
                            .ToString();
                    lblMonthTotal.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "'").Count().ToString();
                    lblSixBMonthGood.Text =
                        shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "' and CommentType='5'")
                            .Count()
                            .ToString();
                    lblSixBMonthMiddle.Text =
                        shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "' and CommentType='3'")
                            .Count()
                            .ToString();
                    lblSixBMonthBad.Text =
                        shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "' and CommentType='1'")
                            .Count()
                            .ToString();
                    lblSixBMonthTotal.Text =
                        shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "'").Count().ToString();
                    lblSixRMonthGood.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "' and CommentType='5'")
                            .Count()
                            .ToString();
                    lblSixRMonthMiddle.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "' and CommentType='3'")
                            .Count()
                            .ToString();
                    lblSixRMonthBad.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "' and CommentType='1'")
                            .Count()
                            .ToString();
                    lblSixRMonthTotal.Text =
                        shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "'").Count().ToString();
                    lblGoodTotal.Text = shopCommentCount.Select("CommentType='5'").Count().ToString();
                    lblMiddleTotal.Text = shopCommentCount.Select("CommentType='3'").Count().ToString();
                    lblBadTotal.Text = shopCommentCount.Select("CommentType='1'").Count().ToString();
                    lblAllTotal.Text = shopCommentCount.Rows.Count.ToString();
                }
            }
        }

        protected void BindData()
        {
            string strCondition = string.Empty;
            strCondition = " and shoploginid='" + base.MemLoginID + "' and isaudit=1 ";
            int num = 10;
            var action = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            int num2 = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num2 = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(action.SelectShopComment(num.ToString(), num2.ToString(), strCondition, "0").Rows[0][0]);
            
            var bll = new PageListBll("shop/shopadmin/S_CreditHonor.aspx", true);
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