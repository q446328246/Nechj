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
    public class CategoryListSearch1 : BaseWebControl
    {
        private Button ButtonGo;
        private Button ButtonSearch;
        private DropDownList DropDownListCategoryCf;
        private DropDownList DropDownListCategoryCs;
        private DropDownList DropDownListCategoryCt;
        private DropDownList DropDownListCity;
        private DropDownList DropDownListCounty;
        private DropDownList DropDownListProvince;
        private DropDownList DropDownListType;

        private Label LabelPageCount;
        private Label LabelPageIndex;
        private LinkButton LinkButtonEnd;
        private LinkButton LinkButtonFirst;
        private LinkButton LinkButtonLast;
        private LinkButton LinkButtonNext;
        private Repeater RepeaterShow;
        private TextBox TextBoxEndTime;
        private TextBox TextBoxKeywords;
        private TextBox TextBoxPageNum;
        private TextBox TextBoxStartTime;
        private TextBox TextBoxTitle;
        private bool bool_0;
        private string skinFilename = "CategoryListSearch.ascx";

        public CategoryListSearch1()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageCount { get; set; }

        public void BindCategoryCf()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            DropDownListCategoryCf.Items.Clear();
            DropDownListCategoryCf.Items.Add(new ListItem("-全部-", "-1"));
            for (int i = 0; i < productCategoryName.Rows.Count; i++)
            {
                DropDownListCategoryCf.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                    productCategoryName.Rows[i]["Code"] + "/" +
                    productCategoryName.Rows[i]["ID"]));
            }
            DropDownListCategoryCf_SelectedIndexChanged(null, null);
        }

        public void BindData()
        {
            string str2;
            string str5;
            string addresscode = method_0(DropDownListProvince, DropDownListCity, DropDownListCounty);
            if (!((Page.Request.QueryString["code"] == null) || bool_0))
            {
                str2 = Page.Request.QueryString["code"];
            }
            else
            {
                str2 = method_1(DropDownListCategoryCf, DropDownListCategoryCs, DropDownListCategoryCt);
            }
            string str3 = (TextBoxStartTime.Text == "") ? "-1" : TextBoxStartTime.Text;
            string str4 = (TextBoxEndTime.Text == "") ? "-1" : TextBoxEndTime.Text;
            if (!((Page.Request.QueryString["search"] == null) || bool_0))
            {
                str5 = Operator.FilterString(Page.Request.QueryString["search"]);
            }
            else
            {
                str5 = Operator.FilterString((TextBoxKeywords.Text == "") ? "-1" : TextBoxKeywords.Text);
            }
            string title = (TextBoxTitle.Text == "") ? "-1" : TextBoxTitle.Text;
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            var set = new DataSet();
            int num = int.Parse(LabelPageIndex.Text);
            if (ViewState["PageData"] == null)
            {
                set = action.Search(num.ToString(), PageCount.ToString(), addresscode, str2, str3, str4, str5, title);
                ViewState["PageData"] = set;
            }
            else
            {
                int num2 = num/10;
                if (num2.ToString() != ((DataSet) ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
                {
                    set = action.Search(num.ToString(), PageCount.ToString(), addresscode, str2, str3, str4, str5, title);
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
            LinkButtonFirst.Enabled = true;
            LinkButtonLast.Enabled = true;
            LinkButtonNext.Enabled = true;
            LinkButtonEnd.Enabled = true;
            if (num == 1)
            {
                LinkButtonFirst.Enabled = false;
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
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = TextBoxPageNum.Text;
            BindData();
        }

        protected void DropDownListCategoryCf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCategoryCs.Items.Clear();
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            DropDownListCategoryCs.Items.Add(new ListItem("-全部-", "-1"));
            if (DropDownListCategoryCf.SelectedValue != "-1")
            {
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListCategoryCf.SelectedValue.Split(new[] {'/'})[0]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListCategoryCs.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
            DropDownListCategoryCs_SelectedIndexChanged(null, null);
        }

        protected void DropDownListCategoryCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCategoryCt.Items.Clear();
            DropDownListCategoryCt.Items.Add(new ListItem("-全部-", "-1"));
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            if (DropDownListCategoryCf.SelectedValue != "-1")
            {
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListCategoryCs.SelectedValue.Split(new[] {'/'})[0]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListCategoryCt.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
        }

        protected void DropDownListCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCounty.Items.Clear();
            DropDownListCounty.Items.Add(new ListItem("—县级—", "-1"));
            if (DropDownListCity.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListCity.SelectedValue.Split(new[] {'/'})[0]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListCounty.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["ID"] + "/" +
                        productCategoryName.Rows[i]["Code"]));
                }
            }
        }

        protected void DropDownListProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCity.Items.Clear();
            DropDownListCity.Items.Add(new ListItem("—市级—", "-1"));
            if (DropDownListProvince.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListProvince.SelectedValue.Split(new[] {'/'})[0]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListCity.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["ID"] + "/" +
                        productCategoryName.Rows[i]["Code"]));
                }
            }
            DropDownListCity_SelectedIndexChanged(null, null);
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
            DropDownListProvince = (DropDownList) skin.FindControl("DropDownListProvince");
            DropDownListProvince.SelectedIndexChanged += DropDownListProvince_SelectedIndexChanged;
            DropDownListCity = (DropDownList) skin.FindControl("DropDownListCity");
            DropDownListCity.SelectedIndexChanged += DropDownListCity_SelectedIndexChanged;
            DropDownListCounty = (DropDownList) skin.FindControl("DropDownListCounty");
            DropDownListCategoryCf = (DropDownList) skin.FindControl("DropDownListCategoryCf");
            DropDownListCategoryCf.SelectedIndexChanged += DropDownListCategoryCf_SelectedIndexChanged;
            DropDownListCategoryCs = (DropDownList) skin.FindControl("DropDownListCategoryCs");
            DropDownListCategoryCs.SelectedIndexChanged += DropDownListCategoryCs_SelectedIndexChanged;
            DropDownListCategoryCt = (DropDownList) skin.FindControl("DropDownListCategoryCt");
            TextBoxStartTime = (TextBox) skin.FindControl("TextBoxStartTime");
            TextBoxEndTime = (TextBox) skin.FindControl("TextBoxEndTime");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            LinkButtonFirst = (LinkButton) skin.FindControl("LinkButtonFirst");
            LinkButtonLast = (LinkButton) skin.FindControl("LinkButtonLast");
            LinkButtonNext = (LinkButton) skin.FindControl("LinkButtonNext");
            LinkButtonEnd = (LinkButton) skin.FindControl("LinkButtonEnd");
            LabelPageIndex = (Label) skin.FindControl("LabelPageIndex");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxPageNum = (TextBox) skin.FindControl("TextBoxPageNum");
            ButtonGo = (Button) skin.FindControl("ButtonGo");
            LinkButtonFirst.Click += LinkButtonFirst_Click;
            LinkButtonLast.Click += LinkButtonLast_Click;
            LinkButtonNext.Click += LinkButtonNext_Click;
            LinkButtonEnd.Click += LinkButtonEnd_Click;
            ButtonGo.Click += ButtonGo_Click;
            if (!Page.IsPostBack)
            {
            }
            Province();
            BindCategoryCf();
            if ((Page.Request.QueryString["code"] != null) && (Page.Request.QueryString["code"] != ""))
            {
                int num;
                string str = Page.Request.QueryString["code"];
                if (str.Length >= 3)
                {
                    for (num = 0; num < DropDownListCategoryCf.Items.Count; num++)
                    {
                        if (DropDownListCategoryCf.Items[num].Value.StartsWith(str.Substring(0, 3) + "/"))
                        {
                            DropDownListCategoryCf.SelectedValue = DropDownListCategoryCf.Items[num].Value;
                            break;
                        }
                    }
                    DropDownListCategoryCf_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 6)
                {
                    num = 0;
                    while (num < DropDownListCategoryCs.Items.Count)
                    {
                        if (DropDownListCategoryCs.Items[num].Value.StartsWith(str.Substring(0, 6) + "/"))
                        {
                            DropDownListCategoryCs.SelectedValue = DropDownListCategoryCs.Items[num].Value;
                            break;
                        }
                        num++;
                    }
                    DropDownListCategoryCs_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 9)
                {
                    for (num = 0; num < DropDownListCategoryCt.Items.Count; num++)
                    {
                        if (DropDownListCategoryCt.Items[num].Value.StartsWith(str.Substring(0, 9) + "/"))
                        {
                            DropDownListCategoryCt.Items[num].Selected = true;
                            break;
                        }
                    }
                }
            }
            BindData();
        }

        protected void LinkButtonFirst_Click(object sender, EventArgs e)
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

        private string method_0(DropDownList dropDownList_7, DropDownList dropDownList_8, DropDownList dropDownList_9)
        {
            if (dropDownList_9.SelectedValue != "-1")
            {
                return dropDownList_9.SelectedValue.Split(new[] {'/'})[1];
            }
            if (dropDownList_8.SelectedValue != "-1")
            {
                return dropDownList_8.SelectedValue.Split(new[] {'/'})[1];
            }
            if (dropDownList_7.SelectedValue != "-1")
            {
                return dropDownList_7.SelectedValue.Split(new[] {'/'})[1];
            }
            return "-1";
        }

        private string method_1(DropDownList dropDownList_7, DropDownList dropDownList_8, DropDownList dropDownList_9)
        {
            if (dropDownList_9.SelectedValue != "-1")
            {
                return dropDownList_9.SelectedValue.Split(new[] {'/'})[1];
            }
            if (dropDownList_8.SelectedValue != "-1")
            {
                return dropDownList_8.SelectedValue.Split(new[] {'/'})[1];
            }
            if (dropDownList_7.SelectedValue != "-1")
            {
                return dropDownList_7.SelectedValue.Split(new[] {'/'})[1];
            }
            return "-1";
        }

        protected void Province()
        {
            DropDownListProvince.Items.Clear();
            DropDownListProvince.Items.Add(new ListItem("--省级--", "-1"));
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Region";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            for (int i = 0; i < productCategoryName.Rows.Count; i++)
            {
                DropDownListProvince.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                    productCategoryName.Rows[i]["ID"] + "/" +
                    productCategoryName.Rows[i]["Code"]));
            }
            DropDownListProvince_SelectedIndexChanged(null, null);
        }
    }
}