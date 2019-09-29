using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Integral_Action : IShop_Integral_Action
    {
        public int AddIntegral(string memloginid, string score, string agentloginid, string isaudit)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@score";
            paraValue[1] = score;
            paraName[2] = "@agentloginid";
            paraValue[2] = agentloginid;
            paraName[3] = "@isaudit";
            paraValue[3] = isaudit;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddIntegral", paraName, paraValue);
        }
    }
}