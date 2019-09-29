using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_VideoCategory_Action
    {
        int AddVideoCategory(ShopNum1_Shop_VideoCategory videoCategory);
        int DeleteVideoCategory(string guid);
        DataTable GetVideoCategory(string guid);
        DataTable GetVideoCategoryList(string memloginid, string isshow);
        int UpdateVideoCategory(ShopNum1_Shop_VideoCategory videoCategory);
    }
}