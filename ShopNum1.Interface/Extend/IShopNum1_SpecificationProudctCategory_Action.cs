using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SpecificationProudctCategory_Action
    {
        bool Check(string productcategoryid);
        int DeleteByProductCategoryID(string productCategoryID);
        string GetSpecNamesString(string productcategoryid);
        DataTable GetSpecs(string productcategoryid);
        int Insert(string string_0, string productcategoryid, string productcategorycode, string specificationid);
        bool InsertMuch(string productcategoryid, string productcategorycode, string specificationid);
    }
}