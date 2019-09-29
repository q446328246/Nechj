using System;
using System.Data;
using System.Web;
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
    public class ProductListIsRecommendMoreNew : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        private Button ButtonSure;
        private HtmlGenericControl ICreatime;
        private HtmlGenericControl IPrice;
        private HtmlGenericControl IRenqi;
        private HtmlGenericControl ISales;
        private ImageButton ImageButtonGrid;
        private Label LabelCurrent;
        private Label LabelPageCount;
        private Label LabelTotal;
        private LinkButton LinkButtonCreatime;
        private LinkButton LinkButtonNextPage;
        private LinkButton LinkButtonPrice;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private Panel PanelNoFind;
        private Repeater RepeaterDataGrid;
        private Repeater RepeaterDataList;

        private TextBox TextBoxIndex;
        private ImageButton imageButtonSure;
        private int int_0;
        private int int_1;
        private LinkButton linkButtonSure;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "ProductListIsRecommendMoreNew.ascx";

        public ProductListIsRecommendMoreNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string ordername { get; set; }

        public int PageCount { get; set; }

        public int ShowCount { get; set; }

        public string soft { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(TextBoxIndex.Text.Trim());
            if (num > int_0)
            {
                num = int_0;
            }
            Page.Response.Redirect(
                string.Concat(new object[] {string_1, "?sort=", soft, "&ordername=", ordername, "&pageid=", num}));
        }

        public void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["ShowStyle"] = "Grid";
            method_1();
            imageButtonSure.ImageUrl = "../Images/tabulat.png";
            ImageButtonGrid.ImageUrl = "../Images/large_bg.png";
        }

        public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["ShowStyle"] = "List";
            method_1();
            imageButtonSure.ImageUrl = "../Images/display_mode_list_act.gif";
            ImageButtonGrid.ImageUrl = "../Images/display_mode_grid.gif";
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
            linkButtonSure = (LinkButton) skin.FindControl("LinkButtonPrevPage");
            linkButtonSure.Click += linkButtonSure_Click;
            LinkButtonNextPage = (LinkButton) skin.FindControl("LinkButtonNextPage");
            LinkButtonNextPage.Click += LinkButtonNextPage_Click;
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
                ? "modifytime"
                : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            imageButtonSure = (ImageButton) skin.FindControl("ImageButtonList");
            ImageButtonGrid = (ImageButton) skin.FindControl("ImageButtonGrid");
            ImageButtonGrid.Click += ImageButtonGrid_Click;
            imageButtonSure.Click += ImageButtonList_Click;
            RepeaterDataGrid = (Repeater) skin.FindControl("RepeaterDataGrid");
            RepeaterDataList = (Repeater) skin.FindControl("RepeaterDataList");
            RepeaterDataGrid.ItemCommand += RepeaterDataGrid_ItemCommand;
            ViewState["ShowStyle"] = "Grid";
            ViewState["SortStyle"] = "modifytime";
            method_1();
            method_0(ordername, soft);
        }

        protected void linkButtonSure_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[] {string_1, "?sort=", soft, "&ordername=", ordername, "&pageid=", int_1 - 1}));
        }

        protected void LinkButtonNextPage_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[] {string_1, "?sort=", soft, "&ordername=", ordername, "&pageid=", int_1 + 1}));
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
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername);
        }

        protected void LinkButtonSales_Click(object sender, EventArgs e)
        {
            if (ordername == "salenumber")
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
                ordername = "salenumber";
                soft = "desc";
            }
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername);
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
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername);
        }

        protected void LinkButtonPrice_Click(object sender, EventArgs e)
        {
            if (ordername == "shopprice")
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
                ordername = "shopprice";
                soft = "desc";
            }
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername);
        }

        protected void method_0(string string_5, string string_6)
        {
            string_5 = string_5.ToLower();
            if (soft == "desc")
            {
                if (string_5 == "shopprice")
                {
                    LinkButtonPrice.CssClass = "as_rise as_down";
                    IPrice.Attributes.Add("class", "comSort-d");
                }
                if (string_5 == "salenumber")
                {
                    LinkButtonSales.CssClass = "as_rise as_down";
                    ISales.Attributes.Add("class", "comSort-d");
                }
                if (string_5 == "collectcount")
                {
                    LinkButtonRenqi.CssClass = "as_rise as_down";
                    IRenqi.Attributes.Add("class", "comSort-d");
                }
                if (string_5 == "modifytime")
                {
                    LinkButtonCreatime.CssClass = "as_rise as_down";
                    ICreatime.Attributes.Add("class", "comSort-d");
                }
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
            DataSet set = action.GetIsProductNewAndRecommend("-1", "-1", "-1", "1", ordername, MemLoginID, soft,
                ShowCount.ToString(), int_1.ToString(), "1",CookieCustomerCategory);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ProductListPromotion", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
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
            if ((int_1 + pl.PageCount) == 2)
            {
                linkButtonSure.Enabled = false;
                LinkButtonNextPage.Enabled = false;
                linkButtonSure.CssClass = "pgup pgnext";
                LinkButtonNextPage.CssClass = "pgup pgnext";
            }
            else if (int_1 == pl.PageCount)
            {
                linkButtonSure.Enabled = true;
                LinkButtonNextPage.Enabled = false;
                LinkButtonNextPage.CssClass = "pgup pgnext";
            }
            else
            {
                linkButtonSure.Enabled = false;
                linkButtonSure.CssClass = "pgup pgnext";
                LinkButtonNextPage.Enabled = true;
            }
            DataSet set2 = action.GetIsProductNewAndRecommend("-1", "-1", "-1", "1", ordername, MemLoginID, soft,
                ShowCount.ToString(), int_1.ToString(), "0",CookieCustomerCategory);
            if ((set2.Tables[0] == null) || (set2.Tables[0].Rows.Count == 0))
            {
                PanelNoFind.Visible = true;
            }
            else if (ViewState["ShowStyle"].ToString().ToLower() == "Grid".ToLower())
            {
                RepeaterDataList.Visible = false;
                RepeaterDataGrid.Visible = true;
                RepeaterDataGrid.DataSource = set2.Tables[0];
                RepeaterDataGrid.DataBind();
            }
            else if (ViewState["ShowStyle"].ToString().ToLower() == "List".ToLower())
            {
                RepeaterDataGrid.Visible = false;
                RepeaterDataList.Visible = true;
                RepeaterDataList.DataSource = set2.Tables[0];
                RepeaterDataList.DataBind();
            }
        }

        protected void RepeaterDataGrid_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            int Category = 1;
            if (Page.Request.QueryString["category"] != null)
            {
                Category = Convert.ToInt32(Page.Request.QueryString["category"]);
            }
            else
            {
                Category = Convert.ToInt32(Page.Request.Cookies["category"].Value);
            }
            if (e.CommandName == "BtnProductCollect")
            {
                var literal = (Literal) e.Item.FindControl("LiteralMemLoginID");
                var literal2 = (Literal) e.Item.FindControl("LiteralShopPrice");
                string text = literal2.Text;
                var literal3 = (Literal) e.Item.FindControl("LiteralProductName");
                string productName = literal3.Text;
                var literal4 = (Literal) e.Item.FindControl("LiteralShopName");
                string shopID = literal4.Text;
                var literal5 = (Literal) e.Item.FindControl("LiteralProductGuid");
                string productguid = literal5.Text;
                string isAttention = "0";
                if (Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                    string memloginid = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
                    var action = (Shop_Collect_Action) LogicFactory.CreateShop_Collect_Action();
                    if (literal.Text == memloginid)
                    {
                        MessageBox.Show("您不能收藏自己的商品！");
                    }
                    else if (
                        action.AddProductCollect(memloginid, productguid, shopID, isAttention, text, productName,
                            literal.Text, Category) > 0)
                    {
                        MessageBox.Show("收藏成功!");
                        action.ProductCollectNum(productguid);
                    }
                    else
                    {
                        MessageBox.Show("已收藏过该商品!");
                    }
                }
                else
                {
                    GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再收藏！");
                }
            }
        }
    }
}