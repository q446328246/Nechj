using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MsgDetail : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
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