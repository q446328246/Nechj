using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_DefaultAdImg_Action
    {
        bool Add(DefaultAdImg advertisement);
        bool Delete(string guids);
        DataTable GetDefaultAd();
        void ResetAd();
        DataTable SelectByID(string guid);
        bool Update(DefaultAdImg advertisement);
    }
}