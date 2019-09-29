using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ExtendSiteMapXml_Action : IShopNum1_ExtendSiteMapXml_Action
    {
        public DataTable SearchArticle()
        {
            string strSql = "select Guid from ShopNum1_Article";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchArticleCategoryID()
        {
            string strSql = "select ID from ShopNum1_ArticleCategory";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchCategoryInfoCatagoryCode()
        {
            string strSql = "select code from ShopNum1_Category";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchCategoryInfoDetail()
        {
            string strSql = "select guid from ShopNum1_CategoryInfo";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchProductCategoryID()
        {
            string strSql = "select Code from ShopNum1_ProductCategory where 0=0";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchSupplyDemandCatagoryCode()
        {
            string strSql = "select code from ShopNum1_SupplyDemandCategory";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchSupplyDemandDetail()
        {
            string strSql = "select guid from ShopNum1_SupplyDemand";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
    }
}