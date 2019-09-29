using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_SysMsgDetail : BaseMemberControl
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
            var info = new ShopNum1_MessageInfo();
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            if (Page.Request.QueryString["guid"] != null)
            {
                info.Guid = new Guid(Common.Common.ReqStr("Guid"));
                DataTable table = action.Search(Common.Common.ReqStr("Guid"));
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
