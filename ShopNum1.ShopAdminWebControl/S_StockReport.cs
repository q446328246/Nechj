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
    public class S_StockReport : BaseShopWebControl
    {
        protected const string Stock_Report = "S_Stock_Report.aspx";
        private Button button_0;
        private Button button_1;
        private Button button_2;
        private DropDownList dropDownList_0;
        private HyperLink hyperLink_0;
        private HyperLink hyperLink_1;
        private HyperLink hyperLink_2;
        private HyperLink hyperLink_3;
        private Label label_0;
        private Literal literal_0;
        private Repeater repeater_0;
        private string skinFilename = "S_StockReport.ascx";
        protected string strSapce = "　　";
        //private string string_1;
        private TextBox textBox_0;
        private TextBox textBox_1;
        private TextBox textBox_2;
        private TextBox textBox_3;
        private TextBox textBox_4;

        public S_StockReport()
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

        protected void AddSubProductCategory(DataTable dataTable)
        {
            var action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            foreach (DataRow row in dataTable.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["Code"].ToString().Trim();
                dropDownList_0.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), MemLoginID);
                if (table.Rows.Count > 0)
                {
                    AddSubProductCategory(table);
                }
            }
        }

        protected void BindData()
        {
            string productSeriesCode = dropDownList_0.SelectedItem.Value.Trim();
            string str4 = (textBox_0.Text.Trim() == "") ? "-1" : textBox_0.Text.Trim();
            string str2 = (textBox_1.Text.Trim() == "") ? "-1" : textBox_1.Text.Trim();
            string str5 = (textBox_2.Text.Trim() == "") ? "-1" : textBox_2.Text.Trim();
            string str6 = (textBox_3.Text.Trim() == "") ? "-1" : textBox_3.Text.Trim();
            string productname = (textBox_4.Text.Trim() == "") ? "-1" : textBox_4.Text.Trim();
            DataTable table = ((Shop_Report_Action) LogicFactory.CreateShop_Report_Action()).Search(MemLoginID,
                productSeriesCode,
                str4, str2, str5,
                str6, productname);
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
            label_0.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize, currentPage);
            literal_0.Text = common.AppendPage(Page, source.PageCount, currentPage);
            hyperLink_0.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage - 1));
            hyperLink_1.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1";
            hyperLink_2.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage + 1));
            hyperLink_3.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + source.PageCount;
            if ((currentPage <= 1) && (source.PageCount <= 1))
            {
                hyperLink_1.NavigateUrl = "";
                hyperLink_0.NavigateUrl = "";
                hyperLink_2.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            if ((currentPage <= 1) && (source.PageCount > 1))
            {
                hyperLink_1.NavigateUrl = "";
                hyperLink_0.NavigateUrl = "";
            }
            if (currentPage >= source.PageCount)
            {
                hyperLink_2.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            repeater_0.DataSource = source;
            repeater_0.DataBind();
        }

        protected void BindProductCategory()
        {
            var item = new ListItem
            {
                Text = " -全部-", //LocalizationUtil.GetCommonMessage("All"),
                Value = "-1"
            };
            dropDownList_0.Items.Add(item);
            var action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            action.TableName = "ShopNum1_Shop_ProductCategory";
            foreach (DataRow row in action.GetShopProductCategoryCode("0", MemLoginID).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                {
                    Text = row["Name"].ToString().Trim(),
                    Value = row["Code"].ToString().Trim()
                };
                dropDownList_0.Items.Add(item2);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), MemLoginID);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubProductCategory(dataTable);
                }
            }
        }

        protected void button_0_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void button_1_Click(object sender, EventArgs e)
        {
            string str = dropDownList_0.SelectedItem.Value.Trim();
            string str3 = (textBox_0.Text.Trim() == "") ? "-1" : textBox_0.Text.Trim();
            string str5 = (textBox_1.Text.Trim() == "") ? "-1" : textBox_1.Text.Trim();
            string str2 = (textBox_2.Text.Trim() == "") ? "-1" : textBox_2.Text.Trim();
            string str4 = (textBox_3.Text.Trim() == "") ? "-1" : textBox_3.Text.Trim();
            string str6 = (textBox_4.Text.Trim() == "") ? "-1" : textBox_4.Text.Trim();
            Page.Response.Redirect("S_Stock_Report.aspx?Type=xls&MemLoginID=" + MemLoginID + "&productCategoryCode=" +
                                   str + "&SaleNumber1=" + str3 + "&SaleNumber2=" + str5 + "&RepertoryCount1=" + str2 +
                                   "&RepertoryCount2=" + str4 + "&productname=" + str6);
        }

        protected void button_2_Click(object sender, EventArgs e)
        {
            string str = dropDownList_0.SelectedItem.Value.Trim();
            string str3 = (textBox_0.Text.Trim() == "") ? "-1" : textBox_0.Text.Trim();
            string str5 = (textBox_1.Text.Trim() == "") ? "-1" : textBox_1.Text.Trim();
            string str2 = (textBox_2.Text.Trim() == "") ? "-1" : textBox_2.Text.Trim();
            string str4 = (textBox_3.Text.Trim() == "") ? "-1" : textBox_3.Text.Trim();
            string str6 = (textBox_4.Text.Trim() == "") ? "-1" : textBox_4.Text.Trim();
            Page.Response.Redirect("S_Stock_Report.aspx?Type=html&MemLoginID=" + MemLoginID + "&ProductCategoryCode=" +
                                   str + "&SaleNumber1=" + str3 + "&SaleNumber2=" + str5 + "&RepertoryCount1=" + str2 +
                                   "&RepertoryCount2=" + str4 + "&productname=" + str6);
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
                if (cookie2.Values["MemberType"] != "2")
                {
                    GetUrl.RedirectTopLogin();
                }
                else
                {
                    MemLoginID = cookie2.Values["MemLoginID"];
                    hyperLink_0 = (HyperLink) skin.FindControl("lnkPrev");
                    hyperLink_1 = (HyperLink) skin.FindControl("lnkFirst");
                    hyperLink_2 = (HyperLink) skin.FindControl("lnkNext");
                    hyperLink_3 = (HyperLink) skin.FindControl("lnkLast");
                    label_0 = (Label) skin.FindControl("LabelPageMessage");
                    literal_0 = (Literal) skin.FindControl("lnkTo");
                    repeater_0 = (Repeater) skin.FindControl("RepeaterShow");
                    if (!Page.IsPostBack)
                    {
                    }
                    dropDownList_0 = (DropDownList) skin.FindControl("DropDownListProductCategoryID");
                    textBox_0 = (TextBox) skin.FindControl("TextBoxSaleNumber1");
                    textBox_1 = (TextBox) skin.FindControl("TextBoxSaleNumber2");
                    textBox_2 = (TextBox) skin.FindControl("TextBoxRepertoryCount1");
                    textBox_3 = (TextBox) skin.FindControl("TextBoxRepertoryCount2");
                    textBox_4 = (TextBox) skin.FindControl("TextBoxProductName");
                    button_0 = (Button) skin.FindControl("ButtonSearch");
                    button_0.Click += button_0_Click;
                    button_1 = (Button) skin.FindControl("ButtonReport");
                    button_1.Click += button_1_Click;
                    button_2 = (Button) skin.FindControl("ButtonHtml");
                    button_2.Click += button_2_Click;
                    BindProductCategory();
                    BindData();
                }
            }
        }
    }
}