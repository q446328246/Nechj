using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_PageAddress_Action
    {
        DataTable GetArticleCategoryPageAddress(string guid);
        DataTable GetArticlePageAddress(string guid);
        DataTable GetHelpCategoryPageAddress(string guid);
        DataTable GetProductCategoryPageAddress(string productCategoryID);
        DataTable GetProductPageAddress(string guid);
        DataTable GetVideoCategoryPageAddress(string guid);
        DataTable GetVideoPageAddress(string guid);
    }
}