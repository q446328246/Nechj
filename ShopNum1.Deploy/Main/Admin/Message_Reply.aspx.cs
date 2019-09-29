using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Message_Reply : PageBase, IRequiresSessionState
    {
        private string string_4 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            string_4 = (base.Request.QueryString["type"] == null) ? "0" : base.Request.QueryString["type"];
            if (hiddenGuid.Value != "0")
            {
                TextBoxContent.Text = string.Empty;
                if (!Page.IsPostBack)
                {
                    GetEditInfo();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string_4 == "1")
            {
                base.Response.Redirect("ReceiveMessage_List.aspx");
            }
            if (string_4 == "2")
            {
                base.Response.Redirect("SendMessage_List.aspx");
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var memberMessage = new ShopNum1_MemberMessage
                {
                    Guid = new Guid(hiddenGuid.Value.Replace("'", "")),
                    ReTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ReContent = TextBoxReplyContent.Text.Trim()
                };
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            if (action.Update(memberMessage) > 0)
            {
                TextBoxContent.Text = string.Empty;
                base.Response.Redirect("ReceiveMessage_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable table = new ShopNum1_MessageInfo_Action().Search(hiddenGuid.Value);
            LabelMemLoginIDValue.Text = table.Rows[0]["SendID"].ToString();
            LabelMeaageTypeValue.Text = (table.Rows[0]["Type"].ToString() == "0") ? "会员消息" : "系统消息";
            LabelTitleValue.Text = table.Rows[0]["Title"].ToString();
            LabelSendTimeValue.Text = table.Rows[0]["SendTime"].ToString();
            LabelReplyUserValue.Text = table.Rows[0]["ReceiveID"].ToString();
            LabelReplyTimeValue.Text = table.Rows[0]["ReplyTime"].ToString();
            if (Operator.FormatToEmpty(table.Rows[0]["ReplyTime"].ToString()) == string.Empty)
            {
                LabelIsReplyValue.Text = " 未回复"; //LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "0");
            }
            else
            {
                LabelIsReplyValue.Text = " 已回复"; //LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "1");
            }
            TextBoxContent.Text = table.Rows[0]["Content"].ToString();
            TextBoxReplyContent.Text = table.Rows[0]["ReplyContent"].ToString();
            if ((table.Rows[0]["ReplyTime"].ToString() == null) || (table.Rows[0]["ReplyTime"].ToString() == ""))
            {
                TextBoxReplyContent.ReadOnly = false;
                ButtonConfirm.Enabled = true;
            }
            else
            {
                ButtonConfirm.Enabled = false;
                TextBoxReplyContent.ReadOnly = true;
            }
            if (string_4 == "2")
            {
                TextBoxReplyContent.ReadOnly = true;
                ButtonConfirm.Enabled = false;
            }
        }


    }
}