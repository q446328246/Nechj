using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Referral_Action : IShopNum1_Referral_Action
    {

        /// <summary>
        /// 添加会员升级申请
        /// </summary>
        /// <param name="membership"></param>
        /// <returns></returns>
        public int Add(ShopNum1_Referral shopNum1_referral)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Referral( \tBankName, \tAgent, \tBankID, \tBankBranch, \tAccountName, \tReferral, \tMemloginID) VALUES (  '"
                    , shopNum1_referral.BankName, "','" , shopNum1_referral.Agent, "','" , shopNum1_referral.BankID, "','" , shopNum1_referral.BankBranch, "','" , shopNum1_referral.AccountName, "','" , shopNum1_referral.Referral, "','" , shopNum1_referral.MemloginID, "')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

    }
}
