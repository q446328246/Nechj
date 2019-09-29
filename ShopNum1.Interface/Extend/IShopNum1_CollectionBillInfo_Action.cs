using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_CollectionBillInfo_Action
    {
        int Delete(string strGuids);

        DataTable Search(string OrderNumber, string MemLoginID, string PaymentGuid, decimal ShouldPayPrice1,
            decimal ShouldPayPrice2, string CreateTime1, string CreateTime2, int IsDelete);

        DataTable SearchByGuid(string strGuid);
        DataTable SearchCollectionBillByGuid(string guids);
    }
}