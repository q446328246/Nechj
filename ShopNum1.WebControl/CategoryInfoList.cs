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
    public class CategoryInfoList : BaseWebControl
    {
        private Button ButtonAdd;
        private Button ButtonDelete;
        private Button ButtonEdit;
        private CheckBox CheckAll;
        private Label LabelPageMessage;
        private Repeater RepeaterShow;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;

        private Literal lnkTo;
        private string skinFilename = "CategoryInfoList.ascx";

        public CategoryInfoList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        public int ShowCount { get; set; }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
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
                else if (action.Delete(guids) > 0)
                {
                    BindData();
                }
            }
            catch
            {
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("CategoryInfoOperate.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
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
                MessageBox.Show("请选择您要编辑的记录！");
            }
            else if (num == 1)
            {
                innerText = innerText.Trim().Replace("\n", "");
                Page.Response.Redirect("CategoryInfoOperate.aspx?guid=" + innerText);
            }
            else if (num > 1)
            {
                MessageBox.Show("请每次只能选择一个记录编辑！");
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
                Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
            }
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
            ButtonDelete.Attributes.Add("onclick", "javascript:return confirm('您确认要删除吗?')");
            ButtonAdd = (Button) skin.FindControl("ButtonAdd");
            ButtonAdd.Click += ButtonAdd_Click;
            ButtonEdit = (Button) skin.FindControl("ButtonEdit");
            ButtonEdit.Click += ButtonEdit_Click;
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action())
                    .SearchCategoryInfo(MemberLoginID, "-1");
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true
            };
            ShowCount = 10;
            source.PageSize = ShowCount;
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
    }
}