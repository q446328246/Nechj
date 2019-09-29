using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class VideoCommentList : BaseWebControl
    {
        private Label LabelPageMessage;
        private Repeater RepeaterData;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "VideoCommentList.ascx";

        public VideoCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public string PageCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            Guid = (Page.Request.QueryString["Guid"] == null) ? "" : Page.Request.QueryString["Guid"];
            if (!Page.IsPostBack)
            {
            }
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            if ((Page.Request.QueryString["guid"] != null) && (Page.Request.QueryString["ShopID"] != null))
            {
                BindData(Page.Request.QueryString["guid"], Page.Request.QueryString["ShopID"]);
            }
        }

        protected void BindData(string string_3, string string_4)
        {
            DataTable videoCommentList =
                ((Shop_VideoComment_Action) LogicFactory.CreateShop_VideoComment_Action()).GetVideoCommentList(Guid);
            var source = new PagedDataSource
            {
                DataSource = videoCommentList.DefaultView,
                AllowPaging = true,
                PageSize = 5
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
            lnkTo.Text = common.AppendPageVideo(Page.Request.Path + "?guid=" + string_3 + "&ShopID=" + string_4,
                source.PageCount, currentPage);
            lnkPrev.NavigateUrl =
                string.Concat(new object[]
                {
                    Page.Request.Path, "?guid=", string_3, "&ShopID=", string_4, "&Page=",
                    Convert.ToInt32((currentPage - 1))
                });
            lnkFirst.NavigateUrl = Page.Request.Path + "?guid=" + string_3 + "&ShopID=" + string_4 + "&Page=1";
            lnkNext.NavigateUrl =
                string.Concat(new object[]
                {
                    Page.Request.Path, "?guid=", string_3, "&ShopID=", string_4, "&Page=",
                    Convert.ToInt32((currentPage + 1))
                });
            lnkLast.NavigateUrl =
                string.Concat(new object[]
                {Page.Request.Path, "?guid=", string_3, "&ShopID=", string_4, "&Page=", source.PageCount});
            if ((currentPage <= 1) && (source.PageCount <= 1))
            {
                lnkFirst.Enabled = false;
                lnkPrev.Enabled = false;
                lnkNext.Enabled = false;
                lnkLast.Enabled = false;
            }
            if ((currentPage <= 1) && (source.PageCount > 1))
            {
                lnkFirst.Enabled = false;
                lnkPrev.Enabled = false;
            }
            if (currentPage >= source.PageCount)
            {
                lnkNext.Enabled = false;
                lnkLast.Enabled = false;
            }
            RepeaterData.DataSource = source;
            RepeaterData.DataBind();
        }
    }
}