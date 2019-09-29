using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ArticleCategory_Action
    {
        int Add(ShopNum1_ArticleCategory articleCategory);
        int Delete(string string_0);
        DataTable GetArticleCategory(string FatherId);
        DataTable GetArticleCategoryMeto(string strID);
        DataTable GetArticleInfoByID(string string_0);
        DataTable GetEditInfo(string strID);
        int GetMaxID();
        string GetNameByID(int int_0);
        DataTable Search(int isDeleted);
        DataTable Search(int fatherID, int isDeleted);
        DataTable SearchByFatherID(string fatherID, string showcount, string isDeleted);
        DataTable SearchID(int int_0);
        DataTable SearchShow(int fatherID, int isDeleted);
        int Update(ShopNum1_ArticleCategory articleCategory);
    }
}