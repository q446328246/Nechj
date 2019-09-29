using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class PreDeposits : BaseWebControl
    {
        private Button ButtonPay;
        private Label LabelAdvancePayment;
        private Label LabelShouldPay;
        private TextBox TextBoxOrderID;
        private TextBox TextBoxPayPassword;
        private byte byte_0;
        private DataSet dataSet_0;
        private DataSet dataSet_1;
        private DataTable dt;
        private HtmlGenericControl noPay;
        private string string_0;
        private string skinFilename = "PreDeposits.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private TextBox txtMobileCode;

        public PreDeposits()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                string_2 = httpCookie.Values["MemLoginID"];
                var payUrlOperate = new PayUrlOperate();
                SortedDictionary<string, string> requestGet = GetRequestGet();
                if (requestGet.Count != 8)
                {
                    byte_0 = 1;
                }
                else
                {
                    if (Page.Request.QueryString["sign"] != null)
                    {
                        if (!payUrlOperate.CheckSign(requestGet, Page.Request.QueryString["sign"]))
                        {
                            byte_0 = 2;
                        }
                        else
                        {
                            if (Page.Request.QueryString["timetemp"] != null)
                            {
                                long num = Convert.ToInt64(Page.Request.QueryString["timetemp"]);
                                if (DateTime.Now.Ticks - num > 0L)
                                {
                                    byte_0 = 3;
                                    return;
                                }
                                string text = Page.Request.QueryString["memlogid"].Trim();
                                if (string_2.Trim().ToLower() != text.Trim().ToLower())
                                {
                                    byte_0 = 4;
                                    return;
                                }
                                noPay = (HtmlGenericControl) skin.FindControl("noPay");
                                txtMobileCode = (TextBox) skin.FindControl("txtMobileCode");
                                TextBoxPayPassword = (TextBox) skin.FindControl("TextBoxPayPassword");
                                LabelShouldPay = (Label) skin.FindControl("LabelShouldPay");
                                LabelAdvancePayment = (Label) skin.FindControl("LabelAdvancePayment");
                                ButtonPay = (Button) skin.FindControl("ButtonPay");
                                TextBoxOrderID = (TextBox) skin.FindControl("TextBoxOrderID");
                                ButtonPay.Click += ButtonPay_Click;
                                if (Page.Request.QueryString["TradeID"] == null ||
                                    Page.Request.Cookies["MemberLoginCookie"] == null)
                                {
                                    Page.Response.Redirect("http://" + ShopSettings.siteDomain);
                                }
                                else
                                {
                                    method_0();
                                }
                                string nameById = Common.Common.GetNameById("PayPwd", "ShopNum1_Member",
                                    "    AND  MemLoginID='" + string_2 + "'");
                                if (string.IsNullOrEmpty(nameById))
                                {
                                    noPay.Visible = true;
                                }
                                else
                                {
                                    noPay.Visible = false;
                                }
                                try
                                {
                                    decimal num2 = Convert.ToDecimal(LabelShouldPay.Text);
                                    if (num2.ToString() == "0.00" || num2.ToString() == "0" || num2.ToString() == "")
                                    {
                                        Page.Response.Redirect("/Main/Member/M_Index.aspx");
                                        return;
                                    }
                                    return;
                                }
                                catch (Exception)
                                {
                                    Page.Response.Redirect("/Main/Member/M_Index.aspx");
                                    return;
                                }
                            }
                            byte_0 = 3;
                        }
                    }
                    else
                    {
                        byte_0 = 2;
                    }
                }
            }
            else
            {
                GetUrl.RedirectLogin();
            }
        }

        protected void ButtonPay_Click(object sender, EventArgs e)
        {
            var shopNum1_Member_Action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if (ShopSettings.GetValue("IsMobileCheckPay") == "1")
            {
                int num = 0;
                try
                {
                    string nameById = Common.Common.GetNameById("mobile", "shopnum1_member",
                        " and memloginId='" + string_2 + "' and mobile!=''");
                    var shopNum1_MemberActivate_Action =
                        (ShopNum1_MemberActivate_Action) LogicFactory.CreateShopNum1_MemberActivate_Action();
                    if (shopNum1_MemberActivate_Action.CheckMobileCode(txtMobileCode.Text, nameById, "2") != "0")
                    {
                        num = 1;
                    }
                }
                catch
                {
                }
                if (num != 1)
                {
                    MessageBox.Show("手机验证码不正确！");
                    return;
                }
            }
            string payPwd = shopNum1_Member_Action.GetPayPwd(string_2);
            if (payPwd == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                    "<script>alert(\"请先设置交易密码才能进行支付交易！\");location.href='http://" + ShopSettings.siteDomain +
                    "/Main/Account/a_index.aspx?toaurl=A_PwdSer.aspx';</script>");
            }
            else
            {
                string md5SecondHash = Encryption.GetMd5SecondHash(TextBoxPayPassword.Text.Trim());
                if (payPwd != md5SecondHash)
                {
                    MessageBox.Show("您输入的交易密码不正确！");
                }
                else
                {
                    var arg_122_0 =
                        (ShopNum1_OrderOperateLog_Action) LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    decimal num2 = Convert.ToDecimal(LabelShouldPay.Text);
                    if (num2.ToString() == "0.00" || num2.ToString() == "0")
                    {
                        Page.Response.Redirect("/Main/Member/M_Index.aspx");
                    }
                    else
                    {
                        decimal num3 = Convert.ToDecimal(LabelAdvancePayment.Text);
                        string a = Page.Request.QueryString["type"];
                        if (num2 > num3)
                        {
                            MessageBox.Show("您当前帐户上面的金额不足，无法支付!");
                            TextBoxPayPassword.Text = "";
                        }
                        else
                        {
                            if (a == "product")
                            {
                                string text = Page.Request.QueryString["TradeID"];
                                string text2 = Page.Request.QueryString["IsAllPay"];
                                int num4 = shopNum1_Member_Action.PreDepositsPay(string_2, num2, num3, text, text2);
                                if (num4 > 0)
                                {
                                    string_5 = "金币（BV）支付";
                                    var shopNum1_OrderInfo_Action =
                                        (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                                    DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(text);
                                    if (text2 == "1")
                                    {
                                        if (orderGuIdByTradeId.Rows.Count > 0)
                                        {
                                            MoneyModifyLog(string_5);
                                            OrderOperateLog(string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["feeType"].ToString());
                                            for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                                            {
                                                var shopNum1_OrderProduct_Action =
                                                    (ShopNum1_OrderProduct_Action)
                                                        LogicFactory.CreateShopNum1_OrderProduct_Action();
                                                shopNum1_OrderProduct_Action.UpdateStock(
                                                    orderGuIdByTradeId.Rows[i]["guid"].ToString());
                                                if (orderGuIdByTradeId.Rows[i]["FeeType"].ToString() == "2")
                                                {
                                                    IsMMS(orderGuIdByTradeId.Rows[i]["ordernumber"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["IdentifyCode"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["Mobile"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["ProductName"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["BuyNumber"].ToString());
                                                }
                                                if (ShopSettings.GetValue("PayIsMMS") == "1")
                                                {
                                                    method_3(orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["ordernumber"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(),
                                                        orderGuIdByTradeId.Rows[i]["Mobile"].ToString());
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MoneyModifyLog(string_5);
                                        OrderOperateLog(string_5, string_6, string_7);
                                        var shopNum1_OrderProduct_Action =
                                            (ShopNum1_OrderProduct_Action)
                                                LogicFactory.CreateShopNum1_OrderProduct_Action();
                                        shopNum1_OrderProduct_Action.UpdateStock(string_6);
                                        if (orderGuIdByTradeId.Rows[0]["FeeType"].ToString() == "2")
                                        {
                                            IsMMS(orderGuIdByTradeId.Rows[0]["ordernumber"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["IdentifyCode"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["Mobile"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["ProductName"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["BuyNumber"].ToString());
                                        }
                                        if (ShopSettings.GetValue("PayIsMMS") == "1")
                                        {
                                            method_3(orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["ordernumber"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(),
                                                orderGuIdByTradeId.Rows[0]["Mobile"].ToString());
                                        }
                                    }
                                    if (ShopSettings.GetValue("PayIsEmail") == "1")
                                    {
                                        IsEmail();
                                    }
                                    Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                                        "<script>alert(\"您所买的商品,已经成功付款!您可以通知卖家及时发货\");location.href='http://" +
                                        ShopSettings.siteDomain +
                                        "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");
                                }
                                else
                                {
                                    MessageBox.Show("支付失败");
                                }
                            }
                            else
                            {
                                if (a == "categoryad")
                                {
                                    string tradeID = Page.Request.QueryString["TradeID"];
                                    int num4 = shopNum1_Member_Action.CategoryAdPay(string_2, num2, num3, tradeID);
                                    if (num4 > 0)
                                    {
                                        MoneyModifyLog("购买广告");
                                        Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                                            "<script>alert(\"支付成功\");location.href='http://" + ShopSettings.siteDomain +
                                            "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                                            "<script>alert(\"支付失败\");window.close()</script>");
                                    }
                                }
                                else
                                {
                                    if (a == "shoprank" || a == "shopensure")
                                    {
                                        string text = Page.Request.QueryString["TradeID"];
                                        int num4 = shopNum1_Member_Action.OtherOrderIDPay(string_2, num2, num3, text);
                                        if (num4 > 0)
                                        {
                                            int num5 = 0;
                                            if (string_0 == "1")
                                            {
                                                var shop_ShopApplyRank_Action =
                                                    (Shop_ShopApplyRank_Action)
                                                        ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
                                                num5 = shop_ShopApplyRank_Action.UpdataShopRankPayStatusByID(string_4);
                                                string_5 = "购买店铺等级";
                                            }
                                            else
                                            {
                                                if (string_0 == "2")
                                                {
                                                    var shop_Ensure_Action =
                                                        (Shop_Ensure_Action)
                                                            ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                                                    num5 = shop_Ensure_Action.UpdataEnsurePayStatusByGuid(string_4);
                                                    string_5 = "购买店铺担保";
                                                }
                                            }
                                            if (num5 > 0)
                                            {
                                                MoneyModifyLog(string_5);
                                                Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                                                    "<script>alert(\"支付成功\");location.href='http://" +
                                                    ShopSettings.siteDomain +
                                                    "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");
                                            }
                                            else
                                            {
                                                Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                                                    "<script>alert(\"支付失败\");window.close()</script>");
                                            }
                                        }
                                        else
                                        {
                                            Page.ClientScript.RegisterStartupScript(this.GetType(),"pop",
                                                "<script>alert(\"支付失败\");window.close()</script>");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void IsMMS(string OrderNumber, string strCode, string memloginID, string string_8,
            string strProductName, string strBuyNum)
        {
            if (!(string_8.Trim() == "") && !(strCode == "0" | strCode == ""))
            {
                var orderInfo = new OrderInfo();
                orderInfo.Name = memloginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = ShopSettings.GetValue("Name");
                string text = "73370552-efdb-47ec-9e0f-f813261375b8";
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
                if (editInfo != null && editInfo.Rows.Count > 0)
                {
                    string text2 = editInfo.Rows[0]["Remark"].ToString();
                    text2 = text2.Replace("{$Name}", orderInfo.Name);
                    text2 = text2.Replace("{$IdentifyCode}", strCode);
                    text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
                    text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                    text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    text2 = text2.Replace("{$ProductName}", strProductName);
                    text2 = text2.Replace("{$BuyNum}", strBuyNum);
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    var sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                    sMS.Send(string_8.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), mMsTitle, text2, 2,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), mMsTitle, text2, 0,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected void MoneyModifyLog(string memo)
        {
            var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.OperateType = 3;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(LabelAdvancePayment.Text);
            shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(LabelShouldPay.Text);
            shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(LabelAdvancePayment.Text) -
                                                                Convert.ToDecimal(LabelShouldPay.Text);
            shopNum1_AdvancePaymentModifyLog.Date =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.Memo = memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = string_2;
            shopNum1_AdvancePaymentModifyLog.CreateUser = string_2;
            shopNum1_AdvancePaymentModifyLog.CreateTime =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;
            var shopNum1_AdvancePaymentModifyLog_Action =
                (ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
        }

        protected void OrderOperateLog(string memo, string strOrdGuId, string strFeeType)
        {
            if (!string.IsNullOrEmpty(strOrdGuId))
            {
                var shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
                shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
                shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(strOrdGuId);
                shopNum1_OrderOperateLog.OderStatus = 1;
                shopNum1_OrderOperateLog.ShipmentStatus = 0;
                shopNum1_OrderOperateLog.PaymentStatus = 1;
                shopNum1_OrderOperateLog.CurrentStateMsg = "已付款";
                if (strFeeType.Equals("2"))
                {
                    shopNum1_OrderOperateLog.NextStateMsg = "等待买家消费";
                }
                else
                {
                    shopNum1_OrderOperateLog.NextStateMsg = "等待发货";
                }
                shopNum1_OrderOperateLog.Memo = memo;
                shopNum1_OrderOperateLog.OperateDateTime =
                    Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_OrderOperateLog.IsDeleted = 0;
                shopNum1_OrderOperateLog.CreateUser = string_2;
                var shopNum1_OrderOperateLog_Action =
                    (ShopNum1_OrderOperateLog_Action) LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
            }
        }

        protected void method_0()
        {
            string text = Page.Request.QueryString["TradeID"];
            TextBoxOrderID.Text = text;
            IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
            object obj = Page.Request.QueryString["type"];
            if (obj.ToString() == "product")
            {
                string a = (Page.Request.QueryString["IsAllPay"] == null) ? "-1" : Page.Request.QueryString["IsAllPay"];
                if (a == "1")
                {
                    dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(text, string_2);
                    if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                        !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
                    {
                        LabelShouldPay.Text = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                        string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                        string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                        LabelAdvancePayment.Text = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                        string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();
                    }
                }
                else
                {
                    if (a == "0")
                    {
                        dataSet_0 = shopNum1_OrderInfo_Action.SingleTradePayMent(text, string_2);
                        if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                            !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
                        {
                            LabelShouldPay.Text = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment.Text = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();
                        }
                    }
                }
            }
            else
            {
                if (obj.ToString() == "shoprank" || obj.ToString() == "shopensure")
                {
                    dt = shopNum1_OrderInfo_Action.GetOtherOrderInfoByTradeID(text, string_2);
                    LabelShouldPay.Text = dt.Rows[0]["TotalPrice"].ToString();
                    LabelAdvancePayment.Text = dt.Rows[0]["AdvancePayment"].ToString();
                    string_0 = dt.Rows[0]["Type"].ToString();
                    string_4 = dt.Rows[0]["RelevanceID"].ToString();
                }
                else
                {
                    if (obj.ToString() == "categoryad")
                    {
                        var shopNum1_CategoryAdPayMent_Action =
                            (ShopNum1_CategoryAdPayMent_Action) LogicFactory.CreateShopNum1_CategoryAdPayMent_Action();
                        dataSet_1 = shopNum1_CategoryAdPayMent_Action.PayCategoryAdPrice(text, string_2);
                        if (dataSet_1 == null || dataSet_1.Tables.Count != 2 ||
                            dataSet_1.Tables[0].Rows[0][0].ToString() == "-1")
                        {
                            byte_0 = 2;
                        }
                        else
                        {
                            LabelShouldPay.Text = dataSet_1.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                            LabelAdvancePayment.Text = dataSet_1.Tables[1].Rows[0]["AdvancePayment"].ToString();
                        }
                    }
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (byte_0 == 0)
            {
                base.Render(writer);
            }
            else
            {
                if (byte_0 == 1)
                {
                    writer.Write("<span style=\"color:red\">支付参数不对!</span><span class='gohome'><a href=\"http://" +
                                 ShopSettings.siteDomain + "\">返回首页</a></span>");
                }
                else
                {
                    if (byte_0 == 2)
                    {
                        writer.Write("<span style=\"color:red\">错误的签名!</span><span class='gohome'><a href=\"http://" +
                                     ShopSettings.siteDomain + "\">返回首页</a></span>");
                    }
                    else
                    {
                        if (byte_0 == 3)
                        {
                            writer.Write(
                                "<span style=\"color:red\">支付已经过期请重新点击支付!</span><span class='gohome'><a href=\"http://" +
                                ShopSettings.siteDomain + "\">返回首页</a></span>");
                        }
                        else
                        {
                            writer.Write(
                                "<span style=\"color:red\">非法的支付请求!</span><span class='gohome'><a href=\"http://" +
                                ShopSettings.siteDomain + "\">返回首页</a></span>");
                        }
                    }
                }
            }
        }

        public SortedDictionary<string, string> GetRequestGet()
        {
            var sortedDictionary = new SortedDictionary<string, string>();
            NameValueCollection queryString = HttpContext.Current.Request.QueryString;
            string[] allKeys = queryString.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                if (HttpContext.Current.Request.QueryString[allKeys[i]] != null)
                {
                    sortedDictionary.Add(allKeys[i], HttpContext.Current.Request.QueryString[allKeys[i]]);
                }
            }
            return sortedDictionary;
        }

        protected void IsMMS()
        {
            try
            {
                string guid = string.Empty;
                IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
                string text = Page.Request.QueryString["TradeID"];
                string a = Page.Request.QueryString["IsAllPay"];
                DataTable dataTable = null;
                if (a == "1")
                {
                    dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByTradeIDAndMemloginid(text, string_2);
                }
                else
                {
                    if (a == "0")
                    {
                        dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(text, string_2);
                    }
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    guid = dataTable.Rows[0]["guid"].ToString();
                    var shopNum1_OrderInfo_Action2 =
                        (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable orderInfoByGuid = shopNum1_OrderInfo_Action2.GetOrderInfoByGuid(guid);
                    string text2 = string.Empty;
                    if (orderInfoByGuid.Rows[0]["Tel"].ToString().Trim() == "")
                    {
                        if (!(orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim() != ""))
                        {
                            return;
                        }
                        text2 = orderInfoByGuid.Rows[0]["Mobile"].ToString();
                    }
                    else
                    {
                        text2 = orderInfoByGuid.Rows[0]["Tel"].ToString();
                    }
                    var updateOrderStute = new UpdateOrderStute();
                    updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                    updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                    updateOrderStute.ShopName = ShopSettings.GetValue("Name");
                    updateOrderStute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    updateOrderStute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string text3 = "204e827c-a610-4212-836e-709cd59cba83";
                    IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                    DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text3, 0);
                    string text4 = string.Empty;
                    string mMsTitle = string.Empty;
                    if (editInfo.Rows.Count > 0)
                    {
                        text4 = editInfo.Rows[0]["Remark"].ToString();
                        mMsTitle = editInfo.Rows[0]["Title"].ToString();
                        text4 = text4.Replace("{$Name}", updateOrderStute.Name);
                        text4 = text4.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
                        text4 = text4.Replace("{$ShopName}", updateOrderStute.ShopName);
                        text4 = text4.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    var sMS = new SMS();
                    string text5 = "";
                    text4 = updateOrderStute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(text4));
                    sMS.Send(text2.Trim(), text4 + "【唐江宝宝】", out text5);
                    if (text5.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(),
                            text2, mMsTitle, text4, 2, text3);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(),
                            text2, mMsTitle, text4, 0, text3);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool method_1(string string_8)
        {
            bool result = false;
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(string_8);
            if (dataTable.Rows.Count > 0 && string.Format("{0}", dataTable.Rows[0]["FeeType"]).Equals("1"))
            {
                string string_9 = string.Format("{0}", dataTable.Rows[0]["Name"]);
                string string_10 = string.Format("{0}", dataTable.Rows[0]["IdentifyCode"]);
                string string_11 = string.Format("{0}", dataTable.Rows[0]["Mobile"]);
                string string_12 = string.Format("{0}", dataTable.Rows[0]["MemLoginID"]);
                string string_13 = string.Format("{0}", dataTable.Rows[0]["ProductName"]);
                string string_14 = string.Format("{0}", dataTable.Rows[0]["BuyNumber"]);
                method_2(string_9, string_8, string_10, string_12, string_11, string_13, string_14);
                result = true;
            }
            return result;
        }

        protected void method_2(string string_8, string string_9, string string_10, string string_11, string string_12,
            string string_13, string string_14)
        {
            if (!string.IsNullOrEmpty(string_12))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("73370552-EFDB-47EC-9E0F-F813261375B8", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", string_8);
                    text = text.Replace("{$OrderNumber}", string_9);
                    text = text.Replace("{$IdentifyCode}", string_10);
                    text = text.Replace("{$ProductName}", string_13);
                    text = text.Replace("{$BuyNum}", string_14);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(string_12, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_11, string_12.Trim(), mMsTitle, text, 2,
                            "73370552-EFDB-47EC-9E0F-F813261375B8");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_11, string_12.Trim(), mMsTitle, text, 0,
                            "73370552-EFDB-47EC-9E0F-F813261375B8");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected void method_3(string string_8, string string_9, string string_10, string string_11)
        {
            if (!string.IsNullOrEmpty(string_11))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("204e827c-a610-4212-836e-709cd59cba83", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", string_8);
                    text = text.Replace("{$OrderNumber}", string_9);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(string_11, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_10, string_11.Trim(), mMsTitle, text, 2,
                            "204e827c-a610-4212-836e-709cd59cba83");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_10, string_11.Trim(), mMsTitle, text, 0,
                            "204e827c-a610-4212-836e-709cd59cba83");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, string strContent,
            int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = strContent,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }

        protected void IsEmail()
        {
            try
            {
                string guid = string.Empty;
                IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
                string text = Page.Request.QueryString["TradeID"];
                string a = Page.Request.QueryString["IsAllPay"];
                DataTable dataTable = null;
                if (a == "1")
                {
                    dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByTradeIDAndMemloginid(text, string_2);
                }
                else
                {
                    if (a == "0")
                    {
                        dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(text, string_2);
                    }
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    guid = dataTable.Rows[0]["guid"].ToString();
                    DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
                    if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
                    {
                        string email = orderInfoByGuid.Rows[0]["Email"].ToString();
                        string value = ShopSettings.GetValue("Name");
                        var updateOrderStute = new UpdateOrderStute();
                        string memLoginID = updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                        updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                        updateOrderStute.OrderStatus =
                            OrderStatus.ChangeOrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
                        updateOrderStute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        updateOrderStute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        updateOrderStute.ShopName = value;
                        string text2 = string.Empty;
                        string emailTitle = string.Empty;
                        string text3 = "204e827c-a610-4212-836e-709cd59cba83";
                        var shopNum1_Email_Action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
                        DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
                        if (editInfo.Rows.Count > 0)
                        {
                            text2 = editInfo.Rows[0]["Remark"].ToString();
                            emailTitle = editInfo.Rows[0]["Title"].ToString();
                        }
                        text2 = text2.Replace("{$Name}", updateOrderStute.Name);
                        text2 = text2.Replace("{{$OrderNumber}", updateOrderStute.OrderNumber);
                        text2 = text2.Replace("{$ShopName}", value);
                        text2 = text2.Replace("{$SendTime}",
                            DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                        string emailBody = updateOrderStute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(text2));
                        var sendEmail = new SendEmail();
                        sendEmail.Emails(email, memLoginID, emailTitle, text3, emailBody);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}