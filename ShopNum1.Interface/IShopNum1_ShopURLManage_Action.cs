using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopURLManage_Action
    {
        int Add(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
        DataTable CheckDoMain(string strDoMain);
        int Delete(string strID);
        DataTable GetEditInfo(string strID);
        DataTable GetShopLoginID(string guids);
        DataTable GetShopValidity(string MemLoginID);
        DataTable Search(string MemLoginID);
        DataTable Search(string MemLoginID, string isAudit);
        DataTable SearchByID(string string_0);
        DataTable SelectGoUrl(string domain);
        int Update(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
        int Update(string strID, string strDoMain, string siteNumber);
        int UpdateIsAudit(string strID, string isAudit);
        DataTable UpdateSearch(string MemLoginID);
        DataTable UrlWriteShopDoMain(string domain);
    }
}