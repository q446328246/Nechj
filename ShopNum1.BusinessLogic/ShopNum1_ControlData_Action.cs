using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ControlData_Action : IShopNum1_ControlData_Action
    {
        public int Delete(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_ControlData WHERE [Guid] in (" + guid + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable GetControlDataList(string controlGuid, string groupID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@controlGuid";
            parms[0].Value = controlGuid;
            parms[1].ParameterName = "@groupID";
            parms[1].Value = groupID;
            return
                DatabaseExcetue.ReturnDataTable("Select * from ShopNum1_ControlData where ControlGuid=@controlGuid AND  GroupID=@groupID AND IsShow =1 order by OrderID asc",parms);
        }

        public DataTable GetEditInfo(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("Href,");
            builder.Append("Image,");
            builder.Append("Price,");
            builder.Append("OrderID,");
            builder.Append("GroupID,");
            builder.Append("DataType,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShow,");
            builder.Append("ControlGuid");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_ControlData");
            builder.Append(" WHERE ");
            builder.Append("Guid = " + guid);
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Insert(ShopNum1_ControlData shopNum1_ControlData)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_ControlData(");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("Href,");
            builder.Append("Image,");
            builder.Append("Price,");
            builder.Append("OrderID,");
            builder.Append("GroupID,");
            builder.Append("DataType,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShow,");
            builder.Append("ControlGuid)");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_ControlData.Guid + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.Title) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.Href) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.Image) + "',");
            builder.Append(Operator.FilterString(shopNum1_ControlData.Price) + ",");
            builder.Append(Operator.FilterString(shopNum1_ControlData.OrderID) + ",");
            builder.Append(Operator.FilterString(shopNum1_ControlData.GroupID) + ",");
            builder.Append(Operator.FilterString(shopNum1_ControlData.DataType) + ",");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.CreateUser) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.CreateTime) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.ModifyUser) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.ModifyTime) + "',");
            builder.Append(Operator.FilterString(shopNum1_ControlData.IsShow) + ",");
            builder.Append("'" + Operator.FilterString(shopNum1_ControlData.ControlGuid) + "'");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("Href,");
            builder.Append("Image,");
            builder.Append("Price,");
            builder.Append("OrderID,");
            builder.Append("GroupID,");
            builder.Append("DataType,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShow,");
            builder.Append("ControlGuid");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_ControlData");
            builder.Append(" WHERE ");
            builder.Append(" ControlGuid = '" + Operator.FilterString(guid) + "'");
            builder.Append(" ORDER BY OrderID DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Update(ShopNum1_ControlData shopNum1_ControlData)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_ControlData");
            builder.Append(" SET ");
            builder.Append("Title = '" + Operator.FilterString(shopNum1_ControlData.Title) + "',");
            builder.Append("Href = '" + Operator.FilterString(shopNum1_ControlData.Href) + "',");
            builder.Append("Image = '" + Operator.FilterString(shopNum1_ControlData.Image) + "',");
            builder.Append("Price = " + Operator.FilterString(shopNum1_ControlData.Price) + ",");
            builder.Append("OrderID = " + Operator.FilterString(shopNum1_ControlData.OrderID) + ",");
            builder.Append("GroupID = " + Operator.FilterString(shopNum1_ControlData.GroupID) + ",");
            builder.Append("DataType = " + Operator.FilterString(shopNum1_ControlData.DataType) + ",");
            builder.Append("ModifyUser = '" + shopNum1_ControlData.ModifyUser + "',");
            builder.Append("IsShow = " + Operator.FilterString(shopNum1_ControlData.IsShow) + ",");
            builder.Append("ModifyTime = '" + Operator.FilterString(shopNum1_ControlData.ModifyTime) + "'");
            builder.Append(" WHERE ");
            builder.Append("Guid = '" + shopNum1_ControlData.Guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}