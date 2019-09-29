using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Image_Action
    {
        int Add(ShopNum1_Image shopNum1_Image, string imageCategoryID);
        int Delete(string guids);
        DataTable Search(string guid);
        DataTable Search(string imageType, string name, int isDeleted, string imageCategoryID);

        DataTable SearchImageByType(string imageType, string name, int isDeleted, string imageCategoryID,
            string pagesize, string current_page, string isReturCount);

        int Update(ShopNum1_Image shopnum1_image);
        int UpdateName(string strGuid, string strNewName);
    }
}