using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using com.yeepay;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class Callback : Page, IRequiresSessionState
    {
        private static string string_0;
        private static string string_1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string str = ShopNum1.Common.Common.GetNameById("MerchantCode", "ShopNum1_Payment", "  AND  PaymentType='Yeepay.aspx'");
                string str2 = ShopNum1.Common.Common.GetNameById("SecretKey", "ShopNum1_Payment", "  AND  PaymentType='Yeepay.aspx'");
                string_0 = str;
                string_1 = str2;
                BuyCallbackResult result = Buy.VerifyCallback(string_0, string_1,
                                                              FormatQueryString.GetQueryString("r0_Cmd"),
                                                              FormatQueryString.GetQueryString("r1_Code"),
                                                              FormatQueryString.GetQueryString("r2_TrxId"),
                                                              FormatQueryString.GetQueryString("r3_Amt"),
                                                              FormatQueryString.GetQueryString("r4_Cur"),
                                                              FormatQueryString.GetQueryString("r5_Pid"),
                                                              FormatQueryString.GetQueryString("r6_Order"),
                                                              FormatQueryString.GetQueryString("r7_Uid"),
                                                              FormatQueryString.GetQueryString("r8_MP"),
                                                              FormatQueryString.GetQueryString("r9_BType"),
                                                              FormatQueryString.GetQueryString("rp_PayDate"),
                                                              FormatQueryString.GetQueryString("hmac"));
                if (string.IsNullOrEmpty(result.ErrMsg))
                {
                    if (result.R1_Code == "1")
                    {
                        if (result.R9_BType == "1")
                        {
                            if (result.R5_Pid.StartsWith("C"))
                            {
                                var action =
                                    (ShopNum1_AdvancePaymentApplyLog_Action)
                                    LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                                string str3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member",
                                                                 " and memloginId='" + BindData() + "'");
                                AdvancePaymentModifyLog(1, Convert.ToDecimal(str3), Convert.ToDecimal(result.R3_Amt),
                                                        "易宝(YeePay)会员充值", BindData(),
                                                        Convert.ToDateTime(
                                                            DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")),
                                                        1);
                                action.ChangeApplyLogStatus(1, result.R5_Pid);
                                base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx?type=1");
                            }
                            else
                            {
                                var action2 = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                                DataTable table = action2.SearchOrderInfo(result.R6_Order);
                                string strValue = table.Rows[0]["MemLoginID"].ToString();
                                string guid = table.Rows[0]["Guid"].ToString();
                                string str6 = table.Rows[0]["ShouldPayPrice"].ToString();
                                table.Rows[0]["OrderNumber"].ToString();
                                action2.SetPaymentStatus2(guid, 1, 1, 0, DateTime.Now, Convert.ToDecimal(result.R3_Amt),
                                                          Convert.ToDecimal(str6));
                                if (CheckMember(strValue) == 1)
                                {
                                    ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action())
                                        .UpdateCostMoney(
                                            strValue, Convert.ToDecimal(result.R3_Amt));
                                }
                                base.Response.Write("支付成功!<br>商品ID:" + result.R5_Pid + "<br>商户订单号:" + result.R6_Order +
                                                    "<br>支付金额:" + result.R3_Amt + "<br>易宝支付交易流水号:" + result.R2_TrxId +
                                                    "<BR>");
                            }
                        }
                        else if (result.R9_BType == "2")
                        {
                            base.Response.Write("SUCCESS");
                        }
                        else if (result.R9_BType == "3")
                        {
                            base.Response.Write("SUCCESS");
                        }
                    }
                    else
                    {
                        base.Response.Write("支付失败!");
                    }
                }
                else
                {
                    base.Response.Write("交易签名无效!");
                }
            }
        }

        public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo,
                                         string shopMemloginID, DateTime time, int type)
        {
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                Guid = Guid.NewGuid(),
                OperateType = OperateType,
                CurrentAdvancePayment = AdvancePayments,
                OperateMoney = payMoney
            };
            if (type == 1)
            {
                advancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
            }
            else
            {
                advancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
            }
            advancePaymentModifyLog.Date = time;
            advancePaymentModifyLog.Memo = Memo;
            advancePaymentModifyLog.MemLoginID = shopMemloginID;
            advancePaymentModifyLog.CreateUser = shopMemloginID;
            advancePaymentModifyLog.CreateTime = time;
            advancePaymentModifyLog.IsDeleted = 0;
            ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoney(advancePaymentModifyLog);
        }

        protected int CheckMember(string strValue)
        {
            int num = 0;
            try
            {
                var guid = new Guid(strValue);
            }
            catch
            {
                num = 1;
            }
            return num;
        }

        private string BindData()
        {
            string str = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                str = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
            }
            return str;
        }

    }
}