using System;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_WebSite_Action : IShopNum1_WebSite_Action
    {
        public bool CheckAddressName(string addressname)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@addressname";
            paraValue[0] = addressname;
            object obj2 = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_WebSiteCheckAddressName", paraName,
                paraValue);
            if ((obj2 == null) || (Convert.ToInt32(obj2) < 1))
            {
                return false;
            }
            return true;
        }

        public int DeleteById(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_WebSite  WHERE ID IN (@string_0) ",parms);
        }

        public DataTable GetAllSite()
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_WebSiteGet");
        }

        public object GetDomainByAddressName(string address)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@addressname";
            paraValue[0] = address;
            return DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_WebSiteGetDomainByAddress", paraName, paraValue);
        }

        public DataTable GetSiteByID(string ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            string strSql = string.Empty;
            if (ID == "0")
            {
                strSql = "SELECT * FROM dbo.ShopNum1_WebSite ";
            }
            else
            {
                strSql = "SELECT *FROM dbo.ShopNum1_WebSite WHERE ID=@ID" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public bool Insert(ShopNum1_WebSite website)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@addressName";
            paraValue[0] = website.addressName;
            paraName[1] = "@addressCode";
            paraValue[1] = website.addressCode;
            paraName[2] = "@domain";
            paraValue[2] = website.domain;
            paraName[3] = "@isAvailable";
            paraValue[3] = website.isAvailable.ToString();
            return (DatabaseExcetue.RunProcedure("[Pro_ShopNum1_WebSiteInsert]", paraName, paraValue) > 0);
        }

        public bool Update(ShopNum1_WebSite website)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@id";
            paraValue[0] = website.ID.ToString();
            paraName[1] = "@addressname";
            paraValue[1] = website.addressName;
            paraName[2] = "@addresscode";
            paraValue[2] = website.addressCode;
            paraName[3] = "@domain";
            paraValue[3] = website.domain;
            paraName[4] = "@isavailable";
            paraValue[4] = website.isAvailable.ToString();
            return (DatabaseExcetue.RunProcedure("[Pro_ShopNum1_WebSiteUpdate]", paraName, paraValue) > 0);
        }

        public DataTable GetList(string categoryID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@categoryID";
            parms[0].Value = categoryID;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[ID],");
            builder.Append("[Name],");
            builder.Append("[code]");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Region");
            builder.Append(" WHERE FatherID=@categoryID");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable WebSiteGet(string addressCode)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@addressCode";
            parms[0].Value = addressCode;
            string strSql = string.Empty;
            strSql = "SELECT * FROM dbo.ShopNum1_WebSite WHERE 0=0";
            if (addressCode.Trim() != "-1")
            {
                strSql = strSql + " AND addressCode=@addressCode";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }
    }
}