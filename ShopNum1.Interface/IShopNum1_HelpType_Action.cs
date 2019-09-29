using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_HelpType_Action
    {
        int Add(ShopNum1_HelpType shopNum1_HelpType);
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        DataTable GetList();
        DataTable Search(string name);
        DataTable Search(string IsDeleted, int showCount);
        int update(ShopNum1_HelpType shopNum1_HelpType);
    }
}