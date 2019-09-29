using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Payment_Action
    {
        DataTable SearchTwo(int isDeleted);
        int Add(ShopNum1_Payment payment);
        int Delete(string guids);
        int DeleteMobile(string guids);
        DataTable GetPaymentInfoByGuid(string guid);
        DataTable GetPaymentKey(string paymentType);
        string GetPaymentType(string guid);
        string GetShopPayMentByGuid(string guid);
        DataTable Search();
        DataTable Search(int isDeleted);
        DataTable SearchMobile(int isDeleted);
        DataTable SearchPayInfo(string guid, int delete);
        DataTable SearchPre();
        int UpdataShopPayMentByGuid(string guid, string IsPayMentShop);
        int Update(ShopNum1_Payment payment, string guid, int isDeleted);
        int UpdateMobile(ShopNum1_Payment payment, string guid, int isDeleted);
    }
}