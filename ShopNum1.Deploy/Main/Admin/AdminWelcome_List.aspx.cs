using System;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdminWelcome_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.CheckLogin();
                GetAdminWelcomeInfo();
            }
            catch
            {
            }
        }

        protected void GetAdminWelcomeInfo()
        {
            string strApplyTime = DateTime.Now.ToString("yyyy-MM-dd");
            var action = new ShopNum1_AdminWelcome_Action();
            string str2 = string.Empty;
            if (Page.Request.Cookies["AdminLoginDateCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["AdminLoginDateCookie"];
                str2 = HttpSecureCookie.Decode(cookie).Values["LastLoginTime"];
            }
            else
            {
                str2 = DateTime.Now.ToString();
            }
            LabelLastLoginTime.Text = str2;
            string str3 = ShopSettings.GetValue("ShopNum1Version");
            LabelVersion.Text = str3;
            LabelForCount.Text = action.SearchOrderForDispatch("", "", "", 2);
            LabelForDispatchCount.Text = action.SearchOrderForDispatch("1", "", "", 10);
            LabelForConfirmCount.Text = action.SearchOrderForDispatch("2", "", "", 10);
            LabelForPayCount.Text = action.SearchOrderForDispatch("0", "", "0", 10);
            LabelFinishedCount.Text = action.SearchOrderForDispatch("3", string.Empty, string.Empty, 10);
            LabelProductCount.Text = action.SearchProductCount(0);
            LabelAuditProductCount.Text = action.SearchAuditProductCount(0, 0);
            LabelPanicBuyProductCount.Text = action.SearchActivityProductCount("1", "1", 2);
            LabelNewCount.Text = action.SearchRecommendCount(string.Empty, string.Empty, string.Empty, "1", 0);
            LabelBestCount.Text = action.SearchRecommendCount("1", string.Empty, string.Empty, string.Empty, 0);
            LabelHotCount.Text = action.SearchRecommendCount(string.Empty, "1", string.Empty, string.Empty, 0);
            LabelRecommendCount.Text = action.SearchRecommendCount(string.Empty, string.Empty, "1", string.Empty, 0);
            LabelMessageBoardCount.Text = action.SearchMessageBoardCount(0, 0);
            Label1MessageCount.Text = action.SearchMessageCount(0, 0);
            LabelArticleComment.Text = action.SearchArticleCommentCount(0, 0);
            LabelProductComment.Text = action.SearchProductCommentCount(0, 0);
            LabelAuditShopCount.Text = action.SearchRegisterShopCount(0, strApplyTime, 0);
            var action2 =
                (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            LabelMemApply.Text = action2.Search("", "", "", 1, 0, 0).Rows.Count.ToString();
            var action3 =
                (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            LabelPaymentApply.Text = action3.Search("", "", "", 0, 0, 0).Rows.Count.ToString();
            LabelMessageBoard.Text = action.SearchMessageBoardCount();
            var action1 = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            LabelDemandCheck.Text = Common.Common.GetNameById("count(*)", "ShopNum1_SupplyDemand", " AND isaudit=0");
            LabelProuductChecked.Text = action.SearchProuductCheckedCount();
            LabelProductCommentAudit.Text = action.SearchProductCommentCount();
            LabelOrderNow.Text = action.SearchOrderNowCount();
            LabelMemberAllCount.Text = action.SearchAllMemberCount(0);
            LabelShopAllCount.Text = action.SearchAllShopCount(0);
            if (action.SearchSaleInfo(strApplyTime, 0) == string.Empty)
            {
                LabelProductPriceCount.Text = "0.00";
            }
            else
            {
                LabelProductPriceCount.Text = action.SearchSaleInfo(strApplyTime, 0);
            }
            LabelBuyNumberCount.Text = action.SearchSaleProductCount(strApplyTime, 0);
            LabelMemberCount.Text = action.SearchRegisterMemberCount(strApplyTime, 0);
            LabelShopNowCount.Text = action.SearchShopNowCount();
        }
    }
}