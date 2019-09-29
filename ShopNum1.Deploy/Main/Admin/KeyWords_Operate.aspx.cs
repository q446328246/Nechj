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
    public partial class KeyWords_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            ShopNum1_KeyWords words = new ShopNum1_KeyWords
            {
                Guid = Guid.NewGuid(),
                Name = this.TextBoxKeyWords.Text.Trim(),
                Type = Convert.ToInt32(this.DropDownListType.SelectedValue),
                IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue),
                CreateUser = "admin",
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                ModifyUser = "admin",
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            ShopNum1_KeyWords_Action action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
            if (action.Add(words) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "新增" + this.TextBoxKeyWords.Text.Trim() + "成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "AgentKeyWords_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.ClearControl();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void BindStatus()
        {
            ListItem item = new ListItem
            {
                Text = "-请选择-",
                Value = "-1"
            };
            ListItem item2 = new ListItem
            {
                Text = "商品",
                Value = "0"
            };
            ListItem item3 = new ListItem
            {
                Text = "资讯",
                Value = "1"
            };
            ListItem item4 = new ListItem
            {
                Text = "显示",
                Value = "1"
            };
            this.DropDownListIfShow.Items.Add(item4);
            ListItem item5 = new ListItem
            {
                Text = "不显示",
                Value = "0"
            };
            this.DropDownListIfShow.Items.Add(item5);
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (this.ButtonConfirm.ToolTip == "Update")
            {
                this.Edit();
            }
            else if (this.ButtonConfirm.ToolTip == "Submit")
            {
                this.Add();
            }
        }

        protected void ClearControl()
        {
            this.TextBoxKeyWords.Text = string.Empty;
            this.DropDownListType.SelectedValue = "-1";
            this.DropDownListIfShow.SelectedValue = "1";
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.ToolTip = "Submit";
        }

        protected void Edit()
        {
            ShopNum1_KeyWords words = new ShopNum1_KeyWords
            {
                Name = this.TextBoxKeyWords.Text.Trim(),
                Type = Convert.ToInt32(this.DropDownListType.SelectedValue),
                IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue),
                ModifyUser = "admin",
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            ShopNum1_KeyWords_Action action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
            if (action.Update(this.hiddenFieldGuid.Value, words) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "编辑" + this.TextBoxKeyWords.Text.Trim() + "成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "AgentKeyWords_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                base.Response.Redirect("KeyWords_Manage.aspx");
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo = ((ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action()).GetEditInfo(this.hiddenFieldGuid.Value);
            this.TextBoxKeyWords.Text = editInfo.Rows[0]["Name"].ToString();
            this.DropDownListIfShow.SelectedValue = editInfo.Rows[0]["IfShow"].ToString();
            this.DropDownListType.SelectedValue = editInfo.Rows[0]["Type"].ToString();
            this.ButtonConfirm.Text = "更新";
            this.ButtonConfirm.ToolTip = "Update";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (this.Page.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!this.Page.IsPostBack)
            {
                this.BindStatus();
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.LabelPageTitle.Text = "编辑关键字";
                    this.GetEditInfo();
                }
            }
        }

    }
}