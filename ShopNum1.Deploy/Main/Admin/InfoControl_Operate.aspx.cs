using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class InfoControl_Operate : PageBase, IRequiresSessionState
    {
       
        protected void Add()
        {
            var control = new ShopNum1_Control
                {
                    Guid = Guid.NewGuid(),
                    PageName = this.TextBoxPageName.Text,
                    PageFileName = this.TextBoxPageFileName.Text,
                    ControlName = this.TextBoxControlName.Text,
                    ControlFileName = this.TextBoxControlFileName.Text,
                    ControlKey = this.TextBoxControlKey.Text,
                    ControlImg = this.TextBoxControlImg.Text,
                    CreateUser = base.ShopNum1LoginID,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = base.ShopNum1LoginID,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsShow = int.Parse(this.DropDownListIsShow.SelectedValue)
                };
            var action = (ShopNum1_Control_Action) LogicFactory.CreateShopNum1_Control_Action();
            if (action.Insert(control) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + this.TextBoxPageFileName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "InfoControl_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                ClearControl();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void BottonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InfoControl_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (this.BottonConfirm.ToolTip == "Update")
            {
                Edit();
            }
            else if (this.BottonConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void ButtonSeeData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ControlData_List.aspx?guid=" + this.hiddenFieldGuid.Value);
        }

        protected void ClearControl()
        {
            this.TextBoxPageName.Text = string.Empty;
            this.TextBoxPageFileName.Text = string.Empty;
            this.TextBoxControlName.Text = string.Empty;
            this.TextBoxControlFileName.Text = string.Empty;
            this.TextBoxControlKey.Text = string.Empty;
            this.TextBoxControlImg.Text = string.Empty;
        }

        protected void Edit()
        {
            var control = new ShopNum1_Control
                {
                    Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", "")),
                    PageName = this.TextBoxPageName.Text,
                    PageFileName = this.TextBoxPageFileName.Text,
                    ControlName = this.TextBoxControlName.Text,
                    ControlFileName = this.TextBoxControlFileName.Text,
                    ControlKey = this.TextBoxControlKey.Text,
                    ControlImg = this.TextBoxControlImg.Text,
                    ModifyUser = base.ShopNum1LoginID,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsShow = int.Parse(this.DropDownListIsShow.SelectedValue)
                };
            var action = (ShopNum1_Control_Action) LogicFactory.CreateShopNum1_Control_Action();
            if (action.Update(control) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + this.TextBoxPageFileName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "InfoControl_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("InfoControl_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_Control_Action) LogicFactory.CreateShopNum1_Control_Action()).GetEditInfo(
                    this.hiddenFieldGuid.Value);
            this.TextBoxPageName.Text = editInfo.Rows[0]["PageName"].ToString();
            this.TextBoxPageFileName.Text = editInfo.Rows[0]["PageFileName"].ToString();
            this.TextBoxControlName.Text = editInfo.Rows[0]["ControlName"].ToString();
            this.TextBoxControlFileName.Text = editInfo.Rows[0]["ControlFileName"].ToString();
            this.TextBoxControlKey.Text = editInfo.Rows[0]["ControlKey"].ToString();
            this.TextBoxControlImg.Text = editInfo.Rows[0]["ControlImg"].ToString();
            this.ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["ControlImg"];
            this.DropDownListIsShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
            this.BottonConfirm.Text = "更新";
            this.BottonConfirm.ToolTip = "Update";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                             ? "0"
                                             : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                ClearControl();
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.LabelPageTitle.Text = "编辑模块";
                    GetEditInfo();
                    this.ButtonSeeData.Visible = true;
                }
            }
        }
    }
}