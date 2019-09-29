using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MessageBoard_Action
    {
        int Add(ShopNum1_MessageBoard messageBoard);
        int Delete(string guids);
        DataTable GetMemloginIDAndIsAuditByGuid(string guid);
        DataTable Search(string guid);
        DataTable Search(string memLoginID, int isDeleted);
        DataTable Search(int isReply, int isAudit, int count);
        DataTable Search(string memLoginID, string sendTime1, string sendTime2, int isDeleted);
        int Update(ShopNum1_MessageBoard messageBoard);
        int UpdateAudit(string guids, int isAudit);
    }
}