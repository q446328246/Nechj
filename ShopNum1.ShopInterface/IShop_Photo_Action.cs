using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Photo_Action
    {
        int AddPhoto(ShopNum1_Shop_Photo photo);
        int DeletePhoto(string guid);
        DataTable EditPhoto(string guid);
        DataTable SearchPhotoList(string albumsguid, string showcount);
        int UpdatePhoto(ShopNum1_Shop_Photo photo);
    }
}