using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_PreTransfer_Action : IShopNum1_PreTransfer_Action
    {
       /// <summary>
       /// 转帐单
       /// </summary>
       /// <param name="shopNum1_PreTransfer"></param>
       /// <returns></returns>
        public int InsertPay(ShopNum1_PreTransfer shopNum1_PreTransfer)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format(
                        "insert into ShopNum1_PreTransfer([Guid],[OrderNumber],[OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID],[YzCode],[OperateStatus],[IsDeleted],[type])\r\n            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        new object[]
                        {
                            Guid.NewGuid(), shopNum1_PreTransfer.OrderNumber, shopNum1_PreTransfer.OperateMoney,
                            shopNum1_PreTransfer.Date, shopNum1_PreTransfer.Memo, shopNum1_PreTransfer.MemLoginID,
                            shopNum1_PreTransfer.RMemberID, shopNum1_PreTransfer.YzCode,
                            shopNum1_PreTransfer.OperateStatus, shopNum1_PreTransfer.IsDeleted,
                            shopNum1_PreTransfer.type
                        }));
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("   DELETE   ShopNum1_PreTransfer  WHERE   Guid  IN (@guids)  ",parms);
        }

        public DataTable Search(string OrderNumber, string SendMemLoginID, string GetMemLoginID, string date1,
            string date2, int IsDeleted, int operateType)
        {
            string str = string.Empty;
            str = "      SELECT  *,CASE when [type]=1 then 'K宝兑换'  when [type]=2 then 'K宝转出' when [type]=3 then 'CNY转出'when [type]=4 then '扫码支付'when [type]=5 then '交易所转CNY' when [type]=6 then 'CNY转交易所' when [type]=6 then '线下转商户' end type1 FROM ShopNum1_PreTransfer    WHERE  1=1    ";
            //str = "      SELECT  * FROM ShopNum1_PreTransfer    WHERE  1=1    ";
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + "    AND    OrderNumber  LIKE  '%" + OrderNumber + "%'   ";
            }
            if (!string.IsNullOrEmpty(SendMemLoginID))
            {
                str = str + "    AND    MemLoginID ='" + SendMemLoginID + "'   ";
            }
            if (operateType!=0)
            {
                str = str + "    AND    type ='" + operateType + "'   ";
            }
            if (!string.IsNullOrEmpty(GetMemLoginID))
            {
                str = str + "    AND     RMemberID ='" + GetMemLoginID + "'   ";
            }
            if (!string.IsNullOrEmpty(date1))
            {
                str = str + "    AND     Date  >'" + date1 + "'   ";
            }
            if (!string.IsNullOrEmpty(date2))
            {
                str = str + "    AND     Date  <'" + date2 + "'   ";
            }
            object obj2 = str;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[] {obj2, "    AND      IsDeleted =", IsDeleted, "   "}) +
                    "    ORDER  BY  Date DESC   ");
        }
    }
}