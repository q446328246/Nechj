using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SetWxInfo_V82 : PageBase, IRequiresSessionState
    {
        protected void btnPayReturn_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ShopInfoList_Manage.aspx");
        }

        protected void btnPaySub_Click(object sender, EventArgs e)
        {
            Common.Common.UpdateInfo(
                "wDepartTime='" + this.selectpart.Items[this.selectpart.SelectedIndex].Value + "',wPayMoney='" +
                this.txtWxPay.Value + "'", "shopnum1_shopinfo", " And Guid='" + this.CheckGuid.Value + "'");
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "微信店铺费用设置成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SetWxInfo_V82.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            MessageBox.Show("保存成功！");
            BindData();
        }

        private void BindData()
        {
            string str = Common.Common.ReqStr("guid");
            this.CheckGuid.Value = str;
            DataTable table = Common.Common.GetTableById("wDepartTime,wPayMoney", "shopnum1_shopinfo",
                                                         " And Guid='" + str + "'");
            if (table.Rows.Count > 0)
            {
                this.txtWxPay.Value = table.Rows[0]["wPayMoney"].ToString();
                this.hidDepart.Value = table.Rows[0]["wDepartTime"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}