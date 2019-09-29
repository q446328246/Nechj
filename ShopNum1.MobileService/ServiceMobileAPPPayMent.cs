using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1.Payment;
using ShopNum1MultiEntity;
using ShopNum1.Interface;
using ShopNum1.Email;
using ShopNum1.Standard;

namespace ShopNum1.MobileService
{
    public class ServiceMobileAPPPayMent : BaseUserControl
    {
        //充值链接
        public string MobileServiceRecharge(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog)
        {
            ShopNum1_AdvancePaymentApplyLog_Action action =
                     (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            if (action.ApplyOperateMoney(advancePaymentApplyLog) > 0)
            {
                string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                string url = new PayUrlOperate().GetPayUrl(advancePaymentApplyLog.PaymentGuid.ToString(), advancePaymentApplyLog.OperateMoney.ToString().Trim(), ShopSettings.siteDomain + "/main/account/A_Index.aspx", "充值", advancePaymentApplyLog.OrderNumber, "Recharge", "0", "admin", advancePaymentApplyLog.MemLoginID, timetemp);
                if (url.Length > 0x3e8)
                {
                    Encoding encoding;
                    if (url.Split(new[] { '|' })[0].IndexOf("UTF") != -1)
                    {
                        encoding = Encoding.UTF8;
                    }
                    else
                    {
                        encoding = Encoding.Default;
                    }
                    //Page.Response.ContentEncoding = encoding;
                    //Page.Response.Write(url.Split(new[] { '|' })[1]);
                }
                else if (advancePaymentApplyLog.PaymentName != "线下支付")
                {

                    return url;
                }
                else
                {

                    return "线下支付提交成功，请及时汇款";
                }
            }


            return "充值失败";

        }
        //智付链接 ShouldPay订单金额  Score_dv订单重销币  Deduction_pv_b订单使用红包  memloginID买家ID  OrderNumber订单编号
        public string Dinpay(decimal ShouldPay, decimal Score_dv, string OrderNumber, decimal Deduction_pv_b, string memloginID)
        {

            string PaymentGuid = "1075526A-7C28-44D0-B5F8-FD1B6746F662";

            string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
            var payUrlOperate = new PayUrlOperate();
            string payUrl = payUrlOperate.GetPayUrl(PaymentGuid, ShouldPay.ToString(),
                ShopSettings.siteDomain, Score_dv.ToString(), OrderNumber, Deduction_pv_b.ToString(), "1",
                memloginID, memloginID, timetemp);

            if (payUrl.Length > 1000)
            {
                Encoding contentEncoding;
                if (payUrl.Split(new[]
                {
                    '|'
                })[0].IndexOf("UTF") != -1)
                {
                    contentEncoding = Encoding.UTF8;
                }
                else
                {
                    contentEncoding = Encoding.Default;
                }
                //Page.Response.ContentEncoding = contentEncoding;
                //Page.Response.Write(payUrl.Split(new[]
                //{
                //    '|'
                //})[1]);
            }



            return payUrl;


        }
        //金币支付
        public string BVpay(string OrderNumber, decimal ShouldPay, decimal ShouldDv, decimal Deduction_pv_b, string memloginID)
        {



            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
                                                    (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            try
            {
                DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(OrderNumber);
                shopNum1_OrderInfo_Action.UpdateOrderSYhv(OrderNumber, Deduction_pv_b);
                if (orderGuIdByTradeId.Rows.Count > 0)
                {

                    MoneyModifyLog("金币（BV）支付", OrderNumber, memloginID, ShouldPay, ShouldDv, Deduction_pv_b);
                    shopNum1_OrderInfo_Action.UpdateOrderStateTJ(OrderNumber, memloginID, ShouldPay, DateTime.Now);

                    OrderOperateLog("金币（BV）支付", orderGuIdByTradeId.Rows[0]["guid"].ToString(),
                                    orderGuIdByTradeId.Rows[0]["feeType"].ToString(), memloginID);
                    for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                    {
                        string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
    " and memloginid='" + orderGuIdByTradeId.Rows[i]["MemloginId"].ToString() + "'");

                        string nameById422212222 = Common.Common.GetNameById("mobile", "shopnum1_member",
    " and memloginid='" + orderGuIdByTradeId.Rows[i]["ShopID"].ToString() + "'");

                        var shopNum1_OrderProduct_Action =
                            (ShopNum1_OrderProduct_Action)
                            LogicFactory.CreateShopNum1_OrderProduct_Action();
                        shopNum1_OrderProduct_Action.UpdateStock(
                            orderGuIdByTradeId.Rows[i]["guid"].ToString());
                        if (orderGuIdByTradeId.Rows[i]["FeeType"].ToString() == "2")
                        {
                            IsMMS(nameById42221,
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
                                     nameById42221);
                            if (orderGuIdByTradeId.Rows[i]["ShopID"].ToString() != "C0000001")
                            {
                                method_3("卖家" + orderGuIdByTradeId.Rows[i]["ShopID"].ToString(),
                                         orderGuIdByTradeId.Rows[i]["ordernumber"].ToString() + "(您所卖出的)",
                                         orderGuIdByTradeId.Rows[i]["ShopID"].ToString(),
                                         nameById422212222);
                            }
                        }
                    }
                }

                return "支付成功";
            }
            catch (Exception ex)
            {


                return "支付失败";
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
        protected void MoneyModifyLog(string memo, string OrderNumber, string memloginID, decimal ShouldPay, decimal ShouldDv, decimal Deduction_pv_b)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
                                            (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

            var shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action2.GetOrderGuIdByTradeId(OrderNumber);

            #region 退款记录

            decimal GZ_Score_hv = 0M;
            decimal GZ_Score_pv_a = 0M;
            decimal GZ_Score_pv_b = 0M;
            decimal GZ_Score_pv_cv = 0M;
            decimal GZ_Score_dv = 0M;
            decimal GZ_PaymentPrice = 0M;
            decimal GZ_reduce_score_hv = 0M;
            decimal GZ_reduce_score_pv_a = 0M;
            decimal GZ_reduce_score_pv_b = 0M;
            decimal GZ_reduce_score_pv_cv = 0M;
            decimal GZ_reduce_score_dv = 0M;
            decimal GZ_reduce_PaymentPrice = 0M;
            decimal GZ_reduce_score_TJ_hv = 0M;
            string GZ_reduce_TJID;
            #endregion
            decimal MyScore_hv_txt = 0M;
            decimal MyScore_pv_a_txt = 0M;
            decimal MyScore_pv_b_txt = 0M;
            decimal MyScore_hv = 0M;
            decimal MyScore_pv_a = 0M;
            decimal MyScore_pv_b = 0M;
            decimal MyScore_pv_c = 0M;
            decimal MyScore_dv = 0M;


            decimal MYlabelScore_pv_cv_txt = 0M;
            decimal MYlabelScore_cv_txt = 0M;
            decimal MYlabelScore_max_hv_tx = 0M;
            for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
            {

                MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_hv"]);
                MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_a"]);
                MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_b"]);
                MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_pv_a"]);
                MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_hv"]);

                MYlabelScore_pv_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_cv"]);

            }



            DataSet dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(OrderNumber, memloginID);
            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);

            var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.hv_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_a_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.hv_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_a_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.HuoDe_dv_Guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.XiaoFei_guid_Hou_cv = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.DeDao_guid_Hou_cv = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_GUID = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.OperateType = 3;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]);
            shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(ShouldPay);
            shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]) -
                                                                Convert.ToDecimal(ShouldPay);
            #region 退款记录
            GZ_PaymentPrice = ShouldPay;
            #endregion
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            String Guidmem = member_Action.GetGuidByMemLoginID(memloginID);
            DataTable tableTJ = member_Action.SearchMemberGuid(Guidmem);
            string MemLoginIDno = tableTJ.Rows[0]["MemLoginNO"].ToString();
            #region 2015.7.25
            decimal TJScore_pv_a;
            decimal TJScore_pv_b;
            decimal TJScore_pv_c;
            decimal TJScore_hv;
            string TJID;
            int TJtype;
            #endregion
            if (MemLoginIDno.ToUpper().IndexOf("C") != -1)
            {
                TJtype = 1;
                TJScore_pv_a = MyScore_pv_a;
                TJScore_pv_b = MyScore_pv_b;
                TJScore_pv_c = MyScore_pv_c;
                TJScore_hv = MyScore_hv;
                TJID = memloginID;
            }
            else
            {

                TJtype = 0;
                if (tableTJ.Rows[0]["Superior"].ToString() != null && tableTJ.Rows[0]["Superior"].ToString() != "")
                {
                    String TJGuid1 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                    DataTable TJtable = member_Action.SearchMemberGuid(TJGuid1);

                    TJScore_pv_a = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_a"].ToString());
                    TJScore_pv_b = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_b"].ToString());
                    TJScore_pv_c = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_cv"].ToString());
                    TJScore_hv = Convert.ToDecimal(TJtable.Rows[0]["Score_hv"].ToString());
                    TJID = TJtable.Rows[0]["MemLoginID"].ToString();

                }
                else
                {
                    TJScore_pv_a = 0;
                    TJScore_pv_b = 0;
                    TJScore_pv_c = 0;
                    TJScore_hv = 0;
                    TJID = "";
                }
            }


