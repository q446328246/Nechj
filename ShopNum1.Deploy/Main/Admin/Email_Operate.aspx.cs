using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Email_Operate : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                BindMenu();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑邮件模板";
                    GetEditInfo();
                }
            }
        }

        protected void Add()
        {
            var email = new ShopNum1_Email
                {
                    Guid = Guid.NewGuid(),
                    TypeName = DropDownListType.Text,
                    Title = TextBoxTitle.Text.Trim(),
                    Remark = FCKeditorRemark.Value,
                    Description = TextBoxDescription.Text.Trim(),
                    CreateUser = "admin",
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Add(email) > 0)
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

        protected void BindMenu()
        {
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (FCKeditorRemark.Value == string.Empty)
            {
                MessageBox.Show("邮件内容不能为空!");
            }
            else if (FCKeditorRemark.Value.Length > 0x3e8)
            {
                MessageBox.Show("你输入的邮件内容长度已经大于1000，<br/>请删减文字！");
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑邮件模板信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Email_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                Edit();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxTitle.Text = string.Empty;
            FCKeditorRemark.Value = string.Empty;
            TextBoxDescription.Text = string.Empty;
            DropDownListType.SelectedValue = "-1";
        }

        protected void Edit()
        {
            var email = new ShopNum1_Email
                {
                    TypeName = DropDownListType.Text,
                    Title = TextBoxTitle.Text.Trim(),
                    Remark = base.Server.HtmlEncode(FCKeditorRemark.Value),
                    Description = base.Server.HtmlEncode(TextBoxDescription.Text.Trim()),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Update(hiddenFieldGuid.Value, email) > 0)
            {
                base.Response.Redirect("Email_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action()).GetEditInfo(hiddenFieldGuid.Value,
                                                                                                 0);
            DropDownListType.Text = editInfo.Rows[0]["TypeName"].ToString();
            FCKeditorRemark.Value = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
            TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
            TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }


    }
}