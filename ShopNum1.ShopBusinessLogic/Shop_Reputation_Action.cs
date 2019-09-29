using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Reputation_Action : IShop_Reputation_Action
    {
        public int Add(ShopNum1_ShopReputation Shop_Reputation)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ShopReputation( \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted  ) VALUES (  '"
                , Shop_Reputation.Guid, "',  '", Operator.FilterString(Shop_Reputation.Name), "',  ",
                Shop_Reputation.minScore, ",  ", Shop_Reputation.maxScore, ",  '", Shop_Reputation.Pic, "',  '",
                Operator.FilterString(Shop_Reputation.Memo), "',  ", Shop_Reputation.Type, ", '",
                Shop_Reputation.CreateUser,
                "', '", Shop_Reputation.CreateTime, "',  '", Shop_Reputation.ModifyUser, "' , '",
                Shop_Reputation.ModifyTime, "',  ", Shop_Reputation.IsDeleted, ")"
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

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopReputation  WHERE  Guid IN(" + guids + ")");
        }

        public DataTable Search(int isDeleted)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopReputation   WHERE IsDeleted = " +
                    isDeleted + " Order By CreateTime Desc");
        }

        public DataTable Search(string type)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopReputation   WHERE IsDeleted = 0 ";
            if (type != "-1")
            {
                str = str + " And Type=" + type;
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order By minScore");
        }

        public DataTable Search(string guid, int isDeleted)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopReputation   WHERE 0=0 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted = ", isDeleted, " "});
            }
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND Guid = " + guid + " ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable ShopReputationSearch(string shopReputation, string isdeleted, string type)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopReputation";
            paraValue[0] = shopReputation;
            paraName[1] = "@isdeleted";
            paraValue[1] = isdeleted;
            paraName[2] = "@type";
            paraValue[2] = type;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopReputationSearch", paraName, paraValue);
        }

        public int Update(ShopNum1_ShopReputation Shop_Reputation)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "UPDATE ShopNum1_ShopReputation SET  Name='", Operator.FilterString(Shop_Reputation.Name),
                "', minScore=", Operator.FilterString(Shop_Reputation.minScore), ", maxScore=",
                Operator.FilterString(Shop_Reputation.maxScore), ", Pic='", Shop_Reputation.Pic, "', Memo='",
                Operator.FilterString(Shop_Reputation.Memo), "', Type=", Shop_Reputation.Type, ", ModifyUser='",
                Shop_Reputation.ModifyUser, "', ModifyTime='", Shop_Reputation.ModifyTime,
                "' WHERE Guid='", Shop_Reputation.Guid, "'"
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

        public int GetMaxScore()
        {
            return DatabaseExcetue.ReturnMaxID("maxScore", "ShopNum1_ShopReputation");
        }
    }
}