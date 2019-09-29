using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ServiceOnLineService_List : PageBase, IRequiresSessionState
    {
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("ServiceOnLineService_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_OnLineService_Action action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "客服管理信息批量删除成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ServiceOnLineService_List.aspx",
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
            ShopNum1_OnLineService_Action action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
            LinkButton button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "客服管理信息删除成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ServiceOnLineService_List.aspx",
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
            base.Response.Redirect("ServiceOnLineService_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        public string ChangeIsShow(string strIsShow)
        {
            if (strIsShow == "0")
            {
                return "images/shopNum1Admin-wrong.gif";
            }
            if (strIsShow == "1")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "";
        }

        private void BindData()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
            }
        }
    }
}