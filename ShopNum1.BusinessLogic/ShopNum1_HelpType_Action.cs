﻿using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_HelpType_Action : IShopNum1_HelpType_Action
    {
        public int Add(ShopNum1_HelpType shopNum1_HelpType)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_HelpType( Guid, Name, Remark, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime  ) VALUES (  '"
                        , shopNum1_HelpType.Guid, "',  '", Operator.FilterString(shopNum1_HelpType.Name), "',  '",
                        Operator.FilterString(shopNum1_HelpType.Remark), "',  ", shopNum1_HelpType.OrderID, ",  '",
                        shopNum1_HelpType.CreateUser, "',getdate(),  '", shopNum1_HelpType.ModifyUser,
                        "', getdate())"
                    }));
        }

        public int Delete(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "Delete FROM ShopNum1_Help Where HelpTypeGuid in (" + guids + ")";
            sqlList.Add(item);
            item = "Delete FROM ShopNum1_HelpType Where Guid in (" + guids + ")";
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

        public DataTable GetEditInfo(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
           
            return
                DatabaseExcetue.ReturnDataTable("SELECT  Name, Remark, OrderID FROM ShopNum1_HelpType Where Guid=@guid",parms);
        }

        public DataTable GetList()
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[Guid],");
            builder.Append("[Name]");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_HelpType");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable Search(string name)
        {
            string str = string.Empty;
            str =
                "SELECT Guid, Name, Remark, OrderID,  CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_HelpType Where ";
            str = str + " IsDeleted = 0";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order By OrderID Desc");
        }

        public DataTable Search(string IsDeleted, int showCount)
        {
            string strProcedureName = "[dbo].[Pro_ShopNum1_GetHelpType]";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showCount";
            paraValue[0] = showCount.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
        }

        public int update(ShopNum1_HelpType shopNum1_HelpType)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_HelpType SET  Name='", Operator.FilterString(shopNum1_HelpType.Name),
                        "', Remark='", Operator.FilterString(shopNum1_HelpType.Remark), "', OrderID='",
                        shopNum1_HelpType.OrderID, "', ModifyUser='", shopNum1_HelpType.ModifyUser,
                        "', ModifyTime=getdate() WHERE Guid='", shopNum1_HelpType.Guid, "'"
                    }));
        }
    }
}