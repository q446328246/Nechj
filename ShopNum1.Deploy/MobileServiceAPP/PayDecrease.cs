using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Deploy.Api;

namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class PayDecrease : BaseMemberControl
    {

        #region 参数字典
        //MemLoginID 登陆用户
        //MessageCode 短信码
        //Decrease_bv 提现金额
        //PayPwd 支付密码
        //Remark 会员备注
        #endregion


        #region 返回值字典
        //1    系统错误
        //2    用户信息获取失败，请联系管理员！
        //3    验证码错误
        //4    请设置支付密码
        //5    支付密码错误
        //6    交易金额不能小于100
        //7    提现金额不能大于金币
        //8    会员备注不能大于300字符
        //9    顾客不能提现
        //10   提现金额人民币（RV）必须为整数
        //11   非常抱歉，非工作日不能提现哟~

        //0    申请提现成功

        #endregion

        private string Bank;
        private string BankRealName;
        private string BankID;

        private string bvMemLoginID;
        private string Score_bv;
        private string Lab_MemLoginID;
        private string Lab_AdPayment;
        private string hid_RealName;
        private string Hid_Score_pv_a;
        private string Hid_Score_hv;
        private string Hid_Score_pv_b;
        private string Hid_Score_dv;

        /// <summary>
        /// 金币（BV）提现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string PayDecrease_BV(string MemLoginID, string PayPwd, string Decrease_bv, string Remark)
        {
            #region 获取用户账户信息
            DataTable membertable =
               ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(MemLoginID);
            try
            {
                if (membertable.Rows.Count > 0)
                {
                    bvMemLoginID = membertable.Rows[0]["MemLoginID"].ToString();
                    Score_bv = membertable.Rows[0]["AdvancePayment"].ToString();
                    Lab_MemLoginID = membertable.Rows[0]["MemLoginID"].ToString();
                    Lab_AdPayment = membertable.Rows[0]["Score_rv"].ToString();
                    hid_RealName = membertable.Rows[0]["RealName"].ToString();
                    Hid_Score_pv_a = membertable.Rows[0]["Score_pv_a"].ToString();
                    Hid_Score_hv = membertable.Rows[0]["Score_hv"].ToString();
                    Hid_Score_pv_b = membertable.Rows[0]["Score_pv_b"].ToString();
                    Hid_Score_dv = membertable.Rows[0]["Score_dv"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch
            {
            }
            #endregion
            #region 获取银行信息


            DataTable Banktable =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMembertwo(MemLoginID);
            string MemNO = Banktable.Rows[0]["MemLoginNO"].ToString();
            //TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //string privateKey_two = "Number=" + MemNO.ToUpper() + md5_one;
            //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string returnResult = mms.GetMemberInfo(MemNO.ToUpper(), md5Check_two);
            string returnResult = "密匙验证失败!";
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
            if (Bank.Trim() != "" && BankRealName.Trim() != "" && BankID.Trim() != "")
            {
                #region
                var action22 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                string modile = action22.GetAdvancePayment(MemLoginID).Rows[0]["Mobile"].ToString();
                string IsProtecion = "2";
                if (IsProtecion == "1")
                {
                    string MessageCode = "10010";
                    CheckInfo c = new CheckInfo();
                    string cw = c.MemberMobileExec(MessageCode, modile);
                    if (cw != "1")
                    {
                        return "3";
                    }
                    else
                    {
                        string payPwd =
                            ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(MemLoginID);
                        string memberrankguid =
                          ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(MemLoginID);
                        if ((payPwd == "") || (payPwd == null))
                        {
                            return "4";
                        }
                        else
                        {
                            string datemy = Week();
                            string strpwd = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                            if (payPwd != strpwd)
                            {
                                return "5";
                            }
                            else
                            {
                                if (Convert.ToDecimal(Decrease_bv) < 100M)
                                {
                                    return "6";
                                }
                                else if (Convert.ToDecimal(Decrease_bv) > Convert.ToDecimal(Score_bv.Trim()))
                                {
                                    return "7";
                                }
                                else if (Remark.Length > 300)
                                {
                                    return "8";
                                }
                                else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                                {
                                    return "9";
                                }
                                else if (Convert.ToInt32(Convert.ToDecimal(Decrease_bv) / 100) * 100 != Convert.ToDecimal(Decrease_bv))
                                {
                                    return "10";
                                }
                                else if (datemy == "星期六" || datemy == "星期日")
                                {
                                    return "11";
                                }
                                else
                                {
                                    ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                    DataTable meminfo = memberaction.GetMemInfo(MemLoginID);
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
                                    advancePaymentApplyLog.MemLoginID = MemLoginID;
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
                                        if (1 > 0)
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
                                                    MemLoginID = MemLoginID,
                                                    CreateUser = MemLoginID,
                                                    CreateTime = DateTime.Now,
                                                    IsDeleted = 0,


                                                };
                                                action3.ApplyOperateMoneyDecrease(advancePaymentApplyLog, advancePaymentModifyLog, 1);
                                                //((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoneyBV(advancePaymentModifyLog);
                                            }

                                            catch (Exception)
                                            {
                                            }



                                        }
                                    }
                                    return "0";


                                }
                            }
                        }
                    }
                }
                #region 不需要手机验证提现
                else
                {

                    string payPwd =
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(MemLoginID);
                    string memberrankguid =
                      ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(MemLoginID);
                    if ((payPwd == "") || (payPwd == null))
                    {
                        return "4";
                    }
                    else
                    {
                        string datemy = Week();
                        string strpwd = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                        if (payPwd != strpwd)
                        {
                            return "5";
                        }
                        else
                        {
                            //if (Convert.ToDecimal(Decrease_bv) < 100M)
                            //{
                            //    return "6";
                            //}
                             if (Convert.ToDecimal(Decrease_bv) > Convert.ToDecimal(Score_bv.Trim()))
                            {
                                return "7";
                            }
                            else if (Remark.Length > 300)
                            {
                                return "8";
                            }
                            else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                            {
                                return "9";
                            }
                            //else if (Convert.ToInt32(Convert.ToDecimal(Decrease_bv) / 100) * 100 != Convert.ToDecimal(Decrease_bv))
                            //{
                            //    return "10";
                            //}
                            else if (datemy == "星期六" || datemy == "星期日")
                            {
                                return "11";
                            }
                            else
                            {
                                ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                DataTable meminfo = memberaction.GetMemInfo(MemLoginID);
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
                                advancePaymentApplyLog.MemLoginID = MemLoginID;
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
                                    if (1 > 0)
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
                                                MemLoginID = MemLoginID,
                                                CreateUser = MemLoginID,
                                                CreateTime = DateTime.Now,
                                                IsDeleted = 0,


                                            };
                                            action3.ApplyOperateMoneyDecrease(advancePaymentApplyLog, advancePaymentModifyLog, 1);

                                            //((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoneyBV(advancePaymentModifyLog);
                                        }

                                        catch (Exception)
                                        {
                                        }



                                    }
                                }
                                return "0";





                            }
                        }
                    }
                }
                #endregion
                #endregion
            }
            return "12";

        }












        /// <summary>
        /// 银行信息获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Mobile_ShopNum1_Bank PayDecrease_Bank(string MemLoginID)
        {
            Mobile_ShopNum1_Bank bank = new Mobile_ShopNum1_Bank();
            DataTable table =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMembertwo(MemLoginID);
         //   string MemNO = table.Rows[0]["MemLoginNO"].ToString();
            //TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //string privateKey_two = "Number=" + MemNO.ToUpper() + md5_one;
            //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string returnResult = mms.GetMemberInfo(MemNO.ToUpper(), md5Check_two);
            //if (returnResult == "密匙验证失败!" || returnResult == "会员编号不存在!" || returnResult == "查询失败!")
            //{
            if (table.Rows[0]["Bank"].ToString() != null && table.Rows[0]["Bank"].ToString() != "" && table.Rows[0]["BankAddress"].ToString() != null && table.Rows[0]["BankAddress"].ToString() != "" && table.Rows[0]["BankName"].ToString() != null && table.Rows[0]["BankName"].ToString() != "" && table.Rows[0]["BankNo"].ToString() != null && table.Rows[0]["BankNo"].ToString() != "")
            {
                bank.Bank = table.Rows[0]["Bank"].ToString();
                bank.BankAdress = table.Rows[0]["BankAddress"].ToString();
                bank.BankName = table.Rows[0]["BankName"].ToString();
                bank.BankNo = table.Rows[0]["BankNo"].ToString();
                return bank;
            }
            else 
            {
                return null;
            }
            //}
            //else
            //{
            //    string[] sArray = returnResult.Split(new char[1] { ',' });

            //    string m = "收款银行: " + sArray[1] + "," + sArray[4] + "|" + "收款人姓名: " + sArray[2] + "|" + "收款人银行账号: " + sArray[3];
            //    return m;

            //}
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