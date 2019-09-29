using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class Alipay2return_url : Page, IRequiresSessionState
    {
        
        public bool IsDoMain;
        public string AgentHost = string.Empty;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList requestGet = this.GetRequestGet();
            string text = string.Empty;
            string text2 = string.Empty;
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay2.aspx");
            if (paymentKey.Rows.Count > 0)
            {
                text = paymentKey.Rows[0]["MerchantCode"].ToString();
                text2 = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            string text3 = "utf-8";
            string text4 = "MD5";
            string text5 = "http";
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
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text7);
                    int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
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
                    if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS" || base.Request.QueryString["trade_status"] == "TRADE_FINISHED")
                    {
                        if (num < 1)
                        {
                        }
                        dataTable.Rows[0]["MemLoginID"].ToString();
                        string text18 = dataTable.Rows[0]["Guid"].ToString();
                        string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                        dataTable.Rows[0]["OrderNumber"].ToString();
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text18, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text8), Convert.ToDecimal(value));
                        this.Page.Response.Redirect("~/index.aspx?MemberUrl=" + HttpUtility.UrlEncode("OrderDetail.aspx?guid=" + text18));
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