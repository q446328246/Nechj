using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ShopLink_Action
    {
        int Add(ShopNum1_Shop_Link shopNum1_Shop_Link);
        DataTable CheckMemLoginID(string memLoginID);
        int Delete(string guids);
        DataTable Edit(string guid);
        DataTable GetAllShopMemLoginID();
        DataTable Search(string showCount);
        DataTable Show(string MemLoginID, string showCount);
        int Updata(ShopNum1_Shop_Link shopNum1_Shop_Link);
    }
}