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
    public partial class Group_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除管理员组",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Group_List.aspx",
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
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除管理员组",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Group_List.aspx",
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

        protected DataTable GetGroup()
        {
            string groupGuid = CheckGuid.Value;
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetGroupByGuid(groupGuid, 0);
        }

        protected DataTable GetGroup(string strGuid)
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetGroupByGuid(strGuid, 0);
        }

        protected DataTable GetPage()
        {
            string groupGuid = CheckGuid.Value;
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetPageByGroupGuid(groupGuid, 0);
        }

        protected DataTable GetPage(string strGuid)
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetPageByGroupGuid(strGuid, 0);
        }

        protected DataTable GetUser()
        {
            string groupGuid = CheckGuid.Value;
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetUserByGroupGuid(groupGuid, 0);
        }

        protected DataTable GetUser(string strGuid)
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetUserByGroupGuid(strGuid, 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
        }

        protected void PowerSet_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string str = button.CommandArgument ?? "";
            base.Response.Redirect("Competence.aspx?ID=" + str);
        }
    }
}