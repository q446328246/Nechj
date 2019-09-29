using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ScoreModifyLog_Action
    {
        int Delete(string guids);
        DataTable GetDataInfo(int IsDeleted);
    }
}