using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_AdvancePaymentModifyLog_Action
    {
        int ChangeOperateStatus(string ID, int OperateStatus);
        DataTable GetAdvancePaymentModifyLog(string ID);
        int OperateMoney(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog);
        DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted);
        DataTable SelectAdvPaymentModifyLog_List(CommonPageModel commonModel);

        DataTable SelectOperateMoney(string memberid, string operatetype, string datetime1, string datetime2,
            string ordernumber);
        int OperateMoneytwo(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog);
    }
}