using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopSellOrder : BaseShopWebControl
    {
        protected const string ShopSellOrder_Report = "S_ShopSellOrder_Report.aspx";
        private Button ButtonHtml;
        private Button ButtonReport;
        private Label LabelPageMessage;
        private Repeater RepeaterShow;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "S_ShopSellOrder.ascx";
        //private string string_3;

        public S_ShopSellOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        //public string MemLoginID
        //{
        //    get { return string_3; }
        //    set { string_3 = value; }
        //}

        public int ShowCount { get; set; }

        protected void BindData()
        {
            string str = Common.Common.ReqStr("sd");
            string str2 = Common.Common.ReqStr("ed");
            string productName = Common.Common.ReqStr("pn");
            DataTable table =
                ((Shop_Report_Action) LogicFactory.CreateShop_Report_Action()).SearchShopSellOrder(MemLoginID, str, str2,
                    productName);
            if ((table != null) && (table.Rows.Count > 0))
            {
                var source = new PagedDataSource
                {
                    DataSource = table.DefaultView,
                    AllowPaging = true
                };
                if (ShowCount < 1)
                {
                    source.PageSize = 10;
                }
                else
                {
                    source.PageSize = ShowCount;
                }
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
                lnkPrev.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage - 1));
                lnkFirst.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1";
                lnkNext.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage + 1));
                lnkLast.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + source.PageCount;
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
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataSource = source;
                RepeaterShow.DataBind();
            }
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            string str = Common.Common.ReqStr("sd");
            string str2 = Common.Common.ReqStr("ed");
            string str3 = Common.Common.ReqStr("pn");
            Page.Response.Redirect("S_ShopSellOrder_Report.aspx?Type=xls&MemLoginID=" + MemLoginID + "&&textBoxTime1=" +
                                   str + "&&textBoxTime2=" + str2 + "&&ProductName=" + str3);
        }

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            string str = Common.Common.ReqStr("sd");
            string str2 = Common.Common.ReqStr("ed");
            string str3 = Common.Common.ReqStr("pn");
            Page.Response.Redirect("S_ShopSellOrder_Report.aspx?Type=html&MemLoginID=" + MemLoginID + "&&textBoxTime1=" +
                                   str + "&&textBoxTime2=" + str2 + "&&ProductName=" + str3);
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                if (cookie2.Values["MemberType"] != "2")
                {
                    GetUrl.RedirectTopLogin();
                }
                else
                {
                    MemLoginID = cookie2.Values["MemLoginID"];
                    lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
                    lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
                    lnkNext = (HyperLink) skin.FindControl("lnkNext");
                    lnkLast = (HyperLink) skin.FindControl("lnkLast");
                    LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
                    lnkTo = (Literal) skin.FindControl("lnkTo");
                    RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
                    if (!Page.IsPostBack)
                    {
                    }
                    ButtonReport = (Button) skin.FindControl("ButtonReport");
                    ButtonReport.Click += ButtonReport_Click;
                    ButtonHtml = (Button) skin.FindControl("ButtonHtml");
                    ButtonHtml.Click += ButtonHtml_Click;
                    BindData();
                }
            }
        }

        public string returnTextvalue(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return "-1";
            }
            return Operator.FilterString(textBox.Text);
        }
    }
}