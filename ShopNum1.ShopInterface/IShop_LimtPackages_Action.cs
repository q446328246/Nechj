using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_LimtPackages_Action
    {
        int AddLimtPackage(ShopNum1_Limt_Package shopNum1__Limt_Package);
        int DeletePackById(string MemloginId, string strAid);
        string ReturnDate(string MemloginId);
        DataTable SelectLastPack(string MemloginId);
        DataTable SelectLimtPackage(string pagesize, string currentpage, string condition, string resultnum);
    }
}