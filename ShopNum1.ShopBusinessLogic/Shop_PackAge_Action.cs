using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_PackAge_Action : IShop_PackAge_Action
    {
        public int DeletePackAge(string strPackAgeId, string strMemloginId)
        {
            string str = "delete from ShopNum1_PackAge where id='" + strPackAgeId + "' AND memloginId='" + strMemloginId +
                         "';";
            var sqlList = new List<string>
            {
                str,
                "DELETE FROM ShopNum1_PackAgeRalate WHERE packageId='" + strPackAgeId + "';"
            };
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

        public int DeletePackAgeInfo(string strPackAgeId, string strProductGuID)
        {
            return
                DatabaseExcetue.RunNonQuery("delete from ShopNum1_PackAgeRalate where productguid='" + strProductGuID +
                                            "' AND packageId='" + strPackAgeId + "'");
        }

        public DataSet GetPackAgeInfo(string strPackAgeId, string strMemloginID)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@packageid";
            paraValue[0] = strPackAgeId;
            paraName[1] = "@memloginId";
            paraValue[1] = strMemloginID;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_shop_GetPackageInfo", paraName, paraValue);
        }

        public DataSet GetPackAgeProduct(string strPackAgeId, string strProductGuID)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@packageid";
            paraValue[0] = strPackAgeId;
            paraName[1] = "@productguid";
            paraValue[1] = strProductGuID;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_GetPackAgeProduct", paraName, paraValue);
        }

        public int OpPackAge(ShopNum1_PackAge ShopNum1_PackAge, List<ShopNum1_PackAgeRalate> listPackAgeRalate)
        {
            var paraName = new string[10];
            var paraValue = new string[10];
            paraName[0] = "@Name";
            paraValue[0] = ShopNum1_PackAge.Name;
            paraName[1] = "@Price";
            paraValue[1] = ShopNum1_PackAge.Price.ToString();
            paraName[2] = "@SalePrice";
            paraValue[2] = ShopNum1_PackAge.SalePrice.ToString();
            paraName[3] = "@Pic";
            paraValue[3] = ShopNum1_PackAge.Pic;
            paraName[4] = "@Desc";
            paraValue[4] = ShopNum1_PackAge.Desc;
            paraName[5] = "@state";
            paraValue[5] = ShopNum1_PackAge.State.ToString();
            paraName[6] = "@ShopName";
            paraValue[6] = ShopNum1_PackAge.ShopName;
            paraName[7] = "@MemloginId";
            paraValue[7] = ShopNum1_PackAge.MemloginId;
            paraName[8] = "@CreateTime";
            paraValue[8] = ShopNum1_PackAge.CreateTime.ToString();
            paraName[9] = "@Id";
            paraValue[9] = ShopNum1_PackAge.Id.ToString();
            int num2 = Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_OpPackAge", paraName, paraValue));
            var sqlList = new List<string>();
            if ((listPackAgeRalate != null) && (listPackAgeRalate.Count > 0))
            {
                sqlList.Add("DELETE FROM ShopNum1_PackAgeRalate WHERE Packageid='" + ShopNum1_PackAge.Id + "'");
                for (int i = 0; i < listPackAgeRalate.Count; i++)
                {
                    listPackAgeRalate[i].PackAgeId = num2;
                    sqlList.Add(
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_PackAgeRalate(productguid,packageid) Values('",
                            listPackAgeRalate[i].ProductGuid, "','", listPackAgeRalate[i].PackAgeId, "')"
                        }));
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
            return 0;
        }

        public DataTable SelectPackAgeProduct(string pagesize, string currentpage, string condition, string resultnum,
            string sortvalue, string ordercolumn, string strColumns, string strTabName)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = strColumns;
            paraName[3] = "@tablename";
            paraValue[3] = strTabName;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = ordercolumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = sortvalue;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}