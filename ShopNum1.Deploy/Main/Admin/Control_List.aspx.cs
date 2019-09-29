using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Control_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void BindPage()
        {
            DataTable table = ((ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action()).Search(
                hiddenGuid.Value, 0);
            LabelPageNameShow.Text = table.Rows[0]["Name"].ToString();
            if (table.Rows[0]["PageType"].ToString() == "0")
            {
                LabelPageTypeShow.Text = " 左边菜单页面";// LocalizationUtil.GetChangeMessage("Page_List", "PageType", "0");
            }
            else if (table.Rows[0]["PageType"].ToString() == "1")
            {
                LabelPageTypeShow.Text = " 普通操作页面";//LocalizationUtil.GetChangeMessage("Page_List", "PageType", "1");
            }
            else if (table.Rows[0]["PageType"].ToString() == "3")
            {
                LabelPageTypeShow.Text = " 顶部页面";//LocalizationUtil.GetChangeMessage("Page_List", "PageType", "3");
            }
            LabelPagePathShow.Text = table.Rows[0]["PagePath"].ToString();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_PageWebControl_Action action;
            ShopNum1_PageWebControl control;
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                try
                {
                    action = (ShopNum1_PageWebControl_Action) LogicFactory.CreateShopNum1_PageWebControl_Action();
                    control = new ShopNum1_PageWebControl();
                    string g = hiddenGuid.Value.Replace("'", "");
                    control.Guid = Guid.NewGuid();
                    control.Name = TextBoxControlName.Text.Trim();
                    control.PageGuid = new Guid(g);
                    control.ControlID = TextBoxControlID.Text.Trim();
                    control.ControlType = DropDownListControlType.SelectedValue;
                    control.Description = TextBoxDescription.Text.Trim();
                    control.CreateUser = base.ShopNum1LoginID;
                    control.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    control.ModifyUser = base.ShopNum1LoginID;
                    control.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    control.IsDeleted = 0;
                    if (action.Add(control) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "新增" + TextBoxControlID.Text.Trim() + "成功",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "Control_List.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        MessageShow.ShowMessage("AddYes");
                        MessageShow.Visible = true;
                        BindGrid();
                        ClearControl();
                    }
                    else
                    {
                        MessageShow.ShowMessage("AddNo");
                        MessageShow.Visible = true;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                action = (ShopNum1_PageWebControl_Action) LogicFactory.CreateShopNum1_PageWebControl_Action();
                control = new ShopNum1_PageWebControl
                    {
                        Guid = new Guid(hiddenControlGuid.Value),
                        Name = TextBoxControlName.Text.Trim(),
                        ControlID = TextBoxControlID.Text.Trim(),
                        ControlType = DropDownListControlType.SelectedValue,
                        Description = TextBoxDescription.Text.Trim(),
                        ModifyUser = base.ShopNum1LoginID,
                        ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                if (action.Update(control) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "编辑" + TextBoxControlID.Text.Trim() + "成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Control_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("EditYes");
                    MessageShow.Visible = true;
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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_PageWebControl_Action) LogicFactory.CreateShopNum1_PageWebControl_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Control_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                BindGrid();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            ClearControl();
            LabelPageTitle.Text = "编辑控件";
            ButtonConfirm.ToolTip = "Update";
            ButtonConfirm.Text = "更新";
            DataTable control = GetControl();
            hiddenControlGuid.Value = control.Rows[0]["Guid"].ToString();
            TextBoxControlID.Text = control.Rows[0]["ControlID"].ToString();
            TextBoxControlName.Text = control.Rows[0]["Name"].ToString();
            TextBoxDescription.Text = control.Rows[0]["Description"].ToString();
            DropDownListControlType.SelectedValue = control.Rows[0]["ControlType"].ToString();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
        }

        protected void ClearControl()
        {
            TextBoxDescription.Text = string.Empty;
            TextBoxControlName.Text = string.Empty;
            TextBoxControlID.Text = string.Empty;
        }

        protected void DropDownListControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownListPageType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownListSOne_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownListSPageType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownListSTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected DataTable GetControl()
        {
            string guid = CheckGuid.Value.Replace("'", "");
            var action = (ShopNum1_PageWebControl_Action) LogicFactory.CreateShopNum1_PageWebControl_Action();
            return action.Search(string.Empty, guid, 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = base.Request.QueryString["Guid"];
                BindPage();
                BindGrid();
            }
        }
    }
}