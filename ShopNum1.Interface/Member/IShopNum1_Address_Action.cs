using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Address_Action
    {
        int Add(ShopNum1_Address address);
        int ChangeDefaultAddress(string MemLoginID, string Guid);
        int CheckDefaultAddress(string MemLoginID);
        int Delete(string guids);
        DataTable GetAreaByCode(string code);
        DataTable GetRegionCode(string code);
        DataTable Search(string guid);
        DataTable Search(string memberLoginID, int isDeleted);
        string SearchDefault(string guid);
        DataTable SelectAddress_List(CommonPageModel commonModel);
        int Update(ShopNum1_Address address);
    }
}