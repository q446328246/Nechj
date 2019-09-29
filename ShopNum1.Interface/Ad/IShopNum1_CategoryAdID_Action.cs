using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_CategoryAdID_Action
    {
        int Add(ShopNum1_CategoryAdID shopNum1_CategoryAdID);
        int Delete(string string_0);
        DataTable Search(string name, string adID);
        int Updata(ShopNum1_CategoryAdID shopNum1_CategoryAdID);
    }
}