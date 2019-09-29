using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ImageCategory_Action
    {
        int Delete(string string_0);
        int DeleteType(string strId);
        DataTable ImageCategoryGetAllByFatherID(string fatherid);
        int Insert(string name, string description, string categoryLevel, string fatherID, string family, string user);
        DataTable Search(int fatherid);
        DataTable SearchInfoByID(string strID);

        int Update(string guid, string name, string description, string categoryLevel, string fatherID, string family,
            string user);
    }
}