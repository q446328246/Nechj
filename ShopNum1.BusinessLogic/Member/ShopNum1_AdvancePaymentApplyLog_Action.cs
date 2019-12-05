using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AdvancePaymentApplyLog_Action : IShopNum1_AdvancePaymentApplyLog_Action
    {




       




        public int ApplyOperateMoneyDecrease(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog, ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog, int IsDecrease)
        {
            var paraName = new string[13];
            var paraValue = new string[13];
            paraName[0] = "@IsDecrease";
            paraValue[0] = Convert.ToString(IsDecrease);
            paraName[1] = "@Guid";
            paraValue[1] = Convert.ToString(advancePaymentApplyLog.Guid);
            paraName[2] = "@MemLogin";
            paraValue[2] = advancePaymentApplyLog.MemLoginID;
            paraName[3] = "@OperateMoney";
            paraValue[3] = Convert.ToString(advancePaymentApplyLog.OperateMoney);
            paraName[4] = "@OrderNumber";
            paraValue[4] = advancePaymentApplyLog.OrderNumber;
            paraName[5] = "@applyMemo";
            paraValue[5] = advancePaymentApplyLog.Memo;
            paraName[6] = "@PaymentGuid";
            paraValue[6] = Convert.ToString(advancePaymentApplyLog.PaymentGuid);
            paraName[7] = "@Bank";
            paraValue[7] = advancePaymentApplyLog.Bank;
            paraName[8] = "@TrueName";
            paraValue[8] = advancePaymentApplyLog.TrueName;
            paraName[9] = "@Account";
            paraValue[9] = advancePaymentApplyLog.Account;
            paraName[10] = "@applyID";
            paraValue[10] = Convert.ToString(advancePaymentApplyLog.ID);
            paraName[11] = "@ModifyGuid";
            paraValue[11] = Convert.ToString(advancePaymentModifyLog.Guid);
            paraName[12] = "@ModifyMemo";
            paraValue[12] = advancePaymentModifyLog.Memo;

            return DatabaseExcetue.RunProcedure("ApplyOperateMoneyDecrease", paraName, paraValue);





        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="mobile"></param>
        /// <param name="isadmin"></param>
        /// <returns></returns>
        public DataTable SelectTeamList(string MemLoginID, string mobile,string isadmin)
        {
            string str = string.Empty;
            str =
                "  SELECT id,  MemLoginID,Mobile,name,[RecoMemberTime] FROM [ShopNum1_Member] WHERE MemLoginID IN(SELECT distinct RecoMember FROM [ShopNum1_Member] WHERE RecoMember!='')   ";
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                str = str + " AND  MemLoginID ='" + MemLoginID + "' ";
            }

            if (Operator.FormatToEmpty(mobile) != string.Empty)
            {
                str = str + " AND  mobile ='" + mobile + "' ";
            }

            if (isadmin!="1") {
                str = str + " AND  MemLoginID not in (SELECT BLID from WHJ_BlackList) ";
            }

            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY  ID desc");
        }

        public DataTable SelectRcodMemBerLogo(string MemLoginID, string date1, string date2,string isadmin)
        {
            string str = string.Empty;
            str =
                "  select * from [ShopNum1_RcodMemBerLogo]  where 0=0";
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                str = str + " AND  MemberLoginID ='" + MemLoginID + "'";
            }

            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND CreateTime>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND CreateTime<='" + Operator.FilterString(date2) + "' ";
            }
            if (isadmin!="1") {
                str = str + "  and MemberLoginID not in (SELECT BLID from WHJ_BlackList) ";
            }

            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY  CreateTime desc");
        }
        /// <summary>
        ///  金币（BV）操作日志（充值、提现）
        /// </summary>
        /// <param name="advancePaymentApplyLog"></param>
        /// <returns></returns>
        public int ApplyOperateMoney(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentApplyLog( Guid, OperateType\t,CurrentAdvancePayment\t,OperateMoney,OperateStatus,Date,Memo,MemLoginID,PaymentGuid,PaymentName,Bank,TrueName,Account,IsDeleted,  OrderNumber,ID,BankCard,GetBamkCard,UserName  ) VALUES (  '"
                , advancePaymentApplyLog.Guid, "',  ", advancePaymentApplyLog.OperateType, ",  ",
                advancePaymentApplyLog.CurrentAdvancePayment, ",  ", advancePaymentApplyLog.OperateMoney, ",  ",
                advancePaymentApplyLog.OperateStatus, ",  '", advancePaymentApplyLog.Date, "',  '",
                Operator.FilterString(advancePaymentApplyLog.Memo), "',  '", advancePaymentApplyLog.MemLoginID,
                "',  '", advancePaymentApplyLog.PaymentGuid, "',  '",
                Operator.FilterString(advancePaymentApplyLog.PaymentName), "',  '",
                Operator.FilterString(advancePaymentApplyLog.Bank), "',  '",
                Operator.FilterString(advancePaymentApplyLog.TrueName), "',  '", advancePaymentApplyLog.Account,
                "',  '", advancePaymentApplyLog.IsDeleted, "', '",
                Operator.FilterString(advancePaymentApplyLog.OrderNumber), "',  ", advancePaymentApplyLog.ID,
                ",  '", advancePaymentApplyLog.BankCard, "',  '", advancePaymentApplyLog.GetBamkCard, "',  '", advancePaymentApplyLog.UserName, "')"
            }));
        }

        public int ApplyOperateMoneyAndReduceBV(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog, ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            List<string> sqls = new List<string>();
            sqls.Add(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentApplyLog( Guid, OperateType\t,CurrentAdvancePayment\t,OperateMoney,OperateStatus,Date,Memo,MemLoginID,PaymentGuid,PaymentName,Bank,TrueName,Account,IsDeleted,  OrderNumber,ID,BankCard,GetBamkCard,UserName  ) VALUES (  '"
                , advancePaymentApplyLog.Guid, "',  ", advancePaymentApplyLog.OperateType, ",  ",
                advancePaymentApplyLog.CurrentAdvancePayment, ",  ", advancePaymentApplyLog.OperateMoney, ",  ",
                advancePaymentApplyLog.OperateStatus, ",  '", advancePaymentApplyLog.Date, "',  '",
                Operator.FilterString(advancePaymentApplyLog.Memo), "',  '", advancePaymentApplyLog.MemLoginID,
                "',  '", advancePaymentApplyLog.PaymentGuid, "',  '",
                Operator.FilterString(advancePaymentApplyLog.PaymentName), "',  '",
                Operator.FilterString(advancePaymentApplyLog.Bank), "',  '",
                Operator.FilterString(advancePaymentApplyLog.TrueName), "',  '", advancePaymentApplyLog.Account,
                "',  '", advancePaymentApplyLog.IsDeleted, "', '",
                Operator.FilterString(advancePaymentApplyLog.OrderNumber), "',  ", advancePaymentApplyLog.ID,
                ",  '", advancePaymentApplyLog.BankCard, "',  '", advancePaymentApplyLog.GetBamkCard, "',  '", advancePaymentApplyLog.UserName, "')"
            }));

            sqls.Add (string.Concat(new object[]
            {
                  "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            }));

            sqls.Add (string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment = AdvancePayment + " + advancePaymentModifyLog.OperateMoney +" WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
                }));

            try
            {
                DatabaseExcetue.RunTransactionSql(sqls);
                return 1;
            }
            catch
            {
                return 0;
            }


            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operateStatus"></param>
        /// <param name="strOrderNumber"></param>
        /// <returns></returns>
        public int ChangeApplyLogStatus(int operateStatus, string strOrderNumber)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]{"UPDATE  ShopNum1_AdvancePaymentApplyLog SET  OperateStatus =", operateStatus," WHERE ordernumber ='", Operator.FilterString(strOrderNumber), "'"}));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int Delete(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_AdvancePaymentApplyLog  WHERE  Guid"+andSql,parms.ToArray());
        }

        public int ChangeOperateStatusPL(string guids)
        {

            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));


            return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_AdvancePaymentApplyLog SET   OperateStatus =1 WHERE Guid " + andSql, parms.ToArray());

            
        }
        /// <summary>
        /// 以太坊提现批量删除
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int deleteETH_Tx(string orderid)
        {

            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(orderid, parms));


            return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_AdvancePaymentApplyLog SET   IsDeleted =1 WHERE OrderID " + andSql, parms.ToArray());


        }


        public int deleteNEC_Tx(string orderid)
        {

            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(orderid, parms));


            return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_AdvancePaymentApplyLog SET   IsDeleted =1 WHERE OrderID " + andSql, parms.ToArray());


        }

        /// <summary>
        /// 查询金币（BV）操作日志（充值、提现）
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataTable Search(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,OperateType\t,CurrentAdvancePayment\t,OperateMoney,Date,OperateStatus,Memo,UserMemo,Bank,Account,TrueName,MemLoginID\t,PaymentGuid,PaymentName,IsDeleted ,BankCard,GetBamkCard,UserName  FROM ShopNum1_AdvancePaymentApplyLog ";
            if (guid != string.Empty)
            {
                strSql = strSql + " WHERE Guid='" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
        //提现查询
        public DataTable SearchTx(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT sa.Guid as Guid,sa.OperateType as OperateType\t,sa.CurrentAdvancePayment as CurrentAdvancePayment\t,sa.OperateMoney OperateMoney,( CASE when OperateMoney-(sa.OperateMoney*0.995) <= 10 then OperateMoney-10 when OperateMoney-(sa.OperateMoney*0.995) > 10 then sa.OperateMoney*0.995  end  )  as ActualMoney,sa.Date as Date,sa.OperateStatus as OperateStatus,sa.Memo as Memo,sa.UserMemo as UserMemo,sa.Bank as Bank,sa.Account as Account,sa.TrueName as TrueName,sa.MemLoginID as MemLoginID\t,sa.PaymentGuid PaymentGuid,sa.PaymentName PaymentName,sa.IsDeleted as IsDeleted,sa.BankCard as BankCard,sa.GetBamkCard as GetBamkCard,sa.UserName as UserName,RealName,TrueName  FROM ShopNum1_AdvancePaymentApplyLog as sa left join ShopNum1_Member as sm on sa.MemLoginID=sm.MemLoginID ";
            if (guid != string.Empty)
            {
                strSql = strSql + " WHERE sa.Guid='" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }


        /// <summary>
        /// 查询金币（BV）操作日志（充值、提现）
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="operateType"></param>
        /// <param name="operateStatus"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int operateStatus,int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT sa.Guid as Guid,sb.Name as huiyuandengji, sa.OrderNumber as OrderNumber\t,sa.OperateType as OperateType\t,sa.CurrentAdvancePayment as CurrentAdvancePayment\t,sa.OperateMoney as OperateMoney,round(( OperateMoney-(sa.OperateMoney*0.005) ),2)  as ActualMoney,sa.Date as Date,sa.OperateStatus as OperateStatus,sa.Memo as Memo,sa.UserMemo as UserMemo,sa.MemLoginID as MemLoginID\t,sa.PaymentGuid as PaymentGuid,sa.PaymentName as PaymentName,sa.IsDeleted as  IsDeleted,RealName,sa.UserName as UserName,sa.Bank as Bank,sa.TrueName as TrueName,sa.Account as Account   FROM ShopNum1_AdvancePaymentApplyLog as sa left join ShopNum1_Member as sm on sa.MemLoginID=sm.MemLoginID left join ShopNum1_MemberRank as sb on sm.MemberRankGuid=sb.Guid  WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND sa.MemLoginID ='" + memLoginID + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND sa.OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND sa.OperateStatus=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND sa.Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND sa.Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND sa.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  sa.Date Desc");
        }




        public DataTable SearchSaveLog(string memLoginID, string date1, string date2, int operateStatus)
        {
            string str = string.Empty;
            str = "select * from savelog where 1=1";


          
            if (operateStatus != -1)
            {
                str = str + " AND status=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND (time>='" + Operator.FilterString(date1) + "' ";
                if (Operator.FormatToEmpty(date2) != string.Empty)
                {
                    str = str + " or time<='" + Operator.FilterString(date2) + "' ";
                }
                str += ")";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND time<='" + Operator.FilterString(date2) + "' ";
            }
            DataTable dt = DatabaseExcetue.ReturnDataTable(str + "ORDER BY  time Desc");
            return dt;

        }

















        /// <summary>
        /// 查询金币（BV）操作日志（导出）
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="operateType"></param>
        /// <param name="operateStatus"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>

        public DataTable SearchCzDc(string memLoginID, string date1, string date2, int operateType, int operateStatus, int isDeleted, string TextBoxModifyTime1, string TextBoxModifyTime2)
        {
            string str = string.Empty;
            str =
                "SELECT sa.Guid as Guid,sa.OrderNumber as OrderNumber\t,sa.OperateType as OperateType\t,sa.CurrentAdvancePayment as CurrentAdvancePayment\t,sa.OperateMoney as OperateMoney,( OperateMoney-(sa.OperateMoney*0.005) )  as ActualMoney,sa.Date as Date,sa.OperateStatus as OperateStatus,sa.Memo as Memo,sa.UserMemo as UserMemo,sa.MemLoginID as MemLoginID\t,sa.PaymentGuid as PaymentGuid,sa.PaymentName as PaymentName,sa.IsDeleted as  IsDeleted,RealName,sa.UserName as UserName,sa.Bank as Bank,sa.TrueName as TrueName,sa.Account as Account,sa.ModifyTime as ModifyTime FROM ShopNum1_AdvancePaymentApplyLog as sa left join ShopNum1_Member as sm on sa.MemLoginID=sm.MemLoginID  WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND sa.MemLoginID ='" + memLoginID + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND sa.OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND sa.OperateStatus=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND sa.Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND sa.Date<='" + Operator.FilterString(date2) + "' ";
            }

            if (Operator.FormatToEmpty(TextBoxModifyTime1) != string.Empty)
            {
                str = str + " AND sa.ModifyTime>='" + Operator.FilterString(TextBoxModifyTime1) + "' ";
            }
            if (Operator.FormatToEmpty(TextBoxModifyTime2) != string.Empty)
            {
                str = str + " AND sa.ModifyTime<='" + Operator.FilterString(TextBoxModifyTime2) + "' ";
            }

            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND sa.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  sa.Date Desc");
        }



        /// <summary>
        /// 查询金币（BV）操作日志（充值、提现）
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="operateType"></param>
        /// <param name="operateStatus"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable SearchDc(string memLoginID,string realName, string date1, string date2,  int isDeleted)
        {
            string str = string.Empty;
            str =
                "  SELECT  BonusID ,sp.MemLoginID as Mem,sm.MemLoginNO,Bonus1,Bonus2,Bonus3,BonusAll,RealName,sp.CreateTime as Cre,sp.Isdelete as isd,Proportion, sp.membership_Level as meml ,sp.standardfactor  FROM [Bonus] as sp left join ShopNum1_Member as sm on sp.MemLoginID=sm.MemLoginID  WHERE 0=0    ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND sp.MemLoginID ='" + memLoginID + "'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                str = str + " AND  sm.RealName='" + realName + "'";
            }
            //if (operateType != -1)
            //{
            //    str = str + " AND sa.OperateType=" + operateType;
            //}
            //if (operateStatus != -1)
            //{
            //    str = str + " AND sp.OperateStatus=" + operateStatus;
            //}
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Convert(DATETIME,convert(varchar(10),sp.CreateTime,23))>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Convert(DATETIME,convert(varchar(10),sp.CreateTime,23))<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == -1))
            {
                
            }
            else
            {
                str = string.Concat(new object[] { str, " AND sp.IsDelete="+ isDeleted+ " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  BonusID Desc");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonModel"></param>
        /// <returns></returns>
        public DataTable SelectAdvPayment_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "Date";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberid"></param>
        /// <param name="operatetype"></param>
        /// <param name="datetime1"></param>
        /// <param name="datetime2"></param>
        /// <param name="ordernumber"></param>
        /// <param name="hidbank"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public DataTable SelectOperateMoney(string memberid, string operatetype, string datetime1, string datetime2,string ordernumber, string hidbank, string bank)
        {
            string strSql = string.Empty;
            strSql = " SELECT * FROM ShopNum1_AdvancePaymentApplyLog ";
            strSql = strSql + " WHERE 1=1 and OperateType ='" + operatetype + "'";
            if (Operator.FormatToEmpty(memberid) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID='" + Operator.FilterString(memberid) + "' ";
            }
            if (Operator.FormatToEmpty(datetime1) != string.Empty)
            {
                strSql = strSql + " AND Date>='" + Operator.FilterString(datetime1) + "' ";
            }
            if (Operator.FormatToEmpty(datetime2) != string.Empty)
            {
                strSql = strSql + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " +
                         Operator.FilterString(datetime2) + "'),120)  as  a)  ";
            }
            if (Operator.FormatToEmpty(ordernumber) != string.Empty)
            {
                strSql = strSql + " AND OrderNumber='" + ordernumber + "'";
            }
            if (Operator.FormatToEmpty(operatetype) != string.Empty)
            {
                if (operatetype == "0")
                {
                    if ((Operator.FormatToEmpty(hidbank) != string.Empty) && (hidbank != "-1"))
                    {
                        if (hidbank == "1")
                        {
                            if (Operator.FormatToEmpty(bank) != string.Empty)
                            {
                                strSql = strSql + " AND Bank='" + bank + "'";
                            }
                        }
                        else
                        {
                            strSql = strSql + " AND Bank='" + hidbank + "'";
                        }
                    }
                }
                else if ((Operator.FormatToEmpty(hidbank) != string.Empty) && (Operator.FormatToEmpty(hidbank) != "-1"))
                {
                    strSql = strSql + " AND PaymentGuid='" + hidbank + "'";
                }
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="memLoginID"></param>
        /// <param name="operateType"></param>
        /// <param name="operateMoney"></param>
        /// <param name="operateStatus"></param>
        /// <param name="userMemo"></param>
        /// <param name="advancePaymentModifyLog"></param>
        /// <returns></returns>
        public int Update(string guid, string memLoginID, string operateType, decimal operateMoney, int operateStatus,string userMemo, ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  UserMemo ='", Operator.FilterString(userMemo),
                    "', OperateStatus =", operateStatus, " WHERE Guid ='", Operator.FilterString(guid), "'"
                });
            sqlList.Add(item);
            if (operateStatus == 1)
            {
                if (operateType == "1")
                {
                    item =
                        string.Concat(new object[]
                        {
                            "UPDATE ShopNum1_Member SET  AdvancePayment =AdvancePayment +", operateMoney,
                            " Where  MemLoginID='", memLoginID, "'"
                        });
                    sqlList.Add(item);
                }
                else if (operateType == "0")
                {
                    item =
                        string.Concat(new object[]
                        {
                            "UPDATE ShopNum1_Member SET  AdvancePayment = AdvancePayment-", operateMoney,
                            " Where  MemLoginID='", memLoginID, "'"
                        });
                    sqlList.Add(item);
                }
                item = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '"
                    , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                    advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney,
                    ",  ", advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                    Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID
                    ,
                    "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                    advancePaymentModifyLog.CreateTime, "',  ", advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int ChangeLogStatus(int operateStatus, string Guid)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  OperateStatus =", operateStatus,
                        " WHERE  Guid ='", Operator.FilterString(Guid), "'"
                    }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operateStatus"></param>
        /// <param name="Guid"></param>
        /// <param name="UserMemo"></param>
        /// <returns></returns>
        public int ChangeLogStatusNew(int operateStatus, string Guid, string UserMemo)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_AdvancePaymentApplyLog SET   UserMemo ='", UserMemo, "', OperateStatus =",
                        operateStatus, " ,ModifyTime=GETDATE() WHERE  Guid ='", Operator.FilterString(Guid), "'"
                    }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMemo"></param>
        /// <param name="operateStatus"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public int ChangeOperateStatus(string userMemo, int operateStatus, string guid)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  UserMemo ='", Operator.FilterString(userMemo),
                        "', OperateStatus =", operateStatus, " WHERE Guid ='", Operator.FilterString(guid), "'"
                    }));
        }
        public int NECChangeOperateStatus(int operateStatus, string guid)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  Nec_TiXian SET  Status =", operateStatus, " WHERE OrderID ='", Operator.FilterString(guid), "'"
                    }));
        }

        public int nnnnNECChangeOperateStatus(int operateStatus, string guid)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  Nec_TiXianNEC SET  Status =", operateStatus, " WHERE OrderID ='", Operator.FilterString(guid), "'"
                    }));
        }
        public int nnnnNECChangeOperateStatus(int operateStatus, string guid, string txhash)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  Nec_TiXianNEC SET  Status =", operateStatus, ",TxHash='",txhash,"' WHERE OrderID ='",guid, "'"
                    }));
        }
        public int NECChangeOperateStatus(int operateStatus, string guid,string txhash)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  Nec_TiXian SET  Status =", operateStatus, ",TxHash='",txhash,"' WHERE OrderID ='",guid, "'"
                    }));
        }


        public DataTable Search(string OrderNumber, string memLoginID, string date1, string date2, int operateType,
            int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT Guid,OrderNumber\t,OperateType\t,CurrentAdvancePayment\t,OperateMoney,Date,OperateStatus,Memo,UserMemo,MemLoginID\t,PaymentGuid,PaymentName,IsDeleted   FROM ShopNum1_AdvancePaymentApplyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID like '%" + memLoginID + "%'";
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " AND  OrderNumber like '%" + OrderNumber + "%'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND OperateStatus=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, "AND IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc");
        }


        public DataTable SearchCz(string OrderNumber, string memLoginID, string date1, string date2, string ModifyTime1, string ModifyTime2, int operateType, int PaymentName,
            int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT Guid,OrderNumber\t,OperateType\t,CurrentAdvancePayment\t,OperateMoney,Date,OperateStatus,Memo,UserMemo,MemLoginID\t,PaymentGuid,PaymentName,IsDeleted,ModifyTime   FROM ShopNum1_AdvancePaymentApplyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID like '%" + memLoginID + "%'";
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " AND  OrderNumber like '%" + OrderNumber + "%'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND OperateStatus=" + operateStatus;
            }
            if (PaymentName != -1)
            {
                if (PaymentName == 0)
                {
                    str = str + " AND PaymentName='线下支付'" ;
                }
                if (PaymentName == 1)
                {
                    str = str + " AND PaymentName='唐江智付快捷支付'" ;
                }
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }

            if (Operator.FormatToEmpty(ModifyTime1) != string.Empty)
            {
                str = str + " AND ModifyTime>='" + Operator.FilterString(ModifyTime1) + "' ";
            }
            if (Operator.FormatToEmpty(ModifyTime2) != string.Empty)
            {
                str = str + " AND ModifyTime<='" + Operator.FilterString(ModifyTime2) + "' ";
            }

            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY  Date Desc");
        }
        //SearchTx(string OrderNumber, string memLoginID, string date1, string date2, int operateType,int operateStatus, int isDeleted)方法的老语句
        //( CASE when OperateMoney-(sa.OperateMoney*0.99) <= 10 then OperateMoney-10 when OperateMoney-(sa.OperateMoney*0.99) > 10 then sa.OperateMoney*0.99  end  )  as ActualMoney
        public DataTable SearchTx(string OrderNumber, string memLoginID, string date1, string date2, int operateType,
            int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT sa.Guid as Guid,sa.OrderNumber as OrderNumber,sa.OperateType as OperateType,sa.CurrentAdvancePayment as CurrentAdvancePayment,sa.OperateMoney as OperateMoney,( OperateMoney-(sa.OperateMoney*0.005) )  as ActualMoney,sa.Date as Date,sa.OperateStatus as OperateStatus,sa.Bank as Bank,sa.Memo as Memo,sa.UserMemo as UserMemo,sa.MemLoginID as MemLoginID,sa.PaymentGuid as PaymentGuid,sa.PaymentName as PaymentName ,sa.IsDeleted as IsDeleted,sm.RealName as RealName,Account,TrueName   FROM ShopNum1_AdvancePaymentApplyLog as sa left join ShopNum1_Member as sm on sa.MemLoginID=sm.MemLoginID  WHERE 0=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND  sa.MemLoginID ='" + memLoginID + "'";
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " AND  sa.OrderNumber like '%" + OrderNumber + "%'";
            }
            if (operateType != -1)
            {
                str = str + " AND sa.OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND sa.OperateStatus=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND sa.Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND sa.Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, "AND sa.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  sa.Date Desc");
        }

        /// <summary>
        /// 以太坊充值查询
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="operateType"></param>
        /// <param name="operateStatus"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable ETHSearchCz(string memLoginID, string date1, string date2, int operateType,
