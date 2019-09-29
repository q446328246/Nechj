using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class return_url : Page, IRequiresSessionState
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
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text7);
                    string text18 = dataTable.Rows[0]["MemLoginID"].ToString();
                    string text19 = dataTable.Rows[0]["Guid"].ToString();
                    string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                    dataTable.Rows[0]["OrderNumber"].ToString();
                    string a2 = dataTable.Rows[0]["OderStatus"].ToString();
                    string a3 = dataTable.Rows[0]["PaymentStatus"].ToString();
                    string a4 = dataTable.Rows[0]["ShipmentStatus"].ToString();
                    if (base.Request.Form["trade_status"] == "WAIT_BUYER_PAY")
                    {
                        if (!(a2 == "0") || !(a4 == "0") || !(a3 == "0"))
                        {
                            shopNum1_OrderInfo_Action.SetWaitBuyerPay("0", "0", "0", text19);
                        }
                    }
                    else
                    {
                        if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
                        {
                            if (!(a2 == "1") || !(a3 == "1") || !(a4 == "0"))
                            {
                                shopNum1_OrderInfo_Action.SetPaymentStatus2(text19, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text8), Convert.ToDecimal(value));
                                if (this.CheckMember(text18) == 1)
                                {
                                    ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                    shopNum1_Member_Action.UpdateCostMoney(text18, Convert.ToDecimal(text8));
                                }
                            }
                        }
                        else
                        {
                            if (base.Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
                            {
                                if (!(a2 == "2") || !(a3 == "1") || !(a4 == "1"))
                                {
                                    Random random = new Random();
                                    shopNum1_OrderInfo_Action.SetShipmentStatus1(text19, 2, 1, 1, DateTime.Now, "XT_" + DateTime.Now.ToLongTimeString().Replace("-", "") + random.Next(0, 1000));
                                }
                            }
                            else
                            {
                                if (base.Request.Form["trade_status"] == "TRADE_FINISHED")
                                {
                                    if (!(a2 == "3") || !(a3 == "1") || !(a4 == "2"))
                                    {
                                        shopNum1_OrderInfo_Action.SetShipmentStatus2(text19, 3, 1, 2);
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