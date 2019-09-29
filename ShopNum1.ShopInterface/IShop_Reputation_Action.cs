using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Reputation_Action
    {
        int Add(ShopNum1_ShopReputation ShopReputation);
        int Delete(string guids);
        DataTable Search(int isDeleted);
        DataTable Search(string type);
        DataTable Search(string guid, int isDeleted);
        DataTable ShopReputationSearch(string reputation, string isdeleted, string type);
        int Update(ShopNum1_ShopReputation ShopReputation);
    }
}