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
    public class ShopNum1_PostageSettings_Action : IShopNum1_PostageSettings_Action
    {

        public int Add(ShopNum1_PostageSettings PostageSettings)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_PostageSettings(MemLoginID) VALUES (  '",PostageSettings.MemLoginID, "')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        public DataTable SelectPrice(string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            return
                DatabaseExcetue.ReturnDataTable("   select  * from  ShopNum1_PostageSettings  where MemLoginID=@memloginid", parms);
        }

        public int UpdatePostagePrice(string memloginid, decimal FirstHeavyPrice, decimal AfterHeavyPrice, decimal FirstHeavy)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@FirstHeavyPrice";
            parms[1].Value = FirstHeavyPrice;
            parms[2].ParameterName = "@AfterHeavyPrice";
            parms[2].Value = AfterHeavyPrice;
            parms[3].ParameterName = "@FirstHeavy";
            parms[3].Value = FirstHeavy;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_PostageSettings set FirstHeavyPrice=@FirstHeavyPrice,AfterHeavyPrice=@AfterHeavyPrice,FirstHeavy=@FirstHeavy where MemLoginID=@memloginid", parms);
        }
    }
}
