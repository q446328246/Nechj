using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_PageWebControl_Action
    {
        int Add(ShopNum1_PageWebControl pageWebControl);
        int Delete(string guids);
        DataTable Search(string pageGuid, string guid, int isDeleted);
        int Update(ShopNum1_PageWebControl pageWebControl);
    }
}