using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Link_Action
    {
        int Add(ShopNum1_Link Service_Link);
        DataTable CheckIsDuplication(string link);
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        DataTable GetLink();
        DataTable GetLinkListImage(string showCount);
        DataTable Search(int isDeleted);
        DataTable Search(string name, int isShow);
        int Update(string guid, ShopNum1_Link Service_Link);
    }
}