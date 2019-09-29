using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Reputation_Action : IShopNum1_Reputation_Action
    {
        public DataTable ShopReputationSearch(string shopReputation, string isdeleted, string type)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopReputation";
            paraValue[0] = shopReputation;
            paraName[1] = "@isdeleted";
            paraValue[1] = isdeleted;
            paraName[2] = "@type";
            paraValue[2] = type;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopReputationSearch", paraName, paraValue);
        }
    }
}