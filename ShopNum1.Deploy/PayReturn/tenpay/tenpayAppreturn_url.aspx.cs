using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using tenpay;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class tenpayAppreturn_url : Page, IRequiresSessionState
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = string.Empty;
            PayResponseHandler payResponseHandler = new PayResponseHandler(this.Context);
            string parameter = payResponseHandler.getParameter("sp_billno");
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Tenpay.aspx");
            if (paymentKey.Rows.Count > 0)
            {
                key = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            payResponseHandler.setKey(key);
            if (payResponseHandler.isTenpaySign())
            {
                payResponseHandler.getParameter("transaction_id");
                string parameter2 = payResponseHandler.getParameter("sp_billno");
                payResponseHandler.getParameter("total_fee");
                string parameter3 = payResponseHandler.getParameter("pay_result");
                if ("0".Equals(parameter3))
                {
                    try
                    {
                        if (parameter.StartsWith("C"))
                        {
                            decimal payMoney = Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("total_fee")) / Convert.ToDecimal(100);
                            ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                            string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                            this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), payMoney, "财付通即时到账会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                            shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, parameter);
                            base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx?type=1");
                        }
                        else
                        {
                            this.UpdataOrderInfo(parameter);
                        }
                    }
                    catch
                    {
                    }
                    this.Session["orderNum"] = parameter2;
                    payResponseHandler.doShow(ConfigurationManager.AppSettings["tenpayAppshow_url"]);
                }
            }
            else
            {
                base.Response.Write("认证签名失败");
            }
        }
        protected bool UpdataOrderInfo(string order_no)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable dataTable = shopNum1_OrderInfo_Action.SearchStatus(order_no);
            int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
            if (num < 1)
            {
                shopNum1_OrderInfo_Action.UpdateOrderInfoStatus_tenpay(order_no, "OderStatus", "1");
            }
            return true;
        }
        protected int CheckMember(string strValue)
        {
            int result = 0;
            try
            {
                Guid guid = new Guid(strValue);
            }
            catch
            {
                result = 1;
            }
            return result;
        }
        public bool CheckProductLine()
        {
            ShopSettings shopSettings = new ShopSettings();
            string fieldXmlPath = this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
            return bool.Parse(shopSettings.GetValue(fieldXmlPath, "AgentProductLine"));
        }
        public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
        {
            ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid=new Guid?(Guid.NewGuid());
            shopNum1_AdvancePaymentModifyLog.OperateType=OperateType;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment=AdvancePayments;
            shopNum1_AdvancePaymentModifyLog.OperateMoney=payMoney;
            if (type == 1)
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney=AdvancePayments + payMoney;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney=AdvancePayments - payMoney;
            }
            shopNum1_AdvancePaymentModifyLog.Date=time;
            shopNum1_AdvancePaymentModifyLog.Memo=Memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID=shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser=shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateTime=new DateTime?(time);
            shopNum1_AdvancePaymentModifyLog.IsDeleted=new int?(0);
            ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
        }
        private string method_0()
        {
            string result = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                result = httpCookie.Values["MemLoginID"].ToString();
            }
            return result;
        }

    }
}