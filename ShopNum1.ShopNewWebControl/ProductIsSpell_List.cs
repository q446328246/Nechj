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
    public class ProductIsSpell_List : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        private Button ButtonSure;
        private DropDownList DropDownListSort;
        private ImageButton ImageButtonGrid;
        private ImageButton ImageButtonList;

        private Label LabelPageCount;
        private Panel PanelNoFind;
        private Repeater RepeaterDataGrid;
        private Repeater RepeaterDataList;

        private TextBox TextBoxIndex;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "ProductIsSpell_List.ascx";

        public ProductIsSpell_List()
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
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername + "&pageid=" + str);
        }

        protected void DropDownListSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["SortStyle"] = DropDownListSort.SelectedValue;
            BindData();
        }

        public void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
        {
            ImageButtonGrid.ImageUrl = "../Images/productDisplayGrid.gif";
            ImageButtonList.ImageUrl = "../Images/display_mode_list.gif";
            //ViewState["ShowStyle"] = "Grid";
            //==================List========================

            Page.Session["HttpGriddd"] = "Grid";

            //==================List-end===================

            BindData();
        }

        public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
        {
            ImageButtonGrid.ImageUrl = "../Images/display_mode_grid.gif";
            ImageButtonList.ImageUrl = "../Images/display_mode_list_act.gif";
            //ViewState["ShowStyle"] = "List";
            //==================List========================

            Page.Session["HttpGriddd"] = "List";

            //==================List-end===================

            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            ordername = (Page.Request.QueryString["ordername"] == null) ? "guid" : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            ImageButtonList = (ImageButton) skin.FindControl("ImageButtonList");
            ImageButtonGrid = (ImageButton) skin.FindControl("ImageButtonGrid");
            DropDownListSort = (DropDownList) skin.FindControl("DropDownListSort");
            ImageButtonGrid.Click += ImageButtonGrid_Click;
            ImageButtonList.Click += ImageButtonList_Click;
            DropDownListSort.SelectedIndexChanged += DropDownListSort_SelectedIndexChanged;
            RepeaterDataGrid = (Repeater) skin.FindControl("RepeaterDataGrid");
            RepeaterDataList = (Repeater) skin.FindControl("RepeaterDataList");
            RepeaterDataGrid.ItemCommand += RepeaterDataGrid_ItemCommand;
            //ViewState["ShowStyle"] = "Grid";
            ViewState["SortStyle"] = "CreateTime";
            BindData();
        }

        protected void BindData()
        {
            //==========默认值=============
            if (Page.Session["HttpGriddd"] == null)
            {
                Page.Session["HttpGriddd"] = "List";
            }
            //==========默认值end==========

            if (ShowCount.ToString() == "")
            {
                ShowCount = 10;
            }
            var action = new Shop_GroupProduct_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            string condition = "  and State=1 and memloginid='" + MemLoginID + "'";
            DataTable table = action.SelectGroupProduct(ShowCount.ToString(), int_0.ToString(), condition, "3", "desc",
                "id");
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("SpellBuyList", true)
                {
                    ShowRecordCount = true,
                    ShowPageCount = false,
                    ShowPageIndex = false,
                    ShowNoRecordInfo = false,
                    ShowNumListButton = true,
                    PrevPageText = "上一页",
                    NextPageText = "下一页 "
                }.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            if (int_0 > pl.PageCount)
            {
                int_0 = pl.PageCount;
            }
            DataTable table2 = action.SelectGroupProduct(ShowCount.ToString(), int_0.ToString(), condition, "2", "desc",
                "id");
            if (table2.Rows.Count == 0)
            {
                PanelNoFind.Visible = true;
            }
            if (Page.Session["HttpGriddd"].ToString().ToLower() == "Grid".ToLower())
            {
                RepeaterDataList.Visible = false;
                RepeaterDataGrid.Visible = true;
                RepeaterDataGrid.DataSource = table2.DefaultView;
                RepeaterDataGrid.DataBind();
            }
            else if (Page.Session["HttpGriddd"].ToString().ToLower() == "List".ToLower())
            {
                RepeaterDataGrid.Visible = false;
                RepeaterDataList.Visible = true;
                RepeaterDataList.DataSource = table2.DefaultView;
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