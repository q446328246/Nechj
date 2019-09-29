using System;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ManagerShopPayMent : PageBase, IRequiresSessionState
    {
        private string string_4 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                CheckGuid.Value = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
                string shopPayMentByGuid =
                    ((ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action()).GetShopPayMentByGuid(
                        CheckGuid.Value.Replace("'", ""));
                RadioButtonListShopPayMent.SelectedValue = shopPayMentByGuid;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopInfoList_Manage.aspx");
        }

        protected void ButtonUpdata_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            if (
                action.UpdataShopPayMentByGuid(CheckGuid.Value.Replace("'", ""),
                                               RadioButtonListShopPayMent.SelectedValue) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理支付类型",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ManagerShopPayMent.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("ShopInfoList_Manage.aspx");
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

   
    }
}