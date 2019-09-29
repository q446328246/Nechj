using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberRank_Action : IShopNum1_MemberRank_Action
    {
        public int Add(ShopNum1_MemberRank memberRank)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (memberRank.IsDefault == 1)
            {
                item = "UPDATE ShopNum1_MemberRank SET IsDefault=0 WHERE IsDefault=1";
                sqlList.Add(item);
            }
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MemberRank( \tGuid, \tName,    minScore ,   maxScore ,   IsDefault ,   Pic ,\tMemo, \tCreateUser, \tCreateTime\t, \tModifyUser , \tModifyTime\t, \tIsDeleted  ) VALUES (  '"
                , memberRank.Guid, "',  '", Operator.FilterString(memberRank.Name), "',  ", memberRank.minScore,
                ",  ", memberRank.maxScore, ",  ", memberRank.IsDefault, ",  '", memberRank.Pic, "',  '",
                Operator.FilterString(memberRank.Memo), "',  '", memberRank.CreateUser,
                "', '", memberRank.CreateTime, "',  '", memberRank.ModifyUser, "' , '", memberRank.ModifyTime,
                "',  ", memberRank.IsDeleted, ")"
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

        public DataTable Check(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            string strSql = string.Empty;
            strSql =
                strSql =
                    "select *   from ShopNum1_Member,   ShopNum1_MemberRank   where ShopNum1_Member.MemberRankGuid=@guid";
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int Delete(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  COUNT(*) AS NUM FROM ShopNum1_MemberRank WHERE IsDefault=1 AND Guid"+andSql,parms.ToArray());
            if (((table != null) && (table.Rows.Count > 0)) && (table.Rows[0]["NUM"].ToString() != "0"))
            {
                return -1;
            }
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MemberRank  WHERE  Guid"+andSql,parms.ToArray());
        }

        public DataTable Search(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tGuid, \tName,    minScore,   maxScore,\tDiscount, \tIsDefault,    Pic ,\tMemo, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_MemberRank   WHERE IsDeleted =@isDeleted Order By minScore",parms);
        }

        public DataTable DailyMoney()
        {
           

            
            return
                DatabaseExcetue.ReturnDataTable("SELECT * from ShopNum1_DailyMoney order by createdate desc");
        }

        public DataTable NewDailyMoney()
        {



            return
                DatabaseExcetue.ReturnDataTable("SELECT * from NewShopNum1_DailyMoney order by createdate desc");
        }


        
        public DataTable DailyMoneyByTime(string StratTime,string LastTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@StratTime";
            parms[0].Value = StratTime;
            parms[1].ParameterName = "@LastTime";
            parms[1].Value = LastTime;

            return
                DatabaseExcetue.ReturnDataTable("SELECT * from ShopNum1_DailyMoney where createdate>@StratTime and  createdate<@LastTime order by  createdate desc", parms);
        }
        public DataTable NewDailyMoneyByTime(string StratTime, string LastTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@StratTime";
            parms[0].Value = StratTime;
            parms[1].ParameterName = "@LastTime";
            parms[1].Value = LastTime;

            return
                DatabaseExcetue.ReturnDataTable("SELECT * from NewShopNum1_DailyMoney where createdate>@StratTime and  createdate<@LastTime order by  createdate desc", parms);
        }


        public DataTable Search(string guid, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "SELECT \tGuid,\tName,   minScore ,   maxScore ,\tDiscount ,\tIsDefault ,   Pic ,\tMemo ,\tCreateUser ,\tCreateTime ,\tModifyUser ,\tModifyTime ,\tIsDeleted   FROM ShopNum1_MemberRank   WHERE 0=0 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted =@isDeleted"});
            }
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND Guid =@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }
        public DataTable SearchMJC(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT [membership_Level]  FROM [ShopNum1_Member]   WHERE 0=0 and [MemLoginID]=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchMJC_PersonCate(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT [PersonCate]  FROM [ShopNum1_Member]   WHERE 0=0 and [MemLoginID]=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable Search(string memberrank, string isdeleted)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memberrank";
            paraValue[0] = memberrank;
            paraName[1] = "@isdeleted";
            paraValue[1] = isdeleted;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberRankSearch", paraName, paraValue);
        }

        public string SearchDiscountByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            
            string strSql = string.Empty;
            strSql = "SELECT \tGuid, \tDiscount   FROM ShopNum1_MemberRank  where 1=1";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + "And Guid=@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][1].ToString();
        }

        public DataTable SearchGuidName(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tGuid, \tName, \tIsDeleted   FROM ShopNum1_MemberRank   WHERE   IsDeleted =@isDeleted");
        }

        public DataTable SearchGuidNameDiscount()
        {

            string strSql = string.Empty;
            strSql = "SELECT \tGuid, \tName, \tDiscount   FROM ShopNum1_MemberRank   WHERE   IsDeleted = 0  ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public string SearchNameByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            string strSql = string.Empty;
            strSql = "SELECT \tGuid, \tName   FROM ShopNum1_Member  where 1=1";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + "And Guid=@guid";
            }
            try
            {
                return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][1].ToString();
            }
            catch
            {
                return "会员等级异常!";
            }
        }

        public int Update(ShopNum1_MemberRank memberRank)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (memberRank.IsDefault == 1)
            {
                item = "UPDATE ShopNum1_MemberRank SET IsDefault=0 WHERE IsDefault=1";
                sqlList.Add(item);
            }
            item = string.Concat(new object[]
            {
                "UPDATE ShopNum1_MemberRank SET  Name='", Operator.FilterString(memberRank.Name), "', minScore=",
                Operator.FilterString(memberRank.minScore), ", maxScore=",
                Operator.FilterString(memberRank.maxScore), ", IsDefault=",
                Operator.FilterString(memberRank.IsDefault), ", Pic='", memberRank.Pic, "', Memo='",
                Operator.FilterString(memberRank.Memo), "', ModifyUser='", memberRank.ModifyUser, "', ModifyTime='",
                memberRank.ModifyTime,
                "' WHERE Guid='", memberRank.Guid, "'"
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

        public DataTable GetDefaultMemberRank()
        {
            string strSql = string.Empty;
            strSql = "SELECT  *    FROM    ShopNum1_MemberRank      WHERE    IsDefault=1   ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int GetMaxScore()
        {
            return DatabaseExcetue.ReturnMaxID("maxScore", "ShopNum1_MemberRank");
        }

        public DataTable SearchNameByScore(int Score)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Score";
            parms[0].Value = Score;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT  *    FROM   ShopNum1_MemberRank      WHERE   IsDeleted = 0    AND    minScore  <=@Score   AND   maxScore  >=@Score"
                    }),parms);
        }
    }
}