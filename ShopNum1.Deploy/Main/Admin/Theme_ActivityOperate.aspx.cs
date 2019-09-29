using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Theme_ActivityOperate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_Activity_Action shopNum1_Activity_Action_0 =
            ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action());

        private readonly ShopNum1_ThemeActivity shopNum1_ThemeActivity_0 = new ShopNum1_ThemeActivity();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            shopNum1_ThemeActivity_0.Guid = Guid.NewGuid();
            shopNum1_ThemeActivity_0.ThemeImage = hidpicTheme.Value;
            shopNum1_ThemeActivity_0.ThemeTitle = Operator.FilterString(txtName.Value);
            shopNum1_ThemeActivity_0.StartDate = Convert.ToDateTime(txtStartTime.Value);
            shopNum1_ThemeActivity_0.EndDate = Convert.ToDateTime(txtEndTime.Value);
            shopNum1_ThemeActivity_0.ThemeDescription = Operator.FilterString(txtThemeDescription.Value);
            shopNum1_ThemeActivity_0.ThemeStatus = 0;
            shopNum1_ThemeActivity_0.OrderID = Convert.ToInt32(txtOrderID.Value);
            shopNum1_ThemeActivity_0.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_ThemeActivity_0.CreateUser = base.ShopNum1LoginID;
            var action = (ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action();
            if (Common.Common.ReqStr("update") != "")
            {
                shopNum1_ThemeActivity_0.Guid = new Guid(Common.Common.ReqStr("update"));
                action.UpdateThemeActivty(shopNum1_ThemeActivity_0);
            }
            else
            {
                action.AddThemeActivty(shopNum1_ThemeActivity_0);
            }
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "主题活动设置成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Theme_ActivityOperate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            lblMsg.Visible = true;
            lblMsg.Text = "操作成功！";
            BindData();
        }

        private void BindData()
        {
            try
            {
                txtStartTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txtEndTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
                txtFinalTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
                if (Common.Common.ReqStr("update") != "")
                {
                    string guid = Common.Common.ReqStr("update");
                    DataTable themeActivtyByGuid = shopNum1_Activity_Action_0.GetThemeActivtyByGuid(guid);
                    if ((themeActivtyByGuid != null) && (themeActivtyByGuid.Rows.Count > 0))
                    {
                        txtName.Value = themeActivtyByGuid.Rows[0]["ThemeTitle"].ToString();
                        txtStartTime.Value = themeActivtyByGuid.Rows[0]["StartDate"].ToString();
                        txtEndTime.Value = themeActivtyByGuid.Rows[0]["EndDate"].ToString();
                        txtThemeDescription.Value = themeActivtyByGuid.Rows[0]["ThemeDescription"].ToString();
                        txtOrderID.Value = themeActivtyByGuid.Rows[0]["OrderID"].ToString();
                        hidpicTheme.Value = themeActivtyByGuid.Rows[0]["themeimage"].ToString();
                        picTheme.Src = themeActivtyByGuid.Rows[0]["themeimage"].ToString();
                    }
                }
            }
            catch
            {
            }
        }
    }
}