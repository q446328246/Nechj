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
    public partial class alitwo_receive : Page, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList requestPost = this.GetRequestPost();
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
            if (requestPost.Count > 0)
            {
                AlipayNotify alipayNotify = new AlipayNotify(requestPost, base.Request.QueryString["notify_id"], text, text2, text3, text4, text5);
                string responseTxt = alipayNotify.ResponseTxt;
                string a = base.Request.QueryString["sign"];
                string mysign = alipayNotify.Mysign;
                if (responseTxt == "true" && a == mysign)
                {
                    string arg_124_0 = base.Request.QueryString["trade_no"];
                    string text6 = base.Request.QueryString["out_trade_no"];
                    string value = base.Request.QueryString["price"];
                    string arg_168_0 = base.Request.QueryString["subject"];
                    string arg_17E_0 = base.Request.QueryString["body"];
                    string arg_194_0 = base.Request.QueryString["buyer_email"];
                    string arg_1AA_0 = base.Request.QueryString["trade_status"];
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text6);
                    int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
                    if (base.Request.QueryString["trade_status"] == "WAIT_BUYER_PAY")
                    {
                        if (num == 0)
                        {
                        }
                        base.Response.Redirect(base.Request.Url.ToString().Replace("alitwo_receive.aspx", "alitwo_show.aspx"));
                    }
                    else
                    {
                        if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
                        {
                            if (num == 1 || num == 0)
                            {
                            }
                            string text7 = dataTable.Rows[0]["MemLoginID"].ToString();
                            dataTable.Rows[0]["Guid"].ToString();
                            string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                            dataTable.Rows[0]["OrderNumber"].ToString();
                            shopNum1_OrderInfo_Action.SetPaymentStatus2(text6, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
                            if (this.CheckMember(text7) == 1)
                            {
                                ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                shopNum1_Member_Action.UpdateCostMoney(text7, Convert.ToDecimal(value));
                            }
                            base.Response.Redirect(base.Request.Url.ToString().Replace("alitwo_receive.aspx", "alitwo_show.aspx"));
                        }
                        else
                        {
                            if (base.Request.QueryString["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
                            {
                                if (num == 2)
                                {
                                    string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                    dataTable.Rows[0]["Guid"].ToString();
                                    shopNum1_OrderInfo_Action.SetPaymentStatus2(text6, 2, 2, 1, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
                                }
                                base.Response.Redirect(base.Request.Url.ToString().Replace("alitwo_receive.aspx", "alitwo_show.aspx"));
                            }
                            else
                            {
                                if (base.Request.QueryString["trade_status"] == "TRADE_FINISHED")
                                {
                                    if (num == 3 || num < 2)
                                    {
                                    }
                                    string text7 = dataTable.Rows[0]["MemLoginID"].ToString();
                                    dataTable.Rows[0]["Guid"].ToString();
                                    string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                    dataTable.Rows[0]["OrderNumber"].ToString();
                                    shopNum1_OrderInfo_Action.SetPaymentStatus2(text6, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
                                    if (this.CheckMember(text7) == 1)
                                    {
                                        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                        shopNum1_Member_Action.UpdateCostMoney(text7, Convert.ToDecimal(value));
                                    }
                                }
                                else
                                {
                                    base.Response.Redirect(base.Request.Url.ToString().Replace("alitwo_receive.aspx", "alitwo_show.aspx"));
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
        public ArrayList GetRequestPost()
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