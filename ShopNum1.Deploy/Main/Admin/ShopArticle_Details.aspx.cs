using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopArticle_Details : PageBase, IRequiresSessionState
    {
        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            if ((Page.Request.QueryString["type"] != null) && (Page.Request.QueryString["type"] == "check"))
            {
                Page.Response.Redirect("ShopArticle_Check.aspx");
            }
            else
            {
                Page.Response.Redirect("ShopArticle_List.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string guid = base.Request.QueryString["guid"];
            DataTable table =
                ((ShopNum1_ArticleCheck_Action) LogicFactory.CreateShopNum1_ArticleCheck_Action()).SearchDetailsByGuid(
                    guid);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxCreateTime.Text = table.Rows[0]["CreateTime"].ToString();
                TextBoxTitle.Text = table.Rows[0]["Title"].ToString();
                FCKeditorConten.Text = Page.Server.HtmlDecode(table.Rows[0]["Content"].ToString());
                TextBoxKeywords.Text = table.Rows[0]["Keywords"].ToString();
                TextBoxCategoryGuid.Text = table.Rows[0]["name"].ToString();
                TextBoxMemberLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
            }
        }
    }
}