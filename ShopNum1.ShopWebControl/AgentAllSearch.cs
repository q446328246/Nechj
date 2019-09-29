using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class AgentAllSearch : BaseWebControl
    {
        private Button ButtonAllSearch;
        private DropDownList DropDownListType;
        private TextBox TextBoxSearchWhere;
        private string skinFilename = "AgentAllSearch.ascx";

        public AgentAllSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonAllSearch_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(SetUrl(DropDownListType.SelectedValue + TextBoxSearchWhere.Text));
        }

        protected override void InitializeSkin(Control skin)
        {
            string text1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            TextBoxSearchWhere = (TextBox) skin.FindControl("TextBoxSearchWhere");
            ButtonAllSearch = (Button) skin.FindControl("ButtonAllSearch");
            ButtonAllSearch.Click += ButtonAllSearch_Click;
            BindData();
        }

        protected void BindData()
        {
            string overrideUrlName = string.Empty;
            string str5 = CookieCustomerCategory.ToString();
            if (ShopSettings.IsOverrideUrl)
            {
                overrideUrlName = ShopSettings.overrideUrlName;
            }
            else
            {
                overrideUrlName = ".aspx";
            }
            DropDownListType.Items.Add(new ListItem("商品", "/ProductListSearch" + overrideUrlName + "?category="+str5+"&search="));
            DropDownListType.Items.Add(new ListItem("店铺", "/ShopListSearch" + overrideUrlName + "?category=" + str5 + "&search="));
            DropDownListType.Items.Add(new ListItem("文章", "/ArticleListSearch" + overrideUrlName + "?category=" + str5 + "&search="));
            DropDownListType.Items.Add(new ListItem("分类", "/CategoryListSearch" + overrideUrlName + "?category=" + str5 + "&search="));
            DropDownListType.Items.Add(new ListItem("供求", "/SupplyDemandListSearch" + overrideUrlName + "?category=" + str5 + "&search="));
        }

        public string SetUrl(string page)
        {
            return ("http://" + ConfigurationManager.AppSettings["Domain"] + page);
        }
    }
}