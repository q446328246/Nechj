using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Page_Action
    {
        int Add(ShopNum1_Page page);
        int DelPageBySuper(string pageguid);
        DataTable GetOnePage(int isDeleted);
        DataTable GetOnePage(string guid, int isDeleted);
        DataTable GetOnePageBySuper(int isDeleted);
        DataTable GetTopPage(int isDeleted);
        DataTable GetTwopage(int oneID, int isDeleted);
        DataTable GetTwopage(string guid, int oneID, int isDeleted);
        DataTable GetTwopageBySupper(int oneID, int isDeleted);
        int RetrunMaxThreeID(int oneID, int twoID);
        int RetrunMaxTwoID(int oneID);
        DataTable Search(int IsDeleted);
        DataTable Search(string guid, int isDeleted);
        DataTable Search(int oneID, int twoID, int pageType, string name, string pagePath, int isDeleted);
        int Update(ShopNum1_Page page);
    }
}