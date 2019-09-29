using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopCommentList : BaseWebControl
    {
        private Label LabelPageMessage;
        private LinkButton LinkButtonAll;
        private LinkButton LinkButtonBad;
        private LinkButton LinkButtonGood;
        private LinkButton LinkButtonMid;
        private Panel Panelpager;
        private Repeater RepeaterShow;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ShopCommentList.ascx";
        private string string_1 = string.Empty;
        private string string_2;
        private string string_3 = string.Empty;

        public ShopCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        public static string CommentValue(object commentType)
        {
            string str = commentType.ToString();
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "[差评]";

                default:
                    if (!(str == "1"))
                    {
                        if (str == "2")
                        {
                            return "[好评]";
                        }
                    }
                    else
                    {
                        return "[中评]";
                    }
                    break;
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            string_3 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(string_3);
            string_1 = (Page.Request.QueryString["commentType"] == null) ? "3" : Page.Request.QueryString["commentType"];
            string_2 = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            Panelpager = (Panel) skin.FindControl("Panelpager");
            LinkButtonAll = (LinkButton) skin.FindControl("LinkButtonAll");
            LinkButtonAll.Click += LinkButtonAll_Click;
            LinkButtonGood = (LinkButton) skin.FindControl("LinkButtonGood");
            LinkButtonGood.Click += LinkButtonGood_Click;
            LinkButtonMid = (LinkButton) skin.FindControl("LinkButtonMid");
            LinkButtonMid.Click += LinkButtonMid_Click;
            LinkButtonBad = (LinkButton) skin.FindControl("LinkButtonBad");
            LinkButtonBad.Click += LinkButtonBad_Click;
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            var control = (HtmlGenericControl) skin.FindControl("div" + string_1);
            control.Style["background"] =
                "url(Themes/Skin_Default/images/wany.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            string_1 = "3";
            if (string_2 == "-1")
            {
                Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + string_1 + "&guid=" + string_2));
            }
            else
            {
                Page.Response.Redirect(GetPageName.RetUrl("ProductDetail",
                    "commentType=" + string_1 + "&guid=" + string_2));
            }
        }

        protected void LinkButtonGood_Click(object sender, EventArgs e)
        {
            string_1 = "2";
            if (string_2 == "-1")
            {
                Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + string_1 + "&guid=" + string_2));
            }
            else
            {
                Page.Response.Redirect(GetPageName.RetUrl("ProductDetail",
                    "commentType=" + string_1 + "&guid=" + string_2));
            }
        }

        protected void LinkButtonMid_Click(object sender, EventArgs e)
        {
            string_1 = "1";
            if (string_2 == "-1")
            {
                Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + string_1 + "&guid=" + string_2));
            }
            else
            {
                Page.Response.Redirect(GetPageName.RetUrl("ProductDetail",
                    "commentType=" + string_1 + "&guid=" + string_2));
            }
        }

        protected void LinkButtonBad_Click(object sender, EventArgs e)
        {
            string_1 = "0";
            if (string_2 == "-1")
            {
                Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + string_1 + "&guid=" + string_2));
            }
            else
            {
                Page.Response.Redirect(GetPageName.RetUrl("ProductDetail",
                    "commentType=" + string_1 + "&guid=" + string_2));
            }
        }

        protected void BindData()
        {
            var action = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            DataTable table = action.CommentListStatReport(string_3, string_2);
            if (table.Rows.Count > 0)
            {
                LinkButtonGood.Text = "好评" + table.Rows[0]["GoodNum"];
                LinkButtonMid.Text = "中评" + table.Rows[0]["MidNum"];
                LinkButtonBad.Text = "差评" + table.Rows[0]["BadNum"];
            }
            if (string_1 == "3")
            {
                string_1 = "-1";
            }
            DataTable table2 = action.CommentList(MemLoginID, string_1, string_2);
            if (table2.Rows.Count > 0)
            {
                var source = new PagedDataSource
                {
                    DataSource = table2.DefaultView,
                    AllowPaging = true,
                    PageSize = ShowCount
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
                lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage,
                    "commentType=" + string_1 + "&guid=" + string_2);
                lnkPrev.NavigateUrl =
                    string.Concat(new object[]
                    {
                        Page.Request.CurrentExecutionFilePath, "?Page=", Convert.ToInt32((currentPage - 1)),
                        "&commentType=", string_1, "&guid=", string_2
                    });
                lnkFirst.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1&commentType=" + string_1 +
                                       "&guid=" + string_2;
                lnkNext.NavigateUrl =
                    string.Concat(new object[]
                    {
                        Page.Request.CurrentExecutionFilePath, "?Page=", Convert.ToInt32((currentPage + 1)),
                        "&commentType=", string_1, "&guid=", string_2
                    });
                lnkLast.NavigateUrl =
                    string.Concat(new object[]
                    {
                        Page.Request.CurrentExecutionFilePath, "?Page=", source.PageCount, "&commentType=", string_1
                        ,
                        "&guid=", string_2
                    });
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
                RepeaterShow.DataSource = source;
                RepeaterShow.DataBind();
                Panelpager.Visible = true;
            }
            else
            {
                Panelpager.Visible = false;
            }
        }
    }
}