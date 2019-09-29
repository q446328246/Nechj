using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class LifeOrder : BaseWebControl
    {
        private Button btnSure;
        private Button btnViewDetail;
        private HtmlGenericControl content;
        private DataTable dt;
        private HtmlInputHidden hidShopMemloginId;
        private HtmlInputHidden hidSuccesslifeorder;
        private HtmlInputHidden hidWaitlifeorder;
        private Repeater repOrderInfo;
        private string skinFilename = "LifeOrder.ascx";
        private HtmlInputText txtLifeCode;

        public LifeOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state,
            string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = mobile,
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

        protected void btnSure_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            string strCode = txtLifeCode.Value;
            dt = action.GetOrderInfoByCode(hidShopMemloginId.Value, strCode);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("该验证码不是当前商户的验证码!");
            }
            else if (dt.Rows[0]["oderstatus"].ToString() == "3")
            {
                MessageBox.Show("该验证码已在【" + dt.Rows[0]["receipttime"] + "】被使用了!");
            }
            else if (Convert.ToInt32(dt.Rows[0]["oderstatus"].ToString()) == 3)
            {
                MessageBox.Show("该订单已经交易完成!");
            }
            else if (Convert.ToInt32(dt.Rows[0]["oderstatus"].ToString()) > 3)
            {
                MessageBox.Show("该订单已经关闭!");
            }
            else
            {
                var action2 = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                string logisticsCompany = "";
                string shipmentNumber = "";
                string str8 = dt.Rows[0]["ShouldPayPrice"].ToString();
                string memberloginid = hidShopMemloginId.Value;
                string str5 = dt.Rows[0]["PayMentName"].ToString();
                string guid = dt.Rows[0]["GuID"].ToString();
                string partner = string.Empty;
                DataTable paymentKey =
                    ((ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action()).GetPaymentKey("Alipay.aspx");
                if (paymentKey.Rows.Count > 0)
                {
                    partner = paymentKey.Rows[0]["MerchantCode"].ToString();
                    DataTable table = action2.Search1(guid);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        string str14 = dt.Rows[0]["AlipayTradeId"].ToString();
                        if (str5 == "支付宝担保交易")
                        {
                            string xml = new PayUrlOperate().ConfimSendProduct(partner, str14, logisticsCompany,
                                shipmentNumber);
                            var document = new XmlDocument();
                            try
                            {
                                document.LoadXml(xml);
                                if (document.SelectSingleNode("//is_success").InnerText == "T")
                                {
                                    MessageBox.Show("发货成功！");
                                }
                                else
                                {
                                    MessageBox.Show("发货失败！");
                                    return;
                                }
                            }
                            catch (Exception)
                            {
                                Page.Response.Write(xml);
                            }
                        }
                    }
                }

                var action5 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                var action4 = (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
                var action1 = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                decimal payprice = Convert.ToDecimal(str8);
                string str11 = Common.Common.GetNameById("advancepayment", "shopnum1_member",
                    " and memloginid='" + memberloginid + "'");
                if (str11 != "")
                {
                    decimal advancePayments = Convert.ToDecimal(str11);
                    if (((str5.IndexOf("线下") == -1) && (str5.IndexOf("货到付款") == -1)) &&
                        (action5.UpdateAdvancePayment(0, memberloginid, payprice) > 0))
                    {
                        AdvancePaymentModifyLog(4, advancePayments, payprice, "会员确认收货，增加店铺金币（BV）", memberloginid,
                            DateTime.Now, 1);
                    }
                    int num = action2.SetOderStatus1(guid, 3, 1, 2, DateTime.Now);
                    string strMemLoginId = dt.Rows[0]["MemloginID"].ToString();
                    string strMobile = Common.Common.GetNameById("Mobile", "shopnum1_member",
                        " and memloginid='" + strMemLoginId + "'");
                    IsMMS(guid, strMobile, strMemLoginId, payprice.ToString());
                    if (num > 0)
                    {
                        switch (str5)
                        {
                            case "线下支付":
                            case "货到付款":
                                action4.UpdateStock(guid);
                                break;
                        }
                        var action6 =
                            (ShopNum1_OrderOperateLog_Action) LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                        var orderOperateLog = new ShopNum1_OrderOperateLog
                        {
                            Guid = Guid.NewGuid(),
                            OrderInfoGuid = new Guid(guid),
                            CreateUser = memberloginid,
                            OderStatus = 3,
                            ShipmentStatus = 2,
                            PaymentStatus = 1,
                            CurrentStateMsg = "买家已消费,交易完成",
                            NextStateMsg = "等待买家评价",
                            Memo = "",
                            OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            IsDeleted = 0
                        };
                        action6.Add(orderOperateLog);
                    }
                    BindData();
                    MessageBox.Show("该验证码已被成功消费!");
                }
            }
        }

        protected void btnViewDetail_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            string strCode = txtLifeCode.Value;
            dt = action.GetOrderInfoByCode(hidShopMemloginId.Value, strCode);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("该验证码不是当前商户的验证码!");
            }
            else if (dt.Rows[0]["oderstatus"].ToString() == "3")
            {
                MessageBox.Show("该验证码已在【" + dt.Rows[0]["receipttime"] + "】被使用了!");
            }
            else if (Convert.ToInt32(dt.Rows[0]["oderstatus"].ToString()) == 3)
            {
                MessageBox.Show("该订单已经交易完成!");
            }
            else if (Convert.ToInt32(dt.Rows[0]["oderstatus"].ToString()) > 3)
            {
                MessageBox.Show("该订单已经关闭!");
            }
            else
            {
                repOrderInfo.DataSource = dt.DefaultView;
                repOrderInfo.DataBind();
                btnSure.Visible = true;
                BindData();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            btnSure = (Button) skin.FindControl("btnSure");
            btnSure.Click += btnSure_Click;
            btnViewDetail = (Button) skin.FindControl("btnViewDetail");
            btnViewDetail.Click += btnViewDetail_Click;
            content = (HtmlGenericControl) skin.FindControl("content");
            hidShopMemloginId = (HtmlInputHidden) skin.FindControl("hidShopMemloginId");
            hidSuccesslifeorder = (HtmlInputHidden) skin.FindControl("hidSuccesslifeorder");
            hidWaitlifeorder = (HtmlInputHidden) skin.FindControl("hidWaitlifeorder");
            txtLifeCode = (HtmlInputText) skin.FindControl("txtLifeCode");
            repOrderInfo = (Repeater) skin.FindControl("repOrderInfo");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void IsMMS(string guid, string strMobile, string strMemLoginId, string strPayMoney)
        {
            var action1 = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            string str = "0610a526-229e-4075-b084-3b6a5b929759";
            IShopNum1_MMS_Action action = LogicFactory.CreateShopNum1_MMS_Action();
            DataTable editInfo = action.GetEditInfo(str, 0);
            if (editInfo.Rows.Count != 0)
            {
                ShopNum1_MMSGroupSend send;
                string content = editInfo.Rows[0]["Remark"].ToString();
                string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                content =
                    content.Replace("{$Name}", strMemLoginId)
                        .Replace("{$PayMoney}", strPayMoney)
                        .Replace("{$SendTime}", DateTime.Now.ToString("MM月dd日"));
                var sms = new SMS();
                string retmsg = "";
                sms.Send(strMobile, content + "【唐江宝宝】", out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    send = AddMMS(strMemLoginId, strMobile, mMsTitle, 2, str.Replace("'", ""));
                    action.AddMMSGroupSend(send);
                }
                else
                {
                    send = AddMMS(strMemLoginId, strMobile, mMsTitle, 0, str.Replace("'", ""));
                    action.AddMMSGroupSend(send);
                }
            }
        }

        protected void BindData()
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                if (cookie2.Values["MemberType"] != "2")
                {
                    content.Visible = false;
                }
                else
                {
                    string strMemLoginID = cookie2.Values["MemLoginID"];
                    hidShopMemloginId.Value = strMemLoginID;
                    DataTable lifeOrderCount =
                        ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).GetLifeOrderCount(
                            strMemLoginID);
                    if (lifeOrderCount.Rows.Count > 0)
                    {
                        hidSuccesslifeorder.Value = lifeOrderCount.Rows[0]["success"].ToString();
                        hidWaitlifeorder.Value = lifeOrderCount.Rows[0]["wait"].ToString();
                    }
                }
            }
            else
            {
                content.Visible = false;
            }
        }
    }
}