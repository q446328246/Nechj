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
    public class ShopNum1_FreezeRelease_Action : IShopNum1_FreezeRelease_Action
    {

        /// <summary>
        /// 添加冻结资金表
        /// </summary>
        /// <param name="membership"></param>
        /// <returns></returns>
        public int Add(ShopNum1_FreezeRelease freezerelease)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_FreezeRelease( \tFreezeMemLoginID, \tFreezeScore_rv, \tFreezeTime) VALUES (  '"
                    , freezerelease.FreezeMemLoginID, "'," , freezerelease.FreezeScore_rv, ",'" , freezerelease.FreezeTime, "')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }
    }
}
