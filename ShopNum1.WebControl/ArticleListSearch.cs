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
    public class ArticleListSearch : BaseWebControl
    {
        private Button ButtonGo;
        private Button ButtonSearch;
        private DropDownList DropDownListArticleCategoryCf;
        private DropDownList DropDownListArticleCategoryCs;
        private DropDownList DropDownListArticleCt;
        private Label LabelArticleProductName;
        private Label LabelPageCount;
        private Label LabelPageIndex;
        private LinkButton LinkButtonEnd;
        private LinkButton LinkButtonLast;
        private LinkButton LinkButtonNext;
        private Repeater RepeaterShow;
        private TextBox TextBoxEndTime;
        private TextBox TextBoxKeywords;
        private TextBox TextBoxPageNum;
        private TextBox TextBoxStartTime;
        private TextBox TextBoxTitle;
        private bool bool_0;
        private int int_0 = 20;
        private LinkButton linkButtonSearch;
        private string skinFilename = "ArticleListSearch.ascx";

        public ArticleListSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageCount
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public void BindCategoryCf()
        {
            DataTable articleCategory =
                ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action())
                    .GetArticleCategory("0");
            DropDownListArticleCategoryCf.Items.Clear();
            DropDownListArticleCategoryCf.Items.Add(new ListItem("-请选择-", "-1"));
            for (int i = 0; i < articleCategory.Rows.Count; i++)
            {
                DropDownListArticleCategoryCf.Items.Add(new ListItem(articleCategory.Rows[i]["Name"].ToString(),
                    articleCategory.Rows[i]["ID"].ToString()));
            }
            DropDownListArticleCategoryCf_SelectedIndexChanged(null, null);
        }

        public void BindData()
        {
            string str2;
            string str5;
            string addresscode = "-1";
            if (!((Page.Request.QueryString["ID"] == null) || bool_0))
            {
                str2 = Page.Request.QueryString["ID"];
            }
            else
            {
                str2 = method_0(DropDownListArticleCategoryCf, DropDownListArticleCategoryCs, DropDownListArticleCt);
            }
            string str3 = (TextBoxStartTime.Text == "") ? "-1" : TextBoxStartTime.Text;
            string endTime = (TextBoxEndTime.Text == "") ? "-1" : TextBoxEndTime.Text;
            try
            {
                if (str3 != "-1")
                {
                    Convert.ToDateTime(str3);
                }
                if (endTime != "-1")
                {
                    Convert.ToDateTime(str3);
                }
            }
            catch
            {
                str3 = "-1";
                endTime = "-1";
            }
            string title = (TextBoxTitle.Text == "") ? "-1" : TextBoxTitle.Text;
            if (!((Page.Request.QueryString["search"] == null) || bool_0))
            {
                str5 = Operator.FilterString(Page.Request.QueryString["search"]);
            }
            else
            {
                str5 = TextBoxKeywords.Text.Trim();
            }
            var action = (ShopNum1_ArticleCheck_Action) LogicFactory.CreateShopNum1_ArticleCheck_Action();
            var set = new DataSet();
            int num = int.Parse(LabelPageIndex.Text);
            if (ViewState["PageData"] == null)
            {
                set = action.Search(num.ToString(), int_0.ToString(), addresscode, str2, str3, endTime, str5, title);
                ViewState["PageData"] = set;
            }
            else
            {
                int num2 = num/10;
                if (num2.ToString() != ((DataSet) ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
                {
                    set = action.Search(num.ToString(), int_0.ToString(), addresscode, str2, str3, endTime, str5, title);
                    ViewState["PageData"] = set;
                }
            }
            LabelPageCount.Text = (((DataSet) ViewState["PageData"]).Tables[2].Rows[0][0].ToString() == "0")
                ? "1"
                : ((DataSet) ViewState["PageData"]).Tables[2].Rows[0][0].ToString();
            var source = new PagedDataSource
            {
                AllowPaging = true,
                PageSize = PageCount,
                DataSource = ((DataSet) ViewState["PageData"]).Tables[0].DefaultView,
                CurrentPageIndex = (num - 1)%10
            };
            RepeaterShow.DataSource = source;
            RepeaterShow.DataBind();
            linkButtonSearch.Enabled = true;
            LinkButtonLast.Enabled = true;
            LinkButtonNext.Enabled = true;
            LinkButtonEnd.Enabled = true;
            if (num == 1)
            {
                linkButtonSearch.Enabled = false;
                LinkButtonLast.Enabled = false;
            }
            if (num == int.Parse(LabelPageCount.Text))
            {
                LinkButtonNext.Enabled = false;
                LinkButtonEnd.Enabled = false;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            bool_0 = true;
            ViewState["PageData"] = null;
            BindData();
            LabelArticleProductName.Text = (GetArticleCategoryName() == "-1") ? "全部" : GetArticleCategoryName();
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = TextBoxPageNum.Text;
            BindData();
        }

        protected void DropDownListArticleCategoryCf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListArticleCategoryCs.Items.Clear();
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            DropDownListArticleCategoryCs.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListArticleCategoryCf.SelectedValue != "-1")
            {
                DataTable articleCategory = action.GetArticleCategory(DropDownListArticleCategoryCf.SelectedValue);
                for (int i = 0; i < articleCategory.Rows.Count; i++)
                {
                    DropDownListArticleCategoryCs.Items.Add(new ListItem(articleCategory.Rows[i]["Name"].ToString(),
                        articleCategory.Rows[i]["ID"].ToString()));
                }
            }
            DropDownListArticleCategoryCs_SelectedIndexChanged(null, null);
        }

        protected void DropDownListArticleCategoryCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListArticleCt.Items.Clear();
            DropDownListArticleCt.Items.Add(new ListItem("-请选择-", "-1"));
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            if (DropDownListArticleCategoryCs.SelectedValue != "-1")
            {
                DataTable articleCategory = action.GetArticleCategory(DropDownListArticleCategoryCs.SelectedValue);
                for (int i = 0; i < articleCategory.Rows.Count; i++)
                {
                    DropDownListArticleCt.Items.Add(new ListItem(articleCategory.Rows[i]["Name"].ToString(),
                        articleCategory.Rows[i]["ID"].ToString()));
                }
            }
        }

        public string GetArticleCategoryName()
        {
            if (DropDownListArticleCt.SelectedValue != "-1")
            {
                return DropDownListArticleCt.SelectedItem.Text;
            }
            if (DropDownListArticleCategoryCs.SelectedValue != "-1")
            {
                return DropDownListArticleCategoryCs.SelectedItem.Text;
            }
            if (DropDownListArticleCategoryCf.SelectedValue != "-1")
            {
                return DropDownListArticleCategoryCf.SelectedItem.Text;
            }
            return "-1";
        }

        protected DataTable GetArticleInfo(string newid)
        {
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            return action.GetArticleInfoByID(newid);
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
            DropDownListArticleCategoryCf = (DropDownList) skin.FindControl("DropDownListArticleCategoryCf");
            DropDownListArticleCategoryCf.SelectedIndexChanged += DropDownListArticleCategoryCf_SelectedIndexChanged;
            DropDownListArticleCategoryCs = (DropDownList) skin.FindControl("DropDownListArticleCategoryCs");
            DropDownListArticleCategoryCs.SelectedIndexChanged += DropDownListArticleCategoryCs_SelectedIndexChanged;
            DropDownListArticleCt = (DropDownList) skin.FindControl("DropDownListArticleCt");
            TextBoxStartTime = (TextBox) skin.FindControl("TextBoxStartTime");
            TextBoxEndTime = (TextBox) skin.FindControl("TextBoxEndTime");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            LabelArticleProductName = (Label) skin.FindControl("LabelArticleProductName");
            linkButtonSearch = (LinkButton) skin.FindControl("LinkButtonFirst");
            LinkButtonLast = (LinkButton) skin.FindControl("LinkButtonLast");
            LinkButtonNext = (LinkButton) skin.FindControl("LinkButtonNext");
            LinkButtonEnd = (LinkButton) skin.FindControl("LinkButtonEnd");
            LabelPageIndex = (Label) skin.FindControl("LabelPageIndex");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxPageNum = (TextBox) skin.FindControl("TextBoxPageNum");
            ButtonGo = (Button) skin.FindControl("ButtonGo");
            linkButtonSearch.Click += linkButtonSearch_Click;
            LinkButtonLast.Click += LinkButtonLast_Click;
            LinkButtonNext.Click += LinkButtonNext_Click;
            LinkButtonEnd.Click += LinkButtonEnd_Click;
            ButtonGo.Click += ButtonGo_Click;
            if (!Page.IsPostBack)
            {
            }
            BindCategoryCf();
            if ((Page.Request.QueryString["ID"] != null) && (Page.Request.QueryString["ID"] != ""))
            {
                string newid = Page.Request.QueryString["ID"];
                DataTable articleInfo = GetArticleInfo(newid);
                if ((articleInfo != null) && (articleInfo.Rows.Count > 0))
                {
                    if (articleInfo.Rows[0]["CategoryLevel"].ToString() == "1")
                    {
                        DropDownListArticleCategoryCf.SelectedValue = newid;
                    }
                    else if (articleInfo.Rows[0]["CategoryLevel"].ToString() == "2")
                    {
                        DropDownListArticleCategoryCf.SelectedValue =
                            GetArticleInfo(articleInfo.Rows[0]["FatherID"].ToString()).Rows[0]["ID"].ToString();
                        DropDownListArticleCategoryCf_SelectedIndexChanged(null, null);
                        DropDownListArticleCategoryCs.SelectedValue = newid;
                    }
                    else if (articleInfo.Rows[0]["CategoryLevel"].ToString() == "3")
                    {
                        DataTable table2 = GetArticleInfo(articleInfo.Rows[0]["FatherID"].ToString());
                        DropDownListArticleCategoryCf.SelectedValue =
                            GetArticleInfo(table2.Rows[0]["FatherID"].ToString()).Rows[0]["ID"].ToString();
                        DropDownListArticleCategoryCf_SelectedIndexChanged(null, null);
                        DropDownListArticleCategoryCs.SelectedValue =
                            GetArticleInfo(articleInfo.Rows[0]["FatherID"].ToString()).Rows[0]["ID"].ToString();
                        DropDownListArticleCategoryCs_SelectedIndexChanged(null, null);
                        DropDownListArticleCt.SelectedValue = newid;
                    }
                }
            }
            BindData();
            LabelArticleProductName.Text = (GetArticleCategoryName() == "-1") ? "全部" : GetArticleCategoryName();
        }

        protected void linkButtonSearch_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = "1";
            BindData();
        }

        protected void LinkButtonLast_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = (int.Parse(LabelPageIndex.Text) - 1).ToString();
            BindData();
        }

        protected void LinkButtonNext_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = (int.Parse(LabelPageIndex.Text) + 1).ToString();
            BindData();
        }

        protected void LinkButtonEnd_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = LabelPageCount.Text;
            BindData();
        }

        private string method_0(DropDownList dropDownList_3, DropDownList dropDownList_4, DropDownList dropDownList_5)
        {
            if (dropDownList_5.SelectedValue != "-1")
            {
                return dropDownList_5.SelectedValue;
            }
            if (dropDownList_4.SelectedValue != "-1")
            {
                return dropDownList_4.SelectedValue;
            }
            if (dropDownList_3.SelectedValue != "-1")
            {
                return dropDownList_3.SelectedValue;
            }
            return "-1";
        }
    }
}