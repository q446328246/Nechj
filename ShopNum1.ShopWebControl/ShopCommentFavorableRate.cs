using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopCommentFavorableRate : BaseWebControl
    {
        private Label LabelAll;
        private Label LabelAllOneMonth;
        private Label LabelAllPrevious;
        private Label LabelAllSixMonth;
        private Label LabelAllWeek;
        private Label LabelBadAll;
        private Label LabelBadOneMonth;
        private Label LabelBadPrevious;
        private Label LabelBadSixMonth;
        private Label LabelBadWeek;
        private Label LabelFavorableRate;
        private Label LabelGeneralAll;
        private Label LabelGeneralOneMonth;
        private Label LabelGeneralPrevious;
        private Label LabelGeneralSixMonth;
        private Label LabelGeneralWeek;
        private Label LabelGoodAll;
        private Label LabelGoodOneMonth;
        private Label LabelGoodPrevious;
        private Label LabelGoodSixMonth;
        private Label LabelGoodWeek;
        private string skinFilename = "ShopCommentFavorableRate.ascx";

        public ShopCommentFavorableRate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelFavorableRate = (Label) skin.FindControl("LabelFavorableRate");
            LabelGoodWeek = (Label) skin.FindControl("LabelGoodWeek");
            LabelGoodOneMonth = (Label) skin.FindControl("LabelGoodOneMonth");
            LabelGoodSixMonth = (Label) skin.FindControl("LabelGoodSixMonth");
            LabelGoodPrevious = (Label) skin.FindControl("LabelGoodPrevious");
            LabelGoodAll = (Label) skin.FindControl("LabelGoodAll");
            LabelGeneralWeek = (Label) skin.FindControl("LabelGeneralWeek");
            LabelGeneralOneMonth = (Label) skin.FindControl("LabelGeneralOneMonth");
            LabelGeneralSixMonth = (Label) skin.FindControl("LabelGeneralSixMonth");
            LabelGeneralPrevious = (Label) skin.FindControl("LabelGeneralPrevious");
            LabelGeneralAll = (Label) skin.FindControl("LabelGeneralAll");
            LabelBadWeek = (Label) skin.FindControl("LabelBadWeek");
            LabelBadOneMonth = (Label) skin.FindControl("LabelBadOneMonth");
            LabelBadSixMonth = (Label) skin.FindControl("LabelBadSixMonth");
            LabelBadPrevious = (Label) skin.FindControl("LabelBadPrevious");
            LabelBadAll = (Label) skin.FindControl("LabelBadAll");
            LabelAllWeek = (Label) skin.FindControl("LabelAllWeek");
            LabelAllOneMonth = (Label) skin.FindControl("LabelAllOneMonth");
            LabelAllSixMonth = (Label) skin.FindControl("LabelAllSixMonth");
            LabelAllPrevious = (Label) skin.FindControl("LabelAllPrevious");
            LabelAll = (Label) skin.FindControl("LabelAll");
            BindData();
        }

        protected void BindData()
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            LabelGoodWeek.Text = action.ShopComment("5", "1", shopid).Rows[0][0].ToString();
            LabelGoodOneMonth.Text = action.ShopComment("5", "2", shopid).Rows[0][0].ToString();
            LabelGoodSixMonth.Text = action.ShopComment("5", "3", shopid).Rows[0][0].ToString();
            LabelGoodPrevious.Text = action.ShopComment("5", "4", shopid).Rows[0][0].ToString();
            LabelGoodAll.Text = action.ShopComment("5", string.Empty, shopid).Rows[0][0].ToString();
            LabelGeneralWeek.Text = action.ShopComment("3", "1", shopid).Rows[0][0].ToString();
            LabelGeneralOneMonth.Text = action.ShopComment("3", "2", shopid).Rows[0][0].ToString();
            LabelGeneralSixMonth.Text = action.ShopComment("3", "3", shopid).Rows[0][0].ToString();
            LabelGeneralPrevious.Text = action.ShopComment("3", "4", shopid).Rows[0][0].ToString();
            LabelGeneralAll.Text = action.ShopComment("3", string.Empty, shopid).Rows[0][0].ToString();
            LabelBadWeek.Text = action.ShopComment("1", "1", shopid).Rows[0][0].ToString();
            LabelBadOneMonth.Text = action.ShopComment("1", "2", shopid).Rows[0][0].ToString();
            LabelBadSixMonth.Text = action.ShopComment("1", "3", shopid).Rows[0][0].ToString();
            LabelBadPrevious.Text = action.ShopComment("1", "4", shopid).Rows[0][0].ToString();
            LabelBadAll.Text = action.ShopComment("1", string.Empty, shopid).Rows[0][0].ToString();
            LabelAllWeek.Text = action.ShopComment(string.Empty, "1", shopid).Rows[0][0].ToString();
            LabelAllOneMonth.Text = action.ShopComment(string.Empty, "2", shopid).Rows[0][0].ToString();
            LabelAllSixMonth.Text = action.ShopComment(string.Empty, "3", shopid).Rows[0][0].ToString();
            LabelAllPrevious.Text = action.ShopComment(string.Empty, "4", shopid).Rows[0][0].ToString();
            LabelAll.Text = action.ShopComment(string.Empty, string.Empty, shopid).Rows[0][0].ToString();
            if (LabelAll.Text != "0")
            {
                LabelFavorableRate.Text = Convert.ToString(((int.Parse(LabelGoodAll.Text)*100)/int.Parse(LabelAll.Text)));
            }
            else
            {
                LabelFavorableRate.Text = "0";
            }
        }
    }
}