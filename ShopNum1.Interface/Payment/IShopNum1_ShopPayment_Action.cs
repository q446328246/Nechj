using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopPayment_Action
    {
        int Add(ShopNum1_ShopPayment payment);
        int Delete(string guids);
        DataTable GetPaymentInfoByGuid(string guid);
        DataTable GetPaymentInfoByGuid(string guid, string memloginid);
        DataTable GetPaymentKey(string paymentType, string agentLoginID);
        string GetPaymentType(string guid);
        DataTable Search(string memloginid);
        DataTable Search(int isDeleted, string memloginid);
        DataTable SearchPayInfo(string guid, int delete);
        int Update(ShopNum1_ShopPayment payment, string guid, int isDeleted);
    }
}