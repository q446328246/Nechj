using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Integrals_Action : IShop_Integrals_Action
    {
        public int AddShopIntegral(ShopNum1_Shop_Integral shop_Integral)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@memloginid";
            paraValue[0] = shop_Integral.MemLoginID;
            paraName[1] = "@score";
            paraValue[1] = shop_Integral.Score.ToString();
            paraName[2] = "@agentloginid";
            paraValue[2] = shop_Integral.AgentLoginID;
            paraName[3] = "@isaudit";
            paraValue[3] = shop_Integral.IsAudit.ToString();
            paraName[4] = "@remark";
            paraValue[4] = shop_Integral.Remark;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddIntegral", paraName, paraValue);
        }

        public int DeleteIntegral(string guid, string isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteIntegral", paraName, paraValue);
        }

        public DataTable GetIntegralInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIntegralInfo", paraName, paraValue);
        }

        public DataTable GetIntegralList(string memloginid, string isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIntegralList", paraName, paraValue);
        }

        public DataTable SearchIntegralCostList(string shopid, string scorestate)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@scorestate";
            paraValue[1] = scorestate;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchIntegralCostList", paraName, paraValue);
        }
    }
}