using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Group_ActivityOperate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_Product_Activity shopNum1_Product_Activity_0 = new ShopNum1_Product_Activity();

        protected void btnSub_Click(object sender, EventArgs e)
        {
            shopNum1_Product_Activity_0.Name = Operator.FilterString(txtName.Value);
            shopNum1_Product_Activity_0.StartTime = Convert.ToDateTime(txtStartTime.Value);
            shopNum1_Product_Activity_0.EndTime = Convert.ToDateTime(txtEndTime.Value);
            shopNum1_Product_Activity_0.FinalTime = Convert.ToDateTime(txtFinalTime.Value);
            shopNum1_Product_Activity_0.Type = 1;
            shopNum1_Product_Activity_0.Pic = "";
            shopNum1_Product_Activity_0.Discount = Convert.ToDecimal("0.00");
            var action = (ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action();
            if (Common.Common.ReqStr("id") != "")
            {
                shopNum1_Product_Activity_0.Id = Convert.ToInt32(Common.Common.ReqStr("id"));
                action.UpdateActivity(shopNum1_Product_Activity_0);
            }
            else
            {
                action.AddActivity(shopNum1_Product_Activity_0);
            }
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "添加或更改团购活动信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Group_ProductList.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            lblMsg.Visible = true;
            lblMsg.Text = "操作成功！";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                txtStartTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txtEndTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
                txtFinalTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
                if (Common.Common.ReqStr("id") != "")
                {
                    string str = Common.Common.ReqStr("id");
                    DataTable groupActivityById =
                        ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action()).GetGroupActivityById(
                            str);
                    if ((groupActivityById != null) && (groupActivityById.Rows.Count > 0))
                    {
                        txtName.Value = groupActivityById.Rows[0]["name"].ToString();
                        txtStartTime.Value = groupActivityById.Rows[0]["starttime"].ToString();
                        txtEndTime.Value = groupActivityById.Rows[0]["endtime"].ToString();
                    }
                }
            }
        }
    }
}