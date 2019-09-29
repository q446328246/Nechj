using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ArticleCheck_Action
    {
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        DataTable Search(string title, string shopID, string startdate, string enddate, int IsAudit, int isDeleted);
        DataTable SearchDetailsByGuid(string guid);
        int UpdateAudit(string guids, int isAudit);
    }
}