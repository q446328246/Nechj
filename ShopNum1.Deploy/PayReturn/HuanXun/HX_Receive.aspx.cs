using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn
{
    public class HX_Receive : Page, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = base.Request["billno"];
            string text2 = base.Request["amount"];
            string text3 = base.Request["Currency_type"];
            string text4 = base.Request["date"];
            string text5 = base.Request["succ"];
            string arg_66_0 = base.Request["msg"];
            string arg_77_0 = base.Request["attach"];
            string text6 = base.Request["ipsbillno"];
            string text7 = base.Request["retencodetype"];
            string b = base.Request["signature"];
            string arg_BE_0 = base.Request["bankbillno"];
            string str = string.Concat(new string[]
		{
			"billno",
			text,
			"currencytype",
			text3,
			"amount",
			text2,
			"date",
			text4,
			"succ",
			text5,
			"ipsbillno",
			text6,
			"retencodetype",
			text7
		});
            bool flag = false;
            if (text7 == "12")
            {
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("huanxun.aspx");
                string str2 = paymentKey.Rows[0]["SecretKey"].ToString();
                string a = FormsAuthentication.HashPasswordForStoringInConfigFile(str + str2, "MD5").ToLower();
                if (a == b)
                {
                    flag = true;
                }
            }
            else
            {
                if (text7 == "17")
                {
                    ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                    DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("huanxun.aspx");
                    string str2 = paymentKey.Rows[0]["SecretKey"].ToString();
                    string a = FormsAuthentication.HashPasswordForStoringInConfigFile(str + str2, "MD5").ToLower();
                    if (a == b)
                    {
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                if (text5 != "Y")
                {
                    base.Response.Write("交易失败！");
                    base.Response.End();
                }
                else
                {
                    if (text.IndexOf("C") != -1)
                    {
                        ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                        DataTable dataTable = shopNum1_AdvancePaymentApplyLog_Action.SelectOperateMoney("", "1", "", "", text, "", "");
                        if (dataTable == null || dataTable.Rows.Count <= 0)
                        {
                            this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                        }
                        if (dataTable.Rows[0]["OperateStatus"].ToString() == "0")
                        {
                            string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                            this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(text2), "环迅支付会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                            shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, text);
                        }
                        base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
                    }
                    else
                    {
                        ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                        DataTable dataTable2 = shopNum1_OrderInfo_Action.SearchOrderInfo(text);
                        string text8 = dataTable2.Rows[0]["MemLoginID"].ToString();
                        string text9 = dataTable2.Rows[0]["Guid"].ToString();
                        string value = dataTable2.Rows[0]["ShouldPayPrice"].ToString();
                        dataTable2.Rows[0]["OrderNumber"].ToString();
                        string value2 = dataTable2.Rows[0]["OderStaus"].ToString();
                        if (Convert.ToInt32(value2) == 0)
                        {
                            shopNum1_OrderInfo_Action.SetPaymentStatus2(text9, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text2), Convert.ToDecimal(value));
                            ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                            shopNum1_OrderProduct_Action.UpdateStock(text9);
                            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            shopNum1_Member_Action.UpdateCostMoney(text8, Convert.ToDecimal(text2));
                            string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                            this.AdvancePaymentModifyLog(3, Convert.ToDecimal(nameById), Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")), "环迅支付会员购买商品", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                            this.OrderOperateLog("环迅支付会员购买商品", "买家已付款", "等待卖家发货", text9);
                            base.Response.Redirect("/main/Member/m_index.aspx?order=" + text);
                        }
                    }
                }
            }
            else
            {
                base.Response.Write("签名不正确！");
            }
        }
        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId)
        {
            ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
            shopNum1_OrderOperateLog.Guid=Guid.NewGuid();
            shopNum1_OrderOperateLog.OrderInfoGuid=new Guid(OrderGuId);
            shopNum1_OrderOperateLog.OderStatus=1;
            shopNum1_OrderOperateLog.ShipmentStatus=0;
            shopNum1_OrderOperateLog.PaymentStatus=1;
            shopNum1_OrderOperateLog.CurrentStateMsg=CurrentStateMsg;
            shopNum1_OrderOperateLog.NextStateMsg=NextStateMsg;
            shopNum1_OrderOperateLog.Memo=memo;
            shopNum1_OrderOperateLog.OperateDateTime=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderOperateLog.IsDeleted=0;
            shopNum1_OrderOperateLog.CreateUser=this.method_0();
            ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
            shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
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

    }
}