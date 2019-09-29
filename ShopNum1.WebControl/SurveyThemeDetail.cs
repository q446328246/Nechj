using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SurveyThemeDetail : BaseWebControl
    {
        private Label LabelAllCount1;
        private Label LabelAllCount2;
        private Label LabelTitle;
        private Repeater RepeaterSurveyThemeDetail;
        private string skinFilename = "SurveyThemeDetail.ascx";

        public SurveyThemeDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterSurveyThemeDetail = (Repeater) skin.FindControl("RepeaterSurveyThemeDetail");
            LabelAllCount1 = (Label) skin.FindControl("LabelAllCount1");
            LabelAllCount2 = (Label) skin.FindControl("LabelAllCount2");
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            RepeaterSurveyThemeDetail.ItemDataBound += RepeaterSurveyThemeDetail_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            string str = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (str != "0")
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_SurveyTheme_Action) LogicFactory.CreateShopNum1_SurveyTheme_Action()).SearchSurveyOption(
                    Page.Request.QueryString["guid"].Replace("'", ""));
            RepeaterSurveyThemeDetail.DataSource = table.DefaultView;
            RepeaterSurveyThemeDetail.DataBind();
            LabelAllCount1.Text = table.Rows[0]["AllCount"].ToString();
            LabelAllCount2.Text = table.Rows[0]["AllCount"].ToString();
            LabelTitle.Text = table.Rows[0]["Title"].ToString();
        }

        protected void RepeaterSurveyThemeDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string str = "10";
                string str2 = "10";
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCount");
                var label = (Label) e.Item.FindControl("LabelShow");
                label.Text = "<hr size=" + str + " width=" + field.Value + " color=" + str2 + ">";
            }
        }
    }
}