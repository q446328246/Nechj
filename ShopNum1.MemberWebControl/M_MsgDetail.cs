using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_MsgDetail : BaseMemberWebControl
    {
        private Literal LitContent;
        private Label lblDate;
        private Label lblReceiveUser;
        private Label lblSendUser;
        private Label lblTitle;
        private string skinFilename = "M_MsgDetail.ascx";

        public M_MsgDetail()
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
            var message = new ShopNum1_MemberMessage();
            var action = (ShopNum1_MemberMessage_Action) LogicFactory.CreateShopNum1_MemberMessage_Action();
            if (Page.Request.QueryString["guid"] != null)
            {
                message.IsRead = Convert.ToInt32(Common.Common.ReqStr("isread"));
                message.Guid = new Guid(Common.Common.ReqStr("Guid"));
                DataTable table = action.SelectMsg(message);
                if (table.Rows.Count > 0)
                {
                    lblTitle.Text = Operator.FilterString(table.Rows[0]["title"].ToString());
                    lblSendUser.Text = table.Rows[0]["sendloginID"].ToString();
                    lblReceiveUser.Text = table.Rows[0]["reLoginID"].ToString();
                    lblDate.Text = table.Rows[0]["SendTime"].ToString();
                    LitContent.Text = Operator.FilterString(table.Rows[0]["Content"].ToString());
                }
            }
            if ((Common.Common.ReqStr("isread") != "1") &&
                ((Page.Request.QueryString["isread"] != null) && (Page.Request.QueryString["isread"] != "2")))
            {
                action.Update_MsgIsRead(Common.Common.ReqStr("Guid"));
            }
        }
    }
}