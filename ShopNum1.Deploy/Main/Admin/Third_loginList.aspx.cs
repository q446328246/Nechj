using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Second;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Third_loginList : PageBase, IRequiresSessionState
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
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Third_loginOperate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var bussiness = new ShopNum1_SecondTypeBussiness();
            if (bussiness.Delete(int.Parse(CheckGuid.Value.Replace("'", ""))))
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ɾ���ɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Third_loginList.aspx",
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
            var bussiness = new ShopNum1_SecondTypeBussiness();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (bussiness.Delete(int.Parse(commandArgument.Replace("'", ""))))
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ɾ���ɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Third_loginList.aspx",
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

        protected string GetAvailState(object avalable)
        {
            if (avalable.ToString() == "1")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }
    }
}