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
    public class MobileOrderReceipt : System.Web.UI.Page
    {

        #region 参数
        //OrderNumber-订单编号
        
        #endregion
        private string Oid;
        /// <summary>
        /// 手机订单确认收货
        /// </summary>
        public string MobileReceipt(string OrderNumber)
        {
            #region 确认收货
            Oid = OrderNumber;
            decimal num11 = 0M;
            decimal num4 = 0M;

            decimal num6 = 0M;
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            var action2 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            var action3 = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
            var action4 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            var action6 = (ShopNum1_FreezeRelease_Action)LogicFactory.CreateShopNum1_FreezeRelease_Action();
            string ordernumber = OrderNumber;

            DataTable table = action.SelectOrderOfAll(ordernumber);
            string OrderGuid = table.Rows[0]["Guid"].ToString();
            string MemLoginID = table.Rows[0]["MemLoginID"].ToString();
            decimal pv_b = Convert.ToDecimal(table.Rows[0]["Score_pv_b"].ToString());

            string memberloginid = table.Rows[0]["ShopID"].ToString();
            decimal num3 = Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"].ToString()) - pv_b;
            decimal payprice = Convert.ToDecimal(num3);



            string str7 = Common.Common.GetNameById("AdvancePayment", "shopnum1_member",
                " and memloginid='" + memberloginid + "'");
            if (str7 != "")
            {
                decimal Score_rvs = Convert.ToDecimal(str7);

                if (Convert.ToDateTime(table.Rows[0]["PayTime"]) < Convert.ToDateTime("2018-1-1"))
                {
                    AdvancePaymentModifyLog(4, Score_rvs, decimal.Multiply(payprice, (decimal)0.255), "会员确认收货2017年订单" + ordernumber + "，增加店铺人民币（RV）", memberloginid,
                    DateTime.Now, 1);
                }
                else
                {
                    AdvancePaymentModifyLog(4, Score_rvs, payprice, "会员确认收货" + ordernumber + "，增加店铺人民币（RV）", memberloginid,
                        DateTime.Now, 1);
                }

                //AdvancePaymentModifyLog(4, Score_rvs, decimal.Multiply(payprice, (decimal)0.255), "会员确认收货" + ordernumber + "，增加店铺人民币（RV）", memberloginid,
                //    DateTime.Now, 1);
                ShopNum1_FreezeRelease freeze = new ShopNum1_FreezeRelease();
                freeze.FreezeMemLoginID = memberloginid;
                freeze.FreezeScore_rv = payprice;
                freeze.FreezeTime = DateTime.Now;
                //action6.Add(freeze);

                action.SetOderStatus1(OrderGuid, 3, 1, 2, DateTime.Now);





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
                        CurrentStateMsg = "交易完成",
                        NextStateMsg = "等待买家评价",
                        Memo = "",
                        OperateDateTime = DateTime.Now,
                        IsDeleted = 0,
                        CreateUser = MemLoginID
                    };
                    ((ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                        orderOperateLog);
                }
                #endregion
                return "1";//操作成功
            }
            #endregion
            return "2";//操作失败
        }


        public void AdvancePaymentModifyLog(int OperateType, decimal Score_rvs, decimal payMoney, string Memo,
            string shopMemloginID, DateTime time, int type)
        {
            var shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action2.GetOrderGuIdByordernumber(Oid);
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
    }
}