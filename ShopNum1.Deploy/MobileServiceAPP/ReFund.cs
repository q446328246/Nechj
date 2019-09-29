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
    public class ReFund : System.Web.UI.Page
    {
        #region 参数
        //MemLoginID-买家
        //OrderGuid-订单Guid
        //ShopID-卖家
        //RefundReason-退款原因
        //Introduce-退款说明
        //RefundTypes-（1=退款，2=退货）
        #endregion

        /// <summary>
        /// 手机订单退款
        /// </summary>
        public string MobileOrderRefund(string MemLoginID, string OrderGuid, string ShopID, string RefundReason, string Introduce, string RefundTypes)
        {
            ShopNum1_Refund refund = new ShopNum1_Refund
            {
                ApplyTime = DateTime.Now,
                MemLoginID = MemLoginID,
                OrderID = OrderGuid,
                ProductGuid = new Guid(OrderGuid),
                ShopID = ShopID
            };
            ShopNum1_OrderProduct_Action orderProduct = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
            ShopNum1_OrderInfo_Action action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable ordertimetable = action.SelectOrderTime(OrderGuid);
            DateTime OrderTime = Convert.ToDateTime(ordertimetable.Rows[0]["PayTime"]);
            string CategoryID = ordertimetable.Rows[0]["shop_category_id"].ToString();
            string OrderNumber = ordertimetable.Rows[0]["OrderNumber"].ToString();
            int orderstatus = Convert.ToInt32(ordertimetable.Rows[0]["OderStatus"]);
            string OrderType = "";
            DateTime d1 = DateTime.Now;
            TimeSpan d3 = d1.Subtract(OrderTime);
            if (d3.Days > 7)
            {

                return "1";//付款时间大于15天后，不能申请退款
            }
            if (orderstatus > 2) 
            {
                return "2";
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
            int num = 1;
            action3.DeleteRefundByOrId(refund.OrderID);
            //num = action3.Add(refund);
            if (num > 0)
            {
                if (refund.RefundType == 0)
                {
                    ShopNum1_OrderInfo_Action action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();


                    int cl = action2.MobileRefund(OrderGuid, MemLoginID, "", "", "2", "1", "0", Convert.ToString(Guid.NewGuid()), "", "买家申请退款", "等待卖家处理",refund);
                    if (cl != 0)
                    {
                        #region OrderOperateLog
                        //if (!string.IsNullOrEmpty(OrderGuid))
                        //{
                        //    var orderOperateLog = new ShopNum1_OrderOperateLog
                        //    {
                        //        Guid = Guid.NewGuid(),
                        //        OrderInfoGuid = new Guid(OrderGuid),
                        //        OderStatus = 1,
                        //        ShipmentStatus = 0,
                        //        PaymentStatus = 0,
                        //        CurrentStateMsg = "买家申请退款",
                        //        NextStateMsg = "等待卖家处理",
                        //        Memo = "",
                        //        OperateDateTime = DateTime.Now,
                        //        IsDeleted = 0,
                        //        CreateUser = MemLoginID
                        //    };
                        //    ((ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                        //        orderOperateLog);
                        //}
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
                        return "3";//退款成功
                    }
                    else
                    {
                        return "2";//操作失败
                    }
                }
                else
                {
                    int cl = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).MobileRefund(
                        OrderGuid, MemLoginID, "", "3", "", "1", "0", Convert.ToString(Guid.NewGuid()), "", "买家申请退货", "等待卖家处理", refund);
                    if (cl != 0)
                    {
                        #region OrderOperateLog
                        //if (!string.IsNullOrEmpty(OrderGuid))
                        //{
                        //    var orderOperateLog = new ShopNum1_OrderOperateLog
                        //    {
                        //        Guid = Guid.NewGuid(),
                        //        OrderInfoGuid = new Guid(OrderGuid),
                        //        OderStatus = 1,
                        //        ShipmentStatus = 0,
                        //        PaymentStatus = 0,
                        //        CurrentStateMsg = "买家申请退货",
                        //        NextStateMsg = "等待卖家处理",
                        //        Memo = "",
                        //        OperateDateTime = DateTime.Now,
                        //        IsDeleted = 0,
                        //        CreateUser = MemLoginID
                        //    };
                        //    ((ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                        //        orderOperateLog);
                        //}
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
                        return "4";//退货成功
                    }
                    else
                    {
                        return "2";//操作失败
                    }
                }

            }
            return "2";//操作失败
        }






    }
}