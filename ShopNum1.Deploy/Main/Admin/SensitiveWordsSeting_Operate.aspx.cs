using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SensitiveWordsSeting_Operate : PageBase, IRequiresSessionState
    {
        private string string_4 = string.Empty;
        
        protected void Add()
        {
            var words = new ShopNum1_BadWords
                {
                    CreateUser = "admin",
                    find = TextBoxName.Text,
                    replacement = TextBoxreplacement.Text
                };
            var action = (ShopNum1_BadWord_Action) LogicFactory.CreateShopNum1_BadWord_Action();
            if (action.Add(words) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "添加敏感字设置成功!",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SensitiveWordsSeting_Operate.aspx",
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

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void ClearControl()
        {
            TextBoxName.Text = "";
            TextBoxreplacement.Text = "";
        }

        protected void Edit()
        {
            var words = new ShopNum1_BadWords
                {
                    CreateUser = "admin",
                    find = TextBoxName.Text
                };
            words.id = int.Parse(hiddenFieldGuid.Value);
            words.replacement = TextBoxreplacement.Text;
            var action = (ShopNum1_BadWord_Action) LogicFactory.CreateShopNum1_BadWord_Action();
            if (action.Updata(words) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑敏感字设置成功!",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SensitiveWordsSeting_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("SensitiveWordsSeting.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable table =
                ((ShopNum1_BadWord_Action) LogicFactory.CreateShopNum1_BadWord_Action()).Edit(
                    int.Parse(hiddenFieldGuid.Value));
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxName.Text = table.Rows[0]["find"].ToString();
                TextBoxreplacement.Text = table.Rows[0]["replacement"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["ID"] == null)
                                        ? "0"
                                        : base.Request.QueryString["ID"].Replace("'", "");
            this.string_4 = (base.Request.QueryString["type"] == null) ? "0" : base.Request.QueryString["type"];
            if (!base.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                LabelTitle.Text = "编辑敏感字";
                GetEditInfo();
                ButtonConfirm.Text = "更新";
            }
        }
    }
}