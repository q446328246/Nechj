namespace ShopNum1.Interface
{
    public interface IShopNum1_SiteMap_Action
    {
        string Search(string table, string guid);
        string SearchNameByID(string table, string string_0);
        string SearchOrganizBuyInfoName(string guid);
        string SearchTitle(string table, string guid);
    }
}