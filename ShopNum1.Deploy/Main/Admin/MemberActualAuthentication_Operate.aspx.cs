using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberActualAuthentication_Operate : PageBase, IRequiresSessionState
    {
        public string strstate = string.Empty;
        public string guid { get; set; }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberActualAuthentication_List.aspx");
        }

        protected void ButtonConfiirm_Click(object sender, EventArgs e)
        {
            if (DropDownListAuditStatus.SelectedItem.Selected)
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                if (
                    action.UpdateIdentificationIsAudit(guid, DropDownListAuditStatus.SelectedItem.Value,
                                                       TextBoxAuditFailedReason.Value) > 0)
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
            BindData();
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "审核已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void BindData()
        {
            DataTable table =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchMemberInfoByGuid(guid);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxAuditFailedReason.Value = table.Rows[0]["auditfailedreason"].ToString();
                TextBoxName.Text = table.Rows[0]["MemLoginID"].ToString();
                TextBoxRealName.Text = table.Rows[0]["RealName"].ToString();
                TextBoxCardNum.Text = table.Rows[0]["IdentityCard"].ToString();
                TextBoxTime.Text = table.Rows[0]["IdentificationTime"].ToString();
                DropDownListAuditStatus.Items[DropDownListAuditStatus.SelectedIndex].Text =
                    Is(table.Rows[0]["IdentificationIsAudit"].ToString());
                if (table.Rows[0]["IdentificationIsAudit"].ToString() != "0")
                {
                    DropDownListAuditStatus.Enabled = false;
                    ButtonConfiirm.Visible = false;
                    LabelPageTitle.Text = "查看会员实名认证";
                }
                if (!(table.Rows[0]["IdentificationIsAudit"].ToString() == "0"))
                {
                    strstate = Is(table.Rows[0]["IdentificationIsAudit"].ToString());
                }
                ImageIdentityCard.ImageUrl = "~/ImgUpload/ShopCertification/" + table.Rows[0]["IdentityCardImg"];
                ImageIdentityCardBack.ImageUrl = "~/ImgUpload/ShopCertification/" + table.Rows[0]["IdentityCardBackImg"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            guid = Page.Request.QueryString["Guid"].Replace("'", "");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}