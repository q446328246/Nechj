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
    public partial class MMSMemberGroup_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                GetEditInfo();
            }
        }

        protected void Add()
        {
            var memberGroup = new ShopNum1_MMSMemberGroup
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
            var memberAssignGroup = new List<string>();
            var box = (ListBox) MemberSelect1.FindControl("ListBoxRightMember");
            foreach (ListItem item in box.Items)
            {
                string[] strArray = item.Text.Split(new[] {'-'});
                memberAssignGroup.Add(strArray[0]);
            }
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            if (action.Add(memberGroup, memberAssignGroup) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MMSMemberGroup_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else
            {
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
            var memberGroup = new ShopNum1_MMSMemberGroup
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
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            if (action.UpdateMemberAssignGroup(memberGroup, memberAssignGroup) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + TextBoxName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MMSMemberGroup_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
                base.Response.Redirect("MMSMemberGroup_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            DataTable table = action.SearchMemberGroup(hiddenFieldGuid.Value);
            TextBoxName.Text = table.Rows[0]["Name"].ToString();
            TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
            DataTable table2 = action.SearchMemberAssignGroup(hiddenFieldGuid.Value.Replace("'", ""));
            var box = (ListBox) MemberSelect1.FindControl("ListBoxRightMember");
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
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }


    }
}