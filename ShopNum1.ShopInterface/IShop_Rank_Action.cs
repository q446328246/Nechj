using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Rank_Action
    {
        int Add(ShopNum1_ShopRank shopRank);
        int Delete(string guids);
        int EditIsDefault();
        DataTable GetDefaultRank();
        DataTable GetShopRank();
        DataTable GetShopRankByGuid(string guid);
        DataTable GetShopRankInfoByMemLoginID(string memloginid);
        DataTable GetTemplateByRankGuid(string guid);
        DataTable Search(int isDeleted);
        DataTable Search(string guid, int isDeleted);
        DataTable ShopRankSearch(string name);
        int Update(ShopNum1_ShopRank shopRank);
    }
}