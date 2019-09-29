using System;
using System.Collections.Generic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MMSGroupSend_Action : IShopNum1_MMSGroupSend_Action
    {
        public int Add(ShopNum1_MMSGroupSend MMSGroupSend)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MMSGroupSend( Guid, SendObject, SendObjectMMS, MMSTitle, State, CreateTime, IsTime, TimeSendTime, MMSGuid  ) VALUES (  '"
                , MMSGroupSend.Guid, "',  '", Operator.FilterString(MMSGroupSend.SendObject), "',  '",
                Operator.FilterString(MMSGroupSend.SendObjectMMS), "',  '",
                Operator.FilterString(MMSGroupSend.MMSTitle), "',  '", Operator.FilterString(MMSGroupSend.State),
                "',  '", MMSGroupSend.CreateTime, "', '", MMSGroupSend.IsTime, "',  '", MMSGroupSend.TimeSendTime,
                "' , '", MMSGroupSend.MMSGuid, "' )"
            });
            sqlList.Add(item);
            string str2 = Guid.NewGuid().ToString();
            item =
                "INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,MemLoginID,Content,sendtime,OperateUser,IsDeleted  ) VALUES (  '" +
                str2 + "',  '" + Operator.FilterString(MMSGroupSend.MMSTitle) + "',  '1',  '" +
                MMSGroupSend.SendObject.Split(new[] {'-'})[0] + "',  '" +
                Operator.FilterString(MMSGroupSend.SendObjectMMS) + "',  '" + DateTime.Now +
                "' , 'admin' , '0')";
            sqlList.Add(item);
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_UserMessage(  Guid ,  ReceiveID ,  SendID,  IsRead, SendTime,  IsDeleted,  MessageInfoGuid,  SendIsDeleted,  ReceiveIsDeleted  ) VALUES (  '"
                , Guid.NewGuid(), "',  '", MMSGroupSend.SendObject.Split(new[] {'-'})[0], "',  'admin',  ", 0,
                ",  '", DateTime.Now.ToString(), "',  ", 0, ",  '", str2, "',  ", 0, ",  ", 0,
                " )"
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

        public int AddTwo(ShopNum1_MMSGroupSend MMSGroupSend)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MMSGroupSend( Guid, SendObject, SendObjectMMS, MMSTitle, State, CreateTime, IsTime, TimeSendTime, MMSGuid  ) VALUES (  '"
                , MMSGroupSend.Guid, "',  '", Operator.FilterString(MMSGroupSend.SendObject), "',  '",
                Operator.FilterString(MMSGroupSend.SendObjectMMS), "',  '",
                Operator.FilterString(MMSGroupSend.MMSTitle), "',  '", Operator.FilterString(MMSGroupSend.State),
                "',  '", MMSGroupSend.CreateTime, "', '", MMSGroupSend.IsTime, "',  '", MMSGroupSend.TimeSendTime,
                "' , '", MMSGroupSend.MMSGuid, "' )"
            });
            sqlList.Add(item);
            string str2 = Guid.NewGuid().ToString();
            item =
                "INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,MemLoginID,Content,sendtime,OperateUser,IsDeleted  ) VALUES (  '" +
                str2 + "',  '" + Operator.FilterString(MMSGroupSend.MMSTitle) + "',  '1',  '" +
                MMSGroupSend.SendObject.Split(new[] { '-' })[0] + "',  '" +
                Operator.FilterString(MMSGroupSend.SendObjectMMS) + "',  '" + DateTime.Now +
                "' , 'admin' , '0')";
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
    }
}