using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_OnLineService_Action
    {
        int AddOnLineService(ShopNum1_Shop_OnlineService onlineService);
        int DeleteOnLineService(string guid);
        string GetIsShowByID(string string_0);
        DataTable GetOnLineService(string guid);
        DataTable GetOnLineServiceList(string memloginid, string type, string isshow);
        string GetPath();
        void LoadXml();
        DataTable Search(string name, string type, string strPath);
        DataTable SelectOnLineService_List(CommonPageModel commonModel);
        int Update(string[] string_0, string[] isshow, string strPath, string memloginid);
        int UpdateIsShow(string type, string shopid, string isshow);
        int UpdateOnLineService(ShopNum1_Shop_OnlineService onlineService);
        int UpdateShopOnlinePhone(ShopNum1_Shop_OnlineService onlineService);
    }
}