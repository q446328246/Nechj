using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ProductCategory_Action
    {
        int Add(ShopNum1_Shop_ProductCategory shop_ProductCategory);
        DataTable GetCategory(string code, string codelen, string agentloginid);
        DataTable GetCategoryProc(string FatherID, string idname, string idvalue,int category);
        int GetMaxID(string MemloginId);
        DataTable GetProductCategoryCode(string fatherID);
        DataTable GetProductCategoryCodeProc(string code, string memloginid);
        DataTable GetShopAgentID(string memberLoginID);
        DataTable GetShopMetaBycategory(string code);
        DataTable GetShopProductCategoryCode(string fatherID, string memLoginID);
        DataTable Search(int fatherID, string memLoginID);
        DataTable Search_Import(string FatherID, string MemloginId);
        DataTable SearchShopType(int fatherID, string memLoginID);
        DataTable SetCategoryCode(string code, string strMemloginId);
        int Update(ShopNum1_Shop_ProductCategory shop_ProductCateGory);
        int Update1(string guid, ShopNum1_Shop_ProductCategory agent_ProductCateGory);
    }
}