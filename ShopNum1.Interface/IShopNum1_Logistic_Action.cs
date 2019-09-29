using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Logistic_Action
    {
        int Add(ShopNum1_Logistic shopNum1_Logistic);
        int Delete(string string_0);
        bool Exists(string code);
        DataTable GetLogistic(int ID);
        DataTable GetLogistic(string name);
        DataTable Search(int isshow);
        int Update(ShopNum1_Logistic shopNum1_Logistic);
    }
}