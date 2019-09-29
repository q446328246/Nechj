using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Advertisement_Action
    {
        int Add(Advertisement advertisement);
        int Delete(string guids);
        string GetNewDivID(string filename);
        string GetPath();
        void LoadXml();
        DataTable Search(string pagename, string fileName);
        DataTable SelectByID(string guid);
        DataTable ShowAD(string filename);
        DataTable ShowADByDivID(string divID);
        int Update(Advertisement advertisement);
    }
}