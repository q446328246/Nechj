using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_LimtProduct_Action
    {
        int AddLimitProduct(ShopNum1_Limt_Product shopNum1_Limt_Product);
        int DeleteLimitProduct(string strId);
        DataTable GetLimtProdcut(string pagesize, string currentpage, string condition, string resultnum, string strLid);
        DataTable SelectLimtProdcut(string pagesize, string currentpage, string condition, string resultnum);
        int UpdateDisCount(string strDisCount, string strId);
        int UpdateLimitProductStae(string strId, string strState);
    }
}