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
    public partial class SurveyTheme_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            if (textBoxStartTime.Text.Trim() == "")
            {
                MessageBox.Show("请填写开始时间");
            }
            else if (textEndTime.Text.Trim() == "")
            {
                MessageBox.Show("请填写截止时间");
            }
            else
            {
                if (Convert.ToDateTime(textBoxStartTime.Text.Trim()) >= Convert.ToDateTime(textEndTime.Text.Trim()))
                {
                    MessageBox.Show("截止时间不能小于或等于开始时间");
                }
                var theme = new ShopNum1_SurveyTheme
                    {
                        Guid = Guid.NewGuid(),
                        Title = textBoxTitle.Text.Trim(),
                        StartTime = Convert.ToDateTime(textBoxStartTime.Text.Trim()),
                        EndTime = Convert.ToDateTime(textEndTime.Text.Trim()),
                        SimplyOrMultiCheck = Convert.ToInt32(radioButtonCheck.SelectedItem.Value)
                    };
                var action = (ShopNum1_SurveyTheme_Action) LogicFactory.CreateShopNum1_SurveyTheme_Action();
                if (action.Add(theme) > 0)
                {
                    foreach (System.Web.UI.Control control in Controls)
                    {
                        for (int i = 0; i < control.Controls.Count; i++)
                        {
                            if (control.Controls[i] is TextBox)
                            {
                                var box = (TextBox) control.Controls[i];
                                box.Text = "";
                            }
                        }
                    }
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑商城在线调查",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SurveyTheme_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加商城在线调查",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SurveyTheme_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void Edit()
        {
            if (textBoxStartTime.Text.Trim() == "")
            {
                MessageBox.Show("请填写开始时间");
            }
            else if (textEndTime.Text.Trim() == "")
            {
                MessageBox.Show("请填写截止时间");
            }
            else
            {
                var theme = new ShopNum1_SurveyTheme
                    {
                        Title = textBoxTitle.Text.Trim(),
                        StartTime = Convert.ToDateTime(textBoxStartTime.Text.Trim()),
                        EndTime = Convert.ToDateTime(textEndTime.Text.Trim()),
                        SimplyOrMultiCheck = Convert.ToInt32(radioButtonCheck.SelectedItem.Value)
                    };
                var action = (ShopNum1_SurveyTheme_Action) LogicFactory.CreateShopNum1_SurveyTheme_Action();
                if (action.Update(hiddenFieldGuid.Value, theme) > 0)
                {
                    base.Response.Redirect("SurveyTheme_Manage.aspx");
                }
                else
                {
                    MessageShow.ShowMessage("EditNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_SurveyTheme_Action) LogicFactory.CreateShopNum1_SurveyTheme_Action()).GetEditInfo(
                    hiddenFieldGuid.Value);
            textBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
            textBoxStartTime.Text = Convert.ToDateTime(editInfo.Rows[0]["StartTime"]).ToString("yyyy-MM-dd");
            textEndTime.Text = Convert.ToDateTime(editInfo.Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
            radioButtonCheck.SelectedValue = editInfo.Rows[0]["SimplyOrMultiCheck"].ToString();
            ButtonConfirm.Text = "更新";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                radioButtonCheck.SelectedValue = "0";
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑商城调查";
                    GetEditInfo();
                }
            }
        }
    }
}