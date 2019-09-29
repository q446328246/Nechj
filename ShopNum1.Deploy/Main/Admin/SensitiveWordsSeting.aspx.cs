using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SensitiveWordsSeting : PageBase, IRequiresSessionState
    {
        public void BindData()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            ShopNum1_BadWord_Action action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
            if (action.Delete(this.CheckGuid.Value) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除敏感字成功!",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SensitiveWordsSeting.aspx",
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
            ShopNum1_BadWord_Action action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
            LinkButton button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除敏感字成功!",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SensitiveWordsSeting.aspx",
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

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("SensitiveWordsSeting_Operate.aspx?ID=" + this.CheckGuid.Value);
        }

        public void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void ButtonUpdata_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SensitiveWordsSeting_Operate.aspx?ID=" + this.CheckGuid.Value + "&Type=1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindData();
            }
        }
    }
}