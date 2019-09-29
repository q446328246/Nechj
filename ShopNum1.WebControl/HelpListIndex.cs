using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class HelpListIndex : BaseWebControl
    {
        private Button ButtonAgainSearch;
        private Repeater RepeaterData;
        private TextBox TextBoxSearch;
        private string skinFilename = "HelpListIndex.ascx";
        private string string_1;

        public HelpListIndex()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonAgainSearch_Click(object sender, EventArgs e)
        {
            string_1 = (TextBoxSearch.Text.Trim().Replace("'", "") == string.Empty)
                ? "-1"
                : TextBoxSearch.Text.Trim().Replace("'", "");
            string url = GetPageName.AgentRetUrl("HelpListSearch", string_1, "search");
            Page.Response.Redirect(url);
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            ButtonAgainSearch = (Button) skin.FindControl("ButtonAgainSearch");
            ButtonAgainSearch.Click += ButtonAgainSearch_Click;
            TextBoxSearch = (TextBox) skin.FindControl("TextBoxSearch");
            if (!Page.IsPostBack)
            {
            }
        }
    }
}