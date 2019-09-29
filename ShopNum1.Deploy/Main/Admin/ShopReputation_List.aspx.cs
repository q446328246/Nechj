using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopReputation_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridviewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ShopReputation_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺信誉等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopReputation_List.aspx",
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action = (Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺信誉等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopReputation_List.aspx",
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
            base.Response.Redirect("ShopReputation_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected string IsType(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "店铺等级";
            }
            if (object_0.ToString() == "1")
            {
                return "店铺信誉等级";
            }
            return "非法类型";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
    }
}