using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OrderOperateLog_Action : IShopNum1_OrderOperateLog_Action
    {
        public int Add(ShopNum1_OrderOperateLog orderOperateLog)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderOperateLog( Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted ) VALUES ( '"
                , orderOperateLog.Guid, "','", orderOperateLog.OrderInfoGuid, "','", orderOperateLog.CreateUser,
                "',", orderOperateLog.OderStatus, ",", orderOperateLog.ShipmentStatus, ",",
                orderOperateLog.PaymentStatus, ",'", Operator.FilterString(orderOperateLog.CurrentStateMsg), "','",
                Operator.FilterString(orderOperateLog.NextStateMsg),
                "','", Operator.FilterString(orderOperateLog.Memo), "','",
                Convert.ToDateTime(orderOperateLog.OperateDateTime).ToString("yyyy-MM-dd HH:mm:ss"), "',",
                orderOperateLog.IsDeleted, ")"
            }));
        }

        public DataTable Search(string orderInfoGuid)
        {
            string str = string.Empty;
            str =
                "SELECT Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,Memo,OperateDateTime,IsDeleted  FROM ShopNum1_OrderOperateLog  WHERE 0=0 ";
            if (orderInfoGuid != "-1")
            {
                str = string.Concat(new object[] {str, " AND OrderInfoGuid='", new Guid(orderInfoGuid), "'"});
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY OperateDateTime DESC");
        }
    }
}