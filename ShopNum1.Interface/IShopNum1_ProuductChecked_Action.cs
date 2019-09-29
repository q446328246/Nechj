using System.Collections.Generic;
using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ProuductChecked_Action
    {
        int Delete(string guids);

        DataSet GetFurnitureProduct(string addresscode, string address, string productCategoryCode, string ordername,
            string soft, string startprice, string endprice, string productName,
            string brandguid, string perpagenum, string current_page, string isreturcount,
            Dictionary<string, string> Pvalue,int category);

        DataSet GetFurnitureProduct1(string addresscode, string address, string productCategoryCode, string ordername,
            string soft, string startprice, string endprice, string productName,
            string brandguid, string perpagenum, string current_page, string isreturcount,
            Dictionary<string, string> Pvalue, string strName);

        DataSet GetFurnitureProduct2(string addresscode, string address, string productCategoryCode, string ordername,
            string soft, string startprice, string endprice, string productName,
            string brandguid, string perpagenum, string current_page, string isreturcount,
            Dictionary<string, string> Pvalue, int IsShopNew, int IsshopHot, int IsShopGood,
            int IsShopRecommend);

        DataTable GetList(string categoryID);
        DataTable GetOrderID(string guid);
        DataTable GetPanceProductByCategoryCode(string categorycode, string pagesize, string current_page);
        DataTable GetProductByCategoryCode(string categorycode, string pagesize, string current_page);
        DataTable GetProductByCategoryID(string categoryid, string showcount);
        DataTable GetShopInfoByGuid(string guid);

        DataTable Search(string productName, string productNum, string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID,
            string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend);

        int SearchAllCount(string productName, string productNum, string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID);

        int SearchAllCountNew(string productName, string productNum, string productCategory, string price1,
            string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy,
            string MemLoginID, string shopName, string sName);

        DataTable SearchGroupProduct(string categorycode, string Sort, string SortType, string pagesize,
            string current_page);

        DataTable SearchNew(string productName, string productNum, string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID,
            string shopName, string sName);

        DataTable SearchPerPage(int startRowIndex, int maximumRows, string productName, string productNum,
            string productCategory, string price1, string price2, string isSaled, string isAudit,
            string isPanicBuy, string isSpellBuy, string MemLoginID);

        DataTable SearchPerPageNew(int startRowIndex, int maximumRows, string productName, string productNum,
            string productCategory, string price1, string price2, string isSaled, string isAudit,
            string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName,
            string sName, string isSell, string isShopNew, string isShopHot, string isShopGood,
            string isShopRecommend);

        DataTable SearchProductByMemLoginID(string MemLoginID, string ProductCount);

        DataSet SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid,
            string name, string startdate, string enddate, string brandguid);

        DataSet SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid,
            string name, string startdate, string enddate, string brandguid, string keywords,
            string startShopPrice, string endShopPrice);

        DataTable SearchProductOrder(string pagesize, string field);

        DataTable SearchRelatedProduct(string productname, string memberid, int pageindex, int pagesize,
            string isreturcount);

        DataTable SelectProductPanicBuy(string pagesize);
        DataTable SelectProductShowLine(string pagesize, string code);
        int Update(string guids, string intState);
        int UpdateProduct(string guids, string strName, string strValue);

        DataSet V8_2_GetFurnitureProductNew(string addresscode, string address, string productCategoryCode,
            string ordername, string soft, string startprice, string endprice,
            string productName, string brandguid, string perpagenum, string current_page,
            string isreturcount, Dictionary<string, string> Pvalue, string strSaleType, string category);

        DataTable V8_2_SearchPerPageNew(string resultnum, string pagesize, string currentpage, string productName,
            string productCategory, string price1, string price2, string isSaled,
            string isAudit, string MemLoginID, string shopName, string isSell, string isNew,
            string isHot, string isShopGood, string isRecommend);
    }
}