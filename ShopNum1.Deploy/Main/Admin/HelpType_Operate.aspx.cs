using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class HelpType_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            CheckGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                if (CheckGuid.Value != "0")
                {
                    HelpTypeBind();
                    lbladd.Text = "编辑帮助分类";
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString((method_5() + 1));
                }
            }
        }
        
        protected void Add()
        {
            var type = new ShopNum1_HelpType
                {
                    Guid = Guid.NewGuid(),
                    Name = TextBoxName.Text,
                    Remark = TextBoxDescription.Text,
                    OrderID = int.Parse(TextBoxOrderID.Text),
                    CreateUser = "admin",
                    ModifyUser = "admin"
                };
            var action = (ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action();
            if (action.Add(type) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "添加帮助分类信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "HelpType_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("HelpType_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (CheckGuid.Value != "0")
            {
                Update();
            }
            else
            {
                Add();
            }
        }

        protected void HelpTypeBind()
        {
            DataTable editInfo =
                ((ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action()).GetEditInfo(CheckGuid.Value);
            TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
            TextBoxDescription.Text = editInfo.Rows[0]["Remark"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            ButtonConfirm.Text = "更新";
        }

        private int method_5()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_HelpType");
        }



        protected void Update()
        {
            var type = new ShopNum1_HelpType
                {
                    Guid = new Guid(CheckGuid.Value.Replace("'", "")),
                    Name = TextBoxName.Text,
                    Remark = TextBoxDescription.Text,
                    OrderID = int.Parse(TextBoxOrderID.Text),
                    ModifyUser = "admin"
                };
            var action = (ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action();
            if (action.update(type) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "更新帮助分类信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "HelpType_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("EditYes");
                base.Response.Redirect("HelpType_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }
    }
}