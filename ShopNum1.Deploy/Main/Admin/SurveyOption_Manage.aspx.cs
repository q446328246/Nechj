using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SurveyOption_Manage : PageBase, IRequiresSessionState
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("SurveyTheme_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonAddOption_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SurveyOption_Manage.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_SurveyTheme_Action action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SurveyTheme_Manage.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
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
            LinkButton button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            ShopNum1_SurveyTheme_Action action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SurveyTheme_Manage.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
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
            base.Response.Redirect("SurveyTheme_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

    }
}