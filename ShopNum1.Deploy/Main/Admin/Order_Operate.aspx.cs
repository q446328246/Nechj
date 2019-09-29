using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Order_Operate : PageBase, IRequiresSessionState
    {
        protected const string Order_List = "Order_List.aspx";
        protected const string Order_Operate_10 = "Order_Operate_10.aspx";
        protected const string Order_Operate_2 = "Order_Operate_2.aspx";
        protected const string Order_Operate_4 = "Order_Operate_4.aspx";
        protected const string Order_Operate_5 = "Order_Operate_5.aspx";
        protected const string Order_Operate_6 = "Order_Operate_6.aspx";
        protected const string Order_Operate_8 = "Order_Operate_8.aspx";
        protected const string Order_Operate_9 = "Order_Operate_9.aspx";
        protected const string OrderInfo_Report = "OrderInfo_Report.aspx";
        private readonly string string_11 = string.Empty;
        public DataTable dataTableOrderInfo = null;
        public DataTable dt_OrderOperate = null;
        private string string_10 = string.Empty;

        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;
        public string OrganizGuid { get; set; }

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state)
        {
            return new ShopNum1_EmailGroupSend
                {
                    Guid = Guid.NewGuid(),
                    EmailTitle = string_11,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    EmailGuid = new Guid("7C367402-4219-46B7-BC48-72CF48F6A836"),
                    SendObjectEmail = email,
                    SendObject = memLoginID + "-" + email,
                    State = state
                };
        }

        public void AdvancePaymentModify(string MemLoginID, string shopid, string orderguid,
                                         string productguid)
        {
            var action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
            if (action.RefundUpdateAdvancePaymentMem_two(MemLoginID, shopid, orderguid, productguid, 3) > 0)
            
            {
                MessageBox.Show("退款成功！");
                GetOrderInfo();
            }
            else
            {
                MessageBox.Show("退款失败！");
            }
        }

        public void AdvancePaymentModifyLog(int OperateType, string ordernumber, decimal payMoney, string Memo,
                                            string shopMemloginID, int type)
        {
            if (type == 1)
            {

                var orderInfoByGuid_two =
            ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action());
                DataTable orderRefund = orderInfoByGuid_two.SelectOrderRefund(ordernumber);
                DataTable memloginAll = orderInfoByGuid_two.SelectShopNum1_Member(shopMemloginID);
                string TJmid = orderRefund.Rows[0]["reduce_score_tjid"].ToString();
                DataTable memloginTJ = orderInfoByGuid_two.SelectShopNum1_Member(TJmid);
                string RefundType = orderRefund.Rows[0]["RefundType"].ToString();
                if (RefundType == "0")
                {
                    orderInfoByGuid_two.UpdateRefunType(ordernumber);
                    var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                    {
                        Guid = Guid.NewGuid(),
                        OperateType = OperateType,
                        CurrentAdvancePayment = Convert.ToDecimal(memloginAll.Rows[0]["AdvancePayment"]),
                        OperateMoney = Convert.ToDecimal(orderRefund.Rows[0]["PaymentPrice"])

                    };



                    decimal reduce_score_dv = Convert.ToDecimal(orderRefund.Rows[0]["reduce_score_dv"]);
                    decimal Score_dv = Convert.ToDecimal(orderRefund.Rows[0]["Score_dv"]);
                    decimal Score_pv_b = Convert.ToDecimal(orderRefund.Rows[0]["Score_pv_b"]);
                    decimal reduce_score_pv_b = Convert.ToDecimal(orderRefund.Rows[0]["reduce_score_pv_b"]);
                    //Score_hv  +    reduce_score_pv_a -
                    decimal Score_hv = Convert.ToDecimal(orderRefund.Rows[0]["Score_hv"]);
                    decimal reduce_Score_hv = Convert.ToDecimal(orderRefund.Rows[0]["reduce_Score_hv"]);
                    decimal Score_pv_a = Convert.ToDecimal(orderRefund.Rows[0]["Score_pv_a"]);
                    decimal reduce_score_pv_a = Convert.ToDecimal(orderRefund.Rows[0]["reduce_score_pv_a"]);
                    decimal PaymentPrice = Convert.ToDecimal(orderRefund.Rows[0]["PaymentPrice"]);
                    decimal Score_pv_cv = Convert.ToDecimal(orderRefund.Rows[0]["Score_pv_cv"]);
                    decimal reduce_core_pv_cv = Convert.ToDecimal(orderRefund.Rows[0]["reduce_score_pv_cv"]);
                    decimal reduce_score_tj_hv = Convert.ToDecimal(orderRefund.Rows[0]["reduce_score_tj_hv"]);
                    string reduce_tjid = orderRefund.Rows[0]["reduce_score_tjid"].ToString();



                    decimal Score_dv_memlogin = Convert.ToDecimal(memloginAll.Rows[0]["Score_dv"]);
                    decimal Score_pv_b_tj = 0;
                    decimal Score_hv_memlogin = Convert.ToDecimal(memloginAll.Rows[0]["Score_hv"]);
                    decimal Score_pv_a_tj = Convert.ToDecimal(memloginAll.Rows[0]["Score_pv_a"]);
                    decimal AdvancePayment_memlogin = Convert.ToDecimal(memloginAll.Rows[0]["AdvancePayment"]);
                    decimal Score_pv_cv_tj = 0;
                    decimal Score_hv_tj = 0;
                    //if (TJmid != null && TJmid != "")
                    //{
                    //    Score_pv_b_tj = Convert.ToDecimal(memloginTJ.Rows[0]["Score_pv_b"]);
                    //    Score_pv_a_tj = Convert.ToDecimal(memloginTJ.Rows[0]["Score_pv_a"]);
                    //    Score_pv_cv_tj = Convert.ToDecimal(memloginTJ.Rows[0]["Score_pv_cv"]);
                    //    Score_hv_tj = Convert.ToDecimal(memloginTJ.Rows[0]["Score_hv"]);
                    //}

                    #region


                    advancePaymentModifyLog.hv_guid = Guid.NewGuid();
                    advancePaymentModifyLog.YuanYou_hv = Score_hv_memlogin;
                    advancePaymentModifyLog.XiaoFei_hv = reduce_Score_hv;
                    advancePaymentModifyLog.XiaoFei_Hou_hv = Score_hv_memlogin - reduce_Score_hv;
                    advancePaymentModifyLog.XiaoFei_Mom = "退款成功所减少的";

                    advancePaymentModifyLog.hv_guid_two = Guid.NewGuid();
                    advancePaymentModifyLog.HuoDe_YuanYou_hv = Score_hv_memlogin;
                    advancePaymentModifyLog.HuoDe_hv = Score_hv;
                    advancePaymentModifyLog.Huo_DeHou_hv = Score_hv + Score_hv_memlogin;


                    advancePaymentModifyLog.pv_a_guid_two = Guid.NewGuid();
                    advancePaymentModifyLog.YuanYou_pv_a = Score_pv_a_tj;
                    advancePaymentModifyLog.XiaoFei_pv_a = reduce_score_pv_a;
                    advancePaymentModifyLog.XiaoFei_Hou_pv_a = Score_pv_a_tj - reduce_score_pv_a;
           

                    advancePaymentModifyLog.pv_a_guid = Guid.NewGuid();
                    advancePaymentModifyLog.HuoDe_YuanYou_pv_a = Score_pv_a_tj;
                    advancePaymentModifyLog.HuoDe_pv_a = Score_pv_a;
                    advancePaymentModifyLog.Huo_DeHou_pv_a = Score_pv_a_tj + Score_pv_a;
                    advancePaymentModifyLog.HuoDe_Mom = "退款成功所增加的";


                    advancePaymentModifyLog.pv_b_guid_two = Guid.NewGuid();
                    advancePaymentModifyLog.YuanYou_pv_b = Score_pv_b_tj;
                    advancePaymentModifyLog.XiaoFei_pv_b = reduce_score_pv_b;
                    advancePaymentModifyLog.XiaoFei_Hou_pv_b = Score_pv_b_tj - reduce_score_pv_b;



                    advancePaymentModifyLog.HuoDe_dv_Guid = Guid.NewGuid();
                    advancePaymentModifyLog.HuoDe_YuanYou_dv = Score_dv_memlogin;
                    advancePaymentModifyLog.HuoDe_dv = reduce_score_dv;
                    advancePaymentModifyLog.HuoDe_Hou_dv = Score_dv_memlogin - reduce_score_dv;
                    #endregion
                    //需要加dv

                    advancePaymentModifyLog.DeDao_guid_Hou_dv = Guid.NewGuid();
                    advancePaymentModifyLog.DeDao_Qian_dv = Score_dv_memlogin;
                    advancePaymentModifyLog.DeDao_dv = Score_dv;
                    advancePaymentModifyLog.DeDao_Hou_dv = Score_dv_memlogin + Score_dv;

                    //需要增加pv_b
                    advancePaymentModifyLog.pv_b_guid = Guid.NewGuid();
                    advancePaymentModifyLog.HuoDe_YuanYou_pv_b = Score_pv_b_tj;
                    advancePaymentModifyLog.HuoDe_pv_b = Score_pv_b;
                    advancePaymentModifyLog.Huo_DeHou_pv_b = Score_pv_b_tj + Score_pv_b;

                    //增加cv
                    advancePaymentModifyLog.DeDao_guid_Hou_cv = Guid.NewGuid();
                    advancePaymentModifyLog.DeDao_Qian_cv = Score_pv_cv_tj;
                    advancePaymentModifyLog.DeDao_cv = Score_pv_cv;
                    advancePaymentModifyLog.DeDao_Hou_cv = Score_pv_cv_tj + Score_pv_cv;

                    //减少cv
                    advancePaymentModifyLog.DeDao_guid_Hou_cv = Guid.NewGuid();
                    advancePaymentModifyLog.DeDao_Qian_cv = Score_pv_cv_tj;
                    advancePaymentModifyLog.DeDao_cv = reduce_core_pv_cv;
                    advancePaymentModifyLog.DeDao_Hou_cv = Score_pv_cv_tj - reduce_core_pv_cv;



                    //advancePaymentModifyLog.LastOperateMoney = AdvancePayment_memlogin + PaymentPrice;
                    //advancePaymentModifyLog.OperateType = 1;

                    //else
                    //{
                    //    advancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
                    //    advancePaymentModifyLog.OperateType = 6;
                    //}
                    advancePaymentModifyLog.Date = DateTime.Now;
                    advancePaymentModifyLog.Memo = Memo;
                    advancePaymentModifyLog.MemLoginID = shopMemloginID;
                    advancePaymentModifyLog.CreateUser = shopMemloginID;
                    advancePaymentModifyLog.CreateTime = DateTime.Now;
                    advancePaymentModifyLog.IsDeleted = 0;
                    advancePaymentModifyLog.LastOperateMoney = AdvancePayment_memlogin + PaymentPrice;
                    if (advancePaymentModifyLog.HuoDe_pv_a != 0) 
                    {
                        advancePaymentModifyLog.Score_pv_a = Score_pv_a_tj + Score_pv_a;
                    }
                    else
                    {
                        advancePaymentModifyLog.Score_pv_a = Score_pv_a_tj - reduce_score_pv_a;
                    }
                    advancePaymentModifyLog.Score_hv = Score_hv_memlogin + Score_hv - reduce_Score_hv;
                    advancePaymentModifyLog.Score_dv = Score_dv_memlogin + Score_dv - reduce_score_dv;
                    advancePaymentModifyLog.Score_pv_b = Score_pv_b + Score_pv_b_tj - reduce_score_pv_b;
                    advancePaymentModifyLog.Score_pv_c = Score_pv_cv_tj + Score_pv_cv - reduce_core_pv_cv;
                    if (reduce_tjid == shopMemloginID)
                    {
                        advancePaymentModifyLog.TJScore_hv = Score_hv_memlogin + Score_hv - reduce_Score_hv;
                    }
                    else
                    {
                        advancePaymentModifyLog.TJScore_hv = Score_hv_tj - reduce_score_tj_hv;
                        advancePaymentModifyLog.TJ_hv_guid = Guid.NewGuid();
                        advancePaymentModifyLog.TJ_YuanYou_hv = Score_hv_tj;
                        advancePaymentModifyLog.TJ_XiaoFei_hv = reduce_score_tj_hv;
                        advancePaymentModifyLog.TJ_XiaoFei_Hou_hv = Score_hv_tj - reduce_score_tj_hv;
                        advancePaymentModifyLog.XiaoFei_Mom = "退款成功所减少的";
                    }
                    advancePaymentModifyLog.TJmemID = reduce_tjid;




                    ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                        .OperateMoney_TJ(advancePaymentModifyLog);
                    
                    //}
                }
                else 
                {
                    return;
                }
            }
        }

        protected void ButtonAdminAgreed_Click(object sender, EventArgs e)
        {
            DataTable table =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).Search(
                    hiddenFieldGuid.Value);
            if (table.Rows.Count > 0)
            {
                string str = hidRefundMoney.Value;
                string productguid = hidProductGuId.Value;
                string memLoginID = table.Rows[0]["MemLoginID"].ToString();
                string shopid = table.Rows[0]["ShopID"].ToString();
                string orderNumber = table.Rows[0]["Ordernumber"].ToString();
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).SetWaitBuyerPay("4", "0",
                                                                                                             "1",
                                                                                                             hiddenFieldGuid
                                                                                                                 .Value);
                #region 元逻辑
                //string str5 = Common.Common.GetNameById("advancepayment", "shopnum1_member",
                //                                        " and memloginid='" + memLoginID + "'");
                //string str6 = Common.Common.GetNameById("advancepayment", "shopnum1_member",
                //                                        " and memloginid='" + shopid + "'");
                //AdvancePaymentModify(memLoginID, shopid, Convert.ToDecimal(str), hiddenFieldGuid.Value, productguid);
                //decimal num = Convert.ToDecimal(LabelOrderPriceValue.Text);
                //if (!string.IsNullOrEmpty(str5))
                //{
                //    AdvancePaymentModifyLog(5, Convert.ToDecimal(str5), Convert.ToDecimal(str), "平台介入退款成功增加买家金币（BV）",
                //                            memLoginID, 1);
                //    if (num > Convert.ToDecimal(str))
                //    {
                //        decimal payMoney = num - Convert.ToDecimal(str);
                //        AdvancePaymentModifyLog(5, Convert.ToDecimal(str6), payMoney, "平台介入退款成功剩余金额打给卖家", shopid, 1);
                //    }
                //}
                #endregion
                //AdvancePaymentModify(memLoginID, shopid, Convert.ToDecimal(str), hiddenFieldGuid.Value, productguid);
                AdvancePaymentModifyLog(5, orderNumber, Convert.ToDecimal(str), "平台介入退款成功增加买家金币（BV）",
                                            memLoginID, 1);
                var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                DataTable tablemember = memaction.SearchMembertwo(memLoginID);

                
                if (tablemember.Rows[0]["MemberRankGuid"].ToString().ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper() && table.Rows[0]["shop_category_id"].ToString() == "9")
                {
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).Update_5XCV(shopid, Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                }
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).UpdateOrderState(orderNumber, "4", "3", "2");

                AdvancePaymentModify(memLoginID, shopid, hiddenFieldGuid.Value, productguid);

                ((ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action()).UpdateReduceStock(
                    hiddenFieldGuid.Value, "1");
                var action4 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                var orderOperateLog = new ShopNum1_OrderOperateLog
                    {
                        Guid = Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hiddenFieldGuid.Value),
                        CreateUser = memLoginID,
                        OderStatus = 2,
                        ShipmentStatus = 1,
                        PaymentStatus = 1,
                        CurrentStateMsg = "平台介入同意退款",
                        NextStateMsg = "无",
                        Memo = "",
                        OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                action4.Add(orderOperateLog);
            }
            Page.Response.Redirect("Order_Operate.aspx?guid=" + hiddenFieldGuid.Value);
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (hiddenFieldType.Value == "1")
            {
                base.Response.Redirect("Order_List.aspx");
            }
            else if (hiddenFieldType.Value == "2")
            {
                base.Response.Redirect("OrderSpell_List.aspx");
            }
            else if (hiddenFieldType.Value == "3")
            {
                base.Response.Redirect("OrderPanic_List.aspx");
            }
            else
            {
                base.Response.Redirect("Order_List.aspx");
            }
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrderInfo_Report.aspx?OrderNumber=" + LabelOrderNumberValue.Text);
        }

        public string ChangeOderStatus(string oderStatus, string strFeeType)
        {
            if (oderStatus == "0")
            {
                return "等待买家付款";
            }
            if (oderStatus == "1")
            {
                if (strFeeType == "2")
                {
                    return "等待买家消费";
                }
                return "等待卖家发货";
            }
            if (oderStatus == "2")
            {
                if (strFeeType == "2")
                {
                    return "等待卖家确认";
                }
                return "等待买家确认收货";
            }
            if (oderStatus == "3")
            {
                return "交易成功";
            }
            if (oderStatus == "4")
            {
                return "系统关闭订单";
            }
            if (oderStatus == "5")
            {
                return "卖家关闭订单";
            }
            if (oderStatus == "6")
            {
                return "买家关闭订单";
            }
            return "非法状态";
        }

        public string ChangePaymentStatus(string paymentStatus)
        {
            if (paymentStatus == "0")
            {
                return "未付款";
            }
            if (paymentStatus == "1")
            {
                return "已付款";
            }
            if (paymentStatus == "2")
            {
                return "退款成功";
            }
            if (paymentStatus == "3")
            {
                return "卖家拒绝退款";
            }
            return "非法状态";
        }

        public string ChangeShipmentStatus(string shipmentStatus)
        {
            if (shipmentStatus == "0")
            {
                return "未发货";
            }
            if (shipmentStatus == "1")
            {
                return "已发货";
            }
            if (shipmentStatus == "2")
            {
                return "已收货";
            }
            if (shipmentStatus == "3")
            {
                return "退货";
            }
            return "非法状态";
        }

        protected int CheckMember()
        {
            int num = 0;
            try
            {
                var guid = new Guid(LabelMemLoginIDValue.Text);
            }
            catch
            {
                num = 1;
            }
            return num;
        }

        protected void GetAllProductWeight()
        {
            DataTable orderProductGuidAndByNumber =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action())
                    .GetOrderProductGuidAndByNumber(LabelOrderNumberValue.Text);
            var action2 = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
            HiddenFieldAllWeight.Value = "0.00";
            for (int i = 0; i < orderProductGuidAndByNumber.Rows.Count; i++)
            {
                string guid = orderProductGuidAndByNumber.Rows[i]["ProductGuid"].ToString();
                string str2 = orderProductGuidAndByNumber.Rows[i]["BuyNumber"].ToString();
                string weight = action2.GetWeight(guid);
                HiddenFieldAllWeight.Value =
                    Convert.ToString((Convert.ToDecimal(HiddenFieldAllWeight.Value) +
                                      (Convert.ToDecimal(str2) * Convert.ToDecimal(weight))));
            }
        }

        protected void GetEmailSetting()
        {
            var settings = new ShopSettings();
            string_4 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailServer"));
            string_5 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
            string_7 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "ServerPort"));
            string_6 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailAccount"));
            string_8 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailPassword"));
            string_9 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "RestoreEmail"));
            string_10 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailCode"));
        }

        protected void GetOrderInfo()
        {
            DataSet set =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderDetail(
                    hiddenFieldGuid.Value, "0", "0", "0");
            if ((set != null) && (set.Tables.Count == 4))
            {
                dataTableOrderInfo = set.Tables[0];
                if (dataTableOrderInfo.Rows.Count == 0)
                {
                    dataTableOrderInfo = null;
                }
                else
                {
                    dt_OrderOperate = set.Tables[2];
                    if (dt_OrderOperate.Rows.Count == 0)
                    {
                        dt_OrderOperate = null;
                    }
                    LabelOrderNumberValue.Text = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                    string str3 = string.Empty;
                    str3 = ChangeOderStatus(dataTableOrderInfo.Rows[0]["OderStatus"].ToString(),
                                            dataTableOrderInfo.Rows[0]["feetype"].ToString());
                    LabelOderStatusValue.Text = str3;
                    LabelCreateTimeValue.Text = dataTableOrderInfo.Rows[0]["CreateTime"].ToString();
                    LabelPaymentNameValue.Text = dataTableOrderInfo.Rows[0]["PaymentName"].ToString();
                    LabelPayTimeValue.Text = dataTableOrderInfo.Rows[0]["PayTime"].ToString();
                    if (Convert.ToInt32(dataTableOrderInfo.Rows[0]["OderStatus"].ToString()) > 1)
                    {
                        if (dataTableOrderInfo.Rows[0]["DispatchType"].ToString() == "1")
                        {
                            LabelDispatchModeNameValue.Text = "平邮";
                        }
                        else if (dataTableOrderInfo.Rows[0]["DispatchType"].ToString() == "2")
                        {
                            LabelDispatchModeNameValue.Text = "快递";
                        }
                        else
                        {
                            LabelDispatchModeNameValue.Text = "买家自提货";
                        }
                    }
                    LabelDispatchTimeValue.Text = dataTableOrderInfo.Rows[0]["DispatchTime"].ToString();
                    LabelShipmentNumberValue.Text = dataTableOrderInfo.Rows[0]["ShipmentNumber"].ToString();
                    LabelFromUrlValue.Text = dataTableOrderInfo.Rows[0]["FromUrl"].ToString();
                    LabelInvoiceTypeValue.Text = dataTableOrderInfo.Rows[0]["InvoiceType"].ToString();
                    LabelInvoiceTitleValue.Text = dataTableOrderInfo.Rows[0]["InvoiceTitle"].ToString();
                    LabelInvoiceContentValue.Text = dataTableOrderInfo.Rows[0]["InvoiceContent"].ToString();
                    LabelClientToSellerMsgValue.Text = dataTableOrderInfo.Rows[0]["ClientToSellerMsg"].ToString();
                    LabelOutOfStockOperateValue.Text = dataTableOrderInfo.Rows[0]["OutOfStockOperate"].ToString();
                    LabelSellerToClientMsgValue.Text = dataTableOrderInfo.Rows[0]["SellerToClientMsg"].ToString();
                    LabelNameValue.Text = dataTableOrderInfo.Rows[0]["Name"].ToString();
                    LabelEmailValue.Text = dataTableOrderInfo.Rows[0]["Email"].ToString();
                    LabelAddressValue.Text = dataTableOrderInfo.Rows[0]["Address"].ToString();
                    LabelPostalcodeValue.Text = dataTableOrderInfo.Rows[0]["Postalcode"].ToString();
                    LabelTelValue.Text = dataTableOrderInfo.Rows[0]["Tel"].ToString();
                    LabelMobileValue.Text = dataTableOrderInfo.Rows[0]["Mobile"].ToString();
                    LabelProductPriceValue.Text = dataTableOrderInfo.Rows[0]["ProductPrice"].ToString();
                    LabelDiscountValue.Text = dataTableOrderInfo.Rows[0]["Discount"].ToString();
                    LabelInvoiceTaxValue.Text = dataTableOrderInfo.Rows[0]["InvoiceTax"].ToString();
                    LabelDispatchPriceValue.Text = dataTableOrderInfo.Rows[0]["DispatchPrice"].ToString();
                    LabelPaymentPriceValue.Text = dataTableOrderInfo.Rows[0]["PaymentPrice"].ToString();
                    LabelJiFenAText.Text = dataTableOrderInfo.Rows[0]["Score_pv_a"].ToString();
                    LabelJiFenBText.Text = (Convert.ToDecimal(dataTableOrderInfo.Rows[0]["Score_pv_b"]) - Convert.ToDecimal(dataTableOrderInfo.Rows[0]["Offset_pv_b"])).ToString();
                    LabelKouHV.Text = dataTableOrderInfo.Rows[0]["Offset_pv_b"].ToString();
                    if (dataTableOrderInfo.Rows[0]["paymentmemloginid"].ToString() == "admin")
                    {
                        LabelPaymentPriceValue.Text = dataTableOrderInfo.Rows[0]["PaymentPrice"].ToString();
                    }
                    else
                    {
                        LabelPaymentPriceValue.Text =
                            (((((Convert.ToDecimal(LabelProductPriceValue.Text) +
                                 Convert.ToDecimal(LabelDiscountValue.Text)) +
                                Convert.ToDecimal(LabelInvoiceTaxValue.Text)) +
                               Convert.ToDecimal(LabelDispatchPriceValue.Text)) *
                              Convert.ToDecimal(dataTableOrderInfo.Rows[0]["PaymentPrice"].ToString())) / 100M).ToString();
                    }
                    LabelShopIDValue.Text = dataTableOrderInfo.Rows[0]["ShopID"].ToString();
                    LabelShopNameValue.Text = dataTableOrderInfo.Rows[0]["ShopName"].ToString();
                    LabelMemLoginIDValueShow.Text = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                    LabelMemLoginIDValue.Text = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                    string orderPrice = "0";
                    orderPrice = LabelProductPriceValue.Text + "-" + LabelDiscountValue.Text + "+" +
                                 LabelInvoiceTaxValue.Text + "+" + LabelDispatchPriceValue.Text + "+" +
                                 LabelPaymentPriceValue.Text;
                    LabelOrderPriceValue.Text =
                        ((ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action()).ComputeOderPrice(
                            orderPrice);
                    LabelUseScoreValue.Text = dataTableOrderInfo.Rows[0]["UseScore"].ToString();
                    HiddenFieldDeposit.Value = dataTableOrderInfo.Rows[0]["Deposit"].ToString();
                    HiddenFieldBuyType.Value = dataTableOrderInfo.Rows[0]["BuyType"].ToString();
                    HiddenFieldActivityGuid.Value = dataTableOrderInfo.Rows[0]["ActivityGuid"].ToString();
                    if (!(HiddenFieldBuyType.Value == "0") && !(HiddenFieldBuyType.Value == "1"))
                    {
                    }
                    DataTable refund =
                        ((ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action()).GetRefund(
                            hiddenFieldGuid.Value);
                    if ((refund != null) && (refund.Rows.Count > 0))
                    {
                        hidRefundMoney.Value = refund.Rows[0]["RefundMoney"].ToString();
                        hidProductGuId.Value = refund.Rows[0]["ProductGuid"].ToString();
                        hidOnPassReason.Value = refund.Rows[0]["OnPassReason"].ToString();
                        hidRefundImg.Value = refund.Rows[0]["OnPassImg"].ToString();
                        hidrefundstatus.Value = refund.Rows[0]["refundstatus"].ToString();
                        hidRefundType.Value = refund.Rows[0]["RefundType"].ToString();
                        LabelShopNotAgreedRefundValue.Text = hidOnPassReason.Value;
                        LabelOrderRefundStatusValue.Text = RefundStatus(hidrefundstatus.Value, hidRefundType.Value);
                        imgRefund.Visible = true;
                        imgRefund.Src = hidRefundImg.Value;
                    }

                    var orderInfoByGuid_two =((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action());
                    DataTable orderRefund = orderInfoByGuid_two.ststus(hiddenFieldGuid.Value);
                    int shop_category_id = Convert.ToInt32(orderRefund.Rows[0]["shop_category_id"]);
                    int OderStatus = Convert.ToInt32(orderRefund.Rows[0]["OderStatus"]);
                    if (shop_category_id == 5 && OderStatus == 0)
                    {
                        
                        this.butto1.Style["display"] = "block";
                    }
                    

                }
            }
        }

        protected void GetOrderProduct()
        {
            if (dataTableOrderInfo != null)
            {
                Num1GridViewShowOrderProduct.DataSource = dataTableOrderInfo.DefaultView;
                Num1GridViewShowOrderProduct.DataBind();
            }
        }

        protected void GetOrderProductRepeter()
        {
            if (dataTableOrderInfo != null)
            {
                RepeaterData.DataSource = dataTableOrderInfo.DefaultView;
                RepeaterData.DataBind();
            }
        }

        private void method_5(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField)e.Item.FindControl("HiddenFieldIsImage");
                var image = (Image)e.Item.FindControl("ImageUrl");
                var label = (Label)e.Item.FindControl("LabelValue");
                if (field.Value == "True")
                {
                    label.Visible = false;
                }
                else
                {
                    image.Visible = false;
                }
            }
        }

        private string method_6(string string_13)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_13);
            try
            {
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        protected void Num1GridViewShowOrderProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = "1000";
            }
            if ((e.Row.RowType == DataControlRowType.DataRow) || (e.Row.RowType == DataControlRowType.Header))
            {
                e.Row.Cells[9].Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            hiddenFieldType.Value = (Page.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"];
            GetOrderInfo();
            GetOrderProduct();
            GetOrderProductRepeter();
        }

        protected string RefundStatus(string status, string rtype)
        {
            string str = "退款";
            if (rtype == "1")
            {
                str = "退货";
            }
            switch (status)
            {
                case "0":
                    ButtonAdminAgreed.Visible = true;
                    return (str + "申请等待卖家确认中");

                case "1":
                    return (str + "成功");

                case "2":
                    ButtonAdminAgreed.Visible = true;
                    return ("卖家拒绝" + str);

                case "3":
                    return ("平台介入" + str + "成功");
            }
            return "";
        }
        protected void ButtonBack_Click1(object sender, EventArgs e)
        {
            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string EnterName = cookie2.Values["LoginID"];
            decimal LabelOrderPriceValue = Convert.ToDecimal(this.LabelOrderPriceValue.Text);
            string LabelOrderNumberValue = this.LabelOrderNumberValue.Text;
            string LabelMemLoginIDValueShow = this.LabelMemLoginIDValueShow.Text;
            var orderInfoByGuid_two = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()); 
            int b = orderInfoByGuid_two.insertcomputer(hiddenFieldGuid.Value, EnterName, LabelOrderPriceValue, LabelOrderNumberValue, LabelMemLoginIDValueShow);
            if ( b>0)
            {
                GetOrderInfo();
                Response.Write("<script>alert('修改成功')</script>");
               
            }

        }
    }
}