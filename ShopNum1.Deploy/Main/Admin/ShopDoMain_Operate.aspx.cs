using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopDoMain_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            var manage = new ShopNum1_ShopURLManage
                {
                    DoMain = TextBoxName.Text,
                    MemLoginID = TextBoxShopName.Text,
                    SiteNumber = TextBoxSiteNumber.Text,
                    GoUrl = TextBoxGoUrl.Text
                };
            var action = (ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action();
            if (action.CheckDoMain(TextBoxName.Text).Rows.Count > 0)
            {
                MessageBox.Show("域名已存在!");
            }
            else if (action.Add(manage) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AgentDoMain_Operate.aspx",
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

        public void BindShopLoginID()
        {
            DataTable shopLoginID =
                ((ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action()).GetShopLoginID(
                    base.Request.QueryString["MemLoginID"].Replace("'", ""));
            HiddenFieldAgentID.Value = shopLoginID.Rows[0]["MemLoginID"].ToString();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopDoMain_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (ButtonConfirm.ToolTip == "Update")
            {
                Edit();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxName.Text = string.Empty;
            TextBoxSiteNumber.Text = string.Empty;
        }

        protected void Edit()
        {
            var action = (ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action();
            var table = new DataTable();
            if (ViewState["DoMain"].ToString() != TextBoxName.Text)
            {
                table = action.CheckDoMain(TextBoxName.Text);
            }
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("域名已存在!");
            }
            else if (action.Update(hiddenFieldGuid.Value.Replace("'", ""), TextBoxName.Text, TextBoxSiteNumber.Text) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + TextBoxName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AgentDoMain_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("ShopDoMain_List.aspx");
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
                ((ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action()).GetEditInfo(
                    hiddenFieldGuid.Value.Replace("'", ""));
            TextBoxName.Text = editInfo.Rows[0]["DoMain"].ToString();
            TextBoxSiteNumber.Text = editInfo.Rows[0]["SiteNumber"].ToString();
            TextBoxShopName.Text = editInfo.Rows[0]["MemLoginID"].ToString();
            TextBoxGoUrl.Text = editInfo.Rows[0]["GoUrl"].ToString();
            ViewState["DoMain"] = editInfo.Rows[0]["DoMain"].ToString();
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
            LabelPageTitle.Text = "【 编辑域名 】";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                ViewState["DoMain"] = "";
                GetEditInfo();
            }
        }
    }
}