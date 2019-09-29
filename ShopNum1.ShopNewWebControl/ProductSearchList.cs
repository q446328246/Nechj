using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class ProductSearchList : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        private Button ButtonSearch;
        private Button ButtonSure;
        private HtmlGenericControl ICreatime;
        private HtmlGenericControl IPrice;
        private HtmlGenericControl IRenqi;
        private HtmlGenericControl ISales;
        private Label LabelCurrent;
        private Label LabelPageCount;
        private Label LabelSearch;
        private Label LabelTotal;
        private LinkButton LinkButtonCreatime;
        private LinkButton LinkButtonPrevPage;
        private LinkButton LinkButtonPrice;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private Panel PanelNoFind;
        private Repeater RepeaterDataGrid;
        private Repeater RepeaterDataList;
        private TextBox TextBoxIndex;

        private TextBox TextBoxKeywords;
        private TextBox TextBoxPriceEnd;
        private TextBox TextBoxPriceStart;
        private ImageButton imageButtonSearch;
        private ImageButton imageButtonSure;
        private int int_0;
        private int int_1;
        private LinkButton linkButtonSure;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "ProductSearchListNew.ascx";

        public ProductSearchList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Keywords { get; set; }

        public string MemLoginID { get; set; }

        public string ordername { get; set; }

        public int PageCount { get; set; }

        public string PriceEnd { get; set; }

        public string PriceStart { get; set; }

        public string ProductCode { get; set; }

        public int ShowCount { get; set; }

        private string ShowStype { get; set; }

        public string soft { get; set; }

        public string category { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(TextBoxIndex.Text.Trim());
            if (num > int_0)
            {
                num = int_0;
            }
            if (Page.Request.QueryString["code"] != null)
            {
                Page.Response.Redirect(string.Concat(new object[]
                {
                    string_1, "?showstyle=", ShowStype, "&keywords=", Keywords, "&priceStart=", PriceStart,
                    "&priceEnd=", PriceEnd, "&sort=", soft, "&ordername=", ordername, "&pageid=", num, "&code=",
                    Page.Request.QueryString["code"]
                }));
            }
            else
            {
                Page.Response.Redirect(
                    string.Concat(new object[]
                    {
                        string_1, "?showstyle=", ShowStype, "&keywords=", Keywords, "&priceStart=", PriceStart,
                        "&priceEnd=", PriceEnd, "&sort=", soft, "&ordername=", ordername, "&pageid=", num
                    }));
            }
        }

        public void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
        {
            Page.Response.Redirect(string_1 + "?showstyle=Grid&keywords=" + Keywords + "&priceStart=" + PriceStart +
                                   "&priceEnd=" + PriceEnd + "&sort=" + soft + "&ordername=" + ordername + "&pageid=1");
        }

        public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
        {
            Page.Response.Redirect(string_1 + "?showstyle=List&keywords=" + Keywords + "&priceStart=" + PriceStart +
                                   "&priceEnd=" + PriceEnd + "&sort=" + soft + "&ordername=" + ordername + "&pageid=1");
        }

        protected override void InitializeSkin(Control skin)
        {
            LinkButtonRenqi = (LinkButton) skin.FindControl("LinkButtonRenqi");
            LinkButtonRenqi.Click += LinkButtonRenqi_Click;
            LinkButtonSales = (LinkButton) skin.FindControl("LinkButtonSales");
            LinkButtonSales.Click += LinkButtonSales_Click;
            LinkButtonCreatime = (LinkButton) skin.FindControl("LinkButtonCreatime");
            LinkButtonCreatime.Click += LinkButtonCreatime_Click;
            LinkButtonPrice = (LinkButton) skin.FindControl("LinkButtonPrice");
            LinkButtonPrice.Click += LinkButtonPrice_Click;
            IRenqi = (HtmlGenericControl) skin.FindControl("IRenqi");
            ISales = (HtmlGenericControl) skin.FindControl("ISales");
            ICreatime = (HtmlGenericControl) skin.FindControl("ICreatime");
            IPrice = (HtmlGenericControl) skin.FindControl("IPrice");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            LabelCurrent = (Label) skin.FindControl("LabelCurrent");
            LabelTotal = (Label) skin.FindControl("LabelTotal");
            LinkButtonPrevPage = (LinkButton) skin.FindControl("LinkButtonPrevPage");
            LinkButtonPrevPage.Click += LinkButtonPrevPage_Click;
            linkButtonSure = (LinkButton) skin.FindControl("LinkButtonNextPage");
            linkButtonSure.Click += linkButtonSure_Click;
            LabelSearch = (Label) skin.FindControl("LabelSearch");
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            int_1 = 1;
            try
            {
                int_1 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_1 = 1;
            }
            ordername = (Page.Request.QueryString["ordername"] == null)
                ? "ModifyTime"
                : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            TextBoxPriceStart = (TextBox) skin.FindControl("TextBoxPriceStart");
            TextBoxPriceEnd = (TextBox) skin.FindControl("TextBoxPriceEnd");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += TextBoxPriceEnd_TextChanged;
            TextBoxKeywords.TextChanged += TextBoxPriceEnd_TextChanged;
            TextBoxPriceEnd.TextChanged += TextBoxPriceEnd_TextChanged;
            imageButtonSearch = (ImageButton) skin.FindControl("ImageButtonList");
            imageButtonSure = (ImageButton) skin.FindControl("ImageButtonGrid");
            imageButtonSure.Click += ImageButtonGrid_Click;
            imageButtonSearch.Click += ImageButtonList_Click;
            RepeaterDataGrid = (Repeater) skin.FindControl("RepeaterDataGrid");
            RepeaterDataList = (Repeater) skin.FindControl("RepeaterDataList");
            ShowStype = (Common.Common.ReqStr("showstyle") == "") ? "Grid" : Common.Common.ReqStr("showstyle");
            if (!Page.IsPostBack)
            {
                ViewState["ShowStyle"] = "Grid";
                ViewState["SortStyle"] = "ModifyTime";
            }
            if ((Page.Request.QueryString["keywords"] != null) && (Page.Request.QueryString["keywords"] != ""))
            {
                Keywords = Page.Request.QueryString["keywords"];
                TextBoxKeywords.Text = Keywords;
            }
            if ((Page.Request.QueryString["priceStart"] != null) && (Page.Request.QueryString["priceStart"] != ""))
            {
                PriceStart = Page.Request.QueryString["priceStart"];
                TextBoxPriceStart.Text = PriceStart;
            }
            if ((Page.Request.QueryString["priceEnd"] != null) && (Page.Request.QueryString["priceEnd"] != ""))
            {
                PriceEnd = Page.Request.QueryString["priceEnd"];
                TextBoxPriceEnd.Text = PriceEnd;
            }
            if ((Page.Request.QueryString["code"] != null) && (Page.Request.QueryString["code"] != ""))
            {
                ProductCode = Page.Request.QueryString["code"];
            }
            category = CookieCustomerCategory.ToString();
            method_1();
            method_0(ordername, soft);
        }

        protected void LinkButtonPrevPage_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[]
                {
                    string_1, "?category=",category,"&showstyle=", ShowStype, "&keywords=", Keywords, "&priceStart=", PriceStart,
                    "&priceEnd=", PriceEnd, "&sort=", soft, "&ordername=", ordername, "&pageid=", int_1 - 1
                }));
        }

        protected void linkButtonSure_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[]
                {
                    string_1, "?category=",category,"&showstyle=",  ShowStype, "&keywords=", Keywords, "&priceStart=", PriceStart,
                    "&priceEnd=", PriceEnd, "&sort=", soft, "&ordername=", ordername, "&pageid=", int_1 + 1
                }));
        }

        protected void LinkButtonRenqi_Click(object sender, EventArgs e)
        {
            if (ordername == "collectcount")
            {
                soft = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((soft == "asc") || (soft == ""))
                {
                    soft = "desc";
                }
                else
                {
                    soft = "asc";
                }
            }
            else
            {
                ordername = "collectcount";
                soft = "desc";
            }
            Page.Response.Redirect(string_1 + "?showstyle=" + ShowStype + "&keywords=" + Keywords + "&priceStart=" +
                                   PriceStart + "&priceEnd=" + PriceEnd + "&sort=" + soft + "&ordername=" + ordername);
        }

        protected void LinkButtonSales_Click(object sender, EventArgs e)
        {
            if (ordername == "salenumber")
            {
                soft = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((soft == "desc") || (soft == ""))
                {
                    soft = "asc";
                }
                else
                {
                    soft = "desc";
                }
            }
            else
            {
                ordername = "salenumber";
                soft = "desc";
            }
            Page.Response.Redirect(string_1 + "?showstyle=" + ShowStype + "&keywords=" + Keywords + "&priceStart=" +
                                   PriceStart + "&priceEnd=" + PriceEnd + "&sort=" + soft + "&ordername=" + ordername);
        }

        protected void LinkButtonCreatime_Click(object sender, EventArgs e)
        {
            if (ordername == "modifytime")
            {
                soft = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((soft == "asc") || (soft == ""))
                {
                    soft = "desc";
                }
                else
                {
                    soft = "asc";
                }
            }
            else
            {
                ordername = "modifytime";
                soft = "desc";
            }
            Page.Response.Redirect(string_1 + "?showstyle=" + ShowStype + "&keywords=" + Keywords + "&priceStart=" +
                                   PriceStart + "&priceEnd=" + PriceEnd + "&sort=" + soft + "&ordername=" + ordername);
        }

        protected void LinkButtonPrice_Click(object sender, EventArgs e)
        {
            if (ordername == "shopprice")
            {
                soft = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((soft == "desc") || (soft == ""))
                {
                    soft = "asc";
                }
                else
                {
                    soft = "desc";
                }
            }
            else
            {
                ordername = "shopprice";
                soft = "desc";
            }
            Page.Response.Redirect(string_1 + "?showstyle=" + ShowStype + "&keywords=" + Keywords + "&priceStart=" +
                                   PriceStart + "&priceEnd=" + PriceEnd + "&sort=" + soft + "&ordername=" + ordername);
        }

        protected void method_0(string string_10, string string_11)
        {
            string_10 = string_10.ToLower();
            if ((soft == "asc") || (soft == ""))
            {
                if (string_10 == "shopprice")
                {
                    LinkButtonPrice.ToolTip = "价格从低到高";
                    LinkButtonPrice.CssClass = "as_rise";
                    IPrice.Attributes.Add("class", "comSort-d");
                }
                if (string_10 == "salenumber")
                {
                    LinkButtonSales.ToolTip = "销量从低到高";
                    LinkButtonSales.CssClass = "as_rise";
                    ISales.Attributes.Add("class", "comSort-d");
                }
                if (string_10 == "collectcount")
                {
                    LinkButtonRenqi.ToolTip = "人气从低到高";
                    LinkButtonRenqi.CssClass = "as_rise";
                    IRenqi.Attributes.Add("class", "comSort-d");
                }
                if (string_10 == "modifytime")
                {
                    LinkButtonCreatime.ToolTip = "时间从先到后";
                    LinkButtonCreatime.CssClass = "as_rise";
                    ICreatime.Attributes.Add("class", "comSort-d");
                }
            }
            if (ShowStype.ToLower() == "list")
            {
                imageButtonSure.ImageUrl = "../Images/display_mode_grid.gif";
                imageButtonSearch.ImageUrl = "../Images/display_mode_list_act.gif";
            }
        }

        protected void method_1()
        {
            var action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_1
            };
            DataSet set = action.SearchProductListNew(MemLoginID, Keywords, PriceStart, PriceEnd, ProductCode, ordername,
                soft, ShowCount.ToString(), int_1.ToString(), "1",CookieCustomerCategory);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            LabelSearch.Text = pl.RecordCount.ToString();
            var bll = new PageListBll("ProductSearchList", true)
            {
                ShowPageCount = false,
                ShowPageIndex = false,
                ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页 "
            };
            TextBoxIndex.Text = LabelCurrent.Text = int_1.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = LabelTotal.Text = pl.PageCount.ToString();
            int_0 = pl.PageCount;
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (int_1 > pl.PageCount)
            {
                int_1 = pl.PageCount;
            }
            if (int_1 == pl.PageCount)
            {
                LinkButtonPrevPage.Enabled = true;
                linkButtonSure.Enabled = false;
                linkButtonSure.CssClass = "pgup pgnext";
            }
            if (int_1 == 1)
            {
                LinkButtonPrevPage.Enabled = false;
                LinkButtonPrevPage.CssClass = "pgup pgnext";
                linkButtonSure.Enabled = true;
                if (int_1 == pl.PageCount)
                {
                    LinkButtonPrevPage.Enabled = false;
                    linkButtonSure.Enabled = false;
                    linkButtonSure.CssClass = "pgup pgnext";
                }
            }
            if ((pl.RecordCount == 0) || (pl.RecordCount < pl.PageCount))
            {
                LinkButtonPrevPage.Enabled = false;
                linkButtonSure.Enabled = false;
                linkButtonSure.CssClass = "pgup pgnext";
                LinkButtonPrevPage.CssClass = "pgup pgnext";
            }
            DataSet set2 = action.SearchProductListNew(MemLoginID, Keywords, PriceStart, PriceEnd, ProductCode,
                ordername, soft, ShowCount.ToString(), int_1.ToString(), "0",CookieCustomerCategory);
            if ((set2.Tables[0] == null) || (set2.Tables[0].Rows.Count == 0))
            {
                PanelNoFind.Visible = true;
            }
            else if (ShowStype.ToLower() == "Grid".ToLower())
            {
                RepeaterDataList.Visible = false;
                RepeaterDataGrid.Visible = true;
                RepeaterDataGrid.DataSource = set2.Tables[0];
                RepeaterDataGrid.DataBind();
            }
            else if (ShowStype.ToLower() == "List".ToLower())
            {
                RepeaterDataGrid.Visible = false;
                RepeaterDataList.Visible = true;
                RepeaterDataList.DataSource = set2.Tables[0];
                RepeaterDataList.DataBind();
            }
        }

        protected void TextBoxPriceEnd_TextChanged(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                GetPageName.GetPage("?showstyle=" + ShowStype + "&keywords=" +
                                    Operator.FilterString(TextBoxKeywords.Text) +
                                    "&priceStart=" + TextBoxPriceStart.Text + "&priceEnd=" + TextBoxPriceEnd.Text +
                                    "&sort=" + soft +
                                    "&ordername=" + ordername));
        }
    }
}