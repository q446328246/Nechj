using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopProductPropValue_Action
    {
        DataTable BindProductProp(string Code);
        int DeleteShopPropValue(string strId);
        bool Exists(int ID);
        int GetMaxOrderId();
        string GetPropValue(string strID);
        DataTable GetPropValuesByPropID(string string_0);
    }
}