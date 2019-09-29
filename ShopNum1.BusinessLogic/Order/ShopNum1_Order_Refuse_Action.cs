using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Order_Refuse_Action : IShopNum1_Order_Refuse_Action
    {
        public int Add(ShopNum1_Order_Refuse OrderRefuse)
        {

            string strSql = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Order_Refuse( OrderID,MemberloginID,Remark,EndTime,Status,AdminID) VALUES (  '"
                    , OrderRefuse.OrderID, "',  '", OrderRefuse.MemberloginID, "',  '", OrderRefuse.Remark, "',  '", OrderRefuse.EndTime,"',  '", OrderRefuse.Status,"',  '", OrderRefuse.AdminID,"')"
                });

            return DatabaseExcetue.RunNonQuery(strSql);
        }

    }
}
