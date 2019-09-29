using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopProRelateProp_Action : IShopNum1_ShopProRelateProp_Action
    {
        public DataTable SelectProp(string strPid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strPid";
            parms[0].Value = strPid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_ShopProRelateProp WHERE productguid=@strPid",parms);
        }

        public DataTable SelectPropByIdAndPid(string strId, string strPid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            parms[1].ParameterName = "@strPid";
            parms[1].Value = strPid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_ShopProRelateProp WHERE propid=@strId and productguid=@strPid",parms);
        }

        public int AddListPropValue(List<ShopNum1_ShopProRelateProp> ShopProRelateProp)
        {
            var sqlList = new List<string>();
            if (ShopProRelateProp != null)
            {
                sqlList.Add("delete from ShopNum1_ShopProRelateProp where productguid='" +
                            ShopProRelateProp[0].ProductGuid + "'");
                for (int i = 0; i < ShopProRelateProp.Count; i++)
                {
                    string item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO dbo.ShopNum1_ShopProRelateProp \r\n        ( productguid ,\r\n          PCategoryID ,\r\n          CTypeID ,\r\n          ShowType,\r\n          PropID ,\r\n          PropValueID ,\r\n          InputValue\r\n        ) Values('"
                            , ShopProRelateProp[i].ProductGuid, "','", ShopProRelateProp[i].PCategoryID, "','",
                            ShopProRelateProp[i].CTypeID, "','", ShopProRelateProp[i].ShowType, "','",
                            ShopProRelateProp[i].PropID, "','", ShopProRelateProp[i].PropValueID, "','",
                            ShopProRelateProp[i].InputValue, "')"
                        });
                    sqlList.Add(item);
                }
            }
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