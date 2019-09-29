using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopArticleComment_Action
    {
        int Add(ShopNum1_ArticleComment articleComment);
        int Delete(string guids);
        int DeleteShopArticleComment(string guid);
        DataTable GetMemloginIDByGuid(string guid);
        DataTable GetShopArticleCommentByGuid(string articleguid);
        DataTable MemberShopArticleComment(string memloginid);
        DataTable Search(string memLoginID, int isDeleted);
        DataTable Search(string articleGuid, int isReply, int isAudit, int count);

        DataTable Search(string title, string memLoginID, string name, string CommentTime1, string CommentTime2,
            string replyTime1, string replyTime2, int isReply, int isAudit, string iPAddress, string shopID);

        DataTable SearchByGuid(string guid);

        DataTable SearchShopArticleComment(string memberloginid, string commenttitle, string articletitle,
            string articlememloginid, string isaudit, string createtime1,
            string createtime2);

        int Shop_NewsCommentAdd(ShopNum1_Shop_NewsComment Shop_NewsComment);
        int Update(ShopNum1_ArticleComment articleComment);
        int UpdateAudit(string guids, int isAudit);
    }
}