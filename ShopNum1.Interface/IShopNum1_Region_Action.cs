using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Region_Action
    {
        int Add(ShopNum1_Region shopNum1_Region);
        DataTable GetRegionCategoryByID(string ID);
        DataTable SearchByCategoryLevel(string lever, string showcount);
        DataTable SearchtRegionCategory(int fatherID, int isDeleted);
        int Update(string guid, ShopNum1_Region shopNum1_RegionCategory);
    }
}