using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Payment;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class alipay2_receive : Page, IRequiresSessionState
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


        private string OrderinfoId;
        private string MemLoginIDId;


        protected void Page_Load(object sender, EventArgs e)
        {
            File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t充值订单0：", Encoding.UTF8);
            SortedDictionary<string, string> requestPost = this.GetRequestPost();
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
            File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t充值订单1：", Encoding.UTF8);
            if (requestPost.Count > 0)
            {
                Alipay3Notify alipay3Notify = new Alipay3Notify(requestPost, base.Request.Form["notify_id"], partner, key, input_charset, sign_type, transport);
                string responseTxt = alipay3Notify.ResponseTxt;
                string a = base.Request.Form["sign"];
                string mysign = alipay3Notify.Mysign;
                if (responseTxt == "true" && a == mysign)
                {
                    File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t充值订单2：", Encoding.UTF8);
                    string text = base.Request.Form["trade_no"];
                    string text2 = base.Request.Form["out_trade_no"];
                    string value = base.Request.Form["total_fee"];
                    string arg_169_0 = base.Request.Form["subject"];
                    string arg_17F_0 = base.Request.Form["body"];
                    string arg_195_0 = base.Request.Form["buyer_email"];
                    string arg_1AB_0 = base.Request.Form["trade_status"];
                    if (base.Request.Form["trade_status"] == "TRADE_FINISHED" || base.Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t充值订单3：", Encoding.UTF8);

                        if (text2.IndexOf("C") != -1)
                        {


                            ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                            DataTable table = shopNum1_AdvancePaymentApplyLog_Action.SearchStatus(text2);
                            if (table.Rows[0]["OperateStatus"].ToString() == "1")
                            {
                                //stream.WriteLine("充值订单重复");
                                base.Response.Write("success");
                            }
                            else
                            {

                                string nameById = ShopNum1.Common.Common.GetNameById("OrderNumber", "ShopNum1_AdvancePaymentApplyLog", " And OrderNumber='" + text2 + "' And operatestatus=0");
                                //stream.WriteLine("1-2");
                                //File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t" + order_no + "错误信息1：" + nameById, Encoding.UTF8);
                                //stream.WriteLine("1-3");
                                if (nameById != "" && nameById != "0")
                                {
                                    //stream.WriteLine("1-4");
                                    string nameById2 = ShopNum1.Common.Common.GetNameById("memloginid", "ShopNum1_AdvancePaymentApplyLog", " And ordernumber='" + text2 + "' And operatestatus=0");
                                    //stream.WriteLine("1-5");
                                    try
                                    {
                                        //stream.WriteLine("1");
                                        string nameById3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + nameById2 + "'");
                                        //stream.WriteLine("1-6");
                                        //stream.WriteLine("2");
                                        lock (nameById2)
                                        {
                                            this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(value), "支付宝及时到账会员充值", nameById2, Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                                            //stream.WriteLine("1-7");
                                            //stream.WriteLine("3");
                                            shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, text2);
                                            //stream.WriteLine("1-8");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //stream.WriteLine("4");
                                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "错误信息：" + ex.Message + ex.StackTrace, Encoding.UTF8);
                                    }
                                }
                                //stream.WriteLine("充值订单成功");
                                base.Response.Write("success");
                            }









                            //ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                            //string nameById = ShopNum1.Common.Common.GetNameById("OrderNumber", "ShopNum1_AdvancePaymentApplyLog", " And OrderNumber='" + text2 + "' And operatestatus=0");
                            //File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t" + text2 + "充值订单编号：" + nameById, Encoding.UTF8);
                            //if (nameById != "" && nameById != "0")
                            //{
                            //    try
                            //    {
                            //        string nameById2 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
                            //        this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById2), Convert.ToDecimal(value), "支付宝及时到账会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                            //        shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, text2);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "错误信息：" + ex.Message, Encoding.UTF8);
                            //    }
                            //}

                        }
                        else
                        {
                            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            ShopNum1_Member_Action memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
                            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);


                            string[] Should = arg_17F_0.Split(new char[1] { '|' });
                            ShouldDv = Convert.ToDecimal(Should[0]);
                            ShouldHv = Convert.ToDecimal(Should[1]);

                            if (dataTable.Rows.Count > 0)
                            {
                                int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                                if (num < 1)
                                {
                                    OrderinfoId = text2;
                                    MemLoginIDId = dataTable.Rows[0]["MemLoginID"].ToString();
                                    shopNum1_OrderInfo_Action.UpdateOrderSYhv(text2, ShouldHv);
                                    #region 商品需要货币
                                    DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(text2);
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
                                    dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(text2, MemLoginIDId);
                                    MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                                    MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                                    MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                                    MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                                    MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                                    MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                                    MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                                    #endregion

                                    int num1 = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
                                    //stream.WriteLine("2-4");
                                    if (num1 < 1)
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
                                    text2,
                                    ",交易号：",
                                    text,
                                    ",用户名：",
                                    text4,
                                    "\r\n"
                                }), Encoding.UTF8);

                                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();

                                        string nameById3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + text4 + "'");
                                        //lock (text4)
                                        //{
                                        this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(value), "支付宝及时到账会员充值", text4, Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);



                                        string nameById4 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + text4 + "'");


                                        this.AdvancePaymentModifyLog(3, Convert.ToDecimal(nameById4), Convert.ToDecimal(value), "支付宝及时到账消费", text4, Convert.ToDateTime(DateTime.Now.ToLocalTime().AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss")), 0, text2, text4, Convert.ToDecimal(value2), DateTime.Now, "已付款", "买家已付款", "等待卖家发货", text5, text4);





                                        //shopNum1_OrderInfo_Action.SetPaymentStatus2(text2, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2), text);
                                        shopNum1_OrderProduct_Action.UpdateStock(text5);
                                        //}

                                        if (dataTable.Rows[0]["FeeType"].ToString() == "2")
                                        {

                                            this.IsMMS(dataTable.Rows[0]["ordernumber"].ToString(), dataTable.Rows[0]["IdentifyCode"].ToString(), dataTable.Rows[0]["MemloginId"].ToString(), dataTable.Rows[0]["Mobile"].ToString(), dataTable.Rows[0]["ProductName"].ToString(), dataTable.Rows[0]["BuyNumber"].ToString());

                                        }
                                        //this.OrderOperateLog("已付款", "买家已付款", "等待卖家发货", text5, text4);
                                        var orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                                        var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                                        DataTable table = orderaction.SerchOrderInfoAll(OrderinfoId);
                                        string memid = table.Rows[0]["MemLoginID"].ToString();
                                        String Guid1 = memaction.GetGuidByMemLoginID(memid);
                                        DataTable tablemember = memaction.SearchMemberGuid(Guid1);
                                        if (table.Rows[0]["shop_category_id"].ToString() != "5" && table.Rows[0]["shop_category_id"].ToString() != "2" && table.Rows[0]["OderStatus"].ToString() == "1")
                                        {
                                            orderaction.Push3Gorder(OrderinfoId, tablemember.Rows[0]["MemLoginNO"].ToString(), table.Rows[0]["CreateTime"].ToString(), table.Rows[0]["PayTime"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]), Convert.ToDecimal(table.Rows[0]["Score_pv_a"]));
                                        }

                                        #region 6.1的新逻辑
                                        //用户Score_sv=进货X5最大销售额   Score_cv=销售额度    Score_record_pv_a=普通商品购买次数
                                        if (table.Rows[0]["shop_category_id"].ToString() == "5")
                                        {
                                            memaction.Update5XSV(tablemember.Rows[0]["MemLoginNO"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                            DataTable m5XSV = memaction.SearchMembertwo(memid);
                                            if (m5XSV.Rows[0]["MemberType"].ToString() == "2")
                                            {
                                                if (Convert.ToDecimal(m5XSV.Rows[0]["Score_sv"]) > Convert.ToDecimal(m5XSV.Rows[0]["Score_cv"]))
                                                {
                                                    DataTable mShop = memaction.SelectShopOfMemloginid(memid);
                                                    if (mShop.Rows[0]["IsDeleted"].ToString() == "1")
                                                    {
                                                        memaction.UpdateShopIsDelete(memid);
                                                    }
                                                }
                                            }

                                        }
                                        if (table.Rows[0]["shop_category_id"].ToString() == "9")
                                        {
                                            memaction.Update5XCV(table.Rows[0]["ShopID"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                        }

                                        if (tablemember.Rows[0]["MemberRankGuid"].ToString().ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper() && Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]) >= 1000 && Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) >= 1000 && (table.Rows[0]["shop_category_id"].ToString() == "1" || table.Rows[0]["shop_category_id"].ToString() == "9"))
                                        {
                                            DataTable m5XSV = memaction.SearchMembertwo(memid);
                                            if (Convert.ToDecimal(m5XSV.Rows[0]["Score_record _pv_a"]) >= 2)
                                            {

                                                memaction.UpdateMemberRankGuid(memid, MemberLevel.VIP_MEMBER_ID);

                                            }
                                            else
                                            {
                                                memaction.UpdatememberZGX1(memid);
                                            }


                                        }
                                        #endregion
                                        //PushOrder.PushWeiXinMsg pushweixin = new PushOrder.PushWeiXinMsg();
                                        //pushweixin.Push(OrderinfoId);

                                        //DataTable member520 = memberrankguid_Action.SearchMembertwo(MemLoginIDId);
                                        //if ((member520.Rows[0]["MemberRankGuid"].ToString().ToUpper() == "A6DA75AD-E1AC-4DF8-99AD-980294A16581" || member520.Rows[0]["MemberRankGuid"].ToString().ToUpper() == "E5EA79AC-A3E9-492B-9F86-9C7F8A48AA76") && (Convert.ToDecimal(member520.Rows[0]["Score_pv_a"].ToString()) > 10000 || Convert.ToDecimal(member520.Rows[0]["Score_pv_a"].ToString()) == 10000))
                                        //{
                                        //    memberrankguid_Action.UpdateIs520OfMemberID(MemLoginIDId);
                                        //    DataTable WeixinMember = memberrankguid_Action.SelectWeixinMember(member520.Rows[0]["MemLoginNO"].ToString());
                                        //    if (WeixinMember.Rows.Count > 0)
                                        //    {

                                        //        ShopNum1.Webservice.Tj520api.WeiService tj520 = new ShopNum1.Webservice.Tj520api.WeiService();
                                        //        string OpenId = WeixinMember.Rows[0]["WinMemLoginID"].ToString();
                                        //        string privateKey_two = "OpenId=" + OpenId + "&GradeId=13123456";
                                        //        string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                                        //        tj520.UpdateMemberStutas(OpenId, 13, md5Check_two);
                                        //        string privateKey_two1 = "openId=" + OpenId + "&Status=2123456";
                                        //        string md5Check_two1 = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two1);
                                        //        string qwe = tj520.Member(OpenId, "2", "幸福天使", "升级成功", "恭喜你成功升级为幸福天使会员！", "", md5Check_two1);
                                        //    }
                                        //    Thread.Sleep(60);




                                        //}

                                        base.Response.Write("success");

                                    }
                                    
                                }
                                base.Response.Write("success");
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

            //orderrefundaction.Add(orderRefund);
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

        #region 原充值逻辑
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
        #endregion

        private string method_0()
        {
            string result = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                result = httpCookie.Values["MemLoginID"].ToString();
            }
            return result;
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
                ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
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
                    ShopNum1_MMSGroupSend_Action shopNum1_MMSGroupSend_Action = (ShopNum1_MMSGroupSend_Action)LogicFactory.CreateShopNum1_MMSGroupSend_Action();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text2));
                    sMS.Send(string_0.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 2, text);
                        shopNum1_MMSGroupSend_Action.Add(shopNum1_MMSGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 0, text);
                        shopNum1_MMSGroupSend_Action.Add(shopNum1_MMSGroupSend);
                    }
                }
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string Content, string MMsTitle, int state, string mmsGuid)
        {
            ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = new ShopNum1_MMSGroupSend();

            shopNum1_MMSGroupSend.Guid = Guid.NewGuid();
            shopNum1_MMSGroupSend.MMSTitle = MMsTitle;
            shopNum1_MMSGroupSend.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_MMSGroupSend.MMSGuid = new Guid(mmsGuid);
            shopNum1_MMSGroupSend.SendObjectMMS = Content;
            shopNum1_MMSGroupSend.SendObject = memLoginID + "-" + mobile;
            shopNum1_MMSGroupSend.State = state;

            return shopNum1_MMSGroupSend;
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

        //public SortedDictionary<string, string> GetRequestPost()
        //{
        //    SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
        //    NameValueCollection queryString = base.Request.QueryString;
        //    string[] allKeys = queryString.AllKeys;
        //    for (int i = 0; i < allKeys.Length; i++)
        //    {
        //        sortedDictionary.Add(allKeys[i], base.Request.QueryString[allKeys[i]]);
        //    }
        //    return sortedDictionary;
        //}

        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
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