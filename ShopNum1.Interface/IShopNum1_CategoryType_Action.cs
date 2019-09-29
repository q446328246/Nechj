using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_CategoryType_Action
    {
        int Add_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType);
        int Add_CategoryTypeInto(ShopNum1_CategoryType shopNum1_CategoryType);
        int DeleteBatch_CategoryType(string strId);
        string Get_SpValue(string strId);
        int Get_TypeMaxId();
        ShopNum1_CategoryType Select_CategoryType(string strID);
        DataTable Select_ProductCategoryType();
        DataTable SelectCategoryType_List(int pagesize, int currentpage, string strcondition, int resultnum);
        int Update_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType);
        int update_CategoryType_Order(string strorderid, string strId);
    }
}