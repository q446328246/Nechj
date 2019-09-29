using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class alipay1_receive : Page, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList requestGet = this.GetRequestGet();
            
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
            
            if (requestGet.Count > 0)
            {
                AlipayNotify alipayNotify = new AlipayNotify(requestGet, base.Request.QueryString["notify_id"], text, text2, text3, text4, text5);
                string responseTxt = alipayNotify.ResponseTxt;
                string a = base.Request.QueryString["sign"];
                string mysign = alipayNotify.Mysign;
                if (responseTxt == "true" && a == mysign)
                {
                    string text6 = base.Request.QueryString["trade_no"];
                    string text7 = base.Request.QueryString["out_trade_no"];
                    string text8 = base.Request.QueryString["price"];
                    string text9 = base.Request.QueryString["subject"];
                    string text10 = base.Request.QueryString["body"];
                    string text11 = base.Request.QueryString["buyer_email"];
                    string text12 = base.Request.QueryString["receive_name"];
                    string text13 = base.Request.QueryString["receive_address"];
                    string text14 = base.Request.QueryString["receive_zip"];
                    string text15 = base.Request.QueryString["receive_phone"];
                    string text16 = base.Request.QueryString["receive_mobile"];
                    string text17 = base.Request.QueryString["trade_status"];
                    this.lbTrade_no.Text = text6;
                    this.lbOut_trade_no.Text = text7;
                    this.lbTotal_fee.Text = text8;
                    this.lbSubject.Text = text9;
                    this.lbBody.Text = text10;
                    this.lbBuyer_email.Text = text11;
                    this.LbName.Text = text12;
                    this.LbAddress.Text = text13;
                    this.LbZip.Text = text14;
                    this.LbPhone.Text = text15;
                    this.LbMobile.Text = text16;
                    this.lbTrade_status.Text = text17;
                    this.lbVerify.Text = "验证成功";
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

                    //交易状态。
                    //可选值: 
                    //* TRADE_NO_CREATE_PAY(没有创建支付宝交易) 
                    //* WAIT_BUYER_PAY(等待买家付款) 
                    //* SELLER_CONSIGNED_PART(卖家部分发货) 
                    //* WAIT_SELLER_SEND_GOODS(等待卖家发货,即:买家已付款) 
                    //* WAIT_BUYER_CONFIRM_GOODS(等待买家确认收货,即:卖家已发货) 
                    //* TRADE_BUYER_SIGNED(买家已签收,货到付款专用) 
                    //* TRADE_FINISHED(交易成功) 
                    //* TRADE_CLOSED(付款以后用户退款成功，交易自动关闭) 
                    //* TRADE_CLOSED_BY_TAOBAO(付款以前，卖家或买家主动关闭交易)

                    if (!(base.Request.Form["trade_status"] == "WAIT_BUYER_PAY")) //等待买家付款
                    {
                        if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")//等待卖家发货,即:买家已付款
                        {
                            if (base.Request.QueryString["body"] == "Recharge")
                            {
                                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                                string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                                
                                //充值
                                this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")), "支付宝担保交易会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                                
                                //已完成
                                shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, ShopNum1.Common.Common.ReqStr("subject"));
                                
                                base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
                            }
                            else
                            {
                                string text18 = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + text7 + "'";
                                DataTable dataTable = DatabaseExcetue.ReturnDataTable(text18);
                                if (dataTable.Rows.Count > 0)
                                {
                                    string text19 = dataTable.Rows[0]["MemLoginID"].ToString();
                                    string text20 = dataTable.Rows[0]["Guid"].ToString();
                                    string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                    dataTable.Rows[0]["OrderNumber"].ToString();
                                    string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                                    string text21 = dataTable.Rows[0]["PaymentStatus"].ToString();
                                    string a3 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                                    if (Convert.ToInt32(text21) < 1)
                                    {
                                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text9, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text8), Convert.ToDecimal(value), text7);
                                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                                        shopNum1_OrderProduct_Action.UpdateStock(text20);
                                        if (this.CheckMember(text19) == 1)
                                        {
                                            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                            shopNum1_Member_Action.UpdateCostMoney(text19, Convert.ToDecimal(text8));
                                        }
                                        string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                                        this.AdvancePaymentModifyLog(3, Convert.ToDecimal(nameById), Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")), "支付宝担保交易会员购买商品", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                                        this.OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", text20);
                                    }
                                }
                                base.Response.Redirect("/main/Member/m_index.aspx");
                            }
                        }
                        else
                        {
                            if (!(base.Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")) //等待买家确认收货,即:卖家已发货
                            {
                                if (base.Request.Form["trade_status"] == "TRADE_FINISHED") //交易成功
                                {
                                    string text18 = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + text7 + "'";
                                    DataTable dataTable = DatabaseExcetue.ReturnDataTable(text18);
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        string text19 = dataTable.Rows[0]["MemLoginID"].ToString();
                                        string text20 = dataTable.Rows[0]["Guid"].ToString();
                                        string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                        dataTable.Rows[0]["OrderNumber"].ToString();
                                        string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                                        string text21 = dataTable.Rows[0]["PaymentStatus"].ToString();
                                        string a3 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                                        if (!(a2 == "3") || !(text21 == "1") || !(a3 == "2"))
                                        {
                                            shopNum1_OrderInfo_Action.SetShipmentStatus2(text20, 3, 1, 2);
                                        }
                                    }
                                }
                                else
                                {
                                    base.Response.Write("trade_status=" + base.Request.QueryString["trade_status"]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.lbVerify.Text = "验证失败";
                }
            }
            else
            {
                this.lbVerify.Text = "无返回参数";
            }
        }
        
        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId)
        {
            if (base.Request.QueryString["out_trade_no"] != null)
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

        public ArrayList GetRequestGet()
        {
            ArrayList arrayList = new ArrayList();
            NameValueCollection queryString = base.Request.QueryString;
            string[] allKeys = queryString.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                arrayList.Add(allKeys[i] + "=" + base.Request.QueryString[allKeys[i]]);
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