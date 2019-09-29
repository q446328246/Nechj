using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_UserDefinedColumn_Action : IShop_UserDefinedColumn_Action
    {
        public int AddUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@guid";
            paraValue[0] = shop_UserDefinedColumn.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = shop_UserDefinedColumn.Name;
            paraName[2] = "@linkaddress";
            paraValue[2] = shop_UserDefinedColumn.LinkAddress;
            paraName[3] = "@isshow";
            paraValue[3] = shop_UserDefinedColumn.IsShow.ToString();
            paraName[4] = "@ifopen";
            paraValue[4] = shop_UserDefinedColumn.IfOpen.ToString();
            paraName[5] = "@orderid";
            paraValue[5] = shop_UserDefinedColumn.OrderID.ToString();
            paraName[6] = "@memloginid";
            paraValue[6] = shop_UserDefinedColumn.MemLoginID;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddUserDefinedColumn", paraName, paraValue);
        }

        public int DeleteUserDefinedColumn(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteUserDefinedColumn", paraName, paraValue);
        }

        public DataTable GetButtomNavigation(string showCount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(" TOP  " + showCount + " ");
            builder.Append("Name,");
            builder.Append("LinkAddress,");
            builder.Append("IfOpen ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_UserDefinedColumn");
            builder.Append(" WHERE ");
            builder.Append(" ShowLocation='1' AND IfShow=1 AND IsShop=1");
            builder.Append(" ORDER BY OrderID  ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetUserDefinedColumn(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetUserDefinedColumn", paraName, paraValue);
        }

        public DataTable GetUserDefinedColumnList(string memloginid, string isshow)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@isshow";
            paraValue[1] = isshow;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetUserDefinedColumnList", paraName, paraValue);
        }

        public DataTable MetaGetUserDefinedColumn(string memloginid, string linkaddress)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@linkaddress";
            paraValue[1] = linkaddress;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_MetaGetUserDefinedColumn", paraName, paraValue);
        }

        public DataTable SearchUserDefinedColumnList(string ifshow, string showlocation)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ifshow";
            paraValue[0] = ifshow;
            paraName[1] = "@showlocation";
            paraValue[1] = showlocation;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchUserDefinedColumnList", paraName,
                paraValue);
        }

        public DataTable SelectNavigation_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "OrderID";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int UpdateUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@guid";
            paraValue[0] = shop_UserDefinedColumn.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = shop_UserDefinedColumn.Name;
            paraName[2] = "@linkaddress";
            paraValue[2] = shop_UserDefinedColumn.LinkAddress;
            paraName[3] = "@isshow";
            paraValue[3] = shop_UserDefinedColumn.IsShow.ToString();
            paraName[4] = "@ifopen";
            paraValue[4] = shop_UserDefinedColumn.IfOpen.ToString();
            paraName[5] = "@orderid";
            paraValue[5] = shop_UserDefinedColumn.OrderID.ToString();
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateUserDefinedColumn", paraName, paraValue);
        }
    }
}