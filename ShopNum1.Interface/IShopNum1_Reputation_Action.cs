using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Reputation_Action
    {
        DataTable ShopReputationSearch(string shopReputation, string isdeleted, string type);
    }
}