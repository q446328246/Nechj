using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_VideoComment_Action
    {
        int Add(ShopNum1_VideoComment videoComment_Action);
        int Delete(string guids);
        DataSet GetPageVideoComment(string VideoGuid, string perpagenum, string current_page, string isreturcount);
        DataTable GetVideoCommentList(string guid);
        DataTable GetVideoCommentList(string guid, int isAudit);
        DataTable Search(string guid);
        DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2);
        DataTable SearchByGuid(string guid);
        int UpdateAudit(string StrGuids);
        int UpdateAuditNot(string StrGuids);
    }
}