using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OperateLog_Action
    {
        int Add(ShopNum1_OperateLog shopNum1_operateLog);
        int Delete(string guids);
        int DeleteAll(string startDate, string endDate);
        DataTable Search(string operatorID, string IP, string StartDate, string EndDate);
    }
}