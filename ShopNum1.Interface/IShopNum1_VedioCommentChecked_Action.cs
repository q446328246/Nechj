using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_VedioCommentChecked_Action
    {
        int Add(ShopNum1_Shop_Video shop_Video);
        int Delete(string guids);
        int DeleteShopVideoComment(string guid);
        DataTable GetMemLoginIDByGuid(string guid);
        DataTable GetShopVideoByGuid(string guid);
        DataTable MemberShopVideoComment(string memloginid);
        DataTable Search(string memLoginID, int isDeleted);
        DataTable Search(string VideoGuid, int isReply, int isAudit, int count);

        DataTable Search(string Title, string memLoginID, string comment, string CommentTime1, string CommentTime2,
            string replyTime1, string replyTime2, int isReply, int isAudit, string ipAddress, string ShopID);

        DataTable SearchByGuid(string guid);
        int Update(ShopNum1_Shop_Video shop_Video);
        int UpdateAudit(string guids, int isAudit);
    }
}