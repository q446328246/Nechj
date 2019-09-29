using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    public class ProductSearch : BaseWebControl
    {
        private readonly ShopNum1_ProuductChecked_Action shopNum1_ProductCategory_Action =
            ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action());

        private readonly string string_1 = GetPageName.RetDomainUrl("Search_product");
        public string Pvalue;

        public string addcode;
        public string brandguid;
        private Button button_0;
        private Button button_1;
        private Dictionary<string, string> dictionary_0;
        private HiddenField hiddenField_0;
        private HiddenField hiddenField_1;
        private HtmlGenericControl htmlGenericControl_0;
        private HtmlGenericControl htmlGenericControl_1;
        private HtmlGenericControl htmlGenericControl_2;
        private HtmlGenericControl htmlGenericControl_3;
        private HtmlGenericControl htmlGenericControl_4;
        private HtmlGenericControl htmlGenericControl_5;
        private HtmlGenericControl htmlGenericControl_6;
        private int int_0;

        private Label label_0;
        private Label label_1;
        private LinkButton linkButton_0;
        private LinkButton linkButton_1;
        private LinkButton linkButton_10;
        private LinkButton linkButton_11;
        private LinkButton linkButton_12;
        private LinkButton linkButton_2;
        private LinkButton linkButton_3;
        private LinkButton linkButton_4;
        private LinkButton linkButton_5;
        private LinkButton linkButton_6;
        private LinkButton linkButton_7;
        private LinkButton linkButton_8;
        private LinkButton linkButton_9;
        private Repeater repeater_0;
        private Repeater repeater_1;

        private string skinFilename = "ProductSearch.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        public string string_6;

        public string style;
        private TextBox textBox_0;
        private TextBox textBox_1;
        private TextBox textBox_2;
        private TextBox textBox_3;

        public ProductSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CityShowCount { get; set; }

        public int ShowCount { get; set; }

        public string strEndPrice { get; set; }

        public string strStartPrice { get; set; }

        protected void button_0_Click(object sender, EventArgs e)
        {
            string str = textBox_0.Text.Trim();
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&pageid=" + str);
        }

        protected void button_1_Click(object sender, EventArgs e)
        {
            string str = textBox_3.Text.Trim().Replace("'", "");
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&add=" + str);
        }

        protected override void InitializeSkin(Control skin)
        {
            strStartPrice = (Page.Request.QueryString["minprice"] == null) ? "0" : Page.Request.QueryString["minprice"];
            strEndPrice = (Page.Request.QueryString["maxprice"] == null) ? "0" : Page.Request.QueryString["maxprice"];
            repeater_0 = (Repeater) skin.FindControl("RepeaterGrid");
            repeater_1 = (Repeater) skin.FindControl("RepeaterProductShow");
            repeater_1.ItemDataBound += repeater_1_ItemDataBound;
            textBox_1 = (TextBox) skin.FindControl("TextBoxPriceStartSearch");
            if (strStartPrice != "0")
            {
                textBox_1.Text = strStartPrice;
            }
            if (strEndPrice != "0")
            {
                textBox_2.Text = strEndPrice;
            }
            textBox_2 = (TextBox) skin.FindControl("TextBoxPriceEndSearch");
            linkButton_0 = (LinkButton) skin.FindControl("LinkButtonSearch");
            linkButton_0.Click += linkButton_0_Click;
            htmlGenericControl_0 = (HtmlGenericControl) skin.FindControl("pageDiv");
            label_0 = (Label) skin.FindControl("LabelPageCount");
            textBox_0 = (TextBox) skin.FindControl("TextBoxIndex");
            button_0 = (Button) skin.FindControl("ButtonSure");
            button_0.Click += button_0_Click;
            htmlGenericControl_1 = (HtmlGenericControl) skin.FindControl("divGrid");
            htmlGenericControl_2 = (HtmlGenericControl) skin.FindControl("divList");
            linkButton_1 = (LinkButton) skin.FindControl("LinkButtonRenqi");
            linkButton_1.Click += linkButton_1_Click;
            linkButton_2 = (LinkButton) skin.FindControl("LinkButtonSales");
            linkButton_2.Click += linkButton_2_Click;
            linkButton_3 = (LinkButton) skin.FindControl("LinkButtonXinyong");
            linkButton_3.Click += linkButton_3_Click;
            linkButton_4 = (LinkButton) skin.FindControl("LinkButtonPrice");
            linkButton_4.Click += linkButton_4_Click;
            linkButton_5 = (LinkButton) skin.FindControl("LinkButtonGrid");
            linkButton_5.Click += linkButton_5_Click;
            linkButton_6 = (LinkButton) skin.FindControl("LinkButtonList");
            linkButton_6.Click += linkButton_6_Click;
            linkButton_7 = (LinkButton) skin.FindControl("LinkButtonPriceUp");
            linkButton_7.Click += linkButton_7_Click;
            linkButton_8 = (LinkButton) skin.FindControl("LinkButtonPriceDown");
            linkButton_8.Click += linkButton_8_Click;
            linkButton_9 = (LinkButton) skin.FindControl("LinkButtonSalesDown");
            linkButton_9.Click += linkButton_9_Click;
            linkButton_10 = (LinkButton) skin.FindControl("LinkButtonCreateTime");
            linkButton_10.Click += linkButton_10_Click;
            linkButton_11 = (LinkButton) skin.FindControl("LinkButtonDefault");
            linkButton_11.Click += linkButton_11_Click;
            linkButton_12 = (LinkButton) skin.FindControl("LinkButtonSortStatus");
            label_1 = (Label) skin.FindControl("LabelAddress");
            hiddenField_0 = (HiddenField) skin.FindControl("HiddenFieldAddCode");
            hiddenField_1 = (HiddenField) skin.FindControl("HiddenFieldAdd");
            textBox_3 = (TextBox) skin.FindControl("TextBoxCity");
            button_1 = (Button) skin.FindControl("ButtonCity");
            button_1.Click += button_1_Click;
            htmlGenericControl_3 = (HtmlGenericControl) skin.FindControl("IRenqi");
            htmlGenericControl_4 = (HtmlGenericControl) skin.FindControl("ISales");
            htmlGenericControl_5 = (HtmlGenericControl) skin.FindControl("IXinyong");
            htmlGenericControl_6 = (HtmlGenericControl) skin.FindControl("IPrice");
            strStartPrice = (Common.Common.ReqStr("minprice") == "") ? "" : Common.Common.ReqStr("minprice");
            strEndPrice = (Common.Common.ReqStr("maxprice") == "") ? "" : Common.Common.ReqStr("maxprice");
            string_2 = (Common.Common.ReqStr("code") == "") ? "-1" : Common.Common.ReqStr("code");
            string_3 = (Common.Common.ReqStr("productName") == "") ? "-1" : Common.Common.ReqStr("productName");
            brandguid = (Common.Common.ReqStr("brandguid") == "") ? "-1" : Common.Common.ReqStr("brandguid");
            Pvalue = (Common.Common.ReqStr("Pvalue") == "") ? "-1" : Common.Common.ReqStr("Pvalue");
            style = (Common.Common.ReqStr("style") == "") ? "list" : Common.Common.ReqStr("style");
            string_5 = (Common.Common.ReqStr("ordername") == "") ? "orderid" : Common.Common.ReqStr("ordername");
            string_4 = (Common.Common.ReqStr("sort") == "") ? "desc" : Common.Common.ReqStr("sort");
            addcode = (Common.Common.ReqStr("addcode") == "") ? "-1" : Common.Common.ReqStr("addcode");
            string_6 = (Common.Common.ReqStr("add") == "") ? "-1" : Common.Common.ReqStr("add");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Common.Common.ReqStr("pageid"));
            }
            catch
            {
                int_0 = 1;
            }
            Func<string, bool> func = method_2;
            if (Pvalue != "-1")
            {
                func(Pvalue);
            }
            if (!Page.IsPostBack)
            {
                method_1();
                if (style == "list")
                {
                    htmlGenericControl_2.Style.Add("display", "block");
                    htmlGenericControl_1.Style.Add("display", "none");
                }
                else
                {
                    htmlGenericControl_2.Style.Add("display", "none");
                    htmlGenericControl_1.Style.Add("display", "block");
                }
                method_0(string_5, string_4);
                if (string.IsNullOrEmpty(addcode) || (addcode == "-1"))
                {
                    hiddenField_1.Value = string_6;
                }
                else
                {
                    hiddenField_0.Value = addcode;
                }
            }
        }

        protected void linkButton_0_Click(object sender, EventArgs e)
        {
            strStartPrice = textBox_1.Text.Trim();
            strEndPrice = textBox_2.Text.Trim();
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_1_Click(object sender, EventArgs e)
        {
            if (string_5 == "collectcount")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_4 == "asc") || (string_4 == ""))
                {
                    string_4 = "desc";
                }
                else
                {
                    string_4 = "asc";
                }
            }
            else
            {
                string_5 = "collectcount";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_10_Click(object sender, EventArgs e)
        {
            string_5 = "createtime";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_11_Click(object sender, EventArgs e)
        {
            string_5 = "orderid";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_2_Click(object sender, EventArgs e)
        {
            if (string_5 == "salenumber")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_4 == "asc") || (string_4 == ""))
                {
                    string_4 = "desc";
                }
                else
                {
                    string_4 = "asc";
                }
            }
            else
            {
                string_5 = "salenumber";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_3_Click(object sender, EventArgs e)
        {
            if (string_5 == "shopreputation")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "-1" : Page.Request.QueryString["sort"];
                if ((string_4 == "asc") || (string_4 == "-1"))
                {
                    string_4 = "desc";
                }
                else
                {
                    string_4 = "asc";
                }
            }
            else
            {
                string_5 = "shopreputation";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_4_Click(object sender, EventArgs e)
        {
            if (string_5 == "shopprice")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_4 == "desc") || (string_4 == ""))
                {
                    string_4 = "asc";
                }
                else
                {
                    string_4 = "desc";
                }
            }
            else
            {
                string_5 = "shopprice";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_5_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_6_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=list&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_7_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "asc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_8_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void linkButton_9_Click(object sender, EventArgs e)
        {
            string_5 = "salenumber";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void method_0(string string_10, string string_11)
        {
            if (style == "list")
            {
                htmlGenericControl_2.Style.Add("display", "block");
                htmlGenericControl_1.Style.Add("display", "none");
            }
            else
            {
                htmlGenericControl_2.Style.Add("display", "none");
                htmlGenericControl_1.Style.Add("display", "block");
            }
            string_10 = string_10.ToLower();
            if (string_4 == "desc")
            {
                if (string_10 == "shopprice")
                {
                    linkButton_12.Text = "价格从高到低";
                    linkButton_4.CssClass = "comSort selected";
                    htmlGenericControl_6.Attributes.Add("class", "comSort-dSel");
                }
                if (string_10 == "salenumber")
                {
                    linkButton_12.Text = "销量从高到低";
                    linkButton_2.CssClass = "comSort selected";
                    htmlGenericControl_4.Attributes.Add("class", "comSort-dSel");
                }
                if (string_10 == "createtime")
                {
                    linkButton_12.Text = "按发布时间排序";
                }
                if (string_10 == "orderid")
                {
                    linkButton_12.Text = "默认排序";
                }
                if (string_10 == "collectcount")
                {
                    linkButton_12.Text = "人气从高到低";
                    linkButton_1.CssClass = "comSort selected";
                    htmlGenericControl_3.Attributes.Add("class", "comSort-dSel");
                }
                if (string_10 == "shopreputation")
                {
                    linkButton_12.Text = "信用从高到低";
                    linkButton_3.CssClass = "comSort selected";
                    htmlGenericControl_5.Attributes.Add("class", "comSort-dSel");
                }
            }
            else
            {
                if (string_10 == "shopprice")
                {
                    linkButton_12.Text = "价格从低到高";
                    linkButton_4.CssClass = "comSort selected";
                    htmlGenericControl_6.Attributes.Add("class", "comSort-uSel");
                }
                if (string_10 == "salenumber")
                {
                    linkButton_12.Text = "销量从低到高";
                    linkButton_2.CssClass = "comSort selected";
                    htmlGenericControl_4.Attributes.Add("class", "comSort-uSel");
                }
                if (string_10 == "createtime")
                {
                    linkButton_12.Text = "按发布时间排序";
                }
                if (string_10 == "orderid")
                {
                    linkButton_12.Text = "默认排序";
                }
                if (string_10 == "collectcount")
                {
                    linkButton_12.Text = "人气从低到高";
                    linkButton_1.CssClass = "comSort selected";
                    htmlGenericControl_3.Attributes.Add("class", "comSort-uSel");
                }
                if (string_10 == "shopreputation")
                {
                    linkButton_12.Text = "信用从低到高";
                    linkButton_3.CssClass = "comSort selected";
                    htmlGenericControl_5.Attributes.Add("class", "comSort-uSel");
                }
            }
        }

        protected void method_1()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = shopNum1_ProductCategory_Action.GetFurnitureProduct(addcode, string_6, string_2, string_5,
                string_4, strStartPrice, strEndPrice, "",
                brandguid, ShowCount.ToString(),
                int_0.ToString(), "1", dictionary_0, CookieCustomerCategory);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("search_product", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "<<上一页",
                NextPageText = "下一页>> "
            };
            textBox_0.Text = int_0.ToString();
            htmlGenericControl_0.InnerHtml = bll.GetPageListVk(pl);
            label_0.Text = pl.PageCount.ToString();
            DataSet set2 = shopNum1_ProductCategory_Action.GetFurnitureProduct(addcode, string_6, string_2, string_5,
                string_4, strStartPrice, strEndPrice,
                "", brandguid, ShowCount.ToString(),
                int_0.ToString(), "0", dictionary_0, CookieCustomerCategory);
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                repeater_1.DataSource = set2.Tables[0];
                repeater_1.DataBind();
                repeater_0.DataSource = set2.Tables[0];
                repeater_0.DataBind();
            }
            else
            {
                string url = GetPageName.AgentRetUrl("ProductSearchNofind", string_3, "search");
                Page.Response.Redirect(url);
            }
        }


        private bool method_2(string string_10)
        {
            string[] strArray = string_10.Split(new[] {'-'});
            if (strArray.Length != 0)
            {
                dictionary_0 = new Dictionary<string, string>();
                foreach (string str in strArray)
                {
                    string[] strArray3 = str.Split(new[] {'a'});
                    if (strArray3.Length == 2)
                    {
                        dictionary_0.Add(strArray3[0], strArray3[1]);
                    }
                }
            }
            return true;
        }

        protected void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterShopEnsure");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldMemLoginID");
                string shopid = field.Value.Trim().Replace("'", "");
                DataTable shopapplyEnsure =
                    ((ShopNum1_Ensure_Action) LogicFactory.CreateShopNum1_Ensure_Action()).GetShopapplyEnsure(shopid);
                repeater.DataSource = shopapplyEnsure.DefaultView;
                repeater.DataBind();
            }
        }
    }
}