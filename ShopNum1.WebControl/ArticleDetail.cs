using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleDetail : BaseWebControl
    {
        private HiddenField HiddenFieldGuid;
        private Repeater RepeaterArticleDetail;
        private Repeater RepeaterOnAndNext;
        private string skinFilename = "ArticleDetail.ascx";
        private string string_1 = "上一篇：";
        private string string_2 = "下一篇：";

        public ArticleDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string NextArticleName
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string OnArticleName
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterArticleDetail = (Repeater) skin.FindControl("RepeaterArticleDetail");
            RepeaterOnAndNext = (Repeater) skin.FindControl("RepeaterOnAndNext");
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            if (!Page.IsPostBack)
            {
            }
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (HiddenFieldGuid.Value != "0")
            {
                BindData();
            }
        }

        protected void BindData()
        {
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            DataTable editInfo = action.GetEditInfo("'" + HiddenFieldGuid.Value + "'");
            if ((editInfo != null) && (editInfo.Rows.Count > 0))
            {
                RepeaterArticleDetail.DataSource = editInfo.DefaultView;
                RepeaterArticleDetail.DataBind();
                action.UpdateClickCount(HiddenFieldGuid.Value);
            }
            RepeaterOnAndNext.DataSource = action.GetArticleOnAndNext(HiddenFieldGuid.Value, string_1, string_2);
            RepeaterOnAndNext.DataBind();
        }
    }
}