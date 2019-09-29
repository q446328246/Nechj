using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class LogisticsCompany_Operate : PageBase, IRequiresSessionState
    {
        private string string_4 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["ID"] == null)
                                        ? "0"
                                        : base.Request.QueryString["ID"].Replace("'", "");
            if (!base.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                LabelTitle.Text = "编辑物流公司";
                GetEditInfo();
            }
        }

        protected void Add()
        {
            var action = (ShopNum1_Logistic_Action) LogicFactory.CreateShopNum1_Logistic_Action();
            if (!action.Exists(TextBoxValueCode.Text.Trim()))
            {
                MessageBox.Show("该物流公司已存在！");
            }
            else
            {
                var logistic = new ShopNum1_Logistic
                    {
                        Name = TextBoxName.Text.Trim(),
                        ValueCode = TextBoxValueCode.Text.Trim()
                    };
                if (CheckBoxIsShow.Checked)
                {
                    logistic.IsShow = 1;
                }
                else
                {
                    logistic.IsShow = 0;
                }
                logistic.Description = TextBoxContent.Text.Trim();
                if (action.Add(logistic) > 0)
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
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
              HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {

                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑物流公司信息成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "LogisticsCompany_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加物流公司信息成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "LogisticsCompany_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxName.Text = "";
            TextBoxValueCode.Text = "";
            TextBoxContent.Text = "";
        }

        protected void Edit()
        {
            var action = (ShopNum1_Logistic_Action) LogicFactory.CreateShopNum1_Logistic_Action();
            if ((HiddenFieldCode.Value != TextBoxValueCode.Text.Trim()) && !action.Exists(TextBoxValueCode.Text.Trim()))
            {
                MessageBox.Show("该物流公司已存在！");
            }
            else
            {
                var logistic = new ShopNum1_Logistic
                    {
                        Name = TextBoxName.Text.Trim(),
                        ValueCode = TextBoxValueCode.Text.Trim(),
                        Description = TextBoxContent.Text.Trim()
                    };
                if (CheckBoxIsShow.Checked)
                {
                    logistic.IsShow = 1;
                }
                else
                {
                    logistic.IsShow = 0;
                }
                logistic.ID = int.Parse(hiddenFieldGuid.Value);
                if (action.Update(logistic) > 0)
                {
                    MessageShow.ShowMessage("EditYes");
                    MessageShow.Visible = true;
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
            DataTable logistic =
                ((ShopNum1_Logistic_Action) LogicFactory.CreateShopNum1_Logistic_Action()).GetLogistic(
                    int.Parse(hiddenFieldGuid.Value));
            if ((logistic != null) && (logistic.Rows.Count > 0))
            {
                TextBoxName.Text = logistic.Rows[0]["Name"].ToString();
                HiddenFieldCode.Value = logistic.Rows[0]["ValueCode"].ToString();
                TextBoxValueCode.Text = logistic.Rows[0]["ValueCode"].ToString();
                TextBoxContent.Text = logistic.Rows[0]["Description"].ToString();
                if (logistic.Rows[0]["IsShow"].ToString() == "1")
                {
                    CheckBoxIsShow.Checked = true;
                }
                else
                {
                    CheckBoxIsShow.Checked = false;
                }
            }
        }


    }
}