using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_SysMsgDetail : BaseMemberWebControl
    {
        private Literal LitContent;
        private Label lblDate;
        private Label lblReceiveUser;
        private Label lblSendUser;
        private Label lblTitle;
        private string skinFilename = "M_SysMsgDetail.ascx";

        public M_SysMsgDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            lblTitle = (Label) skin.FindControl("lblTitle");
            lblSendUser = (Label) skin.FindControl("lblSendUser");
            lblReceiveUser = (Label) skin.FindControl("lblReceiveUser");
            lblDate = (Label) skin.FindControl("lblDate");
            LitContent = (Literal) skin.FindControl("LitContent");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var info = new ShopNum1_MessageInfo();
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            if (Page.Request.QueryString["guid"] != null)
            {
                info.Guid = new Guid(Common.Common.ReqStr("Guid"));
                DataTable table = action.Search("'" + Common.Common.ReqStr("Guid") + "'");
                if (table.Rows.Count > 0)
                {
                    lblTitle.Text = table.Rows[0]["Title"].ToString();
                    lblSendUser.Text = table.Rows[0]["SendID"].ToString();
                    lblReceiveUser.Text = table.Rows[0]["ReceiveID"].ToString();
                    lblDate.Text = table.Rows[0]["SendTime"].ToString();
                    LitContent.Text = table.Rows[0]["Content"].ToString();
                }
            }
            if (Common.Common.ReqStr("isread") != "1")
            {
                action.Update_SysUserMsgIsRead(Common.Common.ReqStr("Guid"));
            }
        }
    }
}