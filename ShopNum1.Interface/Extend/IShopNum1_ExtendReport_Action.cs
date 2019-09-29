using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ExtendReport_Action
    {
        int Add();
        DataTable GetCategoryByParam(string param);

        DataTable Search(int productCategoryID, string brandGuid, decimal shopPrice1, decimal shopPrice2,
            decimal costPrice1, decimal costPrice2, decimal marketPrice1, decimal marketPrice2);

        DataTable SearchAgentMemberBuyReport(string dispatchTime1, string dispatchTime2);
        DataTable SearchAgentSellDetail(string dispatchTime1, string dispatchTime2);
        DataTable SearchAgentSellOrder(string dispatchTime1, string dispatchTime2);
        DataTable SearchMemberBuyReport(string dispatchTime1, string dispatchTime2);

        DataTable SearchSeeBuyRate(int productCategoryID, string brandGuid, decimal shopPrice1, decimal shopPrice2,
            decimal costPrice1, decimal costPrice2, decimal marketPrice1, decimal marketPrice2);

        DataTable SearchSellDetail(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellGuideLineMemberBuyRate(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellGuideLineMemberOrderMoney(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellGuideLineMemberOrderNumber(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop);

        DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop, string isNew, string isHot,
            string isRecommend, string isBest);

        DataTable SearchSellOrders(string dispatchTime1, string dispatchTime2, int intTop);
        DataTable SearchSellProduct(int intTop, int ProductCategoryID);
    }
}