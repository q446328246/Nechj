﻿using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_SiteMap_Action : IShopNum1_SiteMap_Action
    {
        public string Search(string table, string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string strSql = string.Empty;
            strSql = "SELECT Guid,Name  FROM " + table + " WHERE 0=0";
            guid = guid.Replace("'", "");
            if (Operator.FormatToEmpty(guid) != "-1")
            {
                strSql = strSql + " AND  Guid=@guid";
            }
            if (DatabaseExcetue.ReturnDataTable(strSql,parms).Rows.Count > 0)
            {
                return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0]["Name"].ToString();
            }
            return "-1";
        }

        public string SearchNameByID(string table, string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable("SELECT ID,Name  FROM " + table + " WHERE ID=@string_0" ,parms).Rows[0][
                    "Name"].ToString();
        }

        public string SearchOrganizBuyInfoName(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string str2 =
                DatabaseExcetue.ReturnDataTable("SELECT Guid,ProductGuid FROM ShopNum1_OrganizBuyInfo WHERE Guid=@guid",parms).Rows[0]["ProductGuid"].ToString();
            return
                DatabaseExcetue.ReturnDataTable("SELECT Guid,Name From ShopNum1_Product  WHERE guid='" + str2 + "'")
                    .Rows[0]["Name"].ToString();
        }

        public string SearchTitle(string table, string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");

            string strSql = string.Empty;
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = "SELECT Guid,Title  FROM " + table + " WHERE Guid=@guid";
            }
            if (DatabaseExcetue.ReturnDataTable(strSql,parms).Rows.Count > 0)
            {
                return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0]["Title"].ToString();
            }
            return "-1";
        }
    }
}