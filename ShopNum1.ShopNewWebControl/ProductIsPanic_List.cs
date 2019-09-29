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
    public class ProductIsPanic_List : BaseWebControl
    {
        public static int finished = 0;
        public static int int_0 = 0;
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
        private int int_1;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "ProductIsPanic_ListNew.ascx";

        public ProductIsPanic_List()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static string Isfinished { get; set; }

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
            //ViewState["ShowStyle"] = "Grid";
            //==================List========================

            Page.Session["HttpGriddd"] = "Grid";

            //==================List-end===================
            BindData();
        }

        public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
        {
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
            int_1 = 1;
            try
            {
                int_1 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_1 = 1;
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
            if (!Page.IsPostBack)
            {
                //ViewState["ShowStyle"] = "Grid";
                ViewState["SortStyle"] = "CreateTime";
            }
            BindData();
        }

        public static string IsBegin(object begin, object object_0)
        {
            if (DateTime.Parse(begin.ToString()) > DateTime.Now)
            {
                return begin.ToString();
            }
            if (Isfinished == "1")
            {
                return "1900-1-1";
            }
            return object_0.ToString();
        }

        protected void BindData()
        {
            //==========默认值=============
            if (Page.Session["HttpGriddd"] == null)
            {
                Page.Session["HttpGriddd"] = "List";
            }
            else if (Page.Session["HttpGriddd"].ToString() == "List")
            {
                Page.Session["HttpGriddd"] = "List";
            }
            else
            {
                Page.Session["HttpGriddd"] = "Grid";
            }
            //==========默认值end==========
            var action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_1
            };
            DataSet set = action.GetIsProductNewProductState("-1", "-1", "-1", "1", "-1", ordername, MemLoginID, soft,
                ShowCount.ToString(), int_1.ToString(), "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ProductIsPanic_List", true)
            {
                ShowPageCount = false,
                ShowPageIndex = false,
                ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页 "
            };
            TextBoxIndex.Text = int_1.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (int_1 > pl.PageCount)
            {
                int_1 = pl.PageCount;
            }
            DataSet set2 = action.GetIsProductNewProductState("-1", "-1", "-1", "1", "-1", ordername, MemLoginID, soft,
                ShowCount.ToString(), int_1.ToString(), "0");
            if ((set2.Tables[0] == null) || (set2.Tables[0].Rows.Count == 0))
            {
                PanelNoFind.Visible = true;
            }
            else if (Page.Session["HttpGriddd"].ToString().ToLower() == "Grid".ToLower())
            {
                RepeaterDataList.Visible = false;
                RepeaterDataGrid.Visible = true;
                RepeaterDataGrid.DataSource = set2.Tables[0];
                RepeaterDataGrid.DataBind();
            }
            else if (Page.Session["HttpGriddd"].ToString().ToLower() == "List".ToLower())
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