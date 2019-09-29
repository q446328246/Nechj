using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OrderOperateLog_Action
    {
        int Add(ShopNum1_OrderOperateLog orderOperateLog);
        DataTable Search(string orderInfoGuid);
    }
}