using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Page_Action
    {
        int Add(ShopNum1_Page page);
        DataTable GetLeftMenu(string agentLoginID, string userGuid);
        DataTable GetOnePage(int isDeleted, string agentLoginID);
        DataTable GetOnePage(string guid, int isDeleted);
        DataTable GetTopPage(int isDeleted, string agentLoginID);
        DataTable GetTwopage(int oneID, int isDeleted, string agentLoginID);
        DataTable GetTwopage(string guid, int oneID, int isDeleted);
        DataTable MetaGetPage(string guid);
        int RetrunMaxThreeID(int oneID, int twoID, string agentLoginID);
        int RetrunMaxTwoID(int oneID, string agentLoginID);
        DataTable Search(int IsDeleted, string agentLoginID);
        DataTable Search(string guid, int isDeleted, string agentLoginID);

        DataTable Search(int oneID, int twoID, int pageType, string name, string pagePath, int isDeleted,
            string agentLoginID);
    }
}