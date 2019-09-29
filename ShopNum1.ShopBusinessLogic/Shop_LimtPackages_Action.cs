using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_LimtPackages_Action : IShop_LimtPackages_Action
    {
        public int AddLimtPackage(ShopNum1_Limt_Package shopNum1_Limt_Package)
        {
            string str =
                "INSERT INTO ShopNum1_Limt_Package(name,starttime,endtime,PublishedNum,LeaveNum,LimtActivityNum,LimitProductNum,BuyNum,PayMoney,ShopName,MemloginId)";
            object obj2 = str;
            obj2 =
                string.Concat(new[]
                {
                    obj2, "VALUES('", shopNum1_Limt_Package.Name, "','", shopNum1_Limt_Package.StartTime, "','",
                    shopNum1_Limt_Package.EndTime, "','", shopNum1_Limt_Package.PublishedNum, "',"
                });
            obj2 =
                string.Concat(new[]
                {
                    obj2, "'", shopNum1_Limt_Package.LeaveNum, "','", shopNum1_Limt_Package.LimtActivityNum, "','",
                    shopNum1_Limt_Package.LimitProductNum, "','", shopNum1_Limt_Package.BuyNum, "',"
                });
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new[]
                    {
                        obj2, "'", shopNum1_Limt_Package.PayMoney, "','", shopNum1_Limt_Package.ShopName, "','",
                        shopNum1_Limt_Package.MemloginId, "')"
                    }));
        }

        public int DeletePackById(string MemloginId, string strAid)
        {
            string str = "DELETE FROM ShopNum1_Product_Activity WHERE MemloginId='" + MemloginId + "' And Id='" + strAid +
                         "';";
            string str2 = "DELETE FROM ShopNum1_Limt_Product WHERE MemloginId='" + MemloginId + "' And Lid='" + strAid +
                          "';";
            var sqlList = new List<string>
            {
                str,
                str2
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

        public string ReturnDate(string MemloginId)
        {
            return
                DatabaseExcetue.ReturnString(
                    "select CONVERT(varchar(100),starttime,23)+'|'+CONVERT(varchar(100),endtime,23) from ShopNum1_Limt_Package where memloginid='" +
                    MemloginId + "' order by endtime desc");
        }

        public DataTable SelectLastPack(string MemloginId)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select top 1 starttime,endtime,publishednum,leavenum,limtactivitynum from ShopNum1_Limt_Package where memloginid='" +
                    MemloginId + "' order by endtime desc");
        }

        public DataTable SelectLimtPackage(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Limt_Package";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "starttime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }
    }
}