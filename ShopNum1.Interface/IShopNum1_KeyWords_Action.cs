using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_KeyWords_Action
    {
        int Add(ShopNum1_KeyWords shopnum1_keywords);
        DataTable CheckIsExist(string name, int type);
        int Delete(string guid);
        DataTable GetEditInfo(string guid);
        DataTable Search(string name, string count, int type, int ifshow, int isDelete);
        DataTable SearchName(int count, int type);
        int Update(string guid, ShopNum1_KeyWords shopnum1_keywords);
        int UpdateCount(string name, int type, int count);
    }
}