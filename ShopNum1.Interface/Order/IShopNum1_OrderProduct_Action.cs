using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OrderProduct_Action
    {
        DataTable SelectOrderProductByGuIdorAllAndMemloginId(string memLoginId, string OrderGuId, string KeyWord);
        DataTable SelectOrderProductByGuIdorAllAndBuyerId(string memLoginId, string OrderGuId, string KeyWord);
        DataTable GetNewSaleOrder(string strTopCount);
        DataTable GetOrderProductList(string guid);
        DataTable GetPackOrderShopInfo(string memloginid);
        string GetWeight(string guid);
        DataTable Search(string orderInfoGuid);

        DataTable SearchOrderProduct(string ordernum, string productname, string shopname, string startdate,
            string enddate);

        DataTable SearchRankingSellHot(string ShowCount);
        DataTable SelectOrderProductByGuIdorAll(string OrderGuId, string KeyWord);
        int UpdateOrderProductBuyNum(string guid, string buynumber, string productPrice);
        int UpdateOrderProductInfo(string guid, string buyprice, string groupprice, string buynumber);
        int UpdateReduceStock(string strOrderGuId, string strSaleType);
        int UpdateStock(string strOrderGuId);
    }
}