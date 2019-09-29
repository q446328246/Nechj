using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1MultiEntity;
using System.Text;
using System.Data;
using System.Threading;
using ShopNum1.Standard;
using ShopNum1.Email;
using ShopNum1.Interface;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.IO;
using ShopNum1.Common.ShopNum1.Common;
namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class WeiXinServicePay_weixinPayment : System.Web.UI.Page
    {
        private decimal MyScore_hv_txt;
        private decimal MyScore_pv_a_txt;
        private decimal MyScore_pv_b_txt;
        private decimal MYlabelScore_cv_txt;
        private decimal MYlabelScore_max_hv_tx;
        private decimal MYlabelScore_dv_txt;
        private decimal MYlabelScore_pv_cv_txt;
        private DataSet dataSet_0;
        private decimal MyScore_hv;
        private decimal MyScore_pv_a;
        private decimal MyScore_pv_b;
        private decimal MyScore_pv_c;
        private decimal MyScore_dv;
        private decimal MYlabelScore_cv;
        private decimal MYlabelScore_max_hv;
        private decimal ShouldDv;
        private decimal ShouldHv;
        #region 退款记录

        private decimal GZ_Score_hv;
        private decimal GZ_Score_pv_a;
        private decimal GZ_Score_pv_b;
        private decimal GZ_Score_pv_cv;
        private decimal GZ_Score_dv;
        private decimal GZ_PaymentPrice;
        private decimal GZ_reduce_score_hv;
        private decimal GZ_reduce_score_pv_a;
        private decimal GZ_reduce_score_pv_b;
        private decimal GZ_reduce_score_pv_cv;
        private decimal GZ_reduce_score_dv;
        private decimal GZ_reduce_PaymentPrice;
        private decimal GZ_reduce_score_TJ_hv;
        private string GZ_reduce_TJID;
        #endregion

        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
        ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
        private string OrderinfoId;
        private string MemLoginIDId;
        private string MemloginID;
        private string LabelShouldPay;
        private string labelScore_dv;
        private string LabelAdvancePayment;
        private decimal Deduction_pv_b;
        private string string_6;
        private string string_7;
        private string string_3;
        private string allOrderguid;
        private string allOrderordertype;
        private string allOrdershop_category_id;
        private string PaymentGuid;


        public string BindPayPrice(string OrderNumber, string OpenID, string ScoreHvType)
        {

            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);
            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();
            OrderinfoId = OrderNumber;
            MemLoginIDId = MemloginID;
            DataTable tablegz = shopNum1_OrderInfo_Action2.SearchOrder(OrderNumber);
            if (tablegz.Rows[0]["OderStatus"].ToString() == "0")
            {
                DataTable orderGuIdByTradeId2 = shopNum1_OrderInfo_Action2.GetOrderGuIdByTradeId(OrderNumber);
                for (int i = 0; i < orderGuIdByTradeId2.Rows.Count; i++)
                {

                    MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_hv"]);
                    MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_pv_a"]);
                    MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_pv_b"]);
                    MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["score_reduce_pv_a"]);
                    MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["score_reduce_hv"]);
                    MYlabelScore_dv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_dv"]);
                    MYlabelScore_pv_cv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_pv_cv"]);
                    PaymentGuid = orderGuIdByTradeId2.Rows[i]["PaymentGuid"].ToString();
                }
                dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(OrderNumber, MemloginID);
                DataTable allordertable = shopNum1_OrderInfo_Action.SelectOrderOfAll(OrderNumber);
                allOrderguid = allordertable.Rows[0]["Guid"].ToString();
                allOrderordertype = allordertable.Rows[0]["OrderType"].ToString();
                allOrdershop_category_id = allordertable.Rows[0]["shop_category_id"].ToString();
                //我有的
                MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                            !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
                {
                    if (ScoreHvType == "0")
                    {
                        #region 红包抵扣
                        if ((MyScore_hv > (MYlabelScore_max_hv_tx * (-1))) || (MyScore_hv == (MYlabelScore_max_hv_tx * (-1))))
                        {
                            LabelShouldPay = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - (MYlabelScore_max_hv_tx * (-1))).ToString();
                            labelScore_dv = "0.00";
                            decimal SPdv = Convert.ToDecimal(LabelShouldPay);
                            if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
                            {
                                if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                                {
                                    LabelShouldPay = "0.00";
                                    labelScore_dv = SPdv.ToString();
                                }
                                else
                                {
                                    LabelShouldPay = (SPdv - MyScore_dv).ToString();
                                    labelScore_dv = MyScore_dv.ToString();
                                }
                            }
                            Deduction_pv_b = (MYlabelScore_max_hv_tx * (-1));

                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();

                            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            return "金额" + LabelShouldPay + "," + labelScore_dv + "|" + Deduction_pv_b;
                        }
                        else
                        {
                            LabelShouldPay = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - MyScore_hv).ToString();
                            labelScore_dv = "0.00";
                            decimal SPdv = Convert.ToDecimal(LabelShouldPay);
                            if (allOrdershop_category_id == "2")
                            {
                                if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                                {
                                    LabelShouldPay = "0.00";
                                    labelScore_dv = SPdv.ToString();
                                }
                                else
                                {
                                    LabelShouldPay = (SPdv - MyScore_dv).ToString();
                                    labelScore_dv = MyScore_dv.ToString();
                                }
                            }
                            Deduction_pv_b = MyScore_hv;

                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();

                            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            return "金额" + LabelShouldPay + "," + labelScore_dv + "|" + Deduction_pv_b;
                        }
                        #endregion
                    }
                    else
                    {
                        #region 红包不抵扣

                        LabelShouldPay = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                        labelScore_dv = "0.00";
                        decimal SPdv = Convert.ToDecimal(LabelShouldPay);
                        if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
                        {
                            if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                            {
                                LabelShouldPay = "0.00";
                                labelScore_dv = SPdv.ToString();
                            }
                            else
                            {
                                LabelShouldPay = (SPdv - MyScore_dv).ToString();
                                labelScore_dv = MyScore_dv.ToString();
                            }
                        }


                        Deduction_pv_b = 0;

                        string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                        string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                        LabelAdvancePayment = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                        string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();


                        MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                        MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                        MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                        MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                        MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                        MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                        MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                        return "金额" + LabelShouldPay + "," + labelScore_dv + "|" + Deduction_pv_b;
                        #endregion
                    }

                }
                return "出错了";
            }
            return "订单状态错误";


        }






        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="Totol"></param>
        /// <param name="GetAwyID"></param>
        /// <returns></returns>
        public string Pay(string OrderNumber, decimal Totol, string GetAwyID, string DVHV)
        {



            string[] Should = DVHV.Split(new char[1] { '|' });
            ShouldDv = Convert.ToDecimal(Should[0]);
            ShouldHv = Convert.ToDecimal(Should[1]);

            // stream.WriteLine("2");
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            ShopNum1_Member_Action memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(OrderNumber);

            //stream.WriteLine("2-2");
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["PaymentStatus"].ToString() == "1")
                {
                    //stream.WriteLine("商品订单重复");
                    return "订单已支付！";
                }
                else
                {
                    shopNum1_OrderInfo_Action.UpdateOrderSYhv(OrderNumber, ShouldHv);
                    #region 如果会员等级为普通，订单不获得B积分
                    string MemberLoginID = dataTable.Rows[0]["MemLoginID"].ToString();
                    ////会员等级
                    //string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
                    //if (memberGuid.ToLower() == MemberLevel.NORMAL_MEMBER_ID.ToLower())
                    //{
                    //    shopNum1_OrderInfo_Action.UpdatePTScore_pv_b(order_no);
                    //}
                    #endregion
                    #region 商品需要货币
                    DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(OrderNumber);
                    for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                    {

                        MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_hv"]);
                        MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_a"]);
                        MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_b"]);
                        MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_pv_a"]);
                        MYlabelScore_max_hv_tx += Convert.ToDecimal("0.00");
                        MYlabelScore_dv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_dv"]);
                        MYlabelScore_pv_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_cv"]);

                    }
                    #endregion
                    #region 会员拥有的货币
                    dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(OrderNumber, MemberLoginID);
                    MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                    MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                    MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                    MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                    MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                    MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                    MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                    #endregion
                    OrderinfoId = OrderNumber;
                    MemLoginIDId = MemberLoginID;

                    // stream.WriteLine("2-3");
                    int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                    //stream.WriteLine("2-4");
                    if (num < 1)
                    {
                        //stream.WriteLine("2-5");
                        string text4 = dataTable.Rows[0]["MemLoginID"].ToString();
                        //stream.WriteLine("2-6" + text4);
                        string text5 = dataTable.Rows[0]["Guid"].ToString();
                        //stream.WriteLine("2-7" + text5);
                        string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                        // stream.WriteLine("2-8" + value2);
                        dataTable.Rows[0]["OrderNumber"].ToString();
                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), string.Concat(new string[]
								{
									"\r\n订单号：",
									OrderNumber,
									",交易号：",
									GetAwyID,
									",用户名：",
									text4,
									"\r\n"
								}), Encoding.UTF8);

                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();

                        string nameById3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + text4 + "'");

                        //int fh = shopNum1_OrderInfo_Action.SetPaymentStatus2(OrderNumber, 1, 1, 0, DateTime.Now, Convert.ToDecimal(Totol), Convert.ToDecimal(value2), GetAwyID);
                        //if (fh == 1)
                        //{
                        //加锁
                        //lock (text4)
                        //{

                        this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(Totol), "微信支付充值", text4, Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        string nameById4 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + text4 + "'");
                        this.AdvancePaymentModifyLog(3, Convert.ToDecimal(nameById4), Convert.ToDecimal(Totol), "微信支付消费", text4, Convert.ToDateTime(DateTime.Now.ToLocalTime().AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss")), 0, OrderNumber, text4, Convert.ToDecimal(value2), DateTime.Now, "已付款", "买家已付款", "等待卖家发货", text5, text4);

                        shopNum1_OrderProduct_Action.UpdateStock(text5);
                        //}


                        if (dataTable.Rows[0]["FeeType"].ToString() == "2")
                        {

                            this.IsMMS(dataTable.Rows[0]["ordernumber"].ToString(), dataTable.Rows[0]["IdentifyCode"].ToString(), dataTable.Rows[0]["MemloginId"].ToString(), dataTable.Rows[0]["Mobile"].ToString(), dataTable.Rows[0]["ProductName"].ToString(), dataTable.Rows[0]["BuyNumber"].ToString());

                        }
                        //this.OrderOperateLog("已付款", "买家已付款", "等待卖家发货", text5, text4);
                        #region 取消原520会员升级逻辑
                        //int Is520 = 0;
                        //DataTable productGuid520 = shopNum1_OrderInfo_Action.Select_520OfOrdernumber(OrderinfoId);
                        //for (int i = 0; i < productGuid520.Rows.Count; i++)
                        //{
                        //    if (productGuid520.Rows[i]["ProductGuid"].ToString().ToUpper().Trim() == ShopSettings.TJ520.ToUpper() || productGuid520.Rows[i]["ProductGuid"].ToString().ToUpper().Trim() == ShopSettings.TJ520_two.ToUpper())
                        //    {
                        //        Is520 = 1;
                        //    }
                        //}
                        //if (Is520 == 1)
                        //{
                        //    DataTable member520 = memberrankguid_Action.Get520OfMemLoginID(MemLoginIDId);
                        //    if (member520.Rows[0]["Is520Member"].ToString() == "0" && member520.Rows[0]["MemberRankGuid"].ToString() != MemberLevel.NORMAL_Regular_Members)
                        //    {
                        //        shopNum1_OrderInfo_Action.UpdateOrder520(OrderinfoId);
                        //        memberrankguid_Action.UpdateIs520OfMemberID(MemLoginIDId);
                        //        #region 升级520会员送5200红包
                        //        memberrankguid_Action.UpdateMemberScore(MemLoginIDId, Convert.ToInt32(0),
                        //        Convert.ToInt32(5200));
                        //        decimal vScore = Convert.ToDecimal(ShopNum1.Common.Common.GetScore_hv(MemLoginIDId).Rows[0]["Score_hv"]);
                        //        ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
                        //        shopNum1_AdvancePaymentModifyLog.hv_guid_two = Guid.NewGuid();
                        //        shopNum1_AdvancePaymentModifyLog.OperateType = 1;

                        //        shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_hv = vScore - Convert.ToDecimal(5200);
                        //        shopNum1_AdvancePaymentModifyLog.HuoDe_hv = Convert.ToDecimal(5200);
                        //        shopNum1_AdvancePaymentModifyLog.Huo_DeHou_hv = vScore;
                        //        shopNum1_AdvancePaymentModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //        shopNum1_AdvancePaymentModifyLog.HuoDe_Mom = "升级520会员送红包";
                        //        shopNum1_AdvancePaymentModifyLog.MemLoginID = MemLoginIDId;
                        //        shopNum1_AdvancePaymentModifyLog.CreateUser = MemLoginIDId;
                        //        shopNum1_AdvancePaymentModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //        shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;
                        //        var shopNum1_AdvancePaymentModifyLog_Action =
                        //   (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                        //        shopNum1_AdvancePaymentModifyLog_Action.OperateScore_HV(shopNum1_AdvancePaymentModifyLog);
                        //        #endregion



                        //        DataTable memberOfNoALL = memberrankguid_Action.SearchMembertwo(MemLoginIDId);
                        //        string memberOfNO = memberOfNoALL.Rows[0]["MemLoginNO"].ToString();
                        //        string TJByNo = memberOfNoALL.Rows[0]["Superior"].ToString();
                        //        DataTable TjMemberAll = memberrankguid_Action.SelectMemberBy_NO(TJByNo);
                        //        DataTable TjAngleTable = memberrankguid_Action.SelectWeixinAngleTime(TjMemberAll.Rows[0]["MemLoginID"].ToString());
                        //        if (TjAngleTable.Rows.Count > 0)
                        //        {
                        //            int AngleCount = Convert.ToInt32(TjAngleTable.Rows[0]["ReferenceNumber"]);
                        //            DataTable success520 = memberrankguid_Action.SelectMember520Time(TJByNo);
                        //            if (success520.Rows.Count < AngleCount)
                        //            {

                        //                int i = AngleCount - success520.Rows.Count;
                        //                SMS sms = new SMS();
                        //                string retmsg = "";
                        //                sms.Send(TjMemberAll.Rows[0]["Mobile"].ToString().Trim(), "恭喜你实现一名天使梦想，离你本月的天使梦想还差" + i + "名,加油哟！【唐江宝宝】", out retmsg);
                        //            }
                        //            if (success520.Rows.Count == AngleCount)
                        //            {
                        //                SMS sms = new SMS();
                        //                string retmsg = "";
                        //                sms.Send(TjMemberAll.Rows[0]["Mobile"].ToString().Trim(), "恭喜你实现当月天使梦想，本月你指定的天使梦想有点低哟，下个月可以放大你的天使梦想！【唐江宝宝】", out retmsg);
                        //            }


                        //        }
                        //        DataTable WeixinMember = memberrankguid_Action.SelectWeixinMember(memberOfNO);
                        //        if (WeixinMember.Rows.Count > 0)
                        //        {

                        //            ShopNum1.Webservice.Tj520api.WeiService tj520 = new ShopNum1.Webservice.Tj520api.WeiService();
                        //            string OpenId = WeixinMember.Rows[0]["WinMemLoginID"].ToString();
                        //            string privateKey_two = "OpenId=" + OpenId + "&GradeId=7123456";
                        //            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                        //            tj520.UpdateMemberStutas(OpenId, 7, md5Check_two);
                        //        }
                        //    }



                        //}
                        #endregion
            

                        return "订单支付成功！";
                        //}
                        //return "订单支付状态错误！";
                    }
                    //stream.WriteLine("商品订单成功");
                    return "订单支付状态错误！";
                    // stream.WriteLine("2-19");
                }
            }
            else
            {
                //stream.WriteLine("商品订单不存在");
                return "订单不存在！";
                // stream.WriteLine("2-20");
            }



        }






        public void AdvancePaymentModifyLogY(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
        {
            ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());

            shopNum1_AdvancePaymentModifyLog.OperateType = OperateType;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayments;
            shopNum1_AdvancePaymentModifyLog.OperateMoney = payMoney;
            if (type == 1)
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
            }
            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderinfoId;
            shopNum1_AdvancePaymentModifyLog.Date = time;
            shopNum1_AdvancePaymentModifyLog.Memo = Memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(time);
            shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
            ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            shopNum1_AdvancePaymentModifyLog_Action.OperateMoneyCZGM(shopNum1_AdvancePaymentModifyLog);
        }

        public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type, string ordernumber, string memLoginID, decimal shouldPay, DateTime paytime, string Olgmemo, string CurrentStateMsg, string NextStateMsg, string OrderGuId, string OlgMemLoginID)
        {
            ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(System.Guid.NewGuid());
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
            shopNum1_AdvancePaymentModifyLog.OperateType = OperateType;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayments;
            shopNum1_AdvancePaymentModifyLog.OperateMoney = payMoney;
            if (type == 1)
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
            }
            #region 退款记录
            GZ_PaymentPrice = payMoney;
            #endregion

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            String Guid1 = member_Action.GetGuidByMemLoginID(shopMemloginID);
            DataTable tableTJ = member_Action.SearchMemberGuid(Guid1);
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
                TJID = MemLoginIDId;
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
            if (MyScore_dv > ShouldDv || MyScore_dv == ShouldDv)
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
                shopNum1_AdvancePaymentModifyLog.Score_dv = MyScore_dv - MyScore_dv;
                #region 退款记录
                GZ_Score_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = MyScore_dv - MyScore_dv;
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
            if (MyScore_hv > ShouldHv || MyScore_hv == ShouldHv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - ShouldHv;
                #region 退款记录
                GZ_Score_hv = ShouldHv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = ShouldHv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - ShouldHv;
                #endregion
            }
            if (MyScore_hv < ShouldHv && MyScore_hv > -1)
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

            shopNum1_AdvancePaymentModifyLog.Score_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Score_pv_c = shopNum1_AdvancePaymentModifyLog.Score_pv_c + MYlabelScore_pv_cv_txt;

            //520商品抵扣红包不扣pvb
            //DataTable productGuid520PVB = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).Select_520OfOrdernumber(OrderinfoId);
            //for (int i = 0; i < productGuid520PVB.Rows.Count; i++)
            //{
            //    if (productGuid520PVB.Rows[i]["ProductGuid"].ToString().ToUpper().Trim() == ShopSettings.TJ520.ToUpper() || productGuid520PVB.Rows[i]["ProductGuid"].ToString().ToUpper().Trim() == ShopSettings.TJ520_two.ToUpper())
            //    {
            //        ShouldHv = 0;
            //    }

            //}
            if ((MyScore_pv_b_txt - ShouldHv) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b;
                GZ_reduce_score_pv_b = 0;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b + (MyScore_pv_b_txt - ShouldHv);
                GZ_reduce_score_pv_b = (MyScore_pv_b_txt - ShouldHv);
            }
            //获得pv_cv
            shopNum1_AdvancePaymentModifyLog.DeDao_Qian_cv = TJScore_pv_c;
            shopNum1_AdvancePaymentModifyLog.DeDao_cv = MYlabelScore_pv_cv_txt;
            shopNum1_AdvancePaymentModifyLog.DeDao_Hou_cv = TJScore_pv_c + MYlabelScore_pv_cv_txt;

            //获得pv——b
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_b = TJScore_pv_b;
            if ((MyScore_pv_b_txt - ShouldHv) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = 0;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = MyScore_pv_b_txt - ShouldHv;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b + (MyScore_pv_b_txt - ShouldHv);
            }

            shopNum1_AdvancePaymentModifyLog.HuoDe_pv_a = MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;

            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderinfoId;
            shopNum1_AdvancePaymentModifyLog.Offset_pv_b = ShouldHv;
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




            #region 退款操作
            ShopNum1_OrderRefund orderRefund = new ShopNum1_OrderRefund();
            orderRefund.MemloginID = MemLoginIDId;
            orderRefund.Ordernumber = OrderinfoId;
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


            #endregion



            shopNum1_AdvancePaymentModifyLog.Date = time;
            shopNum1_AdvancePaymentModifyLog.Memo = Memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.TJmemID = TJID;
            shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(time);
            shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;
            ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            int fh = shopNum1_AdvancePaymentModifyLog_Action.OperateMoney_TJ20160817(shopNum1_AdvancePaymentModifyLog, ordernumber, memLoginID, shouldPay, paytime);
            if (fh == 1)
            {
                orderrefundaction.Add(orderRefund);
                OrderOperateLog(Olgmemo, CurrentStateMsg, NextStateMsg, OrderGuId, OlgMemLoginID);
            }

        }
        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId, string MemLoginID)
        {
            if (!string.IsNullOrEmpty(OrderGuId))
            {
                ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
                shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
                shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(OrderGuId);
                shopNum1_OrderOperateLog.OderStatus = 1;
                shopNum1_OrderOperateLog.ShipmentStatus = 0;
                shopNum1_OrderOperateLog.PaymentStatus = 0;
                shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
                shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
                shopNum1_OrderOperateLog.Memo = memo;
                shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_OrderOperateLog.IsDeleted = 0;
                shopNum1_OrderOperateLog.CreateUser = MemLoginID;
                ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
            }
        }
        protected void IsMMS(string OrderNumber, string strCode, string memloginID, string string_0, string strProductName, string strBuyNum)
        {
            if (!(string_0.Trim() == ""))
            {
                OrderInfo orderInfo = new OrderInfo();
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
                    SMS sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text2));
                    sMS.Send(string_0.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 2, text);
                        shopNum1_MMS_Action.AddMMSGroupSend(shopNum1_MMSGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 0, text);
                        shopNum1_MMS_Action.AddMMSGroupSend(shopNum1_MMSGroupSend);
                    }
                }
            }
        }
        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle, int state, string mmsGuid)
        {
            ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = new ShopNum1_MMSGroupSend();
            shopNum1_MMSGroupSend.Guid = Guid.NewGuid();
            shopNum1_MMSGroupSend.MMSTitle = MMsTitle;
            shopNum1_MMSGroupSend.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_MMSGroupSend.MMSGuid = new Guid(mmsGuid);
            shopNum1_MMSGroupSend.SendObjectMMS = strContent;
            shopNum1_MMSGroupSend.SendObject = memLoginID + "-" + mobile;
            shopNum1_MMSGroupSend.State = state;
            return shopNum1_MMSGroupSend;
        }

    }
}