using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_PageAdID_Action
    {
        int Add(PageAdID advertisement);
        int CheckDivID(string divid);
        int Delete(string guids);
        string GetNewDivID();
        DataTable Search(string pagename);
        DataTable SelectByID(string guid);
        int Update(PageAdID advertisement);
    }
}