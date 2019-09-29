using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MobilePayment_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("MobilePayment_Operate.aspx?type=mobile&guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            if (action.DeleteMobile(this.CheckGuid.Value.ToString()) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MobilePayment_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.DeleteMobile(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MobilePayment_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MobilePayment_Operate.aspx?type=mobile&guid=" +
                                   this.CheckGuid.Value.ToString().Replace("'", ""));
        }

        protected string GetCharge(string charge, string isPer)
        {
            if (isPer == "1")
            {
                return (charge + "%");
            }
            return (charge + "元");
        }


    }
}