using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MMSType_Action
    {
        int Add(ShopNum1_MMSType emailtype);
        int Delete(string guids);
        DataTable GetEditInfo(string guid, int isDeleted);
        DataTable Search(string typename, int isDeleted);
        int Update(string guid, ShopNum1_MMSType emailtype);
    }
}