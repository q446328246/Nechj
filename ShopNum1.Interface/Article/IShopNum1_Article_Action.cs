using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Article_Action
    {
        int Add(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList);
        int Delete(string guids);
        DataTable GetArticleCategoryInfo(int isDeleted);
        DataTable GetArticleIsHotorIsRecommend(string showCount, string categoryID, string type);
        DataTable GetArticleMeto(string guid);
        DataTable GetArticleOnAndNext(string guid, string onArticleName, string nextArticleName);
        DataTable GetChildCategory(string showcount, string fatherId);
        DataTable GetEditInfo(string guid);
        string GetNameByGuid(string guid);
        DataTable GetProductCategoryInfo(int isDeleted);
        DataTable GetRelatedArticleInfo(string guid);
        DataTable GetRelatedProductInfo(string guid);
        DataTable GetTitleByID(string ID, string type, string ShowCount);
        DataTable Search(string Title, int articleCategoryID);

        DataTable Search(string title, string publisher, int articlecategoryid, string startdate, string enddate,
            int isshow, int ishot, int isrecommand, int ishead, int isallowcomment, int isDeleted);

        DataTable SearchArticle(string title);

        DataTable SearchArticle(string articlename, string articlecode, string pageindex, string pagesize,
            string isreturcount);

        DataTable SearchArticleList(string guid, int articleCategoryID);
        DataTable SearchArticleList(string guid, int articleCategoryID, int count);
        DataTable SearchArticleRelatedArticle(string guid, int count);
        DataTable SearchByArticleCategoryID(int articleCategoryID);
        DataTable SearchByArticleCategoryID(int articleCategoryID, int showCount);
        DataTable SearchByCategoryIDFrist(int articleCategoryID);
        DataTable SearchByCategoryIDOther(int articleCategoryID, string guid, string showCount);
        DataTable SearchNewArticle(int count);
        int Update(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList);
        int UpdateClickCount(string guid);
    }
}