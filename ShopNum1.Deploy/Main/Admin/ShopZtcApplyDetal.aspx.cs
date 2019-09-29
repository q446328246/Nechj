using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopZtcApplyDetal : PageBase, IRequiresSessionState
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopZtcApplyAudit_List.aspx");
        }

        public void GetData()
        {
            DataTable infoByGuid =
                ((ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action()).GetInfoByGuid(
                    Page.Request.QueryString["ID"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                RepeaterShow.DataSource = infoByGuid.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        public string IsAuditState(string AuditState)
        {
            if (AuditState == "0")
            {
                return "Œ¥…Û∫À";
            }
            if (AuditState == "1")
            {
                return "“—…Û∫À";
            }
            if (AuditState == "2")
            {
                return "…Û∫ÀŒ¥Õ®π˝";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            GetData();
        }
    }
}