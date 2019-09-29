using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_VideoComment_Action
    {
        int Add(ShopNum1_Shop_VideoComment videoComment_Action);
        int Delete(string guids);
        DataTable GetVideoCommentList(string guid);
        DataTable Search(string guid);
        DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2);
        DataTable SearchByGuid(string guid);
        int UpdateAudit(string StrGuids);
        int UpdateAuditNot(string StrGuids);
    }
}