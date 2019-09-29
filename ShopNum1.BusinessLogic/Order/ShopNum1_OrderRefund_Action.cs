using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OrderRefund_Action : IShopNum1_OrderRefund_Action
    {

        public int Add(ShopNum1_OrderRefund OrderRefund) 
        {
            
                string strSql = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_OrderRefund( OrderNumber,MemLoginID,PaymentPrice,Score_hv,Score_pv_a,Score_pv_b,Score_pv_cv,Score_dv,reduce_PaymentPrice,reduce_score_hv,reduce_score_pv_a,reduce_score_pv_b,reduce_score_pv_cv,reduce_score_dv,reduce_score_tj_hv,reduce_score_tjid ) VALUES (  '"
                    , OrderRefund.Ordernumber, "',  '", OrderRefund.MemloginID, "',  ", OrderRefund.PaymentPrice, ",  ", OrderRefund.Score_hv,",  ", OrderRefund.Score_pv_a,",  ", OrderRefund.Score_pv_b,",  ", OrderRefund.Score_pv_cv,",  ", OrderRefund.Score_dv,",  ", OrderRefund.reduce_PaymentPrice,",  ", OrderRefund.reduce_score_hv,",  ", OrderRefund.reduce_score_pv_a,",  ", OrderRefund.reduce_score_pv_b,",  ", OrderRefund.reduce_score_pv_cv,",  ", OrderRefund.reduce_score_dv,",  ", OrderRefund.reduce_TJhv,",  '", OrderRefund.TJMemloginID, "')"
                });
            
            return DatabaseExcetue.RunNonQuery(strSql);
        }

    }
}
