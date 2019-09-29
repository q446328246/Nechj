using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class unionpay_receive : Page, IRequiresSessionState
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = base.Request.Form["respCode"].ToString();
            string text = base.Request.Form["respMsg"].ToString();
            string text2 = base.Request.Form["orderNumber"].ToString();
            if (a == "00" && this.Session["lock"] == null && text.IndexOf("成功") != -1)
            {
                this.method_0(text2);
                this.Session["orderNum"] = text2;
                this.Session["lock"] = "lockok";
                base.Response.Redirect("unionpay_show.aspx");
            }
        }
        private bool method_0(string string_0)
        {
            if (base.Request.QueryString["sendmoney"] == null)
            {
                ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                DataTable dataTable = shopNum1_OrderInfo_Action.SearchStatus(string_0);
                int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
                if (num < 1)
                {
                    shopNum1_OrderInfo_Action.UpdateOrderInfoStatus_tenpay(string_0, "OderStatus", "1");
                }
            }
            else
            {
                string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + base.Request.QueryString["sendmoney"].ToString() + "'");
                if (nameById != "")
                {
                    ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
                    shopNum1_AdvancePaymentModifyLog.Guid=new Guid?(Guid.NewGuid());
                    shopNum1_AdvancePaymentModifyLog.OperateType=3;
                    shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment=Convert.ToDecimal(nameById);
                    shopNum1_AdvancePaymentModifyLog.OperateMoney=Convert.ToDecimal(base.Request.Form["orderAmount"].ToString()) / 100m;
                    shopNum1_AdvancePaymentModifyLog.LastOperateMoney=Convert.ToDecimal(nameById) + Convert.ToDecimal(shopNum1_AdvancePaymentModifyLog.OperateMoney);
                    shopNum1_AdvancePaymentModifyLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.Memo="商汇宝充值";
                    shopNum1_AdvancePaymentModifyLog.MemLoginID=base.Request.QueryString["sendmoney"].ToString();
                    shopNum1_AdvancePaymentModifyLog.CreateUser=base.Request.QueryString["sendmoney"].ToString();
                    shopNum1_AdvancePaymentModifyLog.CreateTime=new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    shopNum1_AdvancePaymentModifyLog.IsDeleted=new int?(0);
                    ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                    shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
                }
            }
            return true;
        }

    }
}