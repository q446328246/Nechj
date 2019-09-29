using System;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Data;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// OrderList 的摘要说明
    /// </summary>
    public class OrderList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (ShopNum1.Common.Common.ReqStr("type") != "")
            {
                var OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                if (ShopNum1.Common.Common.ReqStr("user") == GetMemLoginId())
                {
                    string strGuId = ShopNum1.Common.Common.ReqStr("guid");
                    if (strGuId.IndexOf(",") != -1)
                    {
                        var sb = new StringBuilder();
                        string[] arryguid = strGuId.Split(',');
                        for (int i = 0; i < arryguid.Length; i++)
                        {
                            sb.Append("'" + arryguid[i] + "',");
                        }
                        sb.Remove(sb.Length - 1, 1);
                        strGuId = sb.ToString();
                    }
                    else
                    {
                        strGuId = "'" + strGuId + "'";
                    }
                    OrderInfo_Action.UpdateDelete(strGuId);
                    context.Response.Write("ok");
                }
                else if (ShopNum1.Common.Common.ReqStr("price") != "" && ShopNum1.Common.Common.ReqStr("ordernumber") != "" && ShopNum1.Common.Common.ReqStr("orid") != "")
                {
                    decimal pvb = 0;
                    DataTable Order = OrderInfo_Action.SelectOrderOfAll(ShopNum1.Common.Common.ReqStr("ordernumber"));
                    string price = ShopNum1.Common.Common.ReqStr("price");


                    //if (Convert.ToDecimal(ShopNum1.Common.Common.ReqStr("price")) < Convert.ToDecimal(Order.Rows[0]["Score_pv_a"]))
                    //{
                    //    return;
                    //}


                    //decimal fall = Convert.ToDecimal(Order.Rows[0]["ShouldPayPrice"].ToString()) - Convert.ToDecimal(price);
                    //if (fall > 0)
                    //{
                    //    if ((fall > Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString())) || (fall == Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString())))
                    //    {
                    //        pvb = 0;
                    //    }
                    //    else if (fall < Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString()))
                    //    {
                    //        pvb = Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString()) - fall;
                    //    }
                    //}
                    //else
                    //{
                    //    if (Convert.ToDecimal(price) > (Convert.ToDecimal(Order.Rows[0]["ProductLastPrice"].ToString()) - Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString())))
                    //    {
                    //        pvb = Convert.ToDecimal(price) - (Convert.ToDecimal(Order.Rows[0]["ProductLastPrice"].ToString()) - Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString()));
                    //        if (pvb > Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString()))
                    //        {
                    //            pvb = Convert.ToDecimal(Order.Rows[0]["Score_pv_a"].ToString());
                    //        }

                    //    }

                    //}
                    OrderInfo_Action.UpdateOrderPrice(ShopNum1.Common.Common.ReqStr("ordernumber"), GetMemLoginId(), ShopNum1.Common.Common.ReqStr("price"));
                    //if (Order.Rows[0]["shop_category_id"].ToString() == "9")
                    //{
                    OrderInfo_Action.UpdateOrderPvbHv(ShopNum1.Common.Common.ReqStr("ordernumber"), GetMemLoginId(), "0", "0");
                    //}
                    OrderOperateLog("", "订单提交卖家调整费用", "等待买家付款", ShopNum1.Common.Common.ReqStr("orid"));
                    context.Response.Write("ok");
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   订单操作日志
        /// </summary>
        /// <param name="memo"></param>
        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string strOid)
        {
            var shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
            shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
            shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(strOid);
            shopNum1_OrderOperateLog.OderStatus = 1;
            shopNum1_OrderOperateLog.ShipmentStatus = 0;
            shopNum1_OrderOperateLog.PaymentStatus = 0;
            shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
            shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
            shopNum1_OrderOperateLog.Memo = memo;
            shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderOperateLog.IsDeleted = 0;
            shopNum1_OrderOperateLog.CreateUser = GetMemLoginId();
            var shopNum1_OrderOperateLog_Action =
                (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
            shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
        }

        //获取登录用户方法
        private string GetMemLoginId()
        {
            string name = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
        }
    }
}