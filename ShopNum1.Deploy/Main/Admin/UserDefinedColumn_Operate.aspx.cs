using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UserDefinedColumn_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!this.Page.IsPostBack)
            {
                this.DropDownListBind(this.DropDownListIfOpen);
                this.DropDownListBind(this.DropDownListIfShow);
                this.DropDownListBind(this.DropDownListIsShop);
                this.DropDownListBind(this.DropDownListIsMember);
                this.DropDownListBind(this.DropDownListIsSite);
                this.ShowLocationBind();
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.LabelPageTitle.Text = "编辑栏目";
                    this.GetEditInfo();
                }
                else
                {
                    this.GetOrderID();
                }
            }
        }

        protected void Add()
        {
            ShopNum1_UserDefinedColumn column = new ShopNum1_UserDefinedColumn
            {
                Guid = Guid.NewGuid(),
                Name = this.TextBoxName.Text.Trim(),
                LinkAddress = this.TextBoxLinkAddress.Text.Trim(),
                ShowLocation = this.DropDownListShowLocation.SelectedValue.ToString(),
                IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue.ToString()),
                IfOpen = Convert.ToInt32(this.DropDownListIfOpen.SelectedValue.ToString()),
                Remark = this.TextBoxRemark.Text.Trim(),
                OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim()),
                CreateUser = "admin",
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                ModifyUser = "admin",
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsShop = Convert.ToInt32(this.DropDownListIsShop.SelectedValue.ToString()),
                IsMember = Convert.ToInt32(this.DropDownListIsMember.SelectedValue.ToString()),
                IsSite = Convert.ToInt32(this.DropDownListIsSite.SelectedValue.ToString()),
                IsDeleted = 0
            };
            ShopNum1_UserDefinedColumn_Action action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
            if (action.Insert(column) > 0)
            {
                this.ClearControl();
                this.GetOrderID();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (this.ButtonConfirm.ToolTip == "Update")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "编辑栏目信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "UserDefinedColumn_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.Edit();
            }
            else if (this.ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "添加栏目信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "UserDefinedColumn_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.Add();
            }
        }

        protected void ClearControl()
        {
            this.TextBoxLinkAddress.Text = string.Empty;
            this.TextBoxRemark.Text = string.Empty;
            this.TextBoxName.Text = string.Empty;
            this.DropDownListIfShow.SelectedValue = "1";
            this.DropDownListIfOpen.SelectedValue = "1";
        }

        protected void DropDownListBind(DropDownList dropDownList)
        {
            dropDownList.Items.Add(new ListItem("是", "1"));
            dropDownList.Items.Add(new ListItem("否", "0"));
        }

        protected void Edit()
        {
            ShopNum1_UserDefinedColumn column = new ShopNum1_UserDefinedColumn
            {
                Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", "")),
                Name = this.TextBoxName.Text.Trim(),
                LinkAddress = this.TextBoxLinkAddress.Text.Trim(),
                ShowLocation = this.DropDownListShowLocation.SelectedValue.ToString(),
                IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue.ToString()),
                IfOpen = Convert.ToInt32(this.DropDownListIfOpen.SelectedValue.ToString()),
                Remark = this.TextBoxRemark.Text.Trim(),
                OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim()),
                IsShop = Convert.ToInt32(this.DropDownListIsShop.SelectedValue.ToString()),
                IsMember = Convert.ToInt32(this.DropDownListIsMember.SelectedValue.ToString()),
                IsSite = Convert.ToInt32(this.DropDownListIsSite.SelectedValue.ToString()),
                ModifyUser = "admin",
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            ShopNum1_UserDefinedColumn_Action action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
            if (action.Update(column) > 0)
            {
                base.Response.Redirect("UserDefinedColumn_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo = ((ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action()).GetEditInfo(this.hiddenFieldGuid.Value.ToString());
            this.TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
            this.TextBoxLinkAddress.Text = editInfo.Rows[0]["LinkAddress"].ToString();
            this.DropDownListShowLocation.SelectedValue = editInfo.Rows[0]["ShowLocation"].ToString();
            this.DropDownListIfShow.SelectedValue = editInfo.Rows[0]["IfShow"].ToString();
            this.DropDownListIfOpen.SelectedValue = editInfo.Rows[0]["IfOpen"].ToString();
            this.DropDownListIsShop.SelectedValue = editInfo.Rows[0]["IsShop"].ToString();
            this.DropDownListIsMember.SelectedValue = editInfo.Rows[0]["IsMember"].ToString();
            this.DropDownListIsSite.SelectedValue = editInfo.Rows[0]["IsSite"].ToString();
            this.TextBoxRemark.Text = editInfo.Rows[0]["Remark"].ToString();
            this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            this.ButtonConfirm.Text = "更新";
            this.ButtonConfirm.ToolTip = "Update";
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_UserDefinedColumn";
            this.TextBoxOrderID.Text = Convert.ToString((int)(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }



        protected void ShowLocationBind()
        {
            this.DropDownListShowLocation.Items.Add(new ListItem("中部导航", "0"));
            this.DropDownListShowLocation.Items.Add(new ListItem("底部导航", "1"));
            this.DropDownListShowLocation.Items.Add(new ListItem("右上角导航", "2"));
        }
    }
}