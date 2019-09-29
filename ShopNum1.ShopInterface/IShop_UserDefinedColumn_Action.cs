using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_UserDefinedColumn_Action
    {
        int AddUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn);
        int DeleteUserDefinedColumn(string guid);
        DataTable GetButtomNavigation(string showCount);
        DataTable GetUserDefinedColumn(string guid);
        DataTable GetUserDefinedColumnList(string memloginid, string isshow);
        DataTable MetaGetUserDefinedColumn(string memloginid, string linkaddress);
        DataTable SearchUserDefinedColumnList(string ifshow, string showlocation);
        DataTable SelectNavigation_List(CommonPageModel commonModel);
        int UpdateUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn);
    }
}