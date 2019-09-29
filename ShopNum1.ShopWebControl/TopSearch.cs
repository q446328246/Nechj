using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class TopSearch : BaseWebControl
    {
        private Button ButtonAllSearch;
        private Button ButtonIn;
        private TextBox TextBoxSearchWhere;
        private string skinFilename = "TopSearch.ascx";

        public TopSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonAllSearch_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(GetPageName.RetDomainUrl("Search_productlist", TextBoxSearchWhere.Text, "search"));
        }

        protected void ButtonIn_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(GetPageName.RetUrl("ProductSearchList", TextBoxSearchWhere.Text, "keywords",CookieCustomerCategory));
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxSearchWhere = (TextBox) skin.FindControl("TextBoxSearchWhere");
            ButtonAllSearch = (Button) skin.FindControl("ButtonAllSearch");
            ButtonAllSearch.Click += ButtonAllSearch_Click;
            ButtonIn = (Button) skin.FindControl("ButtonIn");
            ButtonIn.Click += ButtonIn_Click;
        }
    }
}