using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ScoreModifyLog_Action : IShopNum1_ScoreModifyLog_Action
    {
        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            
            return DatabaseExcetue.RunNonQuery("  delete ShopNum1_ScoreModifyLog  where Guid=@guids",parms);
        }

        public DataTable GetMemLoginNOBYMemLoginID(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("   select MemLoginNO from  ShopNum1_Member  where  IsDeleted=0  and MemLoginID =@MemLoginID", parms);
        }

        public DataTable SelectMberGUID(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            return
                DatabaseExcetue.ReturnDataTable("   select MemberRankGuid from  ShopNum1_Member  where  IsDeleted=0  and MemLoginNO =@MemLoginNO", parms);
        }

        public DataTable GetDataInfo(int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@IsDeleted";
            parms[0].Value = IsDeleted;
            return
                DatabaseExcetue.ReturnDataTable("   select * from  ShopNum1_ScoreModifyLog  where  IsDeleted=@IsDeleted  ORDER BY CreateTime DESC   ", parms);
        }

        public DataTable GetDataInfo(int IsDeleted, string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@IsDeleted";
            parms[0].Value = IsDeleted;
            parms[1].ParameterName = "@MemLoginID";
            parms[1].Value = MemLoginID;
            string str = string.Empty;
            str = "   select * from  ShopNum1_ScoreModifyLog  where  IsDeleted=@IsDeleted";
            if (!string.IsNullOrEmpty(MemLoginID))
            {
                str = str + "   and  MemLoginID=@MemLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(str + "   ORDER BY CreateTime DESC    ",parms);
        }

        public DataTable GetDataInfoAdmin(string MemLoginID, int OperateType, string startTime, string endTime,
            int IsDeleted)
        {
            string str = string.Empty;
            str = "   select * from  ShopNum1_ScoreModifyLog  where  IsDeleted='" + IsDeleted + "'   ";
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
            return DatabaseExcetue.ReturnDataTable(str + "   order  by CreateTime desc     ");
        }

        public DataTable GetShopDataInfoByMemLoginID(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            
            return
                DatabaseExcetue.ReturnDataTable("   select * from   ShopNum1_ShopInfo     where  MemLoginID=@MemLoginID",parms);
        }

        public int OperateScore(ShopNum1_ScoreModifyLog scoreModeLog)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ScoreModifyLog( \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '"
                , scoreModeLog.Guid, "',  ", scoreModeLog.OperateType, ",  ", scoreModeLog.CurrentScore, ",  ",
                scoreModeLog.OperateScore, ",  ", scoreModeLog.LastOperateScore, ",  '", scoreModeLog.Date, "',  '",
                Operator.FilterString(scoreModeLog.Memo), "',  '", scoreModeLog.MemLoginID,
                "',  '", scoreModeLog.CreateUser, "', '", scoreModeLog.CreateTime, "',  ", scoreModeLog.IsDeleted,
                ")"
            }));
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
                "SELECT Guid, OperateType\t,CurrentScore, OperateScore, LastOperateScore, Date, Memo, MemLoginID\t, CreateUser, CreateTime, IsDeleted   FROM ShopNum1_ScoreModifyLog   WHERE 0=0 ";
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
                "SELECT \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted   FROM ShopNum1_ScoreModifyLog   WHERE 0=0 ";
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
                "Guid, OperateType,CurrentScore,OperateScore,LastOperateScore,Date,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ScoreModifyLog";
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


        public DataTable Select_Order_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "OrderNumber, MemLoginID,ShouldPayPrice,Score_pv_b,Score_pv_a,PayTime,Deduction_hv ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_OrderInfo";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "PayTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_free", paraName, paraValue);
        }

        public DataTable Select_GPS_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "Device_no,CreateTime, (Mileage*0.1) as Mil,(case when CarType=1 then '新能源汽车' when CarType=2 then '燃油汽车' else '未知' end) as CarTypeName,GetMoney ";
            paraName[3] = "@tablename";
            paraValue[3] = "GPS_TotalMileage";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_free", paraName, paraValue);
        }


        public DataTable Select_TJLB_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "MemLoginID,RealName,RegeDate,Mobile ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Member";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "RegeDate";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_free", paraName, paraValue);
        }
    }
}