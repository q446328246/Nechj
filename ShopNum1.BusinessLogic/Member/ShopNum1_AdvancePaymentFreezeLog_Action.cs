using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AdvancePaymentFreezeLog_Action : IShopNum1_AdvancePaymentFreezeLog_Action
    {
        /// <summary>
        ///  金币（BV）冻结日志
        /// </summary>
        /// <param name="advancePaymentFreezeLog"></param>
        /// <param name="lastAdvancePayment"></param>
        /// <returns></returns>
        public int OperateMoney(ShopNum1_AdvancePaymentFreezeLog advancePaymentFreezeLog, decimal lastAdvancePayment)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentFreezeLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '"
                , advancePaymentFreezeLog.Guid, "',  ", advancePaymentFreezeLog.OperateType, ",  ",
                advancePaymentFreezeLog.CurrentAdvancePayment, ",  ", advancePaymentFreezeLog.OperateMoney, ",  ",
                advancePaymentFreezeLog.LastOperateMoney, ",  '",
                Convert.ToDateTime(advancePaymentFreezeLog.Date).ToString("yyyy-MM-dd HH:mm:ss"), "',  '",
                Operator.FilterString(advancePaymentFreezeLog.Memo), "',  '", advancePaymentFreezeLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentFreezeLog.CreateUser), "', '",
                advancePaymentFreezeLog.CreateTime, "',  ", advancePaymentFreezeLog.IsDeleted, ")"
            });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  LockAdvancePayment =", advancePaymentFreezeLog.LastOperateMoney,
                    ", AdvancePayment =", lastAdvancePayment, " WHERE  MemLoginID ='",
                    advancePaymentFreezeLog.MemLoginID, "'"
                });
            sqlList.Add(item);
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

        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted   FROM ShopNum1_AdvancePaymentFreezeLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID ='" + memLoginID + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
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
    }
}