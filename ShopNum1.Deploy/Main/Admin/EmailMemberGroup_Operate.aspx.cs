using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class EmailMemberGroup_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            var memberGroup = new ShopNum1_MemberGroup
                {
                    Guid = Guid.NewGuid(),
                    Name = TextBoxName.Text.Trim(),
                    Description = TextBoxDescription.Text.Trim(),
                    CreateUser = base.ShopNum1LoginID,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = base.ShopNum1LoginID,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
            var emailmemberAssignGroup = new List<string>();
            var box = (ListBox) MemberSelect1.FindControl("ListBoxRightMember");
            foreach (ListItem item in box.Items)
            {
                string[] strArray = item.Text.Split(new[] {'-'});
                emailmemberAssignGroup.Add(strArray[0]);
            }
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Email_Group_Add(memberGroup, emailmemberAssignGroup) > 0)
            {
                ClearControl();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "更新会员管理组成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "EmailMemberGroup_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加会员管理组成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "EmailMemberGroup_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxDescription.Text = string.Empty;
            TextBoxName.Text = string.Empty;
        }

        protected void Edit()
        {
            var memberGroup = new ShopNum1_MemberGroup
                {
                    Guid = new Guid(hiddenFieldGuid.Value.Replace("'", "")),
                    Name = TextBoxName.Text.Trim(),
                    Description = TextBoxDescription.Text.Trim(),
                    ModifyUser = base.ShopNum1LoginID,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
            var memberAssignGroup = new List<string>();
            var box = (ListBox) MemberSelect1.FindControl("ListBoxRightMember");
            foreach (ListItem item in box.Items)
            {
                string[] strArray = item.Text.Split(new[] {'-'});
                memberAssignGroup.Add(strArray[0]);
            }
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.UpdateEmailMemberAssignGroup(memberGroup, memberAssignGroup) > 0)
            {
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
                base.Response.Redirect("EmailMemberGroup_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            DataTable table = action.SearchMemberGroup(hiddenFieldGuid.Value);
            if (table.Rows.Count > 0)
            {
                TextBoxName.Text = table.Rows[0]["Name"].ToString();
                TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
            }
            DataTable table2 = action.SearchEmailMemberAssignGroup(hiddenFieldGuid.Value.Replace("'", ""));
            var box = (ListBox) MemberSelect1.FindControl("ListBoxRightMember");
            if (table2.Rows.Count > 0)
            {
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    var item = new ListItem
                        {
                            Text = table2.Rows[i]["MemLoginID"] + "-" + table2.Rows[i]["Name"]
                        };
                    DataTable table3 = action.SearchByMemLoginID(table2.Rows[i]["MemLoginID"].ToString());
                    item.Value = table3.Rows[0]["Guid"].ToString();
                    box.Items.Add(item);
                }
            }
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                try
                {
                    if (hiddenFieldGuid.Value != "0")
                    {
                        GetEditInfo();
                        ButtonConfirm.Text = "更新";
                    }
                }
                catch (Exception exception)
                {
                    base.Response.Write(exception.Message);
                }
            }
        }
    }
}