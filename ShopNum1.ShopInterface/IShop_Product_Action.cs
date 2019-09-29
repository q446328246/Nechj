using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Product_Action
    {
        int AddShopProduct(ShopNum1_Shop_Product shop_Product);
        DataTable AutoSearchProductName(string keyword);
        DataTable AutoSearchProductName(string keyword, string type);
        DataTable AutoSearchShopName(string keyword);
        DataTable AutoSearchShopName(string keyword, string type);
        DataTable AutoSearchSupplyName(string keyword);
        DataTable CheckMenberBuyProduct(string guid, string memberid);
        DataTable selectMaxNumber(string guid);
        string CheckSpellPanicProduct(string memberid, string type);
        int DeleteById(string strId);
        int DeleteShopProduct(string guid, string memloginid);
        DataTable GetCollectRankingProduct(string showcount, string shopid,int category);

        DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string showcount, string ordertype,
            string shopid, string sort);

        DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy,
            string showcount, string ordertype, string shopid);

        DataTable GetIsProductAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend,
            string ispanicbuy, string isspellbuy, string showcount, string ordertype,
            string shopid, int shop_category_id);

        DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ordertype, string shopid,
            string sort, string perpagenum, string current_page, string isreturcount);

        DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy,
            string ordertype, string shopid, string sort, string perpagenum, string current_page,
            string isreturcount);

        DataSet GetIsProductNewAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend,
            string ordertype, string shopid, string sort, string perpagenum,
            string current_page, string isreturcount, int shop_category_id);

        DataSet GetIsProductNewProductState(string isnew, string ishot, string ispromotion, string ispanicbuy,
            string isspellbuy, string ordertype, string shopid, string sort,
            string perpagenum, string current_page, string isreturcount);

        int GetLimitBuyCount(string guid);
        DataTable GetPanicBuyList(string shopid, string showcount, string productguid);
        DataSet GetPanicInfo(string shopid, string guid);
        DataTable GetPanicInfoMeta(string shopid, string guid);
        DataTable GetPanicList(string showcount, string ordertype, string shopid);
        DataTable GetProductBrandAndOrderIdByCode(string code);
        DataTable GetProductCategoryNameByCode(string code);
        DataTable GetProductDetail(string guid);
        DataTable GetProductDetailMeta(string guid);
        DataSet GetProductInfoByGuidAndMemLoginID(string guid, string memloginid);
        DataTable GetSaleRankingProduct(string showcount, string shopid,int category);
        DataTable GetShopCategroy(string memloginid);
        DataTable GetShopMetaByGuid(string guid);
        DataTable GetShopName(string memberID);

        DataTable GetShopProduct(string name, string productnum, string issaled, string beginprice, string endprice,
            string producttype, string productseriescode, string productcategorycode,
            string memloginid, string isAudit);

        DataTable GetShopproductCatetoryByCode(string code, string memloginid);
        DataTable GetShopProductDetailMeto(string guid);
        DataTable GetShopProductEdit(string guid, int shop_category_id);
        DataTable GetSpellInfo(string shopid, string guid);
        DataTable GetSpellInfoMeta(string shopid, string guid);
        DataTable GetSpellList(string showcount, string ordertype, string shopid);
        DataTable GetSpellListFor(string shopid, string showcount, string ischeck);
        DataTable GetTemplateFee(string strGuId);

        DataTable SearchProductList(string memloginid, string kwyword, string pricestart, string priceend, string code,
            string sortstyle);

        DataSet SearchProductListNew(string memloginid, string kwyword, string pricestart, string priceend, string code,
            string ordertype, string sort, string perpagenum, string current_page,
            string isreturcount,int category);

        DataTable SearchProductShopByGuid_two(string productguid, int shop_category_id);
        DataTable SearchProductShopByGuid(string productguid);
        DataTable SearchProductPrice(string productid, int shop_category_id);
        int SearchProductID(string productid);
        int UpdateClickCountByGuid(string guid);
        int UpdateProductSaled(string guids, string isSaled);
        int UpdateSaleNumberByOrderGuid(string OrderGuidguid, string strSaleNumber);
        int UpdateShopProduct(ShopNum1_Shop_Product shop_Product);
    }
}