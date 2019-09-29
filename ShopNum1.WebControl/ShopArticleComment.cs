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
    public class ShopArticleComment : BaseWebControl
    {
        private Button ButtonDelete;
        private Button ButtonSearch;
        private Button ButtonSerchDetail;
        private Calendar CalendarTime1;
        private Calendar CalendarTime2;
        private HiddenField CheckGuid;
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
        private string skinFilename = "ShopArticleComment.ascx";

        public ShopArticleComment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        public string ShowCount { get; set; }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            try
            {
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
                        }
                        else
                        {
                            str = str + "'" + control.InnerText + "'";
                        }
                    }
                }
                if (str == string.Empty)
                {
                    MessageBox.Show("请选择要删除的对象！");
                }
                else
                {
                    if (action.DeleteShopArticleComment(str.Trim().Replace("\n", "").Replace("\t", "")) > 0)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    BindData();
                }
            }
            catch
            {
            }
        }

        protected void ButtonSerchDetail_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("MemberShopArticleCommentDetail.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
            }
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            MemberLoginID = cookie2.Values["MemLoginID"];
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
            CheckGuid = (HiddenField) skin.FindControl("CheckGuid");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
            ButtonDelete = (Button) skin.FindControl("ButtonDelete");
            ButtonDelete.Click += ButtonDelete_Click;
        }

        protected void BindData()
        {
            string commenttitle = returnTextvalue(TextBoxTitle).Trim();
            string articletitle = returnTextvalue(TextBoxArticleTitle).Trim();
            string articlememloginid = returnTextvalue(TextBoxArticleMemLoginID).Trim();
            string str5 = (CalendarTime1.SelectedDate.ToString() == "") ? "-1" : CalendarTime1.SelectedDate.ToString();
            string str4 = (CalendarTime2.SelectedDate.ToString() == "") ? "-1" : CalendarTime2.SelectedDate.ToString();
            DataTable table =
                ((ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action())
                    .SearchShopArticleComment(MemberLoginID, commenttitle, articletitle, articlememloginid,
                        DropDownListIsAudit.SelectedValue, str5, str4);
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true
            };
            string str6 =
                new ShopSettings().GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                    "MArticleCommentCount");
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