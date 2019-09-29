using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.KuaiDi;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_OrderDetail : BaseShopWebControl
    {
        public static DataTable dt_OrderInfo = null;
        public static DataTable dt_OrderOperate = null;
        private Label LabelInvoiceContentValue;
        private Label LabelInvoiceTitleValue;
        private Label LabelInvoiceTypeValue;
        private HtmlGenericControl LogisticInfo;
        private LinkButton btnLifeFahuo;
        private LinkButton btnSureConfirm;
        private LinkButton butFahuo;
        private DataTable dt;
        private HtmlInputHidden hidBuyNum;
        private HtmlInputHidden hidCheckCode;
        private HtmlInputHidden hidDispatchPrice;
        private HtmlInputHidden hidEndTime;
        private HtmlInputHidden hidExpiresTime;
        private HtmlInputHidden hidMemloginId;
        private HtmlInputHidden hidOrderGuId;
        private HtmlInputHidden hidOrderPay;
        private HtmlInputHidden hidOrderProductId;
        private HtmlInputHidden hidOrderState;
        private HtmlInputHidden hidPayMentName;
        private HtmlInputHidden hidPayState;
        private HtmlInputHidden hidPaymentPrice;
        private HtmlInputHidden hidRefundType;
        private HtmlInputHidden hidRefundstatus;
        private HtmlInputHidden hidShipState;
        private HtmlInputHidden hidShopPrice;
        private HtmlInputHidden hidShouldPayPrice;
        private HtmlInputHidden hidislogistic;
        private HtmlInputHidden hidlifetype;
        private HtmlInputHidden hidlogisitcnumber;
        private HtmlInputHidden hidlogisticCompany;
        private Label lblAreaName;
        private Label lblBuyerMsg;
        private Label lblConfirmOrderTime;
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
        private string skinFilename = "S_OrderDetail.ascx";
        private HtmlInputText txtlifeCode;
        private Label LabeScroce_pva;
        private Label LabelServiceAgent;
        private string OrdernumberGZ;
        private Label LabelDeduction_hv;
        private Label Recommend_Serve;


        public S_OrderDetail()
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

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle,
            int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = strContent,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }
        public void AdvancePaymentModifyLog(int OperateType, decimal Score_rvs, decimal payMoney, string Memo,
            string shopMemloginID, DateTime time, int type)
        {
            var shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action2.GetOrderGuIdByordernumber(OrdernumberGZ);
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                Guid = Guid.NewGuid(),
                OperateType = OperateType,
                CurrentAdvancePayment = Score_rvs,
                OperateMoney = payMoney
            };
            //不知道是啥
            //payMoney = payMoney - Convert.ToDecimal(orderGuIdByTradeId.Rows[0]["Score_pv_a"]);

            if (type == 1)
            {
                advancePaymentModifyLog.LastOperateMoney = Score_rvs + payMoney;
            }
            else
            {
                advancePaymentModifyLog.LastOperateMoney = Score_rvs - payMoney;
            }
            //decimal score_hv = Convert.ToDecimal(Common.Common.GetNameById("Score_hv", "shopnum1_member",
            //        " and memloginid='" + shopMemloginID + "'"));
            //decimal score_pv_a = Convert.ToDecimal(Common.Common.GetNameById("Score_pv_a", "shopnum1_member",
            //        " and memloginid='" + shopMemloginID + "'"));
            //decimal score_dv = Convert.ToDecimal(Common.Common.GetNameById("Score_dv", "shopnum1_member",
            //        " and memloginid='" + shopMemloginID + "'"));
            //decimal score_pv_b = Convert.ToDecimal(Common.Common.GetNameById("Score_pv_b", "shopnum1_member",
            //        " and memloginid='" + shopMemloginID + "'"));
            //advancePaymentModifyLog.Score_hv = score_hv;
            //advancePaymentModifyLog.Score_pv_a = score_pv_a;
            //advancePaymentModifyLog.Score_dv = score_dv;
            //advancePaymentModifyLog.Score_pv_b = score_pv_b;
            advancePaymentModifyLog.Date = time;
            advancePaymentModifyLog.Memo = Memo;
            advancePaymentModifyLog.MemLoginID = shopMemloginID;
            advancePaymentModifyLog.CreateUser = shopMemloginID;
            advancePaymentModifyLog.CreateTime = time;
            advancePaymentModifyLog.IsDeleted = 0;
            ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoneyDJ_BV(advancePaymentModifyLog);
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelInvoiceTypeValue = (Label)skin.FindControl("LabelInvoiceTypeValue");
            LabelInvoiceTitleValue = (Label)skin.FindControl("LabelInvoiceTitleValue");
            LabelInvoiceContentValue = (Label)skin.FindControl("LabelInvoiceContentValue");
            butFahuo = (LinkButton)skin.FindControl("butFahuo");
            butFahuo.Click += butFahuo_Click;
            btnSureConfirm = (LinkButton)skin.FindControl("btnSureConfirm");
            btnSureConfirm.Click += btnSureConfirm_Click;
            LogisticInfo = (HtmlGenericControl)skin.FindControl("LogisticInfo");
            lblSetOrderTime = (Label)skin.FindControl("lblSetOrderTime");
            lblPayMentTime = (Label)skin.FindControl("lblPayMentTime");
            lblSendGoodsTime = (Label)skin.FindControl("lblSendGoodsTime");
            lblConfirmOrderTime = (Label)skin.FindControl("lblConfirmOrderTime");
            lblMemLoginId = (Label)skin.FindControl("lblMemLoginId");
            lblTrueName = (Label)skin.FindControl("lblTrueName");
            lblAreaName = (Label)skin.FindControl("lblAreaName");
            lblMoible = (Label)skin.FindControl("lblMoible");
            lblEmail = (Label)skin.FindControl("lblEmail");
            Recommend_Serve = (Label)skin.FindControl("Recommend_Serve");
            lblOrderNumber = (Label)skin.FindControl("lblOrderNumber");
            LabelDeduction_hv = (Label)skin.FindControl("LabelDeduction_hv");
            lblOrderStateTxt = (Label)skin.FindControl("lblOrderStateTxt");
            lblOrderDate = (Label)skin.FindControl("lblOrderDate");
            lblReceiveAddress = (Label)skin.FindControl("lblReceiveAddress");
            lbllogisticType = (Label)skin.FindControl("lbllogisticType");
            lblLogisticsCompany = (Label)skin.FindControl("lblLogisticsCompany");
            lblShipmentNumber = (Label)skin.FindControl("lblShipmentNumber");
            lblBuyerMsg = (Label)skin.FindControl("lblBuyerMsg");
            lblSellerMsg = (Label)skin.FindControl("lblSellerMsg");
            lblDispatch = (Label)skin.FindControl("lblDispatch");
            lblShouldPrice = (Label)skin.FindControl("lblShouldPrice");
            LabeScroce_pva = (Label)skin.FindControl("LabeScroce_pva");
            LabelServiceAgent = (Label)skin.FindControl("LabelServiceAgent");
            lblSureDays = (Label)skin.FindControl("lblSureDays");
            txtlifeCode = (HtmlInputText)skin.FindControl("txtlifeCode");
            btnLifeFahuo = (LinkButton)skin.FindControl("btnLifeFahuo");
            btnLifeFahuo.Click += btnLifeFahuo_Click;
            hidOrderGuId = (HtmlInputHidden)skin.FindControl("hidOrderGuId");
            hidOrderState = (HtmlInputHidden)skin.FindControl("hidOrderState");
            hidislogistic = (HtmlInputHidden)skin.FindControl("hidislogistic");
            hidlogisitcnumber = (HtmlInputHidden)skin.FindControl("hidlogisitcnumber");
            hidlogisticCompany = (HtmlInputHidden)skin.FindControl("hidlogisticCompany");
            hidPayState = (HtmlInputHidden)skin.FindControl("hidPayState");
            hidShipState = (HtmlInputHidden)skin.FindControl("hidShipState");
            hidRefundstatus = (HtmlInputHidden)skin.FindControl("hidRefundstatus");
            hidOrderProductId = (HtmlInputHidden)skin.FindControl("hidOrderProductId");
            hidShouldPayPrice = (HtmlInputHidden)skin.FindControl("hidShouldPayPrice");
            hidPaymentPrice = (HtmlInputHidden)skin.FindControl("hidPaymentPrice");
            hidMemloginId = (HtmlInputHidden)skin.FindControl("hidMemloginId");
            hidDispatchPrice = (HtmlInputHidden)skin.FindControl("hidDispatchPrice");
            hidOrderPay = (HtmlInputHidden)skin.FindControl("hidOrderPay");
            hidPayMentName = (HtmlInputHidden)skin.FindControl("hidPayMentName");
            hidExpiresTime = (HtmlInputHidden)skin.FindControl("hidExpiresTime");
            hidlifetype = (HtmlInputHidden)skin.FindControl("hidlifetype");
            hidEndTime = (HtmlInputHidden)skin.FindControl("hidEndTime");
            hidCheckCode = (HtmlInputHidden)skin.FindControl("hidCheckCode");
            hidBuyNum = (HtmlInputHidden)skin.FindControl("hidBuyNum");
            hidShopPrice = (HtmlInputHidden)skin.FindControl("hidShopPrice");
            hidRefundType = (HtmlInputHidden)skin.FindControl("hidRefundType");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void IsEmail(string guid, string Type)
        {
            string str = string.Empty;
            string s = string.Empty;
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(guid);
            if ((orderInfoByGuid.Rows[0]["Email"] != null) && (orderInfoByGuid.Rows[0]["Email"].ToString() != ""))
            {
                string str4;
                string str6 = orderInfoByGuid.Rows[0]["Email"].ToString();
                string str5 = ShopSettings.GetValue("Name");
                var stute = new UpdateOrderStute();
                var annoucement = new SendProductAnnoucement();
                if (Type == "CancelOrderIsEmail")
                {
                    stute.Name = str = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                    stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                    stute.OrderStatus = setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
                    stute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    stute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    stute.ShopName = str5;
                    str4 = "b195a8ab-8b12-4df2-b719-c9cc8e6e5226";
                }
                else
                {
                    annoucement.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                    annoucement.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                    annoucement.Memo = orderInfoByGuid.Rows[0]["SellerToClientMsg"].ToString();
                    annoucement.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    annoucement.ShopName = str5;
                    annoucement.ShopDoMain = ShopSettings.siteDomain;
                    str4 = "7c367402-4219-46b7-bc48-72cf48f6a836";
                }
                string str3 = string.Empty;
                DataTable editInfo =
                    ((ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action()).GetEditInfo("'" + str4 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    str3 = editInfo.Rows[0]["Title"].ToString();
                }
                if (Type == "CancelOrderIsEmail")
                {
                    s = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                }
                else
                {
                    s = annoucement.ChangeSendProductAnnoucement(Page.Server.HtmlDecode(s));
                }
                new SendEmail().Emails(str6, str, str3, str4, s);
            }
        }

        protected void IsMMS(string guid, string type)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(guid);
            if (orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim() != "")
            {
                ShopNum1_MMSGroupSend send;
                string str4 = string.Empty;
                var stute = new UpdateOrderStute();
                var annoucement = new SendProductAnnoucement();
                if (type == "CancelOrderIsMMS")
                {
                    stute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                    stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                    stute.OrderStatus = setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
                    stute.ShopName = ShopSettings.GetValue("Name");
                    stute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    stute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    annoucement.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    str4 = "'3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2'";
                }
                else
                {
                    annoucement.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                    annoucement.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                    annoucement.ShopDoMain = ShopSettings.siteDomain;
                    annoucement.ShopName = ShopSettings.GetValue("Name");
                    annoucement.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    annoucement.Memo = orderInfoByGuid.Rows[0]["SellerToClientMsg"].ToString();
                    str4 = "7c367402-4219-46b7-bc48-72cf48f6a836";
                }
                IShopNum1_MMS_Action action2 = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = action2.GetEditInfo(str4, 0);
                string s = editInfo.Rows[0]["Remark"].ToString();
                string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                var sms = new SMS();
                string retmsg = "";
                if (type == "CancelOrderIsMMS")
                {
                    s = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                }
                else
                {
                    s = annoucement.ChangeSendProductAnnoucement(Page.Server.HtmlDecode(s));
                }
                sms.Send(orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim(), s + "【唐江宝宝】", out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    send = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(),
                        orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim(), s, mMsTitle, 2,
                        str4.Replace("'", ""));
                    action2.AddMMSGroupSend(send);
                }
                else
                {
                    send = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(),
                        orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim(), s, mMsTitle, 0,
                        str4.Replace("'", ""));
                    action2.AddMMSGroupSend(send);
                }
            }
        }

        protected void butFahuo_Click(object sender, EventArgs e)
        {
            string str;
            string str2;
            string str3;
            string str4;
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            if (hidislogistic.Value == "1")
            {
                str = "1";
                str2 = hidlogisticCompany.Value.Split(new[] { '|' })[0];
                str3 = hidlogisticCompany.Value.Split(new[] { '|' })[1];
                str4 = hidlogisitcnumber.Value;
            }
            else
            {
                str = "0";
                str2 = "000";
                str3 = "000";
                str4 = "000";
            }
            if ((str == "1") && (str2 != "其它"))
            {
                string kuaicom = str3;
                string kuainum = str4;
                string str7 = new ShopNum1_KuaiDiRequest().GetKuaidiInfoMY(kuaicom, kuainum);
                if ((str7.IndexOf("不正确") != -1) || (str7.IndexOf("错误") != -1))
                {
                    MessageBox.Show("快递单号无法匹配对应的快递信息！");
                    BindData();
                    return;
                }
            }
            string partner = string.Empty;
            /*DataTable paymentKey =
                ((ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action()).GetPaymentKey("Alipay.aspx");
            if (paymentKey.Rows.Count > 0)
            {
                partner = paymentKey.Rows[0]["MerchantCode"].ToString();
                DataTable table = action.Search1(Common.Common.ReqStr("guid"));
                if ((table != null) && (table.Rows.Count > 0))
                {
                    string str11 = table.Rows[0]["AlipayTradeId"].ToString();
                    string xml = new PayUrlOperate().ConfimSendProduct(partner, str11, str2, str4);
                    var document = new XmlDocument();
                    try
                    {
                        document.LoadXml(xml);
                        if (document.SelectSingleNode("//is_success").InnerText == "T")
                        {
                            MessageBox.Show("发货成功！");
                        }
                    }
                    catch (Exception)
                    {
                        Page.Response.Write(xml);
                    }
                }
            }*/
            if (action.OrderInfoLogistics(hidOrderGuId.Value, str, str2, str3, str4) > 0)
            {
                var action2 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                var orderOperateLog = new ShopNum1_OrderOperateLog
                {
                    Guid = Guid.NewGuid(),
                    OrderInfoGuid = new Guid(hidOrderGuId.Value),
                    CreateUser = base.MemLoginID,
                    OderStatus = 2,
                    ShipmentStatus = 1,
                    PaymentStatus = 1,
                    CurrentStateMsg = "卖家已经发货",
                    NextStateMsg = "等待买家确认收货",
                    Memo = "",
                    OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                action2.Add(orderOperateLog);
                try
                {
                    if (ShopSettings.GetValue("ShipmentOKIsEmail") == "1")
                    {
                        IsEmail(hidOrderGuId.Value, "ShipmentOKIsEmail");
                    }
                    if (ShopSettings.GetValue("ShipmentIsMMS") == "1")
                    {
                        IsMMS(hidOrderGuId.Value, "ShipmentIsMMS");
                    }
                }
                catch
                {
                }
                BindData();
            }
            else
            {
                MessageBox.Show("发货失败！");
            }
        }

        protected void btnSureConfirm_Click(object sender, EventArgs e)
        {
            BindData();
            string str12 = Common.Common.GetNameById("OderStatus", "shopnum1_orderinfo",
                   " and guid='" + hidOrderGuId.Value + "'");
            if (str12 == "2")
            {
                #region 卖家强制确认收货
                string str = hidOrderProductId.Value;
                decimal num = 0M;
                decimal num2 = 0M;
                decimal num3 = 0M;
                var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                var action2 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                var action3 = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                var action4 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                var action6 = (ShopNum1_FreezeRelease_Action)LogicFactory.CreateShopNum1_FreezeRelease_Action();

                DataTable table = action.SelectOrderOfAll(OrdernumberGZ);
                decimal pv_b = Convert.ToDecimal(table.Rows[0]["Score_pv_b"].ToString());
                string memLoginID = base.MemLoginID;
                decimal num4 = Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"].ToString()) - pv_b;
                decimal payprice = Convert.ToDecimal(num4);
                bool flag = true;
                bool flag2 = true;
                if (str != "")
                {
                    decimal num7;
                    string str3 = hidBuyNum.Value;
                    int length = 1;
                    if (str.IndexOf(",") != -1)
                    {
                        length = str.Split(new[] { ',' }).Length;
                    }
                    string str5 = hidShopPrice.Value;
                    for (int i = 0; i < length; i++)
                    {
                        int num8 = 0;
                        if (str3.IndexOf(",") != -1)
                        {
                            num8 = Convert.ToInt32(str3.Split(new[] { ',' })[i]);
                        }
                        else
                        {
                            num8 = Convert.ToInt32(str3);
                        }
                        if (str5.IndexOf(",") != -1)
                        {
                            str5 = str5.Split(new[] { ',' })[i];
                        }
                        string str4 = action4.strVScale(str.Split(new[] { ',' })[i]);
                        //if (((ShopSettings.GetValue("IsShopProductFcRate") == "true") &&
                        //     ((str4 != "") && (str4.IndexOf("|") != -1))) && (str4.Split(new[] { '|' })[1] == "1"))
                        //{
                        //    num7 = decimal.Parse(str4.Split(new[] { '|' })[0]) / 100M;
                        //    num2 += (Convert.ToDecimal(str5) * num7) * num8;
                        //    flag = false;
                        //    flag2 = false;
                        //}
                    }
                    if (flag2 && (ShopSettings.GetValue("IsShopProductFcRate") == "true"))
                    {
                        num7 = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate")) / 100M;
                        num2 =
                            Convert.ToDecimal((((num4 - Convert.ToDecimal(hidDispatchPrice.Value)) -
                                                Convert.ToDecimal(hidPaymentPrice.Value)) * num7));
                    }
                }
                string str6 = Common.Common.GetNameById("AdvancePayment", "shopnum1_member",
                    " and memloginid='" + memLoginID + "'");
                if (str6 != "")
                {
                    decimal Score_rvs = Convert.ToDecimal(str6);
                    if (ShopSettings.GetValue("IsOrderCommission") == "true")
                    {
                        num3 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100M;
                        if ((ShopSettings.GetValue("IsShopProductFcRate") == "true") && flag)
                        {
                            num2 += (num4 - Convert.ToDecimal(hidPaymentPrice.Value)) * num3;
                        }
                        else
                        {
                            num2 = (num4 - Convert.ToDecimal(hidPaymentPrice.Value)) * num3;
                        }
                    }
                    payprice = Convert.ToDecimal((num4 - (num + num2))) - Convert.ToDecimal(hidPaymentPrice.Value);
                    if ((ShopSettings.GetValue("IsOrderCommission") != "true") &&
                        (ShopSettings.GetValue("IsShopProductFcRate") != "true"))
                    {
                        payprice = num4;
                    }
                    if (((hidPayMentName.Value.IndexOf("线下") == -1) && (hidPayMentName.Value.IndexOf("货到付款") == -1))                      )
                    {

                        AdvancePaymentModifyLog(4, Score_rvs, payprice, "会员确认收货，增加店铺人民币（RV）", memLoginID,
                            DateTime.Now, 1);
                        ShopNum1_FreezeRelease freeze=new ShopNum1_FreezeRelease();
                        freeze.FreezeMemLoginID=memLoginID;
                        freeze.FreezeScore_rv = decimal.Multiply(payprice, (decimal)0.35); ;
                        freeze.FreezeTime=DateTime.Now;
                        action6.Add(freeze);
                    }
                    if ((hidPayMentName.Value == "线下支付") || (hidPayMentName.Value == "货到付款"))
                    {
                        action3.UpdateStock(hidOrderGuId.Value);
                    }
                    action.SetOderStatus1(hidOrderGuId.Value, 3, 1, 2, DateTime.Now);
                    var action5 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    var orderOperateLog = new ShopNum1_OrderOperateLog
                    {
                        Guid = Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hidOrderGuId.Value),
                        CreateUser = base.MemLoginID,
                        OderStatus = 3,
                        ShipmentStatus = 2,
                        PaymentStatus = 1,
                        CurrentStateMsg = "买家收货超时,卖家已经确认收货",
                        NextStateMsg = "等待买家评价",
                        Memo = "",
                        OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                    action5.Add(orderOperateLog);
                    BindData();
                }
                #endregion
            }
        }

        protected void btnLifeFahuo_Click(object sender, EventArgs e)
        {
            string str;
            string str2;
            string str3;
            string str4;
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string text1 = hidOrderGuId.Value;
            var action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            if (hidislogistic.Value == "1")
            {
                str = "1";
                str2 = hidlogisticCompany.Value.Split(new[] { '|' })[0];
                str3 = hidlogisticCompany.Value.Split(new[] { '|' })[1];
                str4 = hidlogisitcnumber.Value;
            }
            else
            {
                str = "0";
                str2 = "";
                str3 = "";
                str4 = "";
            }
            lblLogisticsCompany.Text = str2;
            lblShipmentNumber.Text = str4;
            if ((str == "1") && (str2 != "其它"))
            {
                string kuaicom = str3;
                string kuainum = str4;
                string str12 = new ShopNum1_KuaiDiRequest().GetKuaidiInfoMY(kuaicom, kuainum);
                if ((str12.IndexOf("不正确") != -1) || (str12.IndexOf("错误") != -1))
                {
                    MessageBox.Show("快递单号无法匹配对应的快递信息！");
                    BindData();
                    return;
                }
            }
            string partner = string.Empty;
            DataTable paymentKey =
                ((ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action()).GetPaymentKey("Alipay.aspx");
            if (paymentKey.Rows.Count > 0)
            {
                partner = paymentKey.Rows[0]["MerchantCode"].ToString();
                DataTable table2 = action2.Search1(Common.Common.ReqStr("guid"));
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    string str7 = table2.Rows[0]["AlipayTradeId"].ToString();
                    string xml = new PayUrlOperate().ConfimSendProduct(partner, str7, str2, str4);
                    var document = new XmlDocument();
                    try
                    {
                        document.LoadXml(xml);
                        if (document.SelectSingleNode("//is_success").InnerText == "T")
                        {
                            MessageBox.Show("发货成功！");
                        }
                    }
                    catch (Exception)
                    {
                        Page.Response.Write(xml);
                    }
                }
            }
            string str11 = hidOrderProductId.Value;
            decimal num8 = 0M;
            decimal num4 = 0M;

            decimal num2 = 0M;
            var action6 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            var action7 = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
            var action5 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            string memLoginID = base.MemLoginID;
            decimal num6 = Convert.ToDecimal(hidShouldPayPrice.Value);
            decimal payprice = Convert.ToDecimal(num6);
            bool flag = true;
            bool flag3 = true;
            if (str11 != "")
            {
                decimal num3;
                string str10 = hidBuyNum.Value;
                int length = 1;
                if (str11.IndexOf(",") != -1)
                {
                    length = str11.Split(new[] { ',' }).Length;
                }
                string str6 = hidShopPrice.Value;
                bool flag2 = true;
                for (int i = 0; i < length; i++)
                {
                    int num5 = 0;
                    if (str10.IndexOf(",") != -1)
                    {
                        num5 = Convert.ToInt32(str10.Split(new[] { ',' })[i]);
                    }
                    else
                    {
                        num5 = Convert.ToInt32(str10);
                    }
                    if (str6.IndexOf(",") != -1)
                    {
                        str6 = str6.Split(new[] { ',' })[i];
                    }
                    string str9 = action5.strVScale(str11.Split(new[] { ',' })[i]);
                    if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
                    {
                        flag3 = false;
                        if (((str9 != "") && (str9.IndexOf("|") != -1)) && (str9.Split(new[] { '|' })[1] == "1"))
                        {
                            num3 = decimal.Parse(str9.Split(new[] { '|' })[0]) / 100M;
                            num4 += (Convert.ToDecimal(str6) * num3) * num5;
                            flag = false;
                            flag2 = false;
                        }
                    }
                }
                if (!((!flag2 || !(ShopSettings.GetValue("IsShopProductFcRate") == "true")) || flag3))
                {
                    num3 = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate")) / 100M;
                    num4 =
                        Convert.ToDecimal((((num6 - Convert.ToDecimal(hidDispatchPrice.Value)) -
                                            Convert.ToDecimal(hidPaymentPrice.Value)) * num3));
                }
            }
            string str17 = Common.Common.GetNameById("advancepayment", "shopnum1_member",
                " and memloginid='" + memLoginID + "'");
            if (str17 != "")
            {
                decimal advancePayments = Convert.ToDecimal(str17);
                if (ShopSettings.GetValue("IsOrderCommission") == "true")
                {
                    num2 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100M;
                    if (!((!(ShopSettings.GetValue("IsShopProductFcRate") == "true") || !flag) || flag3))
                    {
                        num4 += (num6 - Convert.ToDecimal(hidPaymentPrice.Value)) * num2;
                    }
                    else if (!flag3)
                    {
                        num4 += (num6 - Convert.ToDecimal(hidPaymentPrice.Value)) * num2;
                    }
                }
                payprice = Convert.ToDecimal(((num6 - Convert.ToDecimal(hidPaymentPrice.Value)) - (num8 + num4)));
                if ((ShopSettings.GetValue("IsOrderCommission") != "true") &&
                    (ShopSettings.GetValue("IsShopProductFcRate") != "true"))
                {
                    payprice = num6;
                }
                if (((hidPayMentName.Value.IndexOf("线下") == -1) && (hidPayMentName.Value.IndexOf("货到付款") == -1)) &&
                    (action6.UpdateAdvancePayment(0, memLoginID, payprice) > 0))
                {
                    AdvancePaymentModifyLog(4, advancePayments, payprice, "会员确认收货，增加店铺金币（BV）", memLoginID, DateTime.Now, 1);
                }
                if (action.SetOderStatus1(hidOrderGuId.Value, 3, 1, 2, DateTime.Now) > 0)
                {
                    if ((hidPayMentName.Value == "线下支付") || (hidPayMentName.Value == "货到付款"))
                    {
                        action7.UpdateStock(hidOrderGuId.Value);
                    }
                    var action4 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    var orderOperateLog = new ShopNum1_OrderOperateLog
                    {
                        Guid = Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hidOrderGuId.Value),
                        CreateUser = base.MemLoginID,
                        OderStatus = 3,
                        ShipmentStatus = 2,
                        PaymentStatus = 1,
                        CurrentStateMsg = "买家已消费,交易完成",
                        NextStateMsg = "等待买家评价",
                        Memo = "",
                        OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                    action4.Add(orderOperateLog);
                    BindData();
                }
                else
                {
                    MessageBox.Show("发货失败！");
                }
            }
        }

        protected void BindData()
        {
            strOrderGuId = Common.Common.ReqStr("guid");
            hidOrderGuId.Value = strOrderGuId;
            strOrderType = Common.Common.ReqStr("ordertype");
            DataSet set =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderDetail(
                    strOrderGuId, base.MemLoginID, strOrderType, "1");
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
                    hidPayMentName.Value = row["paymentname"].ToString();
                    hidOrderPay.Value = row["paymentmemloginid"].ToString();
                    hidOrderState.Value = this.strOderState = row["oderstatus"].ToString();
                    hidPayState.Value = row["paymentstatus"].ToString();
                    hidShipState.Value = row["shipmentstatus"].ToString();
                    hidRefundstatus.Value = row["refundstatus"].ToString();
                    hidRefundType.Value = row["refundtype"].ToString();
                    strCreateTime = row["createtime"].ToString();
                    strPayTime = row["paytime"].ToString();
                    hidPaymentPrice.Value = row["paymentprice"].ToString();
                    
                    string strOderState = this.strOderState;
                    switch (strOderState)
                    {
                        case null:
                            break;

                        case "0":
                            lblSetOrderTime.Text = strCreateTime;
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
                                hidExpiresTime.Value =
                                    Convert.ToDateTime(lblSendGoodsTime.Text)
                                        .AddDays(Convert.ToDouble(lblSureDays.Text))
                                        .ToString()
                                        .Replace("-", "/");
                                hidEndTime.Value =
                                    Convert.ToDateTime(lblSendGoodsTime.Text)
                                        .AddDays(double.Parse(lblSureDays.Text))
                                        .ToString();
                            }
                            break;
                    }
                    OrdernumberGZ = row["ordernumber"].ToString();
                    lblOrderNumber.Text = row["ordernumber"].ToString();
                    LabelDeduction_hv.Text = row["Deduction_hv"].ToString();
                    lblOrderStateTxt.Text = setOrderState(this.strOderState);
                    Recommend_Serve.Text = row["ServiceAgent"].ToString();

                    lblOrderDate.Text = strCreateTime;
                    lblReceiveAddress.Text =
                        string.Concat(new[]
                        {
                            row["name"], ",", row["mobile"], ",", row["email"], ",", row["address"], ",",
                            row["postalcode"]
                        });
                    lblBuyerMsg.Text = row["ClientToSellerMsg"].ToString();
                    lblSellerMsg.Text = row["SellerToClientMsg"].ToString();
                    lblShouldPrice.Text = row["shouldpayprice"].ToString();
                    if (Convert.ToDecimal(row["Score_pv_a"]) != 0)
                    {
                        LabeScroce_pva.Text = row["Score_pv_a"].ToString();
                    }
                    else if (Convert.ToDecimal(row["Score_pv_b"]) != 0)
                    {
                        LabeScroce_pva.Text = (Convert.ToDecimal(row["Score_pv_b"]) + Convert.ToDecimal(row["Score_max_hv"])).ToString();
                    }
                    else if (Convert.ToDecimal(row["Score_pv_b"]) == 0 && Convert.ToDecimal(row["Score_pv_b"]) == 0)
                    {
                        LabeScroce_pva.Text = row["Score_pv_b"].ToString();
                    }
                    LabelServiceAgent.Text = row["ServiceAgent"].ToString();
                    hidShouldPayPrice.Value = row["shouldpayprice"].ToString();
                    LabelInvoiceTypeValue.Text = row["InvoiceType"].ToString();
                    LabelInvoiceTitleValue.Text = row["InvoiceTitle"].ToString();
                    LabelInvoiceContentValue.Text = row["InvoiceContent"].ToString();
                    hidlifetype.Value = row["feetype"].ToString();
                    hidCheckCode.Value = row["identifycode"].ToString();
                    if (hidlifetype.Value != "2")
                    {
                        lblDispatch.Text = "邮费：" + row["dispatchprice"] + "元";
                    }
                    if (Convert.ToInt32(hidOrderState.Value) > 1)
                    {
                        lbllogisticType.Text = method_1(row["DispatchType"]);
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
                            LogisticInfo.InnerHtml = new ShopNum1_KuaiDiRequest().GetKuaidiInfoMY(kuaicom, kuainum);
                        }
                    }
                }
                dt = set.Tables[1];
                if (dt.Rows.Count == 0)
                {
                    dt = null;
                }
                else
                {
                    lblMemLoginId.Text = dt.Rows[0]["memloginId"].ToString();
                    hidMemloginId.Value = lblMemLoginId.Text;
                    lblTrueName.Text = dt.Rows[0]["realname"].ToString();
                    string str3 = dt.Rows[0]["addressvalue"].ToString();
                    if (str3.IndexOf("|") != -1)
                    {
                        str3 = str3.Split(new[] { '|' })[0].Replace(",", "");
                    }
                    lblAreaName.Text = str3;
                    lblMoible.Text = dt.Rows[0]["mobile"].ToString();
                    lblEmail.Text = dt.Rows[0]["email"].ToString();
                   
                }
                dt_OrderOperate = set.Tables[2];
                if (dt_OrderOperate.Rows.Count == 0)
                {
                    dt_OrderOperate = null;
                }
                string Memlogid = null;
                Memlogid = dt_OrderOperate.Rows[0]["createuser"].ToString();
                //if (Memlogid.ToLower() == "c0000001")
                //{
                //    TuiJian.Visible = true;
                //}
                //else
                //{
                //    TuiJian.Visible = false;
                //}
            }

        }

        private string method_1(object object_0)
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
                    result = "订单关闭";
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

        public static string setPaymentState(string strState)
        {
            string result;
            if (strState != null)
            {
                if (strState == "0")
                {
                    result = "未付款";
                    return result;
                }
                if (strState == "1")
                {
                    result = "已付款";
                    return result;
                }
                if (strState == "2")
                {
                    result = "已退款";
                    return result;
                }
                if (strState == "3")
                {
                    result = "退款成功";
                    return result;
                }
                if (strState == "4")
                {
                    result = "卖家拒绝退款";
                    return result;
                }
            }
            result = "非法状态";
            return result;
        }

        public static string setShipmentState(string strState)
        {
            string result;
            switch (strState)
            {
                case "0":
                    result = "未发货";
                    return result;
                case "1":
                    result = "已发货";
                    return result;
                case "2":
                    result = "已收货";
                    return result;
                case "3":
                    result = "已退货";
                    return result;
                case "4":
                    result = "退货成功";
                    return result;
                case "5":
                    result = "卖家拒绝退货";
                    return result;
            }
            result = "非法状态";
            return result;
        }
    }
}