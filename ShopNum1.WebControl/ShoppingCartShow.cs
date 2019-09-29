using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShoppingCartShow : BaseWebControl
    {
        private Label LabelAllPrice;
        private Label LableProductCount;
        private HyperLink shoppingCart;
        private string skinFilename = "ShoppingCartShow.ascx";

        public ShoppingCartShow()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LableProductCount = (Label) skin.FindControl("LableProductCount");
            LabelAllPrice = (Label) skin.FindControl("LabelAllPrice");
            shoppingCart = (HyperLink) skin.FindControl("shoppingCart");
            if (!Page.IsPostBack)
            {
            }
            string text = string.Empty;
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie httpCookie = Page.Request.Cookies["MemberLoginCookie"];
                if (httpCookie.Values.Count != 0)
                {
                    HttpCookie httpCookie2 = HttpSecureCookie.Decode(httpCookie);
                    text = httpCookie2.Values["MemLoginID"];
                }
            }
            else
            {
                Page.Response.Redirect(GetPageName.RetUrl("login"));
            }
            method_0(text);
            shoppingCart.Target = "_blank";
            shoppingCart.NavigateUrl = GetPageName.RetUrl("ShoppingCart1", text, "LoginID");
        }

        protected void method_0(string string_1)
        {
            string text = "0";
            string text2 = "0.00";
            if (string_1 != string.Empty)
            {
                var shopNum1_Cart_Action = (ShopNum1_Cart_Action) LogicFactory.CreateShopNum1_Cart_Action();
                DataTable dataTable = shopNum1_Cart_Action.SearchBuyPriceByMemLoginID(string_1);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    text =
                        Convert.ToString(Convert.ToInt32(text) +
                                         Convert.ToInt32(dataTable.Rows[i]["BuyNumber"].ToString()));
                    string value =
                        (Convert.ToDecimal(dataTable.Rows[i]["BuyPrice"].ToString())*
                         Convert.ToInt32(dataTable.Rows[i]["BuyNumber"].ToString())).ToString();
                    text2 = Convert.ToString(Convert.ToDecimal(text2) + Convert.ToDecimal(value));
                }
            }
            LabelAllPrice.Text = text2;
            LableProductCount.Text = text;
        }
    }
}