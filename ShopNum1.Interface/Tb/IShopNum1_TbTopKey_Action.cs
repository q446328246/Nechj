using ShopNum1.TbLinq;

namespace ShopNum1.Interface
{
    public interface IShopNum1_TbTopKey_Action
    {
        bool AddTbTopKey(ShopNum1_TbTopKey tbtopkey);
        bool Delete(string memlogid);
        ShopNum1_TbTopKey SearchTopKey(string memlogid);
        bool UpdateTopKey(ShopNum1_TbTopKey tbtopkey);
    }
}