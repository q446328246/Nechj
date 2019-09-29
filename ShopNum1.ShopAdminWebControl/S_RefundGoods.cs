using System;
using System.Data;
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
using System.Web;
using ShopNum1.Common.ShopNum1.Common;
//using TJapi;


namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_RefundGoods : BaseShopWebControl
    {
        private HtmlGenericControl LogisticInfo;
        private Button btnSubmit;
        private HtmlInputHidden hidAdvancePayment;
        private HtmlInputHidden hidIsReceive;
        private HtmlInputHidden hidMemloginId;
        private HtmlInputHidden hidPayMentName;
        private HtmlInputHidden hidPaymentmemLoginid;
        private HtmlInputHidden hidProductGuID;
        private HtmlInputHidden hidOrderNumber;
        private HtmlInputHidden hidcategory;
        private HtmlInputHidden hidRefundReason;
        private HtmlInputHidden hidRefundStatus;
        private HtmlInputHidden hidShopId;
        private HtmlInputHidden hidShopPayment;
        private HtmlInputHidden hidShouldPayprice;
        private HtmlInputHidden hidSureState;
        private HtmlImage htmlImage_0;
        private Label lblExit;
        private Label lblExitMoney;
        private string skinFilename = "S_RefundGoods.ascx";
        private HtmlTextArea txtIntroduce;
        private HtmlTextArea txtReason;
        private string TZtype;

        public S_RefundGoods()
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
                CreateTime = DateTime.Now,
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = mobile,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }

        public void AdvancePaymentModify(string MemLoginID, decimal AddPrice)
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


            if (action.RefundUpdateAdvancePaymentMem(MemLoginID, AddPrice) > 0)
            {
                MessageBox.Show("退款成功！");
            }
            else
            {
                MessageBox.Show("退款失败！");
            }
        }

        public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo,
            string shopMemloginID, int type)
        {

            //if ((payMoney.ToString() != "0.00") && (payMoney.ToString() != "0"))
            //{

            if (type == 1)
            {
                var orderInfoByGuid_two =
            ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action());
                DataTable orderInfoByGuid_fres =
                   orderInfoByGuid_two.GetOrderInfoByGuid(hidProductGuID.Value);

                string ordernumid = Convert.ToString(orderInfoByGuid_fres.Rows[0]["OrderNumber"]);

                DataTable orderRefund = orderInfoByGuid_two.SelectOrderRefund(ordernumid);
                DataTable memloginAll = orderInfoByGuid_two.SelectShopNum1_Member(shopMemloginID);
                string TJmid = orderRefund.Rows[0]["reduce_score_tjid"].ToString();
                DataTable memloginTJ = orderInfoByGuid_two.SelectShopNum1_Member(TJmid);
                string RefundType = orderRefund.Rows[0]["RefundType"].ToString();
                if (RefundType == "0")
                {
                    orderInfoByGuid_two.UpdateRefunType(ordernumid);
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

                }
                else
                {
                    return;
                }
                //}
            }
        }

        public void JieKou3g(string OrderNumber)
        {
            var orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = orderaction.SerchOrderInfoAll(OrderNumber);
            if (table.Rows.Count == 0)
            {
                return;
            }
            string MJmember = table.Rows[0]["MemLoginID"].ToString();


            DataTable Usertable = memaction.SearchMembertwo(MJmember);
            string MJmemberNo = Usertable.Rows[0]["MemLoginNO"].ToString();
            if (table.Rows[0]["shop_category_id"].ToString() != "2" && table.Rows[0]["shop_category_id"].ToString() != "5")
            {
                orderaction.NoReFund3Gorder(OrderNumber, MJmemberNo, Convert.ToDecimal(table.Rows[0]["Score_pv_a"]));
            }


        }

        public void JieKou_Tui(string orderid)
        {
            var orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
            DataTable table = orderaction.SerchOrderInfoAll(orderid);
            if (table.Rows.Count == 0)
            {
                return;
            }
            string memid = table.Rows[0]["MemLoginID"].ToString();
            String Guid1 = memaction.GetGuidByMemLoginID(memid);
            DataTable tableTJ = memaction.SearchMemberGuid(Guid1);
            string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
            DataTable tablemember;
            if (MemNO.ToUpper().IndexOf("C") != -1)
            {

                tablemember = memaction.SearchMemberGuid(Guid1);
            }
            else
            {
                if (tableTJ.Rows[0]["Superior"].ToString() != null && tableTJ.Rows[0]["Superior"].ToString() != "")
                {
                    String TJGuid2 = memaction.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                    tablemember = memaction.SearchMemberGuid(TJGuid2);
                }
                else
                {
                    tablemember = memaction.SearchMemberGuid(Guid1);
                }
            }
            string OrderType = "1";//订单类型
            string OType = "1";
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.BTC专区)
            {
                OrderType = "1";

            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.大唐专区)
            {
                OType = "0";
                OrderType = "0";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.VIP专区)
            {
                OrderType = "1";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.区代专区1)
            {
                OType = "0";
                OrderType = "0";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.区代专区2)
            {
                OrderType = "1";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.社区店铺专区1)
            {
                OType = "0";
                OrderType = "0";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.社区店铺专区2)
            {
                OrderType = "1";
            }
            #region 计算PV



            decimal GeneralPV = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) + (Convert.ToDecimal(table.Rows[0]["Score_pv_b"]) - Convert.ToDecimal(table.Rows[0]["Offset_pv_b"]));
            #endregion
            string TotalPV = GeneralPV.ToString();
            #region 计算Money
            decimal GeneralMoney = Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]) - Convert.ToDecimal(table.Rows[0]["Offset_pv_b"]);

            #endregion
            string TotalMoney = GeneralMoney.ToString();
            string CreateMan = tablemember.Rows[0]["MemLoginNO"].ToString();
            string nanme = tablemember.Rows[0]["RealName"].ToString();
            string OrderNO = table.Rows[0]["OrderNumber"].ToString();
            string CreateTime = DateTime.Now.ToString();

            TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Number=" + CreateMan.ToUpper().Trim() + "&Name=" + nanme.Trim() + "&OrderID=" + OrderNO.Trim() + "&TotalMoney=" + TotalMoney.Trim() + "&TotalPv=" + TotalPV.Trim() + "&IsAgain=" + OType.Trim() + "&OrderType=" + OrderType.Trim() + "&OrderDate=" + CreateTime.Trim() + md5_one;

            try
            {


                string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                string fh = mms.MemberOrder(CreateMan.ToUpper().Trim(), nanme.Trim(), OrderNO.Trim(), TotalMoney.Trim(), TotalPV.Trim(), OType.Trim(), OrderType.Trim(), CreateTime.Trim(), md5Check_two);
                if (fh.ToUpper() == "SUCCESS")
                {
                    ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                    orderrefuse.OrderID = OrderNO;
                    orderrefuse.MemberloginID = memid;
                    orderrefuse.Remark = fh;
                    orderrefuse.Status = "1";
                    orderrefuse.EndTime = DateTime.Now.ToString();
                    orderrefuse.AdminID = "拒绝退款重推成功";
                    orderrefuseaction.Add(orderrefuse);

                }
                else
                {
                    ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                    orderrefuse.OrderID = OrderNO;
                    orderrefuse.MemberloginID = memid;
                    orderrefuse.Remark = fh;
                    orderrefuse.Status = "0";
                    orderrefuse.EndTime = DateTime.Now.ToString();
                    orderrefuse.AdminID = "拒绝退款重推失败";
                    orderrefuseaction.Add(orderrefuse);

                }

            }
            catch (Exception ex)
            {
                ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                orderrefuse.OrderID = OrderNO;
                orderrefuse.MemberloginID = memid;
                orderrefuse.Remark = ex.Message;
                orderrefuse.Status = "0";
                orderrefuse.EndTime = DateTime.Now.ToString();
                orderrefuse.AdminID = "拒绝退款重推错误";
                orderrefuseaction.Add(orderrefuse);
                throw ex;
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string str;
            ShopNum1_OrderOperateLog_Action action4;
            ShopNum1_OrderOperateLog log;
            var action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
            var action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            var action3 = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
            ShopNum1_Member_Action action5 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string OrderNumber = hidOrderNumber.Value;
            DataTable ordertable = action2.SerchOrderInfoAll(OrderNumber);
            if (lblExit.Text != "退货")
            {
                str = "1";
                string strPayState = "3";
                if (hidSureState.Value == "0")
                {
                    str = "2";
                    strPayState = "4";
                    action2.UpdateOrderState(hidProductGuID.Value, base.MemLoginID, "", "", strPayState, "2", "1");
                    action.UpdateRefundStatus(base.MemLoginID, txtReason.Value, hidProductGuID.Value, str);
                    action4 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    log = new ShopNum1_OrderOperateLog
                    {
                        Guid = Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hidProductGuID.Value),
                        CreateUser = base.MemLoginID,
                        OderStatus = 2,
                        ShipmentStatus = 1,
                        PaymentStatus = 1,
                        CurrentStateMsg = "卖家不同意退款",
                        NextStateMsg = "等待卖家发货",
                        Memo = "",
                        OperateDateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                    action4.Add(log);
                    //JieKou_Tui(OrderNumber);
                    JieKou3g(OrderNumber);
                    TZtype = "2";
                }
                else
                {


                    #region 20151109修改退款逻辑

                    //string CategoryID = hidcategory.Value;
                    //string OrderNumber = hidOrderNumber.Value;
                    //string MJmember = hidMemloginId.Value;
                    //string OrderType = "";
                    //string fh = "";
                    //if (CategoryID == "1")
                    //{
                    //    OrderType = "2";
                    //}
                    //else if (CategoryID == "2" || CategoryID == "9")
                    //{
                    //    OrderType = "3";
                    //}
                    //else if (CategoryID == "4" || CategoryID == "5")
                    //{
                    //    OrderType = "4";
                    //    fh = "Success";
                    //}
                    //else if (CategoryID == "6" || CategoryID == "7")
                    //{
                    //    OrderType = "4";
                    //    fh = "Success";
                    //}
                    //var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    //String Guid = memaction.GetGuidByMemLoginID(MJmember);
                    //DataTable tableTJ = memaction.SearchMemberGuid(Guid);
                    //string TjNO = tableTJ.Rows[0]["Superior"].ToString();
                    //string ZSno = tableTJ.Rows[0]["MemLoginNO"].ToString();
                    //if (OrderType == "4")
                    //{
                    //    fh = "Success";
                    //}
                    //else if ((TjNO == null || TjNO == ""))
                    //{
                    //    fh = "Success";
                    //}


                    //else
                    //{
                    //    String TjGuid = memaction.GetGuidByMemLoginNO(TjNO);
                    //    DataTable Tjtable = memaction.SearchMemberGuid(TjGuid);
                    //    string memberRank = Tjtable.Rows[0]["MemberRankGuid"].ToString();
                    //    if(ZSno.ToUpper().IndexOf("C") != -1)
                    //    {
                    //        memberRank=tableTJ.Rows[0]["MemberRankGuid"].ToString();
                    //    }

                    //    if (memberRank.ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                    //    {
                    //        fh = "Success";
                    //    }
                    //    else
                    //    {
                    //        string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
                    //        string TJMemLoginNO;
                    //        if (MemNO.ToUpper().IndexOf("C") != -1)
                    //        {
                    //            TJMemLoginNO = MemNO;
                    //        }
                    //        else
                    //        {

                    //            TJMemLoginNO = tableTJ.Rows[0]["Superior"].ToString();
                    //        }

                    //        TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
                    //        string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                    //        string privateKey_two = "Number=" + TJMemLoginNO + "&OrderID=" + OrderNumber + "&OrderType=" + OrderType + md5_one;
                    //        string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                    //        fh = mms.MemberOrderBack(TJMemLoginNO, OrderNumber, OrderType, md5Check_two);
                    //        ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                    //        ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                    //        orderrefuse.OrderID = OrderNumber;
                    //        orderrefuse.MemberloginID = MJmember;
                    //        orderrefuse.Remark = fh;
                    //        orderrefuse.Status = "0";
                    //        orderrefuse.EndTime = DateTime.Now.ToString();
                    //        orderrefuse.AdminID = "退款";
                    //        orderrefuseaction.Add(orderrefuse);
                    //    }
                    //}


                    //if (fh.ToUpper() == "Success".ToUpper())
                    //{
                    #endregion
                    //if (OrderType == "1")
                    //{
                    //    ShopNum1_Member_Action memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    //    ShopNum1_OrderInfo_Action orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    //    DataTable tablemem = memaction.SearchByMemLoginID(MJmember);
                    //    DataTable table = orderaction.SearchOrderInfo(OrderNumber);
                    //    decimal mpva = Convert.ToDecimal(tablemem.Rows[0]["Score_record _pv_a"]);


                    //    decimal pva = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) + (Convert.ToDecimal(table.Rows[0]["Score_pv_b"]) - Convert.ToDecimal(table.Rows[0]["Offset_pv_b"]));
                    //    if (mpva == pva)
                    //    {
                    //        memaction.UpdateMemberRankGuid(MJmember, MemberLevel.NORMAL_MEMBER_ID);
                    //    }
                    //    else
                    //    {
                    //        memaction.UpdateMemberRankGuid(MJmember, MemberLevel.VIP_MEMBER_ID);
                    //    }
                    //}
                    BindData();
                    action2.UpdateOrderState(hidProductGuID.Value, base.MemLoginID, "5", "", strPayState, "2", "1");
                    action4 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    log = new ShopNum1_OrderOperateLog
                    {
                        Guid = System.Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hidProductGuID.Value),
                        CreateUser = base.MemLoginID,
                        OderStatus = 2,
                        ShipmentStatus = 1,
                        PaymentStatus = 1,
                        CurrentStateMsg = "卖家同意退款",
                        NextStateMsg = "无",
                        Memo = "",
                        OperateDateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                    action4.Add(log);
                    action3.UpdateReduceStock(hidProductGuID.Value, "1");
                    action.UpdateRefundStatus(base.MemLoginID, txtReason.Value, hidProductGuID.Value, str);
                    if (ordertable.Rows.Count > 0)
                    {
                        var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable tablemember = memaction.SearchMembertwo(ordertable.Rows[0]["MemLoginID"].ToString());

                        if (ordertable.Rows[0]["shop_category_id"].ToString() == "9")
                        {
                            action5.Update_5XCV(base.MemLoginID, Convert.ToDecimal(ordertable.Rows[0]["ShouldPayPrice"]));


                            DataTable shopmem = memaction.SearchMembertwo(ordertable.Rows[0]["ShopID"].ToString());
                            GZ_XiaoShouE_mingxi gz = new GZ_XiaoShouE_mingxi();
                            gz.MemloginID = ordertable.Rows[0]["ShopID"].ToString();
                            gz.OrderNumber = ordertable.Rows[0]["OrderNumber"].ToString();
                            gz.DateTime = DateTime.Now;
                            gz.ZJH_xiaoshoue = shopmem.Rows[0]["Score_cvv"].ToString();
                            gz.ZJ_xiaoshoue = "退款-" + ordertable.Rows[0]["ShouldPayPrice"].ToString();
                            gz.Y_xiaoshoue = (Convert.ToDecimal(shopmem.Rows[0]["Score_cvv"]) + Convert.ToDecimal(ordertable.Rows[0]["ShouldPayPrice"])).ToString();
                            memaction.AddGZ_XiaoShouE(gz);


                        }
                        if (tablemember.Rows[0]["MemberRankGuid"].ToString().ToUpper() == MemberLevel.AGENT_MEMBER_ID_three.ToUpper() && ordertable.Rows[0]["shop_category_id"].ToString() == "5")
                        {
                            action5.Update_5XSV(ordertable.Rows[0]["MemLoginID"].ToString(), Convert.ToDecimal(ordertable.Rows[0]["ShouldPayPrice"]));
                            if (tablemember.Rows[0]["MemberType"].ToString() == "2")
                            {
                                if (Convert.ToDecimal(tablemember.Rows[0]["Score_svv"]) <= Convert.ToDecimal(tablemember.Rows[0]["Score_cvv"]))
                                {
                                    DataTable mShop = memaction.SelectShopOfMemloginid(ordertable.Rows[0]["MemLoginID"].ToString());
                                    if (mShop.Rows[0]["IsDeleted"].ToString() == "0")
                                    {
                                        memaction.UpdateShop_IsDelete(ordertable.Rows[0]["MemLoginID"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
                    {
                        IsMMS(hidProductGuID.Value, hidMemloginId.Value, "退款");
                    }
                    TZtype = "1";
                    //}







                }

            }
            else
            {
                str = "1";
                string strShipState = "4";
                if (hidSureState.Value == "0")
                {
                    str = "2";
                    strShipState = "5";
                    action2.UpdateOrderState(hidProductGuID.Value, base.MemLoginID, "", strShipState, "", "2", "1");
                    action4 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    log = new ShopNum1_OrderOperateLog
                    {
                        Guid = Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hidProductGuID.Value),
                        CreateUser = base.MemLoginID,
                        OderStatus = 2,
                        ShipmentStatus = 1,
                        PaymentStatus = 1,
                        CurrentStateMsg = "卖家不同意退货",
                        NextStateMsg = "等待买家确认收货",
                        Memo = "",
                        OperateDateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                    //JieKou_Tui(OrderNumber);
                    JieKou3g(OrderNumber);
                    action4.Add(log);
                }
                else
                {
                    BindData();
                    action2.UpdateOrderState(hidProductGuID.Value, base.MemLoginID, "5", strShipState, "", "2", "1");
                    action4 = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                    log = new ShopNum1_OrderOperateLog
                    {
                        Guid = Guid.NewGuid(),
                        OrderInfoGuid = new Guid(hidProductGuID.Value),
                        CreateUser = base.MemLoginID,
                        OderStatus = 2,
                        ShipmentStatus = 1,
                        PaymentStatus = 1,
                        CurrentStateMsg = "卖家同意退货",
                        NextStateMsg = "无",
                        Memo = "",
                        OperateDateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                    action4.Add(log);
                    action3.UpdateReduceStock(hidProductGuID.Value, "1");
                    if (ordertable.Rows.Count > 0)
                    {
                        var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable tablemember = memaction.SearchMembertwo(ordertable.Rows[0]["MemLoginID"].ToString());

                        if (ordertable.Rows[0]["shop_category_id"].ToString() == "9")
                        {
                            action5.Update_5XCV(base.MemLoginID, Convert.ToDecimal(ordertable.Rows[0]["ShouldPayPrice"]));

                            DataTable shopmem = memaction.SearchMembertwo(ordertable.Rows[0]["ShopID"].ToString());
                            GZ_XiaoShouE_mingxi gz = new GZ_XiaoShouE_mingxi();
                            gz.MemloginID = ordertable.Rows[0]["ShopID"].ToString();
                            gz.OrderNumber = ordertable.Rows[0]["OrderNumber"].ToString();
                            gz.DateTime = DateTime.Now;
                            gz.ZJH_xiaoshoue = shopmem.Rows[0]["Score_cvv"].ToString();
                            gz.ZJ_xiaoshoue = "退货-" + ordertable.Rows[0]["ShouldPayPrice"].ToString();
                            gz.Y_xiaoshoue = (Convert.ToDecimal(shopmem.Rows[0]["Score_cvv"]) + Convert.ToDecimal(ordertable.Rows[0]["ShouldPayPrice"])).ToString();
                            memaction.AddGZ_XiaoShouE(gz);
                        }
                        if (tablemember.Rows[0]["MemberRankGuid"].ToString().ToUpper() == MemberLevel.AGENT_MEMBER_ID_three.ToUpper() && ordertable.Rows[0]["shop_category_id"].ToString() == "5")
                        {
                            action5.Update_5XSV(ordertable.Rows[0]["MemLoginID"].ToString(), Convert.ToDecimal(ordertable.Rows[0]["ShouldPayPrice"]));
                            if (tablemember.Rows[0]["MemberType"].ToString() == "2")
                            {
                                if (Convert.ToDecimal(tablemember.Rows[0]["Score_svv"]) <= Convert.ToDecimal(tablemember.Rows[0]["Score_cvv"]))
                                {
                                    DataTable mShop = memaction.SelectShopOfMemloginid(ordertable.Rows[0]["MemLoginID"].ToString());
                                    if (mShop.Rows[0]["IsDeleted"].ToString() == "0")
                                    {
                                        memaction.UpdateShop_IsDelete(ordertable.Rows[0]["MemLoginID"].ToString());
                                    }
                                }
                            }
                        }
                        
                    }
                    if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
                    {
                        IsMMS(hidProductGuID.Value, hidMemloginId.Value, "退货");
                    }
                }
                action.UpdateRefundStatus(base.MemLoginID, txtReason.Value, hidProductGuID.Value, str);
            }
            if (TZtype == "1")
            {
                //Page.Response.Redirect("S_Order_List.aspx");
                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                            "<script>alert(\"退款成功！\");top.location='http://" +
                                                                            ShopSettings.siteDomain +
                                                                            "/Shop/ShopAdmin/s_index.aspx';</script>");
            }
            else if (TZtype == "2")
            {
                //Page.Response.Redirect("S_Order_List.aspx");
                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                            "<script>alert(\"拒绝退款成功！\");top.location='http://" +
                                                                            ShopSettings.siteDomain +
                                                                            "/Shop/ShopAdmin/s_index.aspx';</script>");
            }

            //else
            //{
            //    Page.Response.Redirect("S_Order_List.aspx");
            //}
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                            "<script>alert(\"操作失败，请联系客服人员！\");top.location='http://" +
                                                                            ShopSettings.siteDomain +
                                                                            "/Shop/ShopAdmin/s_index.aspx';</script>");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            hidShouldPayprice = (HtmlInputHidden)skin.FindControl("hidShouldPayprice");
            hidPaymentmemLoginid = (HtmlInputHidden)skin.FindControl("hidPaymentmemLoginid");
            hidAdvancePayment = (HtmlInputHidden)skin.FindControl("hidAdvancePayment");
            hidPayMentName = (HtmlInputHidden)skin.FindControl("hidPayMentName");
            hidShopPayment = (HtmlInputHidden)skin.FindControl("hidShopPayment");
            hidShopId = (HtmlInputHidden)skin.FindControl("hidShopId");
            hidMemloginId = (HtmlInputHidden)skin.FindControl("hidMemloginId");
            LogisticInfo = (HtmlGenericControl)skin.FindControl("LogisticInfo");
            hidRefundStatus = (HtmlInputHidden)skin.FindControl("hidRefundStatus");
            lblExit = (Label)skin.FindControl("lblExit");
            lblExitMoney = (Label)skin.FindControl("lblExitMoney");
            hidSureState = (HtmlInputHidden)skin.FindControl("hidSureState");
            txtIntroduce = (HtmlTextArea)skin.FindControl("txtIntroduce");
            txtReason = (HtmlTextArea)skin.FindControl("txtReason");
            btnSubmit = (Button)skin.FindControl("btnSubmit");
            btnSubmit.Click += btnSubmit_Click;
            hidIsReceive = (HtmlInputHidden)skin.FindControl("hidIsReceive");
            hidProductGuID = (HtmlInputHidden)skin.FindControl("hidProductGuID");
            hidRefundReason = (HtmlInputHidden)skin.FindControl("hidRefundReason");
            hidOrderNumber = (HtmlInputHidden)skin.FindControl("hidOrderNumber");
            hidcategory = (HtmlInputHidden)skin.FindControl("hidcategory");
            htmlImage_0 = (HtmlImage)skin.FindControl("showimg");
            if (Common.Common.ReqStr("view").IndexOf("|") != -1)
            {
                string str = Common.Common.ReqStr("view");
                DataTable table =
                    ((ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action()).SelectRefundInfo(
                        str.Split(new[] { '|' })[2], base.MemLoginID, "1");
                if (str.Split(new[] { '|' })[0] == "exitgoods")
                {
                    lblExit.Text = "退货";
                }
                hidcategory.Value = str.Split(new[] { '|' })[5];
                hidOrderNumber.Value = str.Split(new[] { '|' })[6];
                hidProductGuID.Value = str.Split(new[] { '|' })[2];
                if (table.Rows.Count > 0)
                {
                    hidShouldPayprice.Value = table.Rows[0]["shouldpayprice"].ToString();
                    hidPaymentmemLoginid.Value = table.Rows[0]["paymentmemloginid"].ToString();
                    hidAdvancePayment.Value = table.Rows[0]["advancepayment"].ToString();
                    hidShopPayment.Value = table.Rows[0]["shoppayment"].ToString();
                    hidPayMentName.Value = table.Rows[0]["paymentname"].ToString();
                    hidShopId.Value = table.Rows[0]["shopid"].ToString();
                    hidMemloginId.Value = table.Rows[0]["memloginid"].ToString();
                    txtReason.Value = table.Rows[0]["onpassreason"].ToString();
                    hidRefundReason.Value = table.Rows[0]["refundreason"].ToString();
                    lblExitMoney.Text = table.Rows[0]["RefundMoney"].ToString();

                    txtIntroduce.Value = table.Rows[0]["RefundContent"].ToString();
                    htmlImage_0.Src = table.Rows[0]["RefundImg"].ToString();
                    hidIsReceive.Value = table.Rows[0]["IsReceive"].ToString();
                    hidRefundStatus.Value = table.Rows[0]["refundstatus"].ToString();
                    string str2 = table.Rows[0]["LogisticName"].ToString();
                    string kuainum = table.Rows[0]["LogisticNumber"].ToString();
                    if (kuainum.Length > 5)
                    {
                        LogisticInfo.InnerHtml =
                            new ShopNum1_KuaiDiRequest().GetKuaidiInfo(str2.Split(new[] { '|' })[0], kuainum, "");
                    }
                }
            }
        }

        protected void IsMMS(string orderinfoGuId, string MemLoginID, string strStateTxt)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(
                    orderinfoGuId);
            string mobile = orderInfoByGuid.Rows[0]["mobile"].ToString().Trim();
            if (mobile != "")
            {
                ShopNum1_MMSGroupSend send;
                string guid = string.Empty;
                var stute = new UpdateOrderStute();
                stute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                stute.ShopName = ShopSettings.GetValue("Name");
                stute.UpdateTime = DateTime.Now.ToString();
                stute.SysSendTime = DateTime.Now.ToString();
                guid = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                var action2 = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = action2.GetEditInfo(guid, 0);
                string s = string.Empty;
                string mMsTitle = string.Empty;
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    mMsTitle = editInfo.Rows[0]["Title"].ToString();
                }
                s =
                    s.Replace("{$Name}", stute.Name)
                        .Replace("{$OrderStatus}", strStateTxt)
                        .Replace("{$OrderNumber}", stute.OrderNumber)
                        .Replace("{$ShopName} ", stute.ShopName)
                        .Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                var sms = new SMS();
                string retmsg = "";
                s = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                sms.Send(mobile, s + "【唐江宝宝】", out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    send = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), mobile, mMsTitle, 2,
                        guid.Replace("'", ""));
                    action2.AddMMSGroupSend(send);
                }
                else
                {
                    send = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), mobile, mMsTitle, 0,
                        guid.Replace("'", ""));
                    action2.AddMMSGroupSend(send);
                }
            }
        }

        protected void BindData()
        {
            decimal num5;
            string memloginid = hidMemloginId.Value;
            string shopid = hidShopId.Value;
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            decimal payprice = Convert.ToDecimal(lblExitMoney.Text);
            decimal shopAdvancePayment = Convert.ToDecimal(hidShopPayment.Value);
            decimal num3 = Convert.ToDecimal(hidShouldPayprice.Value);
            decimal advancePayments = Convert.ToDecimal(hidAdvancePayment.Value);
            if (hidPaymentmemLoginid.Value == "admin")
            {
                if ((hidPayMentName.Value.IndexOf("货到付款") != -1) || (hidPayMentName.Value.IndexOf("线下支付") != -1))
                {
                    if (advancePayments >= payprice)
                    {
                        action.RefundUpdateAdvancePayment(memloginid, shopid, payprice, shopAdvancePayment,
                            hidProductGuID.Value, hidProductGuID.Value, 3);
                        AdvancePaymentModifyLog(5, advancePayments, payprice, "退款成功增加买家金币（BV）", memloginid, 1);
                        //AdvancePaymentModifyLog(5, shopAdvancePayment, payprice, "会员退款扣除卖家金币（BV）", shopid, 0);
                    }
                    else
                    {
                        MessageBox.Show("金币（BV）不足，请充值后再同意退款！");
                    }
                }
                else
                {
                    //AdvancePaymentModify(memloginid, payprice);
                    AdvancePaymentModifyLog(5, advancePayments, payprice, "退款成功增加买家金币（BV）", memloginid, 1);
                    if (num3 >= payprice)
                    {
                        num5 = num3 - payprice;
                        //AdvancePaymentModifyLog(5, shopAdvancePayment, num5, "买家退款时订单剩余金额打给卖家", shopid, 1);
                    }
                }
            }
            else if (hidPayMentName.Value == "金币（BV）支付")
            {
                //AdvancePaymentModify(memloginid, payprice);
                AdvancePaymentModifyLog(5, advancePayments, payprice, "退款成功增加金币（BV）", memloginid, 1);
                //if (num3 >= payprice)
                //{
                //    num5 = num3 - payprice;
                //    AdvancePaymentModifyLog(5, shopAdvancePayment, num5, "买家退款时订单剩余金额打给卖家", shopid, 1);
                //}
            }
            else if (shopAdvancePayment >= payprice)
            {
                //action.RefundUpdateAdvancePayment(memloginid, base.MemLoginID, payprice, shopAdvancePayment,
                //    hidProductGuID.Value, hidProductGuID.Value, 3);
                AdvancePaymentModifyLog(5, advancePayments, payprice, "退款成功增加买家金币（BV）", memloginid, 1);
                //AdvancePaymentModifyLog(5, shopAdvancePayment, payprice, "会员退款扣除卖家金币（BV）", shopid, 0);
            }
            else
            {
                AdvancePaymentModifyLog(5, advancePayments, payprice, "退款成功增加买家金币（BV）", memloginid, 1);
                //MessageBox.Show("金币（BV）不足，请充值后再同意退款！");
            }
        }
    }
}