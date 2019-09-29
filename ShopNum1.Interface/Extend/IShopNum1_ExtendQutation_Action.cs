using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ExtendQutation_Action
    {
        int Add();
        DataTable Search(int productCategoryID, string brandguid, string name);
        DataTable SearchProduct(int productCategoryID, string brandguid, string name, int IsDeleted);
    }
}