using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AdvancePaymentHelper
    {
        public static string CreateCurrentMemberSql(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string str1 = "UPDATE ShopNum1_Member SET Remak = Remak";
            if (advancePaymentModifyLog.LastOperateMoney != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",AdvancePayment=" + advancePaymentModifyLog.LastOperateMoney ;
            }
            if (advancePaymentModifyLog.Score_hv != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_hv=" + advancePaymentModifyLog.Score_hv ;
            }
            if (advancePaymentModifyLog.Score_dv != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_dv=" + advancePaymentModifyLog.Score_dv ;
            }
            if (advancePaymentModifyLog.Score_pv_a != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_pv_a=" + advancePaymentModifyLog.Score_pv_a ;
            }
            if (advancePaymentModifyLog.Score_pv_b != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_pv_b=" + advancePaymentModifyLog.Score_pv_b ;
            }
            if (advancePaymentModifyLog.Score_pv_c != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_pv_cv=" + advancePaymentModifyLog.Score_pv_c ;
            }

            return str1;
        }


         public static string CreateCurrentMemberSqlWithHVDV(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string str1 = "UPDATE ShopNum1_Member SET Remak = Remak";
            if (advancePaymentModifyLog.LastOperateMoney != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",AdvancePayment=" + advancePaymentModifyLog.LastOperateMoney ;
            }
            if (advancePaymentModifyLog.Score_hv != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_hv=" + advancePaymentModifyLog.Score_hv ;
            }
            if (advancePaymentModifyLog.Score_dv != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_dv=" + advancePaymentModifyLog.Score_dv ;
            }
           
            return str1;
        }

        public static string CreateCurrentMemberSqlWithPVABC(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string str1 = "UPDATE ShopNum1_Member SET Remak = Remak";

            if (advancePaymentModifyLog.Score_pv_a != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_pv_a=" + advancePaymentModifyLog.Score_pv_a ;
            }
            if (advancePaymentModifyLog.Score_pv_b != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_pv_b=" + advancePaymentModifyLog.Score_pv_b ;
            }
            if (advancePaymentModifyLog.Score_pv_c != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_pv_cv=" + advancePaymentModifyLog.Score_pv_c ;
            }
            if (advancePaymentModifyLog.TJScore_hv != ShopNum1_AdvancePaymentModifyLog.defaultValue)
            {
                str1 = str1 + ",Score_hv=" + advancePaymentModifyLog.TJScore_hv;
            }

            return str1;
        }
    }
}
