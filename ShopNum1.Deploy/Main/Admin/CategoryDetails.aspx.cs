using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryDetails : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string guid = base.Request.QueryString["guid"];
            DataRow row = ((Shop_CategoryInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CategoryInfo_Action()).UpdateSearch(guid);
            TextBoxCategoryInfo.Text = row["name"].ToString();
            if (row["Type"].ToString() == "0")
            {
                TextBoxType.Text = "ÆäËü";
            }
            TextBoxMemLoginID.Text = row["AssociatedMemberID"].ToString();
            if (row["ValidTime"].ToString().IndexOf("/") != -1)
            {
                TextBoxValidTime.Text = row["ValidTime"].ToString().Split(new[] {'/'})[0];
            }
            else
            {
                TextBoxValidTime.Text = row["ValidTime"].ToString();
            }
            TextBoxTitle.Text = row["Title"].ToString();
            FCKeditorContent.Text = Page.Server.HtmlDecode(row["Content"].ToString());
            FCKeditorKeywords.Text = Page.Server.HtmlDecode(row["Content"].ToString());
            TextBoxTel.Text = row["Tel"].ToString();
            TextBoxEmail.Text = row["Email"].ToString();
            TextBoxOtherContactWay.Text = row["OtherContactWay"].ToString();
        }
    }
}