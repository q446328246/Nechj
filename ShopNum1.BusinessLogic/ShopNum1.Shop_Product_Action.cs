#region 程序集 ShopNum1.ShopBusinessLogic.dll, v2.0.50727
// E:\workDay\shopnum1\ShopNum1\ShopNum1.ShopBusinessLogic\obj\x86\Debug\ShopNum1.ShopBusinessLogic.dll
#endregion

using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Product_Action : IShop_Product_Action
    {
        public Shop_Product_Action();

        public int AddShopProduct(ShopNum1_Shop_Product shop_Product);
        public DataTable AutoSearchProductName(string keyword);
        public DataTable AutoSearchProductName(string keyword, string type);
        public DataTable AutoSearchShopName(string keyword);
        public DataTable AutoSearchShopName(string keyword, string type);
        public DataTable AutoSearchSupplyName(string keyword);
        public int ChangeCarByCook(string oldUser, string newUser);
        public DataTable CheckMenberBuyProduct(string guid, string memberid);
        public string CheckSpellPanicProduct(string memberid, string type);
        public int DeleteById(string strId);
        public int DeleteShopProduct(string guid, string memloginid);
        public DataTable GetCollectRankingProduct(string showcount, string shopid);
        public DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string showcount, string ordertype, string shopid, string sort);
        public DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string showcount, string ordertype, string shopid);
        public DataTable GetIsProductAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend, string ispanicbuy, string isspellbuy, string showcount, string ordertype, string shopid, int shop_category_id);
        public DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
        public DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
        public DataSet GetIsProductNewAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount, int shop_category_id);
        public DataSet GetIsProductNewProductState(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
        public int GetLimitBuyCount(string guid);
        public DataTable GetPanicBuyList(string shopid, string showcount, string productguid);
        public DataSet GetPanicInfo(string shopid, string guid);
        public DataTable GetPanicInfoMeta(string shopid, string guid);
        public DataTable GetPanicList(string showcount, string ordertype, string shopid);
        public DataTable GetProductBrandAndOrderIdByCode(string code);
        public DataTable GetProductCategoryNameByCode(string code);
        public DataTable GetProductDetail(string guid);
        public DataTable GetProductDetailMeta(string guid);
        public DataSet GetProductInfoByGuidAndMemLoginID(string guid, string memloginid);
        public DataTable GetProductList(string strPageSize, string strCurrentPage, string strCondition, string strResultNum);
        public DataTable GetQgProduct(int start, int int_0);
        public DataTable GetSaleRankingProduct(string showcount, string shopid);
        public DataTable GetShopCategroy(string memloginid);
        public DataTable GetShopMetaByGuid(string guid);
        public DataTable GetShopName(string memberID);
        public DataTable GetShopProduct(string name, string productnum, string issaled, string beginprice, string endprice, string producttype, string productseriescode, string productcategorycode, string memloginid, string isAudit);
        public DataTable GetShopproductCatetoryByCode(string code, string memloginid);
        public DataTable GetShopProductDetailMeto(string guid);
        public DataTable GetShopProductEdit(string guid, int shop_category_id);
        public DataTable GetShopProductEdit_two(string guid);
        public DataTable GetSpellInfo(string shopid, string guid);
        public DataTable GetSpellInfoMeta(string shopid, string guid);
        public DataTable GetSpellList(string showcount, string ordertype, string shopid);
        public DataTable GetSpellListFor(string shopid, string showcount, string ischeck);
        public DataTable GetTemplateFee(string strGuId);
        public int SearchProductID(string productid);
        public DataTable SearchProductList(string memloginid, string kwyword, string pricestart, string priceend, string code, string sortstyle);
        public DataSet SearchProductListNew(string memloginid, string kwyword, string pricestart, string priceend, string code, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
        public DataTable SearchProductPrice(string productid, int shop_category_id);
        public DataTable SearchProductShopByGuid(string productguid);
        public int UpdateClickCountByGuid(string guid);
        public int UpdateProductSaled(string strIds, string isSaled);
        public int UpdateSaleNumberByOrderGuid(string OrderGuidguid, string strSaleNumber);
        public int UpdateShopProduct(ShopNum1_Shop_Product shop_Product);
    }
}
