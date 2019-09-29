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
    public class MemberCategoryCommentList : BaseWebControl
    {
        private Button ButtonDelete;
        private Button ButtonSearch;
        private Button ButtonSerchDetail;
        private Calendar CalendarTime1;
        private Calendar CalendarTime2;
        private CheckBox CheckAll;
        private DropDownList DropDownListIsAudit;
        private Label LabelPageMessage;
        private Repeater RepeaterShow;
        private TextBox TextBoxCategoryInfoMerberID;
        private TextBox TextBoxCategoryName;
        private TextBox TextBoxTitle;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;

        private Literal lnkTo;
        private string skinFilename = "MemberCategoryCommentList.ascx";

        public MemberCategoryCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageCount { get; set; }

        public string strMemLoginID { get; set; }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action();
            try
            {
                string guids = string.Empty;
                foreach (RepeaterItem item in RepeaterShow.Items)
                {
                    var box = item.FindControl("checkboxAll") as CheckBox;
                    if (box.Checked)
                    {
                        var control = item.FindControl("guid") as HtmlGenericControl;
                        if (guids != string.Empty)
                        {
                            guids = guids + ",'" + control.InnerText + "'";
                        }
                        else
                        {
                            guids = guids + "'" + control.InnerText + "'";
                        }
                    }
                }
                if (guids == string.Empty)
                {
                    MessageBox.Show("请选择您要删除的记录!");
                }
                else if (action.DeleteCategoryComment(guids) > 0)
                {
                    MessageBox.Show("删除成功");
                    BindData();
                }
            }
            catch
            {
            }
        }

        protected void ButtonSerchDetail_Click(object sender, EventArgs e)
        {
            string innerText = string.Empty;
            int num = 0;
            foreach (RepeaterItem item in RepeaterShow.Items)
            {
                var box = item.FindControl("checkboxAll") as CheckBox;
                if (box.Checked)
                {
                    var control = item.FindControl("guid") as HtmlGenericControl;
                    innerText = control.InnerText;
                    num++;
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择要查看的评论！");
            }
            else if (num == 1)
            {
                innerText = innerText.Replace("\n", "");
                string categoryGuid =
                    ((ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action())
                        .GetCategoryGuid("'" + innerText + "'");
                Page.Response.Redirect("MemberCategoryCommentDetail.aspx?guid=" + categoryGuid);
            }
            else if (num > 1)
            {
                MessageBox.Show("每次只能选择一条记录！");
            }
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
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                strMemLoginID = cookie2.Values["MemLoginID"];
                TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
                CalendarTime1 = (Calendar) skin.FindControl("CalendarTime1");
                CalendarTime2 = (Calendar) skin.FindControl("CalendarTime2");
                TextBoxCategoryName = (TextBox) skin.FindControl("TextBoxCategoryName");
                TextBoxCategoryInfoMerberID = (TextBox) skin.FindControl("TextBoxCategoryInfoMerberID");
                DropDownListIsAudit = (DropDownList) skin.FindControl("DropDownListIsAudit");
                ButtonSearch = (Button) skin.FindControl("ButtonSearch");
                ButtonSearch.Click += ButtonSearch_Click;
                lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
                lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
                lnkNext = (HyperLink) skin.FindControl("lnkNext");
                lnkLast = (HyperLink) skin.FindControl("lnkLast");
                LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
                lnkTo = (Literal) skin.FindControl("lnkTo");
                CheckAll = (CheckBox) skin.FindControl("CheckAll");
                CheckAll.CheckedChanged += CheckAll_CheckedChanged;
                RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
                if (!Page.IsPostBack)
                {
                }
                ButtonDelete = (Button) skin.FindControl("ButtonDelete");
                ButtonDelete.Click += ButtonDelete_Click;
                ButtonSerchDetail = (Button) skin.FindControl("ButtonSerchDetail");
                ButtonSerchDetail.Click += ButtonSerchDetail_Click;
                BindData();
            }
        }

        protected void BindData()
        {
            string commenttitle = returnTextvalue(TextBoxTitle).Trim();
            string categorytitle = returnTextvalue(TextBoxCategoryName).Trim();
            string categoryInfoMerberID = returnTextvalue(TextBoxCategoryInfoMerberID).Trim();
            string str5 = (CalendarTime1.SelectedDate.ToString() == "") ? "-1" : CalendarTime1.SelectedDate.ToString();
            string str4 = (CalendarTime2.SelectedDate.ToString() == "") ? "-1" : CalendarTime2.SelectedDate.ToString();
            DataTable table =
                ((ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action())
                    .MemberCategoryComment(strMemLoginID, commenttitle, categorytitle, categoryInfoMerberID,
                        DropDownListIsAudit.SelectedValue, str5, str4);
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true
            };
            string str6 =
                new ShopSettings().GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                    "MCategoryCommentCount");
            source.PageSize = Convert.ToInt32(str6);
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