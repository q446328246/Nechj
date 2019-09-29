using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ReturnGoodsInfo_Action
    {
        int Delete(string strGuids);
        DataTable SearchByGuid(string strGuid);

        DataTable SearchReturnGoods(string MemLoginID, string DispatchModeName, string OrderNumber, int Status,
            string ReturnGoodsTime1, string ReturnGoodsTime2);
    }
}