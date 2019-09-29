using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberActualAuthentication_Detai : PageBase, IRequiresSessionState
    {
        public string guid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            guid = Page.Request.QueryString["Guid"].Replace("'", "");
            DataTable table =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMemberInfoByGuid(guid);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxName.Text = table.Rows[0]["MemLoginID"].ToString();
                TextBoxRealName.Text = table.Rows[0]["RealName"].ToString();
                TextBoxCardNum.Text = table.Rows[0]["IdentityCard"].ToString();
                TextBoxTime.Text = table.Rows[0]["IdentificationTime"].ToString();
                ImageIdentityCard.ImageUrl = "~/ImgUpload/ShopCertification/" + table.Rows[0]["IdentityCardImg"];
                ImageIdentityCardBack.ImageUrl = "~/ImgUpload/ShopCertification/" + table.Rows[0]["IdentityCardBackImg"];
            }
        }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberActualAuthentication_Audit.aspx");
        }

        protected void ButtonConfiirm_Click(object sender, EventArgs e)
        {
            if (DropDownListAuditStatus.SelectedItem.Selected)
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                if (
                    action.UpdateIdentificationIsAudit(guid, DropDownListAuditStatus.SelectedItem.Value,
                                                       TextBoxAuditFailedReason.Text,
                                                       TextBoxName.Text.Trim().Replace("'", "")) > 0)
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


    }
}