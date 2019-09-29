using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_AttachMentCategory_Action
    {
        int Delete(string guid);
        DataRow EditShow(string guid);
        int Insert(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory);
        DataTable Search();
        int Update(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory);
    }
}