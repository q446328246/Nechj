using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OperateLog_Action : IShopNum1_OperateLog_Action
    {
        public int Add(ShopNum1_OperateLog shopNum1_operateLog)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_OperateLog(");
            builder.Append("[Guid],");
            builder.Append("Record,");
            builder.Append("OperatorID,");
            builder.Append("IP,");
            builder.Append("PageName,");
            builder.Append("Date)");
            builder.Append(" VALUES(");
            builder.Append("'" + Guid.NewGuid() + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_operateLog.Record) + "',");
            builder.Append("'" + shopNum1_operateLog.OperatorID + "',");
            builder.Append("'" + shopNum1_operateLog.IP + "',");
            builder.Append("'" + shopNum1_operateLog.PageName + "',");
            builder.Append("'" + shopNum1_operateLog.Date + "'");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_OperateLog WHERE [Guid] in (@guids)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public int DeleteAll(string startDate, string endDate)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@startDate";
            parms[0].Value = startDate;
            parms[1].ParameterName = "@endDate";
            parms[1].Value = endDate;
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_OperateLog WHERE Date >=@startDate AND Date<=@endDate");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public DataTable Search(string operatorID, string IP, string StartDate, string EndDate)
        {
            bool flag = true;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[Guid],");
            builder.Append("Record,");
            builder.Append("OperatorID,");
            builder.Append("IP,");
            builder.Append("PageName,");
            builder.Append("Date");
            builder.Append(" FROM ShopNum1_OperateLog");
            if ((operatorID != null) && (operatorID != ""))
            {
                builder.Append(" WHERE OperatorID = '" + Operator.FilterString(operatorID) + "'");
                flag = false;
            }
            if ((StartDate != null) && (StartDate != ""))
            {
                if (!flag)
                {
                    builder.Append(" AND");
                }
                else
                {
                    builder.Append(" WHERE");
                }
                builder.Append(" Date >= '" + StartDate + "'");
                flag = false;
            }
            if ((EndDate != null) && (EndDate != ""))
            {
                if (!flag)
                {
                    builder.Append(" AND");
                }
                else
                {
                    builder.Append(" WHERE");
                }
                builder.Append(" Date <= '" + EndDate + "'");
                flag = false;
            }
            if ((IP != null) && (IP != ""))
            {
                if (!flag)
                {
                    builder.Append(" AND");
                }
                else
                {
                    builder.Append(" WHERE");
                }
                builder.Append(" IP LIKE '%" + Operator.FilterString(IP) + "%'");
                flag = false;
            }
            builder.Append(" ORDER BY Date DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }
    }
}