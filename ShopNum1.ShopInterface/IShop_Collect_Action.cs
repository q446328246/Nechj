namespace ShopNum1.ShopInterface
{
    public interface IShop_Collect_Action
    {
        int AddProductCollect(string memloginid, string productguid, string shopID, string isAttention,
            string shopPrice, string productName, string sellLoginID, int tr_shop_category_id);

        int AddShopCollect(string memloginid, string shopid);
        int ProductCollectNum(string guid);
        int ShopCollectNum(string memLoginID);
    }
}