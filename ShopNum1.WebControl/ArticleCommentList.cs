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
    public class ArticleCommentList : BaseWebControl
    {
        private DataList DataListArticleCommentList;
        private Label LabelPageMessage;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ArticleCommentList.ascx";

        public ArticleCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string guid { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            DataListArticleCommentList = (DataList) skin.FindControl("DataListArticleCommentList");
            if (!Page.IsPostBack)
            {
            }
            string text1 = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action()).Search(
                    Page.Request.QueryString["guid"], -1, 1, Convert.ToInt32(ShowCount));
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true,
                PageSize = Convert.ToInt32(ShowCount)
            };
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
            lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage);
            lnkPrev.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[] {"?Page=", Convert.ToInt32((currentPage - 1)), "&guid=", guid}));
            lnkFirst.NavigateUrl = GetPageName.GetPage("?Page=1&guid=" + guid);
            lnkNext.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[] {"?Page=", Convert.ToInt32((currentPage + 1)), "&guid=", guid}));
            lnkLast.NavigateUrl =
                GetPageName.GetPage(string.Concat(new object[] {"?Page=", source.PageCount, "&guid=", guid}));
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
            DataListArticleCommentList.DataSource = source;
            DataListArticleCommentList.DataBind();
        }
    }
}