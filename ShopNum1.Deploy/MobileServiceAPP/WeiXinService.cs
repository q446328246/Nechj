using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
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
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFeeTemplate;
using ShopNum1.ShopInterface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;
using System.Text;
using ShopNum1.Payment;
using System.Web.Security;


namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class WeiXinService : System.Web.UI.Page
    {
        #region 定义变量
        private decimal MYlabelscore_reduce_pv_cv;
        private decimal ShangPinPrice;
        private decimal MYlabelScore_pv_a;
        private decimal MYlabelscore_reduce_pv_a;
        private decimal MYlabelScore_hv;
        private decimal MYlabelscore_reduce_hv;
        private decimal MYlabelScore_dv;
        private decimal MYlabelScore_pv_b;
        private string MYlabelAgentId;
        private int shop_category_id;
        private string Shopid;
        private string ProductGuid;
        private string MemloginID;
        private string ServiceAgent;

        private string MemberLoginID { get; set; }

        private string MemberType { get; set; }

        private string ShopName { get; set; }
        private decimal QDSQPrice;//区代社区首次价格


        private DataSet dataSet_0;
        private decimal MYlabelScore_max_hv_tx;
        private decimal MyScore_pv_b_txt;
        private decimal MyScore_hv;
        private decimal MyScore_dv;
        private decimal MYlabelScore_max_hv;
        private string labelScore_max_hv;
        private string LabelScore_pv_b;
        private string LabelHiddenScore_pv_b;
        private string LabelHiddenShouldPay;
        private string LabelHiddenScore_dv;
        private string LabelShouldPay;
        private string labelScore_dv;
        private decimal Order_hv;
        private decimal Order_pv_a;
        private string returnOrder_hv;
        private string returnOrder_pv_a;


        private string allOrderguid;
        private string allOrderordertype;
        private string allOrdershop_category_id;
        #endregion


        /// <summary>
        /// 查询微信店铺名
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns></returns>
        public DataTable WeiXinSelectShopName(string Guid)
        {
            ShopNum1_Shop_Product_Action Shop_Product_Action = (ShopNum1_Shop_Product_Action)LogicFactory.CreateShopNum1_Shop_Product_Action();

            DataTable ShopnameInfo = Shop_Product_Action.SelectWeixinShopName(Guid);

            return ShopnameInfo;


        }

        /// <summary>
        /// 返回物流信息
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public DataTable WeiXinSelectOrderInfoWL(string OrderNumber)
        {
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

            DataTable orderinfo = shopNum1_OrderInfo_Action.SelectOrderInfoWL(OrderNumber);

            return orderinfo;


        }


        /// <summary>
        /// 微信订单退款
        /// </summary>
        /// <param name="Ordernumber"></param>
        /// <param name="OpenID"></param>
        /// <param name="RefundReason"></param>
        /// <param name="Introduce"></param>
        /// <param name="RefundTypes"></param>
        /// <returns></returns>
        public string WeiXinOrderRefund(string Ordernumber, string RefundReason, string Introduce, string RefundTypes)
        {
            ShopNum1_OrderProduct_Action orderProduct = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
            ShopNum1_OrderInfo_Action action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable allordertable = action.SelectOrderOfAllRefund(Ordernumber);
            string MemLoginID = "";
            string OrderGuid = "";
            string ShopID = "";
            if (allordertable.Rows.Count > 0)
            {

                MemLoginID = allordertable.Rows[0]["MemLoginID"].ToString();
                OrderGuid = allordertable.Rows[0]["Guid"].ToString();
                ShopID = allordertable.Rows[0]["ShopID"].ToString();
            }
            else
            {
                return "订单有误";
            }


            ShopNum1_Refund refund = new ShopNum1_Refund
            {
                ApplyTime = DateTime.Now,
                MemLoginID = MemLoginID,
                OrderID = OrderGuid,
                ProductGuid = new Guid(OrderGuid),
                ShopID = ShopID
            };

            DataTable ordertimetable = action.SelectOrderTime(OrderGuid);
            DateTime OrderTime = Convert.ToDateTime(ordertimetable.Rows[0]["PayTime"]);
            string CategoryID = ordertimetable.Rows[0]["shop_category_id"].ToString();
            string OrderNumber = ordertimetable.Rows[0]["OrderNumber"].ToString();
            string MJmember = ordertimetable.Rows[0]["MemLoginID"].ToString();
            string OrderType = "";
            DateTime d1 = DateTime.Now;
            TimeSpan d3 = d1.Subtract(OrderTime);
            if (d3.Days > 7)
            {

                return "付款时间大于7天后，不能申请退款";//付款时间大于15天后，不能申请退款
            }
            if (action.SearchOrderInfoByOrderId(OrderGuid, "shipmentstatus") == "0")
            {
                refund.IsReceive = 0;
            }
            else
            {
                refund.IsReceive = int.Parse("0");
                refund.LogisticName = "";
                refund.LogisticNumber = "";
            }
            refund.RefundMoney = Convert.ToDecimal(ordertimetable.Rows[0]["ShouldPayPrice"].ToString());
            refund.RefundID = DateTime.Now.ToString("yyyyMMddHHmmss");
            refund.RefundReason = RefundReason;

            refund.RefundStatus = 0;
            refund.RefundContent = Introduce;
            refund.RefundImg = "";
            if (RefundTypes == "1")
            {

                refund.RefundType = 0;
            }
            else
            {
                refund.RefundType = 1;
            }

            ShopNum1_Refund_Action action3 = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
            int num = 0;
            action3.DeleteRefundByOrId(refund.OrderID);
            num = action3.Add(refund);
            if (num > 0)
            {
                if (refund.RefundType == 0)
                {
                    ShopNum1_OrderInfo_Action action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();


                    int cl = action2.UpdateOrderState(OrderGuid, MemLoginID, "", "", "2", "1", "0");
                    if (cl != 0)
                    {
                        #region OrderOperateLog
                        if (!string.IsNullOrEmpty(OrderGuid))
                        {
                            var orderOperateLog = new ShopNum1_OrderOperateLog
                            {
                                Guid = Guid.NewGuid(),
                                OrderInfoGuid = new Guid(OrderGuid),
                                OderStatus = 1,
                                ShipmentStatus = 0,
                                PaymentStatus = 0,
                                CurrentStateMsg = "买家申请退款",
                                NextStateMsg = "等待卖家处理",
                                Memo = "",
                                OperateDateTime = DateTime.Now,
                                IsDeleted = 0,
                                CreateUser = MemLoginID
                            };
                            ((ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                                orderOperateLog);
                        }
                        #endregion

                        #region 退款接口
                        //int order520 = 0;
                        //try
                        //{
                        //    if (CategoryID == "1")
                        //    {
                        //        OrderType = "2";
                        //    }
                        //    else if (CategoryID == "2" || CategoryID == "9")
                        //    {
                        //        OrderType = "3";
                        //        order520 = 1;
                        //    }
                        //    else if (CategoryID == "4" || CategoryID == "5")
                        //    {
                        //        OrderType = "4";

                        //    }
                        //    else if (CategoryID == "6" || CategoryID == "7")
                        //    {
                        //        OrderType = "4";

                        //    }
                        //    var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        //    String Guid = memaction.GetGuidByMemLoginID(MJmember);
                        //    DataTable tableTJ = memaction.SearchMemberGuid(Guid);
                        //    string TjNO = tableTJ.Rows[0]["Superior"].ToString();
                        //    string ZSno = tableTJ.Rows[0]["MemLoginNO"].ToString();
                        //    if (OrderType != "4" && (TjNO != null || TjNO != ""))
                        //    {
                        //        if (order520 == 1)
                        //        {
                        //            APIInterface AnetApi = new APIInterface();
                        //            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                        //            string privateKey_two = "number=" + ZSno.ToUpper().Trim() + "&orderid=" + OrderNumber.Trim() + md5_one;
                        //            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                        //            string fh = AnetApi.DeleteMemberOrder(ZSno.ToUpper().Trim(), OrderNumber.Trim(), md5Check_two);
                        //            ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                        //            ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                        //            orderrefuse.OrderID = OrderNumber;
                        //            orderrefuse.MemberloginID = MJmember;
                        //            orderrefuse.Remark = fh;
                        //            orderrefuse.Status = "0";
                        //            orderrefuse.EndTime = DateTime.Now.ToString();
                        //            orderrefuse.AdminID = "重销单退款";
                        //            orderrefuseaction.Add(orderrefuse);

                        //        }
                        //        else
                        //        {

                        //            String TjGuid = memaction.GetGuidByMemLoginNO(TjNO);
                        //            DataTable Tjtable = memaction.SearchMemberGuid(TjGuid);
                        //            string memberRank = Tjtable.Rows[0]["MemberRankGuid"].ToString();
                        //            if (ZSno.ToUpper().IndexOf("C") != -1)
                        //            {
                        //                memberRank = tableTJ.Rows[0]["MemberRankGuid"].ToString();
                        //            }
                        //            if (memberRank.ToUpper() != MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                        //            {
                        //                string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
                        //                string TJMemLoginNO;
                        //                if (MemNO.ToUpper().IndexOf("C") != -1)
                        //                {
                        //                    TJMemLoginNO = MemNO;
                        //                }
                        //                else
                        //                {

                        //                    TJMemLoginNO = tableTJ.Rows[0]["Superior"].ToString();
                        //                }
                        //                TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
                        //                string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                        //                string privateKey_two = "Number=" + TJMemLoginNO + "&OrderID=" + OrderNumber + "&OrderType=" + OrderType + md5_one;
                        //                string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                        //                string fh = mms.MemberOrderBack(TJMemLoginNO, OrderNumber, OrderType, md5Check_two);
                        //                ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                        //                ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                        //                orderrefuse.OrderID = OrderNumber;
                        //                orderrefuse.MemberloginID = MJmember;
                        //                orderrefuse.Remark = fh;
                        //                orderrefuse.Status = "0";
                        //                orderrefuse.EndTime = DateTime.Now.ToString();
                        //                orderrefuse.AdminID = "退款";
                        //                orderrefuseaction.Add(orderrefuse);

                        //            }
                        //        }


                        //    }


                        //}
                        //catch (Exception ex)
                        //{


                        //}
                        #endregion
                        return "退款成功";//退款成功
                    }
                    else
                    {
                        return "操作失败";//操作失败
                    }
                }
                else
                {
                    int cl = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).UpdateOrderState(
                        OrderGuid, MemLoginID, "", "3", "", "1", "0");
                    if (cl != 0)
                    {
                        #region OrderOperateLog
                        if (!string.IsNullOrEmpty(OrderGuid))
                        {
                            var orderOperateLog = new ShopNum1_OrderOperateLog
                            {
                                Guid = Guid.NewGuid(),
                                OrderInfoGuid = new Guid(OrderGuid),
                                OderStatus = 1,
                                ShipmentStatus = 0,
                                PaymentStatus = 0,
                                CurrentStateMsg = "买家申请退款",
                                NextStateMsg = "等待卖家处理",
                                Memo = "",
                                OperateDateTime = DateTime.Now,
                                IsDeleted = 0,
                                CreateUser = MemLoginID
                            };
                            ((ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                                orderOperateLog);
                        }
                        #endregion

                        #region 退款接口
                        //int order520 = 0;
                        //try
                        //{
                        //    if (CategoryID == "1")
                        //    {
                        //        OrderType = "2";
                        //    }
                        //    else if (CategoryID == "2" || CategoryID == "9")
                        //    {
                        //        OrderType = "3";
                        //        order520 = 1;
                        //    }
                        //    else if (CategoryID == "4" || CategoryID == "5")
                        //    {
                        //        OrderType = "4";

                        //    }
                        //    else if (CategoryID == "6" || CategoryID == "7")
                        //    {
                        //        OrderType = "4";

                        //    }
                        //    var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        //    String Guid = memaction.GetGuidByMemLoginID(MJmember);
                        //    DataTable tableTJ = memaction.SearchMemberGuid(Guid);
                        //    string TjNO = tableTJ.Rows[0]["Superior"].ToString();
                        //    string ZSno = tableTJ.Rows[0]["MemLoginNO"].ToString();
                        //    if (OrderType != "4" && (TjNO != null || TjNO != ""))
                        //    {

                        //        if (order520 == 1)
                        //        {
                        //            APIInterface AnetApi = new APIInterface();
                        //            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                        //            string privateKey_two = "number=" + ZSno.ToUpper().Trim() + "&orderid=" + OrderNumber.Trim() + md5_one;
                        //            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                        //            string fh = AnetApi.DeleteMemberOrder(ZSno.ToUpper().Trim(), OrderNumber.Trim(), md5Check_two);
                        //            ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                        //            ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                        //            orderrefuse.OrderID = OrderNumber;
                        //            orderrefuse.MemberloginID = MJmember;
                        //            orderrefuse.Remark = fh;
                        //            orderrefuse.Status = "0";
                        //            orderrefuse.EndTime = DateTime.Now.ToString();
                        //            orderrefuse.AdminID = "重销单退款";
                        //            orderrefuseaction.Add(orderrefuse);

                        //        }
                        //        else
                        //        {

                        //            String TjGuid = memaction.GetGuidByMemLoginNO(TjNO);
                        //            DataTable Tjtable = memaction.SearchMemberGuid(TjGuid);
                        //            string memberRank = Tjtable.Rows[0]["MemberRankGuid"].ToString();
                        //            if (ZSno.ToUpper().IndexOf("C") != -1)
                        //            {
                        //                memberRank = tableTJ.Rows[0]["MemberRankGuid"].ToString();
                        //            }
                        //            if (memberRank.ToUpper() != MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                        //            {
                        //                string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
                        //                string TJMemLoginNO;
                        //                if (MemNO.ToUpper().IndexOf("C") != -1)
                        //                {
                        //                    TJMemLoginNO = MemNO;
                        //                }
                        //                else
                        //                {

                        //                    TJMemLoginNO = tableTJ.Rows[0]["Superior"].ToString();
                        //                }
                        //                TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
                        //                string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                        //                string privateKey_two = "Number=" + TJMemLoginNO + "&OrderID=" + OrderNumber + "&OrderType=" + OrderType + md5_one;
                        //                string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                        //                string fh = mms.MemberOrderBack(TJMemLoginNO, OrderNumber, OrderType, md5Check_two);
                        //                ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                        //                ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                        //                orderrefuse.OrderID = OrderNumber;
                        //                orderrefuse.MemberloginID = MJmember;
                        //                orderrefuse.Remark = fh;
                        //                orderrefuse.Status = "1";
                        //                orderrefuse.EndTime = DateTime.Now.ToString();
                        //                orderrefuse.AdminID = "退款";
                        //                orderrefuseaction.Add(orderrefuse);

                        //            }

                        //        }

                        //    }


                        //}
                        //catch (Exception ex)
                        //{


                        //}
                        #endregion
                        return "退货成功";//退货成功
                    }
                    else
                    {
                        return "操作失败";//操作失败
                    }
                }

            }
            return "操作失败";//操作失败
        }

        /// <summary>
        /// 绑定姓名身份证
        /// </summary>
        /// <param name="RealName"></param>
        /// <param name="ID"></param>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public string UpdateBindRealName(string RealName, string ID, string OpenID)
        {
            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);
            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();
            int fh = shopNum1_Member_Action.UpdateRealNameAndID(MemloginID, RealName, ID);
            if (fh == 1)
            {
                return "绑定成功";

            }
            else
            {
                return "绑定失败";
            }
        }


        /// <summary>
        /// 修改银行信息
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="BankName"></param>
        /// <param name="BankNo"></param>
        /// <param name="BankAddress"></param>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public string UpdateBank(string Bank, string BankName, string BankNo, string BankAddress, string OpenID)
        {
            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);
            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();
            int ts = shopNum1_Member_Action.UpdateMemberBank(Bank, BankName, BankNo, BankAddress, MemloginID);
            if (ts == 1)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }



        /// <summary>
        /// 支付页面显示交易金额详情
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public string BindOrderPrice(string OrderNumber, string OpenID)
        {
            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);
            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();
            ShopNum1_OrderInfo_Action OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderGuIdByTradeId = OrderInfo_Action.GetOrderGuIdByTradeId(OrderNumber);

            for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
            {


                MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_hv"]);
                MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[0]["Score_pv_b"]); 
                    Order_pv_a+=Convert.ToDecimal(orderGuIdByTradeId.Rows[0]["Score_pv_a"]);
                    Order_hv += Convert.ToDecimal(orderGuIdByTradeId.Rows[0]["Score_hv"]);

            }

            labelScore_max_hv = (MYlabelScore_max_hv_tx * (-1)).ToString();
            LabelScore_pv_b = MyScore_pv_b_txt.ToString();
            returnOrder_hv=Order_hv.ToString();
            returnOrder_pv_a=Order_pv_a.ToString();





            dataSet_0 = OrderInfo_Action.CheckTradeState(OrderNumber, MemloginID);
            DataTable allordertable = OrderInfo_Action.SelectOrderOfAll(OrderNumber);
            allOrderguid = allordertable.Rows[0]["Guid"].ToString();
            allOrderordertype = allordertable.Rows[0]["OrderType"].ToString();
            allOrdershop_category_id = allordertable.Rows[0]["shop_category_id"].ToString();

            //我有的
            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);

            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
            //我有的

            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
            #region 抵扣红包后的显示价格
            if ((MyScore_hv > (MYlabelScore_max_hv_tx * (-1))) || (MyScore_hv == (MYlabelScore_max_hv_tx * (-1))))
            {

                LabelHiddenShouldPay = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - (MYlabelScore_max_hv_tx * (-1))).ToString();
                LabelHiddenScore_pv_b = (MyScore_pv_b_txt - (MYlabelScore_max_hv_tx * (-1))).ToString();
                LabelHiddenScore_dv = "0.00";
                decimal SPdv = Convert.ToDecimal(LabelHiddenShouldPay);
                if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
                {
                    if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                    {
                        LabelHiddenShouldPay = "0.00";
                        LabelHiddenScore_dv = SPdv.ToString();
                    }
                    else
                    {
                        LabelHiddenShouldPay = (SPdv - MyScore_dv).ToString();
                        LabelHiddenScore_dv = MyScore_dv.ToString();
                    }
                }

            }
            else
            {
                LabelHiddenShouldPay = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - MyScore_hv).ToString();
                LabelHiddenScore_pv_b = (MyScore_pv_b_txt - MyScore_hv).ToString();
                LabelHiddenScore_dv = "0.00";
                decimal SPdv = Convert.ToDecimal(LabelHiddenShouldPay);
                if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
                {
                    if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                    {
                        LabelHiddenShouldPay = "0.00";
                        LabelHiddenScore_dv = SPdv.ToString();
                    }
                    else
                    {
                        LabelHiddenShouldPay = (SPdv - MyScore_dv).ToString();
                        LabelHiddenScore_dv = MyScore_dv.ToString();
                    }
                }

            }
            #endregion



            #region 红包不抵扣

            LabelShouldPay = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
            labelScore_dv = "0.00";
            decimal SPdv1 = Convert.ToDecimal(LabelShouldPay);
            if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
            {
                if (MyScore_dv > SPdv1 || MyScore_dv == SPdv1)
                {
                    LabelShouldPay = "0.00";
                    labelScore_dv = SPdv1.ToString();
                }
                else
                {
                    LabelShouldPay = (SPdv1 - MyScore_dv).ToString();
                    labelScore_dv = MyScore_dv.ToString();
                }
            }



            #endregion


            return labelScore_max_hv + "," + LabelScore_pv_b + "," + LabelHiddenShouldPay + "," + LabelHiddenScore_dv + "," + LabelShouldPay + "," + labelScore_dv + "," + LabelHiddenScore_pv_b + "," + returnOrder_hv + "," + returnOrder_pv_a;

        }

        /// <summary>
        /// 微信商城创建订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="OpenID"></param>
        /// <param name="ShopCategoryID"></param>
        /// <param name="PayMentType"></param>
        /// <param name="ProductId"></param>
        /// <param name="BuyNumber"></param>
        /// <param name="PostPrice"></param>
        /// <param name="Color"></param>
        /// <param name="Size"></param>
        /// <param name="TextBoxMessage"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Address"></param>
        /// <param name="Tel"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public string CreateOrder(string OrderID, string OpenID, int ShopCategoryID, int PayMentType, string ProductId, int BuyNumber, decimal PostPrice, string Color, string Size, string TextBoxMessage, string Name, string Email, string Address, string Tel, string Mobile)
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();


            DataTable memOpenID = member_Action.SelectMemberByOpenId(OpenID);

            ProductGuid = ProductId;
            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();

            string PostPriceGZ = PostPriceDan(ShopCategoryID, ProductGuid, BuyNumber, MemloginID);


            #region 商品价格等信息

            //会员等级
            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);




            DataTable shopProductEdit = shop_Product_Action.GetShopProductEdit(ProductGuid, ShopCategoryID);

            MYlabelscore_reduce_pv_cv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_cv"]);
            #region
            //得到积分
            ShangPinPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]);
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) >= 0)
            {
                MYlabelScore_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
            }
            //可用积分
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) < 0)
            {
                MYlabelscore_reduce_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
            }
            //得到红包
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) >= 0)
            {
                MYlabelScore_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
            }
            //可用红包
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) < 0)
            {
                MYlabelscore_reduce_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
            }
            #endregion
            MYlabelScore_dv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(BuyNumber);
            MYlabelScore_pv_b = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(BuyNumber);
            MYlabelAgentId = Convert.ToString(shopProductEdit.Rows[0]["agentId"]);

            shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);

            #endregion


            #region 服务代理查询

            ServiceAgent = "C0000001";

            DataTable tbc = member_Action.SearchAreaAgentExist(ServiceAgent);
            if (tbc.Rows.Count > 0)
            {
                #region
                if (PayMentType == null || PayMentType == 0)
                {
                    return "3";
                }
                else
                {
                    if (ShopCategoryID == 4)
                    {
                        if ((ShangPinPrice * Convert.ToInt32(BuyNumber)) >= 105700 && (ShangPinPrice * Convert.ToInt32(BuyNumber)) <= 106300)
                        {
                            QDSQPrice = 48000.00M;
                            #region 添加订单
                            string SuperiorRankGuid = "";
                            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                            string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                            if (TJMemberNO != null && TJMemberNO != "")
                            {
                                String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                                DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                                SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                            }
                            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                            shopNum1_OrderInfo.MemLoginID = MemloginID;
                            if (SuperiorRankGuid == "")
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                            }
                            else
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                            }
                            shopNum1_OrderInfo.Guid = Guid.NewGuid();
                            Order order = new Order();
                            shopNum1_OrderInfo.OrderNumber = OrderID;
                            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
                            shopNum1_OrderInfo.ShipmentStatus = 0;
                            shopNum1_OrderInfo.PaymentStatus = 0;
                            shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderInfo.OrderType = 0;
                            shopNum1_OrderInfo.Score_dv = 0;

                            shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


                            shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


                            shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

                            shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

                            shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

                            shopNum1_OrderInfo.Score_cv = 0;
                            shopNum1_OrderInfo.Score_max_hv = 0;
                            shopNum1_OrderInfo.shop_category_id = shop_category_id;
                            shopNum1_OrderInfo.AgentId = MYlabelAgentId;
                            shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                            shopNum1_OrderInfo.score_pv_cv = 0.02M;
                            //地址暂时处理
                            #region 地址未填写详细信息
                            shopNum1_OrderInfo.Name = Name;
                            shopNum1_OrderInfo.Email = Email;
                            shopNum1_OrderInfo.Address = Address;
                            shopNum1_OrderInfo.Postalcode = "";
                            shopNum1_OrderInfo.Tel = Tel;
                            shopNum1_OrderInfo.Mobile = Mobile;
                            shopNum1_OrderInfo.RegionCode = ""; //拿不准的数据

                            #endregion
                            shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                            if (QDSQPrice != null && QDSQPrice != 0)
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                            }
                            //else if (PostPrice == 0 && ShopCategoryID == 2)
                            //{
                            //    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                            //}
                            else
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = PostPrice;
                            }

                            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                            shopNum1_OrderInfo.OderStatus = 0;
                            //支付方式（1=预存款支付，2=智付支付）
                            if (PayMentType == 1)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                                shopNum1_OrderInfo.PaymentName = "预存款支付";
                            }
                            else if (PayMentType == 2)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                                shopNum1_OrderInfo.PaymentName = "微信支付";
                            }
                            else
                            {
                                return "7";
                            }

                            shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
                            shopNum1_OrderInfo.SellerToClientMsg = "";
                            shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                            shopNum1_OrderInfo.IsMemdelay = 0;
                            shopNum1_OrderInfo.OutOfStockOperate = "";
                            shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.PackName = "";
                            shopNum1_OrderInfo.PackPrice = 0m;
                            shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BlessCardName = "";
                            shopNum1_OrderInfo.BlessCardPrice = 0m;
                            shopNum1_OrderInfo.BlessCardContent = "";
                            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice) * Convert.ToDecimal(BuyNumber);
                            shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
                            shopNum1_OrderInfo.AlreadPayPrice = 0m;
                            shopNum1_OrderInfo.SurplusPrice = 0m;
                            shopNum1_OrderInfo.UseScore = 0;
                            shopNum1_OrderInfo.ScorePrice = 0m;

                            shopNum1_OrderInfo.JoinActiveType = -1;
                            shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                            shopNum1_OrderInfo.FromUrl = string.Empty;
                            shopNum1_OrderInfo.PayTime = null;
                            shopNum1_OrderInfo.DispatchTime = null;
                            shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                            shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.PayMemo = "";
                            shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BuyType = "";
                            shopNum1_OrderInfo.Discount = 0m;
                            shopNum1_OrderInfo.Deposit = 0m;
                            shopNum1_OrderInfo.JoinActiveType = 0;
                            shopNum1_OrderInfo.ActvieContent = "";
                            shopNum1_OrderInfo.UsedFavourTicket = "";
                            string text = string.Empty;
                            if (shopNum1_OrderInfo.FeeType == 2)
                            {
                                var random = new Random();
                                for (int i = 1; i < 7; i++)
                                {
                                    text += random.Next(1, 9).ToString();
                                }
                            }
                            shopNum1_OrderInfo.IdentifyCode = text;
                            string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
                            if (value == "true")
                            {
                                ShopSettings.GetValue("RecommendCommision");
                                double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                                shopNum1_OrderInfo.RecommendCommision =
                                    Convert.ToDecimal(Convert.ToDouble(shopNum1_OrderInfo.ProductPrice) * num);
                            }
                            else
                            {
                                shopNum1_OrderInfo.RecommendCommision = 0m;
                            }
                            Shop_Product_Action shop_Product_Action1 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                            DataTable dataTable2 = shop_Product_Action1.SearchProductShopByGuid_two(ProductGuid, ShopCategoryID);
                            shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
                            var list = new List<ShopNum1_OrderProduct>();
                            ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                            shopNum1_OrderProduct.BuyNumber = BuyNumber;
                            shopNum1_OrderProduct.shop_category_id = shop_category_id;
                            shopNum1_OrderProduct.Guid = Guid.NewGuid();
                            shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                            shopNum1_OrderProduct.ProductGuid = ProductGuid;
                            shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                            shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[0]["ProductNum"].ToString();
                            shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[0]["MarketPrice"].ToString());
                            shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(dataTable2.Rows[0]["ShopPrice"].ToString());
                            shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                            IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                            //DataTable dataTable33 =
                            //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

                            //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                            shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                            shopNum1_OrderProduct.OrderType = 0;
                            string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                    string.Concat(new[]
                            {
                                " And memloginid='",
                                MemloginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                MemloginID,
                                "' And ProductState=1)"
                            }));
                            if (nameById != "")
                            {


                                return "8";
                            }
                            string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
                   " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                            if (nameById2 == "0")
                            {


                                return "9";
                            }
                            shopNum1_OrderProduct.Attributes =
                    dataTable2.Rows[0]["setStock"].ToString();
                            shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
                            shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
                            shopNum1_OrderProduct.setStock = dataTable2.Rows[0]["setStock"].ToString();
                            shopNum1_OrderProduct.IsShipment = 0;
                            shopNum1_OrderProduct.IsReal =
                                Convert.ToInt32(dataTable2.Rows[0]["IsReal"].ToString());
                            shopNum1_OrderProduct.ExtensionAttriutes = "";
                            shopNum1_OrderProduct.IsJoinActivity = 0;
                            shopNum1_OrderProduct.CreateTime =
                                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderProduct.DetailedSpecifications = "";
                            shopNum1_OrderProduct.MemLoginID = MemloginID;
                            shopNum1_OrderProduct.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderProduct.ProductName = dataTable2.Rows[0]["Name"].ToString();
                            if (Color.Contains("%"))
                            {
                                shopNum1_OrderProduct.Color = HttpUtility.UrlDecode(Color);
                            }
                            else
                            {
                                shopNum1_OrderProduct.Color = Color;
                            }
                            if (Size.Contains("%"))
                            {
                                shopNum1_OrderProduct.Size = HttpUtility.UrlDecode(Size);
                            }
                            else
                            {
                                shopNum1_OrderProduct.Size = Size;
                            }

                            list.Add(shopNum1_OrderProduct);
                            if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                            {
                                IsEmail(shopNum1_OrderInfo.Email, Shopid, shopNum1_OrderInfo.OrderNumber,
                                    MemloginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                                    shopNum1_OrderInfo.Mobile);
                            }
                            if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                            {
                                string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                    " and memloginId='" + Shopid + "'");
                                IsMMS(nameById5, Shopid, MemloginID, shopNum1_OrderInfo.Tel,
                                    shopNum1_OrderInfo.OrderNumber, shopProductEdit.Rows[0]["Name"].ToString().Trim(), shopNum1_OrderInfo.Mobile);
                            }
                            var shopNum1_OrderInfo_Action =
                (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                      " and memloginid='" + MemloginID + "'");
                            int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
                            if (num2 > 0)
                            {
                                try
                                {
                                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                    {
                                        IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                                    }
                                    if (ShopSettings.GetValue("OrderIsMMS") == "1")
                                    {
                                        IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                                            nameById42221);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                return shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                            }

                            else
                            {
                                return "1";
                            }









                            #endregion
                        }
                        else
                        {
                            return "4";
                        }
                    }
                    else if (ShopCategoryID == 6)
                    {
                        if ((ShangPinPrice * Convert.ToInt32(BuyNumber)) >= 35900 && (ShangPinPrice * Convert.ToInt32(BuyNumber)) <= 36100)
                        {
                            QDSQPrice = 18000.00M;

                            #region 添加订单
                            string SuperiorRankGuid = "";
                            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                            string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                            if (TJMemberNO != null && TJMemberNO != "")
                            {
                                String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                                DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                                SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                            }
                            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                            shopNum1_OrderInfo.MemLoginID = MemloginID;
                            if (SuperiorRankGuid == "")
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                            }
                            else
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                            }
                            shopNum1_OrderInfo.Guid = Guid.NewGuid();
                            Order order = new Order();
                            shopNum1_OrderInfo.OrderNumber = OrderID;
                            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
                            shopNum1_OrderInfo.ShipmentStatus = 0;
                            shopNum1_OrderInfo.PaymentStatus = 0;
                            shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderInfo.OrderType = 0;
                            shopNum1_OrderInfo.Score_dv = 0;

                            shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


                            shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


                            shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

                            shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

                            shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

                            shopNum1_OrderInfo.Score_cv = 0;
                            shopNum1_OrderInfo.Score_max_hv = 0;
                            shopNum1_OrderInfo.shop_category_id = shop_category_id;
                            shopNum1_OrderInfo.AgentId = MYlabelAgentId;
                            shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                            shopNum1_OrderInfo.score_pv_cv = 0.02M;
                            //地址暂时处理
                            #region 地址未填写详细信息
                            shopNum1_OrderInfo.Name = Name;
                            shopNum1_OrderInfo.Email = Email;
                            shopNum1_OrderInfo.Address = Address;
                            shopNum1_OrderInfo.Postalcode = "";
                            shopNum1_OrderInfo.Tel = Tel;
                            shopNum1_OrderInfo.Mobile = Mobile;
                            shopNum1_OrderInfo.RegionCode = ""; //拿不准的数据

                            #endregion
                            shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                            if (QDSQPrice != null && QDSQPrice != 0)
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                            }
                            //else if (PostPrice == 0 && ShopCategoryID == 2)
                            //{
                            //    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                            //}
                            else
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = PostPrice;
                            }

                            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                            shopNum1_OrderInfo.OderStatus = 0;
                            //支付方式（1=预存款支付，2=智付支付）
                            if (PayMentType == 1)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                                shopNum1_OrderInfo.PaymentName = "预存款支付";
                            }
                            else if (PayMentType == 2)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                                shopNum1_OrderInfo.PaymentName = "微信支付";
                            }
                            else
                            {
                                return "7";
                            }

                            shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
                            shopNum1_OrderInfo.SellerToClientMsg = "";
                            shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                            shopNum1_OrderInfo.IsMemdelay = 0;
                            shopNum1_OrderInfo.OutOfStockOperate = "";
                            shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.PackName = "";
                            shopNum1_OrderInfo.PackPrice = 0m;
                            shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BlessCardName = "";
                            shopNum1_OrderInfo.BlessCardPrice = 0m;
                            shopNum1_OrderInfo.BlessCardContent = "";
                            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice) * Convert.ToDecimal(BuyNumber);
                            shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
                            shopNum1_OrderInfo.AlreadPayPrice = 0m;
                            shopNum1_OrderInfo.SurplusPrice = 0m;
                            shopNum1_OrderInfo.UseScore = 0;
                            shopNum1_OrderInfo.ScorePrice = 0m;

                            shopNum1_OrderInfo.JoinActiveType = -1;
                            shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                            shopNum1_OrderInfo.FromUrl = string.Empty;
                            shopNum1_OrderInfo.PayTime = null;
                            shopNum1_OrderInfo.DispatchTime = null;
                            shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                            shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.PayMemo = "";
                            shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BuyType = "";
                            shopNum1_OrderInfo.Discount = 0m;
                            shopNum1_OrderInfo.Deposit = 0m;
                            shopNum1_OrderInfo.JoinActiveType = 0;
                            shopNum1_OrderInfo.ActvieContent = "";
                            shopNum1_OrderInfo.UsedFavourTicket = "";
                            string text = string.Empty;
                            if (shopNum1_OrderInfo.FeeType == 2)
                            {
                                var random = new Random();
                                for (int i = 1; i < 7; i++)
                                {
                                    text += random.Next(1, 9).ToString();
                                }
                            }
                            shopNum1_OrderInfo.IdentifyCode = text;
                            string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
                            if (value == "true")
                            {
                                ShopSettings.GetValue("RecommendCommision");
                                double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                                shopNum1_OrderInfo.RecommendCommision =
                                    Convert.ToDecimal(Convert.ToDouble(shopNum1_OrderInfo.ProductPrice) * num);
                            }
                            else
                            {
                                shopNum1_OrderInfo.RecommendCommision = 0m;
                            }
                            Shop_Product_Action shop_Product_Action1 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                            DataTable dataTable2 = shop_Product_Action1.SearchProductShopByGuid_two(ProductGuid, ShopCategoryID);
                            shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
                            var list = new List<ShopNum1_OrderProduct>();
                            ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                            shopNum1_OrderProduct.BuyNumber = BuyNumber;
                            shopNum1_OrderProduct.shop_category_id = shop_category_id;
                            shopNum1_OrderProduct.Guid = Guid.NewGuid();
                            shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                            shopNum1_OrderProduct.ProductGuid = ProductGuid;
                            shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                            shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[0]["ProductNum"].ToString();
                            shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[0]["MarketPrice"].ToString());
                            shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(dataTable2.Rows[0]["ShopPrice"].ToString());
                            shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                            IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                            //DataTable dataTable33 =
                            //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

                            //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                            shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                            shopNum1_OrderProduct.OrderType = 0;
                            string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                    string.Concat(new[]
                            {
                                " And memloginid='",
                                MemloginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                MemloginID,
                                "' And ProductState=1)"
                            }));
                            if (nameById != "")
                            {


                                return "8";
                            }
                            string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
                   " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                            if (nameById2 == "0")
                            {


                                return "9";
                            }
                            shopNum1_OrderProduct.Attributes =
                    dataTable2.Rows[0]["setStock"].ToString();
                            shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
                            shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
                            shopNum1_OrderProduct.setStock = dataTable2.Rows[0]["setStock"].ToString();
                            shopNum1_OrderProduct.IsShipment = 0;
                            shopNum1_OrderProduct.IsReal =
                                Convert.ToInt32(dataTable2.Rows[0]["IsReal"].ToString());
                            shopNum1_OrderProduct.ExtensionAttriutes = "";
                            shopNum1_OrderProduct.IsJoinActivity = 0;
                            shopNum1_OrderProduct.CreateTime =
                                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderProduct.DetailedSpecifications = "";
                            shopNum1_OrderProduct.MemLoginID = MemloginID;
                            shopNum1_OrderProduct.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderProduct.ProductName = dataTable2.Rows[0]["Name"].ToString();
                            if (Color.Contains("%"))
                            {
                                shopNum1_OrderProduct.Color = HttpUtility.UrlDecode(Color);
                            }
                            else
                            {
                                shopNum1_OrderProduct.Color = Color;
                            }
                            if (Size.Contains("%"))
                            {
                                shopNum1_OrderProduct.Size = HttpUtility.UrlDecode(Size);
                            }
                            else
                            {
                                shopNum1_OrderProduct.Size = Size;
                            }

                            list.Add(shopNum1_OrderProduct);
                            if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                            {
                                IsEmail(shopNum1_OrderInfo.Email, Shopid, shopNum1_OrderInfo.OrderNumber,
                                    MemloginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                                    shopNum1_OrderInfo.Mobile);
                            }
                            if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                            {
                                string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                    " and memloginId='" + Shopid + "'");
                                IsMMS(nameById5, Shopid, MemloginID, shopNum1_OrderInfo.Tel,
                                    shopNum1_OrderInfo.OrderNumber, shopProductEdit.Rows[0]["Name"].ToString().Trim(), shopNum1_OrderInfo.Mobile);
                            }
                            var shopNum1_OrderInfo_Action =
                (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                      " and memloginid='" + MemloginID + "'");
                            int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
                            if (num2 > 0)
                            {
                                try
                                {
                                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                    {
                                        IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                                    }
                                    if (ShopSettings.GetValue("OrderIsMMS") == "1")
                                    {
                                        IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                                            nameById42221);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                return shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                            }

                            else
                            {
                                return "1";
                            }









                            #endregion

                        }
                        else
                        {
                            return "5";
                        }
                    }
                    else
                    {

                        #region 添加订单
                        string SuperiorRankGuid = "";
                        DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                        string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                        if (TJMemberNO != null && TJMemberNO != "")
                        {
                            String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                            DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                            SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                        }
                        ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                        shopNum1_OrderInfo.MemLoginID = MemloginID;
                        if (SuperiorRankGuid == "")
                        {
                            shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                        }
                        else
                        {
                            shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                        }
                        shopNum1_OrderInfo.Guid = Guid.NewGuid();
                        Order order = new Order();
                        shopNum1_OrderInfo.OrderNumber = OrderID;
                        shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
                        shopNum1_OrderInfo.ShipmentStatus = 0;
                        shopNum1_OrderInfo.PaymentStatus = 0;
                        shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                        shopNum1_OrderInfo.OrderType = 0;
                        shopNum1_OrderInfo.Score_dv = 0;

                        shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


                        shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


                        shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

                        shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

                        shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

                        shopNum1_OrderInfo.Score_cv = 0;
                        shopNum1_OrderInfo.Score_max_hv = 0;
                        shopNum1_OrderInfo.shop_category_id = shop_category_id;
                        shopNum1_OrderInfo.AgentId = MYlabelAgentId;
                        shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                        shopNum1_OrderInfo.score_pv_cv = 0.02M;
                        //地址暂时处理
                        #region 地址未填写详细信息
                        shopNum1_OrderInfo.Name = Name;
                        shopNum1_OrderInfo.Email = Email;
                        shopNum1_OrderInfo.Address = Address;
                        shopNum1_OrderInfo.Postalcode = "";
                        shopNum1_OrderInfo.Tel = Tel;
                        shopNum1_OrderInfo.Mobile = Mobile;
                        shopNum1_OrderInfo.RegionCode = ""; //拿不准的数据

                        #endregion
                        shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                        shopNum1_OrderInfo.DispatchType = 0;
                        shopNum1_OrderInfo.FeeType = 1;
                        shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                        if (QDSQPrice != null && QDSQPrice != 0)
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                        }
                        //else if (PostPrice == 0 && ShopCategoryID == 2)
                        //{
                        //    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                        //}
                        else
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = PostPrice;
                        }

                        shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                        shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                        shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
                        shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                        shopNum1_OrderInfo.OderStatus = 0;
                        //支付方式（1=预存款支付，2=智付支付）
                        if (PayMentType == 1)
                        {
                            shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                            shopNum1_OrderInfo.PaymentName = "预存款支付";
                        }
                        else if (PayMentType == 2)
                        {
                            shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                            shopNum1_OrderInfo.PaymentName = "微信支付";
                        }
                        else
                        {
                            return "7";
                        }

                        shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
                        shopNum1_OrderInfo.SellerToClientMsg = "";
                        shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                        shopNum1_OrderInfo.IsMemdelay = 0;
                        shopNum1_OrderInfo.OutOfStockOperate = "";
                        shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                        shopNum1_OrderInfo.PackName = "";
                        shopNum1_OrderInfo.PackPrice = 0m;
                        shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                        shopNum1_OrderInfo.BlessCardName = "";
                        shopNum1_OrderInfo.BlessCardPrice = 0m;
                        shopNum1_OrderInfo.BlessCardContent = "";
                        shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice) * Convert.ToDecimal(BuyNumber);
                        shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
                        shopNum1_OrderInfo.AlreadPayPrice = 0m;
                        shopNum1_OrderInfo.SurplusPrice = 0m;
                        shopNum1_OrderInfo.UseScore = 0;
                        shopNum1_OrderInfo.ScorePrice = 0m;

                        shopNum1_OrderInfo.JoinActiveType = -1;
                        shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                        shopNum1_OrderInfo.FromUrl = string.Empty;
                        shopNum1_OrderInfo.PayTime = null;
                        shopNum1_OrderInfo.DispatchTime = null;
                        shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                        shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        shopNum1_OrderInfo.PayMemo = "";
                        shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                        shopNum1_OrderInfo.BuyType = "";
                        shopNum1_OrderInfo.Discount = 0m;
                        shopNum1_OrderInfo.Deposit = 0m;
                        shopNum1_OrderInfo.JoinActiveType = 0;
                        shopNum1_OrderInfo.ActvieContent = "";
                        shopNum1_OrderInfo.UsedFavourTicket = "";
                        string text = string.Empty;
                        if (shopNum1_OrderInfo.FeeType == 2)
                        {
                            var random = new Random();
                            for (int i = 1; i < 7; i++)
                            {
                                text += random.Next(1, 9).ToString();
                            }
                        }
                        shopNum1_OrderInfo.IdentifyCode = text;
                        string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
                        if (value == "true")
                        {
                            ShopSettings.GetValue("RecommendCommision");
                            double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                            shopNum1_OrderInfo.RecommendCommision =
                                Convert.ToDecimal(Convert.ToDouble(shopNum1_OrderInfo.ProductPrice) * num);
                        }
                        else
                        {
                            shopNum1_OrderInfo.RecommendCommision = 0m;
                        }
                        Shop_Product_Action shop_Product_Action1 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                        DataTable dataTable2 = shop_Product_Action1.SearchProductShopByGuid_two(ProductGuid, ShopCategoryID);
                        shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                        shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
                        var list = new List<ShopNum1_OrderProduct>();
                        ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                        shopNum1_OrderProduct.BuyNumber = BuyNumber;
                        shopNum1_OrderProduct.shop_category_id = shop_category_id;
                        shopNum1_OrderProduct.Guid = Guid.NewGuid();
                        shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                        shopNum1_OrderProduct.ProductGuid = ProductGuid;
                        shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                        shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[0]["ProductNum"].ToString();
                        shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[0]["MarketPrice"].ToString());
                        shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(dataTable2.Rows[0]["ShopPrice"].ToString());
                        shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                        IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                        //DataTable dataTable33 =
                        //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

                        //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                        shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                        shopNum1_OrderProduct.OrderType = 0;
                        string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                string.Concat(new[]
                            {
                                " And memloginid='",
                                MemloginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                MemloginID,
                                "' And ProductState=1)"
                            }));
                        if (nameById != "")
                        {


                            return "8";
                        }
                        string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
               " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                        if (nameById2 == "0")
                        {


                            return "9";
                        }
                        shopNum1_OrderProduct.Attributes =
                dataTable2.Rows[0]["setStock"].ToString();
                        shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
                        shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
                        shopNum1_OrderProduct.setStock = dataTable2.Rows[0]["setStock"].ToString();
                        shopNum1_OrderProduct.IsShipment = 0;
                        shopNum1_OrderProduct.IsReal =
                            Convert.ToInt32(dataTable2.Rows[0]["IsReal"].ToString());
                        shopNum1_OrderProduct.ExtensionAttriutes = "";
                        shopNum1_OrderProduct.IsJoinActivity = 0;
                        shopNum1_OrderProduct.CreateTime =
                            Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        shopNum1_OrderProduct.DetailedSpecifications = "";
                        shopNum1_OrderProduct.MemLoginID = MemloginID;
                        shopNum1_OrderProduct.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                        shopNum1_OrderProduct.ProductName = dataTable2.Rows[0]["Name"].ToString();
                        if (Color.Contains("%"))
                        {
                            shopNum1_OrderProduct.Color = HttpUtility.UrlDecode(Color);
                        }
                        else
                        {
                            shopNum1_OrderProduct.Color = Color;
                        }
                        if (Size.Contains("%"))
                        {
                            shopNum1_OrderProduct.Size = HttpUtility.UrlDecode(Size);
                        }
                        else
                        {
                            shopNum1_OrderProduct.Size = Size;
                        }

                        list.Add(shopNum1_OrderProduct);
                        if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                        {
                            IsEmail(shopNum1_OrderInfo.Email, Shopid, shopNum1_OrderInfo.OrderNumber,
                                MemloginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                                shopNum1_OrderInfo.Mobile);
                        }
                        if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                        {
                            string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                " and memloginId='" + Shopid + "'");
                            IsMMS(nameById5, Shopid, MemloginID, shopNum1_OrderInfo.Tel,
                                shopNum1_OrderInfo.OrderNumber, shopProductEdit.Rows[0]["Name"].ToString().Trim(), shopNum1_OrderInfo.Mobile);
                        }
                        var shopNum1_OrderInfo_Action =
            (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                        string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                  " and memloginid='" + MemloginID + "'");
                        int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
                        if (num2 > 0)
                        {
                            try
                            {
                                if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                {
                                    IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                                }
                                if (ShopSettings.GetValue("OrderIsMMS") == "1")
                                {
                                    IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                                        nameById42221);
                                }
                            }
                            catch (Exception)
                            {
                            }
                            return shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                        }

                        else
                        {
                            return "1";
                        }









                        #endregion
                    }
                }
                #endregion
            }

            return "2";






            #endregion
        }




        /// <summary>
        /// 微信商城创建购物车订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="OpenID"></param>
        /// <param name="ShopCategoryID"></param>
        /// <param name="PayMentType"></param>
        /// <param name="ProductIds"></param>
        /// <param name="OrderPrice"></param>
        /// <param name="PostPrice"></param>
        /// <param name="TextBoxMessage"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Address"></param>
        /// <param name="Tel"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public string CreateOrderCar(string OrderID, string OpenID, int ShopCategoryID, int PayMentType, string ProductIds, decimal OrderPrice, decimal PostPrice, string TextBoxMessage, string Name, string Email, string Address, string Tel, string Mobile)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();



            DataTable memOpenID = member_Action.SelectMemberByOpenId(OpenID);


            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();


            ServiceAgent = "C0000001";

            DataTable tbc = member_Action.SearchAreaAgentExist(ServiceAgent);
            if (tbc.Rows.Count > 0)
            {
                if (PayMentType == null || PayMentType == 0)
                {
                    return "3";
                }
                else
                {


                    string tel;
                    var list = new List<ShopNum1_OrderInfo>();
                    var list2 = new List<ShopNum1_OrderProduct>();
                    IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();


                    string orderid = OrderID;
                    int num = 0;

                    string SuperiorRankGuid = "";
                    DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                    string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                    if (TJMemberNO != null && TJMemberNO != "")
                    {

                        String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());

                        DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                        SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                    }
                    ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                    shopNum1_OrderInfo.Guid = Guid.NewGuid();
                    shopNum1_OrderInfo.MemLoginID = MemloginID;
                    if (SuperiorRankGuid == "")
                    {
                        shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                    }
                    else
                    {
                        shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                    }
                    shopNum1_OrderInfo.TradeID = orderid;
                    shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                    shopNum1_OrderInfo.OderStatus = 0;


                    shopNum1_OrderInfo.ShipmentStatus = 0;
                    shopNum1_OrderInfo.PaymentStatus = 0;
                    shopNum1_OrderInfo.OrderType = 0;
                    shopNum1_OrderInfo.PayMentMemLoginID = MemloginID;
                    shopNum1_OrderInfo.IsMinus = 0;


                    //地址暂时处理
                    #region 地址未填写详细信息
                    shopNum1_OrderInfo.Name = Name;
                    shopNum1_OrderInfo.Email = Email;
                    shopNum1_OrderInfo.Address = Address;
                    shopNum1_OrderInfo.Postalcode = "";
                    shopNum1_OrderInfo.Tel = Tel;
                    shopNum1_OrderInfo.Mobile = Mobile;
                    shopNum1_OrderInfo.RegionCode = ""; //拿不准的数据

                    #endregion
                    tel = Tel;

                    //支付方式（1=预存款支付，2=智付支付）
                    if (PayMentType == 1)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                        shopNum1_OrderInfo.PaymentName = "预存款支付";
                    }
                    else if (PayMentType == 2)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                        shopNum1_OrderInfo.PaymentName = "微信支付";
                    }
                    else
                    {
                        return "7";
                    }
                    shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                    shopNum1_OrderInfo.SellerToClientMsg = "";
                    shopNum1_OrderInfo.IsMemdelay = 0;
                    shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));

                    shopNum1_OrderInfo.InvoiceTitle = "";
                    shopNum1_OrderInfo.InvoiceContent = "";
                    shopNum1_OrderInfo.InvoiceType = "";
                    shopNum1_OrderInfo.InvoiceTax = 0m;

                    shopNum1_OrderInfo.PaymentPrice = 0M;
                    shopNum1_OrderInfo.OutOfStockOperate = "";
                    shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.PackName = "";
                    shopNum1_OrderInfo.PackPrice = 0m;
                    shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.BlessCardName = "";
                    shopNum1_OrderInfo.BlessCardPrice = 0m;
                    shopNum1_OrderInfo.BlessCardContent = "";
                    shopNum1_OrderInfo.AlreadPayPrice = 0m;
                    shopNum1_OrderInfo.SurplusPrice = 0m;
                    shopNum1_OrderInfo.UseScore = 0;
                    shopNum1_OrderInfo.ScorePrice = 0m;
                    shopNum1_OrderInfo.JoinActiveType = -1;
                    shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                    shopNum1_OrderInfo.FromUrl = string.Empty;
                    shopNum1_OrderInfo.PayTime = null;
                    shopNum1_OrderInfo.DispatchTime = null;
                    shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                    shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderInfo.PayMemo = "";
                    shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.BuyType = "";
                    shopNum1_OrderInfo.Discount = 0m;
                    shopNum1_OrderInfo.Deposit = 0m;
                    shopNum1_OrderInfo.JoinActiveType = 0;
                    shopNum1_OrderInfo.ActvieContent = "";
                    shopNum1_OrderInfo.UsedFavourTicket = "";
                    shopNum1_OrderInfo.Guid = Guid.NewGuid();


                    if (ProductIds.Contains("|"))
                    {
                        string[] productsDetiel = ProductIds.Replace("'", "").Split('|');
                        for (int i = 0; i < productsDetiel.Length; i++)
                        {
                            string[] productOne = productsDetiel[i].ToString().Split(',');
                            string productOneID = "";
                            string productOneBuyNumber = "";
                            string productOneSizeColoe = "";
                            if (productOne[0] != null || productOne[0] != "")
                            {
                                productOneID = productOne[0].ToString();
                            }
                            if (productOne[1] != null || productOne[1] != "")
                            {
                                productOneBuyNumber = productOne[1].ToString();
                            }
                            if (productOne[2] != null || productOne[2] != "")
                            {
                                productOneSizeColoe = productOne[2].ToString();
                            }
                            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                            //DataTable ProductAll = shop_Product_Action.SeleceAllProducltOfId(productOneID);
                            ProductGuid = productOneID;

                            DataTable shopProductEdit = shop_Product_Action.GetShopProductEditWeixin(ProductGuid, ShopCategoryID);

                            shopNum1_OrderInfo.score_pv_cv = 0M;

                            //得到积分

                            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) >= 0)
                            {
                                shopNum1_OrderInfo.Score_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(productOneBuyNumber);
                            }
                            //可用积分
                            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) < 0)
                            {
                                shopNum1_OrderInfo.score_reduce_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(productOneBuyNumber);
                            }
                            //得到红包
                            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) >= 0)
                            {
                                shopNum1_OrderInfo.Score_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) * Convert.ToDecimal(productOneBuyNumber);
                            }
                            //可用红包
                            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) < 0)
                            {
                                shopNum1_OrderInfo.score_reduce_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) * Convert.ToDecimal(productOneBuyNumber);
                            }

                            shopNum1_OrderInfo.Score_dv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(productOneBuyNumber);
                            shopNum1_OrderInfo.Score_pv_b += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(productOneBuyNumber);

                            shopNum1_OrderInfo.ShopName = shopProductEdit.Rows[0]["ShopName"].ToString();
                            shopNum1_OrderInfo.ShopID = shopProductEdit.Rows[0]["ShopID"].ToString();


                            string[] SizeColor = productOneSizeColoe.Split(';');
                            string size = "";
                            string color = "";
                            if (SizeColor.Length == 1)
                            {
                                size = "无";
                                color = "无";
                            }
                            else
                            {
                                size = SizeColor[0].ToString();
                                color = SizeColor[1].ToString();
                                if (size.Contains("%"))
                                {
                                    size = HttpUtility.UrlDecode(size);
                                }
                                if (color.Contains("%"))
                                {
                                    color = HttpUtility.UrlDecode(color);
                                }
                            }

                            list2.Add(new ShopNum1_OrderProduct
                                {
                                    ProductImg = shopProductEdit.Rows[0]["OriginalImage"].ToString(),
                                    OrderType = 0,
                                    Guid = Guid.NewGuid(),
                                    OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                                    ProductGuid = ProductGuid.ToUpper(),
                                    GroupPrice = Convert.ToDecimal("0.00"),
                                    SpecificationName = "",
                                    SpecificationValue = "",
                                    setStock = "0",
                                    ProductName = shopProductEdit.Rows[0]["Name"].ToString(),
                                    RepertoryNumber = "",
                                    BuyNumber = Convert.ToInt32(productOneBuyNumber),
                                    MarketPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["MarketPrice"].ToString()),
                                    ShopPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"].ToString()),
                                    BuyPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"].ToString()),
                                    Attributes = "0",
                                    IsShipment = 0,
                                    IsReal = 1,
                                    ExtensionAttriutes = "",
                                    IsJoinActivity = 0,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    DetailedSpecifications = "",
                                    MemLoginID = MemloginID,
                                    ShopID = shopProductEdit.Rows[0]["ShopID"].ToString(),
                                    shop_category_id = ShopCategoryID,
                                    Size = size,
                                    Color = color

                                });















                        }
                    }
                    else
                    {
                        string[] productOne = ProductIds.ToString().Split(',');
                        string productOneID = "";
                        string productOneBuyNumber = "";
                        string productOneSizeColoe = "";
                        if (productOne[0] != null || productOne[0] != "")
                        {
                            productOneID = productOne[0].ToString();
                        }
                        if (productOne[1] != null || productOne[1] != "")
                        {
                            productOneBuyNumber = productOne[1].ToString();
                        }
                        if (productOne[2] != null || productOne[2] != "")
                        {
                            productOneSizeColoe = productOne[2].ToString();
                        }
                        Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                        //DataTable ProductAll = shop_Product_Action.SeleceAllProducltOfId(productOneID);
                        ProductGuid = productOneID;

                        DataTable shopProductEdit = shop_Product_Action.GetShopProductEditWeixin(ProductGuid, ShopCategoryID);

                        shopNum1_OrderInfo.score_pv_cv = 0M;

                        //得到积分

                        if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) >= 0)
                        {
                            shopNum1_OrderInfo.Score_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(productOneBuyNumber);
                        }
                        //可用积分
                        if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) < 0)
                        {
                            shopNum1_OrderInfo.score_reduce_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(productOneBuyNumber);
                        }
                        //得到红包
                        if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) >= 0)
                        {
                            shopNum1_OrderInfo.Score_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) * Convert.ToDecimal(productOneBuyNumber);
                        }
                        //可用红包
                        if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) < 0)
                        {
                            shopNum1_OrderInfo.score_reduce_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) * Convert.ToDecimal(productOneBuyNumber);
                        }

                        shopNum1_OrderInfo.Score_dv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(productOneBuyNumber);
                        shopNum1_OrderInfo.Score_pv_b += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(productOneBuyNumber);

                        shopNum1_OrderInfo.ShopName = shopProductEdit.Rows[0]["ShopName"].ToString();
                        shopNum1_OrderInfo.ShopID = shopProductEdit.Rows[0]["ShopID"].ToString();


                        string[] SizeColor = productOneSizeColoe.Split(';');
                        string size = "";
                        string color = "";
                        if (SizeColor.Length == 1)
                        {
                            size = "无";
                            color = "无";
                        }
                        else
                        {
                            size = SizeColor[1].ToString();
                            color = SizeColor[0].ToString();
                            if (size.Contains("%"))
                            {
                                size = HttpUtility.UrlDecode(size);
                            }
                            if (color.Contains("%"))
                            {
                                color = HttpUtility.UrlDecode(color);
                            }
                        }



                        list2.Add(new ShopNum1_OrderProduct
                            {

                                ProductImg = shopProductEdit.Rows[0]["OriginalImage"].ToString(),
                                OrderType = 0,
                                Guid = Guid.NewGuid(),
                                OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                                ProductGuid = ProductGuid.ToUpper(),
                                GroupPrice = Convert.ToDecimal("0.00"),
                                SpecificationName = "",
                                SpecificationValue = "",
                                setStock = "0",
                                ProductName = shopProductEdit.Rows[0]["Name"].ToString(),
                                RepertoryNumber = "",
                                BuyNumber = Convert.ToInt32(productOneBuyNumber),
                                MarketPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["MarketPrice"].ToString()),
                                ShopPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"].ToString()),
                                BuyPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"].ToString()),
                                Attributes = "0",
                                IsShipment = 0,
                                IsReal = 1,
                                ExtensionAttriutes = "",
                                IsJoinActivity = 0,
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                DetailedSpecifications = "",
                                MemLoginID = MemloginID,
                                ShopID = shopProductEdit.Rows[0]["ShopID"].ToString(),
                                shop_category_id = ShopCategoryID,
                                Size = size,
                                Color = color

                            });
                    }
                    shopNum1_OrderInfo.shop_category_id = ShopCategoryID;



                    if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                    {
                        IsEmail(shopNum1_OrderInfo.Email, shopNum1_OrderInfo.ShopID, shopNum1_OrderInfo.OrderNumber,
                            MemloginID, shopNum1_OrderInfo.Tel, "", shopNum1_OrderInfo.Mobile);
                    }
                    if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                    {
                        string nameById = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                            " and memloginId='" + shopNum1_OrderInfo.ShopID + "'");
                        IsMMS(nameById, shopNum1_OrderInfo.ShopID, MemloginID, shopNum1_OrderInfo.Tel,
                            shopNum1_OrderInfo.OrderNumber, "", shopNum1_OrderInfo.Mobile);
                    }
                    string value2 = ShopSettings.GetValue("IsRecommendCommisionOpen");
                    if (value2 == "true")
                    {
                        ShopSettings.GetValue("RecommendCommision");
                        double num3 = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                        shopNum1_OrderInfo.RecommendCommision =
                            Convert.ToDecimal(Convert.ToDouble(OrderPrice) * num3);
                    }
                    else
                    {
                        shopNum1_OrderInfo.RecommendCommision = 0m;
                    }
                    shopNum1_OrderInfo.OrderNumber = shopNum1_OrderInfo.TradeID;
                    shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(OrderPrice);
                    shopNum1_OrderInfo.ProductPv_b = shopNum1_OrderInfo.Score_pv_b;


                    shopNum1_OrderInfo.ShouldPayPrice = OrderPrice;
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = PostPrice;

                    list.Add(shopNum1_OrderInfo);


                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
      (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    int num4 = shopNum1_OrderInfo_Action.Add(list, list2);
                    if (num4 > 0)
                    {



                        ShopNum1_Member_Action shopNum1_Member_Action =
                            (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable memberInfoByMemLoginID =
                            shopNum1_Member_Action.GetMemberInfoByMemLoginID(MemloginID);
                        if (memberInfoByMemLoginID.Rows.Count > 0)
                        {
                            if (ShopSettings.GetValue("OrderIsEmail") == "1")
                            {
                                IsEmail(orderid.ToString(), MemloginID,
                                    memberInfoByMemLoginID.Rows[0]["email"].ToString());
                            }
                            if (ShopSettings.GetValue("SubmitOrderIsMMS") == "1")
                            {
                                IsMMS(orderid.ToString(), MemloginID, tel);
                            }
                        }
                        return orderid.ToString() + "," + shopNum1_OrderInfo.Guid;
                    }

                    return "1";









                }
            }

            else
            {
                return "2";
            }



        }


        public PostPrice PostPrice(string ShopID)
        {

            PostPrice post = new PostPrice();


            ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
            DataTable table = PostageAction.SelectPrice(ShopID);
            post.FirstHeavyPrice = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
            post.AfterHeavyPrice = Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]);
            post.FirstHeavy = Convert.ToDecimal(table.Rows[0]["FirstHeavy"]);

            return post;
        }
        //手机APP购物车邮费接口
        protected string PostPriceCar(string ShopID, int ShopCategoryID, string ProductGuids, string MemloginID)
        {
            PostPrice post = new PostPrice();

            IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = LogicFactory.CreateShopNum1_Cart_Action();

            DataTable productInfoByCartProductGuid =
                 ishopNum1_Cart_Action_0.GetProductInfoByCartProductGuid(MemloginID, ShopID, ProductGuids);
            int num = 0;
            decimal MZPrice = Convert.ToDecimal(0.0);
            decimal num5 = Convert.ToDecimal(0.0);
            decimal Postage = Convert.ToDecimal(0.0);
            decimal HDFK = Convert.ToDecimal(1.1);
            decimal VIPYF = Convert.ToDecimal(1.2);
            decimal MYPostage = Convert.ToDecimal(0.0);
            decimal WLPostage = Convert.ToDecimal(0.0);
            decimal VIPPostage = Convert.ToDecimal(0.0);
            string PostpriceReulst = "";
            for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
            {
                num5 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
                MZPrice += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["ShopPrice"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
            }
            if (ShopCategoryID == 5 || ShopCategoryID == 7 || ShopCategoryID == 9)
            {
                ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                DataTable table = PostageAction.SelectPrice(ShopID.Trim());
                if (num5 != 0 && (num5 < Convert.ToDecimal(table.Rows[0]["FirstHeavy"]) || num5 == Convert.ToDecimal(table.Rows[0]["FirstHeavy"])))
                {
                    Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;

                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (MZPrice > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;

                        }
                    }

                }
                else if (num5 > Convert.ToDecimal(table.Rows[0]["FirstHeavy"]))
                {
                    Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;
                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (MZPrice > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;


                        }
                    }

                }

            }

            if (num == 1)
            {



                if (Postage != 0m)
                {

                    return Postage.ToString();


                }
                if (HDFK == 0m)
                {

                    return HDFK.ToString();

                }
                if (VIPYF == 0m)
                {

                    //PostpriceReulst = PostpriceReulst + "不使用红包免邮" + VIPPostage + "丨";

                }

            }


            return "0";




        }

        protected string PostPriceDan(int ShopCategoryID, string ProductGuids, int BuyNumber, string MemloginID)
        {
            PostPrice post = new PostPrice();

            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            DataTable productInfoByCartProductGuid = shop_Product_Action.GetShopProductEdit(ProductGuids, ShopCategoryID);
            int num = 0;
            decimal MZPrice = Convert.ToDecimal(0.0);
            decimal num5 = Convert.ToDecimal(0.0);
            decimal Postage = Convert.ToDecimal(0.0);
            decimal HDFK = Convert.ToDecimal(1.1);
            decimal VIPYF = Convert.ToDecimal(1.2);
            decimal MYPostage = Convert.ToDecimal(0.0);
            decimal WLPostage = Convert.ToDecimal(0.0);
            decimal VIPPostage = Convert.ToDecimal(0.0);
            string PostpriceReulst = "";
            for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()))
                {
                    num5 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()) * Convert.ToDecimal(BuyNumber);
                }
            }
            if (ShopCategoryID == 5 || ShopCategoryID == 7 || ShopCategoryID == 9)
            {
                string memberid = productInfoByCartProductGuid.Rows[0]["MemLoginID"].ToString();
                ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                DataTable table = PostageAction.SelectPrice(memberid.Trim());
                if (num5 != 0 && (num5 < Convert.ToDecimal(table.Rows[0]["FirstHeavy"]) || num5 == Convert.ToDecimal(table.Rows[0]["FirstHeavy"])))
                {
                    Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;

                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber) > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;

                        }
                    }

                }
                else if (num5 > Convert.ToDecimal(table.Rows[0]["FirstHeavy"]))
                {
                    Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;
                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber) > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;


                        }
                    }

                }

            }

            if (num == 1)
            {



                if (Postage != 0m)
                {

                    return Postage.ToString();


                }
                if (HDFK == 0m)
                {

                    return HDFK.ToString();

                }
                if (VIPYF == 0m)
                {

                    //PostpriceReulst = PostpriceReulst + "不使用红包免邮" + VIPPostage + "丨";

                }

            }


            return "0";




        }























        protected void IsEmail(string strEmail, string strName, string OrderNumber, string strMemloginId,
    string strHomeTel, string strProductName, string strMobile)
        {
            if (!string.IsNullOrEmpty(strEmail))
            {
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                string memLoginID = orderInfo.Name = strMemloginId;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text = string.Empty;
                string emailTitle = string.Empty;
                string text2 = "457f965d-f1cc-45cf-b4a5-ddbbd6b7fdc0";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text = text.Replace("{$Name}", strName);
                text = text.Replace("{$OrderNumber}", OrderNumber);
                text = text.Replace("{$MemLoginId}", strMemloginId);
                text = text.Replace("{$UserTel}", strHomeTel);
                text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                text = text.Replace("{$ShopName}", orderInfo.ShopName);
                text = text.Replace("{$ProductName}", strProductName);
                text = text.Replace("{$UserMobile}", strMobile);
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                var sendEmail = new SendEmail();
                sendEmail.Emails(strEmail, memLoginID, emailTitle, text2, emailBody);
            }
        }


        protected void IsMMS(string strTel, string strName, string strMemLoginId, string strHomeTel,
                string strOrderNumber, string strProductName, string strMobile)
        {
            if (!string.IsNullOrEmpty(strTel))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("190d25f8-a9e9-4162-b4e8-0a3954c83473", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", strName);
                    text = text.Replace("{$OrderNumber}", strOrderNumber);
                    text = text.Replace("{$MemLoginId}", strMemLoginId);
                    text = text.Replace("{$UserTel}", strHomeTel);
                    text = text.Replace("{$SendTime}", DateTime.Now.ToString());
                    text = text.Replace("{$ProductName}", strProductName);
                    text = text.Replace("{$UserMobile}", strMobile);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(strTel, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(strMemLoginId, strMobile.Trim(), text, mMsTitle, 2,
                            "190d25f8-a9e9-4162-b4e8-0a3954c83473");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(strMemLoginId, strMobile.Trim(), text, mMsTitle, 0,
                            "190d25f8-a9e9-4162-b4e8-0a3954c83473");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }
        protected void IsEmail(string guid, string OrderNumber)
        {
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
            if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
            {
                string email = orderInfoByGuid.Rows[0]["Email"].ToString();
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                string text = orderInfo.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                orderInfo.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text2 = string.Empty;
                string emailTitle = string.Empty;
                string text3 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text2 = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text2 = text2.Replace("{$Name}", text);
                text2 = text2.Replace("{$OrderNumber}", OrderNumber);
                text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                var sendEmail = new SendEmail();
                sendEmail.Emails(email, text, emailTitle, text3, emailBody);
            }
        }
        protected void IsEmail(string OrderNumber, string MemLoginID, string email)
        {
            if (email != null && !(email == ""))
            {
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                orderInfo.Name = MemLoginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text = string.Empty;
                string emailTitle = string.Empty;
                string text2 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text = text.Replace("{$Name}", MemLoginID);
                text = text.Replace("{$OrderNumber}", OrderNumber);
                text = text.Replace("{$ShopName}", "唐江宝宝");
                text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                var sendEmail = new SendEmail();
                sendEmail.Emails(email, MemLoginID, emailTitle, text2, emailBody);
            }
        }
        protected void IsMMS(string OrderNumber, string memloginID, string string_8)
        {
            if (!(string_8.Trim() == ""))
            {
                var orderInfo = new OrderInfo();
                orderInfo.Name = memloginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = ShopSettings.GetValue("Name");
                string text = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
                if (editInfo != null && editInfo.Rows.Count > 0)
                {
                    string text2 = editInfo.Rows[0]["Remark"].ToString();
                    text2 = text2.Replace("{$Name}", orderInfo.Name);
                    text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
                    text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                    text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    var sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                    sMS.Send(string_8.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), text2, mMsTitle, 2,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), text2, mMsTitle, 0,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }
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


        public decimal SelectPvbBySuprice(string memloginNO)
        {
            String yy = DateTime.Now.Year.ToString();

            String mm = DateTime.Now.Month.ToString();
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable MemberTable = action.SelectMemberloginid_By_NO(memloginNO);
            DateTime startMonth = DateTime.Parse(yy + "/" + mm + "/1");
            string MemLoginID = MemberTable.Rows[0]["MemLoginID"].ToString();
            decimal pvb = 0;
            if (Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
               " AND   MemLoginID ='" + MemLoginID + "' and Date>'" + startMonth + "'") == "" || Convert.ToDecimal(Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", " AND   MemLoginID ='" + MemLoginID + "' and Date>'" + startMonth + "'")) < 0)
            {
                pvb = 0;
            }
            else
            {
                pvb = Convert.ToDecimal(Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
              " AND   MemLoginID ='" + MemLoginID + "' and Date>'" + startMonth + "'"));
            }
            return pvb;
        }
        public DataTable SelectNext(string MemLoginID)
        {

            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string MemLoginNO = action.SelectidByMemLoginNO(MemLoginID).Rows[0]["MemLoginNO"].ToString();
            return action.SelectSuperiorGetMemLoginID(MemLoginNO);
        }

        public decimal AllPVB(string MemLoginID)
        {
            decimal pvb = 0;
            DataTable SelectSuperiorTable = SelectNext(MemLoginID);
            for (int i = 0; i < SelectSuperiorTable.Rows.Count; i++)
            {
                pvb += Convert.ToDecimal(SelectPvbBySuprice(SelectSuperiorTable.Rows[i]["MemLoginNO"].ToString()));
                DataTable table = SelectNext(SelectSuperiorTable.Rows[i]["MemLoginID"].ToString());
                if (table.Rows.Count > 0)
                {
                    pvb += AllPVB(SelectSuperiorTable.Rows[i]["MemLoginID"].ToString());
                }
            }
            return pvb;
        }



    }
}