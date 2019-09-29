using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Cart_Action
    {
        int Add(ShopNum1_Shop_Cart cart);
        int AddCart(ShopNum1_Shop_Cart shopcart);
        int AddOrder(List<ShopNum1_Shop_Cart> cart);
        DataTable CheckCartProduct(string memLoginID, string productGuid, string attributes, int isPresent, string guige);
        DataTable CheckMemberLoginID(string memLoginID);
        DataTable CheckRepertoryCount(string guid);
        int Delete(string guids);
        int DeleteByMemLoginID(string memLoginID);
        int DeleteByMemLoginID(string memLoginID, string guids);
        DataTable GetGroupPriceByProductGuid(string productguid);
        DataTable GetInfoByGuid(string guid);
        int GetMemCartCount(string memLoginID);
        int GetProductCount(string memLoginID, string productGuid);
        DataTable GetProductInfoByCartProductGuid(string MemloginID, string ShopID, string ProGuID);
        DataTable GetProductInfoByProductGuids(string MemloginID, string ShopID, string CartGuID);
        DataTable SearchBuyPriceByMemLoginID(string memLoginID);
        DataTable SearchByMemLoginID(string memLoginID);
        DataTable SearchByMemLoginID(string memLoginID, int cartType);
        DataTable SearchByMemLoginID(string memLoginID, string SellName);
        DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID);
        DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID, string guids);
        DataTable SearchByMemLoginIDShopID(string memLoginID, string Shopid);
        DataTable SearchByPostPrice(string memLoginID, string shopName);
        DataTable SearchByShopMemID(string memLoginID, string shopName);
        DataTable SearchByShopMemID(string memLoginID, string shopName, string guids);
        DataTable SearchByShopMemID_two(string memLoginID, string shopName, int shop_category_id);
        DataTable SearchShopByMemLoginID(string memLoginID);
        DataTable SearchShopByMemLoginID(string memLoginID, string guids);
        DataTable SearchShopByMemLoginID_InsertOrderInfo(string memLoginID, string guids);
        DataTable SearchByShopMemID_freetwo(string memLoginID, string guids, int shop_category_id, string shopcarguid);
        DataTable SearchByShopMemID_freefive(string memLoginID, string guids, int shop_category_id, string strShop);
        DataTable GetProductInfoByMemLoginID(string MemloginID);
        DataTable SearchShopByMemLoginID_Price(string memLoginID, string guids, string productGuid, int category_id);
        DataTable SearchShopByMemLoginID_Price(string memLoginID, string guids, string productGuid, int category_id,string size,string color);
        int Update(List<ShopNum1_Shop_Cart> listCart);
        int UpdateCar(List<ShopNum1_Shop_Cart> listCart);
        DataTable SearchShopByMemLoginID_two(string memLoginID, string guids, int shop_category_id);
        DataTable SearchByShopMemID_free(string memLoginID, string guids, int shop_category_id);

        DataTable SelectShopCar(string memLoginID);
    }
}