using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OnLineService_Action
    {
        int Add(ShopNum1_OnlineService onlineservice);
        int Delete(string guids);
        DataTable GetEditInfo(string guid, int isDeleted);
        string GetIsShowByID(string string_0);
        DataSet GetOnlineService(string showcountqq, string showcountmsn);
        DataTable GetOnlineServiceInfo(int Deleted);
        string GetPath();
        void LoadXml();
        DataTable Search(string name, string type);
        int Update(string guid, ShopNum1_OnlineService onlineservice);
        int Update(string[] string_0, string[] isshow);
        int UpdateIsShow(string type, string isshow);
    }
}