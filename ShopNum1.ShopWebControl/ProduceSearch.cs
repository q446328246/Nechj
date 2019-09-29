using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProduceSearch : BaseWebControl
    {
        private Button ButtonSearch;
        private TextBox TextBoxKeywordsSearch;
        private TextBox TextBoxPriceEndSearch;
        private TextBox TextBoxPriceStartSearch;
        private string skinFilename = "ProduceSearch.ascx";

        public ProduceSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            TextBoxKeywordsSearch = (TextBox) skin.FindControl("TextBoxKeywordsSearch");
            TextBoxPriceStartSearch = (TextBox) skin.FindControl("TextBoxPriceStartSearch");
            TextBoxPriceEndSearch = (TextBox) skin.FindControl("TextBoxPriceEndSearch");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += TextBoxPriceEndSearch_TextChanged;
            TextBoxKeywordsSearch.TextChanged += TextBoxPriceEndSearch_TextChanged;
            TextBoxPriceEndSearch.TextChanged += TextBoxPriceEndSearch_TextChanged;
            if (!Page.IsPostBack)
            {
            }
        }

        protected void TextBoxPriceEndSearch_TextChanged(object sender, EventArgs e)
        {
            string url = string.Empty;
            string text = TextBoxKeywordsSearch.Text;
            string str5 = CookieCustomerCategory.ToString();
            try
            {
                string str3 = TextBoxPriceStartSearch.Text;
                string str4 = TextBoxPriceEndSearch.Text;
                
                url = "http://" + HttpContext.Current.Request.Url.Host + "/ProductSearchList.aspx?category="+str5+"&keywords=" + text +
                      "&priceStart=" + str3 + "&priceEnd=" + str4;
                Page.Response.Write("<script>window.location.href='" + url + "';</script>");
            }
            catch (Exception exception)
            {
                if (exception.Message !=
                    "ee.Message\tUnable to evaluate expression because the code is optimized or a native frame is on top of the call stack.\tstring")
                {
                    MessageBox.Show(exception.Message);
                    url = "http://" + HttpContext.Current.Request.Url.Host + "/ProductSearchList.aspx?category=" + str5 + "&keywords=" + text +
                          "&priceStart=&priceEnd=";
                    Page.Response.Redirect(url);
                }
            }
        }
    }
}