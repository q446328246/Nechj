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
    public class S_SeeBuyRate : BaseShopWebControl
    {
        protected const string SeeBuyRate_Report = "S_SeeBuyRate_Report.aspx";
        private Button ButtonHtml;
        private Button ButtonReport;
        private Button ButtonSearch;
        private Label LabelPageMessage;
        private Repeater RepeaterShow;
        private TextBox TextBoxClickCount1;
        private TextBox TextBoxClickCount2;
        private TextBox TextBoxProductName;
        private TextBox TextBoxSaleNumber1;
        private TextBox TextBoxSaleNumber2;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "S_SeeBuyRate.ascx";
        //private string string_1;

        public S_SeeBuyRate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        //public string MemLoginID
        //{
        //    get { return string_1; }
        //    set { string_1 = value; }
        //}

        public int ShowCount { get; set; }

        protected void BindData()
        {
            string str3 = (TextBoxSaleNumber1.Text.Trim() == "") ? "-1" : TextBoxSaleNumber1.Text;
            string str = (TextBoxSaleNumber2.Text.Trim() == "") ? "-1" : TextBoxSaleNumber2.Text;
            string str4 = (TextBoxClickCount1.Text.Trim() == "") ? "-1" : TextBoxClickCount1.Text;
            string str5 = (TextBoxClickCount2.Text.Trim() == "") ? "-1" : TextBoxClickCount2.Text;
            string productName = (TextBoxProductName.Text.Trim() == "") ? "-1" : TextBoxProductName.Text;
            DataTable table = ((Shop_Report_Action) LogicFactory.CreateShop_Report_Action()).SearchClickCount(
                MemLoginID, str3, str, str4, str5, productName);
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
            RepeaterShow.DataSource = source;
            RepeaterShow.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            string str2 = (TextBoxSaleNumber1.Text.Trim() == "") ? "-1" : TextBoxSaleNumber1.Text;
            string str4 = (TextBoxSaleNumber2.Text.Trim() == "") ? "-1" : TextBoxSaleNumber2.Text;
            string str = (TextBoxClickCount1.Text.Trim() == "") ? "-1" : TextBoxClickCount1.Text;
            string str3 = (TextBoxClickCount2.Text.Trim() == "") ? "-1" : TextBoxClickCount2.Text;
            string str5 = (TextBoxProductName.Text.Trim() == "") ? "-1" : TextBoxProductName.Text;
            Page.Response.Redirect("S_SeeBuyRate_Report.aspx?Type=xls&MemLoginID=" + MemLoginID + "&&SaleNumber1=" +
                                   str2 + "&&SaleNumber2=" + str4 + "&&ClickCount1=" + str + "&&ClickCount2=" + str3 +
                                   "&&ProductName=" + str5);
        }

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            string str2 = (TextBoxSaleNumber1.Text.Trim() == "") ? "-1" : TextBoxSaleNumber1.Text;
            string str4 = (TextBoxSaleNumber2.Text.Trim() == "") ? "-1" : TextBoxSaleNumber2.Text;
            string str = (TextBoxClickCount1.Text.Trim() == "") ? "-1" : TextBoxClickCount1.Text;
            string str3 = (TextBoxClickCount2.Text.Trim() == "") ? "-1" : TextBoxClickCount2.Text;
            string str5 = (TextBoxProductName.Text.Trim() == "") ? "-1" : TextBoxProductName.Text;
            Page.Response.Redirect("S_SeeBuyRate_Report.aspx?Type=html&MemLoginID=" + MemLoginID + "&&SaleNumber1=" +
                                   str2 + "&&SaleNumber2=" + str4 + "&&ClickCount1=" + str + "&&ClickCount2=" + str3 +
                                   "&&ProductName=" + str5);
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
                    TextBoxSaleNumber1 = (TextBox) skin.FindControl("TextBoxSaleNumber1");
                    TextBoxSaleNumber2 = (TextBox) skin.FindControl("TextBoxSaleNumber2");
                    TextBoxClickCount1 = (TextBox) skin.FindControl("TextBoxClickCount1");
                    TextBoxClickCount2 = (TextBox) skin.FindControl("TextBoxClickCount2");
                    TextBoxProductName = (TextBox) skin.FindControl("TextBoxProductName");
                    if (!Page.IsPostBack)
                    {
                    }
                    ButtonSearch = (Button) skin.FindControl("ButtonSearch");
                    ButtonSearch.Click += ButtonSearch_Click;
                    ButtonReport = (Button) skin.FindControl("ButtonReport");
                    ButtonReport.Click += ButtonReport_Click;
                    ButtonHtml = (Button) skin.FindControl("ButtonHtml");
                    ButtonHtml.Click += ButtonHtml_Click;
                    BindData();
                }
            }
        }
    }
}