using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_DispatchRegion_Action
    {
        int Add(ShopNum1_DispatchRegion dispatchRegion);
        int Delete(string guids);
        int GetDispatchCount(int fatherID, int isDeleted);
        DataTable GetDispatchRegionByID(string ID);
        DataTable GetDispatchRegionCode(string code);
        DataTable GetDispatchRegionName();
        DataTable GetDispatchRegionName(string fatherID);
        DataTable GetDispatchRegionName(string fatherID, string agentLoginID);
        DataTable Search(int IsDeleted);
        DataTable SearchtDispatchRegion(int fatherID, int isDeleted);
        int Update(string guid, ShopNum1_DispatchRegion dispatchRegion);
    }
}