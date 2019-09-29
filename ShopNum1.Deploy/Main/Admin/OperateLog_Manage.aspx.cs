using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OperateLog_Manage : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog_Action action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
                this.BindGrid();
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            int num = new ShopNum1_OperateLog_Action().DeleteAll(this.textBoxDeleteStartTime.Text.Trim(), this.textDeleteEndTime.Text.Trim());
            if (num == -1)
            {
                MessageBox.Show("请选择要删除日志的时间！");
            }
            if (num > 0)
            {
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
                this.BindGrid();
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string guids = "'" + button.CommandArgument + "'";
            ShopNum1_OperateLog_Action action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
            if (action.Delete(guids) > 0)
            {
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
                this.BindGrid();
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }


    }
}