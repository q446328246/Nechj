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
    public class VideoList : BaseWebControl
    {
        private Label LabelPageMessage;
        private Repeater RepeaterData;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "VideoList.ascx";

        public string Keyword { get; set; }

        public int PageCount { get; set; }

        public string VideoCategoryID { get; set; }

        protected void BindData()
        {
            var action = (ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action();
            int pageCount = 1;
            try
            {
                pageCount = Convert.ToInt32(Common.Common.ReqStr("PageID"));
            }
            catch
            {
            }
            var pl = new PageList1
            {
                PageSize = PageCount,
                PageID = pageCount
            };
            DataTable table = action.SearchVideoList("0", PageCount.ToString(), pageCount.ToString(),
                Common.Common.ReqStr("type"), Common.Common.ReqStr("guid"));
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("Video_ListV82", true)
                {
                    ShowRecordCount = true,
                    ShowPageCount = false,
                    ShowPageIndex = false,
                    //ShowRecordCount = false,
                    ShowNoRecordInfo = false,
                    ShowNumListButton = true,
                    PrevPageText = "上一页",
                    NextPageText = "下一页 "
                }.GetPageListVk(pl);
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (pageCount > pl.PageCount)
            {
                pageCount = pl.PageCount;
            }
            DataTable table2 = action.SearchVideoList("1", PageCount.ToString(), pageCount.ToString(),
                Common.Common.ReqStr("type"), Common.Common.ReqStr("guid"));
            RepeaterData.DataSource = table2.DefaultView;
            RepeaterData.DataBind();
        }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }

            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            VideoCategoryID = (Page.Request.QueryString["guid"] == null)
                ? "-1"
                : Page.Request.QueryString["guid"];
            if (Page.Request.QueryString["guid"] == null)
            {
                VideoCategoryID = (Page.Request.QueryString["CategoryID"] == null)
                    ? "-1"
                    : Page.Request.QueryString["CategoryID"];
            }
            Keyword = (Page.Request.QueryString["keyword"] == null)
                ? ""
                : Page.Request.QueryString["keyword"];
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }
    }
}