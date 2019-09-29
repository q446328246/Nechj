using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace ShopNum1.Deploy.GzWeiXinPay
{
    /// <summary>
    /// 扫码支付模式2回调处理类
    /// 接收微信支付后台发送的扫码结果，调用统一下单接口并将下单结果返回给微信支付后台
    /// </summary>
    public class NativeNotify : Notify
    {
        public NativeNotify(Page page)
            : base(page)
        {

        }

        public override void ProcessNotify()
        {
            WxPayData notifyData = GetNotifyData();
            
            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t回调报错1", Encoding.UTF8);
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
              
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();
            string ordernumber = notifyData.GetValue("out_trade_no").ToString();
            
            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
            //查询订单成功
            else
            {
                File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t回调成功" + ordernumber, Encoding.UTF8);
                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                
                DataTable table = shopNum1_AdvancePaymentApplyLog_Action.SearchStatus(ordernumber);
                
                if (table.Rows[0]["OperateStatus"].ToString() == "1")
                {
                   
                    File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t微信扫码订单状态已经处理" + ordernumber, Encoding.UTF8);
                }
                else
                {
                    
                    string nameById = ShopNum1.Common.Common.GetNameById("OrderNumber", "ShopNum1_AdvancePaymentApplyLog", " And OrderNumber='" + ordernumber + "' And operatestatus=0");
                    
                    if (nameById != "" && nameById != "0")
                    {
                        
                        string nameById2 = ShopNum1.Common.Common.GetNameById("memloginid", "ShopNum1_AdvancePaymentApplyLog", " And ordernumber='" + ordernumber + "' And operatestatus=0");
                        File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t微信扫码获得用户:" + nameById + "订单号:" + ordernumber, Encoding.UTF8);
                        try
                        {

                            string nameById3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + nameById2 + "'");
                            File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t微信扫码获得用户:" + nameById + "获得已有金币:" + nameById3 + "订单号:" + ordernumber, Encoding.UTF8);
                            lock (nameById2)
                            {
                                this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(table.Rows[0]["OperateMoney"].ToString()), "微信扫码及时到账会员充值", nameById2, Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1, ordernumber);
                                File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t微信扫码添加金币记录" + ordernumber, Encoding.UTF8);
                                shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, ordernumber);
                                File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t微信扫码处理充值订单状态" + ordernumber, Encoding.UTF8);

                                WxPayData res = new WxPayData();
                                res.SetValue("return_code", "SUCCESS");
                                res.SetValue("return_msg", "OK");

                                page.Response.Write(res.ToXml());
                                page.Response.End();
                            }
                        }
                        catch (Exception ex)
                        {

                            File.AppendAllText(page.Server.MapPath("~/log/weixin.txt"), "\r\n\t错误信息：" + ex.Message + ex.StackTrace, Encoding.UTF8);
                        }
                    }
                }
                

                
            }
        }

        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region 原充值逻辑
        public void AdvancePaymentModifyLogY(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type, string OrderinfoId)
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
    }
}