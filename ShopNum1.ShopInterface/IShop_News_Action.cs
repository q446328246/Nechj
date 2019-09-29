using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_News_Action
    {
        int AddNews(ShopNum1_Shop_News shop_News);
        int DeleteNews(string guid);
        DataTable GetCountNewsByMemLoginID(string memloginid);
        DataTable GetNews(string guid);
        DataTable GetNewsByGuidAndMemLoginID(string guid, string memloginid);
        DataTable GetNewsList(string memloginid, string isshow);
        DataTable GetShopArticleDetailMeto(string guid);
        DataTable GetShopMetaByNewsguid(string guid);
        DataTable MetaGetNews(string memloginid, string guid);

        DataSet SearchNewsListNew(string memloginid, string newscategoryguid, string ordertype, string sort,
            string perpagenum, string current_page, string isreturcount);

        int UpdateNews(ShopNum1_Shop_News shop_News);
    }
}