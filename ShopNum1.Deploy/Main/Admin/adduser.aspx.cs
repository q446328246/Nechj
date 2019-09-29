using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Encryption;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class adduser : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
           
            if (!Page.IsPostBack)
            {
                BindData();
               
                if (base.Request.QueryString["id"] != null)
                {
                    ButtonConfirm.Text = "更新";
                    TextBoxLoginID.Enabled = false;
                    string comId = base.Request.QueryString["id"];
                    DataTable user = GetUser(comId);
                    hiddenGuid.Value = user.Rows[0]["Guid"].ToString();
                    TextBoxLoginID.Text = user.Rows[0]["LoginID"].ToString();
                    TextBoxRealName.Text = user.Rows[0]["RealName"].ToString();
                    DropDownListSex.SelectedValue = user.Rows[0]["Sex"].ToString();
                    if (user.Rows[0]["DeptGuid"].ToString() == "00000000-0000-0000-0000-000000000000")
                    {
                        DropDownListDept.SelectedValue = "-1";
                    }
                    else
                    {
                        DropDownListDept.SelectedValue = user.Rows[0]["DeptGuid"].ToString();
                    }
                    TextBoxAge.Text = user.Rows[0]["Age"].ToString();
                    TextBoxWorkNumber.Text = user.Rows[0]["WorkNumber"].ToString();
                    TextBoxEmail.Text = user.Rows[0]["Email"].ToString();
                    TextBoxTelephone.Text = user.Rows[0]["Telephone"].ToString();
                    DropDownListIsForbid.SelectedValue = user.Rows[0]["IsForbid"].ToString();
                    if ((user.Rows.Count >= 1) && (user.Rows[0]["GroupGuid"].ToString() != ""))
                    {
                        for (int i = 0; i < DropDownListGroup.Items.Count; i++)
                        {
                            for (int j = 0; j < user.Rows.Count; j++)
                            {
                                if (DropDownListGroup.Items[i].Value == user.Rows[j]["GroupGuid"].ToString())
                                {
                                    DropDownListGroup.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                    ButtonConfirm.ToolTip = "Update";
                }
                else
                {
                    ButtonConfirm.ToolTip = "Submit";
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_User_Action action;
            ShopNum1_User user;
            List<string> list;
            ShopNum1_GroupUser user2;
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
                DataTable userByLoginID = action.GetUserByLoginID(TextBoxLoginID.Text.Trim(), 0);
                if ((userByLoginID != null) && (userByLoginID.Rows.Count > 0))
                {
                    MessageBox.Show("用户名已存在，请更换！");
                }
                else
                {
                    user = new ShopNum1_User
                        {
                            Guid = Guid.NewGuid()
                        };
                    TextBoxLoginID.Enabled = true;
                    user.LoginId = TextBoxLoginID.Text.Trim();
                    user.Pwd = Common.Encryption.GetSHA1SecondHash(TextBoxPassword1.Text.Trim());//DESEncrypt.Decrypt(TextBoxPassword1.Text.Trim());
                    user.RealName = TextBoxRealName.Text.Trim();
                    user.Sex = Convert.ToInt32(DropDownListSex.SelectedValue);
                    if ((TextBoxAge.Text.Trim() == string.Empty) || (TextBoxAge.Text.Trim() == null))
                    {
                        user.Age = 0;
                    }
                    else
                    {
                        user.Age = Convert.ToInt32(TextBoxAge.Text.Trim());
                    }
                    user.WorkNumber = TextBoxWorkNumber.Text.Trim();
                    user.Email = TextBoxEmail.Text.Trim();
                    user.Telephone = TextBoxTelephone.Text.Trim();
                    user.IsForbid = Convert.ToInt32(DropDownListIsForbid.SelectedValue);
                    user.LoginTimes = 0;
                    user.LastLoginTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    user.LastLoginIP = string.Empty;
                    user.LastModifyPasswordTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    user.CreateUser = base.ShopNum1LoginID;
                    user.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    user.ModifyUser = base.ShopNum1LoginID;
                    user.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    user.IsDeleted = 0;
                    list = new List<string>();
                    user2 = new ShopNum1_GroupUser();
                    if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 1)
                    {
                        user.PeopleType = 1;
                        user2.GroupGuid = new Guid(DropDownListGroup.SelectedValue);
                    }
                    else
                    {
                        user.PeopleType = 0;
                    }
                    list.Add(user2.GroupGuid.ToString());
                    if (action.Add(user, list) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "添加后台管理员",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "adduser.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
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
                user = new ShopNum1_User
                    {
                        Guid = new Guid(hiddenGuid.Value),
                        LoginId = TextBoxLoginID.Text.Trim()
                    };
                if (TextBoxPassword1.Text.Trim() != "")
                {
                    user.Pwd = Common.Encryption.GetSHA1SecondHash(TextBoxPassword1.Text.Trim());//DESEncrypt.Decrypt(TextBoxPassword1.Text.Trim());
                    user.LastModifyPasswordTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                user.RealName = TextBoxRealName.Text.Trim();
                user.Sex = Convert.ToInt32(DropDownListSex.SelectedValue);
                if ((TextBoxAge.Text.Trim() == string.Empty) || (TextBoxAge.Text.Trim() == null))
                {
                    user.Age = 0;
                }
                else
                {
                    user.Age = Convert.ToInt32(TextBoxAge.Text.Trim());
                }
                user.WorkNumber = TextBoxWorkNumber.Text.Trim();
                user.Email = TextBoxEmail.Text.Trim();
                user.Telephone = TextBoxTelephone.Text.Trim();
                user.IsForbid = Convert.ToInt32(DropDownListIsForbid.SelectedValue);
                user.LoginTimes = 0;
                user.LastLoginTime = null;
                user.LastLoginIP = string.Empty;
                user.ModifyUser = base.ShopNum1LoginID;
                user.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                user.IsDeleted = 0;
                list = new List<string>();
                user2 = new ShopNum1_GroupUser();
                if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 1)
                {
                    user.PeopleType = 1;
                    user2.GroupGuid = new Guid(DropDownListGroup.SelectedValue);
                    list.Add(user2.GroupGuid.ToString());
                }
                else
                {
                    user.PeopleType = 0;
                }
                action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
                if (action.Update(user, list) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "修改后台管理员",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "adduser.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    Page.ClientScript.RegisterStartupScript(this.GetType(),"script", "<script>window.parent.location.reload();</script>");
                    ClearControl();
                    ButtonConfirm.ToolTip = "Submit";
                    ButtonConfirm.Text = "确定";
                    TextBoxLoginID.Enabled = true;
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
            TextBoxLoginID.Text = string.Empty;
            TextBoxPassword1.Text = string.Empty;
            TextBoxPassword2.Text = string.Empty;
            TextBoxRealName.Text = string.Empty;
            TextBoxTelephone.Text = string.Empty;
            TextBoxWorkNumber.Text = string.Empty;
            TextBoxEmail.Text = string.Empty;
            TextBoxAge.Text = "0";
            DropDownListSex.SelectedValue = "1";
            DropDownListDept.SelectedValue = "-1";
            DropDownListIsForbid.SelectedValue = "0";
            DropDownListGroup.SelectedIndex = -1;
        }

        protected DataTable GetUser(string comId)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            return action.GetUserByGuid(comId, 0);
        }

        private void BindData()
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["GUID"].ToString().Trim()
                    };
                DropDownListGroup.Items.Add(item);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 1)
            {
                pane1.Visible = true;
            }
            else
            {
                pane1.Visible = false;
            }
        }
    }
}