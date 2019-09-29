using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_UserDefinedColumn_Action : IShopNum1_UserDefinedColumn_Action
    {
        public int Delete(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_UserDefinedColumn WHERE [Guid] in (@guid)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public DataTable GetButtomNavigation(string showCount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(" TOP  " + showCount);
            builder.Append(" Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfShow,");
            builder.Append("IfOpen,");
            builder.Append("Remark,");
            builder.Append("OrderID,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append(" ShowLocation='1' AND IfShow=1 ");
            builder.Append(" ORDER BY OrderID  ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetEditInfo(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfShow,");
            builder.Append("IfOpen,");
            builder.Append("IsShop,");
            builder.Append("IsMember,");
            builder.Append("IsSite,");
            builder.Append("Remark,");
            builder.Append("OrderID,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append("Guid = @guid" );
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetTopNavigation(string showCount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(" TOP  " + showCount);
            builder.Append(" Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfOpen,");
            builder.Append("Remark,");
            builder.Append("OrderID");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append(" ShowLocation='2' AND IfShow=1");
            builder.Append(" ORDER BY OrderID  ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Insert(ShopNum1_UserDefinedColumn shopNum1_UserDefinedColumn)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_UserDefinedColumn(");
            builder.Append("Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfOpen,");
            builder.Append("IfShow,");
            builder.Append("Remark,");
            builder.Append("OrderID,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShop,");
            builder.Append("IsMember,");
            builder.Append("IsSite)");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_UserDefinedColumn.Guid + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_UserDefinedColumn.Name) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_UserDefinedColumn.LinkAddress) + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.ShowLocation + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.IfOpen + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.IfShow + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_UserDefinedColumn.Remark) + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.OrderID + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.CreateUser + "',");
            builder.Append("getdate(),");
            builder.Append("'" + shopNum1_UserDefinedColumn.ModifyUser + "',");
            builder.Append("getdate(),");
            builder.Append("'" + shopNum1_UserDefinedColumn.IsShop + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.IsMember + "',");
            builder.Append("'" + shopNum1_UserDefinedColumn.IsSite + "')");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search(string Name)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfShow,");
            builder.Append("IsMember,");
            builder.Append("IsShop,");
            builder.Append("IfOpen,");
            builder.Append("Remark,");
            builder.Append("OrderID,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append(" IsDeleted = 0");
            builder.Append(" ORDER BY OrderID DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchMiddleNavigation(string showCount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(" TOP  " + showCount);
            builder.Append(" Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfShow,");
            builder.Append("IfOpen,");
            builder.Append("Remark,");
            builder.Append("OrderID,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append(" ShowLocation='0' AND IfShow=1");
            builder.Append(" ORDER BY OrderID  ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchMiddleNavigation(string showCount, int type)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(" TOP  " + showCount);
            builder.Append(" Guid,");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("ShowLocation,");
            builder.Append("IfShow,");
            builder.Append("IfOpen,");
            builder.Append("Remark,");
            builder.Append("OrderID");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append(" ShowLocation='0' AND IfShow=1");
            switch (type)
            {
                case 1:
                    builder.Append(" AND IsSite=1");
                    break;

                case 2:
                    builder.Append(" AND IsMember=1");
                    break;

                case 3:
                    builder.Append(" AND IsShop=1");
                    break;
            }
            builder.Append(" ORDER BY OrderID  ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Update(ShopNum1_UserDefinedColumn shopNum1_UserDefinedColumn)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_UserDefinedColumn");
            builder.Append(" SET ");
            builder.Append("Name = '" + Operator.FilterString(shopNum1_UserDefinedColumn.Name) + "',");
            builder.Append("LinkAddress = '" + Operator.FilterString(shopNum1_UserDefinedColumn.LinkAddress) + "',");
            builder.Append("ShowLocation = '" + shopNum1_UserDefinedColumn.ShowLocation + "',");
            builder.Append("IfShow = '" + shopNum1_UserDefinedColumn.IfShow + "',");
            builder.Append("IfOpen = '" + shopNum1_UserDefinedColumn.IfOpen + "',");
            builder.Append("IsShop = '" + shopNum1_UserDefinedColumn.IsShop + "',");
            builder.Append("IsMember = '" + shopNum1_UserDefinedColumn.IsMember + "',");
            builder.Append("IsSite = '" + shopNum1_UserDefinedColumn.IsSite + "',");
            builder.Append("Remark = '" + Operator.FilterString(shopNum1_UserDefinedColumn.Remark) + "',");
            builder.Append("OrderID = '" + shopNum1_UserDefinedColumn.OrderID + "',");
            builder.Append("ModifyUser = '" + shopNum1_UserDefinedColumn.ModifyUser + "',");
            builder.Append("ModifyTime = getdate()");
            builder.Append(" WHERE ");
            builder.Append("Guid = '" + shopNum1_UserDefinedColumn.Guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}