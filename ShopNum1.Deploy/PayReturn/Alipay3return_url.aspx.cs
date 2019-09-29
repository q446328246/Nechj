using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Payment;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class Alipay3return_url : Page, IRequiresSessionState
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> requestGet = this.GetRequestGet();
            string partner = string.Empty;
            string key = string.Empty;
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay3.aspx");
            if (paymentKey.Rows.Count > 0)
            {
                partner = paymentKey.Rows[0]["MerchantCode"].ToString();
                key = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            string input_charset = "utf-8";
            string sign_type = "MD5";
            string transport = "http";
            if (requestGet.Count > 0)
            {
                Alipay3Notify alipay3Notify = new Alipay3Notify(requestGet, base.Request.QueryString["notify_id"], partner, key, input_charset, sign_type, transport);
                string responseTxt = alipay3Notify.ResponseTxt;
                string a = base.Request.QueryString["sign"];
                string mysign = alipay3Notify.Mysign;
                if (responseTxt == "true" && a == mysign)
                {
                    string text = base.Request.QueryString["trade_no"];
                    string text2 = base.Request.QueryString["out_trade_no"];
                    string text3 = base.Request.QueryString["total_fee"];
                    string text4 = base.Request.QueryString["subject"];
                    string text5 = base.Request.QueryString["body"];
                    string text6 = base.Request.QueryString["buyer_email"];
                    string text7 = base.Request.QueryString["trade_status"];
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);
                    int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                    this.lbTrade_no.Text = text;
                    this.lbOut_trade_no.Text = text2;
                    this.lbTotal_fee.Text = text3;
                    this.lbSubject.Text = text4;
                    this.lbBody.Text = text5;
                    this.lbBuyer_email.Text = text6;
                    this.lbTrade_status.Text = text7;
                    this.lbVerify.Text = "验证成功";
                    if (base.Request.QueryString["trade_status"] == "TRADE_FINISHED" || base.Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        if (num < 1)
                        {
                            string text8 = dataTable.Rows[0]["MemLoginID"].ToString();
                            string text9 = dataTable.Rows[0]["Guid"].ToString();
                            string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                            dataTable.Rows[0]["OrderNumber"].ToString();
                            shopNum1_OrderInfo_Action.SetPaymentStatus2(text9, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text3), Convert.ToDecimal(value));
                            if (this.CheckMember(text8) == 1)
                            {
                                ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                shopNum1_Member_Action.UpdateCostMoney(text8, Convert.ToDecimal(text3));
                            }
                            this.Page.Response.Redirect("~/index.aspx?MemberUrl=" + HttpUtility.UrlEncode("OrderDetail.aspx?guid=" + text9));
                        }
                    }
                    else
                    {
                        base.Response.Write("trade_status=" + base.Request.QueryString["trade_status"]);
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
        public SortedDictionary<string, string> GetRequestGet()
        {
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            NameValueCollection queryString = base.Request.QueryString;
            string[] allKeys = queryString.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                sortedDictionary.Add(allKeys[i], base.Request.QueryString[allKeys[i]]);
            }
            return sortedDictionary;
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