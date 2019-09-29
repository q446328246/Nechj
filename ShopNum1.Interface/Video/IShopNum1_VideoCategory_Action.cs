using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_VideoCategory_Action
    {
        int Add(ShopNum1_VideoCategory productCategory);
        int Delete(string string_0);
        int GetMaxID();
        DataTable Search(int isDeleted);
        DataTable Search(int fatherID, int isDeleted);
        DataTable Search(int fatherID, int isDeleted, int count);
        DataTable Search2(int fatherID, int isDeleted);
        DataTable SearchInfoByID(string strID);
        int Update(ShopNum1_VideoCategory productCategory);
    }
}