using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class WeiXinPayDecrease : BaseMemberControl
    {
        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();




        private string Bank;
        private string BankRealName;
        private string BankID;

        /// <summary>
        /// 查询会员的账户信息
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public DataTable WeiXinSelectMemberInfo(string OpenID)
        {
            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);

            string MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();

            DataTable memberinfo = shopNum1_Member_Action.SearchByMemLoginID(MemloginID);

            return memberinfo;


        }

        /// <summary>
        /// 查询已银行账户信息
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public string WeiXinDecreaseBank(string OpenID) 
        {
            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);

            string MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();

            DataTable Banktable =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMembertwo(MemloginID);
            string MemNO = Banktable.Rows[0]["MemLoginNO"].ToString();
            TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Number=" + MemNO.ToUpper() + md5_one;
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            string returnResult = mms.GetMemberInfo(MemNO.ToUpper(), md5Check_two);
            string str = string.Empty;
            if (returnResult == "密匙验证失败!" || returnResult == "会员编号不存在!" || returnResult == "查询失败!")
            {
                str = Banktable.Rows[0]["Bank"].ToString() + "," + Banktable.Rows[0]["BankAddress"].ToString() + "|" + Banktable.Rows[0]["RealName"].ToString() + "|" + Banktable.Rows[0]["BankNo"].ToString();

                
            }
            else
            {
                string[] sArray = returnResult.Split(new char[1] { ',' });
                str= sArray[1] + "," + sArray[4]+"|"+sArray[2]+"|"+sArray[3];

                
            }
            return str;
        }



        /// <summary>
        /// 微信提现
        /// </summary>
        /// <param name="OpenID"></param>
        /// <param name="Decrease_bv"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        public string WeiXinDecrease(string OpenID, string Decrease_bv, string Remark) 
        {
            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);

            string MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();
            DataTable memberinfo = shopNum1_Member_Action.SearchByMemLoginID(MemloginID);
            string Score_bv = memberinfo.Rows[0]["AdvancePayment"].ToString();
            #region 获取银行信息


            DataTable Banktable =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMembertwo(MemloginID);
            string MemNO = Banktable.Rows[0]["MemLoginNO"].ToString();
            TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Number=" + MemNO.ToUpper() + md5_one;
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            string returnResult = mms.GetMemberInfo(MemNO.ToUpper(), md5Check_two);
            if (returnResult == "密匙验证失败!" || returnResult == "会员编号不存在!" || returnResult == "查询失败!")
            {
                Bank = Banktable.Rows[0]["Bank"].ToString() + "," + Banktable.Rows[0]["BankAddress"].ToString();

                BankRealName = Banktable.Rows[0]["RealName"].ToString();

                BankID = Banktable.Rows[0]["BankNo"].ToString();
            }
            else
            {
                string[] sArray = returnResult.Split(new char[1] { ',' });
                Bank = sArray[1] + "," + sArray[4];

                BankRealName = sArray[2];

                BankID = sArray[3];


            }
            #endregion

            string memberrankguid =
                      ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(MemloginID);
            string datemy = Week();
            if (Bank.Trim() == "" || BankRealName.Trim() == "" || BankID.Trim() == "") 
            {
                return "您的账户信息不完整!";
            }
            if (Convert.ToDecimal(Decrease_bv) < 100M)
            {
                return "提现金额不能为零或者负数!";
            }
            else if (Convert.ToDecimal(Decrease_bv) > Convert.ToDecimal(Score_bv.Trim()))
            {
                return "提现金额不能大于金币!";
            }
            else if (Remark.Length > 300)
            {
                return "会员备注不能大于300字符!";
            }
            else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
            {
                return "顾客不能提现!";
            }
            else if (Convert.ToInt32(Convert.ToDecimal(Decrease_bv) / 100) * 100 != Convert.ToDecimal(Decrease_bv))
            {
                return "提现金额人民币（RV）必须为100的倍数!";
            }
            else if (datemy == "星期六" || datemy == "星期日")
            {
                return " 非常抱歉，非工作日不能提现哟~！";
            }
            else
            {
                ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                DataTable meminfo = memberaction.GetMemInfo(MemloginID);
                decimal meminfoBV = Convert.ToDecimal(meminfo.Rows[0]["AdvancePayment"].ToString());
                var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = "0", //提现
                    CurrentAdvancePayment = meminfoBV,
                    OperateMoney = Convert.ToDecimal(Decrease_bv.Trim()),
                    OperateStatus = 0,
                    Date = DateTime.Now
                };
                advancePaymentApplyLog.OrderNumber = "J" + new Order().CreateOrderNumber();
                advancePaymentApplyLog.Memo = Remark;
                advancePaymentApplyLog.MemLoginID = MemloginID;
                advancePaymentApplyLog.PaymentGuid = Guid.Empty;
                advancePaymentApplyLog.PaymentName = string.Empty;
                #region 20151110
                advancePaymentApplyLog.Bank = Bank.Trim();
                advancePaymentApplyLog.TrueName = BankRealName.Trim();
                advancePaymentApplyLog.Account = BankID.Trim();

                //advancePaymentApplyLog.Bank = bv_Bank.Value.Trim();
                //advancePaymentApplyLog.TrueName = bv_RealName.Value.Trim();
                //advancePaymentApplyLog.Account = bv_BankID.Value.Trim();
                #endregion







                advancePaymentApplyLog.IsDeleted = 0;
                advancePaymentApplyLog.ID = method_2() + 1;



                //action3.ApplyOperateMoney(advancePaymentApplyLog);

                ShopNum1_AdvancePaymentApplyLog_Action action3 =
        (ShopNum1_AdvancePaymentApplyLog_Action)
            LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                lock (advancePaymentApplyLog.MemLoginID)
                {
                    //if (action3.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                    if(1>0)
                    {
                        try
                        {

                            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                            {
                                Guid = Guid.NewGuid(),
                                OperateType = 2,
                                CurrentAdvancePayment = advancePaymentApplyLog.CurrentAdvancePayment,
                                OperateMoney = Convert.ToDecimal(Decrease_bv.Trim()),
                                LastOperateMoney =
                                    Convert.ToDecimal(advancePaymentApplyLog.CurrentAdvancePayment) -
                                    Convert.ToDecimal(Decrease_bv.Trim()),
                                Date = DateTime.Now,
                                Memo = "会员提现扣除金币（BV）￥" + Decrease_bv.Trim(),
                                MemLoginID = MemloginID,
                                CreateUser = MemloginID,
                                CreateTime = DateTime.Now,
                                IsDeleted = 0,


                            };

                            //((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoneyBV(advancePaymentModifyLog);
                            action3.ApplyOperateMoneyDecrease(advancePaymentApplyLog, advancePaymentModifyLog, 1);
                        }

                        catch (Exception)
                        {
                        }



                    }
                }
                return "申请提现成功!";


            }

        }





        private int method_2()
        {
            try
            {
                return Common.Common.ReturnMaxID("ID", "MemLoginID", base.MemLoginID, "ShopNum1_AdvancePaymentApplyLog");
            }
            catch
            {
                return 0;
            }
        }

        public string Week()
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];

            return week;
        }
    }
}