using System.Data;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Category_Action
    {
        DataTable GetRegionCode(string code);
        DataTable GetRegionFatherID(string fatherid);
        DataTable GetShopBrand(string memberloiid, string categoryid);
        DataTable GetShopCategoryCode(string code);
        DataTable GetShopCategoryFatherID(string fatherid);
    }
}