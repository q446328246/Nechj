using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SupplyDemandDetails : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string guid = base.Request.QueryString["guid"];
            DataRow row = ((Shop_SupplyDemand_Action) ShopNum1.ShopFactory.LogicFactory.CreateShop_SupplyDemand_Action()).UpdateSearch(guid);
            TextBoxTitle.Text = row["Title"].ToString();
            TextBoxType.Text = row["CategoryName"].ToString();
            TextBoxAddressValue.Text = row["AddressValue"].ToString();
            if (row["TradeType"].ToString() == "0")
            {
                TextBoxTradeType.Text = "供";
            }
            else
            {
                TextBoxTradeType.Text = "求";
            }
            TextBoxKeywords.Text = row["Keywords"].ToString();
            TextBoxValidTime.Text = row["ValidTime"].ToString();
            if (row["IsAudit"].ToString() == "0")
            {
                TextBoxIsAudit.Text = "未审核";
            }
            else if (row["IsAudit"].ToString() == "1")
            {
                TextBoxIsAudit.Text = "审核中";
            }
            else if (row["IsAudit"].ToString() == "2")
            {
                TextBoxIsAudit.Text = "审核未通过";
            }
            else if (row["IsAudit"].ToString() == "3")
            {
                TextBoxIsAudit.Text = "审核通过";
            }
            TextBoxMemLoginID.Text = row["MemberID"].ToString();
            FCKeditorContent.Text = Page.Server.HtmlDecode(row["Content"].ToString());
            TextBoxDescription.Text = Page.Server.HtmlDecode(row["Description"].ToString());
            ImageOriginalImge.ImageUrl = row["Image"].ToString();
            TextBoxTel.Text = row["Tel"].ToString();
            TextBoxEmail.Text = row["Email"].ToString();
            TextBoxOtherContactWay.Text = row["OtherContactWay"].ToString();
            TextBoxContactName.Text = row["ContactName"].ToString();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if ((base.Request.QueryString["type"] != null) && (base.Request.QueryString["type"] == "audit"))
            {
                Page.Response.Redirect("ShopNum1_SupplyDemandCheck_List.aspx");
            }
            else
            {
                Page.Response.Redirect("ShopNum1_SupplyDemand_List.aspx");
            }
        }
    }
}