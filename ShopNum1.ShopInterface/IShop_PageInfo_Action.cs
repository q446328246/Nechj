using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_PageInfo_Action
    {
        int Add(PageInfo pageInfo);
        int Delete(string guids);
        string GetPath();
        void LoadXml();
        DataTable Search(string pagename);
        DataTable SelectByID(string guid);
        int Update(PageInfo pageInfo);
    }
}