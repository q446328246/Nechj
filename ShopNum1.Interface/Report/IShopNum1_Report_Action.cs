using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Report_Action
    {
        DataTable Search(string productCategoryCode, decimal shopPrice1, decimal shopPrice2, decimal marketPrice1,
            decimal marketPrice2);

        DataTable SearchMemberBuyReport(string dispatchTime1, string dispatchTime2);

        DataTable SearchSeeBuyRate(string name, string productCategoryCode1, string productCategoryCode2,
            string productCategoryCode3, string brandGuid, decimal shopPrice1, decimal shopPrice2,
            decimal marketPrice1, decimal marketPrice2);

        DataTable SearchSellDetail(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellGuideLineMemberBuyRate(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellGuideLineMemberOrderMoney(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellGuideLineMemberOrderNumber(string dispatchTime1, string dispatchTime2);
        DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop);
        DataTable SearchSellOrder(string Name, string shopName, string dispatchTime1, string dispatchTime2);
    }
}