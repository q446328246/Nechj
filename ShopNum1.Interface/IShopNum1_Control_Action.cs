using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Control_Action
    {
        int Delete(string guid);
        DataTable GetControlGuid(string controlKey);
        DataTable GetEditInfo(string guid);
        int Insert(ShopNum1_Control shopNum1_Control);
        DataTable Search(string PageName);
        int Update(ShopNum1_Control shopNum1_Control);
    }
}