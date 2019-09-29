using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Image_Type_Action
    {
        int Add(ShopNum1_Image_Type shopnum1_image_type);
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        DataTable Search(string name, int isDeleted);
        int Update(string guid, ShopNum1_Image_Type shopnum1_image_type);
    }
}