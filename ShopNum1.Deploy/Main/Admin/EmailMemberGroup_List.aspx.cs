using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class EmailMemberGroup_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("EmailMemberGroup_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.DeleteMemberGroup(CheckGuid.Value) > 0)
            {
                BindGrid();
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除会员管理组成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "EmailMemberGroup_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.DeleteMemberGroup("'" + commandArgument + "'") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除会员管理组成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "EmailMemberGroup_List.aspx",
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
            base.Response.Redirect("EmailMemberGroup_Operate.aspx?guid=" + CheckGuid.Value.Replace("'", ""));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            BindGrid();
            if (!Page.IsPostBack)
            {
            }
        }
    }
}