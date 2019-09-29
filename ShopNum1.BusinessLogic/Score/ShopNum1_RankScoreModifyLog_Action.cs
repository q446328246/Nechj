using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_RankScoreModifyLog_Action : IShopNum1_RankScoreModifyLog_Action
    {
        public string GetMemberRankGuidByCostMoney(decimal costMoney)
        {
            string strSql = string.Empty;
            string str2 = string.Empty;
            strSql =
                "SELECT \tGuid, \tName, \tScore, \tPayoutCount, \tPayoutMoney   FROM ShopNum1_MemberRank WHERE agentid is null and isagent=0 ORDER BY PayoutMoney ASC ";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (costMoney < Convert.ToDecimal(table.Rows[i]["PayoutMoney"]))
                {
                    if (i == 0)
                    {
                        return table.Rows[0]["Guid"].ToString();
                    }
                    return table.Rows[i - 1]["Guid"].ToString();
                }
                if (costMoney == Convert.ToDecimal(table.Rows[i]["PayoutMoney"]))
                {
                    return table.Rows[i]["Guid"].ToString();
                }
                if (costMoney > Convert.ToDecimal(table.Rows[i]["PayoutMoney"]))
                {
                    str2 = table.Rows[i]["Guid"].ToString();
                }
            }
            return str2;
        }

        public string GetMemberRankGuidByRankScore(int rankScore)
        {
            string strSql = string.Empty;
            string str2 = string.Empty;
            strSql =
                "SELECT \tGuid, \tName, \tScore, \tPayoutCount, \tPayoutMoney   FROM ShopNum1_MemberRank WHERE agentid is null and isagent=0 ORDER BY Score ASC ";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (rankScore < Convert.ToInt32(table.Rows[i]["Score"]))
                {
                    if (i == 0)
                    {
                        return table.Rows[0]["Guid"].ToString();
                    }
                    return table.Rows[i - 1]["Guid"].ToString();
                }
                if (rankScore == Convert.ToInt32(table.Rows[i]["Score"]))
                {
                    return table.Rows[i]["Guid"].ToString();
                }
                if (rankScore > Convert.ToInt32(table.Rows[i]["Score"]))
                {
                    str2 = table.Rows[i]["Guid"].ToString();
                }
            }
            return str2;
        }

        public string GetMemberRankGuidByTradeCount(int tradeCount)
        {
            string strSql = string.Empty;
            string str2 = string.Empty;
            strSql =
                "SELECT \tGuid, \tName, \tScore, \tPayoutCount, \tPayoutMoney   FROM ShopNum1_MemberRank ORDER BY PayoutCount ASC ";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (tradeCount < Convert.ToInt32(table.Rows[i]["PayoutCount"]))
                {
                    if (i == 0)
                    {
                        return table.Rows[0]["Guid"].ToString();
                    }
                    return table.Rows[i - 1]["Guid"].ToString();
                }
                if (tradeCount == Convert.ToInt32(table.Rows[i]["PayoutCount"]))
                {
                    return table.Rows[i]["Guid"].ToString();
                }
                if (tradeCount > Convert.ToInt32(table.Rows[i]["PayoutCount"]))
                {
                    str2 = table.Rows[i]["Guid"].ToString();
                }
            }
            return str2;
        }

        public int OperateScore(ShopNum1_RankScoreModifyLog rankScoreModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_RankScoreModifyLog( \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '"
                , rankScoreModifyLog.Guid, "',  ", rankScoreModifyLog.OperateType, ",  ",
                rankScoreModifyLog.CurrentScore, ",  ", rankScoreModifyLog.OperateScore, ",  ",
                rankScoreModifyLog.LastOperateScore, ",  '", rankScoreModifyLog.Date, "',  '",
                Operator.FilterString(rankScoreModifyLog.Memo), "',  '", rankScoreModifyLog.MemLoginID,
                "',  '", rankScoreModifyLog.CreateUser, "', '",
                Convert.ToDateTime(rankScoreModifyLog.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "',  ",
                rankScoreModifyLog.IsDeleted, ")"
            });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                DataTable table =
                    ((ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action()).SearchNameByScore(
                        Convert.ToInt32(rankScoreModifyLog.LastOperateScore));
                string str2 = "";
                if ((table != null) && (table.Rows.Count > 0))
                {
                    str2 = table.Rows[0]["Guid"].ToString();
                }
                if (!string.IsNullOrEmpty(str2))
                {
                    //ChangeMemberRankGuid(rankScoreModifyLog.MemLoginID, str2);
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable Search(string memLoginID, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            
            string str = string.Empty;
            str =
                "SELECT Guid, OperateType\t, CurrentScore, OperateScore, LastOperateScore, Date, Memo, MemLoginID\t, CreateUser, CreateTime, IsDeleted   FROM ShopNum1_RankScoreModifyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID =@memLoginID";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, "AND IsDeleted=@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc",parms);
        }

        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted   FROM ShopNum1_RankScoreModifyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID ='" + memLoginID + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, "AND IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc");
        }

        public int ChangeMemberRankGuid(string MemLoginID, string MemberRankGuid)
        {
            return 1;
                /*DatabaseExcetue.RunNonQuery("   UPDATE  ShopNum1_Member  SET  MemberRankGuid='" + MemberRankGuid +
                                            "'   WHERE   MemLoginID='" + MemLoginID + "'    ");*/
        }

        public DataTable GetDataInfoAdmin(string MemLoginID, int OperateType, string startTime, string endTime,
            int IsDeleted)
        {
            string str = string.Empty;
            str = "   select * from  ShopNum1_RankScoreModifyLog  where  IsDeleted='" + IsDeleted + "'   ";
            if (!string.IsNullOrEmpty(MemLoginID))
            {
                str = str + "   and  MemLoginID='" + MemLoginID + "'   ";
            }
            if (OperateType != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, "   and  OperateType='", OperateType, "'   "});
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                str = str + "   and  CreateTime >   '" + startTime + "'   ";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                str = str + "   and  CreateTime <   '" + endTime + "'   ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "   order  by  CreateTime   desc     ");
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                " Guid,OperateType,CurrentScore,OperateScore,LastOperateScore,Date,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_RankScoreModifyLog";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}