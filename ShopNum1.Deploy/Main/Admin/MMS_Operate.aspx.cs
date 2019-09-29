using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MMS_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                BindMenu();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑短信模板";
                    GetEditInfo();
                }
            }
        }

        protected void Add()
        {
            var email = new ShopNum1_MMS
                {
                    Guid = Guid.NewGuid(),
                    TypeName = DropDownListType.SelectedValue,
                    Title = TextBoxTitle.Text.Trim(),
                    Remark = base.Server.HtmlEncode(Operator.FilterString(FCKeditorRemark.Text.Replace("'", "''"))),
                    Description = TextBoxDescription.Text.Trim(),
                    CreateUser = base.ShopNum1LoginID,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = base.ShopNum1LoginID,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            if (action.Add(email) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MMS_Operate.aspx",
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

        protected void BindMenu()
        {
        }

        protected void butConfirm_Click(object sender, EventArgs e)
        {
            if (FCKeditorRemark.Text == string.Empty)
            {
                MessageBox.Show("短信内容不能为空!");
            }
            else if (FCKeditorRemark.Text.Length > 300)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),"pop", "<script>alert('你输入的短信内容长度已经大于300，<br/>请删减文字！');</script>");
            }
            else if (butConfirm.ToolTip == "Update")
            {
                Edit();
            }
            else if (butConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxTitle.Text = string.Empty;
            FCKeditorRemark.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            DropDownListType.SelectedValue = "-1";
        }

        protected void Edit()
        {
            var email = new ShopNum1_MMS
                {
                    TypeName = DropDownListType.SelectedValue,
                    Title = TextBoxTitle.Text.Trim(),
                    Remark = base.Server.HtmlEncode(Operator.FilterString(FCKeditorRemark.Text.Replace("'", "''"))),
                    Description = TextBoxDescription.Text.Trim(),
                    ModifyUser = base.ShopNum1LoginID,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            if (action.Update(hiddenFieldGuid.Value, email) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MMS_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("MMS_List.aspx");
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
                ((ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action()).GetEditInfo(
                    hiddenFieldGuid.Value, 0);
            DropDownListType.Text = editInfo.Rows[0]["TypeName"].ToString();
            FCKeditorRemark.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
            TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
            TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
            butConfirm.Text = "更新";
            butConfirm.ToolTip = "Update";
        }


    }
}