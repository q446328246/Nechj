using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    public class ProductBrandCategorySearch : BaseWebControl
    {
        private Button ButtonGo;
        private DropDownList DropDownListRegionCode1;
        private DropDownList DropDownListRegionCode2;
        private DropDownList DropDownListRegionCode3;
        private DropDownList DropDownListRegionCode4;
        private Label LabelPageCount;
        private Label LabelPageIndex;
        private LinkButton LinkButtonEnd;
        private LinkButton LinkButtonFirst;
        private LinkButton LinkButtonLast;
        private LinkButton LinkButtonNext;
        private Repeater RepeaterData;
        private Repeater RepeaterDataBrand;
        private Repeater RepeaterDataCategory;

        private TextBox TextBoxPageNum;
        private int int_0 = 20;
        private string skinFilename = "ProductBrandCategorySearch.ascx";
        public string BrandGuid { get; set; }

        public int PageCount
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public string ProcuctCategoryCode { get; set; }

        protected void BindData()
        {
            DataSet set;
            string addresscode = SetShopRegionCode();
            string procuctCategoryCode = ProcuctCategoryCode;
            string brandGuid = BrandGuid;
            if (procuctCategoryCode.Length.ToString() == "6")
            {
                RepeaterDataBrand.DataSource =
                    ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).GetProductBrand(
                        ProcuctCategoryCode);
                RepeaterDataBrand.DataBind();
                RepeaterDataCategory.DataSource =
                    ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action())
                        .GetProductCategoryCode(ProcuctCategoryCode);
                RepeaterDataCategory.DataBind();
            }
            int num2 = int.Parse(LabelPageIndex.Text);
            if (ViewState["PageData"] == null)
            {
                var action3 = (ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action();
                set = action3.SearchProductList(num2.ToString(), int_0.ToString(), addresscode, procuctCategoryCode,
                    "-1", "-1", "-1", brandGuid);
                ViewState["PageData"] = set;
            }
            else
            {
                int num = num2/10;
                if (num.ToString() != ((DataSet) ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
                {
                    set =
                        ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                            .SearchProductList(num2.ToString(), int_0.ToString(), addresscode, procuctCategoryCode, "-1",
                                "-1", "-1", brandGuid);
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
                CurrentPageIndex = (num2 - 1)%10
            };
            RepeaterData.DataSource = source;
            RepeaterData.DataBind();
            LinkButtonFirst.Enabled = true;
            LinkButtonLast.Enabled = true;
            LinkButtonNext.Enabled = true;
            LinkButtonEnd.Enabled = true;
            if (num2 == 1)
            {
                LinkButtonFirst.Enabled = false;
                LinkButtonLast.Enabled = false;
            }
            if (num2.ToString() == LabelPageCount.Text)
            {
                LinkButtonNext.Enabled = false;
                LinkButtonEnd.Enabled = false;
            }
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = TextBoxPageNum.Text;
            BindData();
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("—市级—", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("--省级--", "-1"));
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Region";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            for (int i = 0; i < productCategoryName.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                    productCategoryName.Rows[i]["Code"] + "/" +
                    productCategoryName.Rows[i]["ID"]));
            }
            DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode3.Items.Clear();
            DropDownListRegionCode3.Items.Add(new ListItem("—县级—", "-1"));
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode3.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode3_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode4.Items.Clear();
            DropDownListRegionCode4.Items.Add(new ListItem("—乡镇级—", "-1"));
            if (DropDownListRegionCode3.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode4.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
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
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterDataBrand = (Repeater) skin.FindControl("RepeaterDataBrand");
            RepeaterDataCategory = (Repeater) skin.FindControl("RepeaterDataCategory");
            DropDownListRegionCode1 = (DropDownList) skin.FindControl("DropDownListRegionCode1");
            DropDownListRegionCode1.SelectedIndexChanged += DropDownListRegionCode1_SelectedIndexChanged;
            DropDownListRegionCode2 = (DropDownList) skin.FindControl("DropDownListRegionCode2");
            DropDownListRegionCode2.SelectedIndexChanged += DropDownListRegionCode2_SelectedIndexChanged;
            DropDownListRegionCode3 = (DropDownList) skin.FindControl("DropDownListRegionCode3");
            DropDownListRegionCode3.SelectedIndexChanged += DropDownListRegionCode3_SelectedIndexChanged;
            DropDownListRegionCode4 = (DropDownList) skin.FindControl("DropDownListRegionCode4");
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
            DropDownListRegionCode1Bind();
            if (Page.Request.QueryString["productCategoryCode"] != null)
            {
                ProcuctCategoryCode = Page.Request.QueryString["productCategoryCode"];
            }
            else
            {
                ProcuctCategoryCode = "-1";
            }
            if (Page.Request.QueryString["brandGuid"] != null)
            {
                BrandGuid = Page.Request.QueryString["brandGuid"];
            }
            else
            {
                BrandGuid = "-1";
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

        public string SetShopRegionCode()
        {
            if (DropDownListRegionCode4.SelectedValue != "-1")
            {
                return DropDownListRegionCode4.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListRegionCode3.SelectedValue != "-1")
            {
                return DropDownListRegionCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                return DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                return DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            return "-1";
        }
    }
}