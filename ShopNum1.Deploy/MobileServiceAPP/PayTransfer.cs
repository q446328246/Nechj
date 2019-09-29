using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Deploy.Api;

namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class PayTransfer : BaseMemberControl
    {
        #region 参数字典
        //MemLoginID 登陆用户
        //MessageCode 短信码
        //TransferID 转账编号
        //TransferID2 转账编号确认
        //PayPwd 支付密码
        //Transfer 转账金额
        //TransferName 转账人姓名
        //Remark 会员备注
        #endregion


        #region 返回值字典
        //1    验证码错误
        //2    请设置支付密码
        //3    支付密码错误
        //4    转账id不匹配
        //5    您不能转账给自己！
        //6    您不能转负数！
        //7    金币（BV）不足！
        //8    转账失败！
        //9    转账失败！
        //10   转账金额有误！
        //11   收款人用户名与收款人姓名不匹配或此收款人用户未填写用户名！
        //12   收款人用户有误或不存在！
        //0    转账成功！

        #endregion


        private string Lab_MemLoginID;
        private string Lab_AdPayment;
        public string OrderNumber;
        /// <summary>
        /// 会员金币（BV）转帐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string PayTransfer_BV(string MemLoginID, string MessageCode, string TransferID, string TransferID2, string PayPwd, string Transfer, string TransferName, string Remark)
        {
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

            DataTable tablegz = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(MemLoginID.ToUpper());
            try
            {
                if (tablegz.Rows.Count > 0)
                {
                    Lab_MemLoginID = tablegz.Rows[0]["MemLoginNo"].ToString();
                    Lab_AdPayment = (tablegz.Rows[0]["AdvancePayment"].ToString() == "") ? "0.00" : tablegz.Rows[0]["AdvancePayment"].ToString();
                    
                }
            }
            catch
            {

            }


            string modile = memberAction.GetAdvancePayment(MemLoginID.ToUpper()).Rows[0]["Mobile"].ToString();
            string IsProtecion = memberAction.SelectIsProtecionByMemerberloginID(MemLoginID.ToUpper()).Rows[0]["IsProtecion"].ToString();
            if (IsProtecion == "1")
            {
                CheckInfo c = new CheckInfo();
                string cw = c.MemberMobileExec(MessageCode, modile);
                if (cw != "1")
                {
                    return "1";
                }
                else
                {


                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    if (action.CheckmemLoginID(TransferID.Trim()) > 0)
                    {
                        string strMemID = action.GetMemLoginIDONNO(TransferID.Trim());
                        string strRankID = action.GetMemberRankGuid(strMemID);
                        string payPwd = action.GetPayPwd(MemLoginID.ToUpper());
                        if ((payPwd == "") || (payPwd == null))
                        {
                            return "2";
                        }
                        else
                        {

                            string strpwd = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                            if (payPwd != strpwd)
                            {
                                return "3";
                            }
                            else
                            {
                                var table = new DataTable();

                                if (TransferID.ToUpper().Trim() != TransferID2.ToUpper().Trim())
                                {
                                    return "4";
                                }
                                else if (strMemID.ToUpper().Trim() == MemLoginID.ToUpper())
                                {
                                    return "5";
                                }
                                else if (Convert.ToDecimal(Transfer.Trim()) < 0)
                                {
                                    return "6";
                                }
                                //else if (strRankID.ToUpper() == MemberLevel.NORMAL_Regular_Members.ToUpper()) 
                                //{
                                //    MessageBox.Show("您不能转账给顾客！");
                                //}

                                else if (action.CheckmemLoginIDtwo(TransferID.Trim(), TransferName.Trim()) > 0)
                                {
                                    if (Convert.ToDecimal(Transfer.Trim()) > 0)
                                    {
                                        #region
                                        string str2 = action.GetPayPwd(MemLoginID.ToUpper());
                                        if (Common.Encryption.GetMd5SecondHash(PayPwd.Trim()) == str2)
                                        {
                                            table = action.SearchByMemLoginID(TransferID.Trim());
                                            switch (
                                                action.Transfer(MemLoginID.ToUpper(), strMemID, Transfer.Trim()))
                                            {
                                                case -1:
                                                    return "7";
                                                    break;

                                                case 0:
                                                    return "8";
                                                    break;

                                                case 1:
                                                    try //转帐日志
                                                    {
                                                        var transfer = new ShopNum1_PreTransfer
                                                        {
                                                            Guid = Guid.NewGuid(),
                                                            IsDeleted = 0,
                                                            MemLoginID = MemLoginID.ToUpper(),
                                                            //RMemberID = txt_TransferID.Value
                                                            RMemberID = strMemID
                                                        };

                                                        if (string.IsNullOrEmpty(Remark))
                                                        {
                                                            //txt_Remark.Value = "转账给" + txt_TransferID.Value;
                                                            Remark = "转账给" + strMemID;
                                                        }

                                                        transfer.Memo = Remark;
                                                        transfer.OperateMoney = Transfer;
                                                        transfer.OperateStatus = 0;
                                                        transfer.type = 8;
                                                        transfer.OperateStatus = 1;
                                                        transfer.Date = DateTime.Now.ToLocalTime();
                                                        var order = new Order();
                                                        OrderNumber = transfer.OrderNumber = "Z" + order.CreateOrderNumber();
                                                        GeneratePreTransfer(transfer);

                                                    }
                                                    catch
                                                    {

                                                    }
                                                    MoneyModifyLog(MemLoginID.ToUpper(), Transfer.Trim(), Lab_AdPayment.Trim(), "0", "您转账给会员" + strMemID + "￥" + Transfer.Trim(), Remark);
                                                    MoneyModifyLog(strMemID.Trim(), Transfer.Trim(), table.Rows[0]["AdvancePayment"].ToString(), "1", "会员" + MemLoginID.ToUpper() + "转账￥" + Transfer.Trim() + "给您", Remark);

                                                    
                                                    return "0";
                                                    
                                            }
                                        }
                                        //else
                                        //{
                                            return "9";
                                        //}
                                        #endregion
                                    }

                                    //else
                                    //{
                                        return "10";
                                    //}
                                }
                                //else
                                //{
                                    return "11";
                                //}
                            }
                        }
                    }
                    //else
                    //{
                        return "12";
                    //}

                }
            }
            else
            {



                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                if (action.CheckmemLoginID(TransferID.Trim()) > 0)
                {
                    string strMemID = action.GetMemLoginIDONNO(TransferID.Trim()).ToUpper();
                    string strRankID = action.GetMemberRankGuid(strMemID);
                    string payPwd = action.GetPayPwd(MemLoginID.ToUpper());
                    if ((payPwd == "") || (payPwd == null))
                    {
                        return "2";
                    }
                    else
                    {

                        string strpwd = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                        if (payPwd != strpwd)
                        {
                            return "3";
                        }
                        else
                        {
                            var table = new DataTable();

                            if (TransferID2.ToUpper().Trim() != TransferID.ToUpper().Trim())
                            {
                                return "4";
                            }
                            else if (strMemID.ToUpper().Trim() == MemLoginID.ToUpper())
                            {
                                return "5";
                            }
                            else if (Convert.ToDecimal(Transfer.Trim()) < 0)
                            {
                                return "6";
                            }
                            //else if (strRankID.ToUpper() == MemberLevel.NORMAL_Regular_Members.ToUpper()) 
                            //{
                            //    MessageBox.Show("您不能转账给顾客！");
                            //}

                            else if (action.CheckmemLoginIDtwo(TransferID.Trim(), TransferName.Trim()) > 0)
                            {
                                if (Convert.ToDecimal(Transfer.Trim()) > 0)
                                {
                                    #region
                                    string str2 = action.GetPayPwd(MemLoginID);
                                    if (Common.Encryption.GetMd5SecondHash(PayPwd.Trim()) == str2)
                                    {
                                        table = action.SearchByMemLoginID(TransferID);
                                        switch (
                                            action.Transfer(MemLoginID, strMemID, Transfer.Trim()))
                                        {
                                            case -1:
                                                return "7";
                                                break;

                                            case 0:
                                                return "8";
                                                break;

                                            case 1:
                                                try //转帐日志
                                                {
                                                    var transfer = new ShopNum1_PreTransfer
                                                    {
                                                        Guid = Guid.NewGuid(),
                                                        IsDeleted = 0,
                                                        MemLoginID = MemLoginID.ToUpper(),
                                                        //RMemberID = txt_TransferID.Value
                                                        RMemberID = strMemID
                                                    };

                                                    if (string.IsNullOrEmpty(Remark))
                                                    {
                                                        //txt_Remark.Value = "转账给" + txt_TransferID.Value;
                                                        Remark = "转账给" + strMemID;
                                                    }

                                                    transfer.Memo = Remark;
                                                    transfer.OperateMoney = Transfer;
                                                    transfer.OperateStatus = 0;
                                                    transfer.type = 8;
                                                    transfer.OperateStatus = 1;
                                                    transfer.Date = DateTime.Now.ToLocalTime();
                                                    var order = new Order();
                                                    OrderNumber = transfer.OrderNumber = "Z" + order.CreateOrderNumber();
                                                    GeneratePreTransfer(transfer);

                                                }
                                                catch
                                                {

                                                }
                                                MoneyModifyLog(MemLoginID, Transfer.Trim(), Lab_AdPayment.Trim(), "0", "您转账给会员" + strMemID + "￥" + Transfer.Trim(), Remark);
                                                MoneyModifyLog(strMemID.Trim(), Transfer.Trim(), table.Rows[0]["AdvancePayment"].ToString(), "1", "会员" + MemLoginID + "转账￥" + Transfer.Trim() + "给您", Remark);


                                                return "0";
                                                
                                        }
                                    }
                                    //else
                                    //{
                                        return "9";
                                    //}
                                    #endregion
                                }

                                //else
                                //{
                                    return "10";
                                //}
                            }
                            //else
                            //{
                                return "11";
                            //}
                        }
                    }
                }
                //else
                //{
                    return "12";
                //}

            }

        }


        protected void MoneyModifyLog(string memloginID, string money, string CurrentAdvancePayment, string type, string string_8, string Remark)
        {
            DataTable table = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(memloginID);
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                Guid = Guid.NewGuid(),
                OperateType = 6,
                CurrentAdvancePayment = Convert.ToDecimal(CurrentAdvancePayment),
                OperateMoney = Convert.ToDecimal(money)
            };

            if (type == "0")
            {
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(CurrentAdvancePayment) -
                                                           Convert.ToDecimal(money);
            }
            else
            {
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(CurrentAdvancePayment) +
                                                           Convert.ToDecimal(money);
            }
            advancePaymentModifyLog.Score_hv = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
            advancePaymentModifyLog.Score_pv_a = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]);
            advancePaymentModifyLog.Score_pv_b = Convert.ToDecimal(table.Rows[0]["Score_pv_b"]);
            advancePaymentModifyLog.Score_dv = Convert.ToDecimal(table.Rows[0]["Score_dv"]);
            advancePaymentModifyLog.Score_pv_c = Convert.ToDecimal(table.Rows[0]["Score_pv_cv"]);
            advancePaymentModifyLog.Date = DateTime.Now;
            advancePaymentModifyLog.Memo = string_8;
            advancePaymentModifyLog.MemLoginID = memloginID;
            advancePaymentModifyLog.CreateUser = base.MemLoginID;
            advancePaymentModifyLog.CreateTime = DateTime.Now;
            advancePaymentModifyLog.IsDeleted = 0;
            advancePaymentModifyLog.OrderNumber = OrderNumber;
            advancePaymentModifyLog.UserMemo = Remark;
            ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoney(advancePaymentModifyLog);
        }

        private void GeneratePreTransfer(ShopNum1_PreTransfer shopNum1_PreTransfer_0)
        {
            new ShopNum1_PreTransfer_Action().InsertPay(shopNum1_PreTransfer_0);
        }
    }
}