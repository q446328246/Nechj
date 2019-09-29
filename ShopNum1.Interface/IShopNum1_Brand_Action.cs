using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Brand_Action
    {
        int Add(ShopNum1_Brand brand);
        DataTable CheckBrand(string strBrand);
        int Delete(string guids);
        DataTable GetBrandCategory(string showCount);
        DataTable GetBrandImgByCode(string showCount, string code);
        DataTable GetBrandMeto(string guid);
        DataTable GetEditInfo(string guid);
        DataTable GetProductBrand(string code);
        DataTable GetProductBrandBycount(string code, string ShowCountTwo);
        DataTable GetProductCategoryCode(string fatherID);
        DataTable Search(int isDeleted);
        DataTable SearchBrand(string pagesize);
        DataTable SearchProductByBrandGuid(string brandGuid, string field, string order);
        DataTable Select_Brand_Import(string strTypeId);
        DataTable SelectBrandFlagStore(string pagesize, string code);
        int Update(string guid, ShopNum1_Brand brand);
    }
}