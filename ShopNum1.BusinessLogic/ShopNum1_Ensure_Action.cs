using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Ensure_Action : IShopNum1_Ensure_Action
    {
        public DataTable GetShopapplyEnsure(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopApplyEnsure", paraName, paraValue);
        }
    }
}