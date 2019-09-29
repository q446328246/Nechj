using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopProduct_Browse_Action
    {
        int Add(ShopNum1_ShopProduct_Browse ShopProduct_Browse);
        int Delete(string guids);
    }
}