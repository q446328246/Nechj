using System.Data;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Address_Action
    {
        DataTable GetAddress(string guid, string isdefault);
    }
}