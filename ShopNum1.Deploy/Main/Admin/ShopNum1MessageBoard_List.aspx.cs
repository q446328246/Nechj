using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1MessageBoard_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindData();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_MessageBoard_Action action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除建议管理数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1MessageBoard_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindData();
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
            ShopNum1_MessageBoard_Action action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
            LinkButton button = (LinkButton)sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.Delete(guids) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除建议管理数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1MessageBoard_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindData();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonEdite_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopNum1MessageBoard_Operate.aspx?Guid=" + this.CheckGuid.Value);
        }

        private void BindData()
        {
            this.Num1GridViewShow.DataBind();
        }

    }
}