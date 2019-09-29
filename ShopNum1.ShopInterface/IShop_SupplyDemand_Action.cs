using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_SupplyDemand_Action
    {
        int Delete(string guid);
        string GetAddressCode(string commerceMemLoginID);
        string GetAddressValue(string addressCode);
        DataTable GetSupplyDemandMeto(string guid);
        DataTable Search(string commerceMemLoginID, string IsAudit);
        int SupplyDemandCommentAdd(ShopNum1_SupplyDemandComment supplyDemandComment);
        DataTable SupplyDemandCommentList(string guid);
        DataTable SupplyDemandDetail(string guid);
        DataRow UpdateSearch(string guid);
    }
}