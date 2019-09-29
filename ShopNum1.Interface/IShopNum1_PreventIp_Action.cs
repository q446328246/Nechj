using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_PreventIp_Action
    {
        bool CheckedUser(string userIP, string Type);
        int Delete(string guid);
        DataTable GetEditInfo(string guid);
        int Insert(ShopNum1_PreventIp shopNum1_PreventIp);
        DataTable Search();
        int Update(ShopNum1_PreventIp shopNum1_PreventIp);
    }
}