using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ControlData_Action
    {
        int Delete(string guid);
        DataTable GetControlDataList(string controlGuid, string groupID);
        DataTable GetEditInfo(string guid);
        int Insert(ShopNum1_ControlData shopNum1_ControlData);
        DataTable Search(string guid);
        int Update(ShopNum1_ControlData shopNum1_ControlData);
    }
}