using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_URLManage_Action
    {
        int AddURLManage(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
        DataTable CheckURLManageByDoMain(string domain);
        int DeleteURLManage(string guid);
        DataTable GetUrlManage(string string_0);
        DataTable GetUrlManageList(string loginid, string isaudit);
        int UpdateURLManage(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
    }
}