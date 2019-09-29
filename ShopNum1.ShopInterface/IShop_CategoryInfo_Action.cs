using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_CategoryInfo_Action
    {
        DataTable CategoryCommentList(string guid);
        DataTable CategoryInfoDetail(string guid);
        int Delete(string guid);
        string GetAddressCode(string commerceMemLoginID);
        string GetAddressValue(string addressCode);
        int Insert(ShopNum1_CategoryInfo shopNum1_CategoryInfo);
        DataTable Search(string commerceMemLoginID, string IsAudit);
        int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo);
        DataRow UpdateSearch(string guid);
    }
}