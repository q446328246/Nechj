using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_BadWord_Action
    {
        int Add(ShopNum1_BadWords shopNum1_BadWord);
        DataTable CheckIsExists(string find, string replacement);
        int Delete(string string_0);
        DataTable Edit(int int_0);
        DataTable SearchByName(string name);
        int Updata(ShopNum1_BadWords shopNum1_BadWord);
    }
}