using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Advertisement_Action
    {
        int Add(Advertisement advertisement);
        int Delete(string guids);
        string GetNewDivID(string filename);
        string GetPath();
        void LoadXml();
        DataTable Search(string pagename, string fileName);
        DataTable Search(string pagename, string fileName, string adID);
        DataTable Search1(string pagename, string fileName);
        DataTable SelectByID(string guid);
        DataTable ShowAD(string filename);
        DataTable ShowADByDivID(string divID);
        DataTable ShowADByDivID(string divID, string type);
        int Update(Advertisement advertisement);
    }
}