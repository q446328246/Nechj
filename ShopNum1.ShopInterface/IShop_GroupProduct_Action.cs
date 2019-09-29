using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_GroupProduct_Action
    {
        int AddGroupProduct(ShopNum1_Group_Product Shop_GroupProduct);
        int DeleteGroupProduct(string strId, string strMemloginId);
        DataTable GetGroupProductById(string strId, string MemLoginID);
        DataTable GetGroupProductDetial(string strId);
        DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID, int IsSaled);
        DataTable GetProductById(string GuId, string MemLoginID);
        DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum);

        DataTable SelectGroupProduct(string pagesize, string currentpage, string condition, string resultnum,
            string sortvalue, string ordercolumn);

        int UpdateGroupProduct(ShopNum1_Group_Product Shop_GroupProduct);
    }
}