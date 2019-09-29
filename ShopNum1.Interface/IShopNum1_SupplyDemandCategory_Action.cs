using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SupplyDemandCategory_Action
    {
        int Add(ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory);
        DataTable GetSupplyCategoryByID(string ID);
        DataTable SearchtSupplyDemandCategory(int fatherID, int isDeleted);
        int Update(string guid, ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory);
    }
}