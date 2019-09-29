using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ExtendSiteMapXml_Action
    {
        DataTable SearchArticle();
        DataTable SearchArticleCategoryID();
        DataTable SearchCategoryInfoCatagoryCode();
        DataTable SearchCategoryInfoDetail();
        DataTable SearchProductCategoryID();
        DataTable SearchSupplyDemandCatagoryCode();
        DataTable SearchSupplyDemandDetail();
    }
}