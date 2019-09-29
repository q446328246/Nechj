using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_CouponType_Action
    {
        int Add(ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType);
        int Delete(string ID);
        DataTable search(int int_0, int isshow);
        int Update(ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType);
    }
}