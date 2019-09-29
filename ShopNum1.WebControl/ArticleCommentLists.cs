using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleCommentLists : BaseWebControl
    {
        private Label LabelPageMessage;
        private Repeater RepeaterArticleCommentList;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ArticleCommentLists.ascx";

        public ArticleCommentLists()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string guid { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            RepeaterArticleCommentList = (Repeater) skin.FindControl("RepeaterArticleCommentList");
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
            var settings = new ShopSettings();
            string str = settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                "ArticleCommentCount");
            DataTable table =
                ((ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action()).Search(
                    Page.Request.QueryString["guid"], -1, 1, Convert.ToInt32(str));
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true
            };
            string str2 = settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                "ArticleCommentPageCount");
            source.PageSize = Convert.ToInt32(str2);
            int currentPage = -1;
            if (Page.Request.QueryString.Get("page") != null)
            {
                currentPage = Convert.ToInt32(Page.Request.QueryString.Get("page"));
            }
            else
            {
                currentPage = 1;
            }
            source.CurrentPageIndex = currentPage - 1;
            var common = new Num1WebControlCommon();
            LabelPageMessage.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize,
                currentPage);
            lnkTo.Text = common.AppendPage(Page, Page.Request.QueryString["guid"], source.PageCount, currentPage);
            lnkPrev.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[]
                    {"?Page=", Convert.ToInt32((currentPage - 1)), "&guid=", Page.Request.QueryString["guid"]}));
            lnkFirst.NavigateUrl = GetPageName.GetPage("?Page=1&guid=" + Page.Request.QueryString["guid"]);
            lnkNext.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[]
                    {"?Page=", Convert.ToInt32((currentPage + 1)), "&guid=", Page.Request.QueryString["guid"]}));
            lnkLast.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[] {"?Page=", source.PageCount, "&guid=", Page.Request.QueryString["guid"]}));
            if ((currentPage <= 1) && (source.PageCount <= 1))
            {
                lnkFirst.NavigateUrl = "";
                lnkPrev.NavigateUrl = "";
                lnkNext.NavigateUrl = "";
                lnkLast.NavigateUrl = "";
            }
            if ((currentPage <= 1) && (source.PageCount > 1))
            {
                lnkFirst.NavigateUrl = "";
                lnkPrev.NavigateUrl = "";
            }
            if (currentPage >= source.PageCount)
            {
                lnkNext.NavigateUrl = "";
                lnkLast.NavigateUrl = "";
            }
            RepeaterArticleCommentList.DataSource = source;
            RepeaterArticleCommentList.DataBind();
        }
    }
}