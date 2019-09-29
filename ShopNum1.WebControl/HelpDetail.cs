using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class HelpDetail : BaseWebControl
    {
        private Button ButtonAgainSearch;
        private Label LabelHelp;
        private Repeater RepeaterData;
        private TextBox TextBoxSearch;
        private string skinFilename = "HelpDetail.ascx";
        private string string_1;

        public HelpDetail()
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
            LabelHelp = (Label) skin.FindControl("LabelHelp");
            if (!Page.IsPostBack)
            {
            }
            try
            {
                string str2 = Common.Common.GetNameById("Name", "ShopNum1_HelpType",
                    "  AND   Guid='" +
                    Common.Common.GetNameById("HelpTypeGuid", "ShopNum1_Help",
                        "  AND  Guid='" +
                        Page.Request.QueryString["guid"] + "'") +
                    "'");
                LabelHelp.Text = str2;
            }
            catch (Exception)
            {
                LabelHelp.Text = "帮助内容";
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action()).SearchRemark(
                    Page.Request.QueryString["guid"], 0);
            if (table.Rows.Count > 0)
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }
    }
}