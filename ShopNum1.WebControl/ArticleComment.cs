using System;
using System.Data;
using System.Web;
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
    public class ArticleComment : BaseWebControl
    {
        private Button ButtonSearch;
        private Button ButtonSerchDetail;
        private Calendar CalendarTime1;
        private Calendar CalendarTime2;
        private CheckBox CheckAll;
        private DropDownList DropDownListIsAudit;
        private Label LabelPageMessage;
        private Repeater RepeaterShow;
        private TextBox TextBoxArticleMemLoginID;
        private TextBox TextBoxArticleTitle;
        private TextBox TextBoxTitle;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ArticleComment.ascx";

        public ArticleComment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        protected void ButtonSerchDetail_Click(object sender, EventArgs e)
        {
            var action1 = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
            int num = 0;
            string str = string.Empty;
            foreach (RepeaterItem item in RepeaterShow.Items)
            {
                var box = item.FindControl("checkboxAll") as CheckBox;
                if (box.Checked)
                {
                    var control = item.FindControl("guid") as HtmlGenericControl;
                    if (str != string.Empty)
                    {
                        str = str + ",'" + control.InnerText + "'";
                        num++;
                    }
                    else
                    {
                        str = str + "'" + control.InnerText + "'";
                        num++;
                    }
                }
            }
            if (str == string.Empty)
            {
                MessageBox.Show("请选择要操作的对象！");
            }
            else if ((str.IndexOf(',') != -1) || (num > 1))
            {
                MessageBox.Show("您每次只能选中一条记录！");
            }
            else
            {
                Page.Response.Redirect("MemberArticleCommentDetail.aspx?guid=" + str);
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in RepeaterShow.Items)
            {
                var box = item.FindControl("checkboxAll") as CheckBox;
                if (CheckAll.Checked)
                {
                    box.Checked = true;
                }
                else
                {
                    box.Checked = false;
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
            }
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            CalendarTime1 = (Calendar) skin.FindControl("CalendarTime1");
            CalendarTime2 = (Calendar) skin.FindControl("CalendarTime2");
            TextBoxArticleTitle = (TextBox) skin.FindControl("TextBoxArticleTitle");
            TextBoxArticleMemLoginID = (TextBox) skin.FindControl("TextBoxArticleMemLoginID");
            DropDownListIsAudit = (DropDownList) skin.FindControl("DropDownListIsAudit");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            ButtonSerchDetail = (Button) skin.FindControl("ButtonSerchDetail");
            ButtonSerchDetail.Click += ButtonSerchDetail_Click;
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            CheckAll = (CheckBox) skin.FindControl("CheckAll");
            CheckAll.CheckedChanged += CheckAll_CheckedChanged;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        protected void BindData()
        {
            string commenttitle = returnTextvalue(TextBoxTitle).Trim();
            string articletitle = returnTextvalue(TextBoxArticleTitle).Trim();
            string str5 = (CalendarTime1.SelectedDate.ToString() == "") ? "-1" : CalendarTime1.SelectedDate.ToString();
            string str4 = (CalendarTime2.SelectedDate.ToString() == "") ? "-1" : CalendarTime2.SelectedDate.ToString();
            DataTable table =
                ((ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action())
                    .SearchArticleCommentInfo(MemberLoginID, commenttitle, articletitle,
                        DropDownListIsAudit.SelectedValue,
                        str5, str4);
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true
            };
            string str3 =
                new ShopSettings().GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                    "MArticleCommentCount");
            try
            {
                source.PageSize = Convert.ToInt32(str3);
            }
            catch
            {
                source.PageSize = 10;
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