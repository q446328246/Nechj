using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Vedio_List_Action
    {
        int Delete(string guids);

        DataTable GetVedioAll(string commentTitle, string VedioName, string createMember, string isAudit,
            string createTime1, string createTime2, string memLoginID);

        DataTable Search(string title, string memLoginID, string commentTime1, string commentTime2, int isAudit);
        int UpdateAudit(string guids, int isAudit);
    }
}