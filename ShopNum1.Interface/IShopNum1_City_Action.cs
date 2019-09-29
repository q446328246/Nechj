using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_City_Action
    {
        int Add(ShopNum1_City city);
        DataTable CheckIsChilds(string Field, string TableName, string ID);
        int Delete(string string_0);
        DataTable GetCategoryByParam(string param);
        string GetCfCode();
        string GetCmCode(string AddressCode);
        string GetCodeBylevel(int level, int fatherID);
        string GetCsCode(string AddressCode);
        string GetCtCode(string AddressCode);
        DataTable GetDispatchRegionName(string AddressCode);
        string GetNameByID(int int_0);
        DataTable GetProductCategoryMeto(string strID);
        DataTable GetTableByID(int int_0);
        DataTable IsHost(string string_0);
        DataTable Search(int isDeleted);
        DataTable Search(int fatherID, int isDeleted);
        DataTable Search(int fatherID, int isDeleted, int count);
        DataTable Search2(int fatherID, int isDeleted);
        DataTable Search2(string showCount, int fatherID, int isDeleted);
        DataTable SearchCityByLetter(string Letter);
        DataTable SearchCityLetter();
        DataTable SearchHotCity(string showCount);
        DataTable SearchInfoByID(string strID);
        int Update(ShopNum1_City city);
    }
}