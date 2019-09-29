using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleSearch : BaseWebControl
    {
        private readonly string string_0 = GetPageName.RetDomainUrl("ArticleListSearch");
        private Button button_0;
        private HiddenField hiddenField_0;
        private HtmlGenericControl htmlGenericControl_0;
        private Label label_0;
        private Repeater repeater_0;
        private string string_1 = "ArticleSearch.ascx";

        private TextBox textBox_0;

        public ArticleSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_1;
            }
        }

        private string pageID { get; set; }
        public string PageSize { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCategoryID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            repeater_0 = (Repeater) skin.FindControl("RepeaterData");
            htmlGenericControl_0 = (HtmlGenericControl) skin.FindControl("pageDiv");
            label_0 = (Label) skin.FindControl("LabelPageCount");
            textBox_0 = (TextBox) skin.FindControl("TextBoxIndex");
            button_0 = (Button) skin.FindControl("ButtonSure");
            hiddenField_0 = (HiddenField) skin.FindControl("HiddenFieldSearchName");
            button_0.Click += button_0_Click;
            ArticleName = ((Page.Request.QueryString["search"] == null) ? "-1" : Page.Request.QueryString["search"]);
            hiddenField_0.Value = ((Page.Request.QueryString["search"] == null)
                ? Page.Request.QueryString["Category"]
                : Page.Request.QueryString["search"]);
            if (hiddenField_0.Value == "" || hiddenField_0.Value == "-1")
            {
                hiddenField_0.Value = "咨询";
            }
            ArticleCategoryID = ((Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"]);
            if (!Page.IsPostBack)
            {
            }
            pageID = "1";
            try
            {
                pageID = Page.Request.QueryString["PageID"];
            }
            catch
            {
                pageID = "1";
            }
            BindData();
        }

        protected void button_0_Click(object sender, EventArgs e)
        {
            string text = textBox_0.Text.Trim();
            Page.Response.Redirect(string.Concat(new[]
            {
                string_0,
                "?search=",
                ArticleName,
                "&guid=",
                ArticleCategoryID,
                "&pageid=",
                text
            }));
        }

        protected void BindData()
        {
            ArticleCategoryID = ArticleCategoryID.Replace("'", "");
            var pageList = new PageList1();
            pageList.PageSize = Convert.ToInt32(PageSize);
            pageList.PageID = Convert.ToInt32(pageID);
            var shopNum1_Article_Action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            DataTable dataTable = shopNum1_Article_Action.SearchArticle(ArticleName, ArticleCategoryID, pageID, PageSize,
                "1");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            else
            {
                pageList.RecordCount = 0;
            }
            var pageListBll = new PageListBll("ArticleListSearch", true);
            pageListBll.ShowRecordCount = true;
            pageListBll.ShowPageCount = false;
            pageListBll.ShowPageIndex = false;
            pageListBll.ShowRecordCount = false;
            pageListBll.ShowNoRecordInfo = false;
            pageListBll.ShowNumListButton = true;
            pageListBll.PrevPageText = "上一页";
            pageListBll.NextPageText = "下一页 ";
            textBox_0.Text = pageID;
            htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
            label_0.Text = pageList.PageCount.ToString();
            if (pageList.PageCount < pageList.RecordCount/(double) pageList.PageSize)
            {
                PageList1 expr_162 = pageList;
                expr_162.PageCount = expr_162.PageCount + 1;
            }
            if (Convert.ToInt32(pageID) > pageList.PageCount)
            {
                pageID = pageList.PageCount.ToString();
            }
            DataTable dataTable2 = shopNum1_Article_Action.SearchArticle(ArticleName, ArticleCategoryID, pageID,
                PageSize, "0");
            if (dataTable2 != null && dataTable2.Rows.Count > 0)
            {
                repeater_0.DataSource = dataTable2;
                repeater_0.DataBind();
            }
            else
            {
                string url = GetPageName.AgentRetUrl("ArticleSearchNofind", ArticleName, "search");
                Page.Response.Redirect(url);
            }
        }
    }
}