int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT  a.*,(case when MemLoginID IS NULL  then '无工号'  else MemLoginID end) as MemLoginID,(case when  a.Toaddr=b.NECAddress  then 'NEC' WHEn a.Toaddr=b.ETHAddress  then 'ETH'  else '无效币种' end) as Bizhong FROM Nec_ChongZhi as a left join ShopNum1_Member as b on (a.Toaddr=b.ETHAddress or a.Toaddr=b.NECAddress) where a.Toaddr!='0xf47e0e6cd02205e19411a46dd0960b4d23442798' and  0=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND  MemLoginID ='" + memLoginID + "'";
            }
            

            if (operateStatus != -1)
            {
                str = str + " AND a.Status=" + operateStatus;
            }
            if (operateType != -1)
            {
                str = str + " AND a.BiType=" + operateType;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Time>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Time<='" + Operator.FilterString(date2) + "' ";
            }
            
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Time Desc");
        }


        //提现查询
        public DataTable ETHSearchTx(string ordernumber)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT * from Nec_TiXian   where IsDeleted=0";
            if (ordernumber != string.Empty)
            {
                strSql = strSql + " and OrderID='" + Operator.FilterString(ordernumber) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable NNECSearchTx(string ordernumber)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT * from Nec_TiXianNEC   where IsDeleted=0";
            if (ordernumber != string.Empty)
            {
                strSql = strSql + " and OrderID='" + Operator.FilterString(ordernumber) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        /// <summary>
        /// 以太坊提现
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="memLoginID"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="operateType"></param>
        /// <param name="operateStatus"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable ETHSearchTx(string OrderNumber, string memLoginID, string date1, string date2, int operateType,
    int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT * from Nec_TiXian  WHERE 0=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND  MemLoginID ='" + memLoginID + "'";
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " AND  OrderID like '%" + OrderNumber + "%'";
            }
            
            if (operateStatus != -1)
            {
                str = str + " AND Status=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND TxTime>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND TxTime<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, "AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  TxTime Desc");
        }
        public DataTable NECSearchTx(string OrderNumber, string memLoginID, string date1, string date2, int operateType,
 int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT * from Nec_TiXianNEC  WHERE 0=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND  MemLoginID ='" + memLoginID + "'";
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " AND  OrderID like '%" + OrderNumber + "%'";
            }

            if (operateStatus != -1)
            {
                str = str + " AND Status=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND TxTime>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND TxTime<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, "AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  TxTime Desc");
        }
        public DataTable SearchStatus(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;

            string str = string.Empty;
            str =
                "SELECT Guid,OrderNumber,OperateType,CurrentAdvancePayment,OperateMoney,Date,OperateStatus,Memo,UserMemo,MemLoginID,PaymentGuid,PaymentName,IsDeleted   FROM ShopNum1_AdvancePaymentApplyLog   WHERE 0=0 and OrderNumber=@OrderNumber ";
            
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc",parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="memLoginID"></param>
        /// <param name="operateType"></param>
        /// <param name="operateMoney"></param>
        /// <param name="operateStatus"></param>
        /// <param name="userMemo"></param>
        /// <param name="advancePaymentModifyLog"></param>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public int Update_Update(string guid, string memLoginID, string operateType, decimal operateMoney,int operateStatus, string userMemo, ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog, string AdminID)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  UserMemo ='", Operator.FilterString(userMemo), "', OperateStatus =", operateStatus, ",ModifyTime=GETDATE() WHERE Guid ='", Operator.FilterString(guid), "'" });
            sqlList.Add(item);
            if (operateStatus == 1)
            {
                if ((!(operateType == "0") && (operateType == "1")) &&(Common.Common.GetNameById("OperateStatus", "ShopNum1_AdvancePaymentApplyLog"," and Guid ='" + Operator.FilterString(guid) + "'") == "0"))
                {
                    item =
                        string.Concat(new object[]{"UPDATE ShopNum1_Member SET  AdvancePayment = AdvancePayment+", operateMoney," Where  MemLoginID='", memLoginID, "'"});
                    sqlList.Add(item);
                    item = string.Concat(new object[]{

                        "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '"
                        , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                        advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney,
                        ",  ", advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date,
                        "',  '", Operator.FilterString(advancePaymentModifyLog.Memo), "',  '",
                        advancePaymentModifyLog.MemLoginID,
                        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                        advancePaymentModifyLog.CreateTime, "',  ", advancePaymentModifyLog.IsDeleted, ")"
                    });

                    sqlList.Add(item);
                }
            }
            else if (operateStatus == 2)
            {
                if (operateType == "0")
                {
                    DataTable table = new ShopNum1_Member_Action().SearchByMemLoginID(memLoginID);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        var advancePaymentFreezeLog = new ShopNum1_AdvancePaymentFreezeLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = 1,
                            OperateMoney = Convert.ToDecimal(operateMoney),
                            LastOperateMoney =
                                Convert.ToDecimal(table.Rows[0]["LockAdvancePayment"].ToString()) -
                                Convert.ToDecimal(operateMoney),
                            CurrentAdvancePayment =
                                Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString()) +
                                Convert.ToDecimal(operateMoney),
                            Date = DateTime.Now,
                            Memo = "拒绝提现返还冻结金额",
                            MemLoginID = memLoginID,
                            CreateUser = AdminID,
                            CreateTime = DateTime.Now.ToString(),
                            IsDeleted = 0
                        };

                        new ShopNum1_AdvancePaymentFreezeLog_Action().OperateMoney(advancePaymentFreezeLog,Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString()) +Convert.ToDecimal(operateMoney));
                    }
                }
                else if (!(operateType == "1"))
                {
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable SearchJs(string MemLoginID, string RealName, string date1, string date2,
            int operateStatus)
        {
            string str = string.Empty;
            str =
                "  select ROW_NUMBER() over(order by sm.MemLoginNO) as rowId ,pm.Bonus1,pm.Bonus2,pm.Bonus3,pm.BonusAll ,pm.Proportion,pm.membership_Level,pm.standardfactor,pm.MemLoginID,RealName,pm.CreateTime ,pm.Isdelete from(select  MemLoginID,Bonus1,Bonus2,Bonus3,BonusAll,Isdelete,Proportion,CASE when membership_Level=1 then '一星会员'  when membership_Level=2 then '二星会员' when membership_Level=3 then '三星会员'when membership_Level=4 then '四星会员'when membership_Level=5 then '五星会员' when membership_Level=6 then '普通会员' when membership_Level=0 then '体验会员' end membership_Level,standardfactor ,Convert(DATETIME ,convert(varchar(10),CreateTime,23)) as CreateTime from [Bonus] ) as pm left join ShopNum1_Member as sm on pm.MemLoginID=sm.MemLoginID where 0=0";
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                str = str + " AND  pm.MemLoginID ='" + MemLoginID + "'";
            }
            if (!string.IsNullOrEmpty(RealName))
            {
                str = str + " AND  RealName='" + RealName + "'";
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND pm.CreateTime>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND pm.CreateTime<='" + Operator.FilterString(date2) + "' ";
            }
            if ((operateStatus == 0) || (operateStatus == 1) || (operateStatus == 2))
            {
                str = string.Concat(new object[] { str, "AND IsDelete=", operateStatus, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  CreateTime desc");
        }

        public DataTable SearchJs_QLX(string MemLoginID, string RealName, string date1, string date2,
    int operateStatus)
        {
            string str = string.Empty;
            str =
                "  select ROW_NUMBER() over(order by sm.MemLoginNO) as rowId ,pm.Bonus1,(pm.Bonus2+pm.Bonus3) as Bonus2,pm.Bonus4,pm.Bonus5  ,pm.MemLoginID,RealName,pm.CreateTime ,pm.Isdelete from(select  MemLoginID,Bonus1,Bonus2,Bonus3,Bonus4,bonus5,BonusAll,Isdelete,Proportion, standardfactor ,Convert(DATETIME ,convert(varchar(10),CreateTime,23)) as CreateTime from [Bonus] ) as pm left join ShopNum1_Member as sm on pm.MemLoginID=sm.MemLoginID where 0=0 ";
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                str = str + " AND  pm.MemLoginID ='" + MemLoginID + "'";
            }
            if (!string.IsNullOrEmpty(RealName))
            {
                str = str + " AND  RealName='" + RealName + "'";
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND pm.CreateTime>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND pm.CreateTime<='" + Operator.FilterString(date2) + "' ";
            }
            if ((operateStatus == 0) || (operateStatus == 1) || (operateStatus == 2))
            {
                str = string.Concat(new object[] { str, "AND IsDelete=", operateStatus, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  CreateTime desc");
        }


        public DataTable SearchJs(string MemLoginNO, string Times)
        {
            string str = string.Empty;
            str =
                "    SELECT  BonusID,sp.MemLoginID,sm.MemLoginNO,Bonus1,Bonus2,Bonus3,BonusAll,sm.RealName,sp.CreateTime,sp.Isdelete,sp.Proportion,sp.membership_Level,sp.standardfactor  FROM [Bonus] as sp left join ShopNum1_Member as sm on sp.MemLoginID=sm.MemLoginID  WHERE 0=0 ";
            str = str + " AND  sp.MemLoginID ='" + MemLoginNO + "'";
                str = str + " AND convert(varchar(10),sp.CreateTime,23)='" + Operator.FilterString(Times) + "' ";
                return DatabaseExcetue.ReturnDataTable(str + " ORDER BY  sm.MemLoginID desc");
        }

        public int UpdateJsZt(string id)
        {

            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = id;

            return DatabaseExcetue.RunProcedure("Pro_KCE_Brouns_Push_Member", paraName, paraValue);
                
        }

        public int AllUpdateJsZt(string memberloginno,string times)
        {

            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemberLoginNo";
            paraValue[0] = memberloginno;
            paraName[1] = "@datetime";
            paraValue[1] =Operator.FilterString(times);
            return DatabaseExcetue.RunProcedure("Pro_KCE_Brouns_All_Push_Member", paraName, paraValue);

        }

        public int DeleteJs(string id)
        {
            string str = string.Empty;
            str =
                "delete from ShopNum1_PushMoney where";
            str = str + "  id ='" + id + "'";
            return DatabaseExcetue.RunNonQuery(str);
        }

        public int IdentificationJsZt(string id)
        {

            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = id;

            return DatabaseExcetue.RunProcedure("Pro_Identification_Push_Member", paraName, paraValue);

        }

       
    }
}