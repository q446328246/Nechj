using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductListIsPromotion : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ProductListIsPromotion.ascx";

        public ProductListIsPromotion()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemCommand += RepeaterData_ItemCommand;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            string url = Page.Request.Url.ToString();
            int Category;
            if (url.IndexOf("shop100000027") > -1)
            {
                Category = CookieCustomerCategory;
            }
            else
            {
                Category = 9;
            }
            DataTable table =
                ((Shop_Product_Action) LogicFactory.CreateShop_Product_Action()).GetIsProductAndRecommend("-1", "-1",
                    "1", "-1", "0",
                    "0",
                    ShowCount
                        .ToString(),
                    "Modifytime",
                    MemLoginID, Category);
            RepeaterData.DataSource = table;
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemCommand(object sender, RepeaterCommandEventArgs e)
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
                var literal2 = (Literal) e.Item.FindControl("LiteralGroupPrice");
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