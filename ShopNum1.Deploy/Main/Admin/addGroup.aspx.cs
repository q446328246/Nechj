using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class addGroup : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                ButtonConfirm.ToolTip = "Update";
                if (base.Request.QueryString["id"] != null)
                {
                    ButtonConfirm.ToolTip = "Update";
                    ButtonConfirm.Text = "更新";
                    string strGuid = base.Request.QueryString["id"];
                    DataTable group = GetGroup(strGuid);
                    if (group.Rows.Count > 0)
                    {
                        hiddenGuid.Value = group.Rows[0]["Guid"].ToString();
                        TextBoxName.Text = group.Rows[0]["Name"].ToString();
                        TextBoxShortName.Text = group.Rows[0]["ShortName"].ToString();
                        TextBoxRemarks.Value = group.Rows[0]["Remarks"].ToString();
                        TextBoxName.Enabled = false;
                    }
                }
                else
                {
                    ButtonConfirm.ToolTip = "Submit";
                }
            }
        }

        protected void BindGrid()
        {
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            ShopNum1_Group group;
            List<string> list;
            ShopNum1_Group_Action action2;
            List<ShopNum1_GroupPageWebControl> list2;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
                if (action.CheckShotName(TextBoxShortName.Text.Trim()) > 0)
                {
                    MessageBox.Show("用户组标志不能重复！");
                }
                else
                {
                    group = new ShopNum1_Group
                        {
                            Guid = Guid.NewGuid(),
                            Name = TextBoxName.Text.Trim(),
                            ShortName = TextBoxShortName.Text.Trim(),
                            CreateUser = "admin",
                            CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            ModifyUser = "admin",
                            ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            IsDeleted = 0,
                            Remarks = TextBoxRemarks.Value.Trim()
                        };
                    list = new List<string>();
                    action2 = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
                    list2 = new List<ShopNum1_GroupPageWebControl>();
                    if (action2.Add(group) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "添加用户组成功!",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "addGroup.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        OperateLog(log);
                        BindGrid();
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
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                action2 = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
                group = new ShopNum1_Group
                    {
                        Guid = new Guid(hiddenGuid.Value),
                        Name = TextBoxName.Text.Trim(),
                        ShortName = TextBoxShortName.Text.Trim(),
                        ModifyUser = "admin",
                        ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0,
                        Remarks = TextBoxRemarks.Value.Trim()
                    };
                var pageList = new List<string>();
                list = new List<string>();
                list2 = new List<ShopNum1_GroupPageWebControl>();
                if (action2.Update(group, pageList, list, list2) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "编辑用户组成功!",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "addGroup.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    OperateLog(log);
                    Page.ClientScript.RegisterStartupScript(this.GetType(),"script", "<script>window.parent.location.reload();</script>");
                    BindGrid();
                    ClearControl();
                }
                else
                {
                    MessageShow.ShowMessage("EditNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ClearControl()
        {
            TextBoxName.Text = string.Empty;
            TextBoxShortName.Text = string.Empty;
            TextBoxRemarks.Value = string.Empty;
        }

        protected DataTable GetGroup(string strGuid)
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetGroupByGuid(strGuid, 0);
        }

        //protected int OperateLog(ShopNum1_OperateLog operateLog)
        //{
        //    var action = (ShopNum1_OperateLog_Action) LogicFactory.CreateShopNum1_OperateLog_Action();
        //    return action.Add(operateLog);
        //}
    }
}