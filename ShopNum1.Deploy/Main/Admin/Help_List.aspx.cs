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
    public partial class Help_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridView.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Help_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除帮助列表信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Help_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                BindGrid();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除帮助列表信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Help_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Help_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void HelpTypeBind()
        {
            DataTable list = ((ShopNum1_HelpType_Action) LogicFactory.CreateShopNum1_HelpType_Action()).GetList();
            DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListType.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                        list.Rows[i]["Guid"].ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                HelpTypeBind();
                BindGrid();
            }
        }
    }
}