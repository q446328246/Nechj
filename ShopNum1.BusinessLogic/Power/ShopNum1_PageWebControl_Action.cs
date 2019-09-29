using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_PageWebControl_Action : IShopNum1_PageWebControl_Action
    {
        public int Add(ShopNum1_PageWebControl pageWebControl)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_PageWebControl( Guid,  Name,  PageGuid,  ControlID,  ControlType,  Description, CreateUser, CreateTime,  ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , pageWebControl.Guid, "',  '", Operator.FilterString(pageWebControl.Name), "',  '",
                pageWebControl.PageGuid, "',  '", pageWebControl.ControlID, "',  '", pageWebControl.ControlType,
                "',  '", Operator.FilterString(pageWebControl.Description), "', '", pageWebControl.CreateUser,
                "',  '", pageWebControl.CreateTime,
                "',  '", pageWebControl.ModifyUser, "' , '", pageWebControl.ModifyTime, "',  ",
                pageWebControl.IsDeleted, ")"
            }));
        }

        public int Delete(string guids)
        {

            string item = string.Empty;
            var sqlList = new List<string>();
            item = "DELETE FROM ShopNum1_PageWebControl WHERE Guid IN (" + guids + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_GroupPageWebControl WHERE Guid IN (" + guids + ")";
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

        public DataTable Search(string pageGuid, string guid, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@pageGuid";
            parms[0].Value = Operator.FilterString(pageGuid);
            parms[1].ParameterName = "@guid";
            parms[1].Value = Operator.FilterString(guid);
            parms[2].ParameterName = "@isDeleted";
            parms[2].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "SELECT  Guid, \tName\t,\tPageGuid\t,\tControlID\t,\tControlType\t,\tDescription\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tIsDeleted FROM ShopNum1_PageWebControl  WHERE 0=0 ";
            if (Operator.FormatToEmpty(pageGuid) != string.Empty)
            {
                strSql = strSql + " AND PageGuid=@pageGuid";
            }
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND Guid=@guid";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int Update(ShopNum1_PageWebControl pageWebControl)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_PageWebControl SET  ControlType='", pageWebControl.ControlType,
                    "', ControlID='",
                    pageWebControl.ControlID, "', Name='", Operator.FilterString(pageWebControl.Name),
                    "', Description='", Operator.FilterString(pageWebControl.Description), "', ModifyUser='",
                    pageWebControl.ModifyUser, "', ModifyTime='", pageWebControl.ModifyTime, "' WHERE Guid='",
                    pageWebControl.Guid, "'"
                });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_GroupPageWebControl SET ControlType='", pageWebControl.ControlType,
                    "', ControlID='", pageWebControl.ControlID, "', ModifyUser='", pageWebControl.ModifyUser,
                    "', ModifyTime='", pageWebControl.ModifyTime, "' WHERE  PageWebControlGuid='",
                    pageWebControl.Guid, "'"
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
    }
}