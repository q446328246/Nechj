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
    public partial class Help_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopNum1Help_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (CheckGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "更新帮助列表信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Help_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Update();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加帮助列表信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Help_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Insert();
            }
        }

        protected void HelpBind()
        {
            DataTable editInfo =
                ((ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action()).GetEditInfo(CheckGuid.Value);
            TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            FCKeditorContent.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
            DropDownListHelpTypeGuid.SelectedValue = editInfo.Rows[0]["HelpTypeGuid"].ToString();
            ButtonConfirm.Text = "更新";
        }

        protected void HelpTypeBind()
        {
            DataTable list = ((ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action()).GetList();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListHelpTypeGuid.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                list.Rows[i]["Guid"].ToString()));
            }
        }

        protected void Insert()
        {
            var help = new ShopNum1_Help
                {
                    Guid = Guid.NewGuid(),
                    Title = TextBoxTitle.Text,
                    Remark = base.Server.HtmlEncode(FCKeditorContent.Text.Replace("'", "''")),
                    HelpTypeGuid = new Guid(DropDownListHelpTypeGuid.SelectedValue),
                    OrderID = int.Parse(TextBoxOrderID.Text),
                    CreateUser = "admin",
                    ModifyUser = "admin"
                };
            var action = (ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action();
            if (action.Add(help) > 0)
            {
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        private int method_5()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Help");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            CheckGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                HelpTypeBind();
                if (CheckGuid.Value != "0")
                {
                    HelpBind();
                    LabelTitle.Text = "编辑帮助";
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString((method_5() + 1));
                }
            }
        }

        protected void Update()
        {
            var help = new ShopNum1_Help
                {
                    Guid = new Guid(CheckGuid.Value.Replace("'", "")),
                    Title = TextBoxTitle.Text,
                    Remark = base.Server.HtmlEncode(FCKeditorContent.Text.Replace("'", "''")),
                    HelpTypeGuid = new Guid(DropDownListHelpTypeGuid.SelectedValue),
                    OrderID = int.Parse(TextBoxOrderID.Text),
                    ModifyUser = "admin"
                };
            var action = (ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action();
            if (action.Update(help) > 0)
            {
                MessageShow.ShowMessage("EditYes");
                base.Response.Redirect("Help_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }
    }
}