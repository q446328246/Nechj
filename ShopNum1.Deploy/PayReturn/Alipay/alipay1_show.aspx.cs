using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class alipay1_show : Page, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList requestPost = this.GetRequestPost();
            string text = string.Empty;
            string text2 = string.Empty;
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
            if (paymentKey.Rows.Count > 0)
            {
                text = paymentKey.Rows[0]["MerchantCode"].ToString();
                text2 = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            string text3 = "utf-8";
            string text4 = "MD5";
            string text5 = "https";
            if (requestPost.Count > 0)
            {
                AlipayNotify alipayNotify = new AlipayNotify(requestPost, base.Request.Form["notify_id"], text, text2, text3, text4, text5);
                string responseTxt = alipayNotify.ResponseTxt;
                string a = base.Request.Form["sign"];
                string mysign = alipayNotify.Mysign;
                if (responseTxt == "true" && a == mysign)
                {
                    string text6 = base.Request.Form["trade_no"];
                    string text7 = base.Request.Form["out_trade_no"];
                    string value = base.Request.Form["price"];
                    string text8 = base.Request.Form["subject"];
                    string arg_180_0 = base.Request.Form["body"];
                    string arg_196_0 = base.Request.Form["buyer_email"];
                    string arg_1AC_0 = base.Request.Form["trade_status"];
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    if (base.Request.Form["trade_status"] == "WAIT_BUYER_PAY")
                    {
                        DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text7);
                        if (dataTable.Rows.Count > 0)
                        {
                            dataTable.Rows[0]["MemLoginID"].ToString();
                            string text9 = dataTable.Rows[0]["Guid"].ToString();
                            string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                            dataTable.Rows[0]["OrderNumber"].ToString();
                            string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                            string text10 = dataTable.Rows[0]["PaymentStatus"].ToString();
                            string a3 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                            if (!(a2 == "0") || !(a3 == "0") || !(text10 == "0"))
                            {
                                shopNum1_OrderInfo_Action.SetWaitBuyerPay("1", "0", "1", text9);
                            }
                            base.Response.Write("success");
                        }
                    }
                    else
                    {
                        if (base.Request.Form["trade_status"] == "WAIT_SELLER_SEND_GOODS")
                        {
                            if (base.Request.QueryString["body"] == "Recharge")
                            {
                                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                                string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                                
                                //充值
                                this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")), "支付宝担保交易会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                                shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, ShopNum1.Common.Common.ReqStr("subject"));
                                base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
                            }
                            else
                            {
                                string text11 = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + text7 + "'";
                                DataTable dataTable = DatabaseExcetue.ReturnDataTable(text11);
                                if (dataTable.Rows.Count > 0)
                                {
                                    dataTable.Rows[0]["MemLoginID"].ToString();
                                    string text9 = dataTable.Rows[0]["Guid"].ToString();
                                    string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                    dataTable.Rows[0]["OrderNumber"].ToString();
                                    string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                                    string text10 = dataTable.Rows[0]["PaymentStatus"].ToString();
                                    string a3 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                                    if (Convert.ToInt32(text10) < 1)
                                    {
                                        int num = shopNum1_OrderInfo_Action.SetPaymentStatus2(text8, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2), text6);
                                        this.OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", text9);
                                        string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                                        try
                                        {
                                            this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")), "支付宝担保交易会员购买商品", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                                        }
                                        catch
                                        {
                                        }
                                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                                        shopNum1_OrderProduct_Action.UpdateStock(text9);
                                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "订单当前状态：成功", Encoding.UTF8);
                                        base.Response.Write("success");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (base.Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
                            {
                                DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text7);
                                if (dataTable.Rows.Count > 0)
                                {
                                    dataTable.Rows[0]["MemLoginID"].ToString();
                                    string text9 = dataTable.Rows[0]["Guid"].ToString();
                                    string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                    dataTable.Rows[0]["OrderNumber"].ToString();
                                    string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                                    string text10 = dataTable.Rows[0]["PaymentStatus"].ToString();
                                    string a3 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                                    if (!(a2 == "2") || !(text10 == "1") || !(a3 == "1"))
                                    {
                                        Random random = new Random();
                                        int num = shopNum1_OrderInfo_Action.SetShipmentStatus1(text9, 2, 1, 1, DateTime.Now, "XT_" + DateTime.Now.ToLongTimeString().Replace("-", "") + random.Next(0, 1000));
                                    }
                                    base.Response.Write("success");
                                    base.Response.Redirect("/main/Member/m_index.aspx");
                                }
                            }
                            else
                            {
                                if (base.Request.Form["trade_status"] == "TRADE_FINISHED")
                                {
                                    string text11 = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + text7 + "'";
                                    DataTable dataTable = DatabaseExcetue.ReturnDataTable(text11);
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        dataTable.Rows[0]["MemLoginID"].ToString();
                                        string text9 = dataTable.Rows[0]["Guid"].ToString();
                                        string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                        dataTable.Rows[0]["OrderNumber"].ToString();
                                        string text12 = dataTable.Rows[0]["PayMentMemLoginID"].ToString();
                                        string text13 = dataTable.Rows[0]["MemLoginId"].ToString();
                                        string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                                        string text10 = dataTable.Rows[0]["PaymentStatus"].ToString();
                                        string a3 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                                        if (!(a2 == "3") || !(text10 == "1") || !(a3 == "2"))
                                        {
                                            int num = shopNum1_OrderInfo_Action.SetShipmentStatus2(text9, 3, 1, 2);
                                            ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                                            if (num > 0)
                                            {
                                                IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
                                                string text14 = text9;
                                                decimal d = 0m;
                                                decimal d2 = 0m;
                                                string a4 = text12;
                                                if (a4 == "admin")
                                                {
                                                    DataTable dataTable2 = shopNum1_OrderInfo_Action.SearchOrderShouldPrice(text14);
                                                    string text15 = dataTable2.Rows[0]["ShopID"].ToString();
                                                    decimal num2 = Convert.ToDecimal(dataTable2.Rows[0]["ShouldPayPrice"].ToString());
                                                    ShopNum1_Member_Action shopNum1_Member_Action2 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                                    DataTable dataTable3 = shopNum1_Member_Action2.SearchByMemLoginID(text15);
                                                    if (dataTable3 == null || dataTable3.Rows.Count <= 0)
                                                    {
                                                        return;
                                                    }
                                                    decimal advancePayments = Convert.ToDecimal(dataTable3.Rows[0]["AdvancePayment"].ToString());
                                                    string text16 = "select BuyNumber from shopnum1_orderinfo A inner join shopnum1_orderproduct B on b.orderinfoguid = A.guid where A.guid='" + text9 + "'";
                                                    DataTable dataTable4 = DatabaseExcetue.ReturnDataTable(text16);
                                                    if (dataTable4 != null && dataTable4.Rows.Count > 0)
                                                    {
                                                        for (int i = 0; i < dataTable4.Rows.Count; i++)
                                                        {
                                                            int num3 = Convert.ToInt32(dataTable4.Rows[i]["BuyNumber"].ToString());
                                                            for (int j = 0; j < num3; j++)
                                                            {
                                                                if (ShopSettings.GetValue("IsAdminProductFcCount") == "true")
                                                                {
                                                                    decimal d3 = decimal.Parse(ShopSettings.GetValue("AdminProductFcCount")) / 100m;
                                                                    decimal d4 = Convert.ToDecimal(num2 * d3);
                                                                    d += d4;
                                                                }
                                                                if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
                                                                {
                                                                    decimal d5 = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate")) / 100m;
                                                                    d2 = Convert.ToDecimal((num2 - Convert.ToDecimal(dataTable2.Rows[0]["DispatchPrice"].ToString())) * d5);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    decimal num4 = Convert.ToDecimal(num2 - d2);
                                                    if (ShopSettings.GetValue("IsOrderCommission") == "true")
                                                    {
                                                        decimal d6 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100m;
                                                        if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
                                                        {
                                                            num4 -= num2 * d6;
                                                        }
                                                        else
                                                        {
                                                            num4 = num2 * (1m - d6);
                                                        }
                                                    }
                                                    if (ShopSettings.GetValue("IsOrderCommission") != "true" && ShopSettings.GetValue("IsShopProductFcRate") != "true")
                                                    {
                                                        num4 = num2;
                                                    }
                                                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                                                    DataTable dataTable5 = shopNum1_OrderInfo_Action2.Search1(text14);
                                                    if (dataTable5 != null && dataTable5.Rows.Count > 0 && dataTable5.Rows[0]["PaymentName"].ToString() != "货到付款" && shopNum1_Member_Action.UpdateAdvancePayment(0, text15, num4) > 0)
                                                    {
                                                        this.AdvancePaymentModifyLog(2, advancePayments, num4, "会员确认收货，平台支付给卖家金币（BV）", text15, DateTime.Now, 1);
                                                    }
                                                }
                                                else
                                                {
                                                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                                                    DataTable dataTable5 = shopNum1_OrderInfo_Action2.Search1(text14);
                                                    if (dataTable5 != null && dataTable5.Rows.Count > 0)
                                                    {
                                                        ShopNum1_Member_Action shopNum1_Member_Action3 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                                        if (dataTable5.Rows[0]["PaymentName"].ToString() == "金币（BV）支付")
                                                        {
                                                            DataTable dataTable6 = shopNum1_Member_Action.SearchByMemLoginID(dataTable5.Rows[0]["ShopID"].ToString());
                                                            if (dataTable6 != null && dataTable6.Rows.Count > 0)
                                                            {
                                                                Convert.ToDecimal(dataTable6.Rows[0]["AdvancePayment"].ToString());
                                                                shopNum1_Member_Action3.UpdateAdvancePayment(0, dataTable5.Rows[0]["ShopID"].ToString(), Convert.ToDecimal(dataTable5.Rows[0]["ShouldPayPrice"].ToString()));
                                                                this.AdvancePaymentModifyLog(2, Convert.ToDecimal(dataTable6.Rows[0]["AdvancePayment"].ToString()), Convert.ToDecimal(dataTable5.Rows[0]["ShouldPayPrice"].ToString()), "会员确认收货，平台支付给卖家金币（BV）", dataTable5.Rows[0]["ShopID"].ToString(), DateTime.Now, 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (dataTable5.Rows[0]["PaymentName"].ToString() == "支付宝担保交易")
                                                            {
                                                                DataTable dataTable7 = shopNum1_Member_Action.SearchByMemLoginID(dataTable5.Rows[0]["ShopID"].ToString());
                                                                decimal d7 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100m;
                                                                decimal payMoney = Convert.ToDecimal(dataTable5.Rows[0]["ShouldPayPrice"].ToString()) * d7;
                                                                this.AdvancePaymentModifyLog(2, Convert.ToDecimal(dataTable7.Rows[0]["AdvancePayment"].ToString()), payMoney, "由于支付宝担保交易，扣除卖家金币（BV）的交易费", dataTable5.Rows[0]["ShopID"].ToString(), DateTime.Now, 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                shopNum1_OrderInfo_Action.SetOderStatus1(text14, 3, 1, 2, DateTime.Now);
                                                shopNum1_OrderProduct_Action.UpdateStock(text9.ToString());
                                                int num5 = (ShopSettings.GetValue("MyCommentRankSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyCommentRankSorce"));
                                                int num6 = (ShopSettings.GetValue("MyCommentSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyCommentSorce"));
                                                shopNum1_Member_Action.UpdateMemberScore(text13, num5, num6);
                                                if (ShopSettings.GetValue("ShipmentOKIsEmail") == "1")
                                                {
                                                    this.IsEmail("ShipmentOKIsEmail", text9);
                                                }
                                                if (ShopSettings.GetValue("ShipmentOKIsMMS") == "1")
                                                {
                                                    this.IsMMS("ShipmentOKIsMMS", text9);
                                                }
                                            }
                                        }
                                        base.Response.Write("success");
                                    }
                                    else
                                    {
                                        base.Response.Write("success");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    base.Response.Write("fail");
                }
            }
            else
            {
                base.Response.Write("无通知参数");
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

        protected void IsMMS(string strflag, string strGuId)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(strGuId);
            IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
            if (orderInfoByGuid.Rows[0]["mobile"] != null && !(orderInfoByGuid.Rows[0]["mobile"].ToString() == ""))
            {
                string text = orderInfoByGuid.Rows[0]["mobile"].ToString();
                string value = ShopSettings.GetValue("Name");
                UpdateOrderStute updateOrderStute = new UpdateOrderStute();
                updateOrderStute.Name=orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                updateOrderStute.OrderNumber=orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                updateOrderStute.OrderStatus=this.OrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
                updateOrderStute.UpdateTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                updateOrderStute.SysSendTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                updateOrderStute.ShopName=value;
                string text2 = string.Empty;
                string text3;
                if (strflag == "CancelOrderIsMMS")
                {
                    text3 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                }
                else
                {
                    text3 = "204e827c-a610-4212-836e-709cd59cba83";
                }
                ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
                string mMsTitle = string.Empty;
                if (editInfo.Rows.Count > 0)
                {
                    text2 = editInfo.Rows[0]["Remark"].ToString();
                    mMsTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text2 = text2.Replace("{$Name}", updateOrderStute.Name);
                text2 = text2.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
                text2 = text2.Replace("{$ShopName}", updateOrderStute.ShopName);
                text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                text2 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text2));
                string empty = string.Empty;
                SMS sMS = new SMS();
                sMS.Send(text.Trim(), text2 + "【唐江宝宝】", out empty);
                if (empty.IndexOf("发送成功") != -1)
                {
                    ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(updateOrderStute.Name, text.Trim(), text2, mMsTitle, 2, text3);
                    shopNum1_MMS_Action.AddMMSGroupSend(shopNum1_MMSGroupSend);
                }
                else
                {
                    ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(updateOrderStute.Name, text.Trim(), text2, mMsTitle, 0, text3);
                    shopNum1_MMS_Action.AddMMSGroupSend(shopNum1_MMSGroupSend);
                }
            }
        }

        protected void IsEmail(string strflag, string strGuID)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(strGuID);
            if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
            {
                string text = orderInfoByGuid.Rows[0]["Email"].ToString();
                string value = ShopSettings.GetValue("Name");
                UpdateOrderStute updateOrderStute = new UpdateOrderStute();
                string text2;
                updateOrderStute.Name=text2 = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                updateOrderStute.OrderNumber=orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                updateOrderStute.OrderStatus=this.OrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
                updateOrderStute.UpdateTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                updateOrderStute.SysSendTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                updateOrderStute.ShopName=value;
                string text3 = string.Empty;
                string text4 = string.Empty;
                string text5;
                if (strflag == "CancelOrderIsEmail")
                {
                    text5 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                }
                else
                {
                    text5 = "204e827c-a610-4212-836e-709cd59cba83";
                }
                ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text5 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text3 = editInfo.Rows[0]["Remark"].ToString();
                    text4 = editInfo.Rows[0]["Title"].ToString();
                }
                text3 = text3.Replace("{$Name}", updateOrderStute.Name);
                text3 = text3.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
                text3 = text3.Replace("{$ShopName}", updateOrderStute.ShopName);
                text3 = text3.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                string text6 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text3));
                SendEmail sendEmail = new SendEmail();
                sendEmail.Emails(text, text2, text4, text5, text6);
            }
        }
        
        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle, int state, string mmsGuid)
        {
            ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = new ShopNum1_MMSGroupSend();
            
            shopNum1_MMSGroupSend.Guid=Guid.NewGuid();
            shopNum1_MMSGroupSend.MMSTitle=MMsTitle;
            shopNum1_MMSGroupSend.CreateTime=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_MMSGroupSend.MMSGuid=new Guid(mmsGuid);
            shopNum1_MMSGroupSend.SendObjectMMS=strContent;
            shopNum1_MMSGroupSend.SendObject=memLoginID + "-" + mobile;
            shopNum1_MMSGroupSend.State=state;
            
            return shopNum1_MMSGroupSend;
        }

        public string OrderStatus(object object_0)
        {
            string text = object_0.ToString();
            string text2 = text;
            string result;
            switch (text2)
            {
                case "0":
                    result = "等待买家付款";
                    return result;
                case "1":
                    result = "等待卖家发货";
                    return result;
                case "2":
                    result = "等待买家确认收货";
                    return result;
                case "3":
                    result = "交易成功";
                    return result;
                case "4":
                    result = "系统关闭订单";
                    return result;
                case "5":
                    result = "卖家关闭订单";
                    return result;
                case "6":
                    result = "买家关闭订单";
                    return result;
            }
            result = "非法状态";
            return result;
        }

        public ArrayList GetRequestPost()
        {
            ArrayList arrayList = new ArrayList();
            NameValueCollection form = base.Request.Form;
            string[] allKeys = form.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                arrayList.Add(allKeys[i] + "=" + base.Request.Form[allKeys[i]]);
            }
            return arrayList;
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

    }
}