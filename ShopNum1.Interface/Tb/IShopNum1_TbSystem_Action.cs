using ShopNum1.TbLinq;

namespace ShopNum1.Interface
{
    public interface IShopNum1_TbSystem_Action
    {
        bool CheckTbUserBind(string tbShopName, string memlogid, out string shopName);
        ShopNum1_TbSystem GetTbSysem(string memlogid, string shopname);
        bool InsertTbSystem(string memglogid, string shopname);
        bool Remove(string memlogid);
        bool UpdateTbSystem(ShopNum1_TbSystem tbSystem);
    }
}