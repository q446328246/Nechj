using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_UserDefinedColumn_Action
    {
        int Delete(string guid);
        DataTable GetButtomNavigation(string showCount);
        DataTable GetEditInfo(string guid);
        DataTable GetTopNavigation(string showCount);
        int Insert(ShopNum1_UserDefinedColumn shopNum1_AgentUserDefinedColumn);
        DataTable Search(string Name);
        DataTable SearchMiddleNavigation(string showCount);
        DataTable SearchMiddleNavigation(string showCount, int cout);
        int Update(ShopNum1_UserDefinedColumn shopNum1_AgentUserDefinedColumn);
    }
}