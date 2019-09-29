using System;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.KuaiDi;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_OrderDetail : BaseMemberWebControl
    {
        public static DataTable dt_OrderInfo = null;
        public static DataTable dt_OrderOperate = null;
        public static DataTable dt_PayMent = null;
        private Label LabelInvoiceContentValue;
        private Label LabelInvoiceTitleValue;
        private Label LabelInvoiceTypeValue;
        private HtmlGenericControl LogisticInfo;
        private LinkButton btnDelay;
        private LinkButton btnUpdatePayMent;
        private LinkButton butCancelOrder;
        private LinkButton butPayMoney;
        private LinkButton butSureConfirm;
        private DataTable dt;
        private HtmlInputHidden hidBuyNum;
        private HtmlInputHidden hidCanleTime;
        private HtmlInputHidden hidDispatchPrice;
        private HtmlInputHidden hidEndTime;
        private HtmlInputHidden hidExpiresTime;
        private HtmlInputHidden hidOrderGuId;
        private HtmlInputHidden hidOrderPay;
        private HtmlInputHidden hidOrderProductId;
        private HtmlInputHidden hidOrderState;
        private HtmlInputHidden hidPayMentInfo;
        private HtmlInputHidden hidPayMentName;
        private HtmlInputHidden hidPayState;
        private HtmlInputHidden hidPaymentPrice;
        private HtmlInputHidden hidRefundType;
        private HtmlInputHidden hidRefundstatus;
        private HtmlInputHidden hidShipState;
        private HtmlInputHidden hidShopId;
        private HtmlInputHidden hidShopPrice;
        private HtmlInputHidden hidShouldPayPrice;
        private HtmlInputHidden hidTotalDays;
        private HtmlInputHidden hidlifetype;
        private Label lblAreaName;
        private Label lblBuyerMsg;
        private Label lblCancleOrder;
        private Label lblConfirmOrderTime;
        private Label lblDelay;
        private Label lblDispatch;
        private Label lblEmail;
        private Label lblLogisticsCompany;
        private Label lblMemLoginId;
        private Label lblMoible;
        private Label lblOrderDate;
        private Label lblOrderNumber;
        private Label lblOrderStateTxt;
        private Label lblPayMentTime;
        private Label lblReceiveAddress;
        private Label lblSellerMsg;
        private Label lblSendGoodsTime;
        private Label lblSetOrderTime;
        private Label lblShipmentNumber;
        private Label lblShouldPrice;
        private Label lblSureDays;
        private Label lblTrueName;
        private Label lbllogisticType;
        private string skinFilename = "M_OrderDetail.ascx";

        public M_OrderDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string strCreateTime { get; set; }

        public string strOderState { get; set; }

        public string strOrderGuId { get; set; }

        public string strOrderType { get; set; }

        public string strPayTime { get; set; }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, string strContent,
            int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = DateTime.Now,
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = strContent,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
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
            ((ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoney(advancePaymentModifyLog);
        }

        protected override void InitializeSkin(Control skin)
        {
            LogisticInfo = (HtmlGenericControl) skin.FindControl("LogisticInfo");
            LabelInvoiceTypeValue = (Label) skin.FindControl("LabelInvoiceTypeValue");
            LabelInvoiceTitleValue = (Label) skin.FindControl("LabelInvoiceTitleValue");
            LabelInvoiceContentValue = (Label) skin.FindControl("LabelInvoiceContentValue");
            lblDispatch = (Label) skin.FindControl("lblDispatch");
            lblSetOrderTime = (Label) skin.FindControl("lblSetOrderTime");
            lblPayMentTime = (Label) skin.FindControl("lblPayMentTime");
            lblSendGoodsTime = (Label) skin.FindControl("lblSendGoodsTime");
            lblConfirmOrderTime = (Label) skin.FindControl("lblConfirmOrderTime");
            lblMemLoginId = (Label) skin.FindControl("lblMemLoginId");
            lblTrueName = (Label) skin.FindControl("lblTrueName");
            lblAreaName = (Label) skin.FindControl("lblAreaName");
            lblMoible = (Label) skin.FindControl("lblMoible");
            lblEmail = (Label) skin.FindControl("lblEmail");
            lblOrderNumber = (Label) skin.FindControl("lblOrderNumber");
            lblOrderStateTxt = (Label) skin.FindControl("lblOrderStateTxt");
            lblOrderDate = (Label) skin.FindControl("lblOrderDate");
            lblReceiveAddress = (Label) skin.FindControl("lblReceiveAddress");
            lbllogisticType = (Label) skin.FindControl("lbllogisticType");
            lblLogisticsCompany = (Label) skin.FindControl("lblLogisticsCompany");
            lblShipmentNumber = (Label) skin.FindControl("lblShipmentNumber");
            lblBuyerMsg = (Label) skin.FindControl("lblBuyerMsg");
            lblSellerMsg = (Label) skin.FindControl("lblSellerMsg");
            lblSureDays = (Label) skin.FindControl("lblSureDays");
            lblShouldPrice = (Label) skin.FindControl("lblShouldPrice");
            lblDelay = (Label) skin.FindControl("lblDelay");
            lblCancleOrder = (Label) skin.FindControl("lblCancleOrder");
            hidOrderGuId = (HtmlInputHidden) skin.FindControl("hidOrderGuId");
            hidOrderState = (HtmlInputHidden) skin.FindControl("hidOrderState");
            hidOrderProductId = (HtmlInputHidden) skin.FindControl("hidOrderProductId");
            hidOrderPay = (HtmlInputHidden) skin.FindControl("hidOrderPay");
            hidPayMentInfo = (HtmlInputHidden) skin.FindControl("hidPayMentInfo");
            hidPayMentName = (HtmlInputHidden) skin.FindControl("hidPayMentName");
            hidPayState = (HtmlInputHidden) skin.FindControl("hidPayState");
            hidShipState = (HtmlInputHidden) skin.FindControl("hidShipState");
            hidRefundstatus = (HtmlInputHidden) skin.FindControl("hidRefundstatus");
            hidShouldPayPrice = (HtmlInputHidden) skin.FindControl("hidShouldPayPrice");
            hidShopId = (HtmlInputHidden) skin.FindControl("hidShopId");
            hidBuyNum = (HtmlInputHidden) skin.FindControl("hidBuyNum");
            hidDispatchPrice = (HtmlInputHidden) skin.FindControl("hidDispatchPrice");
            hidPaymentPrice = (HtmlInputHidden) skin.FindControl("hidPaymentPrice");
            hidExpiresTime = (HtmlInputHidden) skin.FindControl("hidExpiresTime");
            hidRefundType = (HtmlInputHidden) skin.FindControl("hidRefundType");
            hidlifetype = (HtmlInputHidden) skin.FindControl("hidlifetype");
            hidEndTime = (HtmlInputHidden) skin.FindControl("hidEndTime");
            hidCanleTime = (HtmlInputHidden) skin.FindControl("hidCanleTime");
            hidTotalDays = (HtmlInputHidden) skin.FindControl("hidTotalDays");
            hidShopPrice = (HtmlInputHidden) skin.FindControl("hidShopPrice");
            butSureConfirm = (LinkButton) skin.FindControl("butSureConfirm");
            butSureConfirm.Click += butSureConfirm_Click;
            btnUpdatePayMent = (LinkButton) skin.FindControl("btnUpdatePayMent");
            btnUpdatePayMent.Click += btnUpdatePayMent_Click;
            butPayMoney = (LinkButton) skin.FindControl("butPayMoney");
            butCancelOrder = (LinkButton) skin.FindControl("butCancelOrder");
            butCancelOrder.Click += butCancelOrder_Click;
            btnDelay = (LinkButton) skin.FindControl("btnDelay");
            btnDelay.Click += btnDelay_Click;
            if (!Page.IsPostBack)
            {
                BindData();
            }
            string str = "M_PayOp.aspx?pname=" + lblOrderNumber.Text + "&orderguid=" + Common.Common.ReqStr("guid") +
                         "&mid=" +
                         base.MemLoginID + "&shopid=" + lblMemLoginId.Text + "&ordertype=" +
                         Common.Common.ReqStr("ordertype") +
                         "&sign=welcomeshopnum1";
            butPayMoney.Attributes.Add("target", "_blank");
            butPayMoney.Attributes.Add("href", str);
        }

        protected void IsEmail(string strflag)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(
                    hidOrderGuId.Value);
            if ((orderInfoByGuid.Rows.Count <= 0) || (orderInfoByGuid.Rows[0]["Email"].ToString() != ""))
            {
                string str;
                string str6;
                string str5 = orderInfoByGuid.Rows[0]["Email"].ToString();
                string str7 = ShopSettings.GetValue("Name");
                var stute = new UpdateOrderStute();
                stute.Name = str6 = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                stute.OrderStatus = setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
                stute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.ShopName = str7;
                string s = string.Empty;
                string str3 = string.Empty;
                if (strflag == "CancelOrderIsEmail")
                {
                    str = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                }
                else
                {
                    str = "204e827c-a610-4212-836e-709cd59cba83";
                }
                DataTable editInfo =
                    ((ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action()).GetEditInfo("'" + str + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    str3 = editInfo.Rows[0]["Title"].ToString();
                }
                s =
                    s.Replace("{$Name}", stute.Name)
                        .Replace("{$OrderNumber}", stute.OrderNumber)
                        .Replace("{$ShopName}", stute.ShopName)
                        .Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                string str4 = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                new SendEmail().Emails(str5, str6, str3, str, str4);
            }
        }

        protected void IsMMS(string strflag)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(
                    Page.Request.QueryString["guid"]);
            var action2 = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            if ((orderInfoByGuid.Rows[0]["mobile"] != null) && (orderInfoByGuid.Rows[0]["mobile"].ToString() != ""))
            {
                string str2 = orderInfoByGuid.Rows[0]["mobile"].ToString();
                string str3 = ShopSettings.GetValue("Name");
                var stute = new UpdateOrderStute();
                stute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                stute.OrderStatus = setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
                stute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.ShopName = str3;
                string s = string.Empty;
                string mmsGuid = "";
                if (strflag == "CancelOrderIsMMS")
                {
                    mmsGuid = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                }
                else
                {
                    mmsGuid = "";
                }
                if (mmsGuid != "")
                {
                    ShopNum1_MMSGroupSend send;
                    DataTable editInfo =
                        ((ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action()).GetEditInfo(
                            "'" + mmsGuid + "'", 0);
                    string mMsTitle = string.Empty;
                    if (editInfo.Rows.Count > 0)
                    {
                        s = editInfo.Rows[0]["Remark"].ToString();
                        mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    }
                    s =
                        s.Replace("{$Name}", stute.Name)
                            .Replace("{$OrderNumber}", stute.OrderNumber)
                            .Replace("{$ShopName}", stute.ShopName)
                            .Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    s = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                    string retmsg = string.Empty;
                    new SMS().Send(str2.Trim(), s, out retmsg);
                    if (retmsg.IndexOf("发送成功") != -1)
                    {
                        send = AddMMS(stute.Name, str2.Trim(), mMsTitle, s, 2, mmsGuid);
                        action2.AddMMSGroupSend(send);
                    }
                    else
                    {
                        send = AddMMS(stute.Name, str2.Trim(), mMsTitle, s, 0, mmsGuid);
                        action2.AddMMSGroupSend(send);
                    }
                }
            }
        }

        private void butSureConfirm_Click(object sender, EventArgs e)
        {
            if (hidPayMentName.Value.IndexOf("担保交易") != -1)
            {
                MessageBox.Show("您必须到支付宝中进行确认收货！");
                string str = Common.Common.GetNameById("alipaytradeid", "shopnum1_orderinfo",
                    " and guid='" + hidOrderGuId.Value + "'");
                Thread.Sleep(200);
                Page.Response.Redirect(
                    "https://lab.alipay.com/consume/queryTradeDetail.htm?actionName=CONFIRM_GOODS&tradeNo=" + str);
            }
            else
            {
                string str4 = hidOrderProductId.Value;
                decimal num11 = 0M;
                decimal num4 = 0M;

                decimal num6 = 0M;
                var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                var action3 = (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
                var action4 = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                string memberloginid = hidShopId.Value;
                decimal num3 = Convert.ToDecimal(hidShouldPayPrice.Value);
                decimal payprice = Convert.ToDecimal(num3);
                bool flag2 = true;
                bool flag = true;
                if (str4 != "")
                {
                    decimal num2;
                    string str8 = hidBuyNum.Value;
                    int length = 1;
                    if (str4.IndexOf(",") != -1)
                    {
                        length = str4.Split(new[] {','}).Length;
                    }
                    string str9 = hidShopPrice.Value;
                    bool flag3 = true;
                    for (int i = 0; i < length; i++)
                    {
                        int num12 = 0;
                        if (str8.IndexOf(",") != -1)
                        {
                            num12 = Convert.ToInt32(str8.Split(new[] {','})[i]);
                        }
                        else
                        {
                            num12 = Convert.ToInt32(str8);
                        }
                        if (str9.IndexOf(",") != -1)
                        {
                            str9 = str9.Split(new[] {','})[i];
                        }
                        string str3 = action4.strVScale(str4.Split(new[] {','})[i]);
                        if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
                        {
                            flag = false;
                            if (((str3 != "") && (str3.IndexOf("|") != -1)) && (str3.Split(new[] {'|'})[1] == "1"))
                            {
                                num2 = decimal.Parse(str3.Split(new[] {'|'})[0])/100M;
                                num4 += (Convert.ToDecimal(str9)*num2)*num12;
                                flag2 = false;
                                flag3 = false;
                            }
                        }
                    }
                    if (!((!flag3 || !(ShopSettings.GetValue("IsShopProductFcRate") == "true")) || flag))
                    {
                        num2 = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate"))/100M;
                        num4 =
                            Convert.ToDecimal((((num3 - Convert.ToDecimal(hidDispatchPrice.Value)) -
                                                Convert.ToDecimal(hidPaymentPrice.Value))*num2));
                    }
                }
                string str7 = Common.Common.GetNameById("advancepayment", "shopnum1_member",
                    " and memloginid='" + memberloginid + "'");
                if (str7 != "")
                {
                    decimal advancePayments = Convert.ToDecimal(str7);
                    if (ShopSettings.GetValue("IsOrderCommission") == "true")
                    {
                        num6 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission"))/100M;
                        if (!((!(ShopSettings.GetValue("IsShopProductFcRate") == "true") || !flag2) || flag))
                        {
                            num4 += (num3 - Convert.ToDecimal(hidPaymentPrice.Value))*num6;
                        }
                        else if (!flag)
                        {
                            num4 += (num3 - Convert.ToDecimal(hidPaymentPrice.Value))*num6;
                        }
                    }
                    payprice = Convert.ToDecimal(((num3 - Convert.ToDecimal(hidPaymentPrice.Value)) - (num11 + num4)));
                    if ((ShopSettings.GetValue("IsOrderCommission") != "true") &&
                        (ShopSettings.GetValue("IsShopProductFcRate") != "true"))
                    {
                        payprice = num3;
                    }
                    if (((hidPayMentName.Value.IndexOf("线下") == -1) &&
                         (hidPayMentName.Value.IndexOf("货到付款") == -1)) &&
                        (action2.UpdateAdvancePayment(0, memberloginid, payprice) > 0))
                    {
                        AdvancePaymentModifyLog(4, advancePayments, payprice, "会员确认收货，增加店铺金币（BV）", memberloginid,
                            DateTime.Now, 1);
                    }
                    action.SetOderStatus1(hidOrderGuId.Value, 3, 1, 2, DateTime.Now);
                    int num13 = (ShopSettings.GetValue("BuyProductRankScore") == string.Empty)
                        ? 0
                        : int.Parse(ShopSettings.GetValue("BuyProductRankScore"));
                    int num14 = (ShopSettings.GetValue("BuyProductScore") == string.Empty)
                        ? 0
                        : int.Parse(ShopSettings.GetValue("BuyProductScore"));
                    int score = 0;
                    int rankscore = 0;
                    if (num14 > 0)
                    {
                        double num17 = Convert.ToDouble(num14)/Convert.ToDouble(100);
                        score = Convert.ToInt32((Convert.ToDouble(num3)*num17));
                    }
                    if (num13 > 0)
                    {
                        double num18 = Convert.ToDouble(num13)/Convert.ToDouble(100);
                        rankscore = Convert.ToInt32((Convert.ToDouble(num3)*num18));
                    }
                    if (ShopSettings.GetValue("IsRecommendCommisionOpen") == "true")
                    {
                        decimal num = 0M;
                        string str10 = Common.Common.GetNameById("RecommendCommision", "ShopNum1_OrderInfo",
                            "  AND  Guid='" +
                            Common.Common.ReqStr("guid").Replace("'", "") + "'");
                        if (!string.IsNullOrEmpty(str10))
                        {
                            num = Convert.ToDecimal(str10);
                        }
                        if (num > 0M)
                        {
                            string str2 = Common.Common.GetNameById("PromotionMemLoginID", "ShopNum1_Member",
                                "  AND  MemLoginID='" + base.MemLoginID + "'");
                            if (!string.IsNullOrEmpty(str2))
                            {
                                string str5 = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                                    "   AND   MemLoginID='" + str2 + "'");
                                decimal num9 = 0M;
                                if (!string.IsNullOrEmpty(str5))
                                {
                                    num9 = Convert.ToDecimal(str5);
                                }
                                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                                {
                                    Guid = Guid.NewGuid(),
                                    OperateType = 5,
                                    CurrentAdvancePayment = num9,
                                    OperateMoney = num,
                                    LastOperateMoney = num9 + num,
                                    Date = DateTime.Now,
                                    Memo = "推荐会员[" + base.MemLoginID + "]购买商品返利￥" + num,
                                    MemLoginID = str2,
                                    CreateUser = str2,
                                    CreateTime = DateTime.Now,
                                    IsDeleted = 0
                                };
                                ((ShopNum1_AdvancePaymentModifyLog_Action)
                                    LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                                        advancePaymentModifyLog);
                            }
                        }
                    }
                    action2.UpdateMemberScore(base.MemLoginID, rankscore, score);
                    method_1(score, rankscore);
                    if (ShopSettings.GetValue("ShipmentOKIsEmail") == "1")
                    {
                        IsEmail("ShipmentOKIsEmail");
                    }
                    if (ShopSettings.GetValue("ShipmentOKIsMMS") == "1")
                    {
                        IsMMS("ShipmentOKIsMMS");
                    }
                    if ((hidPayMentName.Value == "线下支付") || (hidPayMentName.Value == "货到付款"))
                    {
                        action3.UpdateStock(hidOrderGuId.Value);
                    }
                    OrderOperateLog("", "交易完成", "等待买家评价");
                    Page.Response.Redirect("M_ProductComment.aspx?orid=" + Common.Common.ReqStr("guid") + "&");
                }
            }
        }

        private void btnUpdatePayMent_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            string str = hidPayMentInfo.Value;
            if (str != "")
            {
                string paymentGuid = string.Empty;
                string paymentName = string.Empty;
                string str4 = "0.00";
                int ispercent = 1;
                paymentGuid = str.Split(new[] {'|'})[0];
                paymentName = str.Split(new[] {'|'})[1];
                str4 = str.Split(new[] {'|'})[2];
                ispercent = Convert.ToInt32(str.Split(new[] {'|'})[3]);
                if (ispercent != 0)
                {
                    str4 = str4.Replace("%", "");
                }
                if (
                    action.UpdatePaymentInfo(Common.Common.ReqStr("guid"), paymentGuid, paymentName,
                        Convert.ToDecimal(str4), ispercent) > 0)
                {
                    OrderOperateLog("", "将" + hidPayMentName.Value + "支付方式修改为" + paymentName, "付款");
                    Page.Response.Redirect("M_OrderDetail.aspx?guid=" + Common.Common.ReqStr("guid") + "&ordertype=" +
                                           Common.Common.ReqStr("ordertype"));
                }
            }
        }

        private void butCancelOrder_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable allStatus = action.GetAllStatus(Common.Common.ReqStr("guid"));
            if (allStatus.Rows.Count > 0)
            {
                if (allStatus.Rows[0]["OderStatus"].ToString() != "2")
                {
                    action.SetOderStatus1(Page.Request.QueryString["guid"], 6, 0, 0, DateTime.Now);
                    if (ShopSettings.GetValue("CancelOrderIsEmail") == "1")
                    {
                        IsEmail("CancelOrderIsEmail");
                    }
                    if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
                    {
                        IsMMS("CancelOrderIsMMS");
                    }
                    OrderOperateLog("取消订单", "买家取消订单", "无");
                    ((ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action()).UpdateReduceStock
                        (Common.Common.ReqStr("guid"), "0");
                    BindData();
                }
                else
                {
                    MessageBox.Show("卖家已经发货！");
                }
            }
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            TimeSpan span = (Convert.ToDateTime(hidExpiresTime.Value) - DateTime.Now);
            if (span.TotalDays > 3.0)
            {
                MessageBox.Show("您可以在离超时结束还剩最后3天时，申请延长确认收货时间！");
            }
            else
            {
                string orderguid = Common.Common.ReqStr("guid");
                action.UpdataReceivedDays(orderguid, hidShopId.Value, "1", "3");
                OrderOperateLog("", "买家延长确认收货时间", "等待买家确认收货");
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
        }

        private void BindData()
        {
            strOrderGuId = Common.Common.ReqStr("guid");
            hidOrderGuId.Value = strOrderGuId;
            strOrderType = Common.Common.ReqStr("ordertype");
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataSet set = action.GetOrderDetail(strOrderGuId, base.MemLoginID, strOrderType, "2");
            if ((set != null) && (set.Tables.Count == 4))
            {
                dt_OrderInfo = set.Tables[0];
                if (dt_OrderInfo.Rows.Count == 0)
                {
                    dt_OrderInfo = null;
                }
                else
                {
                    int num2 = 0;
                    for (int i = 0; i < dt_OrderInfo.Rows.Count; i++)
                    {
                        if (dt_OrderInfo.Rows[i]["ordernumber"].ToString() != "")
                        {
                            num2 = i;
                            break;
                        }
                    }
                    DataRow row = dt_OrderInfo.Rows[num2];
                    hidOrderState.Value = strOderState = row["oderstatus"].ToString();
                    hidPayState.Value = row["paymentstatus"].ToString();
                    hidShipState.Value = row["shipmentstatus"].ToString();
                    hidRefundstatus.Value = row["refundstatus"].ToString();
                    hidRefundType.Value = row["refundtype"].ToString();
                    hidOrderPay.Value = row["paymentmemloginid"].ToString();
                    if (hidOrderState.Value == "0")
                    {
                        var action3 = (ShopNum1_ShopPayment_Action) LogicFactory.CreateShopNum1_ShopPayment_Action();
                        var action2 = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
                        if (row["paymentmemloginid"].ToString() == "admin")
                        {
                            dt_PayMent = action2.Search(0);
                        }
                        else
                        {
                            dt_PayMent = action3.Search(0, row["paymentmemloginid"].ToString());
                        }
                    }
                    strCreateTime = row["createtime"].ToString();
                    strPayTime = row["paytime"].ToString();
                    hidPayMentName.Value = row["paymentname"].ToString();
                    //string strOderState1 = this.strOderState;
                    switch (strOderState)
                    {
                        case null:
                            break;

                        case "0":
                            lblSetOrderTime.Text = strCreateTime;
                            lblCancleOrder.Text = ShopSettings.GetValue("DefaultCancelOrderDays");
                            hidCanleTime.Value =
                                Convert.ToDateTime(strCreateTime).AddDays(double.Parse(lblCancleOrder.Text)).ToString();
                            break;

                        case "1":
                            lblPayMentTime.Text = strPayTime;
                            lblSetOrderTime.Text = strCreateTime;
                            break;

                        default:
                            if (!(strOderState == "2"))
                            {
                                if (strOderState == "3")
                                {
                                    lblPayMentTime.Text = strPayTime;
                                    lblSetOrderTime.Text = strCreateTime;
                                    lblSendGoodsTime.Text = row["dispatchtime"].ToString();
                                    lblConfirmOrderTime.Text = row["receipttime"].ToString();
                                }
                            }
                            else
                            {
                                lblPayMentTime.Text = strPayTime;
                                lblSetOrderTime.Text = strCreateTime;
                                lblSendGoodsTime.Text = row["dispatchtime"].ToString();
                                lblSureDays.Text = row["receivedDays"].ToString();
                                hidEndTime.Value =
                                    Convert.ToDateTime(lblSendGoodsTime.Text)
                                        .AddDays(double.Parse(lblSureDays.Text))
                                        .ToString();
                                hidExpiresTime.Value =
                                    Convert.ToDateTime(lblSendGoodsTime.Text)
                                        .AddDays(Convert.ToDouble(lblSureDays.Text))
                                        .ToString()
                                        .Replace("-", "/");
                            }
                            break;
                    }
                    lblOrderNumber.Text = row["ordernumber"].ToString();
                    lblOrderDate.Text = strCreateTime;
                    if (strOderState == "2")
                    {
                        btnDelay.Enabled = true;
                    }
                    if (row["IsMemdelay"].ToString() == "1")
                    {
                        lblDelay.Text = "您已延迟过！";
                        btnDelay.Enabled = false;
                    }
                    lblReceiveAddress.Text =
                        string.Concat(new[]
                        {
                            row["name"], ",", row["mobile"], ",", row["email"], ",", row["address"], ",",
                            row["postalcode"]
                        });
                    lblBuyerMsg.Text = row["ClientToSellerMsg"].ToString();
                    lblSellerMsg.Text = row["SellerToClientMsg"].ToString();
                    lblShouldPrice.Text = row["shouldpayprice"].ToString();
                    hidShouldPayPrice.Value = row["shouldpayprice"].ToString();
                    hidPaymentPrice.Value = row["paymentprice"].ToString();
                    LabelInvoiceTypeValue.Text = row["InvoiceType"].ToString();
                    LabelInvoiceTitleValue.Text = row["InvoiceTitle"].ToString();
                    LabelInvoiceContentValue.Text = row["InvoiceContent"].ToString();
                    hidlifetype.Value = row["feetype"].ToString();
                    lblOrderStateTxt.Text = setOrderState(strOderState);
                    if (hidlifetype.Value == "2")
                    {
                        if (strOderState == "1")
                        {
                            lblOrderStateTxt.Text = "等待买家消费";
                        }
                        if (Convert.ToInt32(strOderState) > 0)
                        {
                            lblDispatch.Text = "消费码：" + row["identifycode"];
                        }
                    }
                    else
                    {
                        lblDispatch.Text = "邮费：" + row["dispatchprice"] + "元";
                    }
                    if (Convert.ToInt32(hidOrderState.Value) > 1)
                    {
                        lbllogisticType.Text = method_2(row["DispatchType"]);
                    }
                    hidDispatchPrice.Value = row["dispatchprice"].ToString();
                    lblLogisticsCompany.Text = row["LogisticsCompany"].ToString();
                    lblShipmentNumber.Text = row["ShipmentNumber"].ToString();
                    if (row["IsLogistics"].ToString() == "1")
                    {
                        string kuaicom = row["LogisticsCompanyCode"].ToString();
                        string kuainum = row["ShipmentNumber"].ToString();
                        if (kuainum.Length > 5)
                        {
                            LogisticInfo.InnerHtml = new ShopNum1_KuaiDiRequest().GetKuaidiInfo(kuaicom, kuainum,
                                "");
                        }
                    }
                    if (hidExpiresTime.Value != "")
                    {
                        TimeSpan span = (Convert.ToDateTime(hidExpiresTime.Value) - DateTime.Now);
                        hidTotalDays.Value = span.Days.ToString();
                    }
                }
                dt = set.Tables[1];
                if (dt.Rows.Count == 0)
                {
                    dt = null;
                }
                else
                {
                    hidShopId.Value = dt.Rows[0]["memloginId"].ToString();
                    lblMemLoginId.Text = dt.Rows[0]["memloginId"].ToString();
                    lblTrueName.Text = dt.Rows[0]["realname"].ToString();
                    string str = dt.Rows[0]["addressvalue"].ToString();
                    if (str.IndexOf("|") != -1)
                    {
                        str = str.Split(new[] {'|'})[0].Replace(",", "");
                    }
                    lblAreaName.Text = str;
                    lblMoible.Text = dt.Rows[0]["mobile"].ToString();
                    lblEmail.Text = dt.Rows[0]["email"].ToString();
                }
                dt_OrderOperate = set.Tables[2];
                if (dt_OrderOperate.Rows.Count == 0)
                {
                    dt_OrderOperate = null;
                }
                if ((strOderState == "0") &&
                    (Convert.ToDateTime(strCreateTime).AddDays(double.Parse(lblCancleOrder.Text)) <= DateTime.Now))
                {
                    action.SetOderStatus1(Page.Request.QueryString["guid"], 4, 0, 0, DateTime.Now);
                    if (ShopSettings.GetValue("CancelOrderIsEmail") == "1")
                    {
                        IsEmail("CancelOrderIsEmail");
                    }
                    if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
                    {
                        IsMMS("CancelOrderIsMMS");
                    }
                    OrderOperateLog("", "系统取消订单", "无");
                    ((ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action()).UpdateReduceStock
                        (hidOrderGuId.Value, "0");
                }
            }
        }

        private void method_1(int int_0, int int_1)
        {
            string str = Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)",
                "shopnum1_member", " and memloginid='" + base.MemLoginID + "'");
            int num = 0;
            int num2 = 0;
            if ((str != "") && (str.IndexOf("-") != -1))
            {
                num = Convert.ToInt32(str.Split(new[] {'-'})[1]);
                num2 = Convert.ToInt32(str.Split(new[] {'-'})[0]);
            }
            if (int_0 > 0)
            {
                var scoreModeLog = new ShopNum1_ScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = num - int_0,
                    OperateScore = int_0,
                    LastOperateScore = num,
                    Date = DateTime.Now,
                    Memo = "买家确认收货送消费红包",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                ((ShopNum1_ScoreModifyLog_Action) LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
                    scoreModeLog);
            }
            if (int_1 > 0)
            {
                var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = num2 - int_1,
                    OperateScore = int_1,
                    LastOperateScore = num2,
                    Date = DateTime.Now,
                    Memo = "买家确认收货送等级红包",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
            }
        }

        private string method_2(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "平邮";
            }
            if (object_0.ToString() == "2")
            {
                return "快递";
            }
            if (object_0.ToString() == "3")
            {
                return "EMS";
            }
            if (object_0.ToString() == "-1")
            {
                return "买家自提货";
            }
            if (object_0.ToString() == "0")
            {
                return "不需要物流";
            }
            return "";
        }

        private string method_3(string string_6)
        {
            string str = string_6;
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "未发货";

                case "1":
                    return "已发货";

                default:
                    if (!(str == "2"))
                    {
                        if (str == "3")
                        {
                            return "退货";
                        }
                    }
                    else
                    {
                        return "已收货";
                    }
                    break;
            }
            return "非法状态";
        }

        private string method_4(string string_6)
        {
            string str = string_6;
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "未付款";

                case "1":
                    return "已付款";

                default:
                    if (!(str == "2"))
                    {
                        if (str == "3")
                        {
                            return "卖家拒绝退款";
                        }
                    }
                    else
                    {
                        return "退款成功";
                    }
                    break;
            }
            return "非法状态";
        }

        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
        {
            if (!string.IsNullOrEmpty(hidOrderGuId.Value))
            {
                var orderOperateLog = new ShopNum1_OrderOperateLog
                {
                    Guid = Guid.NewGuid(),
                    OrderInfoGuid = new Guid(hidOrderGuId.Value),
                    OderStatus = 1,
                    ShipmentStatus = 0,
                    PaymentStatus = 0,
                    CurrentStateMsg = CurrentStateMsg,
                    NextStateMsg = NextStateMsg,
                    Memo = memo,
                    OperateDateTime = DateTime.Now,
                    IsDeleted = 0,
                    CreateUser = base.MemLoginID
                };
                ((ShopNum1_OrderOperateLog_Action) LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                    orderOperateLog);
            }
        }

        public static string setOrderState(string strState)
        {
            string result;
            switch (strState)
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
    }
}