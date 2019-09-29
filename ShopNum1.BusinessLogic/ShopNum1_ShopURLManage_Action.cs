using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopURLManage_Action : IShopNum1_ShopURLManage_Action
    {
        public int Add(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_ShopURLManage(DoMain,");
            builder.Append("SiteNumber,");
            builder.Append("MemLoginID,");
            builder.Append("GoUrl)");
            builder.Append("VALUES('" + Operator.FilterString(shopNum1_ShopURLManage.DoMain) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ShopURLManage.SiteNumber) + "',");
            builder.Append("'" + shopNum1_ShopURLManage.MemLoginID + "',");
            builder.Append("'" + shopNum1_ShopURLManage.GoUrl + "')");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable CheckDoMain(string strDoMain)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strDoMain";
            parms[0].Value = strDoMain;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE DoMain = @strDoMain");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int Delete(string strID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_ShopURLManage WHERE ID in (@strID)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public DataTable GetEditInfo(string strID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE ID = @strID" );
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetShopLoginID(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_Member WHERE Guid = @guids");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetShopValidity(string shopid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@shopid";
            parms[0].Value = shopid;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_Member WHERE MemLoginID = @shopid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable Search(string shopLoginId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@shopLoginId";
            parms[0].Value = shopLoginId;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE 0=0");
            if (Operator.FormatToEmpty(shopLoginId) != string.Empty)
            {
                builder.Append(" AND  Title like '%@shopLoginId%'");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable Search(string MemLoginID, string isAudit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE 0=0");
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND  MemLoginID = @MemLoginID");
            }
            if (isAudit != "-1")
            {
                if (isAudit == "-2")
                {
                    builder.Append(" AND  IsAudit IN (0,2) ");
                }
                else
                {
                    builder.Append(" AND  IsAudit = @isAudit" );
                }
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByID(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE 0=0");
            if (Operator.FormatToEmpty(string_0) != string.Empty)
            {
                builder.Append(" AND  ID in(@string_0)");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SelectGoUrl(string domain)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@domain";
            parms[0].Value = domain;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE DoMain = @domain AND IsAudit=1");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int Update(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_ShopURLManage SET DoMain = '" + shopNum1_ShopURLManage.DoMain + "',");
            builder.Append("GoUrl = '" + shopNum1_ShopURLManage.GoUrl + "'");
            builder.Append("GoUrl = '" + shopNum1_ShopURLManage.SiteNumber + "'");
            builder.Append(" WHERE Title = '" + shopNum1_ShopURLManage.Title + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Update(string strID, string strDoMain, string siteNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            parms[1].ParameterName = "@strDoMain";
            parms[1].Value = Operator.FilterString(strDoMain);
            parms[2].ParameterName = "@siteNumber";
            parms[2].Value = Operator.FilterString(siteNumber);
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_ShopURLManage SET DoMain = @strDoMain,");
            builder.Append(" IsAudit = 0,");
            builder.Append(" SiteNumber = @siteNumber");
            builder.Append(" WHERE ID = @strID" );
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public int UpdateIsAudit(string strID, string isAudit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_ShopURLManage SET ");
            builder.Append("IsAudit = " + isAudit);
            builder.Append(" WHERE ID IN (" + strID + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable UpdateSearch(string agentID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@agentID";
            parms[0].Value = agentID;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE Title = @agentID");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable UrlWriteShopDoMain(string domain)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@domain";
            paraValue[0] = domain;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShopDoMain", paraName, paraValue);
        }

        public int Operate(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE Title = '" + shopNum1_ShopURLManage.Title + "'");
            if (DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows.Count > 0)
            {
                return Update(shopNum1_ShopURLManage);
            }
            return Add(shopNum1_ShopURLManage);
        }
    }
}