using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn.ShengPay
{
    public partial class SPReceive : Page, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("ShengPay.aspx");
            if (paymentKey.Rows.Count == 0)
            {
                this.Page.Response.Write("盛付通支付方式未配置,请联系售后！");
            }
            string text = paymentKey.Rows[0]["SecretKey"].ToString();
            string s = string.Concat(new string[]
		{
			base.Request.Form["Name"],
			base.Request.Form["Version"],
			base.Request.Form["Charset"],
			base.Request.Form["TraceNo"],
			base.Request.Form["MsgSender"],
			base.Request.Form["SendTime"],
			base.Request.Form["InstCode"],
			base.Request["OrderNo"],
			base.Request.Form["OrderAmount"],
			base.Request["TransNo"],
			base.Request.Form["TransAmount"],
			base.Request.Form["TransStatus"],
			base.Request.Form["TransType"],
			base.Request.Form["TransTime"],
			base.Request.Form["MerchantNo"],
			base.Request.Form["ErrorCode"],
			base.Request.Form["ErrorMsg"],
			base.Request.Form["Ext1"],
			base.Request.Form["SignType"],
			text
		});
            string text2 = base.Request.Form["OrderNo"].ToString();
            string value = base.Request.Form["TransAmount"].ToString();
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] signed = mD.ComputeHash(Encoding.GetEncoding("gbk").GetBytes(s));
            string text3 = byte2mac(signed);
            string text4 = text3.ToUpper();
            if (text4.Equals(base.Request.Form["SignMsg"].ToString().Trim()))
            {
                if (text2.IndexOf("C") != -1)
                {
                    ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                    DataTable dataTable = shopNum1_AdvancePaymentApplyLog_Action.SelectOperateMoney("", "1", "", "", text2, "", "");
                    if (dataTable == null || dataTable.Rows.Count <= 0)
                    {
                        this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                    }
                    if (dataTable.Rows[0]["OperateStatus"].ToString() == "0")
                    {
                        string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                        this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(value), "盛付通会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, text2);
                    }
                    base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
                }
                else
                {
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable2 = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);
                    string text5 = dataTable2.Rows[0]["MemLoginID"].ToString();
                    string text6 = dataTable2.Rows[0]["Guid"].ToString();
                    string value2 = dataTable2.Rows[0]["ShouldPayPrice"].ToString();
                    dataTable2.Rows[0]["OrderNumber"].ToString();
                    string value3 = dataTable2.Rows[0]["OderStaus"].ToString();
                    if (Convert.ToInt32(value3) == 0)
                    {
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text6, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                        shopNum1_OrderProduct_Action.UpdateStock(text6);
                        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        shopNum1_Member_Action.UpdateCostMoney(text5, Convert.ToDecimal(value));
                        string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                        this.AdvancePaymentModifyLog(3, Convert.ToDecimal(nameById), Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")), "盛付通会员购买商品", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                        this.OrderOperateLog("盛付通会员购买商品", "买家已付款", "等待卖家发货", text6);
                        base.Response.Redirect("/main/Member/m_index.aspx?order=" + text2);
                    }
                }
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

        public static string byte2mac(byte[] signed)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < signed.Length; i++)
            {
                byte b = signed[i];
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

    }
}