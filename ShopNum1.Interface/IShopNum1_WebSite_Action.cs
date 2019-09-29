using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_WebSite_Action
    {
        bool CheckAddressName(string addressname);
        int DeleteById(string string_0);
        DataTable GetAllSite();
        object GetDomainByAddressName(string address);
        DataTable GetSiteByID(string ID);
        bool Insert(ShopNum1_WebSite website);
        bool Update(ShopNum1_WebSite website);
    }
}