using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopCategory_Action
    {
        int Add(ShopNum1_ShopCategory shopNum1_ShopCategory);
        int Delete(string guids);
        DataTable GetList(string categoryID);
        DataTable GetShopCategoryByID(string ID);
        DataTable GetShopCategoryCount(string showcount);
        DataTable GetShopCategoryMeto(string string_0);
        DataTable GetShopCategoryName();
        DataTable GetWeiXinShopCategoryCount(string showcount);
        DataTable Search(int fatherID, int isDeleted, string showCount);
        DataTable SearchShopCategory(int fatherID, int isDeleted);
        int Update(string guid, ShopNum1_ShopCategory shopNum1_ShopCategory);
    }
}