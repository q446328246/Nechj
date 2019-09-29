using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Menu_Action
    {
        int Add(ShopNum1_Menu shopnum1_menu);
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        DataTable GetMenuInfo();
        DataTable Search(string guid);
        DataTable Search(string name, int state, string typecode);
        int Update(string guid, ShopNum1_Menu shopnum1_menu);
    }
}