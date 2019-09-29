using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SendMessage_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridiewShow.DataBind();
        }

        protected void BindStatus()
        {
            var item = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListSIsRead.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = " 未读",//LocalizationUtil.GetCommonMessage("NoRead"),
                    Value = "0"
                };
            DropDownListSIsRead.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = " 已读",//LocalizationUtil.GetCommonMessage("IsRead"),
                    Value = "1"
                };
            DropDownListSIsRead.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListSType.Items.Add(item4);
            var item5 = new ListItem
                {
                    Text = "系统消息",
                    Value = "1"
                };
            DropDownListSType.Items.Add(item5);
            var item6 = new ListItem
                {
                    Text = "会员消息",
                    Value = "0"
                };
            DropDownListSType.Items.Add(item6);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("Message_Operate.aspx?guid=" + CheckGuid.Value + "&type=2");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            if (action.DeleteSend(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除发件箱消息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SendMessage_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.DeleteSend(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除发件箱消息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SendMessage_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Message_Reply.aspx?guid=" + CheckGuid.Value + "&type=2");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindStatus();
                BindGrid();
                textBoxSMemLoginID.Text = base.ShopNum1LoginID;
            }
        }
    }
}