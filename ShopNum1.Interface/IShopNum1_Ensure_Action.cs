using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Ensure_Action
    {
        DataTable GetShopapplyEnsure(string shopid);
    }
}