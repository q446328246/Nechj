using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Activity_Action
    {
        int AddActivity(ShopNum1_Product_Activity ShopNum1_Activity);
        int AddThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity);
        int AddThemeProduct(ShopNum1_ThemeActivityProduct shopNum1_ThemeActivityProduct);
        int CloseActivity(string strId);
        int DeleteActivity(string strId);
        int DeleteThemeActivty(string guid);
        int DeleteThemeActivtyProduct(string Guid);
        DataTable GetActivityById(string strMemloginId, string strLid);
        DataTable GetGroupActivityById(string string_0);
        DataTable GetProductActivity();
        DataTable GetThemeActivty();
        DataTable GetThemeActivtyByGuid(string Guid);
        DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum);
        DataTable SelectProductByThemeGuid(string themeGuid);
        DataTable SelectShopThemeActivty(string pagesize, string currentpage, string condition, string resultnum);
        DataTable SelectThemeActivty(string pagesize, string currentpage, string condition, string resultnum);
        DataTable SelectThemeActivtyProduct(string pagesize, string currentpage, string condition, string resultnum);
        DataTable SelectThemeProductByGuid(string pagesize, string currentpage, string condition, string resultnum);
        int UpdateActivity(ShopNum1_Product_Activity ShopNum1_Activity);
        int UpdateActivityState(string strId, string strState);
        int UpdateThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity);
        int UpdateThemeProductByThemeGuid(string ThemeGuid, string IsAudit);
        int UpdateThemeProductIsAudit(string Guid, string IsAudit);
    }
}