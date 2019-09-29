using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_NewsCategory_Action
    {
        int AddNewsCategory(ShopNum1_Shop_NewsCategory newsCategory);
        int DeleteNewsCategory(string guid);
        DataTable GetNewsCategory(string guid);
        DataTable GetNewsCategoryList(string memloginid, string isshow);
        int UpdateNewsCategory(ShopNum1_Shop_NewsCategory newsCategory);
    }
}