            /*  shopNum1_AdvancePaymentModifyLog.Score_pv_a=MyScore_pv_a_txt+MyScore_pv_a;
              shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv_txt+ MyScore_hv;*/
            if (MyScore_dv >= ShouldDv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_dv = MyScore_dv - ShouldDv;
                #region 退款记录
                GZ_Score_dv = ShouldDv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = ShouldDv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = MyScore_dv - ShouldDv;
                #endregion
            }
            if (MyScore_dv < ShouldDv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_dv = 0;
                #region 退款记录
                GZ_Score_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = 0;
                #endregion

            }
            if (TJScore_pv_b > (MYlabelScore_cv_txt * (-1)) || TJScore_pv_b == (MYlabelScore_cv_txt * (-1)))
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - (MYlabelScore_cv_txt * (-1));
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c;
                #region 退款记录
                GZ_Score_pv_b = MYlabelScore_cv_txt * (-1);
                GZ_Score_pv_a = 0;
                GZ_Score_pv_cv = 0;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = (MYlabelScore_cv_txt * (-1));
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - (MYlabelScore_cv_txt * (-1));
                #endregion
            }
            if (TJScore_pv_b < (MYlabelScore_cv_txt * (-1)) && (TJScore_pv_a + TJScore_pv_b) >= (MYlabelScore_cv_txt * (-1)))
            {
                decimal poor = (MYlabelScore_cv_txt * (-1)) - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a - poor;
                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c;
                #region 退款记录
                GZ_Score_pv_b = TJScore_pv_b;
                GZ_Score_pv_a = poor;
                GZ_Score_pv_cv = 0;

                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - TJScore_pv_b;

                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a = poor;
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_a = TJScore_pv_a - poor;
                #endregion
            }
            if (TJScore_pv_b < (MYlabelScore_cv_txt * (-1)) && (TJScore_pv_a + TJScore_pv_b) < (MYlabelScore_cv_txt * (-1)))
            {
                decimal poor = (MYlabelScore_cv_txt * (-1)) - (TJScore_pv_b + TJScore_pv_a);
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a - TJScore_pv_a;

                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c - poor;


                shopNum1_AdvancePaymentModifyLog.XiaoFei_Qian_cv = TJScore_pv_c;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_cv = poor;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_cv = TJScore_pv_c - poor;

                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_a = TJScore_pv_a - TJScore_pv_a;

                //差个 pv b
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - TJScore_pv_b;



                #region 退款记录
                GZ_Score_pv_b = TJScore_pv_b;
                GZ_Score_pv_a = TJScore_pv_a;
                GZ_Score_pv_cv = poor;
                #endregion

            }
            if (MyScore_hv > Deduction_pv_b || MyScore_hv == Deduction_pv_b)
            {
                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - Deduction_pv_b;
                #region 退款记录
                GZ_Score_hv = Deduction_pv_b;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = Deduction_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - Deduction_pv_b;
                #endregion
            }
            if (MyScore_hv < Deduction_pv_b && MyScore_hv > -1)
            {

                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - MyScore_hv;
                #region 退款记录
                GZ_Score_hv = MyScore_hv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - MyScore_hv;
                #endregion
            }
            //获得hv
            decimal myHuoDe_YuanYou_hv = MyScore_hv;
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_hv = myHuoDe_YuanYou_hv;
            shopNum1_AdvancePaymentModifyLog.Score_hv = shopNum1_AdvancePaymentModifyLog.Score_hv + MyScore_hv_txt;
            GZ_reduce_score_hv = MyScore_hv_txt;
            //推荐人同时获得红包

            if (TJtype == 0)
            {
                shopNum1_AdvancePaymentModifyLog.TJScore_hv = TJScore_hv + MyScore_hv_txt;
                GZ_reduce_score_TJ_hv = MyScore_hv_txt;

                shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_YuanYou_hv = TJScore_hv;
                shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_hv = MyScore_hv_txt;
                shopNum1_AdvancePaymentModifyLog.TJ_Huo_DeHou_hv = TJScore_hv + MyScore_hv_txt;

            }
            else if (TJtype == 1)
            {
                shopNum1_AdvancePaymentModifyLog.TJScore_hv = shopNum1_AdvancePaymentModifyLog.Score_hv + 0;
                GZ_reduce_score_TJ_hv = 0;

            }

            shopNum1_AdvancePaymentModifyLog.HuoDe_hv = MyScore_hv_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_hv = myHuoDe_YuanYou_hv + MyScore_hv_txt;
            //获得pv_a
            decimal myHuoDe_YuanYou_pv_a = shopNum1_AdvancePaymentModifyLog.Score_pv_a;
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_a = myHuoDe_YuanYou_pv_a;

            shopNum1_AdvancePaymentModifyLog.Score_pv_a = shopNum1_AdvancePaymentModifyLog.Score_pv_a + MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Score_pv_c = shopNum1_AdvancePaymentModifyLog.Score_pv_c + MYlabelScore_pv_cv_txt;
            if ((MyScore_pv_b_txt - Deduction_pv_b) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b;
                GZ_reduce_score_pv_b = 0;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b + (MyScore_pv_b_txt - Deduction_pv_b);
                GZ_reduce_score_pv_b = MyScore_pv_b_txt - Deduction_pv_b;
            }

            //获得pv_cv
            shopNum1_AdvancePaymentModifyLog.DeDao_Qian_cv = TJScore_pv_c;
            shopNum1_AdvancePaymentModifyLog.DeDao_cv = MYlabelScore_pv_cv_txt;
            shopNum1_AdvancePaymentModifyLog.DeDao_Hou_cv = TJScore_pv_c + MYlabelScore_pv_cv_txt;

            //获得pv——b
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_b = TJScore_pv_b;
            if ((MyScore_pv_b_txt - Deduction_pv_b) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = 0;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = MyScore_pv_b_txt - Deduction_pv_b;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b + (MyScore_pv_b_txt - Deduction_pv_b);
            }


            shopNum1_AdvancePaymentModifyLog.HuoDe_pv_a = MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;

            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderNumber;
            shopNum1_AdvancePaymentModifyLog.Offset_pv_b = Deduction_pv_b;
            #region 退款记录

            GZ_reduce_score_pv_a = MyScore_pv_a_txt;

            GZ_reduce_score_pv_cv = MYlabelScore_pv_cv_txt;

            GZ_reduce_TJID = TJID;
            GZ_reduce_score_dv = 0;
            GZ_reduce_PaymentPrice = 0;
            #endregion

            shopNum1_AdvancePaymentModifyLog.HuoDe_Mom = "消费获得";
            shopNum1_AdvancePaymentModifyLog.XiaoFei_Mom = "消费扣取";
            /*  shopNum1_AdvancePaymentModifyLog.Score_cv = MyScore_hv_txt + MyScore_hv;
              shopNum1_AdvancePaymentModifyLog.Score_max_hv = MyScore_hv_txt + MyScore_hv;*/

            shopNum1_AdvancePaymentModifyLog.Date =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.Memo = memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = memloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser = memloginID;
            shopNum1_AdvancePaymentModifyLog.TJmemID = TJID;
            shopNum1_AdvancePaymentModifyLog.CreateTime =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;

            #region 退款操作
            ShopNum1_OrderRefund orderRefund = new ShopNum1_OrderRefund();
            orderRefund.MemloginID = memloginID;
            orderRefund.Ordernumber = OrderNumber;
            orderRefund.PaymentPrice = GZ_PaymentPrice;
            orderRefund.Score_hv = GZ_Score_hv;
            orderRefund.Score_dv = GZ_Score_dv;
            orderRefund.Score_pv_a = GZ_Score_pv_a;
            orderRefund.Score_pv_b = GZ_Score_pv_b;
            orderRefund.Score_pv_cv = GZ_Score_pv_cv;
            orderRefund.reduce_PaymentPrice = GZ_reduce_PaymentPrice;
            orderRefund.reduce_score_dv = GZ_reduce_score_dv;
            orderRefund.reduce_score_hv = GZ_reduce_score_hv;
            orderRefund.reduce_score_pv_a = GZ_reduce_score_pv_a;
            orderRefund.reduce_score_pv_b = GZ_reduce_score_pv_b;
            orderRefund.reduce_score_pv_cv = GZ_reduce_score_pv_cv;
            orderRefund.reduce_TJhv = GZ_reduce_score_TJ_hv;
            orderRefund.TJMemloginID = GZ_reduce_TJID;

            ShopNum1_OrderRefund_Action orderrefundaction = (ShopNum1_OrderRefund_Action)LogicFactory.CreateShopNum1_OrderRefund_Action();

            orderrefundaction.Add(orderRefund);
            #endregion



            var shopNum1_AdvancePaymentModifyLog_Action =
                (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();

            shopNum1_AdvancePaymentModifyLog_Action.OperateMoney_TJ(shopNum1_AdvancePaymentModifyLog);



        }
        protected void OrderOperateLog(string memo, string strOrdGuId, string strFeeType, string memloginid)
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
                shopNum1_OrderOperateLog.CreateUser = memloginid;
                var shopNum1_OrderOperateLog_Action =
                    (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
            }
        }
    }
}
