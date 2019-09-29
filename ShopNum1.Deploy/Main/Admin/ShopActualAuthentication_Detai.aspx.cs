using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopActualAuthentication_Detai : PageBase, IRequiresSessionState
    {
        public string guid { get; set; }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopActualAuthentication_Audit.aspx");
        }

        protected void ButtonConfiirm_Click(object sender, EventArgs e)
        {
            if (DropDownListAuditStatus.SelectedItem.Selected)
            {
                var action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                if (
                    action.UpdateCompanAudit(guid.Replace("'", ""), DropDownListAuditStatus.SelectedItem.Value,
                                             TextBoxAuditFailedReason.Text.Trim().Replace("'", "")) > 0)
                {
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void DropDownListAuditStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListAuditStatus.SelectedItem.Value == "1")
            {
                divShowHide.Visible = false;
            }
            else
            {
                divShowHide.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            guid = Page.Request.QueryString["Guid"];
            guid.Replace("'", "");
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllShopInfoByGuid(
                    guid);
            if ((allShopInfoByGuid != null) && (allShopInfoByGuid.Rows.Count > 0))
            {
                TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();
                TextBoxShopID.Text = "shop" + allShopInfoByGuid.Rows[0]["ShopID"];
                TextBoxRegistrationNum.Text = allShopInfoByGuid.Rows[0]["RegistrationNum"].ToString();
                TextBoxLegalPerson.Text = allShopInfoByGuid.Rows[0]["LegalPerson"].ToString();
                ImageIdentityCard.ImageUrl = "~/ImgUpload/ShopCertification/" +
                                             allShopInfoByGuid.Rows[0]["BusinessLicense"];
            }
        }
    }
}