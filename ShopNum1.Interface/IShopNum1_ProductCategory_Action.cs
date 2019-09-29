using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ProductCategory_Action
    {
        int Add(ShopNum1_ProductCategory shopNum1_ProductCategory);
        int AddList(List<ShopNum1_ProductCategory> list_ProductCategory);
        int Delete(string guids);
        int DeleteTypeC(string strID);
        DataTable dt_GetScale(string strCode);
        DataTable GetCategory(string FatherID);
        DataTable GetCategoryBycount(string FatherID, string ShowCountOne);
        DataTable GetCategoryTypeByCategoryID(string categoryid);
        DataTable GetProductCategory(string fatherid, string showcount);
        DataTable GetProductCategoryByID(string ID);
        DataTable GetProductCategoryCode(string code);
        DataTable GetProductCategoryCodeByName(string name);
        DataTable GetProductCategoryMeto(string code);
        DataTable GetProductCategoryName();
        DataTable GetProductCategoryName(string fatherID);
        DataTable GetTwoOverType(int fatherId, string strTopCount);
        DataTable Search(int fatherID, int isDeleted);
        DataTable Search(int fatherID, int isDeleted, string showCount);
        DataTable SearchtProductCategory(int fatherID, int isDeleted);
        DataTable SearchtTwoProductCategory(int fatherID, int isDeleted);
        string strVScale(string strProductGuId);
        int Update(string guid, ShopNum1_ProductCategory shopNum1_ProductCategory);
        int Update_Scale(string strCode, string strScale, string strIsOpen);
        int UpdateCatrgoryInfoCategory(ShopNum1_Category shopNum1_Category);
    }
}