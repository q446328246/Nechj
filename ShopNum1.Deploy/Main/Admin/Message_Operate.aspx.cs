using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Message_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_MessageInfo messageInfo = new ShopNum1_MessageInfo
            {
                Guid = Guid.NewGuid(),
                Title = this.TextBoxTitle.Text.Trim(),
                Type = "1",
                Content = this.TextBoxContent.Text.Trim(),
                MemLoginID = base.ShopNum1LoginID,
                SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            List<string> usermessage = new List<string>();
            ListBox box = (ListBox)this.MemberSelect2.FindControl("ListBoxRightMember");
            foreach (ListItem item in box.Items)
            {
                try
                {
                    usermessage.Add(item.Text.Split(new char[] { '-' })[0]);
                }
                catch
                {
                    usermessage.Add(item.Text);
                }
            }
            ShopNum1_MessageInfo_Action action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
            if (action.Add(messageInfo, usermessage) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "发送消息成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Message_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.ClearControl();
                this.MessageShow.ShowMessage("OperateYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ClearControl()
        {
            this.TextBoxContent.Text = string.Empty;
            this.TextBoxTitle.Text = string.Empty;
            ListBox box = (ListBox)this.MemberSelect2.FindControl("ListBoxRightMember");
            box.Items.Clear();
            ListBox box2 = (ListBox)this.MemberSelect2.FindControl("ListBoxLeftMember");
            box2.Items.Clear();
            DropDownList list = (DropDownList)this.MemberSelect2.FindControl("DropDownListSMemberRank");
            list.SelectedValue = "-1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (this.Page.IsPostBack)
            {
            }
        }
    }
}